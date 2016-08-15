using UnityEngine;

namespace DarkIslands
{
    public partial class Ship:IUnitContainer
    {
        public bool CanMoveForUnit(Unit unit)
        {
            return true;
        }

        public void SetDestination(Vector3 pos)
        {
            throw new System.NotImplementedException();
        }
    }
}