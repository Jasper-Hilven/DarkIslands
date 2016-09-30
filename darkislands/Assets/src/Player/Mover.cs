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
            direction *= 0.1f;
            if (direction.sqrMagnitude > 0.00001f)
                MoveUnitIntoDirection(direction);
            if (Input.GetKeyDown(KeyCode.S))
                unit.ActionHandler.SetNextCommand(new SpellCommand(new HarvestIslandMana()));
            if (Input.GetKeyDown(KeyCode.D))
                unit.ActionHandler.SetNextCommand(new SpellCommand(new HarvestIslandMana(false)));
            if (Input.GetKeyDown(KeyCode.F))
                unit.ActionHandler.SetNextCommand(new SpellCommand(new SpawnFighter()));
            if (Input.GetKeyDown(KeyCode.G))
                unit.ActionHandler.SetNextCommand(new SpellCommand(new SpawnFighter(true)));
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
            Ray ray;
            RaycastHit hit;
            var camera = Camera.allCameras.First();
            ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                var hitPoint = hit.point;

                var gameObject = hit.collider.gameObject;
                if (!mToEntity.modelToEntity.ContainsKey(gameObject))
                    return;
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