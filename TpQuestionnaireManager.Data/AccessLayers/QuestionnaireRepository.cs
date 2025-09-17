using Microsoft.EntityFrameworkCore;
using TpQuestionnaireManager.Data.Models;

namespace TpQuestionnaireManager.Data.AccessLayers;

public sealed class QuestionnaireRepository
{
    internal TpQuestionnaireManagerDbContext DbContext { get; private set; }

    public QuestionnaireRepository()
    {
        this.DbContext = new TpQuestionnaireManagerDbContext();
    }

    public List<Questionnaire> GetAllQuestionnaires()
        => this.DbContext.Questionnaires.ToList();
}
