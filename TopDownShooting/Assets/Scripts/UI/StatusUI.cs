using System;
using System.Collections;
using System.Collections.Generic;
using Practice.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
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
        
        
        health.OnStatChanged += () =>
        {
            _healthText.text = health.CurrentValue.ToString() + "/" + health.MaxValue.ToString();
        };
        playerInstance.OnNameChanged += () => { _name.text = playerInstance.GetName(); };
        playerInstance.OnJopChanged += () => { characterImage.sprite = playerInstance.MainSprite; };
        
    }
}
