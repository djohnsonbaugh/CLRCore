using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRCore
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public SortedList<int, Section> Sections;
        public int MinAge {get; set;}
        public int MinInventory {  get { return GetMinimumInventory(); } }
        public int MaxAge { get; set; }
        public bool Adult { get; set; }
        public int PrerequisiteID;
        public string Description { get; set; }
        public string Link { get; set; }
        public bool Deprecated { get; set; }
        public int Section {  get { return Sections.Count; } }
        public Course()
        {
            Sections = new SortedList<int, CLRCore.Section>();
            PrerequisiteID = -1;
            Name = "";
            MaxAge = 5000;
        }
        public Course(int id) : this()
        {
            ID = id;
        }
        public Course(int id, string name, string abbreviation) : this(id)
        {
            Name = name;
            Abbreviation = abbreviation;
        }

        public void AddSection(Section section)
        {
            Sections.Add(Sections.Count + 1, section);
        }

        public void AddInventory(int number)
        {
            foreach (Section s in Sections.Values) s.AddInventory(number);
        }
        public int GetMinimumInventory()
        {
            if (Sections.Count == 0) return 0;
            int mininv = int.MaxValue;
            foreach (Section s in Sections.Values)
                if (mininv > s.Inventory)
                    mininv = s.Inventory;
            return mininv; 
        }
        public BindingList<Section> CopySections()
        {
            BindingList<Section> secs = new BindingList<CLRCore.Section>(); 
            foreach(KeyValuePair<int, Section> sec in Sections)
            {
                secs.Add(sec.Value.Copy());
            }
            return secs;
        }
        public void  UpdateSections(BindingList<Section> secs)
        {
            Sections = new SortedList<int, CLRCore.Section>();
            foreach(Section s in secs)
            {
                Sections.Add(s.ID, s);
            }
        }
        public bool MatchString(string search)
        {
            if (Name != null) if (Name.ToLower().Contains(search.ToLower())) return true;
            if (Abbreviation != null) if (Abbreviation.ToLower().Contains(search.ToLower())) return true;
            if (ID.ToString().Contains(search.ToLower())) return true;
            return false;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
