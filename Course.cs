using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRCore
{
    public class Course
    {
        public string Name { get; private set; }
        public string Abbreviation { get; set; }
        public SortedList<int, Section> Sections;
        public int MinAge {get; set;}
        public int MaxAge { get; set; }
        public SortedSet<Course> Prerequisites;
        public string Description { get; set; }

        public Course(string name, string abbreviation)
        {
            Name = name;
            Abbreviation = abbreviation;
            Sections = new SortedList<int, CLRCore.Section>();
            Prerequisites = new SortedSet<CLRCore.Course>();             
        }

        public void AddSection(Section section)
        {
            Sections.Add(Sections.Count + 1, section);
        }

        public void AddInventory(int number)
        {
            foreach (Section s in Sections.Values) s.AddInventory(number);
        }
    }
}
