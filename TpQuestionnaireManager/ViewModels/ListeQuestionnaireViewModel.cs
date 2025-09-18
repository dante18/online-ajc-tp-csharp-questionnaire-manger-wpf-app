using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TpQuestionnaireManager.Data.Models;
using TpQuestionnaireManager.Services;

namespace TpQuestionnaireManager.ViewModels;

class ListeQuestionnaireViewModel : ObservableObject
    {
    private readonly QuestionnaireService questionnaireService;

    public ICommand DeleteCommand { get; set; } = null!;

    public ObservableCollection<Questionnaire> Questionnaires { get; } = new();

    public ListeQuestionnaireViewModel()
    {
        this.questionnaireService = new QuestionnaireService();
        this.Questionnaires = this.questionnaireService.GetAllQuestionnaires();
    }
}

