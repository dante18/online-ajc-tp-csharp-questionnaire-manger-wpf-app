using System.Collections.ObjectModel;
using TpQuestionnaireManager.Data;
using TpQuestionnaireManager.Data.AccessLayers;
using TpQuestionnaireManager.Data.Models;

namespace TpQuestionnaireManager.Services;

public sealed class QuestionnaireService
{
    private readonly QuestionnaireRepository questionnaireRepository;

    public QuestionnaireService()
    {
        this.questionnaireRepository = new QuestionnaireRepository();
    }

    public ObservableCollection<Questionnaire> GetAllQuestionnaires()
        => new ObservableCollection<Questionnaire>(this.questionnaireRepository.GetAllQuestionnaires());

    public void AddQuestionnaire(Questionnaire questionnaire)
        => this.questionnaireRepository.Create(questionnaire);


    public void UpdateQuestionnaireTitle(int id, string newTitle)
        => this.questionnaireRepository.UpdateTitle(id, newTitle);

    public void RemoveQuestionnaire(Questionnaire questionnaire)
        => this.questionnaireRepository.Delete(questionnaire.Id);
}
