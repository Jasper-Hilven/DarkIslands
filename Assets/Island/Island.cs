using UnityEngine;
using System.Collections.Generic;
namespace DarkIslands
{
  public partial class Island
  {
  public List<IIslandChanged> ChangeListeners= new List<IIslandChanged>();
    public Vector2 Position
    {
      get{
        return _Position;
      }
      set
      {
        this._Position= value;
        foreach( var vIslandChanged in ChangeListeners)
          vIslandChanged.PositionChanged();
      }
    }
      private Vector2 _Position{get;set;}
  }
}
