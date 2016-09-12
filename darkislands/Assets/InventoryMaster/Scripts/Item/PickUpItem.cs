using UnityEngine;
using System.Collections;
public class PickUpItem : MonoBehaviour
{
    public Item item;
    private Inventory _inventory;
    private GameObject _player;
    // Use this for initialization

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (_inventory != null && Input.GetKeyDown(KeyCode.E))
        {
        }
    }

}