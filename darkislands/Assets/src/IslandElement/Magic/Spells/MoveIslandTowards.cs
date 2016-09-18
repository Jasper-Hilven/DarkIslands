using UnityEngine;

namespace DarkIslands
{
    public class MoveIslandTowards:ISpell
    {
        private Vector3 direction;

        public MoveIslandTowards(Vector3 direction)
        {
            this.direction = direction;
        }
        public bool CanSee(IslandElement elem)
        {
            return true;
        }

        public bool CanDo(IslandElement elem)
        {
            return elem.CanUseMana && elem.ManaPoints > 1;
        }

        public IIslandElementAction Do(IslandElement elem)
        {
            return new MoveIslandTowardsAction(direction);
        }
    }
}