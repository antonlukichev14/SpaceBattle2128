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
            foreach (var vector in vectors)
            {
                Vector2 trapPos = playerPos + vector;
                if (trapPos.x < 0 || trapPos.y < 0 || trapPos.y >= grid.height || trapPos.x >= grid.width) 
                {
                    continue;
                }
                if (grid.tiles[trapPos.x, trapPos.y].wall) 
                {
                    continue;
                }
                grid.tiles[trapPos.x, trapPos.y].currentFloorObject = new FloorObject(50, Tags.Trap);
            }
        }

    }

}
