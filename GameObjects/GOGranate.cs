using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceBattle2128.GameObjects;

namespace SpaceBattle2128
{
    internal class GOGranate : EffectObject
    {
        int radius;
        int timer;

        Vector2 pos;

        bool[,] bools;

        public GOGranate(int radius, Vector2 position) 
        {
            renderID = 80;

            this.radius = radius;
            this.pos = new Vector2(position);

            timer = radius + 2;             

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

                    tile.wall = false;

                    tile.currentEffectObject = new YellowEffect(xPos, yPos, 1);

                    if (tile.currentObject != null && tile.currentObject.tag == Tags.Player)
                    {
                        GameScene.currentGameScene.PlayerDeath();
                    }

                    if (tile.currentObject != null && tile.currentObject.tag == Tags.Enemy)
                    {
                        Enemy enemy = tile.currentObject as Enemy;
                        if (enemy != null) enemy.dead = true;
                    }

                    tile.currentObject = null;
                    tile.currentFloorObject = null;
                }
            }
        }
    }
}
