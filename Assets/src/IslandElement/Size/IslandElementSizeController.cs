using System;

namespace DarkIslands
{
    public partial class IslandElementSizeController
    {
        private IslandElement islandElement;
        private IslandElementSizeControllerFactory fac;

        public override void Init(IslandElement IslandElement, IslandElementSizeControllerFactory IslandElementSizeControllerFactory)
        {
            this.islandElement = IslandElement;
            this.fac = IslandElementSizeControllerFactory;
        }

        public override void SizeControllerChanged()
        {
            UpdateSize();
        }

        public override void HarvestInfoChanged()
        {
            UpdateSize();
        }

        private void UpdateSize()
        {
            float prevSize = islandElement.Size;
            float size = 1f;
            try
            {
                size = islandElement.SizeController.GetIslandElementSize(islandElement);
            }
            catch (Exception e)
            {
            }
            if (Math.Abs(prevSize - size) < 0.001f)
                return;
            islandElement.Size = size;
        }
    }
}