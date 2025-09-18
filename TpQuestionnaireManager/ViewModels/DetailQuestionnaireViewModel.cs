using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TpQuestionnaireManager.Data.Models;
using TpQuestionnaireManager.Services;
using TpQuestionnaireManager.Views;

namespace TpQuestionnaireManager.ViewModels;

public class DetailQuestionnaireViewModel : ObservableObject
{
    public ICommand RetourAccueilCommand { get; }

    private ObservableCollection<Question> _questions = new();

    public ObservableCollection<Question> Questions
    {
        get => _questions;
        set
        {
            SetProperty(ref _questions, value);
        }
    }

    private Question? _selectedQuestion;
    public Question? SelectedQuestion
    {
        get => _selectedQuestion;
        set => SetProperty(ref _selectedQuestion, value);
    }

    private readonly QuestionService _questionService = new QuestionService();

    public DetailQuestionnaireViewModel(Questionnaire questionnaire)
    {
        var questions = _questionService.GetAllQuestionsByQuestionnaire(questionnaire.Id);
        Questions = new ObservableCollection<Question>(questions);
        RetourAccueilCommand = new RelayCommand(RetourAccueil);
    }

    private void RetourAccueil()
    {
        var mainWindow = Application.Current.MainWindow as MainWindow;
        mainWindow?.MainFrame.Navigate(new ListeQuestionnaire());
    }
}
