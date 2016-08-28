using UnityEngine;

namespace DarkIslands
{
    public partial class IslandElementUnityView
    {
        public IslandElement IslandElement{ get; set; }
        public GameObject UIUnit { get; set; }
        public IslandElementUnityViewFactory UnitUnityViewFactory { get; set; }
        public override void Init(IslandElement islandElement, IslandElementUnityViewFactory IslandElementUnityViewFactory)
        {
            this.IslandElement = islandElement;
            this.UnitUnityViewFactory = IslandElementUnityViewFactory;
        }

        public override void IslandElementViewSettingsChanged()
        {
            if (UIUnit != null)
                Destroy();
            if (IslandElement.IslandElementViewSettings.IsTree)
            {
                this.UIUnit= UnitUnityViewFactory.GetTreeVisualization(IslandElement);
                return;
            }
            this.UIUnit = UnitUnityViewFactory.GetUnitVisualization();
        }

        public override void IsElementalColoredChanged()
        {
            DrawToElementalColor();
        }

        public override void ElementalTypeChanged()
        {
            DrawToElementalColor();
        }

        private void DrawToElementalColor()
        {
            if (!IslandElement.IsElementalColored)
                return;
                var eType = IslandElement.ElementalType;
            if (UIUnit != null)
                this.UIUnit.GetComponent<Renderer>().material.color = eType.GetColor();
        }
        public override void PositionChanged()
        {
            if (UIUnit != null)
                this.UIUnit.transform.position = this.IslandElement.Position;
        }

        public override void Destroy()
        {
            this.UnitUnityViewFactory.Destroy(UIUnit);
        }
    }
}