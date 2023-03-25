using System;

namespace SpaceBattle2128
{
    class Program
    {
        static Scene startScene;
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
