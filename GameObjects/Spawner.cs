using System;

namespace SpaceBattle2128
{
    class Spawner : GameObject
    {
        public Vector2 position = new Vector2();

        public Spawner(Spawner sp) : base(sp) { }
        public Spawner()
        {
            renderID = 4;
            tag = Tags.Spawner;
        }

        public void Spawn()
        {
            Random random = new Random();
            position.x = random.Next(1, GameScene.currentGameScene.grid.width);
            position.y = random.Next(1, GameScene.currentGameScene.grid.height);

            for (int y = 0; y < GameScene.currentGameScene.grid.height; y++)
            {
                for (int x = 0; x < GameScene.currentGameScene.grid.width; x++)
                {
                    if (GameScene.currentGameScene.grid.tiles[position.x, position.y].wall == false)
                    {
                        GameScene.currentGameScene.grid.tiles[position.x, position.y].currentObject = this;

                    }
                }
            }




        }
    }
}
