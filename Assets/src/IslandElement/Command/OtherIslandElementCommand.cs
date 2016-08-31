using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DarkIslands;

namespace DarkIslands
{
    public class OtherIslandElementCommand:IIslandElementCommand
    {
        private IslandElement Actor;
        private IslandElement Other;

        public OtherIslandElementCommand(IslandElement actor, IslandElement other)
        {
            this.Actor = actor;
            this.Other = other;
        }

        public IIslandElementAction GetAction()
        {
            if (Actor.Island != Other.Island)
                return null;
            if (Other.HarvestInfo.CanBeChopped && Actor.HarvestInfo.CanChop)
                return new HarvestResourceAction(Actor, Other,HarvestResourceAction.HarvestAction.Chop);
            if (Other.HarvestInfo.CanBeMined && Actor.HarvestInfo.CanMine)
                return new HarvestResourceAction(Actor, Other, HarvestResourceAction.HarvestAction.Mine);
            if (Other.HarvestInfo.CanBeHarvestAttacked && Actor.HarvestInfo.CanHarvestAttack)
                return new HarvestResourceAction(Actor, Other, HarvestResourceAction.HarvestAction.Smash);
            return new FollowAction(Actor, Other);
        }
    }
}
