using UnityEngine;

public class PlayerEquipmentHandler : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private SpriteRenderer face = null;
    [SerializeField] private SpriteRenderer hood = null;
    [SerializeField] private SpriteRenderer torso = null;
    [SerializeField] private SpriteRenderer pelvis = null;
    #endregion

    #region PRIVATE_METHODS
    
    #endregion

    #region PUBLIC_METHODS
    public void EquipItem(Item item)
    {
        switch (item.ItemType)
        {
            case ITEM_TYPE.FACE:
                face.sprite = item.Sprite;
                break;
            case ITEM_TYPE.HOOD:
                hood.sprite = item.Sprite;
                break;
            case ITEM_TYPE.TORSO:
                torso.sprite = item.Sprite;
                break;
            case ITEM_TYPE.PELVIS:
                pelvis.sprite = item.Sprite;
                break;
        }
    }

    public bool IsItemEquipped(Item item)
    {
        switch (item.ItemType)
        {
            case ITEM_TYPE.FACE:
                return face.sprite.name == item.Sprite.name;
            case ITEM_TYPE.HOOD:
                return hood.sprite == item.Sprite;
            case ITEM_TYPE.TORSO:
                return torso.sprite == item.Sprite;
            case ITEM_TYPE.PELVIS:
                return pelvis.sprite == item.Sprite;
        }
        return false;
    }
    #endregion
}