using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeadMen.API.Models;

namespace Assets.Scripts.Engines.Input
{
    public class SkillLogicManager
    {
        public SkillFlow fromToGates;
        public Dictionary<int, Skill> SkillStatistics;

        public bool hasOptions(int From) {
            return (fromToGates.FromToGates.ContainsKey(From));
        }

        /// <summary>
        /// Returns null if no options are found.  Returns List of int IDs if any are found. 
        /// </summary>
        /// <param name="From"></param>
        /// <returns></returns>
        public List<int> options(int From)
        {
            if (hasOptions(From))
            {
                return fromToGates.FromToGates[From];
            }
            return null;
        }
    }
}
