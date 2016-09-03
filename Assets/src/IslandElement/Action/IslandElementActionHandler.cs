﻿namespace DarkIslands
{
    public partial class IslandElementActionHandler
    {
        public IslandElement Unit { get; set; }
        public IslandElementActionHandlerFactory UnitActionHandlerFactory { get; set; }

        public override void Init(IslandElement IslandElement, IslandElementActionHandlerFactory UnitActionHandlerFactory)
        {
            this.Unit = IslandElement;
            this.UnitActionHandlerFactory = UnitActionHandlerFactory;
        }

        public override void CurrentCommandChanged()
        {
            if (this.Unit.CurrentCommand == null)
                return;
            Unit.CurrentAction = this.Unit.CurrentCommand.GetAction();
            Unit.CurrentCommand = null;
        }

        public override void CurrentLifeActionChanged()
        {
            UpdateToUpdateInFactory();
        }

        public void Update(float deltaTime)
        {
            if (this.Unit.CurrentLifeAction != null)
            {
                if (this.Unit.CurrentLifeAction.Update(this.Unit, deltaTime))
                    this.Unit.CurrentLifeAction = null;
                return;
            }
            if (this.Unit.CurrentAction == null)
                return;
            if (this.Unit.CurrentAction.Update(this.Unit, deltaTime))
                this.Unit.CurrentAction = null;

        }
        public override void CurrentActionChanged()
        {
            UpdateToUpdateInFactory();
        }

        private void UpdateToUpdateInFactory()
        {
            if (this.Unit.CurrentAction == null && this.Unit.CurrentLifeAction == null)
                this.UnitActionHandlerFactory.toUpdate.Remove(this);
            else if(!this.UnitActionHandlerFactory.toUpdate.Contains(this))
                this.UnitActionHandlerFactory.toUpdate.Add(this);
        }
    }
}