using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }

        public override string ToString()
        {
            string inventoryString = string.Join(" ", inventory);
            return "Name = " + Name + ", Health = " + Health + ", inventory = " + inventoryString;
        }

        public void PickUpItem(string item)
        {
            inventory.Add(item);
        }

        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }

        public void SetHealth(int health)
        {
            Health = health;
        }
    }
}