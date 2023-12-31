using System;using System.Collections;
using System.Collections.Generic;
using Practice.Scripts;
using Practice.Scripts.Managers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public OnlineUserManager onlineUserManager { get; private set; }
    public UIManager UIManager { get; private set; }
    
    public ItemManager ItemManager { get; private set; }
    private static GameManager _instance = null;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("GameManager").GetComponent<GameManager>();
                if (_instance == null)
                {
                    GameObject obj =new GameObject("GameManager");
                    _instance = obj.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }

    private void Awake()
    {
        onlineUserManager = GetComponent<OnlineUserManager>();
        UIManager = GetComponent<UIManager>();
        ItemManager = GetComponent<ItemManager>();
    }

    private void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public MonoBehaviour GetGameData(string nameid)
    {
        return onlineUserManager.Get(nameid);
    }

    public GameObject GetPlayer()
    {
        return onlineUserManager.Player;
    }

}
