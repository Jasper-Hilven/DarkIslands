using System;

namespace DarkIslands
{
    public partial class UnitMovementController
    {
        public Unit Unit { get; set; }
        private bool GoingSomewhere { get { return Unit.intendedGoalPosition != null; } }
        public override void Init(Unit Unit, UnitMovementControllerFactory UnitMovementControllerFactory)
        {
            this.Unit = Unit;
        }
        private 
        public override void PositionChanged()
        {
            if (!GoingSomewhere)
                return;
            
        }

        public override void intendedGoalPositionChanged()
        {
        }

        public void Update(float deltaTime)
        {
            
        }
    }
}