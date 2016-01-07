using UnityEngine;
using System.Collections;
using System.Linq;
using Assets.Scripts.Engines.Input;
using DeadMen.API.Models;

/// <summary>
/// Contains logic for restricting and handling player input as it relates to a Mobile in game
/// </summary>
public class PlayerLogicManager : MonoBehaviour {

    public MobileAnimationController ControlledMobileAnimation;
    public Mobile MobileModel = new Mobile();
    public MobileInput PlayerInput;
    public int WeaponClassID = 0;
    public int WeaponSkinID = 0;

    public OnScreenItem SelectedOnScreenItem;
    public LayerMask ItemLayer;
    private const float itemRadius = 0.2f;

    // Use this for initialization
    void Start () {
        MobileModel.stats = new Stats { STR = 10, SPD = 8, INT = 10, WLP = 10 };
        PlayerInput = new MobileInput();
        TieAnimationToModel();
    }
	
    void TieAnimationToModel()
    {
        ControlledMobileAnimation.InitializeMobileMoveSpeed(MobileModel.stats);
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (PlayerInput.attack.trigger())
            {
                ControlledMobileAnimation.AttemptAttack(1);
                PlayerInput.attack.reset();
                PlayerInput.special.reset();
                PlayerInput.block.reset();
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (PlayerInput.special.trigger())
            {
                ControlledMobileAnimation.AttemptAttack(2);
                PlayerInput.attack.reset();
                PlayerInput.special.reset();
                PlayerInput.block.reset();
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (PlayerInput.block.trigger())
            {
                ControlledMobileAnimation.LaunchBlock();
                PlayerInput.attack.reset();
                PlayerInput.special.reset();
                PlayerInput.block.reset();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (PlayerInput.jump.trigger()) { ControlledMobileAnimation.LaunchJump(); }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (PlayerInput.pickup.trigger())
            {
                SelectedOnScreenItem.LaunchPickup(MobileModel);
            }
        }

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        if (horizontal != 0) {
            ControlledMobileAnimation.LaunchMoveX((horizontal > 0));
        }
        if (vertical != 0) {
            ControlledMobileAnimation.LaunchMoveZ((vertical > 0));
        }
        horizontal = 0;
        vertical = 0;

        PlayerInput.tickdown();

        FindSelectedItem();
    }

    public void FindSelectedItem()
    {
        var transform = ControlledMobileAnimation.GetComponent<Transform>();
        var allItems = Physics.OverlapSphere(transform.position, itemRadius, ItemLayer);

        if (allItems.Length == 0)
        {
            SelectedOnScreenItem = null;
            return;
        }

        SelectedOnScreenItem = allItems.FirstOrDefault().GetComponent<OnScreenItem>();
        SelectedOnScreenItem.selected = true;
    }

    public void takeDamage(int damageToTake)
    {
        //if (Health > 0) Health -= damageToTake;
        //if (Health < 0) Health = 0;

        //if (Health == 0) Dead();
    }

    public void Dead()
    {
        // throw IDKYERDEADError();
    }
}
