using UnityEngine;

namespace DarkIslands
{
    public interface IUnitContainer
    {
        bool CanMoveForUnit(Unit unit);
        void SetDestination(Vector3 pos);
        Vector3 Position { get; }
    }
}