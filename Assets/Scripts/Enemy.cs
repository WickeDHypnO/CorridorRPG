using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public EnemyStats enemyData;
    EnemyStats currentStats;
    public Slider healthSlider;
    public Transform effectPosition;
    float maxHealth;

	void OnDestroy() {
        FindObjectOfType<FightController>().enemies.Remove(this);
        FindObjectOfType<FightController>().Select(null);
    }
	
	void OnEnable()
    {
        maxHealth = enemyData.health;
        currentStats = Instantiate(enemyData);
       // FindObjectOfType<FightController>().enemies.Add(this);
    }

    void OnMouseDown()
    {
        FindObjectOfType<FightController>().Select(this);
    }

    public void Destroy()
    {
        Destroy(gameObject);
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

    public void AttackPlayer()
    {
        FindObjectOfType<FightController>().AttackPlayer(enemyData.attack);
    }
}
