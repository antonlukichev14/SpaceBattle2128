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
        public string tag;

        public GameObject() { }

        protected GameObject(GameObject gameObject)
        {
            renderID = gameObject.renderID;
            tag = gameObject.tag;
        }

        virtual public GameObject Copy() { return new GameObject(this); }

        public virtual void Update() { }
    }
}
