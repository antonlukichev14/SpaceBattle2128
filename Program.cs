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
            scene.Start();
            GameSceneRender.Render(scene);
            //currentScene = startScene;
            //currentScene.Start();
        }

        //Меняет сцену
        static void ChangeScene()
        {

        }
    }
}
