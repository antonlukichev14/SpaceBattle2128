using System;

namespace SpaceBattle2128
{
    static class GameSceneRender
    {
        static public void Render(GameScene scene)
        {
            byte wallExeption;
            for (int y = 0; y < scene.grid.tiles.GetLength(1); y++)
            {
                for (int x = 0; x < scene.grid.tiles.GetLength(0); x++)
                {
                    wallExeption = scene.grid.tiles[x, y].wall == false ? Convert.ToByte(0) : Convert.ToByte(1);
                    Console.Write(RenderList.Get(wallExeption));
                }
                Console.WriteLine();
            }


        }
    }
}
