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

            foreach (var collider in colliders)
            {
                var collisionDirection = (collider.Position - Island.Position).normalized; //Towards collider
                var collisionSpeedDiff = collider.Speed - Island.Speed;
                if (0 < Vector3.Dot(collisionSpeedDiff, collisionDirection)) //Already moving away from each other.
                    continue;
                var speedDiffTowardsCollider = -Vector3.Project(collisionSpeedDiff, collisionDirection);
                var elasticity = 0.3f;
                //More correct but minMass IS valid approximation (see comments below).
                var impulsMassCofficient = (float)1f / ((1f / collider.Mass) + (1f / Island.Mass));
                var impulsMass = (1f + elasticity) * impulsMassCofficient;
                var plasticBurnImpuls = (1 - elasticity) * impulsMassCofficient;
                var impulsTowardsCollider = speedDiffTowardsCollider * impulsMass;
                var impulsTowardsIsland = -impulsTowardsCollider;
                collider.MovementController.AddImpuls(impulsTowardsCollider);
                Island.MovementController.AddImpuls(impulsTowardsIsland);
                var lostSurface = speedDiffTowardsCollider.magnitude * plasticBurnImpuls;
                collider.SizeController.RemoveByCollision(lostSurface);
                Island.SizeController.RemoveByCollision(lostSurface);
            }
        }
        //Ask Jasper why (1/(1/A + 1/B)) <= min(a,b) <= 2*(1/(1/A + 1/B)) which means that 
        //min(a,b) is always between a perfect elastic and perfect plastic collision.

    }
}