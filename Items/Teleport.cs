using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    internal class Teleport: Item
    {
        public override void Use()
        {
            Player player = GameScene.currentGameScene.player;
            Grid grid = GameScene.currentGameScene.grid;
            Vector2 playerPos = player.position;
            Vector2 SZPos = GameScene.currentGameScene.savezonePosition;
            player.MoveTo(SZPos);
        }
    }
}
