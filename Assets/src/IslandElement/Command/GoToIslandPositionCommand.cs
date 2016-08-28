using UnityEngine;

namespace DarkIslands
{
    public class GoToIslandPositionCommand:IIslandElementCommand
    {
        public Vector3 intendedPosition;
        private Island onWhich;
        private IslandElement IslandElement;

        public GoToIslandPositionCommand(IslandElement IslandElement, Vector3 absolutePosition, Island onWhich)
        {
            this.intendedPosition = absolutePosition;
            this.onWhich = onWhich;
            this.IslandElement = IslandElement;
        }

        public IIslandElementAction GetAction()
        {
            if(onWhich == IslandElement.Island)
              return new GoToRelativePositionAction(intendedPosition- onWhich.Position);
           
            return null;
        }
    }
}