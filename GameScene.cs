using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    class GameScene : Scene
    {
        public List<GameObject> gameObjects;
        public bool[,] Walls;

        public override void Start()
        {
            //Создание Player
            
            base.Start();
        }

        protected override void Update()
        {
            GameObjectsUpdate();
        }

        private void GameObjectsUpdate()
        {
            int gameObjectsCount = gameObjects.Count;
            for (int i = 0; i < gameObjectsCount; i++)
            {
                gameObjects[i].Update();
            }
        }

        protected override void Render()
        {
            GameSceneRender.Render();
        }
    }
}
