using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeadMen.API.Models
{
    public class Item
    {
        public int value;
        public string name;
        public int weight;
        private int dataID;
    }

    public enum WeaponFlags
    {
        //Core Types
        BuildMelee = 0,
        SpeedMelee = 1,
        IntelligenceMelee = 2,
        BuildRanged = 3,
        SpeedRanged = 4,
        IntelligenceRanged = 5,
        //Types
        WesternSword = 1000,
        Katana = 1001,
        Rifle = 1002,
        //Eras
        StoneAge = 2000,
        BronzeAge = 2001,
        Medieval = 2002,
        Rennaisance = 2003,
        Industrial = 2004,
        ColdWar = 2005,
        Modern = 2006,
        Neo = 2007,
        Serene = 2008
        //MISC
    }

    public class WeaponComponent : Item
    {
        public List<WeaponFlags> Flags;
    }

    public class Weapon : Item
    {
        public bool melee;
        public bool strength;
        public int power;
        public int durabilityMax;
        public int durability;
        public Dictionary<string, int> statBonuses;
    }

    public class Armor : Item
    {
        public int durabilityMax;
        public int durability;
        public Dictionary<string, int> strengths;
    }
}
