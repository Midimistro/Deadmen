using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeadMen.API.Models
{
    public enum eventType
    {
        story = 0,
        standard = 1,
        pvp = 2,
        holiday = 3
    }

    public class GameEvent
    {
        public int Id;
        public string description;
        public eventType type;
        public int dungeonId;
        public int floorId;
    }
}
