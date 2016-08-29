using System.Collections.Generic;
using UnityEngine;

namespace DarkIslands
{
  public partial class OnIslandCollision:OnIslandCollisionDefault
  {
    public OnIslandCollision(Island Island, OnIslandCollisionFactory OnIslandCollisionFactory){
    Init(Island, OnIslandCollisionFactory);
    }

  }
}
