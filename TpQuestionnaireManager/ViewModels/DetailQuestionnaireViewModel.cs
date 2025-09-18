using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TpQuestionnaireManager.Data.Models;
using TpQuestionnaireManager.Services;
using TpQuestionnaireManager.Views;

namespace TpQuestionnaireManager.ViewModels;

[ObservableObject]
public sealed partial class DetailQuestionnaireViewModel
{
    private readonly QuestionService questionService;

    public ICommand RetourAccueilCommand { get; set; } = null!;

    public ObservableCollection<Question> Questions { get; set; } = new();

    [ObservableProperty]
    private Questionnaire questionnaire;

    [ObservableProperty]
    private string? questionnaireTitre;

    [ObservableProperty]
    private Question? selectedQuestion;

    public DetailQuestionnaireViewModel(Questionnaire q)
    {
        this.Questionnaire = q;
        this.QuestionnaireTitre = $"Gestion du questionnaire : {q.Titre}";

        this.questionService = new QuestionService();
        this.Questions = this.questionService.GetAllQuestionsByQuestionnaire(q.Id);

        RetourAccueilCommand = new RelayCommand(RetourAccueil);
    }

    private void RetourAccueil()
    {
        var mainWindow = Application.Current.MainWindow as MainWindow;
        mainWindow?.MainFrame.Navigate(new ListeQuestionnaire());
        this.QuestionnaireTitre = "";
    }
}
