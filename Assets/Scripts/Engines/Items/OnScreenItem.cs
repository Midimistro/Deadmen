using UnityEngine;
using System.Collections;
using DeadMen.API.Models;

public class OnScreenItem : MonoBehaviour {

    public int yPropulsion;
    public bool grounded = false;
    public Animator itemSprite;
    public bool selected = false;
    public Transform groundChecker;
    public LayerMask whatIsGround;
    public float groundRad = 0.2f;
    public Item ActualItem;

    // Use this for initialization
    void Start () {
        LaunchUpwards();
    }
    
    void FixedUpdate () {
        grounded = Physics.OverlapSphere(groundChecker.position, groundRad, whatIsGround).Length > 0;
        if (grounded) itemSprite.SetBool("Grounded", true);
        else itemSprite.SetBool("Grounded", false);
        itemSprite.SetBool("Selected", selected);

        selected = false;
    }

    public void LaunchPickup(Mobile mobilePickingUp)
    {
        if(mobilePickingUp.Inventory.Count < mobilePickingUp.InventoryMax)
        {
            Debug.Log("Picking up!");
            mobilePickingUp.Inventory.Add(ActualItem);
        } else
        {
            LaunchUpwards();
        }
    }

    public void LaunchUpwards()
    {
        var physicsObject = GetComponent<Rigidbody>();
        if (!physicsObject) return;

        itemSprite.SetBool("Grounded", false);

        physicsObject.velocity = new Vector3(0, yPropulsion + Random.Range(-2f, 2f), 0);
    }
}
