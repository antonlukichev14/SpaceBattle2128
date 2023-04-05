namespace SpaceBattle2128
{
    //Класс с настройка игры
    static class Properties
    {
        public static int updateRadius = 30;
        public static Vector2 defaultGameSceneSize = new Vector2(30, 30); // 128, 48
        public static Vector2 renderRadius = new Vector2(10, 10); // 29, 15
        public static bool developmentRender = true;

        public static int seed = 1337; //0 - random value
    }
}
