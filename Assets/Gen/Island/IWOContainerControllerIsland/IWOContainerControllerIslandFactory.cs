using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IWOContainerControllerIslandFactory: IIslandElementFactory
  {
public Dictionary<Island,IWOContainerControllerIsland> Elements= new Dictionary<Island,IWOContainerControllerIsland>();

    public void RemoveExtension(Island Island){
      var element = Elements[Island];
      element.Destroy();
      Elements.Remove(Island);
    }

    public void ExtendIsland(Island Island){
      var element =new IWOContainerControllerIsland(Island, this);
      Elements.Add(Island,element);
      Island.ChangeListeners.Add(element);
    }
  }
}
