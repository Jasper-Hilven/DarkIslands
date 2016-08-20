using System;
using System.Collections.Generic;
using UnityEngine;

namespace DarkIslands
{
    public interface UnitContainerController//Interface for objects that are container their subcomponent
    {
        bool CanAddUnit(Unit unit);
        void AddUnit(Unit unit);
        void RemoveUnit(Unit unit);
        List<Unit> GetContainingUnits { get; } 
        bool CanMoveForUnit(Unit unit);
        void SetDestination(Vector3 pos);
    }
}