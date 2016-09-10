namespace DarkIslands
{
    public class IslandElementViewSettings
    {
        public int Seed { get; set; }
        public bool HasLifeStatVisualization { get; set; }
        public bool IsRock { get; set; }
        public RockInfo RockInfo{get;set;}
        public bool IsUnit { get; set; }
        public bool IsTree { get; set; }
    }
    public class RockInfo
    {
        public bool Big { get; set;}
    }
}