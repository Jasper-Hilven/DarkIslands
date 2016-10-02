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

        public void EnableDehydrating(int dehydrationRate, int hydrationPoints, int maxHydrationPoints)
        {
            this.elem.DehydrationRate = dehydrationRate;
            this.elem.CanDehydrate = true;
            this.elem.HydrationPoints = hydrationPoints;
            this.elem.MaxHydrationPoints = maxHydrationPoints;
        }

        public void disableDehydration()
        {
            this.elem.CanDehydrate = false;
        }

        public override void CanDehydrateChanged()
        {
            if (elem.CanDehydrate && !fac.Dehydrators.Contains(this))
                fac.Dehydrators.Add(this);
            if (!elem.CanDehydrate)
                fac.Dehydrators.Remove(this);
        }

        public void Update(float deltaTime)
        {
            var dehydrationLost = deltaTime * 0.0166667f * elem.DehydrationRate;
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
            elem.HydrationPoints = Math.Min(elem.MaxHydrationPoints, elem.HydrationPoints + i);
        }
        public void DeHydrate(int i)
        {
            var newHydration = Math.Max(0, elem.HydrationPoints - i);
            var diff = elem.HydrationPoints - newHydration;
            elem.HydrationPoints = newHydration;
            var damage = i - diff;
            if (damage > 0)
                elem.LifeController.HurtDueToDeHydration(damage);
        }
    }
}