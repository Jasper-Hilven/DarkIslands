using UnityEngine.UI;

namespace DarkIslands
{
    public partial class IslandElementContainerManager //SubComponent of unit
    {
        public override void Init(IslandElement IslandElement, IslandElementContainerManagerFactory IslandElementContainerManagerFactory)
        {
            IslandElement.IslandManager = this;
            this.IslandElement = IslandElement;
        }

        public IslandElement IslandElement { get; set; }

        public void EnterIsland(Island island)
        {
            if (island == IslandElement.Island)
            {
                return;
            }
            if (IslandElement.Island != null)
                IslandElement.Island.ContainerControllerIsland.RemoveElement(IslandElement);
            if(island != null)
            island.ContainerControllerIsland.AddElement(IslandElement);
        }

        public override void RelativeToContainerPositionChanged()
        {
            if (IslandElement.Island == null)
                return;
            IslandElement.Island.ContainerControllerIsland.MoveElement(IslandElement,IslandElement.RelativeToContainerPosition);
        }

        public override void Destroy()
        {
            if (IslandElement.Island != null)
                IslandElement.Island.ContainerControllerIsland.RemoveElement(IslandElement);
            IslandElement.Island = null;
        }
    }
}