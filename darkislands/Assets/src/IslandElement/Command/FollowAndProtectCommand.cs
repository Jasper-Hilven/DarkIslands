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
}