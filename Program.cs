﻿using System;

namespace SpaceBattle2128
{
    class Program
    {
        static Scene startScene = new GameScene();
        public static Scene currentScene;

        //Запускает первую сцену
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            currentScene = startScene;
            currentScene.Start();
        }

        //Меняет сцену
        static void ChangeScene()
        {

        }
    }
}
