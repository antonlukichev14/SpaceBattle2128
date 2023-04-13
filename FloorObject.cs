using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    class FloorObject
    {
        public byte renderID;
        public Tags tag;

        public FloorObject(byte renderID, Tags tag)
        {
            this.renderID = renderID; this.tag = tag;
        }

        private FloorObject(FloorObject floorObject)
        {
            renderID = floorObject.renderID;
            tag = floorObject.tag;
        }

        public FloorObject Copy() { return new FloorObject(this); }
    }
}
