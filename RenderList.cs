﻿using System;
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
            {4, 'S' },
            { 10, '\u0001' }, //Player
            { 11, '1' } //EnemyKing
        };

        static Dictionary<char, byte> reverseList = new Dictionary<char, byte>
        {

            { '#', 1 },
            { '*', 2 },
            { '^', 3},
            {'S', 4 },
            { '\u0001', 10},
            { '1', 11 }

        };

        static Dictionary<byte, ConsoleColor> colorList = new Dictionary<byte, ConsoleColor>
        {
            { 0, ConsoleColor.White }, //wall = false
            { 1, ConsoleColor.DarkGray }, //wall = true
            { 2, ConsoleColor.Green }, //savezone floor id
            { 3, ConsoleColor.Yellow }, //savezone wall id
            { 4, ConsoleColor.Blue },


            { 10, ConsoleColor.DarkGreen },
            { 11, ConsoleColor.Red }

        };
        public static char Get(byte renderID)
        {
            return renderList[renderID];
        }
        public static ConsoleColor GetColor(byte colorID) { return colorList[colorID]; }
        public static byte GetNumber(char c) { return reverseList[c]; }
    }
}
