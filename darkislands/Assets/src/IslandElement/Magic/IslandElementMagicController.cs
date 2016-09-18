using System;

namespace DarkIslands
{
    public partial class IslandElementMagicController
    {
        private IslandElement _elem;

        public override void Init(IslandElement IslandElement,
            IslandElementMagicControllerFactory IslandElementMagicControllerFactory)
        {
            IslandElement.MagicController = this;
            base.Init(IslandElement, IslandElementMagicControllerFactory);
            this._elem = IslandElement;
            DisableMagic();
        }

        public void DisableMagic()
        {
            _elem.CanUseMana = false;
        }

        public void EnableMagic(int mgPoints, int maxMgPoints)
        {
            _elem.CanUseMana = true;
            _elem.ManaPoints = mgPoints;
            _elem.MaxManaPoints = maxMgPoints;
        }


        public void AddMana(int mgPoints)
        {
            var newPoints = Math.Min(_elem.ManaPoints + mgPoints, _elem.MaxManaPoints);
            _elem.ManaPoints = newPoints;
        }

        public bool CanRemoveMana(int mgPoints)
        {
            return _elem.ManaPoints >= mgPoints;
        }

        public void RemoveMana(int mgPoints)
        {
            _elem.ManaPoints = Math.Max(0, _elem.ManaPoints - mgPoints);
        }
    }
}