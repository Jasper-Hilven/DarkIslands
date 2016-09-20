using System.Collections.Generic;
namespace DarkIslands
{
  public partial class OnIslandNearityController:OnIslandNearityControllerDefault
  {
    public OnIslandNearityController(Island Island, OnIslandNearityControllerFactory OnIslandNearityControllerFactory){
    Init(Island, OnIslandNearityControllerFactory);
    }
  }
}
