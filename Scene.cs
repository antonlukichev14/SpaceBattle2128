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
            while (Properties.gameIsContinue) // пока игра идёт
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
