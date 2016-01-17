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
        Rooms = new Dictionary<Vector2, Room>();
        Rooms[new Vector2(0, 0)] = new Room
        {
            Depth = 8,
            Width = 12,
            Obstacles = new List<Obstacle>{
            new Obstacle { X = -5.5f, Z = -2, Y = 3.0f, ObjectId = "Game_Assets/materials/Wall_DEV_Grey-Bottom" },
            new Obstacle { X = -4.5f, Z = -2, Y = 3.0f, ObjectId = "Game_Assets/materials/Wall_DEV_Grey-Corner" },
            new Obstacle { X = -3.5f, Z = -2, Y = 3.0f, ObjectId = "Game_Assets/materials/DEV_Stone" },
            new Obstacle { X = -2.5f, Z = 1, Y = 3.0f, ObjectId = "Game_Assets/materials/Wall_DEV_Grey-Bottom" },
            new Obstacle { X = -1.5f, Z = 1, Y = 3.0f, ObjectId = "Game_Assets/materials/Wall_DEV_Grey-Corner" },
            new Obstacle { X = -0.5f, Z = -2, Y = 3.0f, ObjectId = "Game_Assets/materials/DEV_Stone" },
            new Obstacle { X = 0.5f, Z = 1, Y = 3.0f, ObjectId = "Game_Assets/materials/Wall_DEV_Grey-Bottom" },
            new Obstacle { X = 1.5f, Z = 1, Y = 3.0f, ObjectId = "Game_Assets/materials/Wall_DEV_Grey-Corner" },
            new Obstacle { X = 2.5f, Z = -2, Y = 3.0f, ObjectId = "Game_Assets/materials/DEV_Stone" },
            new Obstacle { X = 3.5f, Z = 1, Y = 3.0f, ObjectId = "Game_Assets/materials/Wall_DEV_Grey-Bottom" },
            new Obstacle { X = 4.5f, Z = 1, Y = 3.0f, ObjectId = "Game_Assets/materials/Wall_DEV_Grey-Corner" },
            new Obstacle { X = 5.5f, Z = 1, Y = 3.0f, ObjectId = "Game_Assets/materials/DEV_Stone" },
            new Obstacle { X = 6.5f, Z = 1, Y = 3.0f, ObjectId = "Game_Assets/materials/Wall_DEV_Grey-Bottom" }
        }
        };

        Rooms[new Vector2(1, 0)] = new Room
        {
            Depth = 8,
            Width = 12,
            Obstacles = new List<Obstacle>{
            new Obstacle { X = -5.5f, Z = 0, Y = 3.0f, ObjectId = "Game_Assets/materials/Wall_DEV_Grey-Bottom" },
            new Obstacle { X = -4.5f, Z = -3, Y = 3.0f, ObjectId = "Game_Assets/materials/Wall_DEV_Grey-Corner" },
            new Obstacle { X = -3.5f, Z = -4, Y = 3.0f, ObjectId = "Game_Assets/materials/DEV_Stone" },
            new Obstacle { X = -2.5f, Z = 0, Y = 3.0f, ObjectId = "Game_Assets/materials/Wall_DEV_Grey-Bottom" },
            new Obstacle { X = -1.5f, Z = 1, Y = 3.0f, ObjectId = "Game_Assets/materials/Wall_DEV_Grey-Corner" },
            new Obstacle { X = -0.5f, Z = -4, Y = 3.0f, ObjectId = "Game_Assets/materials/DEV_Stone" },
            new Obstacle { X = 0.5f, Z = 1, Y = 3.0f, ObjectId = "Game_Assets/materials/Wall_DEV_Grey-Bottom" },
            new Obstacle { X = 1.5f, Z = -2, Y = 3.0f, ObjectId = "Game_Assets/materials/Wall_DEV_Grey-Corner" },
            new Obstacle { X = 2.5f, Z = -1, Y = 3.0f, ObjectId = "Game_Assets/materials/DEV_Stone" },
            new Obstacle { X = 3.5f, Z = 1, Y = 3.0f, ObjectId = "Game_Assets/materials/Wall_DEV_Grey-Bottom" },
            new Obstacle { X = 4.5f, Z = 0, Y = 3.0f, ObjectId = "Game_Assets/materials/Wall_DEV_Grey-Corner" },
            new Obstacle { X = 5.5f, Z = 1, Y = 3.0f, ObjectId = "Game_Assets/materials/DEV_Stone" },
            new Obstacle { X = 6.5f, Z = -2, Y = 3.0f, ObjectId = "Game_Assets/materials/Wall_DEV_Grey-Bottom" }
        }
        };
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
