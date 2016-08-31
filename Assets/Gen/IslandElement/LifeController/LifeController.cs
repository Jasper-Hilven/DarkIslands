using System.Collections.Generic;
namespace DarkIslands
{
  public partial class LifeController:LifeControllerDefault
  {
    public LifeController(IslandElement IslandElement, LifeControllerFactory LifeControllerFactory){
    Init(IslandElement, LifeControllerFactory);
    }
  }
}
