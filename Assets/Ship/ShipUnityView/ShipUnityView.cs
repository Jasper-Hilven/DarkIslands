using System.Collections.Generic;
namespace DarkIslands
{
  public partial class ShipUnityView:ShipUnityViewDefault
  {
    public ShipUnityView(Ship Ship, ShipUnityViewFactory ShipUnityViewFactory){
    Init(Ship, ShipUnityViewFactory);
    }
  }
}
