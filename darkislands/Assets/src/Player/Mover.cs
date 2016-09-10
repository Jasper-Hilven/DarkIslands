using System;
using System.Linq;
using UnityEngine;

namespace DarkIslands.Player
{
    public class Mover
    {
        public IslandElement unit;
        private ModelToEntity mToEntity;

        public Mover(IslandElement unit, ModelToEntity mToEntity)
        {
            this.unit = unit;
            this.mToEntity = mToEntity;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                MoveUnitToMouseHit();
            var direction = new Vector3();
            if (Input.GetKey(KeyCode.DownArrow))
                direction += new Vector3(0, 0, -1);
            if (Input.GetKey(KeyCode.UpArrow))
                direction += (new Vector3(0, 0, 1));
            if (Input.GetKey(KeyCode.LeftArrow))
                direction += (new Vector3(-1, 0, 0));
            if (Input.GetKey(KeyCode.RightArrow))
                direction += (new Vector3(1, 0, 0));
            if (direction.magnitude > 0.1f)
                MoveUnitIntoDirection(direction);
        }
        public void MoveUnitIntoDirection(Vector3 direction)
        {
            unit.CurrentCommand = new GoToIslandPositionCommand(unit, unit.Position + direction, unit.Island);

        }
        public void MoveUnitToMouseHit()
        {
            RaycastHit hit;
            var camera = Camera.allCameras.First();
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                var hitPoint = hit.point;

                var gameObject = hit.collider.gameObject;

                var obj = mToEntity.modelToEntity[gameObject];
                var island = obj as Island;
                if (island != null)
                {
                    unit.CurrentCommand = new GoToIslandPositionCommand(unit, hitPoint, island);
                }
                var wo = obj as IslandElement;
                if (wo != null)
                {
                    unit.CurrentCommand = new OtherIslandElementCommand(unit, wo);
                }



            }
        }
    }
}