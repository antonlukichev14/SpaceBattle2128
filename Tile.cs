using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    class Tile
    {
        public bool wall = false;

        public EffectObject currentEffectObject;
        public GameObject currentObject = null;
        public FloorObject currentFloorObject = null;
    }
}
