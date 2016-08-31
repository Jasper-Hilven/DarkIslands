namespace DarkIslands
{
    public class FollowAction:IIslandElementAction
    {
        private IslandElement actor;
        private readonly IslandElement followed;

        public FollowAction(IslandElement actor, IslandElement followed)
        {
            this.actor = actor;
            this.followed = followed;

        }

        public void Update(IslandElement islandElement, float deltaTime)
        {
            actor.RelativeGoalPosition = followed.RelativeToContainerPosition;
            if (!actor.HasRelativeGoalPosition)
                actor.HasRelativeGoalPosition = true;
        }
    }
}