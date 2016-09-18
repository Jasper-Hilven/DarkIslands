using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DarkIslands
{
    public class Mover
    {
        public IslandElement unit;
        private ModelToEntity mToEntity;
        private EventSystem evSys;
        public Mover(IslandElement unit, ModelToEntity mToEntity,EventSystem eventSystem)
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
            direction *= 0.1f;
            if (direction.sqrMagnitude > 0.00001f)
                MoveUnitIntoDirection(direction);
            if (Input.GetKeyDown(KeyCode.S))
                unit.ActionHandler.SetNextCommand(new SpellCommand(new HarvestIslandMana()));
            if (Input.GetKeyDown(KeyCode.D))
                unit.ActionHandler.SetNextCommand(new SpellCommand(new SpawnTower()));
            if (Input.GetKeyDown(KeyCode.I))
                unit.ActionHandler.SetNextCommand(new SpellCommand(new MoveIslandTowards(new Vector3(1, 0, 0))));
            if (Input.GetKeyDown(KeyCode.K))
                unit.ActionHandler.SetNextCommand(new SpellCommand(new MoveIslandTowards(new Vector3(-1, 0, 0))));
            if (Input.GetKeyDown(KeyCode.J))
                unit.ActionHandler.SetNextCommand(new SpellCommand(new MoveIslandTowards(new Vector3(0, 0, 1))));
            if (Input.GetKeyDown(KeyCode.L))
                unit.ActionHandler.SetNextCommand(new SpellCommand(new MoveIslandTowards(new Vector3(0, 0, -1))));
        }


        public void MoveUnitIntoDirection(Vector3 direction)
        {
            unit.CurrentCommand = new GoToIslandPositionCommand(unit, unit.Position + direction, unit.Island);

        }

        public void MoveUnitToMouseHit()
        {
            if (HitCanvas())
                return;
            Ray ray;
            RaycastHit hit;
            var camera = Camera.allCameras.First();
            ray = camera.ScreenPointToRay(Input.mousePosition);
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

        private bool HitCanvas()
        {
            int count = 0;
          
            PointerEventData cursor = new PointerEventData(EventSystem.current);                            // This section prepares a list for all objects hit with the raycast
            cursor.position = Input.mousePosition;
            List<RaycastResult> objectsHit = new List<RaycastResult>();
            EventSystem.current.RaycastAll(cursor, objectsHit);
            count = objectsHit.Count;
            return count > 0;
        }
    }
}