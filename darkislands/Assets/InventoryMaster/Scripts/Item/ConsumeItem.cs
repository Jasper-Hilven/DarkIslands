using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ConsumeItem : MonoBehaviour, IPointerDownHandler
{
    public Item item;
    public static GameObject mainInventory;
    private int index;

    void Start()
    {
        item = GetComponent<ItemOnObject>().item;
        if (GameObject.FindGameObjectWithTag("MainInventory") != null)
            mainInventory = GameObject.FindGameObjectWithTag("MainInventory");
        index = mainInventory.GetComponent<Inventory>().GetItemIndex(item);
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (data.button == PointerEventData.InputButton.Right)
        {
            consumeIt();
        }
    }

    public void consumeIt()
    {
        Inventory inventory = transform.parent.parent.parent.GetComponent<Inventory>();
        inventory.ConsumeItemAt(index);
    }
}
