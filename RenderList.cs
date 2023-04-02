using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    static class RenderList
    {
        static Dictionary<byte, char> renderList = new Dictionary<byte, char>
        {
            { 0, ' ' },
            { 1, '#' }
        };

        static char Get(byte renderID)
        {
            return renderList[renderID];
        }
    }
}
