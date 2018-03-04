using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    public Vector2 size;
    public GameObject frontWall;
    public GameObject backWall;
    public GameObject rightWall;
    public GameObject leftWall;
    public Transform waypoint;
    public List<Transform> spawnPoints;
    public Transform parentSpawns;
}
