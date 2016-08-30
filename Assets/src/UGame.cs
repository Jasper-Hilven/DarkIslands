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
                var simpleIsland = fP.IslandFactory.InitializeSimpleIsland(new Vector3(29 * i, i, 2));
            simpleIsland.CircleElementProperties = new CircleElementProperties(1);
            islands.Add(simpleIsland);
            }
            for (int i = 0; i < 360; i += 8 )
            {
                var tree = fP.IslandElementFactory.Create();
                tree.IslandElementViewSettings = new IslandElementViewSettings() {IsTree = true};
                tree.CircleElementProperties= new CircleElementProperties(0.5f);
                trees.Add(tree);
                islands[0].ContainerControllerIsland.AddElement(tree);
                var radAngle = 2*Mathf.PI/360f*i;
                tree.RelativeToContainerPosition = new Vector3(18*Mathf.Cos(radAngle), 0, 18 * Mathf.Sin(radAngle));
            }

            var elementTypes = new List<IElementalType> { new Magma(), new Lightning(), new Psychic(), new Toxic(), new Water() };
            foreach (var eType in elementTypes.Skip(0))
                units.Add(GetUnit(fP.IslandElementFactory, eType, islands[0], new Vector3(eType.GetName().Length - 6, 0, eType.DamageMultiplierAgainst(new Magma()) - 2)));
            FocusOnUnit(units[0]);
    }

    private IslandElement GetUnit(IslandElementFactory fac, IElementalType eType, Island visIsland, Vector3 pos)
    {
        var u = fac.Create();
        u.Position = pos;
        
        visIsland.ContainerControllerIsland.AddElement(u);
        u.IslandElementViewSettings=new IslandElementViewSettings() {IsUnit = true};
        u.hasLight = true;
        u.ElementalInfo = eType.IsLightning ? new ElementalInfo(3, 3, 6, 11, 1) : new ElementalInfo(eType, 2);
        u.ElementalType = eType;
        u.CircleElementProperties= new CircleElementProperties(0.5f);
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
        fP.IslandElementMovementControllerFactory.Update(Time.deltaTime);
        fP.IslandElementActionHandlerFactory.Update(Time.deltaTime);
        fP.IslandElementElementalViewFactory.Update(Time.deltaTime);
        islands[0].Position = islands[0].Position + new Vector3(Time.deltaTime / 10f, 0, 0);
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