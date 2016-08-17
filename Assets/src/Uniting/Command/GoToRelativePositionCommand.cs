using UnityEngine;

namespace DarkIslands
{
    public class GoToRelativePositionCommand:IUnitCommand
    {
        public Vector3 relativePosition;

        public GoToRelativePositionCommand(Vector3 relativePosition)
        {
            this.relativePosition = relativePosition;
        }

        public IUnitAction GetAction()
        {
            return new GoToRelativePositionAction(relativePosition);
        }
    }
}