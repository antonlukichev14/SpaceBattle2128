using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128.Scenes
{
    class WinScene : Scene
    {
        protected override void Render()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("Вы победили");
            Console.Write("\n");
            Console.WriteLine("Нажмите любую кнопку для продолжения");
        }

        protected override void Start()
        {

        }

        protected override void Update()
        {
            Program.ChangeScene(Program.menuScene);
        }
    }
}
