using System;
using UnityEngine;

namespace DarkIslands
{
    public class UnitBuilder
    {
        private IslandElementFactory fac;

        public UnitBuilder(IslandElementFactory fac)
        {
            this.fac = fac;
        }
        public IslandElement GetWizard(IElementalType eType, Island visIsland, Vector3 pos, System.Random r, Team team)
        {
            var wizard = GetDefaultUnit(visIsland, pos, r, team);
            wizard.IslandElementViewSettings = new IslandElementViewSettings() { IsWizzard = true, HasLifeStatVisualization = true };
            wizard.hasLight = true;
            var elementalInfo = eType.IsWater ? new ElementalInfo(13, 13, 16, 11, 13) : new ElementalInfo(eType, 2);
            wizard.ElementalController.SetInfo(elementalInfo,eType,true);
            wizard.HarvestController.SetHarvestSettings(new HumanHarvestControllerTactic(wizard), new HarvestInfo(false, false, null, null, true, true, true));
            wizard.MaxSpeed = 2f;
            wizard.LifeController.SetLifePoints(50,50);
            wizard.MagicController.EnableMagic(70,100);
            wizard.HydrationController.EnableDehydrating(6,80,80);
            wizard.FightingController.EnableAttack(3, 6);
            wizard.InventoryController.HasInventory = true;
            return wizard;
        }

        public IslandElement GetSkeleton(Island visIsland, Vector3 pos, System.Random r, Team team)
        {
            var skeleton = GetDefaultUnit(visIsland, pos, r, team);
            skeleton.hasLight = false;
            skeleton.MaxSpeed = 1f+0.1f*r.Next(0,5);
            skeleton.LifeController.SetLifePoints(5,5);
            skeleton.FightingController.EnableAttack(2,25);
            skeleton.FightingController.EnableCanBeAttacked(1);
            skeleton.IslandElementViewSettings = new IslandElementViewSettings() { IsSkeleton = true, HasLifeStatVisualization = true };
            return skeleton;
        }



        public IslandElement GetDefaultUnit(Island visIsland, Vector3 pos, System.Random r, Team team)
        {
            var unit = fac.Create();
            visIsland.ContainerControllerIsland.AddElement(unit);
            unit.RelativeToContainerPosition = pos;
            unit.Factory = fac;
            unit.IslandElementViewSettings = new IslandElementViewSettings() { HasLifeStatVisualization = true };
            unit.hasLight = false;
            unit.ElementalController.SetInfo(new ElementalInfo(0, 0, 0, 0, 0));
            unit.HarvestInfo = new HarvestInfo(false, false, null, null, false, false, false);
            unit.CircleElementProperties = new CircleElementProperties(0.5f, 0.5f);
            unit.MaxSpeed = 1f;
            unit.LifeController.SetLifePoints(30,30);
            unit.FightingController.EnableCanBeAttacked(1);
            unit.FightingController.DisableAttack();
            unit.MagicController.DisableMagic();
            unit.HydrationController.disableDehydration();
            unit.InventoryController.HasInventory = false;
            unit.TeamController.SetTeam(team);
            return unit;
        }
    }
}