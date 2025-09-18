using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Input;
using TpQuestionnaireManager.Views;

public class DetailQuestionnaireViewModel : ObservableObject
{
    public ICommand RetourAccueilCommand { get; }

    public DetailQuestionnaireViewModel()
    {
        RetourAccueilCommand = new RelayCommand(RetourAccueil);
    }

    private void RetourAccueil()
    {
        var mainWindow = Application.Current.MainWindow as MainWindow;
        mainWindow?.MainFrame.Navigate(new ListeQuestionnaire());
    }
}
