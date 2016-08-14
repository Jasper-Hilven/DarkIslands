using System.Collections.Generic;
namespace DarkIslands
{
  public partial class ShipSelectedView:ShipSelectedViewDefault
  {
    public ShipSelectedView(Ship Ship, ShipSelectedViewFactory ShipSelectedViewFactory){
    Init(Ship, ShipSelectedViewFactory);
    }
  }
}
