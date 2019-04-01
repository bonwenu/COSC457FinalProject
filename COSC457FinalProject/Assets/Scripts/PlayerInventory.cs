using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Set Dynamically")]
    public string[] inventory; // THIS IS THE PLAYER INVENTORY
    public string[] possibleItems; // THIS IS ALL THE ITEMS IN THE GAME

    // Start is called before the first frame update
    void Start()
    {
        // Can be changed later if there are more items
        inventory = new string[4];
        for (int i = 0; i < inventory.Length; i++)
        {
            inventory[i] = "";
        }

        possibleItems = new string[] { "Gas", "Tire", "Keys", "Starter" };
    }

    // IsInInventory checks to see if the item is in the players inventory already
    public bool IsInInventory(string item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].CompareTo(item) == 0)
            {
                return true;
            }
        }
        return false;
    }

    // AddToInventory adds a specified item to the players inventory
    public void AddToInventory(string item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].CompareTo("") == 0)
            {
                inventory[i] = item;
                return;
            }
        }
    }

    public void GivePlayerRandomItem()
    {
        System.Random r = new System.Random();
        int i = 0;
        while (true)
        {
            i = r.Next(0, possibleItems.Length);
            if (!IsInInventory(possibleItems[i]))
            {
                AddToInventory(possibleItems[i]);
                Debug.Log("Added " + possibleItems[i] + " to inventory");
                return;
            }
        }
    }

    public bool HasAllItems()
    {
        for (int i = 0; i < possibleItems.Length; i++)
        {
            if (!IsInInventory(possibleItems[i]))
            {
                return false;
            }
        }
        return true;
    }
}
