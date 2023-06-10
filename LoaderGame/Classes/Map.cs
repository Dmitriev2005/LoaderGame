using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace LoaderGame.Classes
{
    public class Map
    {
        public void MapDraw(string sourceBrickBlock, List<Position>brickBlocks, Grid grid)
        {
            foreach (var item in brickBlocks)
            {
                
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(sourceBrickBlock,UriKind.Relative));
                grid.Children.Add(image);
                Grid.SetRow(image, item.PositionY);
                Grid.SetColumn(image, item.PositionX);

            }
        }

    }
}
