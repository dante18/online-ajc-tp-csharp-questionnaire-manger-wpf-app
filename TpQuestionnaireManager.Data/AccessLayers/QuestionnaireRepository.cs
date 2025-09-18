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

    public void Create(Questionnaire questionnaire)
    {
        this.DbContext.Questionnaires.Add(questionnaire);
        this.DbContext.SaveChanges();
    }

    public void UpdateTitle(int id, string title)
    {
        var questionnaire = this.DbContext.Questionnaires.Find(id);

        if (questionnaire is not null)
        {
            questionnaire.Titre = title;
            this.DbContext.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var questionnaire = this.DbContext.Questionnaires.Find(id);

        if (questionnaire is not null)
        {
            this.DbContext.Questionnaires.Remove(questionnaire);
            this.DbContext.SaveChanges();
        }
    }
}