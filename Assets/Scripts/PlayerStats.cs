using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerStats : ScriptableObject
{
    public int level;
    public float health;
    public float mana;
    public float manaRegenPerTurn;
    public float strength;
    public float speed;
    public List<SkillData> skills;
}
