using LoaderGame.Classes;
using LoaderGame.Windows.General;
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

namespace LoaderGame.Windows.Levels
{
    /// <summary>
    /// Логика взаимодействия для ThirdLevel.xaml
    /// </summary>
    public partial class ThirdLevel : Window
    {
        public ThirdLevel()
        {
            InitializeComponent();
            ListInicialisator();
            Draw();
        }
        private List<Position> brickBlocks = new List<Position>();

        bool _check = true;
        MessageBoxResult message;
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            PlayerControl playerControl = new PlayerControl();
            if (playerControl.Controller(sprBox: sprBox, sprPlayer: sprPlayer, sprTank: sprTank, brickBlocks: brickBlocks, grField: grField, e: e))
            {
                MessageBox.Show("Поздравляю вы прошли игру!");
                _check = false;
                GeneralMenu generalMenu = new GeneralMenu();
                generalMenu.Owner = this;
                generalMenu.Show();
                generalMenu.Owner = null;
                Close();
            }

        }

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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!(OwnedWindows.Count > 0) && _check)
            {
                message = MessageBox.Show("Вы хотите выйти?", "Потвердите действие", MessageBoxButton.OKCancel);
                if (message == MessageBoxResult.OK)
                    Application.Current.Shutdown();
                else
                    e.Cancel = true;

            }

        }
        private void Draw()
        {
            Map map = new Map();
            //Метод рисования кирпичных стен
            map.MapDraw("\\Resources\\BrickBlock.png", brickBlocks, grField);

        }
        private void ListInicialisator()
        {
            List<Position> brickBlocksBuffer = new List<Position>
            {
                new Position(0,1),
                new Position(1,1),
                new Position(2,1),
                new Position(3,1),
                new Position(3,3),
                new Position(4,5),
                new Position(5,5),
                new Position(1,5),
                new Position(0,5)
            };
            brickBlocks = brickBlocksBuffer;

        }

    }
}
