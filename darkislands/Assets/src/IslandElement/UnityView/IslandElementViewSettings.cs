namespace DarkIslands
{
    public class IslandElementViewSettings
    {
        public int Seed { get; set; }
        public bool HasLifeStatVisualization { get; set; }
        public bool IsRock { get; set; }
        public RockInfo RockInfo{get;set;}
        public bool IsWizzard { get; set; }
        public bool IsTree { get; set; }
        public bool IsSkeleton { get; set; }
        public bool IsFighter { get; set; }
    }
    public class RockInfo
    {
        public bool Big { get; set;}
    }
}