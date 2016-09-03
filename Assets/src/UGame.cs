using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private List<IslandElement> trees = new List<IslandElement>();
    void Start()
    {
        fP = new FactoryProvider();
        fP.Initialize();

        for (int i = 0; i < 2; i++)
        {
            var simpleIsland = fP.IslandFactory.InitializeSimpleIsland(new Vector3(0,0,0));
            islands.Add(simpleIsland);
        }
        islands[0].Position = islands[1].Position + new Vector3(40.5f*Mathf.Cos(0), 0, 40.5f*Mathf.Sin(0));
        for (int i = 0; i < 360; i += 8)
        {
            if (i > 100 && i < 200)
                continue;
            var tree = fP.IslandElementFactory.Create();
            tree.Factory = fP.IslandElementFactory;
            tree.IslandElementViewSettings = new IslandElementViewSettings() { IsTree = true };
            tree.CircleElementProperties = new CircleElementProperties(0.5f, 0.5f);
            tree.HarvestController.harvestTactic= new TreeHarvestControllerTactic(tree);
            tree.SizeController = new TreeSizeController();
            var resourceCount = new Dictionary<ResourceType, int>();
            resourceCount[ResourceType.Wood] = 10;
            tree.HarvestInfo = new HarvestInfo(true, false, resourceCount, resourceCount, false, false, false);
            trees.Add(tree);
            islands[0].ContainerControllerIsland.AddElement(tree);
            var radAngle = 2 * Mathf.PI / 360f * i;
            tree.RelativeToContainerPosition = new Vector3(i == 0? 0:18 * Mathf.Cos(radAngle), 0, i == 0 ? 0 : 18 * Mathf.Sin(radAngle));
        }

        var elementTypes = new List<IElementalType> { new Magma(), new Lightning(), new Psychic(), new Toxic(), new Water() };
        foreach (var eType in elementTypes.Skip(0))
            units.Add(GetUnit(fP.IslandElementFactory, eType, islands[(eType.IsLightning || eType.IsToxic) ? 0: 1], new Vector3(eType.GetName().Length - 6, 0, eType.DamageMultiplierAgainst(new Magma()) - 2)));
        FocusOnUnit(units[0]);
    }

    private IslandElement GetUnit(IslandElementFactory fac, IElementalType eType, Island visIsland, Vector3 pos)
    {
        var u = fac.Create();
        visIsland.ContainerControllerIsland.AddElement(u);
        u.RelativeToContainerPosition = pos;
        u.Factory = fac;
        u.IslandElementViewSettings = new IslandElementViewSettings() { IsUnit = true };
        u.hasLight = true;
        u.ElementalInfo = eType.IsLightning ? new ElementalInfo(3, 3, 6, 11, 1) : new ElementalInfo(eType, 2);
        u.ElementalType = eType;
        u.HarvestInfo = new HarvestInfo(false, false, null, null, true, true, true);
        u.HarvestController.harvestTactic= new HumanHarvestControllerTactic(u);
        u.CircleElementProperties = new CircleElementProperties(0.5f, 0.5f);
        u.hasElementalView = true;
        u.MaxSpeed = 2f;
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
        float angle = Time.realtimeSinceStartup / 20f;
        var island0Pos= islands[1].Position + new Vector3(40.5f * Mathf.Cos(angle), 0, 40.5f * Mathf.Sin(angle));
        fP.InterIslandCollisionFactory.MoveDetectCollision(islands[0], island0Pos);

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