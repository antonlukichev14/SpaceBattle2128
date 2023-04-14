using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Transactions;
using SpaceBattle2128.GameObjects;

namespace SpaceBattle2128
{
    class Enemy : Actor
    {
        public bool dead = false;
        public int rangeOfDetection;
        protected Enemy(Enemy enemy) : base(enemy) { }

        public override Enemy Copy() { return new Enemy(this); }

        /* public bool TryExecute(Vector2 prelocation) // попытка понять можно ли пройти в точку
        {
            try
            {
                Move(prelocation); // пытаемся выполнить функцию
                return true; // если выполнение не вызвало ошибок, возвращаем true
            }
            catch (Exception)
            {
                return false; // если произошла ошибка, возвращаем false
            }
        }
        */

        public bool TryExecute(Vector2 direction)
        {
            //Проверяет, возможно ли вообще переместиться в эту точку
            if (position.x + direction.x > 0 && position.x + direction.x < GameScene.currentGameScene.grid.width && position.y + direction.y > 0 && position.y + direction.y < GameScene.currentGameScene.grid.height)
            {
                if (GameScene.currentGameScene.grid.tiles[position.x + direction.x, position.y + direction.y].wall == false)
                {
                    return true;
                }
                else return false;
            }
            return false;
        }

        public bool TryExecuteTo(Vector2 _position)
        {
            //Проверяет, возможно ли вообще переместиться в эту точку
            if (_position.x > 0 && _position.x < GameScene.currentGameScene.grid.width && _position.y > 0 && _position.y < GameScene.currentGameScene.grid.height)
            {
                if (GameScene.currentGameScene.grid.tiles[_position.x, _position.y].wall == false)
                {
                    return true;
                }
                else return false;
            }
            return false;
        }

        public void EnemyMoveTo(Vector2 minPos)
        {
            if (minPos.x == GameScene.currentGameScene.player.position.x && minPos.y == GameScene.currentGameScene.player.position.y) 
                GameScene.currentGameScene.PlayerDeath();

            if (GameScene.currentGameScene.grid.tiles[minPos.x, minPos.y].currentFloorObject != null && GameScene.currentGameScene.grid.tiles[minPos.x, minPos.y].currentFloorObject.tag == Tags.Trap)
            {
                GameScene.currentGameScene.grid.tiles[minPos.x, minPos.y].currentEffectObject = new WhiteEffect(minPos.x, minPos.y, 1);
                GameScene.currentGameScene.grid.tiles[position.x, position.y].currentObject = null;
                PlayerStats.enemyKills++;
                return;
            }

            if(dead)
            {
                GameScene.currentGameScene.grid.tiles[position.x, position.y].currentObject = null;
                PlayerStats.enemyKills++;
            }

            MoveTo(minPos);
        }

        public Enemy() { }
        public Enemy(int x, int y, int _rangeOfDetection)
        {
            rangeOfDetection = _rangeOfDetection;
            position = new Vector2(x, y);
        }
    }

    class King : Enemy
    {
        public override King Copy() { return new King(0, 0, rangeOfDetection); }

        public override void Update()
        {
            Vector2 playerPos = GameScene.currentGameScene.player.position;
            if (Vector2.Distance(position, playerPos) <= rangeOfDetection && !GameScene.currentGameScene.playerInSaveZone)
            {
                Vector2 minDistance = new Vector2(position);

                for (int x = -1; x < 2; x++)
                {
                    for (int y = -1; y < 2; y++)
                    {
                        Vector2 possible = new Vector2(position);
                        if (TryExecute(new Vector2(x, y)))
                        {
                            possible.x += x;
                            possible.y += y;

                            float dis1 = Vector2.DistanceFloat(possible, playerPos);
                            float dis2 = Vector2.DistanceFloat(minDistance, playerPos);

                            if (dis1 < dis2)
                            {
                                minDistance = possible;
                            }
                        }
                    }
                }

                EnemyMoveTo(minDistance);
            }
        }
        public King(int x, int y, int _rangeOfDetection) : base(x,y,_rangeOfDetection)
        {
            renderID = 11;
            tag = Tags.Enemy;
        }
    }

    //Посвящено Дуэлью Джонсану
    class Rook : Enemy
    {
        public override Rook Copy() { return new Rook(0, 0, rangeOfDetection); }

        Vector2[] possiblePositions = new Vector2[4] {new Vector2(0, 1), new Vector2(-1, 0), new Vector2(1, 0), new Vector2(0, -1)};

        public override void Update()
        {
            Vector2 playerPos = GameScene.currentGameScene.player.position;
            if (Vector2.Distance(position, playerPos) <= rangeOfDetection && !GameScene.currentGameScene.playerInSaveZone)
            {
                Vector2 minPos = new Vector2(position);
                float minValue = Vector2.DistanceFloat(position, playerPos);

                foreach (Vector2 nope in possiblePositions)
                {
                    for (int k = 1; ; k++)
                    {
                        Vector2 possiblePos = new Vector2(position) + k * new Vector2(nope);
                        if (TryExecuteTo(possiblePos))
                        {
                            float possibleValue = Vector2.DistanceFloat(possiblePos, playerPos);
                            if (possibleValue < minValue)
                            {
                                minValue = possibleValue;
                                minPos = possiblePos;
                            }
                        }
                        else break;
                    }
                }

                EnemyMoveTo(minPos);
            }
        }
        public Rook()
        {
            renderID = 12;
            tag = Tags.Enemy;
        }
        public Rook(int x, int y, int _rangeOfDetection) : base(x, y, _rangeOfDetection)
        {
            renderID = 12;
            tag = Tags.Enemy;
        }
    }

    class Elephant : Enemy
    {
        public override Elephant Copy() { return new Elephant(0, 0, rangeOfDetection); }

        Vector2[] possiblePositions = new Vector2[4] {new Vector2(1, 1), new Vector2(-1, 1), new Vector2(-1, -1), new Vector2(1, -1)};

        public override void Update()
        {
            Vector2 playerPos = GameScene.currentGameScene.player.position;
            if (Vector2.DistanceFloat(position, playerPos) <= rangeOfDetection && !GameScene.currentGameScene.playerInSaveZone)
            {
                Vector2 minPos = new Vector2(position);
                float minValue = Vector2.DistanceFloat(position, playerPos);

                foreach (Vector2 nope in possiblePositions)
                {
                    for (int k = 1; ; k++)
                    {
                        Vector2 possiblePos = new Vector2(position) + k * new Vector2(nope);

                        if (TryExecuteTo(possiblePos))
                        {
                            float possibleValue = Vector2.DistanceFloat(possiblePos, playerPos);
                            if (possibleValue < minValue)
                            {
                                minValue = possibleValue;
                                minPos = possiblePos;
                            }
                        }
                        else break;
                    }

                }

                EnemyMoveTo(minPos);
            }
        }

        public Elephant(int x, int y, int _rangeOfDetection) : base(x, y, _rangeOfDetection)
        {
            renderID = 13;
            tag = Tags.Enemy;
        }
    }

    class Horse : Enemy
    {
        public override Horse Copy() { return new Horse(0, 0, rangeOfDetection); }

        Vector2[] possiblePositions = new Vector2[8] {new Vector2(2, 1), new Vector2(2, -1), new Vector2(-2, 1), new Vector2(-2, -1), new Vector2(1, 2),new Vector2(1, -2), new Vector2(-1, 2),new Vector2(-1, -2)};

        public override void Update()
        {
            Vector2 playerPos = GameScene.currentGameScene.player.position;

            if (Vector2.Distance(position, playerPos) <= rangeOfDetection && !GameScene.currentGameScene.playerInSaveZone)
            {
                Vector2 minPos = new Vector2(position);
                float minValue = Vector2.DistanceFloat(position, playerPos);
                foreach (Vector2 nope in possiblePositions)
                {
                    Vector2 possiblePos = new Vector2(position) + new Vector2(nope);

                    if (TryExecuteTo(possiblePos))
                    {
                        float possibleValue = Vector2.DistanceFloat(possiblePos, playerPos);
                        if (possibleValue < minValue)
                        {
                            minValue = possibleValue;
                            minPos = possiblePos;
                        }
                    }
                }

                EnemyMoveTo(minPos);
            }
        }
        public Horse(int x, int y, int _rangeOfDetection) : base(x, y, _rangeOfDetection)
        {
            renderID = 14;
            tag = Tags.Enemy;
        }
    }

    class Queen : Enemy
    {
        public override Queen Copy() { return new Queen(0, 0, rangeOfDetection); }

        Vector2[] possiblePositions = new Vector2[8]
        {new Vector2(1, 1), new Vector2(0, 1), new Vector2(-1, 1),
         new Vector2(-1, 0), new Vector2(1, 0),
        new Vector2(-1, -1),new Vector2(0, -1), new Vector2(1, -1)};

        public override void Update()
        {
            //Передеать. Читай дизайн документ!
        }
        public Queen(int x, int y, int _rangeOfDetection) : base(x, y, _rangeOfDetection)
        {
            renderID = 15;
            tag = Tags.Enemy;
        }

    }
   
    

}
