using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeadMen.API.Models
{
    public class SkillFlow
    {
        public Dictionary<int, List<int>> FromToGates;
        public int WeaponClassID;
    }
}
