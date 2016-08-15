using System.Collections.Generic;
namespace DarkIslands
{
  public partial class UnitActionHandler:UnitActionHandlerDefault
  {
    public UnitActionHandler(Unit Unit, UnitActionHandlerFactory UnitActionHandlerFactory){
    Init(Unit, UnitActionHandlerFactory);
    }
  }
}
