using UnityEngine;
using System.Collections;
using DeadMen.API.Models;
using System;
using System.Collections.Generic;

public class DungeonRoomEngine : MonoBehaviour
{
    public LeftBound leftBound;
    public RightBound rightBound;
    public BackBound backBound;
    public ForeBound foreBound;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void ReBound(float left, float right, float back, float fore)
    {
        if (leftBound) { leftBound.transform.position = new Vector3(left, leftBound.transform.position.y, leftBound.transform.position.z); }
        if (rightBound) { rightBound.transform.position = new Vector3(right, rightBound.transform.position.y, rightBound.transform.position.z); }
        if (backBound) { backBound.transform.position = new Vector3(backBound.transform.position.x, backBound.transform.position.y, back); }
        if (foreBound) { foreBound.transform.position = new Vector3(foreBound.transform.position.x, foreBound.transform.position.y, fore); }
    }

    internal void SetupEvents(List<GameEvent> events)
    {
        throw new NotImplementedException();
    }

    internal void SetupObstacles(List<Obstacle> obstacles)
    {
        throw new NotImplementedException();
    }

    internal void SetupMobiles(List<Mobile> mobiles)
    {
        throw new NotImplementedException();
    }

    internal void SetupSkylineObjects(List<SkylineObject> skylineObjects)
    {
        throw new NotImplementedException();
    }
}
