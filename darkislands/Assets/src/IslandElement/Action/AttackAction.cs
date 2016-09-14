namespace DarkIslands
{
    public class AttackAction: IIslandElementAction
    {
        private FollowAction ifNotCloseEnough;
        private IslandElement other;

        public AttackAction(IslandElement other)
        {
            this.other = other;
            ifNotCloseEnough= new FollowAction(other);
            attackTime = 0f;
        }

        private float attackTime;
        public bool Update(IslandElement islandElement, float deltaTime)
        {
            if (!islandElement.FightingController.CouldAttackIfCloseEnough(other))
                return true;
            if (!islandElement.FightingController.IsCloseEnoughToAttack(other))
            {
                attackTime = 0f;
                ifNotCloseEnough.Update(islandElement, deltaTime);
                return false;
            }
            attackTime += deltaTime;
            if (attackTime < 1f)
                return false;
            attackTime -= 1f;
            islandElement.FightingController.Attack(other);
            return false;
        }
    }
}