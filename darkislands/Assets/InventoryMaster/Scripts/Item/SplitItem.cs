using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SplitItem : MonoBehaviour, IPointerDownHandler
{     //splitting an Item

    private bool pressingButtonToSplit;             //bool for pressing a item to split it
    public Inventory inv;                          //inventory script  

    void Update()
    {
        if (false)                     //if we press right controll the ....
            pressingButtonToSplit = true;                               //getting changed to true 
        if (false)
            pressingButtonToSplit = false;                              //or false

    }

   
    public void OnPointerDown(PointerEventData data)                    //splitting the item now
    {
       
    }
}
