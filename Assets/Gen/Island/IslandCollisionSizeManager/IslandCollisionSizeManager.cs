using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandCollisionSizeManager:IslandCollisionSizeManagerDefault
  {
    public IslandCollisionSizeManager(Island Island, IslandCollisionSizeManagerFactory IslandCollisionSizeManagerFactory){
    Init(Island, IslandCollisionSizeManagerFactory);
    }
  }
}
