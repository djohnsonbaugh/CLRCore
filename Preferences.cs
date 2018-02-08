using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace CLRCore
{
    public partial class Preferences : Form
    {
        public Preferences()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Preferences_Load(object sender, EventArgs e)
        {

        }

        private void Preferences_Shown(object sender, EventArgs e)
        {
            var cfg = ConfigurationSettings.AppSettings;
            tbxActiveMemberDays.Text = cfg["MinDaysInactive"];
            tbxAdultMinAge.Text = cfg["AdultMinAge"];
            tbxTeenMaxAge.Text = cfg["TeenMaxAge"];
            tbxTeenMinAge.Text = cfg["TeenMinAge"];


        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            var cfg = ConfigurationSettings.AppSettings;
            int val;
            if (int.TryParse(tbxActiveMemberDays.Text, out val)) cfg["MinDaysInactive"] = val.ToString();
            if (int.TryParse(tbxAdultMinAge.Text, out val)) cfg["AdultMinAge"] = val.ToString();
            if (int.TryParse(tbxTeenMaxAge.Text, out val)) cfg["TeenMaxAge"] = val.ToString();
            if (int.TryParse(tbxTeenMinAge.Text, out val)) cfg["TeenMinAge"] = val.ToString();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
