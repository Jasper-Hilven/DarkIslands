using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DarkIslands 
{
    public class InventoryViewManager : MonoBehaviour
    {
        public IslandElement activeElement;
        public void AttachInventoryToIslandElement(IslandElement element)
        {
            if(activeElement != null)
            {
                RemoveInventoryViewOffActiveIslandElement();
            }
        }
        public void RemoveInventoryViewOffActiveIslandElement()
        {
            this.activeElement = null;
        }
    }
}
