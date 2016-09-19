namespace DarkIslands
{
    public class FollowAndProtectCommand : IIslandElementCommand
    {
        private IslandElement follow;

        public FollowAndProtectCommand(IslandElement toFollow)
        {
            follow = toFollow;
        }
        public IIslandElementAction GetAction()
        {
            return new FollowAndProtectAction(follow);
        }
    }

    public class FollowAndProtectAction : IIslandElementAction
    {
        private FollowAction follow;
        public FollowAndProtectAction(IslandElement toFollow)
        {
            follow = new FollowAction(toFollow);
        }
        public bool Update(IslandElement islandElement, float deltaTime)
        {
            return follow.Update(islandElement, deltaTime);
            //TODO ADD ALSO PROTECT OPTION
        }
    }
}