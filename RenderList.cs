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

            { 10, 'P' } //Player
        };

        public static char Get(byte renderID)
        {
            return renderList[renderID];
        }
    }
}
