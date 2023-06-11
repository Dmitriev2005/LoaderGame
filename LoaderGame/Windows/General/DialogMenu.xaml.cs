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
using System.Windows.Shapes;

namespace LoaderGame.Windows.General
{
    /// <summary>
    /// Логика взаимодействия для DialogMenu.xaml
    /// </summary>
    public partial class DialogMenu : Window
    {
        public DialogMenu()
        {
            InitializeComponent();
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите выйти?", "Потвердите действие", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                Application.Current.Shutdown();
        }

        private void btnContinue_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            button.Background = new BrushConverter().ConvertFromString("#C7C7B5") as SolidColorBrush;
        }

        private void btnContinue_MouseLeave(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            button.Background = new BrushConverter().ConvertFromString("#FFF5F5DC") as SolidColorBrush;

        }

        private void btnLevels_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
