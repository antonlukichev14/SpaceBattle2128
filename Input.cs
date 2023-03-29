using System;

namespace SpaceBattle2128
{
    static class Input
    {
        private static char inputChar;

        public static void SetKey()
        {
            inputChar = Console.ReadKey().KeyChar;
        }

        public static char GetKey()
        {
            return inputChar;
        }
    }
}
