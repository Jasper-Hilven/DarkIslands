using UnityEngine;

namespace DarkIslands
{
    public class GoToIslandPositionCommand:IUnitCommand
    {
        public Vector3 intendedPosition;
        private Island onWhich;
        private Unit unit;

        public GoToIslandPositionCommand(Unit unit,Vector3 absolutePosition, Island onWhich)
        {
            this.intendedPosition = absolutePosition;
            this.onWhich = onWhich;
            this.unit = unit;
        }

        public IUnitAction GetAction()
        {
            if(onWhich == unit.Container)
              return new GoToRelativePositionAction(intendedPosition- onWhich.Position);
            var shippie = unit.Container as Ship;
            if (shippie != null)
            {
                return new EmbarkShipToIslandAction(intendedPosition,onWhich);
            }
            return null;
        }
    }
}