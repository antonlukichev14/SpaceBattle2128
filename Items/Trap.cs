using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    internal class Trap : Item
    {
        Vector2[] vectors = new Vector2[4] {new Vector2(1, 1), new Vector2(1, -1), new Vector2(-1, 1), new Vector2(-1, -1) };
        
        public override void Use()
        {
            Vector2 playerPos = GameScene.currentGameScene.player.position;
            Grid grid = GameScene.currentGameScene.grid;
            
            grid.tiles[playerPos.x, playerPos.y].currentFloorObject = new FloorObject(50, Tags.Trap);
        }
    }

}
