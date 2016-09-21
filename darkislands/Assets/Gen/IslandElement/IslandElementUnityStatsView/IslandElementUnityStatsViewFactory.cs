using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementUnityStatsViewFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,IslandElementUnityStatsView> Elements= new Dictionary<IslandElement,IslandElementUnityStatsView>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new IslandElementUnityStatsView(IslandElement, this);
      Elements.Add(IslandElement,element);
      IslandElement.ChangePositionListeners.Add(element);
      IslandElement.ChangeLifePointsListeners.Add(element);
      IslandElement.ChangeMaxLifePointsListeners.Add(element);
      IslandElement.ChangeHydrationPointsListeners.Add(element);
      IslandElement.ChangeMaxHydrationPointsListeners.Add(element);
      IslandElement.ChangeManaPointsListeners.Add(element);
      IslandElement.ChangeMaxManaPointsListeners.Add(element);
      IslandElement.ChangeIslandElementViewSettingsListeners.Add(element);
      IslandElement.ChangeSpawnTimeToLifeListeners.Add(element);
      IslandElement.ChangeMaxSpawnTimeToLifeListeners.Add(element);
    }
  }
}
