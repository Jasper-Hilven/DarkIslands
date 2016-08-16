using UnityEngine;

namespace DarkIslands
{
    public interface IUnitContainer
    {
        UnitContainerController UnitContainerController { get; }
        Vector3 Position { get; }
    }
}