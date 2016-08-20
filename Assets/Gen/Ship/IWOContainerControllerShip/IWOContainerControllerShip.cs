using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IWOContainerControllerShip:IWOContainerControllerShipDefault
  {
    public IWOContainerControllerShip(Ship Ship, IWOContainerControllerShipFactory IWOContainerControllerShipFactory){
    Init(Ship, IWOContainerControllerShipFactory);
    }
  }
}
