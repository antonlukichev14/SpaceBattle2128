using System;

namespace SpaceBattle2128
{
    class Player : Actor
    {
        public override void Update()
        {

            switch (Input.GetKey())
            {
                case ConsoleKey.W:
                    Move(new Vector2(0, 1));
                    break;

                case ConsoleKey.S:
                    Move(new Vector2(0, -1));
                    break;

                case ConsoleKey.A:
                    Move(new Vector2(-1, 0));
                    break;

                case ConsoleKey.D:
                    Move(new Vector2(1, 0));
                    break;
            }

            if(GameScene.currentGameScene.grid.tiles[position.x, position.y].currentFloorObject.tag == "SaveZone")
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
