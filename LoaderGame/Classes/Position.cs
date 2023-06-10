using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoaderGame.Classes
{
    public class Position
    {
        public Position(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }
}
