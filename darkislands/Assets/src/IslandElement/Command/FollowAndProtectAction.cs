using System.Linq;
using UnityEngine;

namespace DarkIslands
{
    public class FollowAndProtectAction : IIslandElementAction
    {
        private FollowAction follow;
        private AttackAction attack;
        public FollowAndProtectAction(IslandElement toFollow)
        {
            follow = new FollowAction(toFollow);
        }

        private IslandElement previousToAttack;

        public bool Update(IslandElement islandElement, float deltaTime)
        {
            var toAttack =
                islandElement.NearOthersController.GetNearElements()
                    .Where(e => islandElement.TeamController.IsHostileTowards(e)).ToList();
            if (toAttack.Count == 0)
                return follow.Update(islandElement, deltaTime);
            var closest = toAttack[0];
            for (int i = 1; i < toAttack.Count; i++)
            {
                var distance = (toAttack[i].RelativeToContainerPosition - islandElement.RelativeToContainerPosition).sqrMagnitude;
                var oldDistance = (closest.RelativeToContainerPosition - islandElement.RelativeToContainerPosition).sqrMagnitude;
                if (distance < oldDistance)
                    closest = toAttack[i];
            }

           
            if (previousToAttack == closest)
            {
                attack.Update(islandElement, deltaTime);
                return false;
            }
            previousToAttack = closest;
            attack = new AttackAction(previousToAttack);
            return false;

        }
    }
}