using System;
using System.Collections.Generic;

using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private InventoryUI inventoryUI = null;
    [SerializeField] private HudUI hudUI = null;
    [SerializeField] private PlayerEquipmentHandler playerEquipmentHandler = null;
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
        hudUI.Init(() =>
        {
            ToggleInventory(false);
        }, gold);
    }

    public void ToggleInventory(bool onShop)
    {
        inventoryUI.ToggleView(onShop);
        hudUI.ToggleInventoryBtn(onShop);
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
        hudUI.UpdateGold(gold);
    }
    
    public void RemoveGold(int goldToRemove)
    {
        gold -= goldToRemove;
        hudUI.UpdateGold(gold);
    }
    #endregion

    #region PRIVATE_METHODS
    private void EquipItem(string itemId)
    {
        Item item = ownedItems.Find(i => i.ID == itemId);
        playerEquipmentHandler.EquipItem(item);
    }
    #endregion
}