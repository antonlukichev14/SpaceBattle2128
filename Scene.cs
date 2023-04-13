using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceBattle2128
{
    abstract class Scene
    {
        public virtual void StartScene()
        {
            Start();
            SceneLoop();
        }

        protected abstract void Start();

        protected void SceneLoop()
        {
            while (true)
            {
                Console.Clear();
                Render();
                Input.SetKey();
                Update();
            }
        }

        protected abstract void Update();

        protected abstract void Render();
    }
}
