using System;
using System.Collections.Generic;

namespace SpaceBattle2128
{
    static class RenderList
    {
        static Dictionary<byte, char> renderList = new Dictionary<byte, char>
        {
            { 0, ' ' }, //wall = false
            { 1, '#' }, //wall = true
            { 2, '*' }, //savezone floor id
            { 3, '^' }, //savezone wall id

            { 10, '\u0001' } //Player
        };

        static Dictionary<char, byte> reverseList = new Dictionary<char, byte>
        {

            { '#', 1 },
            { '*', 2 },
            { '^', 3},
            { '\u0001', 10}

        };

        static Dictionary<byte, ConsoleColor> colorList = new Dictionary<byte, ConsoleColor>
        {
            { 0, ConsoleColor.White }, //wall = false
            { 1, ConsoleColor.DarkGray }, //wall = true
            { 2, ConsoleColor.Green }, //savezone floor id
            { 3, ConsoleColor.Yellow }, //savezone wall id

   
            { 10, ConsoleColor.Red },

        };
        public static char Get(byte renderID)
        {
            return renderList[renderID];
        }
        public static ConsoleColor GetColor(byte colorID) { return colorList[colorID]; }
        public static byte GetNumber(char c) { return reverseList[c]; }
    }
}
