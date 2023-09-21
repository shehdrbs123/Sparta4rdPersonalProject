using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private ItemSlotUI[] slots;

    private void Awake()
    {
        slots = GetComponentsInChildren<ItemSlotUI>();
    }
}
