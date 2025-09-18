using System.Windows;
using TpQuestionnaireManager.ViewModels;

namespace TpQuestionnaireManager.Views
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = new MainWindowViewModel();
            InitializeComponent();
            MainFrame.Navigate(new ListeQuestionnaire());
        }
    }
}
