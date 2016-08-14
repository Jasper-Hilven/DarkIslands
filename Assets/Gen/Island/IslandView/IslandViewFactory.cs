using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandViewFactory: IIslandElementFactory
  {
public Dictionary<Island,IslandView> Elements= new Dictionary<Island,IslandView>();

    public void RemoveExtension(Island Island){
      var element = Elements[Island];
      element.Destroy();
      Elements.Remove(Island);
    }

    public void ExtendIsland(Island Island){
      var element =new IslandView(Island, this);
      Elements.Add(Island,element);
      Island.ChangeListeners.Add(element);
    }
  }
}
