using Microsoft.EntityFrameworkCore;
using TpQuestionnaireManager.Data.Models;

namespace TpQuestionnaireManager.Data.AccessLayers;

public sealed class QuestionRepository
{
    private readonly TpQuestionnaireManagerDbContext _context
        = new TpQuestionnaireManagerDbContext();

    public void Create(Question question)
    {
        this._context.Questions.Add(question);
        this._context.SaveChanges();
    }

    public List<Question> GetAllQuestionsByQuestionnaireId(int questionnaireId)
    {
        return _context.Questions
            .Where(q => q.QuestionnaireId == questionnaireId)
            .Include(q => q.ReponseAttendue)
            .Include(q => q.ReponsesPossibles)
            .ToList();
    }
}
