using System.Linq;
using UnityEngine;

namespace DarkIslands.Player
{
    public class Mover
    {
        public Unit unit;

        public Mover(Unit unit)
        {
            this.unit = unit;
        }

        public void Update()
        {
            var xDif = (Input.GetKeyDown(KeyCode.RightArrow))? 3 : 
            (Input.GetKeyDown(KeyCode.LeftArrow) ? -3 : 0);
            var zDif = (Input.GetKeyDown(KeyCode.UpArrow)) ? 3 :
            (Input.GetKeyDown(KeyCode.DownArrow) ? -3 : 0);
            unit.intendedGoalPosition = unit.intendedGoalPosition + new Vector3(xDif, 0, zDif);
            if (Input.GetKeyDown(KeyCode.Mouse0))
                MoveUnitToMouseHit();




        }

        public void MoveUnitToMouseHit()
        {
            RaycastHit hit;
            var camera = Camera.allCameras.First();
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                var hitPoint= hit.point;
                unit.intendedGoalPosition = new Vector3(hitPoint.x,0,hitPoint.z);
                unit.intendedToMove = true;
            }
        }
    }
}