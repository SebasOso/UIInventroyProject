using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName = ("Inventory/Item"))]
    public class InventoryItem : ScriptableObject   
    {
        [SerializeField] private Type type; 
        [Tooltip("The UI icon to represent this item in the inventory.")]
        [SerializeField] Sprite icon = null;
        public Sprite GetIcon()
        {
            return icon;
        }
        public Type GetItemType()
        {
            return type;
        }
        public void Use()
        {
            switch (type)
            {
                case Type.Weapon:
                Debug.Log("Weapon Equipped");
                break;

                case Type.Armor:
                Debug.Log("Armor Equipped");
                break;

                case Type.Potion:
                Debug.Log("Potion Drinked");
                break;
                default:
                Debug.Log("Not Type Recognized");
                break;
            }
        }
    }
}
