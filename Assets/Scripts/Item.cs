using Inventory;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IDropHandler
{
    [Header("Item Settings")]
    [SerializeField] public InventoryItem item;
    [SerializeField] public Image itemSprite;
    [SerializeField] Sprite defaultSprite;
    [SerializeField] public Type itemType;
    [SerializeField] int index;
    public void SetItemToUse()
    {
        InventoryManager.Instance.itemToUse = this;
    }
    public void UseObject()
    {
        if(item == null){return;}
        item.Use();
        if(item.GetItemType() == Type.Armor)
        {
            DeleteArmorItemFromInventory();
        }
        if (item.GetItemType() == Type.Weapon)
        {
            DeleteWeaponItemFromInventory();
        }
        if (item.GetItemType() == Type.Potion)
        {
            DeletePotionItemFromInventory();
        }
    }
    public void SetWeapon(int index)
    {
        this.item = MenuManager.Instance.GetItemInWeaponsSlot(index);
        this.itemSprite.sprite = item?.GetIcon();
    }
    public void SetPotion(int index)
    {
        this.item = MenuManager.Instance.GetItemInPotionsSlot(index);
        this.itemSprite.sprite = item?.GetIcon();
    }
    public void SetArmor(int index)
    {
        this.item = MenuManager.Instance.GetItemInArmorsSlot(index);
        this.itemSprite.sprite = item?.GetIcon();
    }
    public void DeletePotionItemFromInventory()
    {
        this.item = null;
        this.itemSprite.sprite = defaultSprite;
        MenuManager.Instance.DeleteItemFromPotionsSlot(index);
    }
    public void DeleteWeaponItemFromInventory()
    {
        this.item = null;
        this.itemSprite.sprite = defaultSprite;
        MenuManager.Instance.DeleteItemFromWeaponsSlot(index);
    }
    public void DeleteArmorItemFromInventory()
    {
        this.item = null;
        this.itemSprite.sprite = defaultSprite;
        MenuManager.Instance.DeleteItemFromArmorsSlot(index);
    }
    //GETTERS
    public RectTransform GetIconTransform()
    {
        if(itemSprite != null)
        {
            return itemSprite.rectTransform;
        }
        else
        {
            return null;
        }
    }

    //EVENTS FOR THE DROP SYSTEM
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            Item itemToCheck = eventData.pointerDrag.GetComponent<DragAndDrop>().actualItem;
            if(itemToCheck.itemType != this.itemType) { return; }
            if(itemToCheck != null)
            {
                if(itemToCheck.itemType == Type.Armor)
                {
                    MenuManager.Instance.AddItemToArmorsSlot(itemToCheck.index, this.item);
                    MenuManager.Instance.AddItemToArmorsSlot(this.index, itemToCheck.item);
                    InventoryManager.Instance.RedrawArmors();
                }
                if (itemToCheck.itemType == Type.Weapon)
                {
                    MenuManager.Instance.AddItemToWeaponsSlot(itemToCheck.index, this.item);
                    MenuManager.Instance.AddItemToWeaponsSlot(this.index, itemToCheck.item);
                    InventoryManager.Instance.RedrawWeapons();
                }
                if (itemToCheck.itemType == Type.Potion)
                {
                    MenuManager.Instance.AddItemToPotionsSlot(itemToCheck.index, this.item);
                    MenuManager.Instance.AddItemToPotionsSlot(this.index, itemToCheck.item);
                    InventoryManager.Instance.RedrawPotions();
                }
            }
        }
        Debug.Log("Dropped Here...");
    }
}
