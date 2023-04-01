using System;

namespace SpaceBattle2128
{
    class Player : Actor
    {
        GameObject player = null; // не понял откуда брать player
        public override void Update()
        {
            void Move()
            {
                Input.SetKey();
                switch (Input.GetKey())
                {
                    case ConsoleKey.W:
                        {
                            if (GameScene.currentGameScene.grid.tiles[position.x, position.y - 1].wall == false)
                            {
                                GameScene.currentGameScene.grid.tiles[position.x, position.y].currentObject = null;
                                position.y--;
                                GameScene.currentGameScene.grid.tiles[position.x, position.y].currentObject = player;
                            }
                        }
                        break;

                    case ConsoleKey.S:
                        {
                            if (GameScene.currentGameScene.grid.tiles[position.x, position.y + 1].wall == false)
                            {
                                GameScene.currentGameScene.grid.tiles[position.x, position.y].currentObject = null;
                                position.y++;
                                GameScene.currentGameScene.grid.tiles[position.x, position.y].currentObject = player;
                            }
                        }
                        break;

                    case ConsoleKey.A:
                        {
                            if (GameScene.currentGameScene.grid.tiles[position.x - 1, position.y].wall == false)
                            {
                                GameScene.currentGameScene.grid.tiles[position.x, position.y].currentObject = null;
                                position.x--;
                                GameScene.currentGameScene.grid.tiles[position.x, position.y].currentObject = player;
                            }
                        }
                        break;

                    case ConsoleKey.D:
                        {
                            if (GameScene.currentGameScene.grid.tiles[position.x + 1, position.y].wall == false)
                            {
                                GameScene.currentGameScene.grid.tiles[position.x, position.y].currentObject = null;
                                position.x++;
                                GameScene.currentGameScene.grid.tiles[position.x, position.y].currentObject = player;
                            }
                        }
                        break;

                }

            }

        }

    }
}
