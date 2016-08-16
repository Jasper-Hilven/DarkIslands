using UnityEngine;
using System.Collections.Generic;
namespace DarkIslands
{
  public partial class Island
  {
  public List<IIslandChanged> ChangeListeners= new List<IIslandChanged>();
    public Vector3 Position
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
      private Vector3 _Position{get;set;}
    public float Size
    {
      get{
        return _Size;
      }
      set
      {
        this._Size= value;
        foreach( var vIslandChanged in ChangeListeners)
          vIslandChanged.SizeChanged();
      }
    }
      private float _Size{get;set;}
    public UnitContainerController UnitContainerController
    {
      get{
        return _UnitContainerController;
      }
      set
      {
        this._UnitContainerController= value;
        foreach( var vIslandChanged in ChangeListeners)
          vIslandChanged.UnitContainerControllerChanged();
      }
    }
      private UnitContainerController _UnitContainerController{get;set;}
  }
}
