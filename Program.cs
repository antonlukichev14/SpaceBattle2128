using System;
using System.Diagnostics;

namespace SpaceBattle2128
{
    class Program
    {
        static Scene startScene = new GameScene();
        public static Scene currentScene;

        //Запускает первую сцену
        static void Main(string[] args)
        {
            currentScene = startScene;
            currentScene.Start();
        }

        //Меняет сцену
        static void ChangeScene()
        {

        }
    }
}
