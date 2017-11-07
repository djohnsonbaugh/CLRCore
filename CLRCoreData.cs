using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRCore
{
    public class CLRCoreData
    {
        public Dictionary<int, Course> Courses { get; }

        public CLRCoreData()
        {
            Courses = new Dictionary<int, CLRCore.Course>();
        }

        private int GetNextCourseID()
        {
            int nextid = Courses.Count;
            while (Courses.ContainsKey(nextid)) nextid++;
            return nextid;

        }

        public Course CreateNewCourse()
        {
            int newid = GetNextCourseID();
            Courses.Add(newid, new Course());
            return Courses[newid];
        }
    }
}
