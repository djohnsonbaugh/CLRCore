using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRCore
{
    public class SectionState
    {
        public int ID { get; set; }
        public DateTime CompletionDate { get; set; }
        public bool Completed { get; set; }
        public string Comment { get; set; }
        public string Decision { get; set; }
        public Boolean Mailed { get; set; }
        public DateTime MailedDate { get; set; }
        public SectionState()
        {
            ID = -1;
        }
        public SectionState(int id)
        {
            ID = id;
        }
        public SectionState(int id, bool complete, bool mailed)
        {
            ID = id;
            Completed = complete;
            Mailed = mailed;

        }
    }
    public class SectionStateDisplay
    {
        public Section Section { get; set; }
        public SectionState SectionState { get; set; }
        public string Name {  get { return Section.Name; } }
        public bool Mailed { get { return SectionState.Mailed; } }
        public string CompletionDate { get { return (SectionState.Completed)? SectionState.CompletionDate.ToShortDateString() : ""; } }

        public SectionStateDisplay(SectionState ss, Section s)
        {
            SectionState = ss;
            Section = s;
        }
    }
}
