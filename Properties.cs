using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    //Класс с настройка игры
    static class Properties
    {
        public static int updateRadius = 30;
        public static Vector2 defaultGameSceneSize = new Vector2(512, 512);
        public static Vector2 renderRadius = new Vector2(29, 15);
        public static bool developmentRender = false;

        public static int seed = 1337; //0 - random value
    }
}
