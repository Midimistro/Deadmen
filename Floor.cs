using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeadMen.API.Models
{
    public class Floor
    {
        public Dictionary<KeyValuePair<int, int>, Room> Rooms;
        public int difficulty;

        public Floor()
        {
            Rooms = new Dictionary<KeyValuePair<int,int>, Room>();
            Rooms[new KeyValuePair<int, int>(0, 0)] = new Room(); //stubbed attempt
            Rooms[new KeyValuePair<int, int>(0, 1)] = new Room(); //stubbed attempt
            Rooms[new KeyValuePair<int, int>(1, 0)] = new Room(); //stubbed attempt
            Rooms[new KeyValuePair<int, int>(-1, 0)] = new Room(); //stubbed attempt
            Rooms[new KeyValuePair<int, int>(0, -1)] = new Room(); //stubbed attempt
        }
    }
}