using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128.Scenes
{
    class ChangeSkinScene : Scene
    {
        char[] skins = { '@', '\u0001', '\u0002', 'P' };
        bool skinChange = false;

        protected override void Render()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Выберите внешний вид:");
            Console.WriteLine("1 2 3 4");
            foreach (var sk in skins) { Console.Write(sk + " "); }

            Console.Write("\n\n");

            if (skinChange) Console.WriteLine("Успешное изменение персонажа!");

            Console.Write("\n");

            Console.WriteLine("ESC - вернуться в меню");
        }

        protected override void Start()
        {
            
        }

        protected override void Update()
        {
            switch (Input.GetKey())
            {
                case ConsoleKey.D1:
                    skinChange = true;
                    RenderList.SetChar(10, skins[0]);
                    break;
                case ConsoleKey.D2:
                    skinChange = true;
                    RenderList.SetChar(10, skins[1]);
                    break;
                case ConsoleKey.D3:
                    skinChange = true;
                    RenderList.SetChar(10, skins[2]);
                    break;
                case ConsoleKey.D4:
                    skinChange = true;
                    RenderList.SetChar(10, skins[3]);
                    break;
                case ConsoleKey.Escape:
                    Program.ChangeScene(Program.menuScene);
                    break;
            }
        }
    }
}
