﻿using UnityEngine;

namespace DarkIslands
{
    public partial class IslandElementLightController
    {
        public IslandElement IslandElement { get; set; }
        public IslandElementLightControllerFactory IslandElementLightControllerFactory { get; set; }
        public GameObject unitLight;

        public override void Init(IslandElement IslandElement, IslandElementLightControllerFactory IslandElementLightControllerFactory)
        {
            this.IslandElement = IslandElement;
            this.IslandElementLightControllerFactory = IslandElementLightControllerFactory;
        }


        public override void hasLightChanged()
        {

            if (IslandElement.hasLight == (unitLight != null))
                return;
            if (IslandElement.hasLight)
            {
                this.unitLight = this.IslandElementLightControllerFactory.GetLight();
                PositionChanged(); // Force update to enable light, as it requires a position;
            }
            else
            {
                this.IslandElementLightControllerFactory.DestroyLight(unitLight);
            }
        }

        public override void PositionChanged()
        {
            if (unitLight == null)
                return;
            this.unitLight.transform.localPosition = this.IslandElement.Position + new Vector3(0, 5, 0);
            var light= this.unitLight.GetComponent<Light>();
            var cosFac = Mathf.Abs(Mathf.Cos(IslandElement.Position.x/5));
            var sinFac = Mathf.Abs(Mathf.Sin(IslandElement.Position.z / 5));
            light.color = new Color(2 * cosFac, 2 - sinFac- cosFac, 2*sinFac);
        }

        public override void Destroy()
        {
            this.IslandElementLightControllerFactory.DestroyLight(unitLight);
        }
    }
}