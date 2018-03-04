using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerStats : ScriptableObject {

    public float health;
    public float strength;
    public float speed;
    public List<SkillData> skills;
}
