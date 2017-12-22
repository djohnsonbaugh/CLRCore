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
        public Dictionary<int, Course> Courses { get; }
        public BindingList<Course> BLCourses { get; }

        public CLRCoreData()
        {
            Courses = new Dictionary<int, CLRCore.Course>();
            BLCourses = new BindingList<CLRCore.Course>();
        }

        private int GetNextCourseID()
        {
            int nextid = Courses.Count;
            while (Courses.ContainsKey(nextid)) nextid++;
            return nextid;

        }
        public bool CourseNameExists(string name)
        {
            foreach (Course c in BLCourses) if (c.Name == name) return true;
            return false;
        }
        public Course CreateNewCourse()
        {
            int newid = GetNextCourseID();
            Courses.Add(newid, new Course());
            BLCourses.Add(Courses[newid]);
            return Courses[newid];
        }
    }

}
