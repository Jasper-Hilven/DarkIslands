using UnityEngine;

namespace DarkIslands.Player
{
    public class Mover
    {
        private Unit unit;

        public Mover(Unit unit)
        {
            this.unit = unit;
        }

        public void Update()
        {
            var xDif = (Input.GetKeyDown(KeyCode.RightArrow))? 3 : 
            (Input.GetKeyDown(KeyCode.LeftArrow) ? -3 : 0);
            var yDif = (Input.GetKeyDown(KeyCode.UpArrow)) ? 3 :
            (Input.GetKeyDown(KeyCode.DownArrow) ? -3 : 0);
            unit.intendedGoalPosition = unit.intendedGoalPosition + new Vector3(xDif, yDif, 0);
        }
    }
}