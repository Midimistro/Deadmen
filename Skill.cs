using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeadMen.API.Models
{
    public class Skill
    {
        //Database Figures
        public int ID;
        public int WeaponClass;

        //Animation Identifiers
        public int AnimationID = 1;
        public int DamageOverTimeID = 0;

        public float DamageBase = 10f;
        public float KnockBackStrength = 0f;
        public float InductionSpeed = 0f;
        public float KnockUpStrength = 0f;
        public float DamageOverTime = 0f;
    }
}
