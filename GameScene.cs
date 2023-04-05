using System;

namespace SpaceBattle2128
{
    class GameScene : Scene
    {
        public Grid grid;

        public static GameScene currentGameScene;

        public Player player;

        public int seed;

        public override void Start()
        {
            if (Properties.seed == 0)
            {
                Random random = new Random();
                seed = random.Next(int.MinValue, int.MaxValue);
            }
            else seed = Properties.seed;

            currentGameScene = this;

            grid = GameSceneGenerator.GenerateWalls(Properties.defaultGameSceneSize.x, Properties.defaultGameSceneSize.y);
            GameSceneGenerator.GenerateSaveZone(grid);

            //Другие функции создания локации

            base.Start();
        }

        protected override void Update()
        {
            GameObjectsUpdate();
        }

        private void GameObjectsUpdate()
        {
            player.Update();

            for(int x = player.position.x - Properties.updateRadius; x <= player.position.x + Properties.updateRadius; x++)
            {
                for(int y = player.position.y - Properties.updateRadius; y <= player.position.y + Properties.updateRadius; y++)
                {
                    if((x > 0 && x < grid.width) && (y > 0 && y < grid.height))
                    {
                        if(grid.tiles[x, y].currentObject != null)
                        {
                            grid.tiles[x, y].currentObject.Update();
                        }
                    }
                }
            }
        }

        protected override void Render()
        {
            if (!Properties.developmentRender) GameSceneRender.Render(currentGameScene);
            else GameSceneRender.DevelopmentRender(currentGameScene);
        }
    }
}
