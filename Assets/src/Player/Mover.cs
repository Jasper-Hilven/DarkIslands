using System;
using System.Linq;
using UnityEngine;

namespace DarkIslands.Player
{
    public class Mover
    {
        public Unit unit;
        private ModelToEntity mToEntity;

        public Mover(Unit unit,ModelToEntity mToEntity)
        {
            this.unit = unit;
            this.mToEntity = mToEntity;
        }

        public void Update()
        {
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
                var hitPoint = hit.point;

                unit.HasRelativeGoalPosition = true;
                var gameObject = hit.collider.gameObject;
                try
                {
                    var obj = mToEntity.modelToEntity[gameObject];
                    var ship = obj as Ship;
                    if (ship != null)
                    {
                        unit.CurrentCommand=new EnterShipCommand(ship);
                        return;
                    }
                    var island = obj as Island;
                    if (island != null)
                    {
                        var relPos= new Vector3(hitPoint.x, hitPoint.y, hitPoint.z) - unit.Container.Position;
                        unit.CurrentCommand= new GoToRelativePositionCommand(relPos);   
                    }

                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                    return;
                }
                
            }
        }
    }
}