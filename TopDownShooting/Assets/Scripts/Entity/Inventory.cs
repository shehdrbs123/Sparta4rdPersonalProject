using System;
using UnityEditor;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform throwPos;
    public int InventorySize;
    
    public ItemData[] ItemList;
    public int[] ItemCount;
    
    private ItemData EmptyData;
    public event Action OnItemChanged;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        ItemManager manager = GameManager.Instance.ItemManager;
        ItemList = new ItemData[InventorySize];
        ItemCount = new int[InventorySize];
        for (int i = 0; i < ItemList.Length; ++i)
        {
            ItemList[i] = manager.GetItemData(ItemData.EmptySlotName);
            ItemCount[i] = 0;
        }

        // for (int i = 0; i < ItemList.Length; i++)
        // {
        //     ItemList[i] = manager.GetItemData("RedPotion");
        //     ItemCount[i] = 1;    
        // }

        EmptyData = manager.GetItemData(ItemData.EmptySlotName);
    }

    public void Add(ItemData addItem)
    {
        int selectedidx = -1;

        if (addItem.isCanStack)
        {
            selectedidx = FindStackIdx(addItem);
        }
       
        if (selectedidx < 0)
        {
            selectedidx = FindEmptyIdx();
        }
        
        if (selectedidx >= 0)
        {
            ItemList[selectedidx] = addItem;
            ItemCount[selectedidx] += 1;
            OnItemChanged?.Invoke();
        }
        else
        {
            ThrowItem(addItem);    
        }
    }

    private int FindStackIdx(ItemData itemData)
    {
        int selectedidx = -1;
        for (int i = 0; i < ItemList.Length; ++i)
        {
            if (ItemList[i].ItemName == itemData.ItemName && ItemCount[i] < itemData.MaxStackCount && selectedidx < 0) 
            {
                selectedidx = i;
                break;
            }
        }

        return selectedidx;
    }

    private int FindEmptyIdx()
    {
        int selectedidx = -1;
        for (int i = 0; i < ItemList.Length; ++i)
        {
            if (ItemList[i].ItemName == ItemData.EmptySlotName) 
            {
                selectedidx = i;
                break;
            }
        }
        return selectedidx;
    }
    
    public ItemData Get(int index)
    {
        return ItemList[index];
    }

    public int GetItemCount(int index)
    {
        return ItemCount[index];
    }

    public void Remove(int index, int count)
    {
        int result = ItemCount[index] - 1;
        ItemData throwItem = ItemList[index];
        if (result <= 0)
        {
            ItemList[index] = EmptyData;
            ItemCount[index] = 0;
        }
        else
        {
            --ItemCount[index];
        }
        ThrowItem(throwItem);
    }

    private void ThrowItem(ItemData throwItem)
    {
        GameObject obj = GameManager.Instance.ItemManager.GetItemObject();
        obj.GetComponent<ItemObject>().ItemData = throwItem;
        obj.transform.position = throwPos.position;
        obj.transform.rotation = throwPos.rotation;
        obj.SetActive(true);
        
    }
    
    // 2d 타워디펜스 :
    // 2d 로그라이크 : 건전
    // 3d 퍼즐 플랫폼 : 포탈 더 위트니스
    // 3d 생존게임 : 발헤임 자원수집, 생존을 위해서 적과 
    
}
