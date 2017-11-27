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
            dgvCourses.Columns.Add(CreateColumn("ID", "ID", "ID", 0));
            dgvCourses.Columns.Add(CreateColumn("Name", "Name", "Name",146));
            dgvCourses.Columns.Add(CreateColumn("MinAge", "Min Age", "MinAge",40));
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
        }
        #endregion Command Buttons


        private void CourseAdded(object sender, CourseAddedEventArgs e)
        {

        }

        private void LoadCourse(Course c)
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

        private void dgvCourses_SelectionChanged(object sender, EventArgs e)
        {
            var selectedid = dgvCourses..SelectedRows[0].Cells["ID"].Value;
            if (selectedid != null)
            {
                LoadCourse(CLRData.Courses[(int)selectedid]);
            }
        }
    }
}
