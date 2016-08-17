namespace DarkIslands
{
    public partial class ShipMovementController
    {
        public Ship Ship { get; set; }
        public ShipMovementControllerFactory ShipMovementControllerFactory { get; set; }
        public override void Init(Ship Ship, ShipMovementControllerFactory ShipMovementControllerFactory)
        {
            this.Ship = Ship;
            this.ShipMovementControllerFactory = ShipMovementControllerFactory;
        }


        public override void HasGoalPositionChanged()
        {
            if(this.Ship.HasGoalPosition)
              this.ShipMovementControllerFactory.UpdateShips.Add(this);
            else
                this.ShipMovementControllerFactory.UpdateShips.Remove(this);
        }

        public override void PositionChanged()
        {
            Ship.HasGoalPosition = Ship.HasGoalPosition || Ship.GoalPosition != Ship.Position;
        }

        public void Update(float deltaTime)
        {
            if (this.Ship.HasGoalPosition)
            {
                var goalDistance = Ship.GoalPosition - Ship.Position;
                var maxMovement = this.Ship.MaxSpeed*deltaTime;
                if (goalDistance.sqrMagnitude < maxMovement*maxMovement)
                {
                    this.Ship.Position = this.Ship.GoalPosition;
                    return;
                }
                goalDistance.Normalize();
                var movement = maxMovement*goalDistance.normalized;
                this.Ship.Position = this.Ship.Position + movement;
            }
        }

        public override void Destroy()
        {
            this.ShipMovementControllerFactory.UpdateShips.Remove(this);
        }
    }
}