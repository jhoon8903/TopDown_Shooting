using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum StatsChangeType
{
    Add,
    Multiple,
    Override
}
[Serializable]
public class CharacterStat
{
    public StatsChangeType statsChangeType;
    [Range(1,100)] public int maxHealth;
    [Range(1, 20f)] public float speed;

    // Attack Data
    public AttackScriptableObject attackSo;

}
