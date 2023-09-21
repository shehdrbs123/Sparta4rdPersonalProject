
using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;


public enum ItemType
{
    Resource=0,
    Equipable,
    Consumable,
}

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/Item",order=0)]
public class ItemData : ScriptableObject
{
    public string ItemName;
    public string ItemDescription;
    public Sprite ItemSprite;
    public ItemType ItemType;
    public CharacterStats[] ApplyStat;
    public Duration[] ApplyDuration;
}
[Serializable]
public class Duration
{
    public float StartTime;
    public float EndTime;
    public float DelayTime;
    public float RepeatTime;
}
