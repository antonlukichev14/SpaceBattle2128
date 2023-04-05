using System;

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
            // Х**ня, надо пределать
            while (true)
            {
                Render();
                Input.SetKey();
                Update();
                Console.Clear();
            }
        }

        protected abstract void Update();

        protected abstract void Render();
    }
}
