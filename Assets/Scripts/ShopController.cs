using System.Collections.Generic;

using UnityEngine;

public class ShopController : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private List<Item> shopItems = null;
    [SerializeField] private ShopUI shopUI = null;
    #endregion

    #region PRIVATE_FIELDS
    private PlayerInventoryController playerInventoryController = null;
    #endregion
    
    #region UNITY_CALLS
   
    #endregion

    #region PUBLIC_METHODS
    public void Init(PlayerInventoryController playerInventoryController)
    {
        this.playerInventoryController = playerInventoryController;
        shopUI.Init(shopItems, SellItem);
        this.playerInventoryController.Init(BuyBackItem);
    }

    public void ToggleShop(bool status)
    {
        shopUI.ToggleView(status);
    }
    #endregion
    
    #region PRIVATE_METHODS
    private void SellItem(string itemId)
    {
        Item item = shopItems.Find(i => i.ID == itemId);
        
        if (item.Price > playerInventoryController.Gold) return;
        
        playerInventoryController.RemoveGold(item.Price);
        playerInventoryController.AddItem(item);
        shopUI.ToggleItem(item, false);
        shopItems.Remove(item);
    }

    private void BuyBackItem(string itemId)
    {
        Item item = playerInventoryController.OwnedItems.Find(i => i.ID == itemId);

        playerInventoryController.AddGold(item.Price);
        playerInventoryController.RemoveItem(item);
        shopUI.ToggleItem(item, true);
        shopItems.Add(item);
    }
    #endregion
}