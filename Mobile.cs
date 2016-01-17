using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;

namespace DeadMen.API.Models
{
    public class Mobile
    {
        public int Id;
        public string name;
        public int health;
        public Stats stats;
        public List<Item> Inventory;
        public int InventoryMax;

        public Mobile()
        {
            Id = 0;
            name = "Debug";
            health = 100;
            stats = new Stats();
            Inventory = new List<Item>();
            InventoryMax = 20;
        }
    }
}
