using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRCore
{
    public class SectionState
    {
        public int ID { get; }
        public DateTime CompletionDate { get; set; }
        public bool Completed { get { return (CompletionDate == null); } }
        public string Comment { get; set; }
        public string Decision { get; set; }
        public Boolean Mailed { get; set; }
        public DateTime MailedDate { get; set; }
    }
}
