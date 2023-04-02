using System;
using System.Diagnostics;

namespace SpaceBattle2128
{
    class Program
    {
        static Scene startScene;
        public static Scene currentScene;

        //Запускает первую сцену
        static void Main(string[] args)
        {
            GameScene scene = new GameScene();
            scene.grid = GameSceneGenerator.GenerateWalls(32, 32);
            for (int y = 0; y < scene.grid.height; y++)
            {
                for (int x = 0; x < scene.grid.width; x++)
                    Console.Write(scene.grid.tiles[x, y].wall ? '#' : ' ');
                Console.WriteLine();
            }
                
            //currentScene = startScene;
            //currentScene.Start();
        }

        //Меняет сцену
        static void ChangeScene()
        {

        }
    }
}
