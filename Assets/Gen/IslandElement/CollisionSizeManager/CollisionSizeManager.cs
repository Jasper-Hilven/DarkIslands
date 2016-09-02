using System.Collections.Generic;
namespace DarkIslands
{
  public partial class CollisionSizeManager:CollisionSizeManagerDefault
  {
    public CollisionSizeManager(IslandElement IslandElement, CollisionSizeManagerFactory CollisionSizeManagerFactory){
    Init(IslandElement, CollisionSizeManagerFactory);
    }
  }
}
