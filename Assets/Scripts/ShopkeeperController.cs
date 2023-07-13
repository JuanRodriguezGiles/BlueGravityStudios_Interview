using System;

using UnityEngine;

public class ShopkeeperController : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private ShopkeeperUI shopkeeperUI = null;
    #endregion

    #region PRIVATE_FIELDS
    private Action<bool> onOpenShop = null;
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
            onOpenShop.Invoke(false);
        }
    }
    #endregion

    #region PUBLIC_METHODS
    public void Init(Action<bool> onOpenShop)
    {
        this.onOpenShop = onOpenShop;
        shopkeeperUI.SetBtnCallback((() =>
        {
           onOpenShop.Invoke(true);
        }));
    }
    #endregion
}