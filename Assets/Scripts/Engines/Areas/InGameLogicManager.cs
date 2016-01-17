using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeadMen.API.Models;

namespace Assets.Scripts.Engines.Areas
{
    public class InGameLogicManager : MonoBehaviour
    {
        public DungeonLogicManager CurrentDungeon;
        public FloorLogicManager CurrentFloor;
        public RoomLogicManager CurrentRoom;

        void Start()
        {
            CurrentRoom.LoadRoom(new Room
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
        });

        }

        void Update()
        {

        }
    }
}
