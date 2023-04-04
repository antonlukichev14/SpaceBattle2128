using System;

namespace SpaceBattle2128
{
    static class GameSceneRender
    {
        static public void Render(GameScene scene)
        {
            char[,] renderChar = new char[Properties.renderRadius.x, Properties.renderRadius.y];

            int centerX = Properties.renderRadius.x / 2;
            int centerY = Properties.renderRadius.y / 2;

            for(int x = 0; x < Properties.renderRadius.x; x++)
            {
                for (int y = 0; y < Properties.renderRadius.x; y++)
                {
                    int positionX = scene.player.position.x - centerX + x;
                    int positionY = scene.player.position.y - centerY + y;

                    if (positionX >= 0 && positionX < scene.grid.width && positionY >= 0 && positionY < scene.grid.height)
                    {
                        if (scene.grid.tiles[positionX, positionY].wall) renderChar[x, y] = RenderList.Get(1);
                        else renderChar[x, y] = RenderList.Get(0);

                        if (scene.grid.tiles[positionX, positionY].currentFloorObject != null)
                            renderChar[x, y] = RenderList.Get(scene.grid.tiles[scene.player.position.x - centerX + x, scene.player.position.y - centerY + y].currentFloorObject.renderID);

                        if (scene.grid.tiles[positionX, positionY].currentObject != null)
                            renderChar[x, y] = RenderList.Get(scene.grid.tiles[scene.player.position.x - centerX + x, scene.player.position.y - centerY + y].currentObject.renderID);

                        if (scene.grid.tiles[positionX, positionY].currentEffectObject != null)
                            renderChar[x, y] = RenderList.Get(scene.grid.tiles[scene.player.position.x - centerX + x, scene.player.position.y - centerY + y].currentEffectObject.renderID);
                    }
                    else
                    {
                        renderChar[x, y] = RenderList.Get(0);
                    }
                }
            }

            for(int y = Properties.renderRadius.x - 1; y >= 0; y--)
            {
                for(int x = 0; x < Properties.renderRadius.x; x++)
                {
                    Console.Write(renderChar[x, y]);
                }
                Console.Write("\n");
            }
        }
    }
}
