using System.Collections.Generic;
namespace DarkIslands
{
  public partial class NearOthersController:NearOthersControllerDefault
  {
    public NearOthersController(IslandElement IslandElement, NearOthersControllerFactory NearOthersControllerFactory){
    Init(IslandElement, NearOthersControllerFactory);
    }
  }
}
