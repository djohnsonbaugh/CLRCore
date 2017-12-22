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
    public partial class frmCLRCore : Form
    {
        private CLRCoreData CLRData;
        private Course SelectedCourse;
        public frmCLRCore()
        {
            CLRData = new CLRCoreData();
            InitializeComponent();
            InitCourseInventory();
        }

        #region Init
        private void InitCourseInventory()
        {
            dgvCourses.AutoGenerateColumns = false;
            dgvCourses.Columns.Clear();
            dgvCourses.Columns.Add(CreateColumn("Name", "Name", "Name", 146));
            dgvCourses.Columns.Add(CreateColumn("MinAge", "Min Age", "MinAge", 40));
            dgvCourses.Columns.Add(CreateColumn("MaxAge", "Max Age", "MaxAge", 40));
            dgvCourses.Columns.Add(CreateColumn("MinInventory", "Min Inv", "MinInventory", 40));
            dgvCourses.RowHeadersVisible = false;
            dgvCourses.DataSource = CLRData.BLCourses;

        }
        private DataGridViewTextBoxColumn CreateColumn(string name, string text, string field, int width)
        {
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            DataGridViewTextBoxColumn colFileName = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                Name = name,
                HeaderText = text,
                DataPropertyName = field,
                Width = width
            };
            return colFileName;
        }
        #endregion Init
        #region Command Buttons
        private void cmdNewCourse_Click(object sender, EventArgs e)
        {
            CLRData.CreateNewCourse();
            SelectRow("");

        }
        #endregion Command Buttons

        private void LoadCourse(Course c)
        {
            if (c == null)
            {
                SelectedCourse = c;
                tbxName.Text = "";
                tbxAbbr.Text = "";
                tbxMinAge.Text = "0";
                tbxMaxAge.Text = "0";
                tbxLink.Text = "";
                rbxDescription.Text = "";
                cbxShowDeprecated.Checked = false;
            }
            else
            {
                SelectedCourse = c;
                tbxName.Text = SelectedCourse.Name;
                tbxAbbr.Text = SelectedCourse.Abbreviation;
                tbxMinAge.Text = SelectedCourse.MinAge.ToString();
                tbxMaxAge.Text = SelectedCourse.MaxAge.ToString();
                tbxLink.Text = SelectedCourse.Link;
                rbxDescription.Text = SelectedCourse.Description;
                cbxShowDeprecated.Checked = SelectedCourse.Deprecated;
            }
            cmdSaveCourse.Enabled = false;
        }

        private void dgvCourses_SelectionChanged(object sender, EventArgs e)
        {
            SelectedCourse = (Course)dgvCourses.CurrentRow.DataBoundItem;
            LoadCourse(SelectedCourse);
        }

        private void cmdSaveCourse_Click(object sender, EventArgs e)
        {
            SelectedCourse.Name = tbxName.Text;
            SelectedCourse.Abbreviation = tbxAbbr.Text;
            SelectedCourse.MinAge = int.Parse(tbxMinAge.Text);
            SelectedCourse.MaxAge = int.Parse(tbxMinAge.Text);
            SelectedCourse.Link = tbxLink.Text;
            SelectedCourse.Description = rbxDescription.Text;
            SelectedCourse.Deprecated = cbxShowDeprecated.Checked;
            SelectRow(SelectedCourse.Name);
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void SelectRow(string name)
        {
            dgvCourses.ClearSelection();
            foreach(DataGridViewRow row in dgvCourses.Rows)
            {
                Course c = (Course)row.DataBoundItem;
                if (c != null)
                {
                    if (c.Name == name)
                    {
                        row.Selected = true;
                        dgvCourses.CurrentCell = dgvCourses.Rows[row.Index].Cells[0];
                        dgvCourses.Se
                        break;
                    }
                }
            }
        }

        private void tbxName_Validating(object sender, CancelEventArgs e)
        {
            if (SelectedCourse.Name != tbxName.Text)
            {
                if (CLRData.CourseNameExists(tbxName.Text))
                {
                    e.Cancel = true;
                    tbxName.Select(0, tbxName.Text.Length);
                    cmdSaveCourse.Enabled = false;
                    errorProvider1.SetError(tbxName, "Name provided is not unique.");
                }
            }
        }

        private void tbxName_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbxName, "");
            if (SelectedCourse.Name != tbxName.Text)
            {
                cmdSaveCourse.Enabled = true;
            }
        }
    }
}
