﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128.GameObjects
{
    class WhiteEffect:EffectObject
    {
        public int timer;

        public override void Update()
        {
            timer--;
            if (timer <= 0) GameScene.currentGameScene.grid.tiles[position.x, position.y].currentEffectObject = null;
        }

        public WhiteEffect(int x, int y, int time)
        {
            timer = time;
            renderID = 71;
            position = new Vector2(x, y);
        }
    }
}
