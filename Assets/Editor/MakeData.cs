using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MakeData
{
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

    [MenuItem("Assets/Create/Items/Helmet")]
    public static void CreateHelmet()
    {
        HelmetData asset = ScriptableObject.CreateInstance<HelmetData>();

        AssetDatabase.CreateAsset(asset, "Assets/Items/Helmets/HelmetData.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

    [MenuItem("Assets/Create/Items/Weapon")]
    public static void CreateWeapon()
    {
        WeaponData asset = ScriptableObject.CreateInstance<WeaponData>();

        AssetDatabase.CreateAsset(asset, "Assets/Items/Weapons/WeaponData.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

    [MenuItem("Assets/Create/Items/BodyArmor")]
    public static void CreateBodyArmor()
    {
        BodyArmorData asset = ScriptableObject.CreateInstance<BodyArmorData>();

        AssetDatabase.CreateAsset(asset, "Assets/Items/BodyArmors/BodyArmorData.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

     [MenuItem("Assets/Create/Items/LowerArmor")]
    public static void CreateLowerArmor()
    {
        LowerArmorData asset = ScriptableObject.CreateInstance<LowerArmorData>();

        AssetDatabase.CreateAsset(asset, "Assets/Items/LowerArmors/LowerArmorData.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

       [MenuItem("Assets/Create/Items/OffHand")]
    public static void CreateOffHand()
    {
        OffHandData asset = ScriptableObject.CreateInstance<OffHandData>();

        AssetDatabase.CreateAsset(asset, "Assets/Items/OffHands/OffHandData.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

}
