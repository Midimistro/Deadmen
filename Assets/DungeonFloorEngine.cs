using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DeadMen.API.Models;
using DeadMen.API.Client;

public class DungeonFloorEngine : MonoBehaviour {
    public int Floor;
    public Dictionary<Vector2, DungeonRoom> Rooms;
    public Vector2 startingRoom;
    public string DungeonName;
    public int ArbitraryDifficulty;
    public List<GameEvent> GameEvents;

    public DungeonRoomEngine DRE;
    public DungeonReader _dungeonReader;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Setup()
    {
        var dungeonData = _dungeonReader.RequestDungeon();
    }

    public void LoadRoom(DungeonRoom loadedRoom)
    {
        DRE.ReBound(0, loadedRoom.Width, loadedRoom.Depth, 0);
        DRE.SetupSkylineObjects(loadedRoom.SkylineObjects);
        DRE.SetupObstacles(loadedRoom.Obstacles);
        DRE.SetupMobiles(loadedRoom.Mobiles);
        DRE.SetupEvents(loadedRoom.Events);
    }

    private void LinkRoom(DungeonRoom StartRoom, DungeonRoom DestinationRoom, string Direction)
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
