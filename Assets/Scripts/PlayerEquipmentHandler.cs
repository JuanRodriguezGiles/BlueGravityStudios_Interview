using UnityEngine;

public class PlayerEquipmentHandler : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private SpriteRenderer face = null;
    [SerializeField] private SpriteRenderer hood = null;
    [SerializeField] private SpriteRenderer torso = null;
    [SerializeField] private SpriteRenderer pelvis = null;
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
    #endregion
}