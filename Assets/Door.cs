using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public FloorLogicManager floorLogicManager;
    public RoomLogicManager roomLogicManager;
    public Vector2 goToId;
    public Vector3 goToPosition;

    // Use this for initialization
    void Start () {
	
	}

    void OnTriggerEnter(Collider collidingObject)
    {
        if(collidingObject.Equals(roomLogicManager.playerCharacter))
        {
        }
        if (goToId == null) { goToId = new Vector2(1, 0); }
        //Debug.Log("ROOM JUMP!");
        roomLogicManager.LoadRoom(floorLogicManager.Rooms[goToId]);
        if (goToId.x == 1) { goToId.x = 0; } else { goToId.x = 1; }

        if (goToPosition == null)
        {
            collidingObject.GetComponent<Transform>().position = new Vector3(0, 4, 0);
        } else
        {
            collidingObject.GetComponent<Transform>().position = goToPosition;
        }
    }

    void OnTriggerStay(Collider collidingObject)
    {

    }

    void OnTriggerExit(Collider collidingObject)
    {

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
