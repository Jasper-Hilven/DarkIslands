using UnityEngine;

namespace DarkIslands
{
    public partial class InterIslandCollision
    {
        private InterIslandCollisionFactory fac;
        public Island Island { get; set; }

        public override void Init(Island Island, InterIslandCollisionFactory InterIslandCollisionFactory)
        {
            this.Island = Island;
            fac = InterIslandCollisionFactory;
            fac.AddIsland(Island);
        }

        public override void Destroy()
        {
            this.fac.RemoveIsland(Island);
        }

        public override void PositionChanged()
        {
            var detectCollision = this.fac.MoveDetectCollision(Island, Island.Position);
            if (!detectCollision)
                return;
            var colliders = this.fac.GetColliders(Island);
            
            var currentSpeed = this.Island.Speed;
            foreach (var collider in colliders)
            {
                var collisionDirection = (collider.Position - Island.Position).normalized; //Towards collider
                var collisionSpeedDiff = collider.Speed - Island.Speed;
                var SpeedDiffTowardsCollider = -Vector3.Project(collisionSpeedDiff, collisionDirection);
                var minMass = Mathf.Min(collider.Mass, Island.Mass);
                var impulsTowardsCollider = SpeedDiffTowardsCollider* 1f * minMass;
                var impulsTowardsIsland = -SpeedDiffTowardsCollider * 1f * minMass;
                collider.MovementController.AddImpuls(impulsTowardsCollider);
                Island.MovementController.AddImpuls(impulsTowardsIsland);
                collider.SizeController.RemoveByCollision(SpeedDiffTowardsCollider.magnitude*0.5f*minMass);
                Island.SizeController.RemoveByCollision(SpeedDiffTowardsCollider.magnitude * 0.5f * minMass);

            }
        }

    }
}