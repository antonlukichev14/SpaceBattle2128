using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    abstract class GameObject
    {
        public Vector2 position;
        public byte renderID;
        public string tag;
        public byte z; //Перекрытие при рендере
        public bool collider; //Могут ли находится другие объекты на этой клетке. True - не могут.

        public abstract void Update();
    }
}
