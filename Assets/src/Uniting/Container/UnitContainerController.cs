using System;
using UnityEngine;

namespace DarkIslands
{
    public interface UnitContainerController
    {
        bool CanAddUnit(Unit unit);
        void AddUnit(Unit unit);
        void RemoveUnit(Unit unit);
        bool CanMoveForUnit(Unit unit);
        void SetDestination(Vector3 pos);
    }
}