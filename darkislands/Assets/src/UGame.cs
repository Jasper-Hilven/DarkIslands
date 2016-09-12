using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DarkIslands;
using DarkIslands.Player;
using DarkIslands.World;
using UnityEngine.EventSystems;

public class UGame : MonoBehaviour
{

    // Use this for initialization
    private List<Island> islands = new List<Island>();
    private FactoryProvider fP;
    private FollowCamera cam;
    private Mover m;
    private List<IslandElement> units = new List<IslandElement>();
    private InventoryViewFacade inventoryView = null;
    private DIInventoryDatabase inventoryDatabase = new DIInventoryDatabase();
    private EventSystem eventSystem;
    void Start()
    {
        var evSystemObj = Instantiate(Resources.Load("Prefabs/EventSystem") as GameObject);
        eventSystem = evSystemObj.GetComponent<EventSystem>();
        var rand = new System.Random(1);
        fP = new FactoryProvider();
        fP.Initialize();
        var worldBuilder = new WorldBuilder();
        worldBuilder.BuildWorld(fP);
        islands = fP.IslandFactory.elements;
        var elementTypes = new List<IElementalType> { new Magma(), new Lightning(), new Psychic(), new Toxic(), new Water() };

        foreach (var eType in elementTypes.Skip(0))
        {
            var onIsland = islands[(eType.IsLightning || eType.IsToxic) ? 0 : 1];
            var position = new Vector3(eType.GetName().Length - 6, 0, eType.DamageMultiplierAgainst(new Magma()) - 2);
            units.Add(GetUnit(fP.IslandElementFactory, eType, onIsland, position, rand));
        }
        FocusOnUnit(units[0]);
    }

    private IslandElement GetUnit(IslandElementFactory fac, IElementalType eType, Island visIsland, Vector3 pos, System.Random r)
    {
        var u = fac.Create();
        visIsland.ContainerControllerIsland.AddElement(u);
        u.RelativeToContainerPosition = pos;
        u.Factory = fac;
        u.IslandElementViewSettings = new IslandElementViewSettings() { IsUnit = true, HasLifeStatVisualization = true };
        u.hasLight = true;
        u.ElementalInfo = eType.IsLightning ? new ElementalInfo(3, 3, 6, 11, 1) : new ElementalInfo(eType, 2);
        u.ElementalType = eType;
        u.HarvestInfo = new HarvestInfo(false, false, null, null, true, true, true);
        u.HarvestController.harvestTactic = new HumanHarvestControllerTactic(u);
        u.CircleElementProperties = new CircleElementProperties(0.5f, 0.5f);
        u.hasElementalView = true;

        u.MaxSpeed = 2f;

        u.LifePoints = r.Next(1, 100);
        u.MaxLifePoints = r.Next(u.LifePoints, 120);

        u.ManaPoints = r.Next(0, 100);
        u.MaxManaPoints = r.Next(u.ManaPoints, 120);

        u.HydrationPoints = r.Next(60, 100);
        u.DehydrationRate = 60;
        u.CanDehydrate = true;
        u.MaxHydrationPoints = r.Next(u.HydrationPoints, 120);

        u.InventoryController.HasInventory = true;

        return u;
    }

    private void FocusOnUnit(IslandElement u)
    {
        cam = cam ?? new FollowCamera(u);
        m = m ?? new Mover(u, fP.ModelToEntity, eventSystem);
        if (inventoryView == null)
        {
            inventoryView = new InventoryViewFacade(new GameObjectManager());
            inventoryView.SetDatabase(inventoryDatabase);
        }
        inventoryView.FocusOn(u);
        cam.toFollow = u;
        m.unit = u;
    }
    private void afterScreenLoaded()
    {
        inventoryView.InitializeAfterScreenLoaded();
    }

    // Update is called once per frame
    void Update()
    {
        fP.IslandElementActionHandlerFactory.Update(Time.deltaTime);
        fP.IslandMovementControllerFactory.Update(Time.deltaTime);
        fP.IslandElementElementalViewFactory.Update(Time.deltaTime);
        fP.IslandElementHydrationControllerFactory.Update(Time.deltaTime);
        UpdateFocussedUnit();
        cam.update();
        m.Update();
        nbFrames++;
        if(nbFrames == 10)
            afterScreenLoaded();
    }

    int nbFrames;
    void UpdateFocussedUnit()
    {
        var force = islands[1].Mass * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.A))
            FocusOnUnit(units[0]);
        if (Input.GetKeyDown(KeyCode.Z))
            FocusOnUnit(units[1]);
        if (Input.GetKeyDown(KeyCode.E))
            FocusOnUnit(units[2]);
        if (Input.GetKeyDown(KeyCode.R))
            FocusOnUnit(units[3]);
        if (Input.GetKeyDown(KeyCode.T))
            FocusOnUnit(units[4]);
    }
}