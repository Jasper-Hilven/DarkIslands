using System.Collections.Generic;

namespace DarkIslands
{
    public class SpawnTower : ISpell
    {
        public bool CanSee(IslandElement elem)
        {
            return true;
        }

        public bool CanDo(IslandElement elem)
        {
            return elem.CanUseMana && elem.ManaPoints > 10f;
        }

        public IIslandElementAction Do(IslandElement elem)
        {
            return new SpawnTowerAction();

        }
    }
}