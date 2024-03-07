using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Inventory;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private InventoryItem[] potionsSlots;
    [SerializeField] private InventoryItem[] weaponsSlots;
    [SerializeField] private InventoryItem[] armorsSlots;
    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public int GetPotionsSize()
    {
        return potionsSlots.Length;
    }
    public int GetArmorsSize()
    {
        return armorsSlots.Length;
    }
    public int GetWeaponsSize()
    {
        return weaponsSlots.Length;
    }
    public static MenuManager GetPlayerInventory()
    {
        var player = GameObject.FindWithTag("Player");
        return player.GetComponent<MenuManager>();
    }
    public InventoryItem GetItemInPotionsSlot(int slot)
    {
        return potionsSlots[slot];
    }
    public InventoryItem GetItemInArmorsSlot(int slot)
    {
        return armorsSlots[slot];
    }
    public InventoryItem GetItemInWeaponsSlot(int slot)
    {
        return weaponsSlots[slot];
    }
    public void AddItemToPotionsSlot(int index, InventoryItem item)
    {
        potionsSlots[index] = item;
    }
    public void AddItemToWeaponsSlot(int index, InventoryItem item)
    {
        weaponsSlots[index] = item;
    }
    public void AddItemToArmorsSlot(int index, InventoryItem item)
    {
        armorsSlots[index] = item;
    }
    public void DeleteItemFromPotionsSlot(int index)
    {
        potionsSlots[index] = null;
    }
    public void DeleteItemFromWeaponsSlot(int index)
    {
        weaponsSlots[index] = null;
    }
    public void DeleteItemFromArmorsSlot(int index)
    {
        armorsSlots[index] = null;
    }
}
