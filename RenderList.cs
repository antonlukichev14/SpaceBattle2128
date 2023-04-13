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

            { 10, '\u0001' }, //Player
            { 11, '1' }, //EnemyKing
            { 12, 'R' }, //EnemyRock
            { 13, 'E' }, //EnemyElephant
            { 14, '2' }, //EnemyHorse
            { 15, 'Q' } //EnemyQueen
        };

        static Dictionary<byte, ConsoleColor> colorList = new Dictionary<byte, ConsoleColor>
        {
            { 0, ConsoleColor.White }, //wall = false
            { 1, ConsoleColor.DarkGray }, //wall = true
            { 2, ConsoleColor.Green }, //savezone floor id
            { 3, ConsoleColor.Yellow }, //savezone wall id

            { 10, ConsoleColor.DarkGreen },
            { 11, ConsoleColor.Red },
            { 12, ConsoleColor.DarkRed },
            { 13, ConsoleColor.DarkYellow },
            { 14, ConsoleColor.Red },
            { 15, ConsoleColor.DarkRed }
        };
        public static char GetChar(byte renderID)
        {
            return renderList[renderID];
        }

        public static void SetChar(byte renderID, char newChar)
        {
            renderList[renderID] = newChar;
        }

        public static ConsoleColor GetColor(byte colorID) { return colorList[colorID]; }
    }
}
