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
        private Section SelectedSection;
        private BindingList<Section> TempSections;
        private string CurrentFile;
        public frmCLRCore()
        {
            CLRData = new CLRCoreData();
            InitializeComponent();
            InitCourseInventory();
            InitSectionInventory();
        }

        #region Init
        private void InitCourseInventory()
        {
            dgvCourses.AutoGenerateColumns = false;
            dgvCourses.Columns.Clear();
            dgvCourses.Columns.Add(CreateColumn("Abbr", "Abbr", "Abbreviation", 146));
            dgvCourses.Columns.Add(CreateColumn("MinAge", "Min Age", "MinAge", 40));
            dgvCourses.Columns.Add(CreateColumn("MaxAge", "Max Age", "MaxAge", 40));
            dgvCourses.Columns.Add(CreateColumn("MinInventory", "Min Inv", "MinInventory", 40));
            dgvCourses.RowHeadersVisible = false;
            dgvCourses.DataSource = CLRData.BLCourses;

        }
        private void InitSectionInventory()
        {
            dgvSections.AutoGenerateColumns = false;
            dgvSections.Columns.Clear();
            dgvSections.Columns.Add(CreateColumn("ID", "ID", "ID", 40));
            dgvSections.Columns.Add(CreateColumn("Abbr", "Abbr", "Abbreviation", 146));
            dgvSections.Columns.Add(CreateColumn("Inventory", "Inv", "Inventory", 40));
            dgvSections.RowHeadersVisible = false;

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
            SelectCourseRow("");
            SelectCourseRow("");
            tbxName.Focus();

        }
        private void cmdNewSection_Click(object sender, EventArgs e)
        {
            TempSections.Add(new CLRCore.Section(TempSections.Count + 1, "", ""));
            SelectSectionRow("");
            SelectSectionRow("");
            tbxSectionName.Focus();

        }
        #endregion Command Buttons

        private void LoadCourse(Course c)
        {
            SelectedCourse = c;
            cbxPrereq.Items.Clear();
            cbxPrereq.Text = "";
            if (c == null)
            {
                tbxName.Text = "";
                tbxAbbr.Text = "";
                tbxMinAge.Text = "0";
                tbxMaxAge.Text = "120";
                tbxLink.Text = "";
                rbxDescription.Text = "";
                cbxShowDeprecated.Checked = false;
                TempSections = new BindingList<Section>();
                foreach (Course co in CLRData.BLCourses) if(co.Name != tbxName.Text) cbxPrereq.Items.Add(co.Name);
            }
            else
            {
                tbxName.Text = SelectedCourse.Name;
                tbxAbbr.Text = SelectedCourse.Abbreviation;
                tbxMinAge.Text = SelectedCourse.MinAge.ToString();
                tbxMaxAge.Text = SelectedCourse.MaxAge.ToString();
                tbxLink.Text = SelectedCourse.Link;
                rbxDescription.Text = SelectedCourse.Description;
                cbxShowDeprecated.Checked = SelectedCourse.Deprecated;
                TempSections = SelectedCourse.CopySections();
                foreach (Course co in CLRData.BLCourses) if (co.Name != tbxName.Text) cbxPrereq.Items.Add(co.Name);
                if (SelectedCourse.Prerequisites != null) cbxPrereq.Text = SelectedCourse.Prerequisites.Name; 
            }
            dgvSections.DataSource = TempSections;

        }
        private void LoadSection(Section s)
        {
            SelectedSection = s;
            if (s == null)
            {
                tbxSectionName.Text = "";
                tbxSectionAbbr.Text = "";
                tbxInventory.Text = "";
            }
            else
            {
                tbxSectionName.Text = SelectedSection.Name;
                tbxSectionAbbr.Text = SelectedSection.Abbreviation;
                tbxInventory.Text = SelectedSection.Inventory.ToString();
                tbxInvLocations.Text = SelectedSection.InventoryLocations;
            }
        }

        private void dgvCourses_SelectionChanged(object sender, EventArgs e)
        {
            SelectedCourse = (Course)dgvCourses.CurrentRow.DataBoundItem;
            LoadCourse(SelectedCourse);
            gbxCourseDescription.Enabled = true;
        }
        private void dgvSections_SelectionChanged(object sender, EventArgs e)
        {

            SelectedSection = (Section)dgvSections.CurrentRow.DataBoundItem;
            SetSectionEnbabled(SelectedSection != null);
            LoadSection(SelectedSection);
        }

        private void cmdSaveCourse_Click(object sender, EventArgs e)
        {
            SelectedCourse.Name = tbxName.Text;
            SelectedCourse.Abbreviation = tbxAbbr.Text;
            SelectedCourse.MinAge = int.Parse(tbxMinAge.Text);
            SelectedCourse.MaxAge = int.Parse(tbxMaxAge.Text);
            SelectedCourse.Link = tbxLink.Text;
            SelectedCourse.Description = rbxDescription.Text;
            SelectedCourse.Deprecated = cbxShowDeprecated.Checked;
            if (cbxPrereq.Text != "") SelectedCourse.Prerequisites = CLRData.GetCourse(cbxPrereq.Text);
            else SelectedCourse.Prerequisites = null;
            SelectedCourse.UpdateSections(TempSections);
            SelectCourseRow(SelectedCourse.Name);
        }
        private void SaveSection()
        {
            SelectedSection.Name = tbxSectionName.Text;
            SelectedSection.Abbreviation = tbxSectionAbbr.Text;
            SelectedSection.Inventory = int.Parse(tbxInventory.Text);
            SelectedSection.InventoryLocations = tbxInvLocations.Text;
            SelectSectionRow(SelectedSection.Name);
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void SelectCourseRow(string name)
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
                        break;
                    }
                }
            }
        }
        private void SelectSectionRow(string name)
        {
            dgvSections.ClearSelection();
            foreach (DataGridViewRow row in dgvSections.Rows)
            {
                Section s = (Section)row.DataBoundItem;
                if (s != null)
                {
                    if (s.Name == name)
                    {
                        row.Selected = true;
                        dgvSections.CurrentCell = dgvSections.Rows[row.Index].Cells[0];
                        break;
                    }
                }
            }
        }

        private void tbxName_Validating(object sender, CancelEventArgs e)
        {
            if (tbxName.Text == "")
            {
                tbxName.Select(0, tbxName.Text.Length);
                errorProvider1.SetError(tbxName, "Unique name is required.");
                e.Cancel = true;
            }
            if (CLRData.CourseNameExists(tbxName.Text) && tbxName.Text != SelectedCourse.Name)
            {
                tbxName.Select(0, tbxName.Text.Length);
                errorProvider1.SetError(tbxName, "Name provided is not unique.");
                e.Cancel = true;
            }
            return;
        }
        private void tbxSectionName_Validating(object sender, CancelEventArgs e)
        {
            if (tbxSectionName.Text == "")
            {
                tbxSectionName.Select(0, tbxSectionName.Text.Length);
                errorProvider1.SetError(tbxSectionName, "Unique name is required.");
                e.Cancel = true;
            }
            if (!SectionNameUnique(tbxSectionName.Text))
            {
                tbxSectionName.Select(0, tbxSectionName.Text.Length);
                errorProvider1.SetError(tbxSectionName, "Name provided is not unique.");
                e.Cancel = true;
            }
            return;
        }
        private void tbxAbbr_Validating(object sender, CancelEventArgs e)
        {
            if (tbxAbbr.Text == "")
            {
                tbxAbbr.Select(0, tbxAbbr.Text.Length);
                errorProvider1.SetError(tbxAbbr, "Unique abbreviation is required.");
                e.Cancel = true;
            }
            if (CLRData.CourseAbbrExists(tbxAbbr.Text) && tbxAbbr.Text != SelectedCourse.Abbreviation)
            {
                tbxAbbr.Select(0, tbxAbbr.Text.Length);
                errorProvider1.SetError(tbxAbbr, "Abbreviation provided is not unique.");
                e.Cancel = true;
            }
            return;
        }
        private void tbxSectionAbbr_Validating(object sender, CancelEventArgs e)
        {
            if (tbxSectionAbbr.Text == "")
            {
                tbxSectionAbbr.Select(0, tbxSectionAbbr.Text.Length);
                errorProvider1.SetError(tbxSectionAbbr, "Unique abbreviation is required.");
                e.Cancel = true;
            }
            if (!SectionAbbrUnique(tbxSectionAbbr.Text))
            {
                tbxSectionAbbr.Select(0, tbxSectionAbbr.Text.Length);
                errorProvider1.SetError(tbxSectionAbbr, "Abbreviation provided is not unique.");
                e.Cancel = true;
            }
            return;
        }

        private void tbxMinAge_Validating(object sender, CancelEventArgs e)
        {
            int maxage = 99;
            int minage = 0;
            int.TryParse(tbxMaxAge.Text, out maxage);
            if (!int.TryParse(tbxMinAge.Text, out minage))
            {
                tbxMinAge.Select(0, tbxMinAge.Text.Length);
                errorProvider1.SetError(tbxMinAge, "Age provided is not a valid number.");
                e.Cancel = true;
            }
            if (minage < 0)
            {
                tbxMinAge.Select(0, tbxMinAge.Text.Length);
                errorProvider1.SetError(tbxMinAge, "Min age provided is negative.");
                e.Cancel = true;
            }
            if (minage > maxage)
            {
                tbxMinAge.Select(0, tbxMinAge.Text.Length);
                errorProvider1.SetError(tbxMinAge, "Min age must be less than max age.");
                e.Cancel = true;
            }
        }
        private void tbxInventory_Validating(object sender, CancelEventArgs e)
        {
            int inv = 0;
            
            if (!int.TryParse(tbxInventory.Text, out inv))
            {
                tbxInventory.Select(0, tbxInventory.Text.Length);
                errorProvider1.SetError(tbxInventory, "Inventory provided is not a valid number.");
                e.Cancel = true;
            }
            if (inv < 0)
            {
                tbxInventory.Select(0, tbxInventory.Text.Length);
                errorProvider1.SetError(tbxInventory, "Inventory provided is negative.");
                e.Cancel = true;
            }
        }
        private void tbxMaxAge_Validating(object sender, CancelEventArgs e)
        {
            int maxage = 99;
            int minage = 0;
            int.TryParse(tbxMinAge.Text, out minage);
            if (!int.TryParse(tbxMaxAge.Text, out maxage))
            {
                tbxMaxAge.Select(0, tbxMaxAge.Text.Length);
                errorProvider1.SetError(tbxMaxAge, "Max age provided is not a valid number.");
                e.Cancel = true;
            }
            if (maxage <= 0)
            {
                tbxMaxAge.Select(0, tbxMaxAge.Text.Length);
                errorProvider1.SetError(tbxMaxAge, "Max age provided is not positive.");
                e.Cancel = true;
            }
            if (minage > maxage)
            {
                tbxMaxAge.Select(0, tbxMaxAge.Text.Length);
                errorProvider1.SetError(tbxMaxAge, "Max age must be greater than or equal min age.");
                e.Cancel = true;
            }
            return;
        }
  
        private void CourseDetail_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, "");
            cmdSaveCourse.Enabled = true;
        }
        private void SectionDetail_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError((Control)sender, "");
            cmdSaveCourse.Enabled = true;
            SaveSection();
        }

        private void cmdMoveUp_Click(object sender, EventArgs e)
        {
            Section s = (Section)dgvSections.CurrentRow.DataBoundItem;
            int id = s.ID;
            if (id != 1)
            {
                BindingList<Section> tmp = new BindingList<CLRCore.Section>();
                TempSections[id - 2].ID++;
                TempSections[id - 1].ID--;
                for (int i = 1; i <= TempSections.Count; i++)
                {
                    if (i == id - 1)
                    {
                        tmp.Add(TempSections[i]);
                    }
                    else if (i == id)
                    {
                        tmp.Add(TempSections[i - 2]);
                    }
                    else
                    {
                        tmp.Add(TempSections[i - 1]);
                    }
                }
                TempSections = tmp;
                dgvSections.DataSource = TempSections;
                SelectSectionRow(s.Name);
            }
        }
        private void cmdMoveDown_Click(object sender, EventArgs e)
        {
            Section s = (Section)dgvSections.CurrentRow.DataBoundItem;
            int id = s.ID;
            if (id != TempSections.Count)
            {
                BindingList<Section> tmp = new BindingList<CLRCore.Section>();
                TempSections[id - 1].ID++;
                TempSections[id].ID--;
                for (int i = 1; i<= TempSections.Count; i++)
                {
                    if(i == id)
                    {
                        tmp.Add(TempSections[i]);
                    }
                    else if (i == id+1)
                    {
                        tmp.Add(TempSections[i - 2]);
                    }
                    else
                    {
                        tmp.Add(TempSections[i - 1]);
                    }
                }
                TempSections = tmp;
                dgvSections.DataSource = TempSections;
                SelectSectionRow(s.Name);
            }
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            Section s = (Section)dgvSections.CurrentRow.DataBoundItem;
            BindingList<Section> tmp = new BindingList<CLRCore.Section>();
            for (int i = 1; i <= TempSections.Count; i++)
            {
                if (i != s.ID)
                {
                    if (i > s.ID)
                    {
                        TempSections[i - 1].ID--;
                    }
                    tmp.Add(TempSections[i - 1]);
                }
            }
            TempSections = tmp;
            dgvSections.DataSource = TempSections;
            if (TempSections.Count == 0) SetSectionEnbabled(false);

        }
        private bool SectionNameUnique(string name)
        {
            foreach(Section s in TempSections)
            {
                if (s.Name == name) return false;
            }
            return true;
        }
        private bool SectionAbbrUnique(string abbr)
        {
            foreach (Section s in TempSections)
            {
                if (s.Abbreviation == abbr) return false;
            }
            return true;
        }


        private void tbxInvLocations_Validating(object sender, CancelEventArgs e)
        {

        }

        private void SetSectionEnbabled(bool enabled)
        {
            tbxSectionName.Enabled = enabled;
            tbxSectionAbbr.Enabled = enabled;
            tbxInventory.Enabled = enabled;
            tbxInvLocations.Enabled = enabled;

        }

        private void miOpen_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CLRData = CLRFileOps.OpenFile(openFileDialog1.FileName);
                    CLRData.FixPrereqRef();
                    dgvCourses.DataSource = CLRData.BLCourses;
                    CurrentFile = openFileDialog1.FileName;
                    this.Text = "Caribbean Radio Light House Correspondence Program [" + CurrentFile + "]";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Read Failed: " + ex.Message);
                }
            }
        }
    

        private void miSave_Click(object sender, EventArgs e)
        {
                try
                {
                    CLRFileOps.SaveFile(CurrentFile, CLRData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Save Failed: " + ex.Message);
                }
        }

        private void miSaveAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CLRFileOps.SaveFile(saveFileDialog1.FileName, CLRData);
                    CurrentFile = saveFileDialog1.FileName;
                    this.Text = "Caribbean Radio Light House Correspondence Program [" + CurrentFile + "]";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Save Failed: " + ex.Message);
                }
            }
        }
    }
}
