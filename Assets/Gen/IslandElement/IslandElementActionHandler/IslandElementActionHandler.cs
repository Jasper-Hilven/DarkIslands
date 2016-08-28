using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementActionHandler:IslandElementActionHandlerDefault
  {
    public IslandElementActionHandler(IslandElement IslandElement, IslandElementActionHandlerFactory IslandElementActionHandlerFactory){
    Init(IslandElement, IslandElementActionHandlerFactory);
    }
  }
}
