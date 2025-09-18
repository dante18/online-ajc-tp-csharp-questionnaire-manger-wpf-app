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

    public void Create(Question question)
    {
        this.DbContext.Questions.Add(question);
        this.DbContext.SaveChanges();
    }

    public List<Question> GetAllQuestionsByQuestionnaireId(int questionnaireId)
    {
        return this.DbContext.Questions
            .Where(q => q.QuestionnaireId == questionnaireId)
            .Include(q => q.ReponseAttendue)
            .Include(q => q.ReponsesPossibles)
            .ToList();
    }
}
