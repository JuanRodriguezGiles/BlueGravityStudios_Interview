using UnityEngine;

[CreateAssetMenu(fileName = "item_", menuName = "Game/Item")]
public class Item : ScriptableObject
{
    #region EXPOSED_FIELDS
    [SerializeField] protected string id = string.Empty;
    [SerializeField] protected ITEM_TYPE itemType = default;
    [SerializeField] protected int price = 100;
    [SerializeField] protected Sprite sprite = null;
    #endregion

    #region PROPERTIES
    public string ID { get => id; }
    public ITEM_TYPE ItemType { get => itemType; }
    public int Price { get => price; }
    public Sprite Sprite { get => sprite; }
    #endregion
}