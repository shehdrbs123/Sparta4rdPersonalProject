using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField] private Image ItemImage;
    [SerializeField] private Image ItemCountTextBG;
    [SerializeField] private TMP_Text ItemCountText;
    
    private int _itemCount;
    private ItemData _itemData;
    private readonly Color alphaMin = new Color(0, 0, 0, 0.5f);
    private readonly Color alphaMax = new Color(1, 1, 1, 1);
    public int ItemCount
    {
        get
        {
            return _itemCount;
        }
        set
        {
            _itemCount = value;
            UpdateCount();
        }
    }
    
    public ItemData ItemData
    {
        get
        {
            return _itemData;
        }
        set
        {
            _itemData = value;
            UpdateData();
        }
    }

    private void UpdateCount()
    {
        if (_itemData.isCanStack)
        {
            ItemCountTextBG.enabled = true;
            ItemCountText.text = _itemCount.ToString();   
        }
        else
        {
            ItemCountTextBG.enabled = false;
            ItemCountText.text = String.Empty;
        }
    }

    

    private void UpdateData()
    {
        if (ItemData.ItemName == "EMPTY")
            ItemImage.color = alphaMin;
        else
        {
            ItemImage.color = alphaMax;   
        }
        ItemImage.sprite = ItemData.ItemSprite;
        
    }
}
