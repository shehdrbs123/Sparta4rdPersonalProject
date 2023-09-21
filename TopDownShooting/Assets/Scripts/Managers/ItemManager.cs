using System.Collections;
using System.Collections.Generic;
using Practice.Scripts.Common;
using Practice.Scripts.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemManager : MonoBehaviour
{
    private GameObjectPool pool;
    
    private void Awake()
    {
        pool = new GameObjectPool();
        var Prefab = ClassGetter.GetResourcePrefab<GameObject>("Prefabs/Item");
        pool.Init(Prefab);
    }

    public GameObject GetItem(string name)
    {
        GameObject obj;
        obj = pool.Get(name);
        return obj;
    }
}
