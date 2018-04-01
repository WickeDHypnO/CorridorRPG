using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public struct Equipped
{
    public HelmetData helmet;
    public WeaponData weapon;
    public OffHandData offHand;
    public BodyArmorData bodyArmor;
    public LowerArmorData lowerArmor;
}
public class PlayerStats : ScriptableObject
{
    public int level;
    public float experience;
    public float experienceNeeded;
    public float health;
    public float mana;
    public float manaRegenPerTurn;
    public float strength;
    public float speed;
    public List<SkillData> skills;
    public List<ItemData> inventory;
    public Equipped equipped;

    public void CalculateExpForNextLevel()
    {
        experienceNeeded = Mathf.RoundToInt((4* Mathf.Pow((level+1),3)) / 5);
    }
}
