using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MakeData {
    [MenuItem("Assets/Create/PlayerData")]
    public static void CreatePlayer()
    {
        PlayerStats asset = ScriptableObject.CreateInstance<PlayerStats>();

        AssetDatabase.CreateAsset(asset, "Assets/PlayerData.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

    [MenuItem("Assets/Create/EnemyData")]
    public static void CreateEnemy()
    {
        EnemyStats asset = ScriptableObject.CreateInstance<EnemyStats>();

        AssetDatabase.CreateAsset(asset, "Assets/Enemies/EnemyData.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

    [MenuItem("Assets/Create/SkillData")]
    public static void CreateSkill()
    {
        SkillData asset = ScriptableObject.CreateInstance<SkillData>();

        AssetDatabase.CreateAsset(asset, "Assets/Skills/SkillData.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
