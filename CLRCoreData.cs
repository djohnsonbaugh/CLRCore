using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRCore
{
    public class CLRCoreData
    {
        public BindingList<Course> BLCourses { get; }

        public CLRCoreData()
        {
            BLCourses = new BindingList<CLRCore.Course>();
        }

        public bool CourseNameExists(string name)
        {
            foreach (Course c in BLCourses) if (c.Name == name) return true;
            return false;
        }
        public bool CourseAbbrExists(string abbr)
        {
            foreach (Course c in BLCourses) if (c.Abbreviation == abbr) return true;
            return false;
        }

        public Course CreateNewCourse()
        {
            Course c = new Course();
            BLCourses.Add(c);
            return c;
        }
        public Course GetCourse(string name)
        {
            foreach (Course c in BLCourses) if (c.Name == name) return c;
            return null;
        }
        public void FixPrereqRef()
        {
            for (int i = 0; i < BLCourses.Count; i++)
            {
                Course c = BLCourses[i];
                if (c.Prerequisites != null)
                {
                    for (int j = 0; j < BLCourses.Count; j++)
                    {
                        if (BLCourses[j].Name == c.Prerequisites.Name)
                        {
                            c.Prerequisites = BLCourses[j];
                        }
                    }
                }
            }
        }
    }
}
