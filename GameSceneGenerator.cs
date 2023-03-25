using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    static class GameSceneGenerator
    {
        static bool[,] WallsGenerate(int width, int height)
        {
            bool[,] walls = new bool[width, height];

            //Здесь будет алгоритм создания карты

            return walls;
        }

        static GameObject[] GameObjectsGenerate(GameObject prefab, int count, bool[,] walls)
        {
            //Здесь будет код для генерации объектов на карте.

            return null;
        }
    }
}
