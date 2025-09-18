using System.Collections.ObjectModel;
using TpQuestionnaireManager.Data;
using TpQuestionnaireManager.Data.AccessLayers;
using TpQuestionnaireManager.Data.Models;

namespace TpQuestionnaireManager.Services;

public sealed class QuestionService
{
    private readonly QuestionRepository _repository = new QuestionRepository();

    public List<Question> GetAllQuestionsByQuestionnaire(int questionnaireId)
    {
        return _repository.GetAllQuestionsByQuestionnaireId(questionnaireId);
    } 
}