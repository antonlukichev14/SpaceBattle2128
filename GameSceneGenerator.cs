namespace SpaceBattle2128
{
    static class GameSceneGenerator
    {
        public static Grid GenerateWalls(int width, int height)
        {
            Grid grid = new Grid(width, height);
            PerlinNoise noise = new PerlinNoise();

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    grid.tiles[x, y].wall = noise.GetNoise(x, y) > 0.1;

            return grid;
        }

        public static void GenerateGameObjects(Grid grid, GameObject prefab, int count)
        {
            //Здесь будет код для генерации объектов на карте.
        }

        public static void GenerateSaveZone(Grid grid, byte floorID, byte wallID)
        {
            string tag = "SaveZone";
            int width = 5;
            int height = 5;

            int centreX = grid.width / 2;
            int centreY = grid.height / 2;

            FloorObject saveZoneFloor = new FloorObject(floorID, tag);
            Wall saveZoneWall = new Wall(wallID, tag);

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

            int doorX = centreX + (width / 2);
            int doorY = centreY + (height - 1);

            Tile door = grid.tiles[doorX, doorY];
            door.currentObject = null;
            door.currentFloorObject = saveZoneFloor;

            for (int y = 1; true; y++)
            {
                if (doorY + y >= height) break;
                Tile path = grid.tiles[doorX, doorY + y];

                if (path.wall)
                {
                    path.currentFloorObject = saveZoneFloor;
                    path.wall = false;
                }
                else break;
            }
        }
    }
}
