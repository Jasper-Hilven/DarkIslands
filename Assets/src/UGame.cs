﻿using UnityEngine;
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
    void Start()
    {
        fP = new FactoryProvider();
        fP.Initialize();
        ship = fP.ShipFactory.Create();
        ship.Position = new Vector3();
        cam = new FollowCamera(ship);
        for (int i = 0; i < 8; i++)
            islands.Add(fP.IslandFactory.InitializeSimpleIsland(new Vector3(i, i % 4, 1)));
        var u = fP.UnitFactory.Create();
        u.ElementType= new Magma();
    }

    // Update is called once per frame
    void Update()
    {
        ship.Position += new Vector3(0, Time.deltaTime, 0);
        foreach (var island in islands)
        {
            island.Size += Time.deltaTime;
            if (island.Size >= 5f)
                fP.IslandFactory.DestroyIsland(island);
        }
        islands = islands.Where(i => i.Size < 5f).ToList();
        cam.update();
    }
}