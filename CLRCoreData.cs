using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CLRCore
{
    public class CLRCoreData
    {
        //public BindingList<Course> BLCourses { get; }
        public Dictionary<int, Course> Courses { get; }
        public Dictionary<int, Member> Members { get; }
        public SortedSet<string> Cities { get; }
        public SortedSet<string> States { get; }
        public SortedSet<string> Countries { get; }
        public SortedSet<string> Churches { get; }
        public SortedSet<string> Denominiations { get; }
        private Thread SearchThread { get; set; }
        private string searchlock = "";

        public event EventHandler<MemberSearchEventArgs> MemberSearchComplete;
        protected virtual void OnMemberSearchComplete(MemberSearchEventArgs msea)
        {
            EventHandler<MemberSearchEventArgs> eh = MemberSearchComplete;
            if (eh != null)
            {
                eh(this, msea);
            }
        }
        public void ResetMembers()
        {
            Members.Clear();
        }
        public CLRCoreData()
        {
            Courses = new Dictionary<int, Course>();
            Members = new Dictionary<int, Member>();
            Cities = new SortedSet<string>();
            States = new SortedSet<string>();
            Countries = new SortedSet<string>();
            Churches = new SortedSet<string>();
            Denominiations = new SortedSet<string>();
        }
        public void AsyncGetMembership(long searchid, string search, bool inactive)
        {
            SearchThread = new Thread(delegate ()
            {
                BindingList<Member> members = GetMembership(search, inactive);
                OnMemberSearchComplete(new MemberSearchEventArgs(searchid, members));
            });
            SearchThread.Start();
        }
        public void DeleteMember(int id)
        {
            Members.Remove(id);
        }
        public BindingList<Member> GetMembership(string search, bool inactive)
        {
            BindingList<Member> members = new BindingList<CLRCore.Member>();
            string[] searches = search.Trim().Split(new Char[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (Member m in Members.Values)
            {
                if (inactive || (DateTime.Today - m.LastActivity).TotalDays < Properties.Settings.Default.MinDaysInactive)
                {
                    int found = 0;
                    foreach (string s in searches)
                    {
                        if (m.MatchString(s)) found++;
                    }
                    if (found == searches.Length) members.Add(m);
                }
            }
            return members;
        }
        public BindingList<Course> GetCourses(string search, bool inactive)
        {
            BindingList<Course> courses = new BindingList<Course>();
            string[] searches = search.Trim().Split(new Char[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (Course c in Courses.Values)
            {
                if (inactive || !c.Deprecated)
                {
                    int found = 0;
                    foreach (string s in searches)
                    {
                        if (c.MatchString(s)) found++;
                    }
                    if (found == searches.Length) courses.Add(c);
                }
            }
            return courses;
        }
        public BindingList<MailCodeDisplay> GetMailingList()
        {
            BindingList<MailCodeDisplay> mcd = new BindingList<MailCodeDisplay>();
            foreach (Member m in Members.Values)
            {
                string mc = "";
                if (m.CurrentCourse != null)
                {
                    CourseState cs = m.CurrentCourse;
                    Course c = Courses[cs.ID];
                    if (cs.CurrentSectionID > 0)
                    {
                        SectionState ss = cs.CurrentSection;
                        Section s = c.Sections[ss.ID];
                        if (!m.CurrentCourse.CurrentSection.Mailed)
                        {
                            if (mc.Length > 0) mc += ";";
                            mc += string.Format("{0}/{1}", c.Abbreviation, s.Abbreviation);
                        }
                    }
                }
                foreach(int cint in m.UnmailedCerts())
                {
                    if (mc.Length > 0) mc += ";";
                    mc += string.Format("CE/{0}", Courses[cint].Abbreviation);
                }

                if (mc.Length > 0) mcd.Add(new MailCodeDisplay(m, mc));
            }
            return mcd;
        }

        public BindingList<CourseStateDisplay> GetCompletedCourses(int id)
        {
            BindingList<CourseStateDisplay> csds = new BindingList<CLRCore.CourseStateDisplay>();
            Member m = Members[id];
            foreach(CourseState cs in Members[id].CompletedCourses.Values)
            {
                csds.Add(new CourseStateDisplay(cs, Courses[cs.ID]));
            }
            return csds;
        }
        public BindingList<SectionStateDisplay> GetCompletedSections(int id)
        {
            BindingList<SectionStateDisplay> csds = new BindingList<SectionStateDisplay>();
            Member m = Members[id];
            if (m.CurrentCourse != null)
            {
                if (Courses.ContainsKey(m.CurrentCourse.ID))
                {
                    Course c = Courses[m.CurrentCourse.ID];
                    foreach (SectionState ss in m.CurrentCourse.Sections.Values)
                    {
                        csds.Add(new SectionStateDisplay(ss, c.Sections[ss.ID]));
                    }
                }
            }
            return csds;
        }
        public SortedSet<string> GetAbbreviations()
        {
            SortedSet<string> set = new SortedSet<string>();
            foreach (Course c in Courses.Values) set.Add(c.Abbreviation);
            return set;
        }
        public int GetNextMemberID()
        {
            int nextid = Members.Count;
            while (Members.ContainsKey(nextid)) nextid++;
            return nextid;
        }
        public int GetNextCourseID()
        {
            int nextid = Courses.Count;
            while (Courses.ContainsKey(nextid)) nextid++;
            return nextid;
        }
        public Member CreateNewMember()
        {
            int newid = GetNextMemberID();
            Member m = new Member(newid);
            Members.Add(newid, m);
            return m;

        }
        public bool CourseNameExists(string name)
        {
            foreach (Course c in Courses.Values) if (c.Name == name) return true;
            return false;
        }
        public bool CourseAbbrExists(string abbr)
        {
            foreach (Course c in Courses.Values) if (c.Abbreviation == abbr) return true;
            return false;
        }
        public bool TryFindCourseByAbbr(string abbr, out int id)
        {
            id = -1;
            foreach (Course c in Courses.Values) if (c.Abbreviation == abbr)
                {
                    id = c.ID;
                    return true;
                }
            return false;
        }

        public Course CreateNewCourse()
        {
            int newid = GetNextCourseID();
            Course c = new Course(newid);
            Courses.Add(newid, c);
            return c;
        }
        public Course GetCourse(string name)
        {
            foreach (Course c in Courses.Values) if (c.Name == name) return c;
            return null;
        }
        public Course GetCourse(int id)
        {
            return Courses[id];
        }

        //public void FixPrereqRef()
        //{
        //    foreach (Course c in Courses.Values)
        //    {
        //        if (c.Prerequisites != null)
        //        {
        //            for (int j = 0; j < BLCourses.Count; j++)
        //            {
        //                if (BLCourses[j].Name == c.Prerequisites.Name)
        //                {
        //                    c.Prerequisites = BLCourses[j];
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
