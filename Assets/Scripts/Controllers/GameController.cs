using UnityEngine;

public class GameController : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private ShopController shopController = null;
    [SerializeField] private PlayerInventoryController playerInventoryController = null;
    [SerializeField] private ShopkeeperController shopkeeperController = null;
    #endregion

    #region UNITY_CALLS
    void Start()
    {
        shopController.Init(playerInventoryController, shopkeeperController);
    }
    #endregion

    #region PRIVATE_METHODS
   
    #endregion
}