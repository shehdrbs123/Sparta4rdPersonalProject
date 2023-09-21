using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField] private Image ItemImage;
    public ItemData itemData;
    public event Action OnChangeItemData;
    
    
}
