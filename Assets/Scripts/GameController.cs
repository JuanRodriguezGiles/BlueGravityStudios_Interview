using UnityEngine;

public class GameController : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private ShopController shopController = null;
    [SerializeField] private PlayerInventoryController playerInventoryController = null;
    #endregion

    #region UNITY_CALLS
    void Start()
    {
        shopController.Init(playerInventoryController);

        shopController.ToggleShop(true);
        //playerInventoryController.ToggleInventory(true);
    }
    #endregion

    #region PRIVATE_METHODS
   
    #endregion
}