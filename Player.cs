using System;

namespace SpaceBattle2128
{
    class Player : Actor
    {
        public override void Update()
        {
            Vector2 playerMove = new Vector2();
            switch (Input.GetKey())
            {
                case ConsoleKey.W:
                    playerMove.x = 0; playerMove.y = -1;
                    Move(playerMove);
                    break;

                case ConsoleKey.S:
                    playerMove.x = 0; playerMove.y = 1;
                    Move(playerMove);
                    break;

                case ConsoleKey.A:
                    playerMove.x = -1; playerMove.y = 0;
                    Move(playerMove);
                    break;

                case ConsoleKey.D:
                    playerMove.x = 1; playerMove.y = 0;
                    Move(playerMove);
                    break;
            }
        }

    }
}
