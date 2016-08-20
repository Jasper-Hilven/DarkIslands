using System;
using System.Collections.Generic;
using UnityEngine;

namespace DarkIslands
{
    public partial class UnitELementViewFactory
    {

        private List<UnitELementView> Active= new List<UnitELementView>();
        private GameObjectManager gM= new GameObjectManager();
        public GameObject GetElementView(IElementType eType, int size)
        {
            var gO= gM.LoadViaResources("UnitElementBall");
            gO.GetComponent<Renderer>().material.color = eType.GetColor();
            gO.transform.localScale = gO.transform.localScale * (0.2f* Mathf.Sqrt(size));
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

        public void Activate(UnitELementView uEV)
        {
            this.Active.Add(uEV);
        }
        public void DeActivate(UnitELementView uEV)
        {
            this.Active.Remove(uEV);
        }
    }
}