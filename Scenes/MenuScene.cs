﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128.Scenes
{
    class MenuScene : Scene
    {
        string buttomstartGame = "1.Новая игра";
        string buttomcontinuegame = "2.Продолжить игру";
        string buttomChangePlayer = "3.Изменить персонажа";
        string buttomExitGame = "4.Выйти из игры";

        protected override void Render()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\n");
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

            if (SaveSystem.CheckSave())
            {
                Console.WriteLine("\n\n");
                Console.WriteLine($"\t\t\t\t\t\t{buttomcontinuegame}");
            }

            Console.WriteLine("\n\n");
            Console.WriteLine($"\t\t\t\t\t\t{buttomChangePlayer}");
            Console.WriteLine("\n\n");
            Console.WriteLine($"\t\t\t\t\t\t{buttomExitGame}");
        }

        protected override void Start()
        {

        }

        protected override void Update()
        {
            switch (Input.GetKey())
            {
                case ConsoleKey.D1:
                    SaveSystem.NewGame();
                    Program.ChangeScene(Program.gameScenes[Program.currentGameScene]);
                    break;
                case ConsoleKey.D2:
                    if (!SaveSystem.CheckSave()) return;
                    SaveSystem.Load();
                    Program.ChangeScene(Program.gameScenes[Program.currentGameScene]);
                    break;
                case ConsoleKey.D3:
                    Program.ChangeScene(Program.changeSkinScene);
                    break;
                case ConsoleKey.D4:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
