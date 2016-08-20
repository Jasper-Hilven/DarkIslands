using System.Collections.Generic;

namespace DarkIslands
{
    public interface IWOContainerController
    {
        bool CanAddWO(WorldObject wo);
        void AddWO(WorldObject wo);
        void RemoveWO(WorldObject wo);
        List<WorldObject> GetContainingUnits { get; }
    }
}