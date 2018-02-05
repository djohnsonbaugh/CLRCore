using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRCore
{
    public class MailCodeDisplay
    {
        public Member Member { get; set; }
        public string MailCode { get; set; }
        public int ID { get { return Member.ID; } }
        public string FirstName { get { return Member.FirstName; } }
        public string LastName { get { return Member.LastName; } }
        public string Country { get { return Member.Address.Country; } }
        public string Label { get { return Member.getLabelText(MailCode); } }
        public bool Selected { get; set; }
        public MailCodeDisplay(Member m, string mailcode)
        {
            Member = m;
            MailCode = mailcode;
            Selected = true;
        }
    }
}
