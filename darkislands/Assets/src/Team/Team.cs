
using System.Collections.Generic;

namespace DarkIslands
{
    public class Team
    {
        public List<Team> Enemies { get; set; }
        public Team()
        {
            this.Enemies= new List<Team>();
        }

        public bool IsHostileTowards(Team other)
        {
            return Enemies.Contains(other);
        }
    }
}