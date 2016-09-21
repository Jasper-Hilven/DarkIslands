namespace DarkIslands
{
    public class FollowAction : IIslandElementAction
    {
        private readonly IslandElement followed;
        private GoToRelativePositionAction gotoPos;
        public FollowAction(IslandElement followed)
        {
            this.gotoPos = new GoToRelativePositionAction(followed.RelativeToContainerPosition, followed.Island, 1f);
            this.followed = followed;
        }

        public bool Update(IslandElement islandElement, float deltaTime)
        {
            if (followed == null || !followed.IsAlive)
                return true;
            gotoPos.Island = followed.Island;
            var distance =
                (islandElement.RelativeToContainerPosition - followed.RelativeToContainerPosition).magnitude;
            var intendedPosition = distance > 1f + islandElement.CircleElementProperties.Radius + followed.CircleElementProperties.Radius ?
                followed.RelativeToContainerPosition
                : islandElement.RelativeToContainerPosition;
            gotoPos.RelativePosition = intendedPosition;
            gotoPos.Update(islandElement, deltaTime);
            return false;
        }
    }
}