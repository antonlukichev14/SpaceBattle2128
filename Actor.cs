namespace SpaceBattle2128
{
    abstract class Actor : GameObject
    {
        public Vector2 position;

        public void Move(Vector2 direction)
        {
            //Проверяет, возможно ли вообще переместиться в эту точку
            if (GameScene.currentGameScene.grid.tiles[position.x + direction.x, position.y + direction.y].wall == false)
            {
                // проверка на невыход за границы массива
                if (position.x + direction.x > 0 && position.x + direction.x < GameScene.currentGameScene.grid.tiles.GetLength(0) && position.y + direction.y > 0 && position.y + direction.y < GameScene.currentGameScene.grid.tiles.GetLength(1))
                {
                    //Изменяет положение в соответсвующем направлении
                    GameScene.currentGameScene.grid.tiles[position.x, position.y].currentObject = null;
                    GameScene.currentGameScene.grid.tiles[position.x += direction.x, position.y += direction.y].currentObject = this;
                }
            }


        }
    }
}
