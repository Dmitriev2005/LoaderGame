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
using LoaderGame.Windows.Levels;

namespace LoaderGame.Windows.General
{
    /// <summary>
    /// Логика взаимодействия для GeneralMenu.xaml
    /// </summary>
    public partial class GeneralMenu : Window
    {
        public GeneralMenu()
        {
            InitializeComponent();
        }
        private bool _check = true;
        private void btnStart_MouseLeave(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            button.Background = new BrushConverter().ConvertFromString("#FFF5F5DC") as SolidColorBrush;

        }

        private void btnStart_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            button.Background = new BrushConverter().ConvertFromString("#C7C7B5") as SolidColorBrush;

        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            _check = false;
            FirstLevel firstLevel = new FirstLevel();
            firstLevel.Owner = this;
            firstLevel.Show();
            firstLevel.Owner = null;
            Close();
        }

        private void btnLevels_Click(object sender, RoutedEventArgs e)
        {
            _check = false;
            LevelsWindow levelsWindow = new LevelsWindow();
            levelsWindow.Owner = this;
            levelsWindow.Show();
            levelsWindow.Owner = null;
            Close();
        }

        private void btnHowPlay_Click(object sender, RoutedEventArgs e)
        {
            _check = false;
            HowPlayWindow howPlayWindow = new();
            howPlayWindow.Owner = this;
            howPlayWindow.Show();
            howPlayWindow.Owner = null;
            Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        MessageBoxResult message;
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_check)
            {
                message = MessageBox.Show("Вы хотите выйти?", "Потвердите действие", MessageBoxButton.OKCancel);
                if (message == MessageBoxResult.OK)
                    Application.Current.Shutdown();
                else
                    e.Cancel = true;

            }

        }

    }
}
