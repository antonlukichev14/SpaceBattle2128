using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    public class GameObject
    {
        public byte renderID;
        public Tags tag;

        public Vector2 position;

        public GameObject() { }

        protected GameObject(GameObject gameObject)
        {
            renderID = gameObject.renderID;
            tag = gameObject.tag;
        }

        virtual public GameObject Copy() { return new GameObject(this); }

        public virtual void Update() { }
    }

    public enum Tags
    {
        None,
        Player,
        Enemy,
        Spawner,
        Wall,
        SaveZone,
        ExitZone,
        Trap,
        Shop,
        Money,
        Robot
    }
}
