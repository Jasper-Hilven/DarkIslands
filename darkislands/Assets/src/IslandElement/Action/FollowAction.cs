namespace DarkIslands
{
    public class FollowAction : IIslandElementAction
    {
        private readonly IslandElement followed;
        private GoToRelativePositionAction gotoPos;
        private float followDistance;

        public FollowAction(IslandElement followed, float followDistance= 1f)
        {
            this.followDistance = followDistance;
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
            var intendedPosition = distance > followDistance + islandElement.CircleElementProperties.Radius + followed.CircleElementProperties.Radius ?
                followed.RelativeToContainerPosition
                : islandElement.RelativeToContainerPosition;
            gotoPos.RelativePosition = intendedPosition;
            gotoPos.Update(islandElement, deltaTime);
            return false;
        }
    }
}