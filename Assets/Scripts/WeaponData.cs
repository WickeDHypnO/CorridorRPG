using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : ItemData
{

    public float damage;
    public float damageRandom;
    public float currentDamage;
    public override void RecalculateStats()
    {
        currentDamage = Mathf.RoundToInt(damage * (level * levelMultiplier) + (((int)rarity + 1) * rarityMultiplier));
    }
}
