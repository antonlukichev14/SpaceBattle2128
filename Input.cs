using System;

namespace SpaceBattle2128
{
    static class Input
    {
        private static ConsoleKey inputKey;


        public static void SetKey()
        {
            inputKey = Console.ReadKey(true).Key;
        }

        public static ConsoleKey GetKey()
        {
            return inputKey;
        }
    }
}
