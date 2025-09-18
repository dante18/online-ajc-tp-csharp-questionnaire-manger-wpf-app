using System.Collections.ObjectModel;
using TpQuestionnaireManager.Data;
using TpQuestionnaireManager.Data.AccessLayers;
using TpQuestionnaireManager.Data.Models;

namespace TpQuestionnaireManager.Services;

public sealed class QuestionService
{
    private readonly QuestionRepository questionRepository;

    public QuestionService()
    {
        this.questionRepository = new QuestionRepository();
    }

    public ObservableCollection<Question> GetAllQuestionsByQuestionnaire(int questionnaireId)
        => new ObservableCollection<Question>(this.questionRepository.GetAllQuestionsByQuestionnaireId(questionnaireId));
}