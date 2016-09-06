using System.Collections.Generic;
namespace DarkIslands
{
  public partial class InterIslandCollision:InterIslandCollisionDefault
  {
    public InterIslandCollision(Island Island, InterIslandCollisionFactory InterIslandCollisionFactory){
    Init(Island, InterIslandCollisionFactory);
    }
  }
}
