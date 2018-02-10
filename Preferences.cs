using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var cfg = Properties.Settings.Default;
            tbxActiveMemberDays.Text = cfg.MinDaysInactive.ToString();
            tbxAdultMinAge.Text = cfg.AdultMinAge.ToString();
            tbxTeenMaxAge.Text = cfg.TeenMaxAge.ToString();
            tbxTeenMinAge.Text = cfg.TeenMinAge.ToString();
            tbxLabelName.Text = cfg.LabelName;
            tbxFontSize.Text = cfg.FontSize.ToString();
            tbxMxCharLength.Text = cfg.MaxLabelChars.ToString();

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            var cfg = Properties.Settings.Default;
            int val;
            if (int.TryParse(tbxActiveMemberDays.Text, out val)) cfg.MinDaysInactive = val;
            if (int.TryParse(tbxAdultMinAge.Text, out val)) cfg.AdultMinAge = val;
            if (int.TryParse(tbxTeenMaxAge.Text, out val)) cfg.TeenMaxAge = val;
            if (int.TryParse(tbxTeenMinAge.Text, out val)) cfg.TeenMinAge = val;
            if (int.TryParse(tbxFontSize.Text, out val)) cfg.FontSize = val;
            if (int.TryParse(tbxMxCharLength.Text, out val)) cfg.MaxLabelChars = val;
            cfg.LabelName = tbxLabelName.Text;
            cfg.Save();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
