using System;

using UnityEngine;
using UnityEngine.UI;

public class HudUI : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private Button btnInventory;
    [SerializeField] private NumberLerper txtGold;
    #endregion

    #region PUBLIC_METHODS
    public void Init(Action onPress, int gold)
    {
        btnInventory.onClick.AddListener(onPress.Invoke);
        UpdateGold(gold);
    }

    public void ToggleInventoryBtn(bool onShop)
    {
        btnInventory.interactable = !onShop;
    }

    public void UpdateGold(int newValue)
    {
        txtGold.LerpNumber(newValue);
    }
    #endregion
}
