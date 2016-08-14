using UnityEngine;

namespace DarkIslands
{
    public partial class UnitUnityView
    {
        public Unit Unit{ get; set; }
        public GameObject UIUnit { get; set; }
        public UnitUnityViewFactory UnitUnityViewFactory { get; set; }
        public override void Init(Unit Unit, UnitUnityViewFactory UnitUnityViewFactory)
        {
            this.Unit= Unit;
            this.UIUnit = UnitUnityViewFactory.GetUnitVisualization();
            this.UnitUnityViewFactory = UnitUnityViewFactory;
        }

        public override void ElementTypeChanged()
        {
            var eType = Unit.ElementType;
            this.UIUnit.GetComponent<SpriteRenderer>().color = eType.GetColor();
        }

        public override void Destroy()
        {
            this.UnitUnityViewFactory.Destroy(UIUnit);
        }
    }
}