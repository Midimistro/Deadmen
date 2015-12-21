using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeadMen.API.Models
{
    public class DungeonRoom
    {
        public List<Mobile> Mobiles;
        public List<GameEvent> Events;
        public List<Obstacle> Obstacles;
        public List<SkylineObject> SkylineObjects;

        public DungeonRoom West;
        public DungeonRoom East;
        public DungeonRoom North;
        public DungeonRoom South;
        public Dictionary<string, DungeonRoom> AdditionalLink;

        public float Width;
        public float Depth;

        public DungeonRoom() {
            Mobiles = new List<Mobile>();
            West = null;
            East = null;
            North = null;
            South = null;
        }
    }
}
