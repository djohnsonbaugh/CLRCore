using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRCore
{
    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Guardian { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string getLabelText(string extrastuff)
        {
            string lbl = "";
            List<string> Parts = new List<string>();
            int maxlen = Properties.Settings.Default.MaxLabelChars;
            if (Guardian.Length > 0)
            {
                lbl += @"c/o " + Guardian;
                lbl += "\r\n";
            }

            if (Line1.Length > 0) Parts.Add(Line1);
            if (Line2.Length > 0) Parts.Add(Line2);
            if (City.Length > 0) Parts.Add(City);
            if (State.Length > 0) Parts.Add(State);
            if (ZipCode.Length > 0) Parts.Add(ZipCode);
            if (Country.Length > 0) Parts.Add(Country);
            if (extrastuff.Length > 0) Parts.Add("[" + extrastuff + "]");

            string sublbl = "";
            foreach (string s in Parts)
            {
                if (sublbl.Length != 0 && sublbl.Length + s.Length + 1 <= maxlen) sublbl += ",";
                if (sublbl.Length + s.Length + 1 > maxlen)
                {
                    lbl += sublbl + "\r\n";
                    sublbl = "";
                }
                sublbl += s;
            }
            if (sublbl.Length != 0) lbl += sublbl;
            return lbl;
        }
    }
}
