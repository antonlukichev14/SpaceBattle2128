using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace SpaceBattle2128
{
    static class SaveSystem
    {
        static string path = "save.sv";

        public static void Save()
        {
            string jsonSave = JsonSerializer.Serialize(new SaveClass());

            using(FileStream fs = File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(jsonSave);
                fs.Write(info, 0, info.Length);
            }
        }

        public static void Load()
        {
            string jsonSave = File.ReadAllText(path);
            SaveClass save = JsonSerializer.Deserialize<SaveClass>(jsonSave);

            Program.currentGameScene = save.currentGameScene;
            PlayerStats.enemyKills = save.enemyKill;
            PlayerStats.livesCount = save.livesCount;
            PlayerStats.money = save.money;

            for(int i = 0; i < PlayerStats.inventory.Length; i++)
            {
                PlayerStats.inventory[i].count = save.inventoryCount[i];
            }
        }

        public static void NewGame()
        {
            Program.currentGameScene = 0;
            PlayerStats.enemyKills = 0;
            PlayerStats.livesCount = 3;
            PlayerStats.money = 0;
            
            foreach(InventorySlot slot in PlayerStats.inventory)
            {
                slot.count = 0;
            }
        }

        public static bool CheckSave()
        {
            return File.Exists(path);
        }

        class SaveClass
        {
            public int currentGameScene { get; set; }
            public int enemyKill { get; set; }
            public int livesCount { get; set; }
            public int money { get; set; }
            public int[] inventoryCount { get; set; }

            public SaveClass()
            {
                currentGameScene = Program.currentGameScene;
                enemyKill = PlayerStats.enemyKills;
                livesCount = PlayerStats.livesCount;
                money = PlayerStats.money;

                inventoryCount = new int[9];

                for(int i = 0; i < PlayerStats.inventory.Length; i++)
                {
                    inventoryCount[i] = PlayerStats.inventory[i].count;
                }
            }
        }
    }
}
