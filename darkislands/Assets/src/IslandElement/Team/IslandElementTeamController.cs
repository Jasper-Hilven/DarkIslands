namespace DarkIslands
{
    public partial class IslandElementTeamController
    {
        public Team Team { get; set; }

        public override void Init(IslandElement IslandElement, IslandElementTeamControllerFactory IslandElementTeamControllerFactory)
        {
            IslandElement.TeamController = this;
            base.Init(IslandElement, IslandElementTeamControllerFactory);
        }

        public void SetTeam(Team team)
        {
            Team = team;
        }

        public bool IsHostileTowards(IslandElement other)
        {
            if (Team == null)
                return false;
            var otherTeam = other.TeamController.Team;
            if (otherTeam == null)
                return false;
            return (Team.IsHostileTowards(otherTeam));
        }

    }
}