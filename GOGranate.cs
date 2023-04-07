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
            timer = radius+1;
            this.pos = position;
         

            bools = new bool[2 * radius + 1, 2 * radius + 1];
            for(int y = 0; y <= radius; y++)
            {
                for (int x = 0; x <= radius; x++) 
                {
                    bool haha = (x * x + y * y <= radius * radius);
                    bools[radius + x, radius + y] = haha;
                    bools[radius - x, radius + y] = haha;
                    bools[radius + x, radius - y] = haha;
                    bools[radius - x, radius - y] = haha;

                }
            }
        }
  
        public override void Update()
        {
            timer--;
            if (timer <= 0)
            {
                Grid grid = GameScene.currentGameScene.grid;
                for (int y = -radius; y <= radius; y++)
                {
                    for (int x = -radius; x <= radius; x++)
                    {
                        int xpos = pos.x + x;
                        int ypos = pos.y + y;
                        if (xpos < 0 || ypos<0 || xpos>= Properties.defaultGameSceneSize.x || ypos >= Properties.defaultGameSceneSize.y)
                        {
                            continue;
                        }
                        if (!bools[radius+x, radius+y]) 
                        {
                            continue;
                        }
                        Tile tile = grid.tiles[xpos, ypos];
                        if (tile.wall) 
                        {
                            continue;
                        }
                        if (tile.currentObject != null) 
                        {
                           // tile.currentObject.Kill(); 
                        }
                    }
                }
            }

        }
    }
}
