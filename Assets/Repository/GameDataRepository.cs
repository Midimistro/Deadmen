using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeadMen.Models.Items;
using System.Net;
using System.Net;

namespace Assets.Repository
{
    public class GameDataRepository
    {
        public GameDataRepository()
        {

        }

        public Item GetItemData(int itemID)
        {
            return new Item();
        }

        public bool SetItemData(Item item)
        {
            return false;
        }

        public Item GenerateNewItemAtRunTime(int rarity)
        {
            return new Item();
        }
    }
}
