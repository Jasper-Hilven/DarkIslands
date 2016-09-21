using System.Collections.Generic;

namespace DarkIslands
{
    public class SpawnFighter : ISpell
    {
        private readonly bool isArcher;

        public SpawnFighter(bool isArcher = false)
        {
            this.isArcher = isArcher;
        }
        public bool CanSee(IslandElement elem)
        {
            return true;
        }

        public bool CanDo(IslandElement elem)
        {
            return elem.CanUseMana && elem.ManaPoints >= 10f;
        }

        public IIslandElementAction Do(IslandElement elem)
        {
            return new SpawnFigherAction(isArcher);

        }
    }
}