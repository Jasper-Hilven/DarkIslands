using System.Collections.Generic;
namespace DarkIslands
{
  public partial class UnitManaView:UnitManaViewDefault
  {
    public UnitManaView(Unit Unit, UnitManaViewFactory UnitManaViewFactory){
    Init(Unit, UnitManaViewFactory);
    }
  }
}
