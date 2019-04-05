using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Set Dynamically")]
    public string[] inventory; // THIS IS THE PLAYER INVENTORY
    public string[] essentialItems; // THIS IS ALL THE CAR ITEMS IN THE GAME
    public string[] weaponItems; // THIS IS ALL WEAPONS IN THE GAME
    public string[] healthItems; // THIS IS ALL HEALTH ITEMS IN THE GAME

    // Start is called before the first frame update
    void Start()
    {
        // Can add items here
        essentialItems = new string[] { "Gas", "Tire", "Keys", "Battery" };
        weaponItems = new string[] {"Knife", "Gun"};
        healthItems = new string[] {"Bandage"};

        // Player inventory initialized to empty strings
        int maxHealthItems = 5;
        inventory = new string[essentialItems.Length+weaponItems.Length+maxHealthItems];
        for (int i = 0; i < inventory.Length; i++)
        {
            inventory[i] = "";
        }
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
        int i = 0, j = 0;
        string[][] possibleItems = new string[3][];
        possibleItems[0] = essentialItems;
        possibleItems[1] = weaponItems;
        possibleItems[2] = healthItems;
        while (true)
        {
            j = r.Next(0, possibleItems.Length);
            i = r.Next(0, possibleItems[j].Length);
            if (!IsInInventory(possibleItems[j][i]) || (j == 2))
            {
                int m = 0;
                if (j == 2)
                {
                    for (int k = 0; k < inventory.Length; k++)
                    {
                        if (possibleItems[j][i].CompareTo(inventory[k]) == 0)
                            m++;
                        if (m >= 5)
                            GivePlayerRandomItem(); // This is bad programming don't do this
                    }
                }

                AddToInventory(possibleItems[j][i]);
                Debug.Log("Added " + possibleItems[j][i] + " to inventory");
                return;
            }
        }
    }

    public bool HasAllItems()
    {
        for (int i = 0; i < essentialItems.Length; i++)
        {
            if (!IsInInventory(essentialItems[i]))
            {
                return false;
            }
        }
        return true;
    }
}
