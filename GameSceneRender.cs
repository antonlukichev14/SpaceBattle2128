using System;

namespace SpaceBattle2128
{
    static class GameSceneRender
    {
        static public void Render(GameScene scene)
        {
            for (int y = 0; y < scene.grid.height; y++)
            {
                for (int x = 0; x < scene.grid.width; x++)
                {
                    Console.Write(scene.grid.tiles[x, y]);
                }
                Console.WriteLine();
            }


        }
    }
}
