﻿using UnityEngine;

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

        private void UpdatePosition()
        {
            if(this.IslandElement.Position != null && this.UIUnit != null)
            this.UIUnit.transform.position = this.IslandElement.Position;

        }
        public override void IslandElementViewSettingsChanged()
        {
            if (UIUnit != null)
                Destroy();
            if (IslandElement.IslandElementViewSettings.IsTree)//TODO this dependent code out to specific interface
            {
                var seed = IslandElement.IslandElementViewSettings.Seed;
                UIUnit= UnitUnityViewFactory.GetTreeVisualization(IslandElement,seed);//TODO this dependent code out to specific interface
                UpdateSize();
                UpdatePosition();
                return;
            }
            if (IslandElement.IslandElementViewSettings.IsRock)
            {
                UIUnit = UnitUnityViewFactory.GetRockVisualization(IslandElement,IslandElement.IslandElementViewSettings.RockInfo.Big);//TODO this dependent code out to specific interface
                UpdateSize();
                UpdatePosition();
                return;
            }
            if (IslandElement.IslandElementViewSettings.IsSkeleton)
            {
                UIUnit = UnitUnityViewFactory.GetSkeletonVisualization(IslandElement);//TODO this dependent code out to specific interface
                UpdateSize();
                UpdatePosition();
                return;
            }
            if (IslandElement.IslandElementViewSettings.IsFighter)
            {
                UIUnit = UnitUnityViewFactory.GetFighterVisualization(IslandElement);//TODO this dependent code out to specific interface
                UpdateSize();
                UpdatePosition();
                return;
            }
            if (IslandElement.IslandElementViewSettings.IsGrass)
            {
                UIUnit = UnitUnityViewFactory.GetGrassVisualization(IslandElement);//TODO this dependent code out to specific interface
                UpdateSize();
                UpdatePosition();
                return;
            }
            if (IslandElement.IslandElementViewSettings.IsBrownMushroom)
            {
                UIUnit = UnitUnityViewFactory.GetBrownMushroomVisualization(IslandElement);//TODO this dependent code out to specific interface
                UpdateSize();
                UpdatePosition();
                return;
            }
            UIUnit = UnitUnityViewFactory.GetUnitVisualization(IslandElement);//TODO this dependent code out to specific interface
            UpdateSize();
            UpdatePosition();
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

        public override void RotationChanged()
        {
            if (UIUnit != null)
                UIUnit.transform.rotation = Quaternion.AngleAxis(this.IslandElement.Rotation, new Vector3(0, 1, 0));    
        }

        public override void Destroy()
        {
            this.UnitUnityViewFactory.Destroy(UIUnit);
        }
    }
}