using UnityEngine.UI;

namespace DarkIslands
{
    public partial class IslandElementContainerManager //SubComponent of unit
    {
        public override void Init(IslandElement IslandElement, IslandElementContainerManagerFactory IslandElementContainerManagerFactory)
        {
            this.IslandElement = IslandElement;
        }

        public IslandElement IslandElement { get; set; }

        public override void IslandToEnterChanged()
        {
            if (IslandElement.IslandToEnter == null)
                return;
            if (IslandElement.IslandToEnter == IslandElement.Island)
            {
                IslandElement.IslandToEnter = null;
                return;
            }
            if (IslandElement.Island != null)
                IslandElement.Island.ContainerControllerIsland.RemoveUnit(IslandElement);
            IslandElement.IslandToEnter.ContainerControllerIsland.AddElement(IslandElement);
            IslandElement.IslandToEnter = null;
        }
    }
}