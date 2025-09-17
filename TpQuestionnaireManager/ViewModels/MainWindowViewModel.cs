using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TpQuestionnaireManager.Data.Models;
using TpQuestionnaireManager.Services;

namespace TpQuestionnaireManager.ViewModels;

class MainWindowViewModel : ObservableObject
{
    private readonly QuestionnaireService questionnaireService;

    public ObservableCollection<Questionnaire> Questionnaires { get; } = new();

    public MainWindowViewModel() { 
        this.questionnaireService = new QuestionnaireService();
        this.Questionnaires = this.questionnaireService.GetAllQuestionnaires();
    }
}
