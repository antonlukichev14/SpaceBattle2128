using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    class GameScene : Scene
    {
        public Grid grid;

        public override void Start()
        {
            grid = GameSceneGenerator.WallsGenerate(Properties.defaultGameSceneSize.x, Properties.defaultGameSceneSize.y);

            //Другие функции создания локации

            base.Start();
        }

        protected override void Update()
        {
            GameObjectsUpdate();
        }

        private void GameObjectsUpdate()
        {
            //Обновление игровой логики по радиусу
        }

        protected override void Render()
        {
            GameSceneRender.Render();
        }
    }
}
