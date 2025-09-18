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

    public ICommand AjouterCommand { get; set; } = null!;

    public ICommand ModifierCommand { get; set; } = null!;

    public ICommand SupprimerCommand { get; set; } = null!;

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
        this.SelectedQuestion = new Question()
        {
            Text = string.Empty,
            ReponsesPossibles = new List<Reponse>
            {
                new Reponse { Texte = string.Empty },
                new Reponse { Texte = string.Empty },
                new Reponse { Texte = string.Empty },
                new Reponse { Texte = string.Empty }
            },
            Questionnaire = this.Questionnaire
        };

        this.RetourAccueilCommand = new RelayCommand(this.RetourAccueil);
        this.AjouterCommand = new RelayCommand(this.AjouterQuestion);
        this.ModifierCommand = new RelayCommand(this.ModifierQuestion);
        this.SupprimerCommand = new RelayCommand(this.SupprimerQuestion);
    }

    private void RetourAccueil()
    {
        var mainWindow = Application.Current.MainWindow as MainWindow;
        mainWindow?.MainFrame.Navigate(new ListeQuestionnaire());
        this.QuestionnaireTitre = "";
    }

    private void AjouterQuestion()
    {
        Question question = new Question()
        {
            Text = this.SelectedQuestion.Text,
            ReponsesPossibles = this.SelectedQuestion.ReponsesPossibles,
            QuestionnaireId = this.Questionnaire.Id
        };
        Reponse responseAttendue = this.SelectedQuestion.ReponseAttendue;

        this.questionService.AddQuestion(question, responseAttendue);

        this.Questions.Add(this.SelectedQuestion);
        this.SelectedQuestion = null;
    }

    private void ModifierQuestion()
    {
        if (this.SelectedQuestion is null)
            return;

        Reponse responseAttendue = this.SelectedQuestion.ReponseAttendue ??
            this.SelectedQuestion.ReponsesPossibles.FirstOrDefault()!;

        this.questionService.UpdateQuestion(this.SelectedQuestion, responseAttendue);
    }

    private void SupprimerQuestion()
    {
        if (this.SelectedQuestion is not null)
        {
            this.questionService.RemoveQuestion(this.SelectedQuestion);
            this.Questions.Remove(this.SelectedQuestion);
        }
    }
}
