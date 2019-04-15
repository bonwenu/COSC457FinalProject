using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [Header("Set Dynamically")]
    public string[] inventory; // THIS IS THE PLAYER INVENTORY
    public string[] essentialItems; // THIS IS ALL THE CAR ITEMS IN THE GAME
    public string[] weaponItems; // THIS IS ALL WEAPONS IN THE GAME
    public string[] healthItems; // THIS IS ALL HEALTH ITEMS IN THE GAME
    public int selectedItem; // this is to indicate which item the player currently has equipped
    public Text pickupText;
    public int maxHealthItems;

    // Start is called before the first frame update
    void Start()
    {
        // Can add items here
        essentialItems = new string[] { "Gas", "Tire", "Starter", "Battery" };
        weaponItems = new string[] {"Knife", "Gun"};
        healthItems = new string[] {"Bandage"};

        // Player inventory initialized to empty strings
        inventory = new string[essentialItems.Length + weaponItems.Length + maxHealthItems + 1];
        inventory[0] = "None"; // this is purely so the player can have nothing equipped if they so wish
        for (int i = 1; i < inventory.Length; i++)
        {
            inventory[i] = "";
        }
        selectedItem = 0;
    }

    // The player can use the mouse wheel to select an item;
    void Update()
    {
        float msd = Input.mouseScrollDelta.y;
        if (msd != 0)
        {
            if(msd > 0)
            {
                // if the wheel scrolled up, select the next item
                SelectNextItem();
            }
            else
            {
                // if the wheel scrolled down, select the previous item
                SelectPreviousItem();
            }
        }
    }

    // SelectNextItem selects the next item
    public void SelectNextItem()
    {
        if(selectedItem + 1 == inventory.Length)
        {
            selectedItem = 0;
        }
        else
        {
            selectedItem++;
        }

        for(int i = 0; i < inventory.Length; i++)
        {
            if (IsEssentialItem(inventory[selectedItem]))
            {
                if (selectedItem + 1 == inventory.Length)
                {
                    selectedItem = 0;
                }
                else
                {
                    selectedItem++;
                }
            }
            else
                return;
        }
    }

    // SelectPreviousItem selects the previous item I'm not good at descriptive documentation
    public void SelectPreviousItem()
    {
        if(selectedItem == 0)
        {
            selectedItem = inventory.Length - 1;
        }
        else
        {
            selectedItem--;
        }

        for (int i = 0; i < inventory.Length; i++)
        {
            if (IsEssentialItem(inventory[selectedItem]))
            {
                if (selectedItem == 0)
                {
                    selectedItem = inventory.Length - 1;
                }
                else
                {
                    selectedItem--;
                }
            }
            else
                return;
        }
    }

    // isEssentialItem detects if an item is an essential item (car part), currently only used in item selection methods
    public bool IsEssentialItem(string item)
    {
        for(int i = 0; i < essentialItems.Length; i++)
        {
            if (essentialItems[i].CompareTo(item) == 0)
                return true;
        }
        return false;
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

    // GivePlayerRandomItem gives the player a bomb that explodes when in the inventory, killing the player instantly
    // just kidding, it gives them a random item they don't already have (except bandages, player can have multiple)
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
                        if (m >= maxHealthItems)
                            GivePlayerRandomItem(); // There is probably a smarter way to do this
                    }
                }

                AddToInventory(possibleItems[j][i]);
                Debug.Log("Added " + possibleItems[j][i] + " to inventory");
                pickupText.text = pickupText.text + "\n" + possibleItems[j][i];
                return;
            }
        }
    }

    // HasAllItems checks to see if the player has all essential items (car parts)
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
