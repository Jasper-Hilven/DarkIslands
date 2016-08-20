using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IWOContainerControllerUnit:IWOContainerControllerUnitDefault
  {
    public IWOContainerControllerUnit(Unit Unit, IWOContainerControllerUnitFactory IWOContainerControllerUnitFactory){
    Init(Unit, IWOContainerControllerUnitFactory);
    }
  }
}
