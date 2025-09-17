using System.Collections.ObjectModel;
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
}
