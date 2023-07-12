using System;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class HudUI : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private Button btnInventory;
    [SerializeField] private TextMeshProUGUI txtGold;
    #endregion

    #region PUBLIC_METHODS
    public void Init(Action onPress)
    {
        btnInventory.onClick.AddListener(onPress.Invoke);
    }

    public void ToggleInventoryBtn(bool onShop)
    {
        btnInventory.interactable = !onShop;
    }
    #endregion
}
