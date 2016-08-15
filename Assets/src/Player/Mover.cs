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
                unit.RelativeGoalPosition = new Vector3(hitPoint.x,0,hitPoint.z)- unit.Container.Position;
                unit.HasRelativeGoalPosition = true;
            }
        }
    }
}