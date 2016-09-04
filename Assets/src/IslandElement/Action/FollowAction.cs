namespace DarkIslands
{
    public class FollowAction:IIslandElementAction
    {
        private readonly IslandElement followed;
        private GoToRelativePositionAction gotoPos;
        public FollowAction(IslandElement actor, IslandElement followed)
        {
            this.gotoPos = new GoToRelativePositionAction(followed.RelativeToContainerPosition,followed.Island,1f);
            this.followed = followed;
        }

        public bool Update(IslandElement islandElement, float deltaTime)
        {
            //Todo stop following dead things.
            gotoPos.Island = followed.Island;
            gotoPos.RelativePosition = followed.RelativeToContainerPosition;
            gotoPos.Update(islandElement, deltaTime);
            return false;
        }
    }
}