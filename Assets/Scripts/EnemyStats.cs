using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyStats : ScriptableObject {

    public float health;
    public float attack;
    public float speed;

    public int level;
    public float experienceGiven;

    public void CalculateExperienceGiven()
    {
        level = FindObjectOfType<GameManager>().playerGameData.level;
        experienceGiven = Mathf.RoundToInt((3* Mathf.Pow((level+1),1.4f)) / 5);
    }
}
