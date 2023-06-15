using LoaderGame.Classes;
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
using LoaderGame.Classes;
using LoaderGame.Windows.General;

namespace LoaderGame.Windows.Levels
{
    /// <summary>
    /// Логика взаимодействия для SecondLevel.xaml
    /// </summary>
    public partial class SecondLevel : Window
    {
        public SecondLevel()
        {
            InitializeComponent();
            ListInicialisator();
            Draw();
        }
        private bool _check = true;
        private List<Position> brickBlocks;
        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Fill = new BrushConverter().ConvertFromString("#7F000000") as SolidColorBrush;
            grField.Children.Add(rectangle);

            Grid.SetColumnSpan(rectangle, 7);
            Grid.SetRowSpan(rectangle, 7);

            DialogMenu dialogMenu = new DialogMenu();
            dialogMenu.Owner = this;
            dialogMenu.ShowDialog();

            grField.Children.Remove(rectangle);

        }

        private void btnMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            btnMenu.Background = new BrushConverter().ConvertFromString("#FFF5F5DC") as SolidColorBrush;
        }

        private void btnMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            btnMenu.Background = new BrushConverter().ConvertFromString("#C7C7B5") as SolidColorBrush;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            PlayerControl playerControl = new PlayerControl();
            if (playerControl.Controller(sprBox: sprBox, sprPlayer: sprPlayer, sprTank: sprTank, brickBlocks: brickBlocks, grField: grField, e: e))
            {

                _check = false;
                ThirdLevel thirdLevel = new ThirdLevel();
                thirdLevel.Owner = this;
                thirdLevel.Show();
                thirdLevel.Owner = null;
                Close();

            }

        }
        private void ListInicialisator()
        {
            List<Position> brickBlocksBuffer = new()
            {
                new(1, 4),
                new(2, 3),
                new(3, 4),
                new(2, 1),
                new(5, 2),
                new(5, 4),
                new(0, 6)
            };
            brickBlocks = brickBlocksBuffer;

        }
        private void Draw()
        {
            Map map = new Map();
            map.MapDraw("/Resources/BrickBlock.png", brickBlocks, grField);
        }
        private MessageBoxResult message;
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!(OwnedWindows.Count > 0)&&_check)
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
