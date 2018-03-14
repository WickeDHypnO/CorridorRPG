using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    MapGenerator generator;
    int currentRoom = 1;
    public List<GameObject> enemies;
    public List<GameObject> aliveEnemies;
    public PlayerStats playerData;
    public Slider healthSlider;
    public Slider manaSlider;
    float maxHealth;
    float maxMana;
    [HideInInspector]
    public PlayerStats playerGameData;
    public UIController uiController;
    public GameObject boss;

	void Start () {
        playerGameData = Instantiate(playerData);
        generator = FindObjectOfType<MapGenerator>();
        maxHealth = playerData.health;
        maxMana = playerData.mana;
	}
	
	public void SpawnEnemies () {
        List<Transform> spawns = generator.placedRooms[currentRoom].GetComponent<Room>().spawnPoints;
        int enemy = Random.Range(0, enemies.Count);
        foreach(Transform t in spawns)
        {
            Quaternion look = Quaternion.LookRotation(Camera.main.transform.position - t.position);
            look.eulerAngles = new Vector3(0, look.eulerAngles.y, 0);
            FindObjectOfType<FightController>().enemies.Add(Instantiate(enemies[enemy], t.position, look).GetComponent<Enemy>());
        }
        currentRoom++;
        FindObjectOfType<FightController>().StartFight();
	}

    public void SpawnBoss()
    {
        List<Transform> spawns = generator.placedRooms[currentRoom].GetComponent<Room>().spawnPoints;
        foreach (Transform t in spawns)
        {
            Quaternion look = Quaternion.LookRotation(Camera.main.transform.position - t.position);
            look.eulerAngles = new Vector3(0, look.eulerAngles.y, 0);
            FindObjectOfType<FightController>().enemies.Add(Instantiate(boss, t.position, look).GetComponent<Enemy>());
        }
        FindObjectOfType<FightController>().StartFight();
    }

    public void DeleteEnemy(GameObject enemy)
    {
        aliveEnemies.Remove(enemy);
        if(aliveEnemies.Count <= 0)
        {
            FindObjectOfType<CameraMovement>().MoveToNextWaypoint();
        }
    }

    public void DealDamageToPlayer(float damage)
    {
        playerGameData.health -= damage;
        healthSlider.value = playerGameData.health / maxHealth;
        uiController.ShowDamage();
        if(playerGameData.health <= 0)
        {
            //DEAD
        }
    }

    public void SpendMana(float cost)
    {
        playerGameData.mana -= cost;
        manaSlider.value = playerGameData.mana / maxMana;
    }

    internal void NextRoom()
    {
        FindObjectOfType<CameraMovement>().MoveToNextWaypoint();
    }
}
