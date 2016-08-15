using UnityEngine;

namespace DarkIslands
{
    public partial class ShipUnityView
    {
        public Ship Ship { get; set; }
        public GameObject UIShip { get; set; }
        public ShipUnityViewFactory ShipUnityViewFactory { get; set; }
        public override void Init(Ship Ship, ShipUnityViewFactory ShipUnityViewFactory)
        {
            this.Ship = Ship;
            this.UIShip= ShipUnityViewFactory.GetShipVisualization();
            this.UIShip.GetComponent<Renderer>().material.color=Color.Lerp(Color.red,Color.cyan,0.2f);
            this.ShipUnityViewFactory = ShipUnityViewFactory;
        }

        public override void PositionChanged()
        {
            this.UIShip.transform.position= Ship.Position;
        }

        public override void Destroy()
        {
            this.ShipUnityViewFactory.Destroy(UIShip);
        }
    }
}