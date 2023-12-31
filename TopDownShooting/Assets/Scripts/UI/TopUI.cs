using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopUI : BaseUI
{
    
    [SerializeField] private Button ChangeName;
    [SerializeField] private Button ChangeCharacter;
    [SerializeField] private Button StatusUI;
    [SerializeField] private Button InventoryUI;

    private GameObject _nameUI;
    private GameObject _ChangeCharUI;
    protected override void Awake()
    {
        base.Awake();
        ChangeName.onClick.AddListener(OnClickChangeName);
        ChangeCharacter.onClick.AddListener(OnClickChangeCharacter);
        StatusUI.onClick.AddListener(OnClickShowStatusUI);
        InventoryUI.onClick.AddListener(OnClickShowInventoryUI);
    }

    private void Start()
    {
        _uiManager = GameManager.Instance.UIManager;
        _nameUI = _uiManager.GetUI("NameUI");
        _nameUI.SetActive(false);
        _ChangeCharUI = _uiManager.GetUI("ChangeCharacterUI");
        _ChangeCharUI.SetActive(false);
    }
    
    public void OnClickChangeName()
    {
        _nameUI.SetActive(!_nameUI.activeSelf);
    }

    public void OnClickChangeCharacter()
    {
        _ChangeCharUI.SetActive(!_ChangeCharUI.activeSelf);
    }

    public void OnClickShowStatusUI()
    {
        GameObject obj = _uiManager.GetUI("StatusUI");
        obj.SetActive(true);
    }
    
    private void OnClickShowInventoryUI()
    {
        GameObject obj = _uiManager.GetUI("InventoryUI");
        obj.SetActive(true);
    }
}
