using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TpQuestionnaireManager.Views
{
    /// <summary>
    /// Logique d'interaction pour DetailQuestionnaire.xaml
    /// </summary>
    public partial class DetailQuestionnaire : Page
    {
        public DetailQuestionnaire()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.MainFrame.Navigate(new ListeQuestionnaire());
        }
    }
}
