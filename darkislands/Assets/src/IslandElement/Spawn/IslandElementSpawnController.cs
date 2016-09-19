using Boo.Lang;

namespace DarkIslands
{
    public partial class IslandElementSpawnController
    {
        private float remainingTime;
        private bool isSpawn;
        private IslandElement elem;
        private IslandElementSpawnControllerFactory fac;

        public override void Init(IslandElement IslandElement, IslandElementSpawnControllerFactory IslandElementSpawnControllerFactory)
        {
            IslandElement.SpawnController = this;
            elem = IslandElement;
            base.Init(IslandElement, IslandElementSpawnControllerFactory);
            this.fac = IslandElementSpawnControllerFactory;
        }

        public void SetSpawn(float remainingTime)
        {
            if (!fac.active.Contains(this))
                fac.active.Add(this);
            this.remainingTime = remainingTime;
            isSpawn = true;
        }

        public void DisableSpawn()
        {
            fac.active.Remove(this);
            isSpawn = false;
        }

        public void Update(float deltaTime)
        {
            remainingTime -= deltaTime;
            if (remainingTime > 0)
                return;
            elem.LifeController.DieDueToSpawnTimeUp();
        }

        public override void Destroy()
        {
            fac.active.Remove(this);
        }
    }
}