using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    class Grid
    {
        public int width { get; private set; }
        public int height { get; private set; }

        public Tile[,] tiles;

        public Grid(int width, int height)
        {
            tiles = new Tile[width, height];
            this.width = width;
            this.height = height;

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    tiles[x, y] = new Tile();
        }

        public Grid() { }
    }
}
