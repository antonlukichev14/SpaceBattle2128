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
            new InventorySlot (null, "Ремингтон", 0, false), //Слот под ремингтон
            new InventorySlot (new Granate(3), "Граната х3", 3, true), //Слот под гранату х3
            new InventorySlot (new Granate(5), "Граната х5", 3, true), //Слот под гранату х5
            new InventorySlot (null, "Ловушка одноразовая", 0, false), //Слот под одноразовую ловушка
            new InventorySlot (null, "Ловушка многоразовая", 0, false), //Слот под многоразовую ловушка
            new InventorySlot (null, "Ловушка одноразовая х4", 0, false), //Слот под ловушку одноразовую х4
            new InventorySlot (null, "Ловушка многоразовая х4", 0, false), //Слот под ловушку многоразовую х4
            new InventorySlot (new Teleport(), "Телепорт на базу", 1, true), //Слот под телепорт на базу
            new InventorySlot (null, "Онлайн-магазин", 0, false) //Слот под онлайн магазин
        };

        public static int money = 0;
    }

    class InventorySlot
    {
        public Item item;
        public string itemName;
        public int count;
        public bool enable;

        public InventorySlot(Item item, string itemName, int count, bool enable)
        {
            this.item = item;
            this.itemName = itemName;
            this.count = count;
            this.enable = enable;
        }
    }
}
