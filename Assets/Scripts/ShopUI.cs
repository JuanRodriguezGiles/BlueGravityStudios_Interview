using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private Transform scrollViewHolder = null;
    [SerializeField] private Transform contentHolder = null;
    [SerializeField] private GameObject itemViewPrefab = null;
    [SerializeField] private Button btnClose = null;
    #endregion

    #region PRIVATE_FIELDS
    private List<ItemView> itemViews = null;
    private Action<string> onBuyItem = null;
    #endregion
    
    #region PROPERTIES
    #endregion
    
    #region PUBLIC_METHODS
    public void Init(List<Item> shopItems, Action<string> onBuyItem, Action onBtnClosePress)
    {
        itemViews = new List<ItemView>();
        this.onBuyItem = onBuyItem;
        SpawnItems(shopItems);
        btnClose.onClick.AddListener(onBtnClosePress.Invoke);
    }
    
    public void ToggleView(bool status)
    {
        scrollViewHolder.gameObject.SetActive(status);
    }
    
    public void SpawnItems(List<Item> shopItems)
    {
        for (int i = 0; i < shopItems.Count; i++)
        {
            GameObject go = Instantiate(itemViewPrefab, contentHolder);
            ItemView itemView = go.GetComponent<ItemView>();

            itemView.Config(shopItems[i]);
            itemView.SetCallback(onBuyItem);
            itemViews.Add(itemView);
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
    }
    #endregion
}