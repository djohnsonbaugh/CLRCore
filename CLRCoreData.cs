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
        public event EventHandler CourseAdded;

        public virtual void OnCourseAdded(EventArgs e)
        {
            if (CourseAdded != null) CourseAdded(this, e);
        }


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

        public Course CreateNewCourse()
        {
            int newid = GetNextCourseID();
            Courses.Add(newid, new Course());
            BLCourses.Add(Courses[newid]);
            OnCourseAdded(new CourseAddedEventArgs(newid));
            return Courses[newid];
        }
    }
    public class CourseAddedEventArgs : EventArgs
    {
        public int ID { get; private set; }

        // Constructor. 
        public CourseAddedEventArgs(int id)
        {
            ID = id;
        }

     }
}
