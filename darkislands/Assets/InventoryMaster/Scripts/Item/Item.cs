using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item
{
    public string itemName;                                     //itemName of the item
    public int itemID;                                          //itemID of the item
    public string itemDesc;                                     //itemDesc of the item
    public Sprite itemIcon;                                     //itemIcon of the item
    public GameObject itemModel;                                //itemModel of the item
    public int itemValue = 1;                                   //itemValue is at start 1
    public float itemWeight;                                    //itemWeight of the item
    public int maxStack = 1;
    public int indexItemInList = 999;    
    public int rarity;

  
    
    public Item(){}

    public Item(string name, int id, string desc, Sprite icon, GameObject model, int maxStack, string sendmessagetext)                 //function to create a instance of the Item
    {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemIcon = icon;
        itemModel = model;
        this.maxStack = maxStack;
    }
    public bool IsSameItem(Item other)
    {
        return other != null && other.itemValue == itemValue && other.itemID == itemID;
    }
    public Item getCopy()
    {
        return (Item)this.MemberwiseClone();        
    }   
    
    
}


