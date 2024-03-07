
using System.Collections;
using UnityEngine;
using Inventory;
using System;
using Unity.VisualScripting;
public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Item[] armorsInInventory;
    [SerializeField] private Item[] weaponsInInventory;
    [SerializeField] private Item[] potionsInInventory;
    public Item itemToUse = null;
    public MenuManager menuManager = null;
    public static InventoryManager Instance {get;  set;}
    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }    
    }
    private void Start() 
    {
        RedrawPotions();
        RedrawArmors();
        RedrawWeapons();
    }
    public void RedrawWeapons()
    {
        for (int i = 0; i < menuManager.GetWeaponsSize(); i++)
        {
            InventoryItem itemInSlot = menuManager.GetItemInWeaponsSlot(i);
            if (itemInSlot == null)
            {
                weaponsInInventory[i].DeleteWeaponItemFromInventory();
                continue;
            }
            weaponsInInventory[i].SetWeapon(i);
        }
    }
    public void RedrawPotions()
    {
        for (int i = 0; i < menuManager.GetPotionsSize(); i++)
        {
            InventoryItem itemInSlot = menuManager.GetItemInPotionsSlot(i);
            if (itemInSlot == null)
            {
                potionsInInventory[i].DeletePotionItemFromInventory();
                continue;
            }
            potionsInInventory[i].SetPotion(i);
        }
    }
    public void RedrawArmors()
    {
        for (int i = 0; i < menuManager.GetArmorsSize(); i++)
        {
            InventoryItem itemInSlot = menuManager.GetItemInArmorsSlot(i);
            if (itemInSlot == null)
            {
                armorsInInventory[i].DeleteArmorItemFromInventory();
                continue;
            }
            armorsInInventory[i].SetArmor(i);
        }
    }
    public void UseTheItem()
    {
        if (itemToUse == null) { return; }
        itemToUse?.UseObject();
    }
}