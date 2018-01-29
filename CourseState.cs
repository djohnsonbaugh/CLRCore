using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRCore
{
    public class CourseState
    {
        public int ID { get; }
        public DateTime CompletionDate { get; set; }
        public bool Completed { get; set; }
        public DateTime CertificateDate { get; set; }
        public bool CertificateMailed { get; set; }
        public Dictionary<int, SectionState> Sections;
        public SectionState CurrentSection { get { return Sections[CurrentSectionID]; } }
        public int CurrentSectionID;
        public CourseState(int id)
        {
            ID = id;
            Sections = new Dictionary<int, SectionState>();
        }
         public void SetCurrentSection(SectionState ss, Course c)
        {
            foreach(Section s in c.Sections.Values)
            {
                if(s.ID != ss.ID && !Sections.ContainsKey(s.ID))
                {
                    Sections.Add(s.ID, new SectionState(s.ID, true, true));
                }
                else
                {
                    Sections.Add(ss.ID, ss);
                    CurrentSectionID = ss.ID;
                    break;
                }
            }
        }

    }
    public class CourseStateDisplay
    {
        public string Name { get { return Course.Name; } }
        public string Abbreviation { get { return Course.Abbreviation; } }
        public int ID { get { return Course.ID; } }
        public DateTime CompletionDate { get { return CourseState.CompletionDate; } set { CourseState.CompletionDate = value; } }
        public bool Completed { get { return CourseState.Completed; } }
        public DateTime CertificateDate { get { return CourseState.CertificateDate; } set { CourseState.CertificateDate = value; } }
        public bool CertificateMailed { get { return CourseState.CertificateMailed; } }
        public Dictionary<int, SectionState> Sections { get { return CourseState.Sections; } set { CourseState.Sections = value; } }
        public SectionState CurrentSection { get { return CourseState.CurrentSection; } }
        public int CurrentSectionID { get { return CourseState.CurrentSectionID; } set { CourseState.CurrentSectionID = value; } }
        public CourseState CourseState { get; set; }
        public Course Course { get; set; }
        public CourseStateDisplay(CourseState cs, Course c)
        {
            CourseState = cs;
            Course = c;
        }

    }
}
