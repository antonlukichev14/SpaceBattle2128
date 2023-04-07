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
            grid.tiles[SZPos.x, SZPos.y].currentObject = player;
            grid.tiles[playerPos.x, playerPos.y].currentObject = null;
            playerPos = new Vector2(SZPos);
        }
    }
}
