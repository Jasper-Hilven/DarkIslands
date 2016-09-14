using System;

namespace DarkIslands
{
    public partial class IslandElementHydrationController
    {
        private IslandElement elem;
        private IslandElementHydrationControllerFactory fac;
        private float totalHydrationLost = 0;

        public override void Init(IslandElement IslandElement, IslandElementHydrationControllerFactory IslandElementHydrationControllerFactory)
        {
            IslandElement.HydrationController = this;
            this.elem = IslandElement;
            this.fac = IslandElementHydrationControllerFactory;
            base.Init(IslandElement, IslandElementHydrationControllerFactory);
        }

        public override void CanDehydrateChanged()
        {
            if(elem.CanDehydrate && !fac.Dehydrators.Contains(this))
                fac.Dehydrators.Add(this);
            if (!elem.CanDehydrate)
                fac.Dehydrators.Remove(this);
        }

        public void Update(float deltaTime)
        {
            var dehydrationLost = deltaTime*0.0166667f*elem.DehydrationRate;
            totalHydrationLost += dehydrationLost;
            if (totalHydrationLost < 1)
                return;
            totalHydrationLost -= 1f;
            if (elem.HydrationPoints < 1)
            {
                elem.HydrationPoints = 0;
                elem.LifeController.HurtDueToDeHydration(1);
                return;
            }
            elem.HydrationPoints -= 1;
        }

        public override void Destroy()
        {
            fac.Dehydrators.Remove(this);
        }

        public void Hydrate(int i)
        {
            elem.HydrationPoints = Math.Max(elem.MaxHydrationPoints, elem.HydrationPoints + i);
        }
    }
}