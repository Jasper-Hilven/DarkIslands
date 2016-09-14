using System;
using UnityEngine;

namespace DarkIslands.World
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
            var wizzard = GetDefaultUnit(visIsland, pos, r, team);
            wizzard.IslandElementViewSettings = new IslandElementViewSettings() { IsWizzard = true, HasLifeStatVisualization = true };
            wizzard.hasLight = true;
            wizzard.ElementalInfo = eType.IsLightning ? new ElementalInfo(3, 3, 6, 11, 1) : new ElementalInfo(eType, 2);
            wizzard.ElementalType = eType;
            wizzard.HarvestInfo = new HarvestInfo(false, false, null, null, true, true, true);
            wizzard.HarvestController.harvestTactic = new HumanHarvestControllerTactic(wizzard);
            wizzard.hasElementalView = true;
            wizzard.MaxSpeed = 2f;
            wizzard.LifePoints = r.Next(1, 100);
            wizzard.MaxLifePoints = r.Next(wizzard.LifePoints, 120);
            wizzard.ManaPoints = r.Next(0, 100);
            wizzard.MaxManaPoints = r.Next(wizzard.ManaPoints, 120);
            wizzard.HydrationPoints = r.Next(60, 100);
            wizzard.DehydrationRate = 60;
            wizzard.CanDehydrate = true;
            wizzard.MaxHydrationPoints = r.Next(wizzard.HydrationPoints, 120);
            wizzard.InventoryController.HasInventory = true;
            wizzard.FightingController.CanAttack = true;
            wizzard.FightingController.AttackValue = 3;
            wizzard.FightingController.AttackRange = 6;
            return wizzard;
        }

        public IslandElement GetSkeleton(Island visIsland, Vector3 pos, System.Random r, Team team)
        {
            var skeleton = GetDefaultUnit(visIsland, pos, r, team);
            skeleton.hasLight = false;
            skeleton.MaxSpeed = 1f;
            skeleton.LifePoints = 50;
            skeleton.MaxLifePoints = 50;
            skeleton.FightingController.CanAttack = true;
            skeleton.FightingController.AttackValue = 4;
            skeleton.FightingController.AttackRange = 25;
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
            u.LifePoints = 30;
            u.MaxLifePoints = 30;
            u.IsAlive = true;

            u.FightingController.CanBeAttacked = true;
            u.FightingController.CanAttack = false;

            u.ManaPoints = 0;
            u.MaxManaPoints = 0;
            u.HydrationPoints = 100;
            u.DehydrationRate = 0;
            u.CanDehydrate = false;
            u.MaxHydrationPoints = 100;
            u.InventoryController.HasInventory = false;
            u.TeamController.SetTeam(team);
            return u;
        }
    }
}