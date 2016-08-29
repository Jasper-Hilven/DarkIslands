using System;
using System.Collections.Generic;
using UnityEngine;

namespace DarkIslands
{
    public partial class IslandElementElementalViewFactory
    {

        private List<IslandElementElementalView> Active= new List<IslandElementElementalView>();
        private GameObjectManager gM= new GameObjectManager();
        public GameObject GetElementView(IElementalType eType, int size)
        {
            var gO= gM.LoadViaResources("UnitElementBall");
            gO.GetComponent<Renderer>().material.color = eType.GetColor();
            gO.transform.localScale = gO.transform.localScale * (0.7f* Mathf.Sqrt(size));
            return gO;
        }
        public void DestroyElementView(GameObject ElementView)
        {
            gM.DestroyObj(ElementView);
        }
        public void Update(float deltaTime)
        {
            foreach (var unitELementView in Active)
            {
                unitELementView.Update(deltaTime);
            }
        }

        public void Activate(IslandElementElementalView uEV)
        {
            this.Active.Add(uEV);
        }
        public void DeActivate(IslandElementElementalView uEV)
        {
            this.Active.Remove(uEV);
        }
    }
}