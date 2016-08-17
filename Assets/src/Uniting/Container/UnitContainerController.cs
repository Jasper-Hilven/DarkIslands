using System;
using UnityEngine;

namespace DarkIslands
{
    public interface UnitContainerController//Interface for objects that are container their subcomponent
    {
        bool CanAddUnit(Unit unit);
        void AddUnit(Unit unit);
        void RemoveUnit(Unit unit);
        bool CanMoveForUnit(Unit unit);
        void SetDestination(Vector3 pos);
    }
}