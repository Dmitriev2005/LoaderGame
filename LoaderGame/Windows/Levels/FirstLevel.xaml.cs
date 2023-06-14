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
    /// Логика взаимодействия для FirstLevel.xaml
    /// </summary>
    public partial class FirstLevel : Window
    {
        public FirstLevel()
        {
            InitializeComponent();
            ListInicialisator();
            Draw();
        }
        private List<Position> brickBlocks = new List<Position>();

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //Класс управления
            PlayerControl playerControl = new PlayerControl();
            if (playerControl.Controller(sprBox: sprBox, sprPlayer: sprPlayer, sprTank: sprTank, brickBlocks: brickBlocks, grField: grField, e: e))
            {
                _check = false;
                SecondLevel secondLevel = new SecondLevel();
                secondLevel.Owner = this;
                secondLevel.Show();
                secondLevel.Owner = null;
                Close();
            }

        }
        MessageBoxResult message;
        bool _check = true;
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!(OwnedWindows.Count > 0)&& _check)
            {
                message = MessageBox.Show("Вы хотите выйти?", "Потвердите действие", MessageBoxButton.OKCancel);
                if (message == MessageBoxResult.OK)
                    Application.Current.Shutdown();
                else
                    e.Cancel = true;

            }
        }
        //Метод инициализатор, экземпляра класса 
        private void Draw()
        { 
            Map map = new Map();
            //Метод рисования кирпичных стен
            map.MapDraw("\\Resources\\BrickBlock.png", brickBlocks, grField);

        }
        //Метод инициализатор списка, координат крипичных стен
        private void ListInicialisator()
        {
            List<Position> brickBlocksBuffer = new List<Position>
            {
                new Position(1,0),
                new Position(3,1),
                new Position(1,2),
                new Position(2,4),
                new Position(3,4)
            };
            brickBlocks = brickBlocksBuffer;

        }

        private void btnMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            btnMenu.Background = new BrushConverter().ConvertFromString("#C7C7B5") as SolidColorBrush;
        }

        private void btnMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            btnMenu.Background = new BrushConverter().ConvertFromString("#FFF5F5DC") as SolidColorBrush;
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
    }
}
