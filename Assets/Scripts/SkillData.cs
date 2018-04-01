using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SkillType
{
    Physical,
    Fire,
    Ice,
    Heal,
    Buff
}

public class SkillData : ScriptableObject
{
    public SkillType skillType;
    public Sprite skilImage;
    public GameObject skillEffect;
    public string skillName;
    public float skillCost;
    public float baseDamage;
    public float damageMultiplier;
    public bool dealDamage;
    public int buffLength;
}
