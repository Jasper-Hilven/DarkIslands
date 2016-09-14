﻿using System;
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
    private UnitBuilder unitBuilder;
    void Start()
    {
        var goodTeam = new Team();
        var undeadTeam = new Team();
        goodTeam.Enemies.Add(undeadTeam);
        undeadTeam.Enemies.Add(goodTeam);
        var evSystemObj = Instantiate(Resources.Load("Prefabs/EventSystem") as GameObject);
        eventSystem = evSystemObj.GetComponent<EventSystem>();
        var rand = new System.Random(1);
        fP = new FactoryProvider();
        fP.Initialize();
        var worldBuilder = new WorldBuilder();
        worldBuilder.BuildWorld(fP);
        islands = fP.IslandFactory.elements;
        var elementTypes = new List<IElementalType> { new Magma(), new Lightning(), new Psychic(), new Toxic(), new Water() };
        unitBuilder = new UnitBuilder(fP.IslandElementFactory);
        foreach (var eType in elementTypes.Skip(4))
        {
            var onIsland = islands[0];
            var position = new Vector3(eType.GetName().Length - 6, 0, eType.DamageMultiplierAgainst(new Magma()) - 2);
            units.Add(unitBuilder.GetWizzard(eType, onIsland, position, rand, goodTeam));
        }
        FocusOnUnit(units[0]);
        var skeleton = unitBuilder.GetSkeleton(islands[0], new Vector3(7, 0, 7), rand, undeadTeam);
        skeleton.CurrentCommand = new OtherIslandElementCommand(skeleton, units[0]);
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
        if (nbFrames == 10)
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