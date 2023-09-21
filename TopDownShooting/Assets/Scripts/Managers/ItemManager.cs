using System.Collections;
using System.Collections.Generic;
using System.IO;
using Practice.Scripts.Common;
using Practice.Scripts.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemManager : MonoBehaviour
{
    private GameObjectPool pool;
    private Dictionary<string, ItemData> dicItemData;
    private void Awake()
    {
        pool = new GameObjectPool();
        var Prefab = ClassGetter.GetResourcePrefab<GameObject>(Path.Combine("Prefabs","Item"));
        pool.Init(Prefab);
        dicItemData = ClassGetter.GetResourcePrefabs<ItemData>(Path.Combine("ScriptableObject","Data","Item"));
    }

    public GameObject GetItemObject()
    {
        GameObject obj;
        obj = pool.Get("Item");
        return obj;
    }

    public GameObject GetItem(string itemDataName)
    {
        GameObject obj;
        obj = pool.Get("Item");
        if (dicItemData.TryGetValue(itemDataName, out ItemData value))
        {
            ItemObject itemObj = obj.GetComponent<ItemObject>();
            itemObj.ItemData = value;
        }
        else
        {
            Debug.Log($"{itemDataName}은 Scriptable에 등록되지 않았습니다");
        }

        return obj;
    }
}
