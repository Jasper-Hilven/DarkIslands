using System.Collections.Generic;
namespace DarkIslands
{
  public partial class ContainerControllerIslandFactory: IIslandElementFactory
  {
public Dictionary<Island,ContainerControllerIsland> Elements= new Dictionary<Island,ContainerControllerIsland>();

    public void RemoveExtension(Island Island){
      var element = Elements[Island];
      element.Destroy();
      Elements.Remove(Island);
    }

    public void ExtendIsland(Island Island){
      var element =new ContainerControllerIsland(Island, this);
      Elements.Add(Island,element);
      Island.ChangeListeners.Add(element);
    }
  }
}
