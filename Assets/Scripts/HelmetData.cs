﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetData : ItemData
{

    public float armor;
    public float currentArmor;
    public override void RecalculateStats()
    {
        currentArmor = Mathf.RoundToInt(armor * (level * levelMultiplier) + (((int)rarity + 1) * rarityMultiplier));
    }
}
