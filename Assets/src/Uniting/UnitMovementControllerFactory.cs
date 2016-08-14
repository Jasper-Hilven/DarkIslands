namespace DarkIslands
{
    public partial class UnitMovementControllerFactory
    {
        public void Update(float deltaTime)
        {
            foreach (var unitMovementController in Elements)
            {
                unitMovementController.Value.Update(deltaTime);
            }
        }
    }
}