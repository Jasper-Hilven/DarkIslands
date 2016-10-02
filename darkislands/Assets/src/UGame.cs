using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.src.World;
using DarkIslands;
using DarkIslands.Player;

public class UGame : MonoBehaviour
{

    // Use this for initialization
    private List<Island> islands = new List<Island>();
    private FactoryProvider fP;
    private FollowCamera cam;
    private Mover m;
    private List<IslandElement> units = new List<IslandElement>();
    private IInventoryView inventoryView;
    private UnitBuilder unitBuilder;
    private Team undeadTeam;
    private System.Random rand;
    void Start()
    {
        var goodTeam = new Team();
        undeadTeam = new Team();
        goodTeam.Enemies.Add(undeadTeam);
        undeadTeam.Enemies.Add(goodTeam);
        rand = new System.Random(1);
        fP = new FactoryProvider();
        fP.Initialize();
        var unityViewFactory = new UnityViewFactory();
        fP.IslandElementUnityViewFactory.UnityViewFactory = unityViewFactory;
        unitBuilder = new UnitBuilder(fP.IslandElementFactory, unityViewFactory);

        InventoryDatabase inventoryDatabase = new InventoryDatabase(unityViewFactory);
        var worldBuilder = new WorldBuilder(unitBuilder, new BuildingBuilder(), unityViewFactory, inventoryDatabase);
        worldBuilder.BuildWorld(fP);
        islands = fP.IslandFactory.elements;
        var elementTypes = new List<IElementalType> { new Magma(), new Lightning(), new Psychic(), new Toxic(), new Water() };
        foreach (var eType in elementTypes.Skip(4))
        {
            var onIsland = islands[0];
            var position = new Vector3(eType.GetName().Length - 6, 0, eType.DamageMultiplierAgainst(new Magma()) - 2);
            units.Add(unitBuilder.GetWizard(eType, onIsland, position, goodTeam));
        }
        cam = new FollowCamera();
        inventoryView = new CoolInventoryView(new GameObjectManager(), cam, new ModelToEntity());
        inventoryView.SetDatabase(inventoryDatabase);
        FocusOnUnit(units[0]);
    }



    private int nbSkeletonsSpawned = 0;
    private void PutASkeleton(Team undeadTeam, System.Random rand)
    {
        if (!(Time.fixedTime > nbSkeletonsSpawned * 11))
            return;
        var ang = rand.Next(0, 360);
        var r = 30;
        var skeleton = unitBuilder.GetSkeleton(islands[0], new Vector3(r * Mathf.Cos(ang), 0, r * Mathf.Sin(ang)), undeadTeam,rand);
        skeleton.ActionHandler.SetNextCommand(new FollowAndProtectCommand(units[0]));
        nbSkeletonsSpawned++;
    }

    private void FocusOnUnit(IslandElement u)
    {
        cam.SetUnit(u);
        m = m ?? new Mover(u, fP.ModelToEntity);
        inventoryView.FocusOn(u);
        cam.toFollow = u;
        m.unit = u;
    }
   
    // Update is called once per frame
    void Update()
    {
        var deltaTime = Time.deltaTime;
        fP.IslandElementActionHandlerFactory.Update(deltaTime);
        fP.IslandMovementControllerFactory.Update(deltaTime);
        fP.IslandElementElementalViewFactory.Update(deltaTime);
        fP.IslandElementHydrationControllerFactory.Update(deltaTime);
        fP.IslandElementSpawnControllerFactory.Update(deltaTime);
        UpdateFocussedUnit();
        cam.update();
        m.Update();
        inventoryView.Update(deltaTime);
        nbFrames++;
        PutASkeleton(undeadTeam, rand);
    }

    int nbFrames;

    void UpdateFocussedUnit()
    {
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