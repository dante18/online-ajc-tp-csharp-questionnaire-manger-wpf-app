using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TpQuestionnaireManager.Data.AccessLayers;
using TpQuestionnaireManager.Data.Models;
using TpQuestionnaireManager.Services;
using TpQuestionnaireManager.Views;

namespace TpQuestionnaireManager.ViewModels;

class ListeQuestionnaireViewModel : ObservableObject
    {
    private readonly QuestionnaireService questionnaireService;

    public ICommand DeleteCommand { get; set; } = null!;
    public ICommand ModifierCommand { get; } = null!;

    public ObservableCollection<Questionnaire> Questionnaires { get; } = new();

    public ListeQuestionnaireViewModel()
    {
        this.questionnaireService = new QuestionnaireService();
        this.Questionnaires = this.questionnaireService.GetAllQuestionnaires();

        ModifierCommand = new RelayCommand<Questionnaire>(ModifierQuestionnaire);
    }

    private void ModifierQuestionnaire(Questionnaire q)
    {
        var mainWindow = Application.Current.MainWindow as MainWindow;
        mainWindow?.MainFrame.Navigate(new DetailQuestionnaire(q));
    }
}

