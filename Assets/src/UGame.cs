using UnityEngine;
using System.Collections;
using DarkIslands;

public class UGame : MonoBehaviour {

    // Use this for initialization
    private Ship ship;
    void Start () {
        var factoryProvider = new FactoryProvider();
        factoryProvider.Initialize();
        ship = factoryProvider.ShipFactory.Create();
        ship.Position= new Vector3();
    }

    // Update is called once per frame
    void Update () {
        ship.Position += new Vector3(0,Time.deltaTime,0);
	}
}
