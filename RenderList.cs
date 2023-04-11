using System;
using System.Collections.Generic;

namespace SpaceBattle2128
{
    static class RenderList
    {
        static public Dictionary<byte, char> renderList = new Dictionary<byte, char>
        {
            { 0, ' ' }, //wall = false
            { 1, '#' }, //wall = true
            { 2, '*' }, //savezone floor id
            { 3, '^' }, //savezone wall id
            { 4, '\u0003' }, // ♥
            { 10, '\u0001' }, //Player
            { 11, 'K' }, //EnemyKing
            { 12, 'R' }, //EnemyRock
            { 13, 'E' }, //EnemyElephant
            { 14, 'H' }, //EnemyHorse
            { 15, 'Q' } //EnemyQueen
        };

        static public Dictionary<byte, ConsoleColor> colorList = new Dictionary<byte, ConsoleColor>
        {
            { 0, ConsoleColor.White }, //wall = false
            { 1, ConsoleColor.DarkGray }, //wall = true
            { 2, ConsoleColor.Green }, //savezone floor id
            { 3, ConsoleColor.Yellow }, //savezone wall id
            { 4, ConsoleColor.Red },
            { 10, ConsoleColor.DarkGreen },
            { 11, ConsoleColor.Yellow },
            { 12, ConsoleColor.DarkRed },
            { 13, ConsoleColor.DarkYellow },
            { 14, ConsoleColor.Cyan },
            { 15, ConsoleColor.DarkRed }
        };
        public static char Get(byte renderID)
        {
            return renderList[renderID];
        }
        public static ConsoleColor GetColor(byte colorID) { return colorList[colorID]; }
    }
}
