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
        public IslandElement GetWizzard(IElementalType eType, Island visIsland, Vector3 pos, System.Random r, Team team)
        {
            var wizard = GetDefaultUnit(visIsland, pos, r, team);
            wizard.IslandElementViewSettings = new IslandElementViewSettings() { IsWizzard = true, HasLifeStatVisualization = true };
            wizard.hasLight = true;
            wizard.ElementalInfo = eType.IsWater ? new ElementalInfo(13, 13, 16, 11, 13) : new ElementalInfo(eType, 2);
            wizard.ElementalType = eType;
            wizard.HarvestInfo = new HarvestInfo(false, false, null, null, true, true, true);
            wizard.HarvestController.harvestTactic = new HumanHarvestControllerTactic(wizard);
            wizard.hasElementalView = true;
            wizard.MaxSpeed = 2f;
            wizard.LifeController.SetLifePoints(50,50);
            wizard.MagicController.EnableMagic(70,100);
            wizard.HydrationController.EnableHydrating(60,70,80);
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
            var u = fac.Create();
            visIsland.ContainerControllerIsland.AddElement(u);
            u.RelativeToContainerPosition = pos;
            u.Factory = fac;
            u.IslandElementViewSettings = new IslandElementViewSettings() { HasLifeStatVisualization = true };
            u.hasLight = false;
            u.ElementalInfo = new ElementalInfo(0, 0, 0, 0, 0);
            u.HarvestInfo = new HarvestInfo(false, false, null, null, false, false, false);
            u.CircleElementProperties = new CircleElementProperties(0.5f, 0.5f);
            u.hasElementalView = false;
            u.MaxSpeed = 1f;
            u.LifeController.SetLifePoints(30,30);
            u.LifeController.SetLifePoints(10,10);
            u.FightingController.EnableCanBeAttacked(1);
            u.FightingController.DisableAttack();
            u.MagicController.DisableMagic();
            u.HydrationController.disableDehydration();
            u.InventoryController.HasInventory = false;
            u.TeamController.SetTeam(team);
            return u;
        }
    }
}