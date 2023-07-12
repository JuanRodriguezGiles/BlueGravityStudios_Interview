using System;

using UnityEngine;

using System.Collections.Generic;

public class PlayerInventoryController : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private InventoryUI inventoryUI = null;
    [SerializeField] private List<Item> startingItems = null;
    [SerializeField] private int startingGold = 1000;
    #endregion

    #region PRIVATE_FIELDS
    private List<Item> ownedItems = null;
    private int gold = 0;
    #endregion
    
    #region PROPERTIES
    public List<Item> OwnedItems { get => ownedItems; }
    public int Gold { get => gold; }
    #endregion
    
    #region PUBLIC_METHODS
    public void Init(Action<string> onSellItem)
    {
        gold = startingGold;
        ownedItems = new List<Item>();
        ownedItems.AddRange(startingItems);

        inventoryUI.Init(ownedItems, onSellItem, EquipItem);
    }

    public void ToggleInventory(bool status, bool onShop)
    {
        inventoryUI.ToggleView(status, onShop);
    }
    
    public void AddItem(Item item)
    {
        ownedItems.Add(item);
        inventoryUI.ToggleItem(item, true);
    }

    public void RemoveItem(Item item)
    {
        ownedItems.Remove(item);
        inventoryUI.ToggleItem(item, false);
    }

    public void AddGold(int goldToAdd)
    {
        gold += goldToAdd;
    }
    
    public void RemoveGold(int goldToRemove)
    {
        gold -= goldToRemove;
    }

    public void EquipItem(string itemId)
    {
        
    }
    #endregion
}