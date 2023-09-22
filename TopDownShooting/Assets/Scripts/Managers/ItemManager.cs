using System.Collections;
using System.Collections.Generic;
using System.IO;
using Practice.Scripts.Common;
using Practice.Scripts.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemManager : MonoBehaviour
{
    public string testItemName;
    private GameObjectPool pool;
    private Dictionary<string, ItemData> dicItemData;
    public static readonly string baseItemPrefab = "ItemObject"; 
    private void Awake()
    {
        dicItemData = ClassGetter.GetResourcePrefabs<ItemData>(Path.Combine("ScriptableObject","Data","Item"));
        var Prefab = ClassGetter.GetResourcePrefab<GameObject>(Path.Combine("Prefabs","ItemObject"));
        
        pool = new GameObjectPool();
        pool.Init(Prefab);
        
    }

    public GameObject GetItemObject()
    {
        GameObject obj;
        obj = pool.Get(baseItemPrefab);
        return obj;
    }

    public GameObject GetItem(string itemDataName)
    {
        GameObject obj;
        obj = pool.Get(baseItemPrefab);
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
#if UNITY_EDITOR
    public ItemData GetItemData(string itemDataName)
    {
        ItemData data=null;
        if (!dicItemData.TryGetValue(itemDataName, out data))
            Debug.Log($"{itemDataName}은 Scriptable에 등록되지 않았습니다");

        return Instantiate(data);
    }
#endif
     
}
