using System;

namespace SpaceBattle2128
{
    static class Menu
    {


        static string buttomstartGame = "  1.Начать игру(зажмите)";
        static string buttomChangePlayer = "          2.Изменить персонажа";
        static string buttomExitGame = "            3.Выйти из игры";
        static public void RenderMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"             _______..______      ___       ______  _______    .______        ___   .___________.___________. __       _______        ");
            Console.WriteLine(@"            /       ||   _  \    /   \     /      ||   ____|   |   _  \      /   \  |           |           ||  |     |   ____|       ");
            Console.WriteLine(@"           |   (----`|  |_)  |  /  ^  \   |  ,----'|  |__      |  |_)  |    /  ^  \ `---|  |----`---|  |----`|  |     |  |__          ");
            Console.WriteLine(@"            \   \    |   ___/  /  /_\  \  |  |     |   __|     |   _  <    /  /_\  \    |  |        |  |     |  |     |   __|         ");
            Console.WriteLine(@"        .----)   |   |  |     /  _____  \ |  `----.|  |____    |  |_)  |  /  _____  \   |  |        |  |     |  `----.|  |____        ");
            Console.WriteLine(@"        |_______/    | _|    /__/     \__\ \______||_______|   |______/  /__/     \__\  |__|        |__|     |_______||_______|       ");
            Console.WriteLine();
            Console.WriteLine(@"                                              ___     __    ___      ___                                                       ");
            Console.WriteLine(@"                                             |__ \   /_ |  |__ \    / _ \                                                      ");
            Console.WriteLine(@"                                                ) |   | |     ) |  | (_) |                                                     ");
            Console.WriteLine(@"                                               / /    | |    / /    > _ <                                                      ");
            Console.WriteLine(@"                                              / /_    | |   / /_   | (_) |                                                     ");
            Console.WriteLine(@"                                             |____|   |_|  |____|   \___/                                                      ");

            Console.WriteLine("\n\n\n");
            Console.WriteLine($"\t\t\t\t\t\t{buttomstartGame}");
            Console.WriteLine("\n\n");
            Console.WriteLine($"\t\t\t\t\t{buttomChangePlayer}");
            Console.WriteLine("\n\n");
            Console.WriteLine($"\t\t\t\t\t{buttomExitGame}");

        }
        static ConsoleKey ChoiceButtom()
        {
            ConsoleKey input;
            while (true) // input != "1" || input != "2"
            {
                input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.D1 || input == ConsoleKey.D2 || input == ConsoleKey.D3) { break; }
            }
            return input;

        }



        static public void Event(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.D1:
                    while (Properties.gameIsContinue == true)
                    {

                        Scene startScene = new GameScene();
                        Scene currentScene;
                        currentScene = startScene;
                        currentScene.StartScene();
                        if (Properties.gameIsContinue == false)
                        {
                            break;

                        }

                    }
                    break;

                case ConsoleKey.D2:
                    char[] skins = { '@', '\u0001', '\u0002', 'P' };
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Clear();
                    Console.WriteLine("1 2 3 4");
                    foreach (var sk in skins) { Console.Write(sk + " "); }
                    ConsoleKey i;
                    while (true)
                    {
                        i = Console.ReadKey(true).Key;
                        if (i == ConsoleKey.Escape) { break; }

                        char skin = ' ';
                        switch (i)
                        {
                            case ConsoleKey.D1:
                                skin = skins[0];
                                RenderList.renderList[10] = skin;
                                break;
                            case ConsoleKey.D2:
                                skin = skins[1];
                                RenderList.renderList[10] = skin;
                                break;
                            case ConsoleKey.D3:
                                skin = skins[2];
                                RenderList.renderList[10] = skin;
                                break;
                            case ConsoleKey.D4:
                                skin = skins[3];
                                RenderList.renderList[10] = skin;
                                break;
                        }

                        Console.Clear();
                        Console.Write(skin);
                        Console.WriteLine();


                    }
                    break;
                case ConsoleKey.D3:
                    Environment.Exit(0);
                    break;
            }

        }

        static public void MenuLoop()
        {


            while (true)
            {
                Properties.gameIsContinue = true;
                Console.Clear();
                RenderMenu();
                ConsoleKey key = ChoiceButtom();
                Event(key);
            }




        }
    }
}
