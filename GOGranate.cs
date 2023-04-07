using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    internal class GOGranate : GameObject
    {
        int radius;
        int timer;

        Vector2 pos;

        bool[,] bools;

        public GOGranate(int radius, Vector2 position) 
        { 
            this.radius = radius;
            this.pos = position;

            timer = radius + 1;             

            bools = new bool[2 * radius + 1, 2 * radius + 1];
            for(int y = 0; y <= radius; y++)
            {
                for (int x = 0; x <= radius; x++) 
                {
                    bool bl = (x * x + y * y <= radius * radius);
                    bools[radius + x, radius + y] = bl;
                    bools[radius - x, radius + y] = bl;
                    bools[radius + x, radius - y] = bl;
                    bools[radius - x, radius - y] = bl;

                }
            }
        }
  
        public override void Update()
        {
            timer--;
            if (timer > 0) return;
            Grid grid = GameScene.currentGameScene.grid;

            for (int y = -radius; y <= radius; y++)
            {
                for (int x = -radius; x <= radius; x++)
                {
                    int xPos = pos.x + x;
                    int yPos = pos.y + y;

                    if (xPos < 0 || yPos < 0 || xPos >= grid.width || yPos >= grid.height) continue;
                    if (!bools[radius + x, radius + y]) continue;

                    Tile tile = grid.tiles[xPos, yPos];

                    if (tile.wall) continue;
                    if (tile.currentObject != null) /* tile.currentObject.Kill()*/;
                }
            }
        }
    }
}
