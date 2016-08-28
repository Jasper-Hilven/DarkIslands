using System;
using System.Collections.Generic;
using UnityEngine;

namespace DarkIslands
{
    public interface IIslandElementContainerController//Interface for objects that are container their subcomponent
    {
        bool CanAddIslandElement(IslandElement unit);
        void AddUnit(IslandElement unit);
        void RemoveUnit(IslandElement unit);
        List<IslandElement> GetContainingElements { get; } 
        bool CanMoveForUnit(IslandElement unit);
    }
}