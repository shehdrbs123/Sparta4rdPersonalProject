using System;
using System.Collections;
using System.Collections.Generic;
using Practice.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusUI : BaseUI
{
    [SerializeField] private Image MainImage;
    [SerializeField] private Image Healthbar;
    [SerializeField] private Image StaminaBar;
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text Money;

    private Player playerInstance;
    private CharacterStatsHandler playerStats;
    private void Start()
    {
        Invoke("Init",0.1f);
    }

    private void Init()
    {
        GameObject player = GameManager.Instance.GetPlayer();
        
        playerInstance = player.GetComponent<Player>();
        
        name.text = playerInstance.GetName();
        playerInstance.OnNameChanged += () => { name.text = playerInstance.GetName(); };
        
        Money.text = playerInstance.Money.ToString();
        playerInstance.OnMoneyChanged += () => { Money.text = playerInstance.Money.ToString();};
        
        MainImage.sprite = playerInstance.MainSprite;
        playerInstance.OnJopChanged += () => {  MainImage.sprite = playerInstance.MainSprite;};
        
        playerStats = player.GetComponent<CharacterStatsHandler>();
        
        CharacterStat health = playerStats.GetStat(StatType.Health);
        Healthbar.fillAmount = health.CurrentValue / health.MaxValue;
        health.OnStatChanged += () =>
        {
            Healthbar.fillAmount = health.CurrentValue / health.MaxValue;
        };
        
        CharacterStat stamina = playerStats.GetStat(StatType.Stamina);
        StaminaBar.fillAmount = stamina.CurrentValue / stamina.MaxValue;
        stamina.OnStatChanged += () =>
        {
            StaminaBar.fillAmount = stamina.CurrentValue / stamina.MaxValue;
        };
     
        
        // health.OnStatChanged?.Invoke();
        // stamina.OnStatChanged?.Invoke();
    }
}
