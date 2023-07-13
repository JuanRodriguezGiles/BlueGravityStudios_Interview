using System;

using UnityEngine;

public class ShopkeeperController : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private ShopkeeperUI shopkeeperUI = null;
    #endregion

    #region PRIVATE_FIELDS
    #endregion
    
    #region UNITY_CALLS
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            shopkeeperUI.ToggleBtn(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            shopkeeperUI.ToggleBtn(false);
        }
    }
    #endregion

    #region PUBLIC_METHODS
    public void Init(Action<bool> onOpenShop)
    {
        shopkeeperUI.SetBtnCallback((() =>
        {
           onOpenShop.Invoke(true);
        }));
    }
    #endregion
}