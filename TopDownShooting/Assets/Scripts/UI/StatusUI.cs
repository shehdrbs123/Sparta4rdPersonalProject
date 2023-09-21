using System;
using System.Collections;
using System.Collections.Generic;
using Practice.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StatusUI : BaseUI
{
    [SerializeField] private Image characterImage;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _staminaText;
    [SerializeField] private TMP_Text _AttackText;
    [SerializeField] private TMP_Text _DefenseText;
    [SerializeField] private TMP_Text _speedText;
    [SerializeField] private TMP_Text _CiritlcalText;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        GameObject player = GameManager.Instance.GetPlayer();
        Player playerInstance = player.GetComponent<Player>();
        CharacterStatsHandler stat = player.GetComponent<CharacterStatsHandler>();
        CharacterStat health = stat.GetStat(StatType.Health);
        CharacterStat stamina = stat.GetStat(StatType.Stamina);
        CharacterStat Attack = stat.GetStat(StatType.Attack);
        CharacterStat Defense = stat.GetStat(StatType.Defense);
        CharacterStat speed = stat.GetStat(StatType.Speed);
        CharacterStat Critical = stat.GetStat(StatType.Critical);
        
        _name.text = playerInstance.GetName();
        characterImage.sprite = playerInstance.MainSprite;
        _healthText.text = health.CurrentValue.ToString() + "/" + health.MaxValue.ToString();
        _staminaText.text = stamina.CurrentValue.ToString() + "/" + stamina.MaxValue.ToString();
        _AttackText.text = Attack.CurrentValue.ToString();
        _DefenseText.text = Defense.CurrentValue.ToString();
        _speedText.text = speed.CurrentValue.ToString();
        _CiritlcalText.text = Critical.CurrentValue.ToString();
        
        
        playerInstance.OnNameChanged += () => { _name.text = playerInstance.GetName(); };
        playerInstance.OnJopChanged += () => { characterImage.sprite = playerInstance.MainSprite; };
        
        health.OnStatChanged += () =>
        {
            _healthText.text = health.CurrentValue.ToString() + "/" + health.MaxValue.ToString();
        };
        
        stamina.OnStatChanged += () =>
        {
            _staminaText.text = stamina.CurrentValue.ToString() + "/" + stamina.MaxValue.ToString();
        };
        
        Attack.OnStatChanged += () =>
        {
            _AttackText.text = Attack.CurrentValue.ToString();
        };
        
        Defense.OnStatChanged += () =>
        {
            _DefenseText.text = Defense.CurrentValue.ToString();
        };
        
        speed.OnStatChanged += () =>
        {
            _speedText.text = speed.CurrentValue.ToString();
        };

        Critical.OnStatChanged += () =>
        {
            _CiritlcalText.text = Critical.CurrentValue.ToString();
        };
    }
}
