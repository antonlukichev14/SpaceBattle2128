using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    abstract class Actor : GameObject
    {
        public void Move(Vector2 direction)
        {
            //Изменяет положение в соответсвующем направлении
            //Проверяет, возможно ли вообще переместиться в эту точку
        }
    }
}
