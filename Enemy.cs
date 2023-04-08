using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Transactions;

namespace SpaceBattle2128
{
    class Enemy : Actor
    {
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
        public Enemy() { }
        public Enemy(int x, int y, int _rangeOfDetection)
        {
            rangeOfDetection = _rangeOfDetection;
            position = new Vector2(x, y);
        }
    }

    class King : Enemy
    {
        public override void Update()
        {
            Vector2 playerPos = GameScene.currentGameScene.player.position;
            if (Vector2.Distance(position, playerPos) == rangeOfDetection)
            {
                Vector2 minDistance = position;

                for (int x = -1; x < 2; x++)
                {
                    for (int y = -1; y < 2; y++)
                    {
                        Vector2 possible = position;
                        if (TryExecute(new Vector2(x, y)))
                        {
                            possible.x = possible.x + x;
                            possible.y = possible.y + y;
                            if (Vector2.Distance(possible, playerPos) < Vector2.Distance(minDistance, playerPos))// тут должно быть местоположение игрока
                            {
                                minDistance = possible;
                            }
                        }
                    }
                }
                MoveTo(minDistance);
            }
        }
        public King(int x, int y, int _rangeOfDetection) : base(x,y,_rangeOfDetection)
        {
            renderID = 11;
            tag = "EnemyKing";
        }
    }
    class Rook : Enemy
    {
        Vector2[] possiblePositions = new Vector2[4]
        {new Vector2(0, 1),
         new Vector2(-1, 0), new Vector2(1, 0),
        new Vector2(0, -1)};

        public override void Update()
        {
            Vector2 playerPos = GameScene.currentGameScene.player.position;
            if (Vector2.Distance(position, playerPos) == rangeOfDetection)
            {
                Vector2 minPos = position;
                int minValue = Vector2.Distance(position, playerPos);
                foreach (Vector2 nope in possiblePositions)
                {
                    for (int k = 1; ; k++)
                    {
                        Vector2 possiblePos = position + k * nope;
                        if (TryExecute(possiblePos))
                        {
                            int possibleValue = Vector2.Distance(possiblePos, playerPos);
                            if (possibleValue < minValue)
                            {
                                minValue = possibleValue;
                                minPos = possiblePos;
                            }
                        }
                        else break;
                    }

                }
                MoveTo(minPos);
            }
        }
        public Rook()
        {
            renderID = 2;
            tag = "EnemyRook";
        }
        public Rook(int x, int y, int _rangeOfDetection) : base(x, y, _rangeOfDetection)
        {
            renderID = 2;
            tag = "EnemyRook";
        }

    }
    class Elephant : Enemy
    {
        Vector2[] possiblePositions = new Vector2[4]
        {new Vector2(1, 1),new Vector2(-1, 1),
        new Vector2(-1, -1), new Vector2(1, -1)};

        public override void Update()
        {
            Vector2 playerPos = GameScene.currentGameScene.player.position;
            if (Vector2.Distance(position, playerPos) == rangeOfDetection)
            {
                Vector2 minPos = position;
                int minValue = Vector2.Distance(position, playerPos);
                foreach (Vector2 nope in possiblePositions)
                {
                    for (int k = 1; ; k++)
                    {
                        Vector2 possiblePos = position + k * nope;
                        if (TryExecute(possiblePos))
                        {
                            int possibleValue = Vector2.Distance(possiblePos, playerPos);
                            if (possibleValue < minValue)
                            {
                                minValue = possibleValue;
                                minPos = possiblePos;
                            }
                        }
                        else break;
                    }

                }
                MoveTo(minPos);
            }
        }

        public Elephant(int x, int y, int _rangeOfDetection) : base(x, y, _rangeOfDetection)
        {
            // renderID = ;
            tag = "EnemyElephant";

        }

    }
    class Horse : Enemy
    {
        Vector2[] possiblePositions = new Vector2[8]
        {new Vector2(2, 1), new Vector2(2, -1),
        new Vector2(2, 1), new Vector2(2, 1),
        new Vector2(2, 1),new Vector2(2, 1),
        new Vector2(2, 1),new Vector2(2, 1),};

        public override void Update()
        {
            Vector2 playerPos = GameScene.currentGameScene.player.position;
            if (Vector2.Distance(position, playerPos) == rangeOfDetection)
            {
                Vector2 minPos = position;
                int minValue = Vector2.Distance(position, playerPos);
                foreach (Vector2 nope in possiblePositions)
                {
                    Vector2 possiblePos = position + nope;
                    if (TryExecute(possiblePos))
                    {
                        int possibleValue = Vector2.Distance(possiblePos, playerPos);
                        if (possibleValue < minValue)
                        {
                            minValue = possibleValue;
                            minPos = possiblePos;
                        }
                    }
                }
                MoveTo(minPos);
            }
        }
        public Horse(int x, int y, int _rangeOfDetection) : base(x, y, _rangeOfDetection)
        {
            // renderID = ;
            tag = "EnemyHorse";
        }
    }
    class Queen : Enemy
    {
        Vector2[] possiblePositions = new Vector2[8]
        {new Vector2(1, 1), new Vector2(0, 1), new Vector2(-1, 1),
         new Vector2(-1, 0), new Vector2(1, 0),
        new Vector2(-1, -1),new Vector2(0, -1), new Vector2(1, -1)};

        public override void Update()
        {
            Vector2 playerPos = GameScene.currentGameScene.player.position;
            if (Vector2.Distance(position, playerPos) == rangeOfDetection)
            {
                Vector2 minPos = position;
                int minValue = Vector2.Distance(position, playerPos);
                foreach (Vector2 nope in possiblePositions)
                {
                    for (int k = 1; ; k++)
                    {
                        Vector2 possiblePos = position + k * nope;
                        if (TryExecute(possiblePos))
                        {
                            int possibleValue = Vector2.Distance(possiblePos, playerPos);
                            if (possibleValue < minValue)
                            {
                                minValue = possibleValue;
                                minPos = possiblePos;
                            }
                        }
                        else break;
                    }

                }
                MoveTo(minPos);
            }
        }
        public Queen(int x, int y, int _rangeOfDetection) : base(x, y, _rangeOfDetection)
        {
            // renderID = ;
            tag = "EnemyQueen";
        }

    }
   
    

}
