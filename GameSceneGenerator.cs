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

            //Здесь будет алгоритм создания карты

            return grid;
        }

        public static GameObject[] GameObjectsGenerate(GameObject prefab, int count, bool[,] walls)
        {
            //Здесь будет код для генерации объектов на карте.

            return null;
        }
    }
}
