using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRCore
{
    public class Member
    {
        public int ID { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public Address Address { get; set; }
        public DateTime DoB { get; set; }
        public Boolean Adult { get; set; }
        public DateTime MembershipDate { get; set; }
        public Boolean ProffessionOfFaith { get; set; }
        public string Church { get; set; }
        public string Country {  get { return Address.Country; } }
        public int Age {
            get
            {
                return (DateTime.Today.Year - DoB.Year) - ((DateTime.Today.Month * 30 + DateTime.Today.Day < DoB.Month * 30 + DoB.Day) ? 1 : 0);
            }
        }
        public string AgeorAdult { get { return (Adult) ? "Adult" : Age.ToString(); } }
        public string Denominiation { get; set; }
        public string Comment { get; set; }
        public Dictionary<int, CourseState> CompletedCourses;
        public CourseState CurrentCourse;

        public DateTime LastActivity { get { return (CurrentCourse == null)? MembershipDate : CurrentCourse.CurrentSection.MailedDate; } }
        public bool MatchString(string search)
        {
            if(FirstName != null) if (FirstName.ToLower().Contains(search.ToLower())) return true;
            if (LastName != null) if (LastName.ToLower().Contains(search.ToLower())) return true;
            if (ID.ToString().Contains(search.ToLower())) return true;
            return false;
        }
        public void DeleteCourseState(int  id)
        {
            CompletedCourses.Remove(id);
        }

        public Member(int id)
        {
            ID = id;
            CompletedCourses = new Dictionary<int, CLRCore.CourseState>();
            MembershipDate = DateTime.Today;
            DoB = new DateTime(1753, 1, 1);
            Address = new Address();
        }
    }
}
