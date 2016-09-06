using System.Collections.Generic;
namespace DarkIslands
{
  public partial class OnIslandCollision:OnIslandCollisionDefault
  {
    public OnIslandCollision(Island Island, OnIslandCollisionFactory OnIslandCollisionFactory){
    Init(Island, OnIslandCollisionFactory);
    }
  }
}
