

using System;
using UnityEngine;

namespace DarkIslands
{
    public partial class IslandElementSpawnController
    {
        private float remainingTime;
        private float maxTime;
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

        public void SetSpawn(float maxTime)
        {
            isSpawn = true;
            if (!fac.active.Contains(this))
                fac.active.Add(this);
            this.maxTime = maxTime;
            this.remainingTime = maxTime;
            UpdateMaxSpawnTimeToLife(maxTime);  
        }

      

        public void DisableSpawn()
        {
            fac.active.Remove(this);
            isSpawn = false;
        }

        public bool IsSpawned { get {return isSpawn;} }
        public void Update(float deltaTime)
        {
            remainingTime -= deltaTime;
            if (remainingTime > 0)
                return;
            elem.LifeController.DieDueToSpawnTimeUp();
            UpdateSpawnToLife();
        }

        private void UpdateSpawnToLife()
        {
            var newSpawnToLife = Mathf.RoundToInt(remainingTime);
            if (newSpawnToLife != elem.SpawnTimeToLife)
                elem.SpawnTimeToLife = newSpawnToLife;
        }
        private void UpdateMaxSpawnTimeToLife(float maxTime)
        {
            this.elem.MaxSpawnTimeToLife = Mathf.RoundToInt(maxTime);
        }
        public override void Destroy()
        {
            fac.active.Remove(this);
        }
    }
}