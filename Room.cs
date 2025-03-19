using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private List<string> items = new List<string> ();

        public Room(string description, List<string> items)
        {
            this.description = description;
            this.items = items;
        }

        public string GetDescription()
        {
            string updatedDescription = description;
            int listLength = items.Count();
            if (listLength != 0)
            {
                updatedDescription += " You see a " + string.Join(", ", items) + " on the ground.";
            }
            return updatedDescription;
        }

        public List<string> GetItems()
        {
            return items;
        }

        public void AddItem(string item)
        {
            items.Add(item);
        }

        public void RemoveItem(string item)
        {
            items.Remove(item);
        }

        public int GetItemCount()
        {
            int itemCount = items.Count();
            return itemCount;
        }
    }
}