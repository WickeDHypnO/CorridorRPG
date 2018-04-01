
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightController : MonoBehaviour
{
    [HideInInspector]
    public Enemy selected;
    public List<Enemy> enemies = new List<Enemy>();
    public List<GameObject> attacking = new List<GameObject>();
    public GameObject selectedIndicator;

    public void StartFight()
    {
        float playerSpeed = FindObjectOfType<GameManager>().playerData.speed;
        foreach (Enemy e in enemies)
        {
            attacking.Add(e.gameObject);
        }
        for (int i = 0; i < attacking.Count; i++)
        {
            if (attacking[i].GetComponent<Enemy>().enemyData.speed < playerSpeed)
            {
                attacking.Insert(i, FindObjectOfType<GameManager>().gameObject);
                break;
            }
        }
        if (!attacking.Exists(x => x == FindObjectOfType<GameManager>().gameObject))
        {
            attacking.Add(FindObjectOfType<GameManager>().gameObject);
        }
        if (attacking[0].GetComponent<Enemy>())
        {
            StartCoroutine(StartEnemyTurn());
        }
        else
        {
            StartPlayerTurn();
        }
    }

    void StartPlayerTurn()
    {
        //Enable skill buttons
        FindObjectOfType<UIController>().SetSkillBarVisible(true);
        FindObjectOfType<UIBuffBar>().UpdateBuffs();
        FindObjectOfType<GameManager>().SpendMana(-FindObjectOfType<GameManager>().playerGameData.manaRegenPerTurn);
        // EndPlayerTurn();
        Debug.Log("playerTurn");
    }

    public void DoSkill(SkillData skillData)
    {
        if (skillData.skillType != SkillType.Buff && skillData.skillType != SkillType.Heal)
        {
            if (skillData.dealDamage)
                selected.DealDamage(skillData.baseDamage + skillData.damageMultiplier * FindObjectOfType<GameManager>().playerData.strength);
        }
        else
        {
            if (skillData.skillType == SkillType.Heal){
                FindObjectOfType<GameManager>().DealDamageToPlayer(-(skillData.baseDamage + FindObjectOfType<GameManager>().playerGameData.level * skillData.damageMultiplier));
            }
            else{

            }
        }
        if (skillData.skillType != SkillType.Buff && skillData.skillType != SkillType.Heal)
        {
            Instantiate(skillData.skillEffect, selected.effectPosition.position, Quaternion.identity);
        }
        else
        {
            Instantiate(skillData.skillEffect, Vector3.zero, Quaternion.identity);
        }
        FindObjectOfType<GameManager>().SpendMana(skillData.skillCost);
    }

    public void EndPlayerTurn(SkillData skillData)
    {
        //Disable buttons
        if (skillData.skillType == SkillType.Heal || skillData.skillType == SkillType.Buff || selected)
        {
            if(skillData.skillCost < FindObjectOfType<GameManager>().playerGameData.mana)
            {
            FindObjectOfType<UIController>().SetSkillBarVisible(false);
            DoSkill(skillData);
            //AttackSelected();
            var temp = attacking[0];
            attacking.Remove(attacking[0]);
            attacking.Add(temp);
            Debug.Log("endedTurn");
            StartCoroutine(StartEnemyTurn());
            }
            else
            {
                Debug.Log("You don't have enought mana");
            }
        }
    }

    IEnumerator StartEnemyTurn()
    {
        yield return new WaitForSeconds(1.5f);
        if (attacking.Count > 1)
        {
            while (attacking[0].GetComponent<Enemy>())
            {
                Debug.Log("enemyAttack");
                attacking[0].GetComponent<EnemyAnimations>().PlayAttack();
                var temp = attacking[0];
                attacking.Remove(attacking[0]);
                attacking.Add(temp);
                yield return new WaitForSeconds(1f);
            }
            StartPlayerTurn();
        }
        else
        {
            attacking.Clear();
            enemies.Clear();
            FindObjectOfType<GameManager>().NextRoom();
        }
    }

    public void AttackSelected(SkillData skillData)
    {
        if (selected)
        {
            selected.DealDamage(skillData.baseDamage + skillData.damageMultiplier * FindObjectOfType<GameManager>().playerData.strength);
        }
    }

    public void Select(Enemy enemy)
    {
        selected = enemy;
        if (selected)
        {
            selectedIndicator.SetActive(true);
            selectedIndicator.transform.position = selected.transform.position;
        }
        else
        {
            selectedIndicator.SetActive(false);
        }
    }

    public void AttackPlayer(float attack)
    {
        FindObjectOfType<GameManager>().DealDamageToPlayer(attack);
    }
}
