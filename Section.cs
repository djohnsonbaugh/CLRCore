using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRCore
{
    public class Section
    {
        public string Name { get; private set; }
        public string Abbreviation { get; private set; }
        public int Inventory { get; private set; }
        public string InventoryLocations { get; private set; }

        public Section(string name, string abbreviation)
        {
            Name = name;
            Abbreviation = abbreviation;
        }

        public void DecrementInventory()
        {
            if (Inventory > 0) Inventory--;
        }

        public void AddInventory(int number)
        {
            Inventory += number;
        }
        public void SetInventory(int number)
        {
            Inventory = number;
        }
    }
}
