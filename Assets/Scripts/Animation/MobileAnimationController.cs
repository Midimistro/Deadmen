using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DeadMen.API.Models;
using System.Linq;

public class MobileAnimationController : MonoBehaviour {
    public float Speed_x = 6f;
    public float Speed_z = 2.5f;
    public float Speed_y = 50f;
    bool rightFace = true;
    public int stance = 1;
    public int weaponImage = 1;

    public Rigidbody rigidBody;
    public Animator anim;
    public ParticleSystem BloodSplatter;
    public List<Item> Inventory;

    public bool tirade = false; // sorry.  This is a cooler way to say 'attempting a combo' or, 'in combo'
    public bool resting = false;
    public int previousAttack = 0;

    // Use this for initialization
    void Start () {
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
                
        anim.SetBool("IsRight", rightFace);
        if (rigidBody.velocity.sqrMagnitude < 0.1) {
            anim.SetBool("Moving", false);
        }
    }

    void Flip()
    {
        rightFace = !rightFace;
        Vector3 worldscale = anim.GetComponent<Transform>().localScale;
        worldscale.x = -worldscale.x;
        anim.GetComponent<Transform>().localScale = worldscale;

        Vector3 localposition = anim.GetComponent<Transform>().position;
        localposition.x += rightFace ? 1f : -1f;
        anim.GetComponent<Transform>().position = localposition;
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
        var toMoveX = Right ? 1 : -1;
        rigidBody.AddForce(new Vector3(toMoveX * Speed_x, 0f, 0f));
        //rigidBody.velocity = new Vector3(toMoveX * Speed_x, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
        anim.SetBool("Moving", true);

        if ((toMoveX > 0 && !rightFace) || (toMoveX < 0 && rightFace))
        {
            Flip();
        }
    }

    public void LaunchMoveZ(bool Fore)
    {
        var toMoveZ = Fore ? 1 : -1;

        rigidBody.AddForce(new Vector3(0f, 0f, toMoveZ * Speed_z));
        //rigidBody.velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, toMoveZ * Speed_z);
        anim.SetBool("Moving", true);
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

    public void InitializeMobileMoveSpeed(Stats mobileModelStats)
    {
        Speed_x = 0.3f * mobileModelStats.SPD;
        Speed_z = 0.125f * mobileModelStats.SPD;
        Speed_y = 2.5f * mobileModelStats.SPD;
    }
}
