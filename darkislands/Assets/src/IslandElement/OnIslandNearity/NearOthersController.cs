using System;
using System.Collections.Generic;

namespace DarkIslands
{
    public partial class NearOthersController
    {
        public override void Init(IslandElement IslandElement, NearOthersControllerFactory NearOthersControllerFactory)
        {
            base.Init(IslandElement, NearOthersControllerFactory);
            IslandElement.NearOthersController = this;
            this.elem = IslandElement;
        }
        public bool IsActive { get { return active; } }
        private bool active;
        private IslandElement elem;
        private INearOthersNotifier notifier;

        public void SetNotifier(INearOthersNotifier notifier)
        {
            this.notifier = notifier;
        }

        public void SetActive()
        {
            if (active)
                return;
            active = true;
            if(elem.Island != null)
            elem.Island.NearityController.AddIslandElement(elem);
            
        }
        public void SetPassive()
        {
            if (!active)
                return;
            if (elem.Island != null)
                elem.Island.NearityController.RemoveIslandElement(elem);
            active = false;
        }

        public void NotifyChanges()
        {
            if (!active)
                return;
            if (this.notifier == null)
                return;
            notifier.NotifyChanges();
        }

        public List<IslandElement> GetNearElements()
        {
            if(elem.Island == null)
                return new List<IslandElement>();
            return elem.Island.NearityController.GetElementsNear(elem);
        } 


    }
}