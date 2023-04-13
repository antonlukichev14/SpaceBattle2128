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

        public static InventorySlot[] inventory = new InventorySlot[9] {
            new InventorySlot (null, 0, false), //Слот под ремингтон
            new InventorySlot (new Granate(3), 0, true), //Слот под гранату х3
            new InventorySlot (new Granate(5), 0, true), //Слот под гранату х5
            new InventorySlot (null, 0, false), //Слот под одноразовую ловушка
            new InventorySlot (null, 0, false), //Слот под многоразовую ловушка
            new InventorySlot (null, 0, false), //Слот под ловушку одноразовую х4
            new InventorySlot (null, 0, false), //Слот под ловушку многоразовую х4
            new InventorySlot (new Teleport(), 0, true), //Слот под телепорт на базу
            new InventorySlot (null, 0, false) //Слот под онлайн магазин
        };
    }

    class InventorySlot
    {
        public Item item;
        public int count;
        public bool enable;

        public InventorySlot(Item item, int count, bool enable)
        {
            this.item = item;
            this.count = count;
            this.enable = enable;
        }
    }
}
