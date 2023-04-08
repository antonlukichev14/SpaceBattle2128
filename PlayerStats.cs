using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    static class PlayerStats
    {
        public static int enemyKills;
        public static int resourcesCount;
        public static int savezoneDistance
        {
            get
            {
                return Vector2.Distance(GameScene.currentGameScene.savezonePosition, GameScene.currentGameScene.player.position);
            }
        }
        public static int exitzoneDistance
        {
            get
            {
                return Vector2.Distance(GameScene.currentGameScene.exitZonePosition, GameScene.currentGameScene.player.position);
            }
        }
        public static int livesCount;
    }
}
