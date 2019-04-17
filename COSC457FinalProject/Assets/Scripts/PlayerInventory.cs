using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Sprite[] itemSprites;
    /* Sprites are as follows:
     itemSprites[0] = Bat
     itemSprites[1] = Knife
     itemSprites[2] = Axe
     itemSprites[3] = Gun
     
     itemSprites[4] = Tire
     itemSprites[5] = Gas
     itemSprites[6] = Starter
     itemSprites[7] = Battery
     
     itemSprites[8] = Water
     itemSprites[9] = Bandage
     itemSprites[10] = Food
     itemSprites[11] = Pills
     */
    public Sprite[] usedHealthItems;

    public Image[] carParts;
    public Image[] usableItems;
    public Image[] selectedItems;

    [Header("Set Dynamically")]
    public string[] inventory; // THIS IS THE PLAYER INVENTORY
    public string[] essentialItems; // THIS IS ALL THE CAR ITEMS IN THE GAME
    public string[] weaponItems; // THIS IS ALL WEAPONS IN THE GAME
    public string[] healthItems; // THIS IS ALL HEALTH ITEMS IN THE GAME
    public int selectedItem; // this is to indicate which item the player currently has equipped
    public Text pickupText;
    public Text countText;

    // Start is called before the first frame update
    void Start()
    {
        // Can add items here
        essentialItems = new string[] { "Gas", "Tire", "Starter", "Battery"};
        weaponItems = new string[] {"Knife", "Gun", "Bat", "Axe"};
        healthItems = new string[] {"Bandage", "Food", "Water", "Pills"};

        // Player inventory initialized to empty strings
        inventory = new string[essentialItems.Length + weaponItems.Length + healthItems.Length + 1];
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
                selectedItems[getItemImageindex(inventory[selectedItem])].color = Color.clear;
                SelectNextItem();
                if (inventory[selectedItem].CompareTo("None") != 0)
                    selectedItems[getItemImageindex(inventory[selectedItem])].color = Color.white;
            }
            else
            {
                // if the wheel scrolled down, select the previous item
                selectedItems[getItemImageindex(inventory[selectedItem])].color = Color.clear;
                SelectPreviousItem();
                if(inventory[selectedItem].CompareTo("None") != 0)
                    selectedItems[getItemImageindex(inventory[selectedItem])].color = Color.white;
            }
        }

        // this is how the player can regain health
        if(Input.GetMouseButton(0))
        {
            if (inventory[selectedItem].CompareTo("Bandage") == 0 || inventory[selectedItem].CompareTo("Food") == 0 ||
                inventory[selectedItem].CompareTo("Water") == 0 || inventory[selectedItem].CompareTo("Pills") == 0)
            {
                float health = this.GetComponent<PlayerCombat>().health;
                float tempHealth = this.GetComponent<PlayerCombat>().tempHealth;
                if (inventory[selectedItem].CompareTo("Bandage") == 0)
                {
                    health += 0.5f;
                    int index = getItemImageindex("Bandage");
                    usableItems[index].sprite = usedHealthItems[1];
                    selectedItems[index].color = Color.clear;
                }
                else if (inventory[selectedItem].CompareTo("Food") == 0)
                {
                    health += 0.15f;
                    int index = getItemImageindex("Bandage");
                    usableItems[index].sprite = usedHealthItems[2];
                    selectedItems[index].color = Color.clear;
                }
                else if (inventory[selectedItem].CompareTo("Water") == 0)
                {
                    health += 0.25f;
                    int index = getItemImageindex("Bandage");
                    usableItems[index].sprite = usedHealthItems[0];
                    selectedItems[index].color = Color.clear;
                }
                else if (inventory[selectedItem].CompareTo("Pills") == 0)
                {
                    health += 1f;
                    int index = getItemImageindex("Bandage");
                    usableItems[index].sprite = usedHealthItems[3];
                    selectedItems[index].color = Color.clear;
                }
                if (health > 2)
                    health = 2;
                this.GetComponent<PlayerCombat>().health = health;
                this.GetComponent<PlayerCombat>().healthBar.SetSize(health / tempHealth);
                inventory[selectedItem] = "";
                SelectNextItem();
                selectedItems[selectedItem].color = Color.white;
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
            if (IsEssentialItem(inventory[selectedItem]) || inventory[selectedItem].CompareTo("") == 0)
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
            if (IsEssentialItem(inventory[selectedItem]) || inventory[selectedItem].CompareTo("") == 0)
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
    // just kidding, it gives them a random item they don't already have
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
            if (!IsInInventory(possibleItems[j][i]))
            {
                AddToInventory(possibleItems[j][i]);
                Debug.Log("Added " + possibleItems[j][i] + " to inventory");
                Vector3 temp;
                if (IsEssentialItem(possibleItems[j][i]))
                {
                    //countText.text = countText.text + "\n" + possibleItems[j][i];
                    for (int k = 0; k <= carParts.Length; k++)
                    {
                        if (carParts[k].sprite == null)
                        {
                            carParts[k].sprite = getSprite(possibleItems[j][i]);
                            //temp = carParts[k].transform.localScale;
                            //temp.x = carParts[k].sprite.rect.size.x / carParts[k].sprite.rect.size.y;
                            //carParts[k].transform.localScale = temp;
                            carParts[k].color = Color.white;
                            k = carParts.Length;
                        }
                    }
                }
                else
                {
                    //pickupText.text = pickupText.text + "\n" + possibleItems[j][i];
                    for(int k = 0; k <= usableItems.Length; k++)
                    {
                        if (usableItems[k].sprite == null)
                        {
                            usableItems[k].sprite = getSprite(possibleItems[j][i]);
                            //temp = usableItems[k].transform.localScale;
                            //temp.x = usableItems[k].sprite.rect.size.x / usableItems[k].sprite.rect.size.y;
                            //usableItems[k].transform.localScale = temp;
                            usableItems[k].color = Color.white;
                            k = usableItems.Length;
                        }
                    }
                }
                return;
            }
        }
    }

    public Sprite getSprite(String item)
    {
        if (item.CompareTo("Bat") == 0)
            return itemSprites[0];
        if (item.CompareTo("Knife") == 0)
            return itemSprites[1];
        if (item.CompareTo("Axe") == 0)
            return itemSprites[2];
        if (item.CompareTo("Gun") == 0)
            return itemSprites[3];
        if (item.CompareTo("Tire") == 0)
            return itemSprites[4];
        if (item.CompareTo("Gas") == 0)
            return itemSprites[5];
        if (item.CompareTo("Starter") == 0)
            return itemSprites[6];
        if (item.CompareTo("Battery") == 0)
            return itemSprites[7];
        if (item.CompareTo("Water") == 0)
            return itemSprites[8];
        if (item.CompareTo("Bandage") == 0)
            return itemSprites[9];
        if (item.CompareTo("Food") == 0)
            return itemSprites[10];
        if (item.CompareTo("Pills") == 0)
            return itemSprites[11];

        return null;
    }

    public int getItemImageindex(String item)
    {
        Sprite sprite = getSprite(item);
        
        for(int i = 0; i <= usableItems.Length; i++)
        {
            if (usableItems[i].sprite == sprite)
                return i;
        }
        return -1;
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
