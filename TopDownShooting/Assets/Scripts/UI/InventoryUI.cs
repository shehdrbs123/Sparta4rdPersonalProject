using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : BaseUI
{
    [SerializeField]private Transform grid;
    private ItemSlotUI[] slots;
    private Inventory _inventory;
    
    public void UpdateItems()
    {
        for (int i = 0; i < slots.Length; ++i)
        {
            slots[i].ItemData = _inventory.Get(i);
            slots[i].ItemCount = _inventory.GetItemCount(i);
        }
    }

    private void Start()
    {
        GameObject player = GameManager.Instance.GetPlayer();
        _inventory = player.GetComponent<Inventory>();
        _inventory.OnItemChanged += UpdateItems;
        slots = new ItemSlotUI[_inventory.InventorySize];
        for (int i = 0; i < slots.Length; i++)
        {
            GameObject obj = _uiManager.GetUI("ItemSlotUI");
            slots[i] = obj.GetComponent<ItemSlotUI>();
            obj.transform.SetParent(grid,false);
        }
        UpdateItems();
    }
}
