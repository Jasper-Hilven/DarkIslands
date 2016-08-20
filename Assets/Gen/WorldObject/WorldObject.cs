using UnityEngine;
using System.Collections.Generic;
namespace DarkIslands
{
  public partial class WorldObject
  {
  public List<IWorldObjectChanged> ChangeListeners= new List<IWorldObjectChanged>();
    public string Name
    {
      get{
        return _Name;
      }
      set
      {
        this._Name= value;
        foreach( var vWorldObjectChanged in ChangeListeners)
          vWorldObjectChanged.NameChanged();
      }
    }
      private string _Name{get;set;}
    public Vector3 Position
    {
      get{
        return _Position;
      }
      set
      {
        this._Position= value;
        foreach( var vWorldObjectChanged in ChangeListeners)
          vWorldObjectChanged.PositionChanged();
      }
    }
      private Vector3 _Position{get;set;}
    public WorldObjectHarvestController HarvestController
    {
      get{
        return _HarvestController;
      }
      set
      {
        this._HarvestController= value;
        foreach( var vWorldObjectChanged in ChangeListeners)
          vWorldObjectChanged.HarvestControllerChanged();
      }
    }
      private WorldObjectHarvestController _HarvestController{get;set;}
    public WorldObjectType Type
    {
      get{
        return _Type;
      }
      set
      {
        this._Type= value;
        foreach( var vWorldObjectChanged in ChangeListeners)
          vWorldObjectChanged.TypeChanged();
      }
    }
      private WorldObjectType _Type{get;set;}
  }
}
