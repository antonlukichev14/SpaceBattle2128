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
            }

            Vector2 newPosition = position + move;
            if (GameScene.currentGameScene.grid.tiles[newPosition.x, newPosition.y].currentObject != null)
            {
                if (GameScene.currentGameScene.grid.tiles[newPosition.x, newPosition.y].currentObject.tag == "Enemy") GameScene.currentGameScene.PlayerDeath();
            }

            Move(move);

            if (GameScene.currentGameScene.grid.tiles[position.x, position.y].currentFloorObject?.tag == "SaveZone")
            {
                GameScene.currentGameScene.playerInSaveZone = true;
            }
            else
            {
                GameScene.currentGameScene.playerInSaveZone = false;
            }
        }

        public Player(int x, int y)
        {
            renderID = 10;
            tag = "Player";

            position = new Vector2(x, y);
        }
    }
}
