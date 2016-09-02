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

        public override void SizeChanged()
        {
            UpdateSize();
        }

        private void UpdateSize()
        {
            if (UIUnit == null)
                return;
            UIUnit.transform.localScale = new Vector3(IslandElement.Size, IslandElement.Size, IslandElement.Size);
        }

        public override void IslandElementViewSettingsChanged()
        {
            if (UIUnit != null)
                Destroy();
            if (IslandElement.IslandElementViewSettings.IsTree)
            {
                UIUnit= UnitUnityViewFactory.GetTreeVisualization(IslandElement);//TODO this dependent code out to specific interface
                UpdateSize();
                return;
            }
            UIUnit = UnitUnityViewFactory.GetUnitVisualization(IslandElement);//TODO this dependent code out to specific interface
            UpdateSize();
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