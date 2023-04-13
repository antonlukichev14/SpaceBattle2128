namespace SpaceBattle2128
{
    abstract class Actor : GameObject
    {
        public void Move(Vector2 direction)
        {
            //Проверяет, возможно ли вообще переместиться в эту точку
            if (position.x + direction.x >= 0 && position.x + direction.x < GameScene.currentGameScene.grid.width && position.y + direction.y >= 0 && position.y + direction.y < GameScene.currentGameScene.grid.height)
            {
                if (GameScene.currentGameScene.grid.tiles[position.x + direction.x, position.y + direction.y].wall == false && GameScene.currentGameScene.grid.tiles[position.x + direction.x, position.y + direction.y].currentObject == null)
                {
                    //Изменяет положение в соответсвующем направлении
                    GameScene.currentGameScene.grid.tiles[position.x, position.y].currentObject = null;
                    GameScene.currentGameScene.grid.tiles[position.x += direction.x, position.y += direction.y].currentObject = this;

                }
            }
        }
        public void MoveTo(Vector2 direction)
        {
            //Проверяет, возможно ли вообще переместиться в эту точку
            if (direction.x > 0 && direction.x < GameScene.currentGameScene.grid.width && direction.y > 0 && direction.y < GameScene.currentGameScene.grid.height)
            {
                if (GameScene.currentGameScene.grid.tiles[direction.x, direction.y].wall == false && GameScene.currentGameScene.grid.tiles[direction.x, direction.y].currentObject == null)
                {
                    //Изменяет положение в соответсвующем направлении
                    GameScene.currentGameScene.grid.tiles[position.x, position.y].currentObject = null;
                    GameScene.currentGameScene.grid.tiles[direction.x, direction.y].currentObject = this;

                    position = direction;

                }
            }
        }

        protected Actor() { }
        protected Actor(Actor actor) : base(actor) { }
    }
}
