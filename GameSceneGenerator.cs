using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    static class GameSceneGenerator
    {
        public static Grid WallsGenerate(int width, int height)
        {
            Grid grid = new Grid(width, height);
            PerlinNoise noise = new PerlinNoise();

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    grid.tiles[x, y].wall = noise.GetNoise(x, y) > 0.1;

            return grid;
        }

        public static Grid GameObjectsGenerate(GameObject prefab, int count, Grid grid)
        {
            //Здесь будет код для генерации объектов на карте.

            return null;
        }
    }
}
