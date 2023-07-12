using System;
using System.Collections.Generic;

using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private Transform scrollViewHolder = null;
    [SerializeField] private Transform contentHolder = null;
    [SerializeField] private GameObject itemViewPrefab = null;
    #endregion

    #region PRIVATE_FIELDS
    private bool onShop = false;
    private List<ItemView> itemViews = null;
    private Action<string> onSellItem = null;
    private Action<string> onEquipItem = null;
    #endregion
    
    #region PROPERTIES
    #endregion
    
    #region PUBLIC_METHODS
    public void Init(List<Item> ownedItems, Action<string> onSellItem, Action<string> onEquipItem)
    {
        this.onSellItem = onSellItem;
        this.onEquipItem = onEquipItem;
        
        itemViews = new List<ItemView>();
        SpawnItems(ownedItems);
    }
    
    public void ToggleView(bool status, bool onShop)
    {
        this.onShop = onShop;
        scrollViewHolder.gameObject.SetActive(status);

        if (!status) return;
        
        for (int i = 0; i < itemViews.Count; i++)
        {
            itemViews[i].TogglePrice(onShop);
            itemViews[i].SetCallback(onShop ? onSellItem : onEquipItem);
        }
    }
    
    public void ToggleItem(Item item, bool status)
    {
        for (int i = 0; i < itemViews.Count; i++)
        {
            if (itemViews[i].ID != item.ID) continue;
            
            itemViews[i].gameObject.SetActive(status);
            return;
        }

        SpawnItems(new List<Item> { item });
        itemViews[^1].TogglePrice(onShop);
        itemViews[^1].SetCallback(onShop ? onSellItem : onEquipItem);
    }
    #endregion

    #region PRIVATE_METHODS
    private void SpawnItems(List<Item> itemsToSpawn)
    {
        for (int i = 0; i < itemsToSpawn.Count; i++)
        {
            GameObject go = Instantiate(itemViewPrefab, contentHolder);
            ItemView itemView = go.GetComponent<ItemView>();

            itemView.Config(itemsToSpawn[i]);
            itemViews.Add(itemView);
        }
    }
    #endregion
}