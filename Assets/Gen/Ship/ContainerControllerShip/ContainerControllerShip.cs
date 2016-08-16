using System.Collections.Generic;
namespace DarkIslands
{
  public partial class ContainerControllerShip:ContainerControllerShipDefault
  {
    public ContainerControllerShip(Ship Ship, ContainerControllerShipFactory ContainerControllerShipFactory){
    Init(Ship, ContainerControllerShipFactory);
    }
  }
}
