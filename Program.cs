using System;
using SpaceBattle2128.Scenes;
using SpaceBattle2128.Scenes.GameScenes;

namespace SpaceBattle2128
{
    static class Program
    {
        //System Scene
        public static Scene menuScene = new MenuScene();
        public static Scene changeSkinScene = new ChangeSkinScene();
        public static Scene deathScene = new DeathScene();
        public static Scene winScene = new WinScene();
        public static Scene shopScene = new ShopScene();

        //Game Scene
        public static int currentGameScene = 0;
        public static Scene[] gameScenes = { new GameScene1(new Vector2(128, 128), 100) };
        public static Scene currentScene;

        //Запускает первую сцену
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            currentScene = menuScene;
            currentScene.StartScene();
        }

        //Меняет сцену
        public static void ChangeScene(Scene newScene)
        {
            currentScene = newScene;
            currentScene.StartScene();
        }

        public static void ContinueScene(Scene newScene)
        {
            currentScene = newScene;
            currentScene.ContinueScene();
        }
    }
}
