using System;

using UnityEngine;
using UnityEngine.UI;

public class ShopkeeperUI : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private Button shopBtn = null;
    #endregion

    #region PUBLIC_METHODS
    public void ToggleBtn(bool status)
    {
        shopBtn.gameObject.SetActive(status);
    }

    public void SetBtnCallback(Action onPress)
    {
        shopBtn.onClick.AddListener(onPress.Invoke);
    }
    #endregion
}