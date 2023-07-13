using System;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class ItemView : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private Button button = null;
    [SerializeField] private Image imgItem = null;
    [SerializeField] private Image imgPrice = null;
    [SerializeField] private TextMeshProUGUI txtPrice = null;
    #endregion

    #region PRIVATE_FIELDS
    private string id = string.Empty;
    #endregion

    #region PROPERTIES
    public string ID { get => id; }
    #endregion
    
    #region PUBLIC_METHODS
    public void Config(Item item)
    {
        imgItem.sprite = item.Sprite;
        txtPrice.text = item.Price.ToString();
        
        id = item.ID;
    }

    public void TogglePrice(bool status)
    {
        imgPrice.gameObject.SetActive(status);
        txtPrice.gameObject.SetActive(status);
    }

    public void SetCallback(Action<string> onPress)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener( () =>
        {
            onPress.Invoke(id);
        });
    }
    #endregion

    #region PRIVATE_METHODS

    #endregion
}