using System;

namespace SpaceBattle2128
{
    static class GameSceneRender
    {
        static public void Render(GameScene scene)
        {
            char[,] renderChar = new char[Properties.renderRadius.x, Properties.renderRadius.y];
            ConsoleColor[,] renderColor = new ConsoleColor[Properties.renderRadius.x, Properties.renderRadius.y];

            int centerX = Properties.renderRadius.x / 2;
            int centerY = Properties.renderRadius.y / 2;

            for (int x = 0; x < Properties.renderRadius.x; x++)
            {
                for (int y = 0; y < Properties.renderRadius.y; y++)
                {
                    int positionX = scene.player.position.x - centerX + x;
                    int positionY = scene.player.position.y - centerY + y;

                    if (positionX >= 0 && positionX < scene.grid.width && positionY >= 0 && positionY < scene.grid.height)
                    {
                        if (scene.grid.tiles[positionX, positionY].wall) 
                        { renderChar[x, y] = RenderList.GetChar(1); renderColor[x, y] = RenderList.GetColor(1); }
                        else { renderChar[x, y] = RenderList.GetChar(0); renderColor[x, y] = RenderList.GetColor(0); }

                        if (scene.grid.tiles[positionX, positionY].currentFloorObject != null)
                        {
                            renderColor[x, y] = RenderList.GetColor(scene.grid.tiles[scene.player.position.x - centerX + x, scene.player.position.y - centerY + y].currentFloorObject.renderID);
                            renderChar[x, y] = RenderList.GetChar(scene.grid.tiles[scene.player.position.x - centerX + x, scene.player.position.y - centerY + y].currentFloorObject.renderID);
                        }

                        if (scene.grid.tiles[positionX, positionY].currentObject != null)
                        {
                            renderColor[x, y] = RenderList.GetColor(scene.grid.tiles[scene.player.position.x - centerX + x, scene.player.position.y - centerY + y].currentObject.renderID);
                            renderChar[x, y] = RenderList.GetChar(scene.grid.tiles[scene.player.position.x - centerX + x, scene.player.position.y - centerY + y].currentObject.renderID);
                        }

                        if (scene.grid.tiles[positionX, positionY].currentEffectObject != null)
                        {
                            renderColor[x, y] = RenderList.GetColor(scene.grid.tiles[scene.player.position.x - centerX + x, scene.player.position.y - centerY + y].currentEffectObject.renderID);
                            renderChar[x, y] = RenderList.GetChar(scene.grid.tiles[scene.player.position.x - centerX + x, scene.player.position.y - centerY + y].currentEffectObject.renderID);
                        }
                    }
                    else
                    {
                        renderChar[x, y] = RenderList.GetChar(0);
                    }
                }
            }

            for (int y = Properties.renderRadius.y - 1; y >= 0; y--)
            {
                for (int x = 0; x < Properties.renderRadius.x; x++)
                {
                    if (renderChar[x, y] != ' ')
                    {
                        Console.ForegroundColor = renderColor[x, y];
                        Console.Write(renderChar[x, y]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }


                    else { Console.Write(renderChar[x, y]); }
                }
                Console.Write("\n");
            }

            Console.Write("\n");

            Console.WriteLine("����������:");
            Console.WriteLine("���������� ������ ������: {0}, ���������� �����: {1}$, ��������� �� ���������� ����: {2}, ��������� �� ������: {3}, ���������� ���������� �������: {4}, ������� �������: {5}.", PlayerStats.enemyKills, PlayerStats.money, PlayerStats.savezoneDistance, PlayerStats.exitzoneDistance, PlayerStats.livesCount, Program.currentGameScene + 1);
            Console.WriteLine("���������� ������: {0}, {1}.", scene.player.position.x, scene.player.position.y);

            Console.Write("\n");
            Console.WriteLine("����������:");
            Console.Write("WAXD QEZC - �����������, ");

            for(int i = 0; i < PlayerStats.inventory.Length; i++)
            {
                if(PlayerStats.inventory[i].enable && PlayerStats.inventory[i].count > 0)
                {
                    Console.Write("{0} - {1} (x{2}), ", i + 1, PlayerStats.inventory[i].itemName, PlayerStats.inventory[i].count);
                }
            }

            Console.Write("ESC - ����������� � ��������� � ����.");
        }
    }
}
