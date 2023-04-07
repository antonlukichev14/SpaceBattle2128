using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    internal class Granate: Item
    {

        int radius;
       
        
        public Granate(int radius) 
        { 
            this.radius = radius;
            
        }

        public override void Use()
        {
            Grid grid = GameScene.currentGameScene.grid;
            Vector2 pos = GameScene.currentGameScene.player.position;
            GOGranate granate = new GOGranate(radius, pos);
            grid.tiles[pos.x, pos.y].currentObject =  granate;
            
        }
    }

}
