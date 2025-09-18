using Microsoft.EntityFrameworkCore;
using TpQuestionnaireManager.Data.Models;

namespace TpQuestionnaireManager.Data.AccessLayers;

public sealed class QuestionRepository
{
    internal TpQuestionnaireManagerDbContext DbContext { get; private set; }

    public QuestionRepository()
    {
        this.DbContext = new TpQuestionnaireManagerDbContext();
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
