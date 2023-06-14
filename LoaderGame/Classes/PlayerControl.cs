using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using LoaderGame.Classes;

namespace LoaderGame.Classes
{
    public class PlayerControl
    {
        public bool Controller(Grid grField, Image sprPlayer, Image sprBox, Image sprTank, 
            List<Position> brickBlocks, KeyEventArgs e)
        {
            //Записываем в переменные ограничения, координаты
            int maxPositionX = grField.ColumnDefinitions.Count - 2;
            int maxPositionY = grField.RowDefinitions.Count - 1;

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
            switch (e.Key)
            {
                case Key.Right:
                    //Ограничение персонажа на границы поля и кирпичных стен
                    if (xPlayerPositionInc <= maxPositionX && !brickBlocks.Where(q => q.PositionX == xPlayerPositionInc && q.PositionY == yPlayerPosition).Any())
                        //Ограничение коробки  на границы поля и кирпичные стены, кроме того проверяю есть ли в соседней клетки персонаж
                        if (xPlayerPositionInc == xBoxPosition && yPlayerPosition == yBoxPosition &&
                            !brickBlocks.Where(q => q.PositionX == xBoxPosition + 1 && q.PositionY == yBoxPosition).Any() &&
                            xBoxPosition + 1 <= maxPositionX)
                        {
                            xBoxPosition += 1;
                            Grid.SetColumn(sprPlayer, xPlayerPositionInc);
                            Grid.SetColumn(sprBox, xBoxPosition);

                        }
                        else if (!(xPlayerPositionInc == xBoxPosition && yPlayerPosition == yBoxPosition))
                            Grid.SetColumn(sprPlayer, xPlayerPositionInc);
                    break;
                case Key.Left:
                    if (xPlayerPositionDec >= 0 && !brickBlocks.Where(q => q.PositionX == xPlayerPositionDec && q.PositionY == yPlayerPosition).Any())
                        if (xPlayerPositionDec == xBoxPosition && yPlayerPosition == yBoxPosition &&
                            !brickBlocks.Where(q => q.PositionX == xBoxPosition - 1 && q.PositionY == yBoxPosition).Any() &&
                            xBoxPosition - 1 >= 0)
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
                        !brickBlocks.Where(q => q.PositionX == xBoxPosition && q.PositionY == yBoxPosition - 1).Any() &&
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

            if (xBoxPosition == xTankPosition && yBoxPosition == yTankPosition)
                return true;
            else
                return false;

        }
    }
}
