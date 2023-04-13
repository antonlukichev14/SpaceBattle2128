using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128.Scenes
{
    class DeathScene : Scene
    {
        protected override void Render()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            if(PlayerStats.livesCount > 0)
            {
                Console.WriteLine("Робот уничтожен.");
                Console.WriteLine("Кол-во роботов в запасе: " + PlayerStats.livesCount + ".");
                Console.WriteLine("Нажмите любую кнопку для продолжения.");
            }
            else
            {
                Console.WriteLine("Робот уничтожен.");
                Console.WriteLine("Кол-во роботов в запасе: " + PlayerStats.livesCount + ".");
                Console.Write("\n");

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Вы проиграли.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n");

                Console.WriteLine("Нажмите любую кнопку для продолжения.");
            }
        }

        protected override void Start()
        {
            PlayerStats.livesCount--;
        }

        protected override void Update()
        {
            if(PlayerStats.livesCount > 0)
            {
                Program.ChangeScene(Program.gameScene1);
            }
            else
            {
                Program.ChangeScene(Program.menuScene);
            }
        }
    }
}
