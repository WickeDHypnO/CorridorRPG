using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnabler : MonoBehaviour {

    public MapGenerator generator;
    public int roomsVisible = 3;
    int currentRoom = 0;
    public int CurrentRoom
    {
        get
        {
            return currentRoom;
        }
        set
        {
            currentRoom = value;
            EnableNextRooms(value);
        }
    }

    void OnEnable()
    {
       //EnableNextRooms(0);
    }

    public void EnableNextRooms(int room)
    {
        for(int i = room; i < room + roomsVisible; i++)
        {
            if(i >= generator.placedRooms.Count)
            {
                break;
            }
            generator.placedRooms[i].SetActive(true);
        }
        for(int i = 0; i < room-1; i++)
        {
            generator.placedRooms[i].SetActive(false);
        }
    }
}
