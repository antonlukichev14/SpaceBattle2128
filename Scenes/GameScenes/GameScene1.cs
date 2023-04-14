using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128.Scenes.GameScenes
{
    class GameScene1:GameScene
    {
        protected override void GenerateCustom()
        {
            GameSceneGenerator.GenerateEnemies(grid, new King(0, 0, 15), 50);
            GameSceneGenerator.GenerateFloorObjects(grid, new FloorObject(50, Tags.Trap), 250);
            GameSceneGenerator.GenerateFloorObjects(grid, new FloorObject(60, Tags.Money), 100);
        }

        public GameScene1(Vector2 size, int minSaveExitZoneDistance) : base(size, minSaveExitZoneDistance) { }
    }
}
