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
            dgvCourses.Columns.Add(CreateColumn("Name", "Name", "Name",146));
            dgvCourses.Columns.Add(CreateColumn("MinAge", "Min Age", "MinAge",40));
            dgvCourses.Columns.Add(CreateColumn("MaxAge", "Max Age", "MaxAge", 40));
            dgvCourses.Columns.Add(CreateColumn("MinInventory", "Min Inv", "MinInventory", 40));
            dgvCourses.RowHeadersVisible = false;

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

    }
}
