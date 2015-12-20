using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using DeadMen.Models.Items;
using System.Linq;

public class CharacterController : MonoBehaviour {
    public readonly float Speed_x = 6f;
    public readonly float Speed_z = 2.5f;
    public readonly float Speed_y = 50f;
    bool rightFace = true;
    public int stance = 1;
    public int weaponImage = 1;
    public int Health = 100;

    public int Build = 10;
    public int Speed = 10;
    public int Will = 10;
    public int Intelligence = 10;

    public bool tirade = false; // sorry.  This is a cooler way to say 'attempting a combo' or, 'in combo'
    public bool resting = false;
    public int previousAttack = 0;

    private int attack = 0;
    private int special = 0;
    private int block = 0;
    private int pickup = 0;
    private int jump = 0;
    private const int buffertime = 10;

    //public List<OnScreenItem> Selectables;
    public OnScreenItem Selected;
    public LayerMask ItemLayer;
    private const float itemRadius = 0.2f;

    public Animator anim;
    public ParticleSystem BloodSplatter;
    //public List<Item> Inventory;
    //public List<Item> Weapons { get { return Inventory.Where(item => item is Weapon).ToList(); } }
    //public List<Item> Armors { get { return Inventory.Where(item => item is Armor).ToList(); } }

    // Use this for initialization
    void Start () {
        //anim = localSprite.GetComponent<Animator>();
	}

    public CharacterController()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            attack = buffertime;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            special = buffertime;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            block = buffertime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = buffertime;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            pickup = buffertime;
        }
    }
	
	void FixedUpdate ()
    {
        var rigidBody = GetComponent<Rigidbody>();
        float move_x = Input.GetAxis("Horizontal");
        float move_z = Input.GetAxis("Vertical");
        var forwardThrust = 0f;

        if (!tirade) {

            anim.SetBool("Moving", (move_x != 0 || move_z != 0));
            anim.SetBool("IsRight", rightFace);
            
            FindSelectedItem();

            if ((move_x > 0 && !rightFace) || (move_x < 0 && rightFace)) {
                Flip();
            }
            if (attack > 0) {
                LaunchAttack(1);
            }

            if (jump > 0)
            {
                LaunchJump();
            }

            if (pickup>0)
            {
                SplatBlood();
                //Selected.launch();
            }
        } else
        {
            move_x = 0;
            move_z = 0;
            if (resting) {

                if (attack > 0) {
                    Debug.Log("attack Z");
                    switch (previousAttack)
                    {
                        case 1:
                            LaunchAttack(2);
                            rigidBody.AddForce(new Vector3((rightFace ? 600 : -600), 0f, 0f));
                            break;
                        case 2:
                            LaunchAttack(2);
                            rigidBody.AddForce(new Vector3((rightFace ? 600 : -600), 0f, 0f));
                            break;
                        default: break;
                    }
                }
            }
        }
        rigidBody.velocity = new Vector3(move_x * Speed_x + (rightFace ? forwardThrust : -forwardThrust), GetComponent<Rigidbody>().velocity.y, move_z * Speed_z);
        reduceBuffers();
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

    void reduceBuffers()
    {
        if (attack > 0) attack--;
        if (special > 0) special--;
        if (block > 0) block--;
        if (jump > 0) jump--;
        if (pickup > 0) pickup--;
    }

    void LaunchAttack(int AttackAnimation)
    {
        attack = 0;
        special = 0;
        block = 0;
        anim.SetInteger("Attack_ID", AttackAnimation);
        anim.SetBool("Tirade", true);
        previousAttack = AttackAnimation;
        tirade = true;
        resting = false;
    }

    void LaunchJump()
    {
        Debug.Log("Jump");

        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(new Vector3(0f, Speed_y, 0f));
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

    public void FindSelectedItem()
    {
        //if (Selectables.Count == 0) return;
        //var rigidBody = GetComponent<Rigidbody>();
        //foreach (OnScreenItem OSI in Selectables)
        //{
        //    var OSI_rigidBody = OSI.GetComponent<Rigidbody>();
        //    if (OSI_rigidBody == null) continue;

        //    if (Physics.SphereCast(rigidBody.position, 10f)) return;
        //}
        var transform = GetComponent<Transform>();
        var allItems = Physics.OverlapSphere(transform.position, itemRadius, ItemLayer);

        if (allItems.Length == 0) {
            Selected = null;
            return;
        }

        Selected = allItems[0].GetComponent<OnScreenItem>();
        Selected.selected = true;
        
    }

    public void takeDamage(int damageToTake)
    {
        if (Health > 0) Health -= damageToTake;
        if (Health < 0) Health = 0;

        if (Health == 0) Dead();
    }

    public void Dead()
    {
        // throw IDKYERDEADError();
    }

    void SplatBlood()
    {
        BloodSplatter.Play();
    }
}
