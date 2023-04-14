using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    class OnlineShop : Item
    {
        public override void Use()
        {
            Program.ChangeScene(Program.shopScene);
        }
    }
}
