using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemActionUI : BaseUI
{
    [SerializeField] private Button SubmitButton;
    [SerializeField] private Button CancelButton;

    [SerializeField] private Sprite HealthIamge;
    [SerializeField] private Sprite StaminaImage;
    [SerializeField] private Sprite AttackIamge;
    [SerializeField] private Sprite DefenseIamge;
    [SerializeField] private Sprite SpeedIamge;
    [SerializeField] private Sprite CriticalImage;
    
    private Image itemSprite;
    private ItemData item;

    private StatInfoUI[] _statInfoUis;
    private void Awake()
    {
        SubmitButton.onClick.AddListener(OnSubmit);
        CancelButton.onClick.AddListener(OnCancel);
        _statInfoUis = new StatInfoUI[Enum.GetNames(typeof(ItemType)).Length];

        for (int i = 0; i < _statInfoUis.Length; ++i)
        {
            GameObject ui = _uiManager.GetUI("StatInfoUI");
            _statInfoUis[i] = ui.GetComponent<StatInfoUI>();
        }
    }

    public void ShowActionUI(ItemData data)
    {
        item = data;
        OnUpdate();
        gameObject.SetActive(true);
    }

    private void OnUpdate()
    {
        itemSprite.sprite = item.ItemSprite;
        InfoView();
    }

    private void InfoView()
    {
        var itemStats = item.ApplyStat;
        
        Array.ForEach(_statInfoUis, (x) =>
        {
            x.StatImage.sprite = null;
            x.StatImage.color = new Color(0, 0, 0, 0);
            x.StatText.text = String.Empty;
        });
        for(int i=0;i<itemStats.Length;++i)
        {
            _statInfoUis[i].StatImage.sprite = GetImageFromType(itemStats[0].stats[i].StatType);
            _statInfoUis[i].StatImage.color = new Color(0, 0, 0, 1);
            _statInfoUis[i].StatText.text = itemStats[0].stats[i].CurrentValue.ToString();
        }
    }

    private Sprite GetImageFromType(StatType type)
    {
        Sprite result = null;
        switch (type)
        {
            case StatType.Health :
                result = HealthIamge;
                break;
            case StatType.Stamina :
                result = StaminaImage;
                break;
            case StatType.Attack :
                result = AttackIamge;
                break;
            case StatType.Defense :
                result = DefenseIamge;
                break;
            case StatType.Speed :
                result = SpeedIamge;
                break;
            case StatType.Critical :
                result = CriticalImage;
                break;
        }

        return result;
    }

    private void OnSubmit()
    {
        
    }

    private void OnCancel()
    {

    }
}
