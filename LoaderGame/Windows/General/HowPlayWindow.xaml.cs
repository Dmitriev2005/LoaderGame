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
    /// Логика взаимодействия для HowPlayWindow.xaml
    /// </summary>
    public partial class HowPlayWindow : Window
    {
        public HowPlayWindow()
        {
            InitializeComponent();
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
        bool _check = true;
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
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
