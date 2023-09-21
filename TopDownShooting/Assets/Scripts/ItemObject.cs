using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private ItemData _itemData;

    private BoxCollider2D _collider2D;
    private SpriteRenderer _renderer;
    
    public ItemData ItemData
    {
        get
        {
            return _itemData;
        }
        set
        {
            _itemData = value;
            Init();
        }
    }

    private void Awake()
    {
        _collider2D = GetComponent<BoxCollider2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        if (_itemData == null)
            return;

        _renderer.sprite = _itemData.ItemSprite;
    }
}
