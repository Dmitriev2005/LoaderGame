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
            //Записываем в переменные ограничения, координаты
            int maxPositionX = grField.ColumnDefinitions.Count-1;
            int maxPositionY = grField.RowDefinitions.Count-1;

            int xPlayerPosition = Grid.GetColumn(sprPlayer);
            int yPlayerPosition = Grid.GetRow(sprPlayer);

            int xBoxPosition = Grid.GetColumn(sprBox);
            int yBoxPosition = Grid.GetRow(sprBox);

            int xTankPosition = Grid.GetColumn(sprTank);
            int yTankPosition = Grid.GetRow(sprTank);

            int xPlayerPositionInc = xPlayerPosition + 1;
            int xPlayerPositionDec = xPlayerPosition - 1;
            int yPlayerPositionInc = yPlayerPosition + 1;
            int yPlayerPositionDec = yPlayerPosition - 1;

            //Определяем что делаем, при нажатии определенной клавиши
            switch (e.Key) {
                case Key.Right:
                    //Ограничение персонажа на границы поля и кирпичных стен
                    if (xPlayerPositionInc <= maxPositionX && !brickBlocks.Where(q =>q.PositionX==xPlayerPositionInc && q.PositionY == yPlayerPosition).Any())
                        //Ограничение коробки  на границы поля и кирпичные стены, кроме того проверяю есть ли в соседней клетки персонаж
                        if(xPlayerPositionInc == xBoxPosition && yPlayerPosition == yBoxPosition&& 
                            !brickBlocks.Where(q => q.PositionX==xBoxPosition + 1 && q.PositionY==yBoxPosition).Any()&&
                            xBoxPosition + 1 <= maxPositionX) 
                        {
                            xBoxPosition += 1;
                            Grid.SetColumn(sprPlayer, xPlayerPositionInc);
                            Grid.SetColumn(sprBox, xBoxPosition);

                        }
                        else if(!(xPlayerPositionInc == xBoxPosition && yPlayerPosition == yBoxPosition))
                            Grid.SetColumn(sprPlayer, xPlayerPositionInc);
                    break;
                case Key.Left:
                    if (xPlayerPositionDec >= 0 && !brickBlocks.Where(q => q.PositionX == xPlayerPositionDec && q.PositionY == yPlayerPosition).Any())
                        if (xPlayerPositionDec == xBoxPosition && yPlayerPosition == yBoxPosition && 
                            !brickBlocks.Where(q => q.PositionX == xBoxPosition - 1 && q.PositionY == yBoxPosition).Any() &&
                            xBoxPosition-1>=0)
                        {
                            xBoxPosition -= 1;
                            Grid.SetColumn(sprPlayer, xPlayerPositionDec);
                            Grid.SetColumn(sprBox, xBoxPosition);

                        }
                        else if (!(xPlayerPositionDec == xBoxPosition && yPlayerPosition == yBoxPosition))
                            Grid.SetColumn(sprPlayer, xPlayerPositionDec);
                    break;
                case Key.Up:
                    if (yPlayerPositionDec >= 0 && !brickBlocks.Where(q => q.PositionX == xPlayerPosition && q.PositionY == yPlayerPositionDec).Any())
                        if (xPlayerPosition == xBoxPosition && yPlayerPositionDec == yBoxPosition &&
                        !brickBlocks.Where(q => q.PositionX == xBoxPosition && q.PositionY == yBoxPosition-1).Any() &&
                        yBoxPosition - 1 >= 0)
                        {
                            yBoxPosition -= 1;
                            Grid.SetRow(sprPlayer, yPlayerPositionDec);
                            Grid.SetRow(sprBox, yBoxPosition);

                        }
                    else if (!(xPlayerPosition == xBoxPosition && yPlayerPositionDec == yBoxPosition))
                        Grid.SetRow(sprPlayer, yPlayerPositionDec);
                    break;
                case Key.Down:
                    if (yPlayerPositionInc <= maxPositionY && !brickBlocks.Where(q => q.PositionX == xPlayerPosition && q.PositionY == yPlayerPositionInc).Any())
                        if (xPlayerPosition == xBoxPosition && yPlayerPositionInc == yBoxPosition &&
                            !brickBlocks.Where(q => q.PositionX == xBoxPosition && q.PositionY == yBoxPosition + 1).Any() &&
                            yBoxPosition + 1 <= maxPositionY)
                        {
                            yBoxPosition += 1;
                            Grid.SetRow(sprPlayer, yPlayerPositionInc);
                            Grid.SetRow(sprBox, yBoxPosition);

                        }
                        else if (!(xPlayerPosition == xBoxPosition && yPlayerPositionInc == yBoxPosition))
                            Grid.SetRow(sprPlayer, yPlayerPositionInc);

                    break;
            }
            //Провера на бак
            if (xBoxPosition == xTankPosition && yBoxPosition == yTankPosition)
                MessageBox.Show("Вы прошли уровень!");

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
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
                new Position(5,4),
                new Position(2,4),
                new Position(3,4)
            };
            brickBlocks = brickBlocksBuffer;

        }
    }
}
