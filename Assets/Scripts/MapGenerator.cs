using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsNames
{
    Strength,
    Agility,
    Willpower
}

public struct Stats
{
    StatsNames name;
    int level;
    float progress;
}

public class MapGenerator : MonoBehaviour
{
    public List<GameObject> rooms;
    public List<GameObject> bossRooms;
    public GameObject starterRoom;
    public List<GameObject> placedRooms = new List<GameObject>();
    public float numberOfRooms;
    public float[] chances = new float[2];

    void Awake()
    {
        Generate();
        FindObjectOfType<RoomEnabler>().EnableNextRooms(0);
        FindObjectOfType<CameraMovement>().transform.LookAt(placedRooms[1].GetComponent<Room>().waypoint.position);
        StartCoroutine(SpawnFirstEnemies());
    }

    IEnumerator SpawnFirstEnemies()
    {
        yield return new WaitForSeconds(0.2f);
        FindObjectOfType<GameManager>().SpawnEnemies();
    }

    void Generate()
    {
        placedRooms.Add(Instantiate(starterRoom, Vector3.zero, Quaternion.identity));
        int lastDirection = 0;
        float spawnsRotation = 0;
        Vector2 directionVector = new Vector2(0, 1);
        for (int i = 0; i < numberOfRooms; i++)
        {
            float direction = Random.Range(0f, 1f);
            int roomNumber = Random.Range(0, rooms.Count);
            
            Vector2 lastPosition = GetLastRoomPosition();
            Vector2 lastRoomSize = placedRooms[placedRooms.Count - 1].GetComponent<Room>().size;
            if (lastDirection != 0 || direction < chances[0])
            {
                placedRooms.Add(Instantiate(rooms[roomNumber], new Vector3(
                    lastPosition.x + (lastRoomSize.x / 2 + rooms[roomNumber].GetComponent<Room>().size.x / 2) * directionVector.x,
                    0,
                    lastPosition.y + (lastRoomSize.y / 2 + rooms[roomNumber].GetComponent<Room>().size.y / 2) * directionVector.y), Quaternion.identity));
                lastDirection = 0;
                DestroyWalls(placedRooms[placedRooms.Count - 1], placedRooms[placedRooms.Count - 2]);
                placedRooms[placedRooms.Count - 1].GetComponent<Room>().parentSpawns.eulerAngles = new Vector3(0, spawnsRotation, 0);
            }
            else if (direction < chances[1])
            {
                directionVector = new Vector2(directionVector.y, directionVector.x * -1);
                placedRooms.Add(Instantiate(rooms[roomNumber], new Vector3(
                    lastPosition.x + (lastRoomSize.x / 2 + rooms[roomNumber].GetComponent<Room>().size.x / 2) * directionVector.x,
                    0,
                    lastPosition.y + (lastRoomSize.y / 2 + rooms[roomNumber].GetComponent<Room>().size.y / 2) * directionVector.y), Quaternion.identity));
                lastDirection = 1;
                DestroyWalls(placedRooms[placedRooms.Count - 1], placedRooms[placedRooms.Count - 2]);
                if(spawnsRotation == 90)
                {
                    spawnsRotation = 0;
                }
                else
                {
                    spawnsRotation = 90;
                }
                placedRooms[placedRooms.Count - 1].GetComponent<Room>().parentSpawns.eulerAngles = new Vector3(0, spawnsRotation, 0);
            }
            else
            {
                directionVector = new Vector2(directionVector.y * -1, directionVector.x);                
                placedRooms.Add(Instantiate(rooms[roomNumber], new Vector3(
                    lastPosition.x + (lastRoomSize.x / 2 + rooms[roomNumber].GetComponent<Room>().size.x / 2)* directionVector.x, 
                    0, 
                    lastPosition.y + (lastRoomSize.y / 2 + rooms[roomNumber].GetComponent<Room>().size.y / 2) * directionVector.y), Quaternion.identity));
                lastDirection = 1;
                DestroyWalls(placedRooms[placedRooms.Count - 1], placedRooms[placedRooms.Count - 2]);
                if (spawnsRotation == 90)
                {
                    spawnsRotation = 0;
                }
                else
                {
                    spawnsRotation = 90;
                }
                placedRooms[placedRooms.Count - 1].GetComponent<Room>().parentSpawns.eulerAngles = new Vector3(0, spawnsRotation, 0);
            }
        }
        foreach(GameObject go in placedRooms)
        {
            go.SetActive(false);
        }
        //spawnBossRoom

        int bossRoomNumber = Random.Range(0, bossRooms.Count);
        Vector2 bossLastPosition = GetLastRoomPosition();
        Vector2 bossLastRoomSize = placedRooms[placedRooms.Count - 1].GetComponent<Room>().size;
        placedRooms.Add(Instantiate(bossRooms[bossRoomNumber], new Vector3(
            bossLastPosition.x + (bossLastRoomSize.x / 2 + bossRooms[bossRoomNumber].GetComponent<Room>().size.x / 2) * directionVector.x, 
            0,
            bossLastPosition.y + (bossLastRoomSize.y / 2 + bossRooms[bossRoomNumber].GetComponent<Room>().size.y / 2) * directionVector.y), Quaternion.identity));
        DestroyWalls(placedRooms[placedRooms.Count - 1], placedRooms[placedRooms.Count - 2]);
        placedRooms[placedRooms.Count - 1].GetComponent<Room>().parentSpawns.eulerAngles = new Vector3(0, spawnsRotation, 0);
    }

    Vector2 GetLastRoomPosition()
    {
        return new Vector2(placedRooms[placedRooms.Count - 1].transform.position.x, placedRooms[placedRooms.Count - 1].transform.position.z);
    }

    void DestroyWalls(GameObject room1, GameObject room2)
    {
        if (room1.transform.position.x > room2.transform.position.x)
        {
            Destroy(room2.GetComponent<Room>().rightWall);
            Destroy(room1.GetComponent<Room>().leftWall);
        }
        else if(room1.transform.position.x < room2.transform.position.x)
        {
            Destroy(room1.GetComponent<Room>().rightWall);
            Destroy(room2.GetComponent<Room>().leftWall);
        }
        else if (room1.transform.position.z > room2.transform.position.z)
        {
            Destroy(room2.GetComponent<Room>().frontWall);
            Destroy(room1.GetComponent<Room>().backWall);
        }
        else
        {
            Destroy(room2.GetComponent<Room>().backWall);
            Destroy(room1.GetComponent<Room>().frontWall);
        }
    }
}
