using System;
using UnityEngine;

namespace DarkIslands
{
    public partial class IslandElementUnityViewFactory
    {
        public UnityViewFactory UnityViewFactory { get;set;}
       
        public void AddToModelEntity(GameObject go, IslandElement elem)
        {
            this.ModelToEntity.modelToEntity.Add(go, elem);
        }
        public void Destroy(GameObject gObject)
        {
            this.ModelToEntity.modelToEntity.Remove(gObject);
            UnityViewFactory.Destroy(gObject);
        }
    }
}