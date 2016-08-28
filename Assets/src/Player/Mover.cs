using System;
using System.Linq;
using UnityEngine;

namespace DarkIslands.Player
{
    public class Mover
    {
        public IslandElement unit;
        private ModelToEntity mToEntity;

        public Mover(IslandElement unit,ModelToEntity mToEntity)
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
                    var island = obj as Island;
                    if (island != null)
                    {
                        unit.CurrentCommand= new GoToIslandPositionCommand(unit,hitPoint,island);   
                    }
                    var wo = obj as IslandElement;
                    if (wo != null)
                    {
                        
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