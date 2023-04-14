using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128.Scenes
{
    class ShopScene : Scene
    {
        private string purchaseline;

        protected override void Render()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Добро пожаловать в магазин!\nВаш баланс: {0}$,\n", PlayerStats.money);
            for(int i = 0; i < PlayerStats.inventory.Length; i++)
            {
                if (PlayerStats.inventory[i].enable) Console.ForegroundColor = ConsoleColor.White;
                else Console.ForegroundColor = ConsoleColor.DarkGray;

                Console.WriteLine("{0} - {1}, текущее количество: {2}, стоимость: {3}$.", i + 1, PlayerStats.inventory[i].itemName, PlayerStats.inventory[i].count, PlayerStats.inventory[i].cost);
            }

            Console.Write("\n");

            if (!string.IsNullOrWhiteSpace(purchaseline))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(purchaseline + "\n");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("ESC - вернуться в игру.");
        }

        protected override void Start()
        {
            
        }

        protected override void Update()
        {
            int i = 0;
            switch (Input.GetKey())
            {
                case ConsoleKey.Escape:
                    Program.ContinueScene(Program.gameScenes[Program.currentGameScene]);
                    break;

                case ConsoleKey.D1:
                    if(PlayerStats.inventory[i].enable && PlayerStats.money >= PlayerStats.inventory[i].cost)
                    {
                        PlayerStats.money -= PlayerStats.inventory[i].cost;
                        PlayerStats.inventory[i].count++;
                        purchaseline = "Успешная покупка: " + PlayerStats.inventory[i].itemName + ".";
                    }
                    break;
                case ConsoleKey.D2:
                    i = 1;
                    if (PlayerStats.inventory[i].enable && PlayerStats.money >= PlayerStats.inventory[i].cost)
                    {
                        PlayerStats.money -= PlayerStats.inventory[i].cost;
                        PlayerStats.inventory[i].count++;
                        purchaseline = "Успешная покупка: " + PlayerStats.inventory[i].itemName + ".";
                    }
                    break;
                case ConsoleKey.D3:
                    i = 2;
                    if (PlayerStats.inventory[i].enable && PlayerStats.money >= PlayerStats.inventory[i].cost)
                    {
                        PlayerStats.money -= PlayerStats.inventory[i].cost;
                        PlayerStats.inventory[i].count++;
                        purchaseline = "Успешная покупка: " + PlayerStats.inventory[i].itemName + ".";
                    }
                    break;
                case ConsoleKey.D4:
                    i = 3;
                    if (PlayerStats.inventory[i].enable && PlayerStats.money >= PlayerStats.inventory[i].cost)
                    {
                        PlayerStats.money -= PlayerStats.inventory[i].cost;
                        PlayerStats.inventory[i].count++;
                        purchaseline = "Успешная покупка: " + PlayerStats.inventory[i].itemName + ".";
                    }
                    break;
                case ConsoleKey.D5:
                    i = 4;
                    if (PlayerStats.inventory[i].enable && PlayerStats.money >= PlayerStats.inventory[i].cost)
                    {
                        PlayerStats.money -= PlayerStats.inventory[i].cost;
                        PlayerStats.inventory[i].count++;
                        purchaseline = "Успешная покупка: " + PlayerStats.inventory[i].itemName + ".";
                    }
                    break;
                case ConsoleKey.D6:
                    i = 5;
                    if (PlayerStats.inventory[i].enable && PlayerStats.money >= PlayerStats.inventory[i].cost)
                    {
                        PlayerStats.money -= PlayerStats.inventory[i].cost;
                        PlayerStats.inventory[i].count++;
                        purchaseline = "Успешная покупка: " + PlayerStats.inventory[i].itemName + ".";
                    }
                    break;
                case ConsoleKey.D7:
                    i = 6;
                    if (PlayerStats.inventory[i].enable && PlayerStats.money >= PlayerStats.inventory[i].cost)
                    {
                        PlayerStats.money -= PlayerStats.inventory[i].cost;
                        PlayerStats.inventory[i].count++;
                        purchaseline = "Успешная покупка: " + PlayerStats.inventory[i].itemName + ".";
                    }
                    break;
                case ConsoleKey.D8:
                    i = 7;
                    if (PlayerStats.inventory[i].enable && PlayerStats.money >= PlayerStats.inventory[i].cost)
                    {
                        PlayerStats.money -= PlayerStats.inventory[i].cost;
                        PlayerStats.inventory[i].count++;
                        purchaseline = "Успешная покупка: " + PlayerStats.inventory[i].itemName + ".";
                    }
                    break;
                case ConsoleKey.D9:
                    i = 8;
                    if (PlayerStats.inventory[i].enable && PlayerStats.money >= PlayerStats.inventory[i].cost)
                    {
                        PlayerStats.money -= PlayerStats.inventory[i].cost;
                        PlayerStats.inventory[i].count++;
                        purchaseline = "Успешная покупка: " + PlayerStats.inventory[i].itemName + ".";
                    }
                    break;

                default:
                    purchaseline = "";
                    break;
            }
        }
    }
}
