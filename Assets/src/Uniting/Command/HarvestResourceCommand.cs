using System;

namespace DarkIslands
{
    public class HarvestResourceCommand:IUnitCommand
    {
        private WorldObject resource;
        public Unit Unit { get; set; }

        public HarvestResourceCommand(Unit u, WorldObject resource)
        {
            this.Unit = u;
            this.resource = resource;
            throw new NotImplementedException();
        }


        public IUnitAction GetAction()
        {
            if (Unit.Container != resource.Container)
                return null;//Don't do anything if we are on different containers
            return new HarvestResourceAction(Unit, resource);
        }
    }
}