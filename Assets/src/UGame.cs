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
    private Ship ship;
    private List<Island> islands = new List<Island>();
    private FactoryProvider fP;
    private FollowCamera cam;
    private Mover m;
    private List<Unit> units = new List<Unit>();
    void Start()
    {
        try
        {
            fP = new FactoryProvider();
            fP.Initialize();
            for (int i = 0; i < 100; i+=3)
            {
                var tree = fP.WorldObjectFactory.Create();
                tree.Type = WorldObjectType.Tree;
                tree.Position= new Vector3(i%10,0,i/10);
            }

            ship = fP.ShipFactory.Create();
            ship.Position = new Vector3(2,0.2f,4);
            ship.MaxSpeed = 0.4f;
            for (int i = 0; i < 2; i++)
            {
                var simpleIsland = fP.IslandFactory.InitializeSimpleIsland(new Vector3(29 * i, i, 2));
                islands.Add(simpleIsland);
            }

            var elementTypes = new List<IElementType> { new Magma(), new Lightning(), new Psychic(), new Toxic(), new Water() };
            foreach (var eType in elementTypes)
                units.Add(GetUnit(fP.UnitFactory, eType, islands[0], new Vector3(eType.GetName().Length-6,0,eType.DamageMultiplierAgainst(new Magma())-2)));
            FocusOnUnit(units[0]);
            units[0].CurrentAction=new EnterShipAction(ship);
            units[2].CurrentAction = new EnterShipAction(ship);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private Unit GetUnit(UnitFactory fac, IElementType eType, Island visIsland,Vector3 pos)
    {
        var u = fac.Create();
        u.Position = pos;
        u.ElementType = eType;
        u.Container = visIsland;
        u.hasLight = true;
        u.ElementInfo= eType.IsLightning? new ElementInfo(5,1,1,1,1):new ElementInfo(eType,2) ;
        u.hasElementView = true;
        u.MaxSpeed = 1f;
        return u;
    }

    private void FocusOnUnit(Unit u)
    {
        cam = cam ?? new FollowCamera(u);
        m = m ?? new Mover(u,fP.ModelToEntity);
        cam.toFollow = u;
        m.unit = u;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateFocussedUnit();
        fP.UnitMovementControllerFactory.Update(Time.deltaTime);
        fP.UnitActionHandlerFactory.Update();
        fP.ShipMovementControllerFactory.Update(Time.deltaTime);
        fP.UnitELementViewFactory.Update(Time.deltaTime);
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