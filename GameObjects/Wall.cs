using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    public class Wall: GameObject
    {
        public Wall(byte renderID, Tags tag)
        {
            this.renderID = renderID;
            this.tag = tag;
        }
        public override void Update() { }
    }
}
