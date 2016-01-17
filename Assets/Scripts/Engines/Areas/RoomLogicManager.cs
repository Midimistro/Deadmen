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
    public Door backDoor;
    public Door frontDoor;
    public Door leftDoor;
    public Door rightDoor;

    public MobileAnimationController playerCharacter;
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
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void LoadRoom(Room quickModel = null)
    {
        if (quickModel != null) { roomModel = quickModel; }
        CleanUpObstacles();
        //CleanUpMobiles();

        ReBound(-6f, roomModel.Width - 6f, -roomModel.Depth - 1f, 7f);
        //SetupEvents(null);
        //EXTREMELY STUBBED OUT
        SetupObstacles(quickModel.Obstacles);

        SetupMobiles(new List<Mobile>
            {
                new Mobile { health = 100, Id = 0, Inventory = new List<Item>(), InventoryMax = 10, name = "enemy 1", stats = new Stats { INT = 5, SPD = 5, STR = 5, WLP = 5 } },
                new Mobile { health = 10, Id = 1, Inventory = new List<Item>(), InventoryMax = 10, name = "enemy 2", stats = new Stats { INT = 5, SPD = 5, STR = 5, WLP = 5 } },
                new Mobile { health = 300, Id = 2, Inventory = new List<Item>(), InventoryMax = 10, name = "enemy 3", stats = new Stats { INT = 5, SPD = 5, STR = 5, WLP = 5 } }
            }
        );
        //SetupSkylineObjects(null);
    }

    private void CleanUpObstacles()
    {
        if (obstacles.Count > 0)
        {
            foreach (Transform O in obstacles)
            {
                Destroy(O.gameObject);
            }
        }
        obstacles = new List<Transform>();
    }

    private void CleanUpMobiles()
    {
        if (mobiles.Count > 0)
        {
            foreach (AIMobileManager M in mobiles)
            {
                Destroy(M.gameObject);
            }
        }
        mobiles = new List<AIMobileManager>();
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

    public void SetupMobiles(List<Mobile> loadedMobiles)
    {
        //foreach(Mobile mobileModel in loadedMobiles)
        //{
        //    mobiles.Add(new AIMobileManager {
        //        ControlledMobileAnimation = Instantiate(MobileBase, new Vector3(0, 4, 0), Quaternion.identity) as MobileAnimationController,
        //        PlayerInput = new Assets.Scripts.Engines.Input.MobileInput(),
        //        MobileModel = mobileModel,
        //        WeaponClassID = 0,
        //        WeaponSkinID = 0
        //    });
        //}
    }

    public void SetupSkylineObjects(List<SkylineObject> skylineObjects)
    {
        throw new NotImplementedException();
    }
}
