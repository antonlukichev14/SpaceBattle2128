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
        }

    }
}
