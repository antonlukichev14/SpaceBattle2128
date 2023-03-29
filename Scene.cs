using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    abstract class Scene
    {
        public virtual void Start()
        {
            SceneLoop();
        }

        protected void SceneLoop()
        {
            while (true)
            {
                Update();
                Render();
                Input.SetKey();
            }
        }

        protected abstract void Update();

        protected abstract void Render();
    }
}
