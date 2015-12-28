using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DeadMen.API.Models;

public class FloorLogicManager : MonoBehaviour
{
    public Dictionary<Vector2, Room> Rooms;
    public Vector2 startingRoom;
    public int DifficultyModifier;
    public List<GameEvent> GameEvents;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Setup()
    {
        //var dungeonData = _dungeonReader.RequestDungeon();
    }

    public void LoadFloor(Floor loadedFloorModel)
    {

    }

    private void LinkRoom(Room StartRoom, Room DestinationRoom, string Direction)
    {
        if (StartRoom == null) return;

        switch (Direction.ToLower())
        {
            case "west":
                StartRoom.West = DestinationRoom;
                if (DestinationRoom.East == null) { DestinationRoom.East = StartRoom; }
                break;
            case "east":
                StartRoom.East = DestinationRoom;
                if (DestinationRoom.West == null) { DestinationRoom.West = StartRoom; }
                break;
            case "north":
                StartRoom.North = DestinationRoom;
                if (DestinationRoom.South == null) { DestinationRoom.South = StartRoom; }
                break;
            case "south":
                StartRoom.West = DestinationRoom;
                if (DestinationRoom.North == null) { DestinationRoom.North = StartRoom; }
                break;
            default:
                if (StartRoom.AdditionalLink[Direction] == null)
                {
                    StartRoom.AdditionalLink[Direction] = DestinationRoom;
                }
                break;
        }
    }
}
