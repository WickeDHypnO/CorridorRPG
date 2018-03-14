using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public EnemyStats enemyData;
    EnemyStats currentStats;
    public Slider healthSlider;
    public Transform effectPosition;
    public Transform head;
    float maxHealth;
    bool selectable = true;

    void OnDestroy()
    {
        FindObjectOfType<FightController>().enemies.Remove(this);
    }

    void OnEnable()
    {
        maxHealth = enemyData.health;
        currentStats = Instantiate(enemyData);
        healthSlider = FindObjectOfType<UIHealthBars>().GetHealthBar();
        // FindObjectOfType<FightController>().enemies.Add(this);
    }

    void OnMouseDown()
    {
        if(selectable)
        FindObjectOfType<FightController>().Select(this);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if(healthSlider)
        {
            healthSlider.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(head.position + Vector3.up * 0.3f);
        }
    }

    public void DealDamage(float damage)
    {
        currentStats.health -= damage;
        healthSlider.value = currentStats.health / maxHealth;
        if (currentStats.health <= 0)
        {
            GetComponent<EnemyAnimations>().PlayDeath();
            FindObjectOfType<FightController>().attacking.Remove(gameObject);
        }
        else
            GetComponent<EnemyAnimations>().PlayHit();
    }

    public void Die()
    {
        selectable = false;
        FindObjectOfType<UIHealthBars>().RevokeHealthBar(healthSlider);
        FindObjectOfType<FightController>().Select(null);
    }

    public void AttackPlayer()
    {
        FindObjectOfType<FightController>().AttackPlayer(enemyData.attack);
    }
}
