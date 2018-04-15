using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    OffHand,
    Helmet,
    BodyArmor,
    LowerArmor
}

public enum Rarity
{
    Common,
    Rare,
    Unique,
    Legendary
}

public abstract class ItemData : ScriptableObject
{
    public ItemType type;
    public Sprite icon;
    public Rarity rarity;
    public float rarityMultiplier;
    public float baseLevel;
    public float levelRandom;
	public float level;
    public float levelMultiplier;

    public abstract void RecalculateStats();

}
