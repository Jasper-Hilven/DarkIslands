using UnityEngine;

namespace DarkIslands
{
    public partial class UnitLightController
    {
        public Unit Unit { get; set; }
        public UnitLightControllerFactory UnitLightControllerFactory { get; set; }
        public GameObject unitLight;
        public override void Init(Unit Unit, UnitLightControllerFactory UnitLightControllerFactory)
        {
            this.Unit = Unit;
            this.UnitLightControllerFactory = UnitLightControllerFactory;
            base.Init(Unit, UnitLightControllerFactory);
        }



        public override void hasLightChanged()
        {

            if (Unit.hasLight == (unitLight != null))
                return;
            if (Unit.hasLight)
            {
                this.unitLight = this.UnitLightControllerFactory.GetLight();
                PositionChanged(); // Force update to enable light, as it requires a position;
            }
            else
            {
                this.UnitLightControllerFactory.DestroyLight(unitLight);
            }
        }

        public override void PositionChanged()
        {
            if (unitLight == null)
                return;
            this.unitLight.transform.localPosition = this.Unit.Position + new Vector3(0, 4, 0);
        }

        public override void Destroy()
        {
            this.UnitLightControllerFactory.DestroyLight(unitLight);
            base.Destroy();
        }
    }
}