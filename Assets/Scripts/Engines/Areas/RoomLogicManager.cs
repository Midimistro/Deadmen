using UnityEngine;
using System.Collections;
using DeadMen.API.Models;
using System;
using System.Collections.Generic;

public class RoomLogicManager : MonoBehaviour
{
    public Room roomModel;
    public Transform ObstacleBase;
    public Transform MobileBase;

    public LeftBound leftBound;
    public RightBound rightBound;
    public BackBound backBound;
    public ForeBound foreBound;

    public List<Transform> obstacles;
    public List<AIMobileManager> mobiles;

    public bool westPortal = false;
    public bool eastPortal = false;
    public bool northPortal = false;
    public bool southPortal = false;

    //public Texture2D[] obstacleTextures;

    // Use this for initialization
    void Start () {
        //obstacleTextures = (Texture2D[])Resources.LoadAll("Textures");
        LoadRoom(new Room { Depth=8,Width=12 });
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void LoadRoom(Room quickModel = null)
    {
        if(quickModel != null) { roomModel = quickModel; }

        ReBound(-6f, roomModel.Width - 6f, -roomModel.Depth - 1f, 7f);
        //SetupEvents(null);
        //EXTREMELY STUBBED OUT
        SetupObstacles(new List<Obstacle>{
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
        });
        //SetupMobiles(null);
        //SetupSkylineObjects(null);
    }

    public void ReBound(float left, float right, float back, float fore)
    {
        if (leftBound) { leftBound.transform.position = new Vector3(left, leftBound.transform.position.y, leftBound.transform.position.z); }
        if (rightBound) { rightBound.transform.position = new Vector3(right, rightBound.transform.position.y, rightBound.transform.position.z); }
        if (backBound) { backBound.transform.position = new Vector3(backBound.transform.position.x, backBound.transform.position.y, back); }
        if (foreBound) { foreBound.transform.position = new Vector3(foreBound.transform.position.x, foreBound.transform.position.y, fore); }
    }

    public void SetupEvents(List<GameEvent> events)
    {
        throw new NotImplementedException();
    }

    public void SetupObstacles(List<Obstacle> loadedObstacles)
    {
        foreach (Obstacle obstacleModel in loadedObstacles)
        {
            obstacles.Add(Instantiate(ObstacleBase, new Vector3(obstacleModel.X, obstacleModel.Y, obstacleModel.Z), Quaternion.identity) as Transform);
            var physicalObjectInEngine = (obstacles[obstacles.Count-1].GetComponent<ObstacleAnimationController>());
            if (physicalObjectInEngine != null) {
                physicalObjectInEngine.ChangeMaterial(obstacleModel.ObjectId);
            }
        }
    }

    public void SetupMobiles(List<Mobile> mobiles)
    {
        throw new NotImplementedException();
    }

    public void SetupSkylineObjects(List<SkylineObject> skylineObjects)
    {
        throw new NotImplementedException();
    }
}
