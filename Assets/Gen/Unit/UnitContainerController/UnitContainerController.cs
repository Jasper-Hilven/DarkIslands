using System.Collections.Generic;
namespace DarkIslands
{
  public partial class UnitContainerController:UnitContainerControllerDefault
  {
    public UnitContainerController(Unit Unit, UnitContainerControllerFactory UnitContainerControllerFactory){
    Init(Unit, UnitContainerControllerFactory);
    }
  }
}
