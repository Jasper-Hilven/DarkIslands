using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandView:IslandViewDefault
  {
    public IslandView(Island Island, IslandViewFactory IslandViewFactory){
    Init(Island, IslandViewFactory);
    }
  }
}
