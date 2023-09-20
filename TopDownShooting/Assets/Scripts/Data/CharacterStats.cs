using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsChangeType
{
    Add,
    Multiple,
    Override,
}

[Serializable]
public class CharacterStats
{
    public StatsChangeType statsChangeType;
    public CharacterStat[] stats;
    public AttackSO attackSO;

    private Dictionary<Enum, CharacterStat> dicStats;
    
    public CharacterStat GetStat(StatType type)
    {
        if (dicStats == null)
            Init();
        
        CharacterStat stat = null;
        if (!dicStats.TryGetValue(type, out stat))
        {
            Debug.Log($"{type.ToString()}은 이 캐릭터에 없습니다");
        }
        
        return stat;
    }

    private void Init()
    {
        dicStats = new Dictionary<Enum, CharacterStat>();
        for (int i = 0; i < stats.Length; ++i)
        {
            dicStats.Add(stats[i].StatType,stats[i]);
        }
    }
}

public enum StatType{
    Health=0, Stamina, Attack, Defense,Critical,Speed
}


[Serializable]
public class CharacterStat
{
    public StatType StatType;
    public float CurrentValue {
        get
        {
            return _currentValue;
        }
        set
        {
            _currentValue = value;
            OnStatChanged?.Invoke();
        }
    }
    public float startValue;
    public float MaxValue
    {
        get
        {
            return _maxValue;
        }
        set
        {
            _maxValue = value;
            OnStatChanged?.Invoke();
        }
    }

    [SerializeField]private float _currentValue;
    [SerializeField]private float _maxValue;
    public event Action OnStatChanged;
}
