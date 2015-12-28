using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeadMen.API.Models
{
    public class Room
    {
        public List<Mobile> Mobiles;
        public List<GameEvent> Events;
        public List<Obstacle> Obstacles;
        public List<SkylineObject> SkylineObjects;

        public Room West;
        public Room East;
        public Room North;
        public Room South;
        public Dictionary<string, Room> AdditionalLink;

        public float Width;
        public float Depth;

        // Potentially a Duplication; TODO: triple/quadruple check we DO need this
        public int XCoordinate;
        public int YCoordinate;

        public Room()
        {
            Mobiles = new List<Mobile>();
            Events = new List<GameEvent>();
            Obstacles = new List<Obstacle>();
            SkylineObjects = new List<SkylineObject>();

            West = null;
            East = null;
            North = null;
            South = null;

            Width = 12;
            Depth = 8;
        }
    }
}
