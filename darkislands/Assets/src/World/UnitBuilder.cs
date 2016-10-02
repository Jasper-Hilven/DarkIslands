using System;
using UnityEngine;
using Random = System.Random;

namespace DarkIslands
{
    public class UnitBuilder
    {
        private UnityViewFactory viewFac;
        private IslandElementFactory elemFac;
        private InventoryDatabase inventoryDb;

        public UnitBuilder(IslandElementFactory elemFac,UnityViewFactory unityViewFactory,InventoryDatabase inventoryDb)
        {
            this.elemFac = elemFac;
            this.viewFac = unityViewFactory;
            this.inventoryDb = inventoryDb;
        }

        public IslandElement GetWizard(IElementalType eType, Island visIsland, Vector3 pos, Team team)
        {
            var wizard = GetDefaultUnit(visIsland, pos, team);
            wizard.IslandElementViewSettings = new IslandElementViewSettings() {GetGameObject=()=>viewFac.GetWizardVisualization(), HasLifeStatVisualization = true };
            wizard.hasLight = true;
            var elementalInfo = eType.IsWater ? new ElementalInfo(13, 13, 16, 11, 13) : new ElementalInfo(eType, 2);
            wizard.ElementalController.SetInfo(elementalInfo, eType, true);
            wizard.HarvestController.SetHarvestSettings(new HumanHarvestControllerTactic(wizard), new HarvestInfo(false, false, null, null, true, true, true,true));
            wizard.MaxSpeed = 6f;
            wizard.LifeController.SetLifePoints(50, 50);
            wizard.MagicController.EnableMagic(70, 100);
            wizard.HydrationController.EnableDehydrating(60, 80, 80);
            wizard.FightingController.EnableAttack(3, 6);
            wizard.InventoryController.HasInventory = true;
            wizard.ItemUsageController.usageTactic = new WizardItemUsageControllerTactic(inventoryDb);
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
            fighter.IslandElementViewSettings = new IslandElementViewSettings() { GetGameObject = ()=>viewFac.GetFighterVisualization(), HasLifeStatVisualization = true };
            fighter.ActionHandler.SetNextCommand(new FollowAndProtectCommand(spawner));
            return fighter;
        }

        public IslandElement GetSkeleton(Island visIsland, Vector3 pos, Team team, Random r)
        {
            var skeleton = GetDefaultUnit(visIsland, pos, team);
            skeleton.MaxSpeed = 3f + 0.3f * r.Next(0, 5);
            skeleton.LifeController.SetLifePoints(5, 5);
            skeleton.FightingController.EnableAttack(2, 25);
            skeleton.FightingController.EnableCanBeAttacked(3);
            skeleton.IslandElementViewSettings = new IslandElementViewSettings() { GetGameObject =()=> viewFac.GetSkeletonVisualization(),HasLifeStatVisualization = true };
            return skeleton;
        }

        public IslandElement GetDefaultUnit(Island visIsland, Vector3 pos, Team team)
        {
            var unit = elemFac.Create();
            visIsland.ContainerControllerIsland.AddElement(unit);
            unit.RelativeToContainerPosition = pos;
            unit.Factory = elemFac;
            unit.IslandElementViewSettings = new IslandElementViewSettings() { HasLifeStatVisualization = true };
            unit.hasLight = false;
            unit.ElementalController.SetInfo(new ElementalInfo(0, 0, 0, 0, 0));
            unit.HarvestInfo = new HarvestInfo(false, false, null, null, false, false, false,false);
            unit.CircleElementProperties = new CircleElementProperties(0.5f, 0.5f);
            unit.MaxSpeed = 4f;
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