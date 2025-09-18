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
public sealed partial class ListeQuestionnaireViewModel
{
    private readonly QuestionnaireService questionnaireService;

    public ICommand AjouterCommand { get; set; } = null!;

    public ICommand SupprimerCommand { get; set; } = null!;

    public ICommand ModifierCommand { get; set; } = null!;

    public ObservableCollection<Questionnaire> Questionnaires { get; } = new();

    [ObservableProperty]
    private string? nouveauQuestionnaireTitre;

    [ObservableProperty]
    private string? titreModifie;

    public ListeQuestionnaireViewModel()
    {
        this.questionnaireService = new QuestionnaireService();
        this.Questionnaires = this.questionnaireService.GetAllQuestionnaires();

        this.AjouterCommand = new RelayCommand(this.AjouterQuestionnaire);
        this.ModifierCommand = new RelayCommand<Questionnaire>(this.ModifierQuestionnaire);
        this.SupprimerCommand = new RelayCommand<Questionnaire>(this.SupprimerQuestionnaire);
    }

    private void AjouterQuestionnaire()
    {
        if (string.IsNullOrWhiteSpace(this.nouveauQuestionnaireTitre))
            return;

        var mainWindow = Application.Current.MainWindow as MainWindow;

        var questionnaire = new Questionnaire { Titre = this.nouveauQuestionnaireTitre };
        questionnaireService.AddQuestionnaire(questionnaire);
        Questionnaires.Add(questionnaire);

        this.nouveauQuestionnaireTitre = string.Empty;

        mainWindow?.MainFrame.Navigate(new DetailQuestionnaire(questionnaire));
    }

    private void ModifierQuestionnaire(Questionnaire questionnaire)
    {
        if (questionnaire is not null)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.MainFrame.Navigate(new DetailQuestionnaire(questionnaire));
        }
    }

    private void SupprimerQuestionnaire(Questionnaire? questionnaire)
    {
        if (questionnaire is not null)
        {
            this.questionnaireService.RemoveQuestionnaire(questionnaire);
            this.Questionnaires.Remove(questionnaire);
        }
    }
}

