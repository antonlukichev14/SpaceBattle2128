namespace SpaceBattle2128
{
    //Класс с настройка игры
    static class Properties
    {
        public static int updateRadius = 30;
        public static Vector2 defaultGameSceneSize = new Vector2(512, 512);
        public static Vector2 renderRadius = new Vector2(20, 10);
        public static bool developmentRender = false;

        public static int seed = 1337; //0 - random value
    }
}
