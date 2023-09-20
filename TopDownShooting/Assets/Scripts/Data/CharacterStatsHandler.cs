using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField] private CharacterStats baseStats;
    public CharacterStats CurrentStates { get; private set; }
    public List<CharacterStats> statsModifiers = new List<CharacterStats>();

    private void Awake()
    {
        InitCharacterStats();
    }

    public CharacterStat GetStat(StatType type)
    {
        return CurrentStates.GetStat(type);
    }

    private void InitCharacterStats()
    {
        AttackSO attackSO = null;
        if (baseStats.attackSO != null)
            attackSO = Instantiate(baseStats.attackSO);

        CurrentStates = new CharacterStats { attackSO = attackSO };// 이니셜라이져 통해서 변수를 직접 선택해줄 수 있구만
        CurrentStates.statsChangeType = baseStats.statsChangeType;
        CurrentStates.stats = baseStats.stats.ToArray();
        foreach (var stat in CurrentStates.stats)
        {
            stat.CurrentValue = stat.startValue;
        }
    }

    private void UpdateCharacterStats()
    {
        
    }
}
