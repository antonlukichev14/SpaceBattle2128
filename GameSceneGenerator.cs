using System;
using System.Collections;
using System.Collections.Generic;

namespace SpaceBattle2128
{
    static class GameSceneGenerator
    {
        public static Grid GenerateWalls(int width, int height)
        {
            Grid grid = new Grid(width, height);
            PerlinNoise noise = new PerlinNoise(GameScene.currentGameScene.seed);

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    grid.tiles[x, y].wall = (noise.GetNoise(x, y) > 0.1);

            return grid;
        }

        public static void GenerateFloorObjects(Grid grid, FloorObject prefab, int count)
        {
            if (count <= 0) return;

            int radius = 5;
            int radius2 = radius * radius;
            bool[,] inRadius = new bool[radius * 2 + 1, radius * 2 + 1];

            inRadius[radius, radius] = true;
            for (int j = 1; j <= radius; j++)
            {
                int j2 = j * j;
                for (int i = 1; i <= radius; i++)
                {
                    bool bl = (i * i + j2 <= radius2);
                    inRadius[radius + i, radius + j] = bl;
                    inRadius[radius - i, radius + j] = bl;
                    inRadius[radius + i, radius - j] = bl;
                    inRadius[radius - i, radius - j] = bl;
                }
            }

            bool[,] canPlace = new bool[grid.width, grid.height];
            for (int y = 0; y < grid.height; y++)
                for (int x = 0; x < grid.width; x++)
                    canPlace[x, y] = false;

            for (int y = radius; y < (grid.height - radius); y++)
                for (int x = radius; x < (grid.width - radius); x++)
                {
                    canPlace[x, y] = true;

                    Tile tile = grid.tiles[x, y];
                    if (tile.wall || tile.currentObject != null)
                    {
                        canPlace[x, y] = false;
                    }
                    if (tile.currentFloorObject != null)
                    {
                        canPlace[x, y] = false;
                        for (int j = 1; j <= radius; j++)
                        {
                            for (int i = 1; i <= radius; i++)
                            {
                                if (inRadius[i, j])
                                {
                                    canPlace[x + i, y + j] = false;
                                    canPlace[x + i, y - j] = false;
                                    canPlace[x - i, y + j] = false;
                                    canPlace[x - i, y - j] = false;
                                }
                            }
                        }

                    }
                }                       

            for (int y = radius; y < (grid.height - radius); y++)
                for (int x = radius; x < (grid.width - radius); x++)
                {
                    if (canPlace[x, y])
                    {
                        x += radius;
                        grid.tiles[x, y].currentFloorObject = prefab.Copy();                       
                        count--;

                        canPlace[x, y] = false;
                        for (int j = 1; j <= radius; j++)
                        {
                            for (int i = 1; i <= radius; i++)
                            {
                                if (inRadius[i, j])
                                {
                                    canPlace[x + i, y + j] = false;
                                    canPlace[x + i, y - j] = false;
                                    canPlace[x - i, y + j] = false;
                                    canPlace[x - i, y - j] = false;
                                }
                            }
                        }

                        if (count <= 0) return;
                    }
                }
        }

        public static void GenerateGameObjects(Grid grid, Enemy prefab, int count)
        {
            if (count <= 0) return;

            int radius = 5;
            int radius2 = radius * radius;
            bool[,] inRadius = new bool[radius * 2 + 1, radius * 2 + 1];

            inRadius[radius, radius] = true;
            for (int j = 1; j <= radius; j++)
            {
                int j2 = j * j;
                for (int i = 1; i <= radius; i++)
                {
                    bool bl = (i * i + j2 <= radius2);
                    inRadius[radius + i, radius + j] = bl;
                    inRadius[radius - i, radius + j] = bl;
                    inRadius[radius + i, radius - j] = bl;
                    inRadius[radius - i, radius - j] = bl;
                }
            }

            bool[,] canPlace = new bool[grid.width, grid.height];
            for (int y = 0; y < grid.height; y++)
                for (int x = 0; x < grid.width; x++)
                    canPlace[x, y] = false;

            for (int y = radius; y < (grid.height - radius); y++)
                for (int x = radius; x < (grid.width - radius); x++)
                {
                    canPlace[x, y] = true;

                    Tile tile = grid.tiles[x, y];
                    if (tile.wall || tile.currentFloorObject != null)
                    {
                        canPlace[x, y] = false;
                    }
                    if (tile.currentObject != null)
                    {
                        canPlace[x, y] = false;
                        for (int j = 1; j <= radius; j++)
                        {
                            for (int i = 1; i <= radius; i++)
                            {
                                if (inRadius[i, j])
                                {
                                    canPlace[x + i, y + j] = false;
                                    canPlace[x + i, y - j] = false;
                                    canPlace[x - i, y + j] = false;
                                    canPlace[x - i, y - j] = false;
                                }
                            }
                        }

                    }
                }

            for (int y = radius; y < (grid.height - radius); y++)
                for (int x = radius; x < (grid.width - radius); x++)
                {
                    if (canPlace[x, y])
                    {
                        x += radius;
                        Enemy copy = prefab.Copy();
                        copy.position = new Vector2(x, y);
                        grid.tiles[x, y].currentObject = copy;
                        count--;

                        canPlace[x, y] = false;
                        for (int j = 1; j <= radius; j++)
                        {
                            for (int i = 1; i <= radius; i++)
                            {
                                if (inRadius[i, j])
                                {
                                    canPlace[x + i, y + j] = false;
                                    canPlace[x + i, y - j] = false;
                                    canPlace[x - i, y + j] = false;
                                    canPlace[x - i, y - j] = false;
                                }
                            }
                        }

                        if (count <= 0) return;
                    }
                }
        }

        public static void GenerateSaveZone(Grid grid, Vector2 savezonePosition)
        {
            string tag = Properties.saveZoneTag;

            byte floorRenderID = Properties.saveZoneRenderIDFloor;
            byte wallRenderID = Properties.saveZoneRenderIDWall;

            int width = Properties.saveZoneSize.x;
            int height = Properties.saveZoneSize.y;

            //int centreX = grid.width / 2;
            //int centreY = grid.height / 2;

            int centreX = 0;
            int centreY = 0;

            FloorObject saveZoneFloor = new FloorObject(floorRenderID, tag);
            Wall saveZoneWall = new Wall(wallRenderID, tag);

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Tile tile = grid.tiles[centreX + x, centreY + y];                   

                    if (x == 0 || y == 0 || x == (width - 1) || y == (height - 1))
                    {
                        tile.currentObject = saveZoneWall;
                        tile.wall = true;
                    }
                    else
                    {
                        tile.currentFloorObject = saveZoneFloor;
                        tile.wall = false;
                    }                      
                }

            int szCentreX = centreX + (width / 2);
            int szCentreY = centreY + (height / 2);

            grid.tiles[szCentreX, centreY + height - 1].currentFloorObject = saveZoneFloor;
            for (int y = height - 1; true; y++)
            {
                int localY = centreY + y;
                if (localY >= grid.height) break;
                Tile path = grid.tiles[szCentreX, localY];

                if (path.wall)
                {
                    path.currentObject = null;
                    path.wall = false;
                }
                else break;
            }

            //grid.tiles[szCentreX, centreY].currentFloorObject = saveZoneFloor;
            //for (int y = 0; true; y++)
            //{
            //    int localY = centreY - y;
            //    if (localY < 0) break;
            //    Tile path = grid.tiles[szCentreX, localY];

            //    if (path.wall)
            //    {
            //        path.currentObject = null;
            //        path.wall = false;
            //    }
            //    else break;
            //}

            grid.tiles[centreX + width - 1, szCentreY].currentFloorObject = saveZoneFloor;
            for (int x = width - 1; true; x++)
            {
                int localX = centreX + x;
                if (localX >= grid.width) break;
                Tile path = grid.tiles[localX, szCentreY];

                if (path.wall)
                {
                    path.currentObject = null;
                    path.wall = false;
                }
                else break;
            }

            //grid.tiles[centreX, szCentreY].currentFloorObject = saveZoneFloor;
            //for (int x = 0; true; x++)
            //{
            //    int localX = centreX - x;
            //    if (localX < 0) break;
            //    Tile path = grid.tiles[localX, szCentreY];

            //    if (path.wall)
            //    {
            //        path.currentObject = null;
            //        path.wall = false;
            //    }
            //    else break;
            //}

            int playerX = centreX + (width / 2); int playerY = centreY + (height / 2);

            savezonePosition.x = centreX + (width / 2); savezonePosition.y = centreY + (height / 2);

            Player player = new Player(playerX, playerY);
            grid.tiles[playerX, playerY].currentObject = player;
            GameScene.currentGameScene.player = player;
        }

        public static void GenerateExitZone(Grid grid)
        {
            string tag = Properties.exitZoneTag;

            byte renderID = Properties.exitZoneRenderIDFloor;

            int width = Properties.exitZoneSize.x;
            int height = Properties.exitZoneSize.y;

            bool[,] bools = new bool[grid.width, grid.width];
            for (int y = 0; y < grid.height; y++)
                for (int x = 0; x < grid.width; x++)
                    bools[x, y] = false;

            Vector2 szSize = Properties.saveZoneSize;
            Vector2[] neighbors = new Vector2[4]
            { new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, -1), new Vector2(-1, 0) };

            Queue<Vector2> queue = new Queue<Vector2>();

            queue.Enqueue(new Vector2(szSize.x / 2, szSize.y));
            queue.Enqueue(new Vector2(szSize.x, szSize.y / 2));

            int maxDistance = 0;
            Vector2 maxPos = new Vector2(0, 0);

            while (queue.Count > 0)
            {
                Vector2 position = queue.Dequeue();
                foreach (Vector2 add in neighbors)
                {
                    Vector2 newPos = position + add;

                    int dx = newPos.x;
                    int dy = newPos.y;

                    if (dx < 0 || dy < 0 || dx >= (grid.width - width) || dy >= (grid.height - height)) continue;
                    if (bools[dx, dy]) continue;
                    if (grid.tiles[dx, dy].wall) continue;

                    bools[dx, dy] = true;
                    queue.Enqueue(newPos);

                    int newDistance = Vector2.Distance(new Vector2(0, 0), newPos);
                    if (newDistance > maxDistance)
                    {
                        maxDistance = newDistance;
                        maxPos = newPos;
                    }
                }
            }

            int centreX = maxPos.x;
            int centreY = maxPos.y;

            FloorObject exitZoneFloor = new FloorObject(renderID, tag);

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Tile tile = grid.tiles[centreX + x, centreY + y];

                    tile.currentFloorObject = exitZoneFloor;
                    tile.wall = false;
                }
        }
    }
}
