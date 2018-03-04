using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour {

    Vector3 lookPoint;
    MapGenerator generator;
    int currentWaypoint;
    bool canMove = true;

	void OnEnable () {
        generator = FindObjectOfType<MapGenerator>();
	}
	
	public void MoveToNextWaypoint () {
        if (!canMove)
            return;
        currentWaypoint++;
        if (generator.placedRooms[currentWaypoint + 1])
        {
            DOTween.Sequence().Append(transform.DOMove(generator.placedRooms[currentWaypoint].GetComponent<Room>().waypoint.position, 2f))
                .Append(transform.DOLookAt(generator.placedRooms[currentWaypoint + 1].GetComponent<Room>().waypoint.position, 1f))
                .AppendCallback(FinishedMoving)
                .Play();
        }
        else
        {
            //Detected end of dungeon
        }
        FindObjectOfType<RoomEnabler>().CurrentRoom++;
        if(currentWaypoint >= generator.placedRooms.Count-1)
        {
            canMove = false;
        }
    }

    void FinishedMoving()
    {
        if (currentWaypoint < generator.placedRooms.Count - 2)
        {
            FindObjectOfType<GameManager>().SpawnEnemies();
        }
        else
        {
            FindObjectOfType<GameManager>().SpawnBoss();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            MoveToNextWaypoint();
        }
    }
}
