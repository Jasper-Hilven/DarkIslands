using System;
using UnityEngine;
using Random = System.Random;

namespace DarkIslands
{
    public class UnitBuilder
    {
        private IslandElementFactory fac;
        private Random r;

        public UnitBuilder(IslandElementFactory fac, System.Random r)
        {
            this.r = r;
            this.fac = fac;
        }

        public IslandElement GetWizard(IElementalType eType, Island visIsland, Vector3 pos, Team team)
        {
            var wizard = GetDefaultUnit(visIsland, pos, team);
            wizard.IslandElementViewSettings = new IslandElementViewSettings() { IsWizard = true, HasLifeStatVisualization = true };
            wizard.hasLight = true;
            var elementalInfo = eType.IsWater ? new ElementalInfo(13, 13, 16, 11, 13) : new ElementalInfo(eType, 2);
            wizard.ElementalController.SetInfo(elementalInfo, eType, true);
            wizard.HarvestController.SetHarvestSettings(new HumanHarvestControllerTactic(wizard), new HarvestInfo(false, false, null, null, true, true, true,true));
            wizard.MaxSpeed = 2f;
            wizard.LifeController.SetLifePoints(50, 50);
            wizard.MagicController.EnableMagic(70, 100);
            wizard.HydrationController.EnableDehydrating(6, 80, 80);
            wizard.FightingController.EnableAttack(3, 6);
            wizard.InventoryController.HasInventory = true;
            return wizard;
        }

        public IslandElement GetSpawnedFighter(IslandElement spawner, Island island, Vector3 pos, Team team,bool isArcher)
        {
            var fighter = GetDefaultUnit(island, pos, team);
            fighter.LifeController.SetLifePoints(5, 5);
            var attackRange = isArcher ? 70 : 25;
            var attackDamage = isArcher ? 1 : 2;
            fighter.FightingController.EnableAttack(attackDamage, attackRange);
            fighter.FightingController.EnableCanBeAttacked(3);
            fighter.IslandElementViewSettings = new IslandElementViewSettings() { IsFighter = true, HasLifeStatVisualization = true };
            fighter.ActionHandler.SetNextCommand(new FollowAndProtectCommand(spawner));
            return fighter;
        }

        public IslandElement GetSkeleton(Island visIsland, Vector3 pos, Team team)
        {
            var skeleton = GetDefaultUnit(visIsland, pos, team);
            skeleton.MaxSpeed = 1f + 0.1f * r.Next(0, 5);
            skeleton.LifeController.SetLifePoints(5, 5);
            skeleton.FightingController.EnableAttack(2, 25);
            skeleton.FightingController.EnableCanBeAttacked(3);
            skeleton.IslandElementViewSettings = new IslandElementViewSettings() { IsSkeleton = true, HasLifeStatVisualization = true };
            return skeleton;
        }

        public IslandElement GetDefaultUnit(Island visIsland, Vector3 pos, Team team)
        {
            var unit = fac.Create();
            visIsland.ContainerControllerIsland.AddElement(unit);
            unit.RelativeToContainerPosition = pos;
            unit.Factory = fac;
            unit.IslandElementViewSettings = new IslandElementViewSettings() { HasLifeStatVisualization = true };
            unit.hasLight = false;
            unit.ElementalController.SetInfo(new ElementalInfo(0, 0, 0, 0, 0));
            unit.HarvestInfo = new HarvestInfo(false, false, null, null, false, false, false,false);
            unit.CircleElementProperties = new CircleElementProperties(0.5f, 0.5f);
            unit.MaxSpeed = 1f;
            unit.LifeController.SetLifePoints(30, 30);
            unit.FightingController.EnableCanBeAttacked(1);
            unit.FightingController.DisableAttack();
            unit.MagicController.DisableMagic();
            unit.HydrationController.disableDehydration();
            unit.InventoryController.HasInventory = false;
            unit.TeamController.SetTeam(team);
            unit.NearOthersController.SetActive();
            return unit;
        }
    }
}