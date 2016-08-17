namespace DarkIslands
{
    public partial class UnitContainerManager //SubComponent of unit
    {
        public override void Init(Unit Unit, UnitContainerManagerFactory UnitContainerManagerFactory)
        {
            this.Unit = Unit;
            base.Init(Unit, UnitContainerManagerFactory);
        }

        public Unit Unit { get; set; }

        public override void ContainerToEnterChanged()
        {
            if (Unit.ContainerToEnter == null)
                return;
            if (Unit.ContainerToEnter == Unit.Container)
            {
                Unit.ContainerToEnter = null;
                return;
            }
            if(Unit.Container != null)
                Unit.Container.UnitContainerController.RemoveUnit(Unit);
            Unit.ContainerToEnter.UnitContainerController.AddUnit(Unit);
            Unit.ContainerToEnter = null;
        }
    }
}