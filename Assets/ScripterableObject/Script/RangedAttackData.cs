using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ranged_Attack_Data", menuName = "TopDownController/Attacks/Ranged", order = 1)]
public class RangedAttackData : AttackScriptableObject
{
    [Header("Ranged Attack Data")] 
    public string bulletNameTag;

    public float duration;
    public float spread;
    public int numberOfProjectilesPerShot;
    public float multipleProjectileAngel;
    public Color projectileColor;
}
