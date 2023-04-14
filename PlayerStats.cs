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
            new InventorySlot (null, "Ремингтон", 0, false, 0), //Слот под ремингтон
            new InventorySlot (new Granate(3), "Граната х3", 3, true, 15), //Слот под гранату х3
            new InventorySlot (new Granate(5), "Граната х5", 3, true, 30), //Слот под гранату х5
            new InventorySlot (null, "Ловушка одноразовая", 0, false, 0), //Слот под одноразовую ловушка
            new InventorySlot (new Trap(), "Ловушка многоразовая", 0, true, 10), //Слот под многоразовую ловушка
            new InventorySlot (null, "Ловушка одноразовая х4", 0, false, 0), //Слот под ловушку одноразовую х4
            new InventorySlot (new Trap_x4(), "Ловушка многоразовая х4", 0, true, 20), //Слот под ловушку многоразовую х4
            new InventorySlot (new Teleport(), "Телепорт на базу", 1, true, 12), //Слот под телепорт на базу
            new InventorySlot (null, "Онлайн-магазин", 0, false, 50) //Слот под онлайн магазин
        };

        public static int money = 0;
    }

    class InventorySlot
    {
        public Item item;
        public string itemName;
        public int count;
        public bool enable;
        public int cost;

        public InventorySlot(Item item, string itemName, int count, bool enable, int cost)
        {
            this.item = item;
            this.itemName = itemName;
            this.count = count;
            this.enable = enable;
            this.cost = cost;
        }
    }
}
