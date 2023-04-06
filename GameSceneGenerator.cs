using System;

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

        public static void GenerateGameObjects(Grid grid, GameObject prefab, int count)
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
                {
                    canPlace[x, y] = true;

                    Tile tile = grid.tiles[x, y];
                    if (tile.wall)
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
                        grid.tiles[x, y].currentObject = prefab.Copy();                       
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
            string tag = "SaveZone";
            int width = 5;
            int height = 5;

            int centreX = grid.width / 2;
            int centreY = grid.height / 2;

            FloorObject saveZoneFloor = new FloorObject(2, tag);
            Wall saveZoneWall = new Wall(3, tag);

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

            grid.tiles[szCentreX, centreY].currentFloorObject = saveZoneFloor;
            for (int y = 0; true; y++)
            {
                int localY = centreY - y;
                if (localY < 0) break;
                Tile path = grid.tiles[szCentreX, localY];

                if (path.wall)
                {
                    path.currentObject = null;
                    path.wall = false;
                }
                else break;
            }

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

            grid.tiles[centreX, szCentreY].currentFloorObject = saveZoneFloor;
            for (int x = 0; true; x++)
            {
                int localX = centreX - x;
                if (localX < 0) break;
                Tile path = grid.tiles[localX, szCentreY];

                if (path.wall)
                {
                    path.currentObject = null;
                    path.wall = false;
                }
                else break;
            }

            int playerX = centreX + (width / 2); int playerY = centreY + (height / 2);

            savezonePosition.x = centreX + (width / 2); savezonePosition.y = centreY + (height / 2);

            Player player = new Player(playerX, playerY);
            grid.tiles[playerX, playerY].currentObject = player;
            GameScene.currentGameScene.player = player;
        }
    }
}
