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
            ship = fP.ShipFactory.Create();
            ship.Position = new Vector3();
            for (int i = 0; i < 2; i++)
                islands.Add(fP.IslandFactory.InitializeSimpleIsland(new Vector3(9 * i, i, 1)));

            foreach (var eType in new List<IElementType> { new Magma(), new Lightning(), new Psychic(), new Toxic(), new Water() })
                units.Add(GetUnit(fP.UnitFactory, eType, islands[0]));
            FocusOnUnit(units[0]);
        }
        catch (Exception e)
        {
            Console.WriteLine();
            throw;
        }
    }

    private Unit GetUnit(UnitFactory fac, IElementType eType, Island visIsland)
    {
        var u = fac.Create();
        u.ElementType = eType;
        u.VisitingIsland = visIsland;
        u.MaxSpeed = 1f;
        return u;
    }

    private void FocusOnUnit(Unit u)
    {
        cam = cam ?? new FollowCamera(u);
        m = m ?? new Mover(u);
        cam.toFollow = u;
        m.unit = u;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateFocussedUnit();
        ship.Position = new Vector3(0, 1, 0);
        fP.UnitMovementControllerFactory.Update(Time.deltaTime);
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