using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRCore
{
    public class Section
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int Inventory { get; set; }
        public string InventoryLocations { get; set; }
        public int ID { get; set; }

        public Section(int id, string name, string abbreviation)
        {
            ID = id;
            Name = name;
            Abbreviation = abbreviation;
            Inventory = 0;
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
        public Section Copy()
        {
            Section s = new CLRCore.Section(ID, Name, Abbreviation);
            s.Inventory = Inventory;
            s.InventoryLocations = InventoryLocations;
            return s;
        }
    }
}
