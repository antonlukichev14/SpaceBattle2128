﻿namespace SpaceBattle2128
{
    //Класс с настройка игры
    static class Properties
    {
        public static int updateRadius = 50;
        public static Vector2 renderRadius = new Vector2(40, 20);

        public static Vector2 saveZoneSize = new Vector2(5, 5);
        public static string saveZoneTag = "SaveZone";
        public static byte saveZoneRenderIDFloor = 2;
        public static byte saveZoneRenderIDWall = 3;


        public static Vector2 exitZoneSize = new Vector2(3, 3);
        public static string exitZoneTag = "ExitZone";
        public static byte exitZoneRenderIDFloor = 2; //Хз какое...

        public static int seed = 0; //0 - random value
        public static int minSaveExitZoneDistance = 300;
    }
}
