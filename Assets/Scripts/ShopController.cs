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
    private ShopkeeperController shopkeeperController = null;
    #endregion

    #region UNITY_CALLS
    #endregion

    #region PUBLIC_METHODS
    public void Init(PlayerInventoryController playerInventoryController, ShopkeeperController shopkeeperController)
    {
        this.playerInventoryController = playerInventoryController;
        this.shopkeeperController = shopkeeperController;
        
        this.playerInventoryController.Init(BuyBackItem);
        
        shopUI.Init(shopItems, SellItem, () =>
        {
            ToggleShop(false);
        });
       
        this.shopkeeperController.Init(ToggleShop);
    }
    #endregion

    #region PRIVATE_METHODS
    private void ToggleShop(bool status)
    {
        shopUI.ToggleView(status);
        playerInventoryController.ToggleInventory(status, status);
    }

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

        if (playerInventoryController.IsItemEquipped(item))
        {
            Debug.Log("Cant sell equipped items");
        }
        else
        {
            playerInventoryController.AddGold(item.Price);
            playerInventoryController.RemoveItem(item);
            shopUI.ToggleItem(item, true);
            shopItems.Add(item);
        }
    }
    #endregion
}