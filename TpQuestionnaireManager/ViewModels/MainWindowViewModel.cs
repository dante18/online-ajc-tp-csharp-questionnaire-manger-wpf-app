using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TpQuestionnaireManager.Data.AccessLayers;
using TpQuestionnaireManager.Data.Models;

namespace TpQuestionnaireManager.ViewModels;

class MainWindowViewModel : ObservableObject
{
    private readonly QuestionnaireRepository _questionnaireRepository;
    public ObservableCollection<Questionnaire> Questionnaires { get; } = new();

    public MainWindowViewModel() { 
        _questionnaireRepository = new QuestionnaireRepository();
        LoadData();
    }

    private void LoadData()
    {
        var questionnaires = _questionnaireRepository.GetAllQuestionnaires();
        foreach (var q in questionnaires)
        {
            Questionnaires.Add(q);
        }
    }
}
