
using UnityEngine;
using UnityEngine.UI;


public enum ItemType
{
    Resource=0,
    Equipable,
    Consumable,
}
public class ItemData : ScriptableObject
{
    public Image ItemSprite;
    public ItemType ItemType;
    public CharacterStat[] ApplyStat;
    public float[] ApplyDuration;
    public GameObject ItemObject;
}
