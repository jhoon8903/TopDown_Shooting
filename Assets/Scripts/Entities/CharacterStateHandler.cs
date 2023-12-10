using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    [SerializeField] private CharacterStat baseStats;
    public CharacterStat CurrentStates { get; private set; }
    public List<CharacterStat> statsModifiers = new List<CharacterStat>();

    private void Awake()
    {
        UpdateCharacterStats();
    }

    private void UpdateCharacterStats()
    {
        AttackScriptableObject attackSo = null;
        if (baseStats.attackSo != null)
        {
            attackSo = Instantiate(baseStats.attackSo);
        }
        CurrentStates = new CharacterStat
        {
            attackSo = attackSo,
            statsChangeType = baseStats.statsChangeType,
            maxHealth = baseStats.maxHealth,
            speed = baseStats.speed
        };
    }
}
