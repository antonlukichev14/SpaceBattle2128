using System;
using System.Collections.Generic;

namespace SpaceBattle2128
{
    class GameScene : Scene
    {
        public Grid grid;

        public static GameScene currentGameScene;

        public Vector2 savezonePosition = new Vector2(); //Для статистики
        public Vector2 exitZonePosition = new Vector2(); //Для статистики

        public Player player;

        public int seed;

        public bool playerInSaveZone; //Для того, чтобы не обновлять врагов, когда игрок в savezone

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
            GameSceneGenerator.GenerateSaveZone(grid, savezonePosition);
            GameSceneGenerator.GenerateExitZone(grid, exitZonePosition);

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

            List<GameObject> gameobjects = new List<GameObject>();

            for(int x = player.position.x - Properties.updateRadius; x <= player.position.x + Properties.updateRadius; x++)
            {
                for(int y = player.position.y - Properties.updateRadius; y <= player.position.y + Properties.updateRadius; y++)
                {
                    if((x > 0 && x < grid.width) && (y > 0 && y < grid.height))
                    {
                        if(grid.tiles[x, y].currentObject != null && grid.tiles[x, y].currentObject.tag != "Player")
                        {
                            gameobjects.Add(grid.tiles[x, y].currentObject);
                        }
                    }
                }
            }

            foreach(GameObject gameObject in gameobjects)
            {
                gameObject.Update();
            }
        }

        protected override void Render()
        {
            if (!Properties.developmentRender) GameSceneRender.Render(currentGameScene);
            else GameSceneRender.DevelopmentRender(currentGameScene);
        }
    }
}
