using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TpQuestionnaireManager.Data.Models;
using TpQuestionnaireManager.Services;

namespace TpQuestionnaireManager.ViewModels;

class MainWindowViewModel : ObservableObject
{
    private readonly QuestionnaireService questionnaireService;

    public ICommand DeleteCommand { get; set; } = null!;

    public ObservableCollection<Questionnaire> Questionnaires { get; } = new();

    public MainWindowViewModel() { 
        this.questionnaireService = new QuestionnaireService();
        this.Questionnaires = this.questionnaireService.GetAllQuestionnaires();
        this.DeleteCommand = new RelayCommand<Questionnaire>(this.DeleteQuestionnaire);
    }

    private void DeleteQuestionnaire(Questionnaire? questionnaire)
    {
        if (questionnaire is not null)
        {
            this.questionnaireService.RemoveQuestionnaire(questionnaire);
            this.Questionnaires.Remove(questionnaire);
        }
    }
}
