using UnityEngine;

namespace DarkIslands
{
    public partial class IslandMovementController
    {
        private IslandMovementControllerFactory fac;
        public Island Island { get; set; }

        public override void Init(Island Island, IslandMovementControllerFactory IslandMovementControllerFactory)
        {
            Island.MovementController = this;
            this.Island = Island;
            this.fac = IslandMovementControllerFactory;
            this.Island.Speed= new Vector3();
        }

        private float decreaseNumber= 0;
        public void Update(float deltaTime)
        {
            this.Island.Position += this.Island.Speed;
            decreaseNumber += deltaTime;
            if (!(decreaseNumber > 0.3f)) return;
            decreaseNumber -= 0.3f;
            this.Island.Speed = (this.Island.Speed.sqrMagnitude < 0.001f) ? Vector3.zero : this.Island.Speed*0.96f;
        }
        

        public void AddImpuls(Vector3 force)
        {
            Island.Speed += force/(Island.Mass+1f);
        }

        public override void SpeedChanged()
        {
            if (Island.Speed == Vector3.zero)
                fac.Active.Remove(this);
            else if(!fac.Active.Contains(this))
                fac.Active.Add(this);
        }

    }
}