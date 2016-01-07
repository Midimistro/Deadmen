using UnityEngine;
using System.Collections;
using Assets.Scripts.Engines.Input;
using DeadMen.API.Models;

public class AIMobileManager : MonoBehaviour
{
    public MobileAnimationController ControlledMobileAnimation;
    public Mobile MobileModel = new Mobile();
    public MobileInput PlayerInput;
    public int WeaponClassID = 0;
    public int WeaponSkinID = 0;
}
