using Microsoft.EntityFrameworkCore;
using TpQuestionnaireManager.Data.Models;

namespace TpQuestionnaireManager.Data.AccessLayers;

public sealed class QuestionRepository
{
    internal TpQuestionnaireManagerDbContext DbContext { get; private set; }
    private readonly ReponseRepository reponseRepository;

    public QuestionRepository()
    {
        this.DbContext = new TpQuestionnaireManagerDbContext();
        this.reponseRepository = new ReponseRepository();
    }

    public List<Question> GetAllQuestionsByQuestionnaireId(int questionnaireId)
    {
        return this.DbContext.Questions
            .Where(q => q.QuestionnaireId == questionnaireId)
            .Include(q => q.ReponseAttendue)
            .Include(q => q.ReponsesPossibles)
            .ToList();
    }

    public void Create(Question question, Reponse reponseAttendue)
    {
        // Pour eviter le probleme de Circular Dependency au de la liaison entre les tables Questions et Reponses
        this.DbContext.Questions.Add(question);
        this.DbContext.SaveChanges();

        question.ReponseAttendueId = question.ReponsesPossibles.First(r => r.Texte == reponseAttendue.Texte).Id;
        this.DbContext.SaveChanges();
    }

    public void Update(Question updatedQuestion, Reponse updatedReponseAttendue)
    {
        var existingQuestion = this.DbContext.Questions
            .Include(q => q.ReponsesPossibles)
            .FirstOrDefault(q => q.Id == updatedQuestion.Id);

        if (existingQuestion is null)
            return;

        this.DbContext.Entry(existingQuestion).CurrentValues.SetValues(updatedQuestion);

        existingQuestion.ReponseAttendueId = null;
        this.DbContext.SaveChanges();

        foreach (var ancienneReponse in existingQuestion.ReponsesPossibles.ToList())
        {
            this.reponseRepository.Delete(ancienneReponse);
        }

        foreach (var reponse in updatedQuestion.ReponsesPossibles)
        {
            reponse.Id = 0;
            this.DbContext.Reponses.Add(reponse);
        }

        this.DbContext.SaveChanges();

        existingQuestion.ReponseAttendueId = updatedQuestion.ReponsesPossibles
            .FirstOrDefault(r => r.Texte == updatedReponseAttendue.Texte)?.Id;

        this.DbContext.SaveChanges();
    }





    public void Delete(int id)
    {
        var question = this.DbContext.Questions.Find(id);

        if (question is not null)
        {
            // Pour eviter le probleme de Circular Dependency au de la liaison entre les tables Questions et Reponses
            question.ReponseAttendueId = null;
            this.DbContext.SaveChanges();

            this.DbContext.Questions.Remove(question);
            this.DbContext.SaveChanges();
        }
    }
}
