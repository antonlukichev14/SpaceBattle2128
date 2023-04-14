using System;

namespace SpaceBattle2128
{
    class Player : Actor
    {
        public override void Update()
        {
            Vector2 move = new Vector2(0, 0);
            switch (Input.GetKey())
            {
                //Обычное перемещение
                case ConsoleKey.W:
                    move = (new Vector2(0, 1));
                    break;

                case ConsoleKey.X:
                    move = (new Vector2(0, -1));
                    break;

                case ConsoleKey.S:
                    move = (new Vector2(0, -1));
                    break;

                case ConsoleKey.A:
                    move = (new Vector2(-1, 0));
                    break;

                case ConsoleKey.D:
                    move = (new Vector2(1, 0));
                    break;

                //Диагональное перемещение
                case ConsoleKey.Q:
                    move = (new Vector2(-1, 1));
                    break;

                case ConsoleKey.C:
                    move = (new Vector2(1, -1));
                    break;

                case ConsoleKey.E:
                    move = (new Vector2(1, 1));
                    break;

                case ConsoleKey.Z:
                    move = (new Vector2(-1, -1));
                    break;

                //Предметы
                case ConsoleKey.D1:
                    if(PlayerStats.inventory[0].count > 0)
                    {
                        PlayerStats.inventory[0].count--;
                        PlayerStats.inventory[0].item.Use();
                    }
                    break;
                case ConsoleKey.D2:
                    if (PlayerStats.inventory[1].count > 0)
                    {
                        PlayerStats.inventory[1].count--;
                        PlayerStats.inventory[1].item.Use();
                    }
                    break;
                case ConsoleKey.D3:
                    if (PlayerStats.inventory[2].count > 0)
                    {
                        PlayerStats.inventory[2].count--;
                        PlayerStats.inventory[2].item.Use();
                    }
                    break;
                case ConsoleKey.D4:
                    if (PlayerStats.inventory[3].count > 0)
                    {
                        PlayerStats.inventory[3].count--;
                        PlayerStats.inventory[3].item.Use();
                    }
                    break;
                case ConsoleKey.D5:
                    if (PlayerStats.inventory[4].count > 0)
                    {
                        PlayerStats.inventory[4].count--;
                        PlayerStats.inventory[4].item.Use();
                    }
                    break;
                case ConsoleKey.D6:
                    if (PlayerStats.inventory[5].count > 0)
                    {
                        PlayerStats.inventory[5].count--;
                        PlayerStats.inventory[5].item.Use();
                    }
                    break;
                case ConsoleKey.D7:
                    if (PlayerStats.inventory[6].count > 0)
                    {
                        PlayerStats.inventory[6].count--;
                        PlayerStats.inventory[6].item.Use();
                    }
                    break;
                case ConsoleKey.D8:
                    if (PlayerStats.inventory[7].count > 0)
                    {
                        PlayerStats.inventory[7].count--;
                        PlayerStats.inventory[7].item.Use();
                    }
                    break;
                case ConsoleKey.D9:
                    if (PlayerStats.inventory[8].count > 0)
                    {
                        PlayerStats.inventory[8].count--;
                        PlayerStats.inventory[8].item.Use();
                    }
                    break;
            }

            Vector2 newPosition = position + move;
            if (newPosition.x > 0 && newPosition.x < GameScene.currentGameScene.grid.width && newPosition.y > 0 && newPosition.y < GameScene.currentGameScene.grid.height && GameScene.currentGameScene.grid.tiles[newPosition.x, newPosition.y].currentObject != null)
            {
                if (GameScene.currentGameScene.grid.tiles[newPosition.x, newPosition.y].currentObject.tag == Tags.Enemy) GameScene.currentGameScene.PlayerDeath();
            }

            Move(move);

            if(GameScene.currentGameScene.grid.tiles[position.x, position.y].currentFloorObject != null)
            {
                CheckFloorObject();
            }
            else
            {
                GameScene.currentGameScene.playerInSaveZone = false;
            }
        }

        public void CheckFloorObject()
        {
            if (GameScene.currentGameScene.grid.tiles[position.x, position.y].currentFloorObject.tag == Tags.SaveZone)
            {
                GameScene.currentGameScene.playerInSaveZone = true;
            }
            else
            {
                GameScene.currentGameScene.playerInSaveZone = false;
            }

            switch (GameScene.currentGameScene.grid.tiles[position.x, position.y].currentFloorObject.tag)
            {
                case Tags.ExitZone:
                    Program.currentGameScene++;
                    if (Program.currentGameScene >= Program.gameScenes.Length) Program.ChangeScene(Program.winScene);
                    else Program.ChangeScene(Program.gameScenes[Program.currentGameScene]);
                    break;
                case Tags.Shop:
                    Program.ChangeScene(Program.shopScene);
                    break;
                case Tags.Money:
                    PlayerStats.money++;
                    GameScene.currentGameScene.grid.tiles[position.x, position.y].currentFloorObject = null;
                    break;
                case Tags.Robot:
                    PlayerStats.livesCount++;
                    GameScene.currentGameScene.grid.tiles[position.x, position.y].currentFloorObject = null;
                    break;
            }
        }

        public Player(int x, int y)
        {
            renderID = 10;
            tag = Tags.Player;

            position = new Vector2(x, y);
        }
    }
}
