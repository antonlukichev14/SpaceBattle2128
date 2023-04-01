using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    class Grid
    {
        public Tile[,] tiles;

        public Grid(int width, int height)
        {
            tiles = new Tile[width, height];
        }
    }
}
