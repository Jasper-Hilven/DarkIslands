using UnityEngine;

namespace DarkIslands
{
    public class MoveIslandTowardsAction : IIslandElementAction
    {
        private float totalActionTime;
        private Vector3 ImpulsDirection;

        public MoveIslandTowardsAction(Vector3 impulsDirection)
        {
            ImpulsDirection = impulsDirection;
        }

        public bool Update(IslandElement islandElement, float deltaTime)
        {
            if (!islandElement.CanUseMana)
                return true;
            if (islandElement.Island == null)
                return true;
            totalActionTime += deltaTime;
            if (totalActionTime < 1f)
                return false;
            islandElement.MagicController.RemoveMana(3);
            var islandSizeFactor = islandElement.Island.Size* islandElement.Island.Size;
            var force = 10 * 1000 * (islandElement.ElementalInfo.PsychicLevel + 1);
            var correctedForce = Mathf.Min(force, 10000*islandSizeFactor);
            var impuls = ImpulsDirection * correctedForce;
            islandElement.Island.MovementController.AddImpuls(impuls);
            return true;
        }
    }
}