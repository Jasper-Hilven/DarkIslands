namespace DarkIslands
{
    public partial class UnitActionHandler
    {
        public Unit Unit { get; set; }
        public UnitActionHandlerFactory UnitActionHandlerFactory { get; set; }

        public override void Init(Unit Unit, UnitActionHandlerFactory UnitActionHandlerFactory)
        {
            this.Unit = Unit;
            this.UnitActionHandlerFactory = UnitActionHandlerFactory;
        }

        public override void CurrentCommandChanged()
        {
            if (this.Unit.CurrentCommand == null)
                return;
            Unit.CurrentAction = this.Unit.CurrentCommand.GetAction();
            Unit.CurrentCommand = null;
        }

        public void Update()
        {

            if (this.Unit.CurrentAction == null)
                return;
            this.Unit.CurrentAction.Update(this.Unit);

        }
        public override void CurrentActionChanged()
        {
            UpdateToUpdateInFactory();
        }

        private void UpdateToUpdateInFactory()
        {
            if (this.Unit.CurrentAction == null)
                this.UnitActionHandlerFactory.toUpdate.Remove(this);
            else
                this.UnitActionHandlerFactory.toUpdate.Add(this);
        }
    }
}