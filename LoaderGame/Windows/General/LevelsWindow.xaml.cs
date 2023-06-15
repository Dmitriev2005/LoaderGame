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
using LoaderGame.Windows.General;

namespace LoaderGame.Windows.General
{
    /// <summary>
    /// Логика взаимодействия для LevelsWindow.xaml
    /// </summary>
    public partial class LevelsWindow : Window
    {
        public LevelsWindow()
        {
            InitializeComponent();
        }
        bool _check = true;
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


        private void recLevelOne_MouseEnter(object sender, MouseEventArgs e)
        {
            Rectangle rectangle = sender as Rectangle;


            rectangle.Fill = new BrushConverter().ConvertFromString("#7F000000") as SolidColorBrush;


        }

        private void recLevelOne_MouseLeave(object sender, MouseEventArgs e)
        {
            Rectangle rectangle = sender as Rectangle;

            rectangle.Fill = new SolidColorBrush(Colors.Transparent);


        }

        private void recLevelOne_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _check = false;
            switch ((sender as Rectangle).Name)
            {
                case "recLevelOne":
                    FirstLevel firstLevel = new FirstLevel();
                    firstLevel.Owner = this;

                    firstLevel.Show();
                    firstLevel.Owner = null;
                    Close();
                    break;
                case "recLevelTwo":
                    SecondLevel secondLevel = new SecondLevel();
                    secondLevel.Owner = this;

                    secondLevel.Show();
                    secondLevel.Owner = null;
                    Close();
                    break;
                case "recLevelThree":
                    ThirdLevel thirdLevel = new ThirdLevel();
                    thirdLevel.Owner = this;

                    thirdLevel.Show();
                    thirdLevel.Owner = null;
                    Close();
                    break;
                default:
                    break;
            }
            _check = true;

        }

        private void imgArrowBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _check = false;
            GeneralMenu generalMenu = new GeneralMenu();
            generalMenu.Owner = this;

            generalMenu.Show();
            generalMenu.Owner = null;
            Close();
        }
    }
}
