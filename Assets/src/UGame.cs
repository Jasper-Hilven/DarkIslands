using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DarkIslands;
using DarkIslands.Player;
using DarkIslands.World;

public class UGame : MonoBehaviour
{

    // Use this for initialization
    private List<Island> islands = new List<Island>();
    private FactoryProvider fP;
    private FollowCamera cam;
    private Mover m;
    private List<IslandElement> units = new List<IslandElement>();
    void Start()
    {
        var rand = new System.Random(1);
        fP = new FactoryProvider();
        fP.Initialize();
        var worldBuilder= new WorldBuilder();
        worldBuilder.BuildWorld(fP);
        islands = fP.IslandFactory.elements;
        var elementTypes = new List<IElementalType> { new Magma(), new Lightning(), new Psychic(), new Toxic(), new Water() };
        
        foreach (var eType in elementTypes.Skip(0))
        {
            var onIsland = islands[(eType.IsLightning || eType.IsToxic) ? 0: 1];
            var position = new Vector3(eType.GetName().Length - 6, 0, eType.DamageMultiplierAgainst(new Magma()) - 2);
            units.Add(GetUnit(fP.IslandElementFactory, eType, onIsland, position,rand));
        }
        FocusOnUnit(units[0]);
    }

    private IslandElement GetUnit(IslandElementFactory fac, IElementalType eType, Island visIsland, Vector3 pos,System.Random r)
    {
        var u = fac.Create();
        visIsland.ContainerControllerIsland.AddElement(u);
        u.RelativeToContainerPosition = pos;
        u.Factory = fac;
        u.IslandElementViewSettings = new IslandElementViewSettings() { IsUnit = true,HasLifeStatVisualization = true};
        u.hasLight = true;
        u.ElementalInfo = eType.IsLightning ? new ElementalInfo(3, 3, 6, 11, 1) : new ElementalInfo(eType, 2);
        u.ElementalType = eType;
        u.HarvestInfo = new HarvestInfo(false, false, null, null, true, true, true);
        u.HarvestController.harvestTactic= new HumanHarvestControllerTactic(u);
        u.CircleElementProperties = new CircleElementProperties(0.5f, 0.5f);
        u.hasElementalView = true;

        u.MaxSpeed = 2f;

        u.LifePoints = 5;
        u.MaxLifePoints = r.Next(5, 10);

        u.ManaPoints = 10;
        u.MaxManaPoints = 20;

        u.HydrationPoints = 30;
        u.MaxHydrationPoints = 40;

        return u;
    }

    private void FocusOnUnit(IslandElement u)
    {
        cam = cam ?? new FollowCamera(u);
        m = m ?? new Mover(u, fP.ModelToEntity);
        cam.toFollow = u;
        m.unit = u;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateFocussedUnit();
        fP.IslandElementActionHandlerFactory.Update(Time.deltaTime);
        fP.IslandElementElementalViewFactory.Update(Time.deltaTime);
        fP.IslandMovementControllerFactory.Update(Time.deltaTime);
        cam.update();
        m.Update();
    }


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