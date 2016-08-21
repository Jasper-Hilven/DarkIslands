using System.Collections.Generic;
namespace DarkIslands
{
  public partial class UnitELementView:UnitELementViewDefault
  {
    public UnitELementView(Unit Unit, UnitELementViewFactory UnitELementViewFactory){
    Init(Unit, UnitELementViewFactory);
    }
  }
}
