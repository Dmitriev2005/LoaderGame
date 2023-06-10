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
            int maxPositionX = grField.ColumnDefinitions.Count;
            int maxPositionY = grField.RowDefinitions.Count;

            int xPlayerPosition = Grid.GetColumn(sprPlayer);
            int yPlayerPosition = Grid.GetRow(sprPlayer);

            int xPlayerPositionInc = xPlayerPosition + 1;
            int xPlayerPositionDec = xPlayerPosition - 1;
            int yPlayerPositionInc = yPlayerPosition + 1;
            int yPlayerPositionDec = yPlayerPosition - 1;

            switch (e.Key) {
                case Key.Right:
                    if (xPlayerPositionInc <= maxPositionX && !brickBlocks.Where(q =>q.PositionX==xPlayerPositionInc && q.PositionY == yPlayerPosition).Any())
                            Grid.SetColumn(sprPlayer, xPlayerPositionInc);
                    break;
                case Key.Left:
                    if (xPlayerPositionDec >= 0 && !brickBlocks.Where(q => q.PositionX == xPlayerPositionDec && q.PositionY == yPlayerPosition).Any())
                        Grid.SetColumn(sprPlayer, xPlayerPositionDec);
                    break;
                case Key.Up:
                    if (yPlayerPositionDec >= 0 && !brickBlocks.Where(q => q.PositionX == xPlayerPosition && q.PositionY == yPlayerPositionDec).Any())
                        Grid.SetRow(sprPlayer, yPlayerPositionDec);
                    break;
                case Key.Down:
                    if (xPlayerPositionInc <= maxPositionY && !brickBlocks.Where(q => q.PositionX == xPlayerPosition && q.PositionY == yPlayerPositionInc).Any())
                        Grid.SetRow(sprPlayer, yPlayerPositionInc);
                    break;
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Draw()
        { 
            Map map = new Map();
            map.MapDraw("\\Resources\\BrickBlock.png", brickBlocks, grField);

        }
        private void ListInicialisator()
        {
            List<Position> brickBlocksBuffer = new List<Position>
            {
                new Position(1,0),
                new Position(3,1),
                new Position(1,2),
                new Position(5,4)
            };
            brickBlocks = brickBlocksBuffer;

        }
    }
}
