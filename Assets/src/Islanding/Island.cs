﻿using UnityEngine;

namespace DarkIslands
{
    public partial class Island:IUnitContainer
    {
        public bool CanMoveForUnit(Unit unit)
        {
            return false;
        }

        public void SetDestination(Vector3 pos)
        {
            throw new System.NotImplementedException();
        }
    }
}