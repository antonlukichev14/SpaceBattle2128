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
                    position.x = 0; position.y = -1;
                    Move(position);
                    break;

                case ConsoleKey.S:
                    position.x = 0; position.y = 1;
                    Move(position);
                    break;

                case ConsoleKey.A:
                    position.x = -1; position.y = 0;
                    Move(position);
                    break;

                case ConsoleKey.D:
                    position.x = 1; position.y = 0;
                    Move(position);
                    break;
            }
        }

    }
}
