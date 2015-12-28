using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DeadMen.API.Models;
using System.Linq;

public class MobileAnimationController : MonoBehaviour {
    public float Speed_x = 6f;
    public float Speed_z = 2.5f;
    public float Speed_y = 50f;
    public float toMoveX = 0;
    public float toMoveZ = 0;
    bool rightFace = true;
    public int stance = 1;
    public int weaponImage = 1;

    public Rigidbody rigidBody;
    public Animator anim;
    public ParticleSystem BloodSplatter;
    public List<Item> Inventory;
    //public List<Item> Weapons { get { return Inventory.Where(item => item is Weapon).ToList(); } }
    //public List<Item> Armors { get { return Inventory.Where(item => item is Armor).ToList(); } }

    public bool tirade = false; // sorry.  This is a cooler way to say 'attempting a combo' or, 'in combo'
    public bool resting = false;
    public int previousAttack = 0;

    // Use this for initialization
    void Start () {
        //anim = localSprite.GetComponent<Animator>();
	}

    public MobileAnimationController()
    {
    }

    void Update()
    {
    }
	
	void FixedUpdate ()
    {
        if(rigidBody == null) { rigidBody = GetComponent<Rigidbody>(); }
        var forwardThrust = 0f;

        anim.SetBool("Moving", (toMoveX != 0 || toMoveZ != 0));
        anim.SetBool("IsRight", rightFace);

        if ((toMoveX > 0 && !rightFace) || (toMoveX < 0 && rightFace)) {
            Flip();
        }

        if (!tirade)
        {
        }
        else
        {
            toMoveX = 0;
            toMoveZ = 0;
        }

        rigidBody.velocity = new Vector3(toMoveX * Speed_x + (rightFace ? forwardThrust : -forwardThrust), GetComponent<Rigidbody>().velocity.y, toMoveZ * Speed_z);
        toMoveX = 0;
        toMoveZ = 0;
    }

    void Flip()
    {
        Debug.Log("Flip");
        rightFace = !rightFace;
        Vector3 worldscale = GetComponent<Transform>().localScale;
        Vector3 localposition = GetComponent<Transform>().position;
        worldscale.x = -worldscale.x;
        localposition.x += rightFace ? 0.3f : -0.3f;
        GetComponent<Transform>().localScale = worldscale;
        GetComponent<Transform>().position = localposition;
    }

    public void AttemptAttack(int AttackAnimation)
    {
        if (!tirade)
        {
            LaunchAttack(AttackAnimation);
        }
        else
        {
            if (resting)
            {
                switch (previousAttack)
                {
                    case 1:
                        LaunchAttack(2);
                        rigidBody.AddForce(new Vector3((rightFace ? 600 : -600), 0f, 0f));
                        break;
                    case 2:
                        LaunchAttack(1);
                        rigidBody.AddForce(new Vector3((rightFace ? 600 : -600), 0f, 0f));
                        break;
                    default: break;
                }
            }
        }
    }

    public void LaunchAttack(int AttackAnimation)
    {
        anim.SetInteger("Attack_ID", AttackAnimation);
        anim.SetBool("Tirade", true);
        previousAttack = AttackAnimation;
        tirade = true;
        resting = false;
    }

    public void LaunchMoveX(bool Right)
    {
        toMoveX = Right ? Speed_x : -Speed_x;
    }

    public void LaunchMoveZ(bool Fore)
    {
        toMoveZ = Fore ? Speed_z : -Speed_z;
    }

    public void LaunchJump()
    {
        Debug.Log("Jump");

        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(new Vector3(0f, Speed_y, 0f));
    }

    public void LaunchBlock()
    {
        Debug.Log("Block");
    }

    /// <summary>
    ///     To be called by a StateMachineBehaviour, attached to an animation in Unity.
    /// </summary>
    public void EndAttack()
    {
        tirade = false;
        resting = false;
        anim.SetInteger("Attack_ID", 0);
        anim.SetBool("Tirade", false);
    }

    /// <summary>
    ///     To be called by a StateMachineBehaviour, attached to an animation in Unity.
    /// </summary>
    public void RestAttack()
    {
        anim.SetInteger("Attack_ID", 0);
        resting = true;
    }

    void SplatBlood()
    {
        BloodSplatter.Play();
    }
}
