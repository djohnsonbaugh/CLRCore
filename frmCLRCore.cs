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
        private Member SelectedMember;
        private BindingList<Section> TempSections;
        private BindingList<Member> Members;
        private BindingList<Course> Courses;
        private BindingList<CourseStateDisplay> CompletedCourses;
        private string CurrentFile;
        private string searchlock = "";
        public frmCLRCore()
        {
            InitializeComponent();
            LoadCLRCoreData(new CLRCoreData());
        }

        public void LoadCLRCoreData(CLRCoreData clrcd)
        {
            CLRData = clrcd;
            InitCourseInventory();
            InitSectionInventory();
            InitMembership();
            InitMemberDetailCombos();
            InitCompletedCourses();
            CLRData.MemberSearchComplete += MemberSearchEventHandler;
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
            UpdateCourses(CLRData.GetCourses("", cbxShowDeprecated.Checked));
        }
        private void UpdateCourses(BindingList<Course> courses)
        {
            Courses = courses;
            dgvCourses.DataSource = Courses;
        }
        private void cbxShowDeprecated_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCourses(CLRData.GetCourses("", cbxShowDeprecated.Checked));
        }
        private void InitSectionInventory()
        {
            dgvSections.AutoGenerateColumns = false;
            dgvSections.Columns.Clear();
            dgvSections.Columns.Add(CreateColumn("ID", "ID", "ID", 40));
            dgvSections.Columns.Add(CreateColumn("Name", "Name", "Name", 146));
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
            Course c = CLRData.CreateNewCourse();
            Courses.Add(c);
            SelectCourseRow(c.ID);
            SelectCourseRow(c.ID);
            tbxName.Focus();

        }
        private void cmdNewSection_Click(object sender, EventArgs e)
        {
            int id = TempSections.Count + 1;
            TempSections.Add(new CLRCore.Section(id, "Book " + id.ToString() , "Bk"+id.ToString()));
            SelectSectionRow("Book " + id.ToString());
            SelectSectionRow("Book " + id.ToString());
            tbxSectionName.Focus();

        }
        #endregion Command Buttons

        private void LoadCourse(Course c)
        {
            SelectedCourse = c;
            cbxPrereq.Items.Clear();
            cbxPrereq.Text = "";
            tbxName.Text = SelectedCourse.Name;
            tbxAbbr.Text = SelectedCourse.Abbreviation;
            tbxMinAge.Text = SelectedCourse.MinAge.ToString();
            tbxMaxAge.Text = SelectedCourse.MaxAge.ToString();
            tbxLink.Text = SelectedCourse.Link;
            rbxDescription.Text = SelectedCourse.Description;
            cbxAdultCourse.Checked = SelectedCourse.Adult;
            cbxDeprecated.Checked = SelectedCourse.Deprecated;
            TempSections = SelectedCourse.CopySections();
            foreach (Course co in Courses) if (co.Name != tbxName.Text) cbxPrereq.Items.Add(co);
            if (SelectedCourse.PrerequisiteID != -1) cbxPrereq.Text = CLRData.GetCourse(SelectedCourse.PrerequisiteID).Name;
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
            Course c = (Course)dgvCourses.CurrentRow.DataBoundItem;
            if (SelectedCourse ==  null) LoadCourse(c);
            if (SelectedCourse.ID != c.ID) LoadCourse(c);
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
            SelectedCourse.Adult = cbxAdultCourse.Checked;
            SelectedCourse.Deprecated = cbxDeprecated.Checked;
            if (cbxPrereq.SelectedItem != null) SelectedCourse.PrerequisiteID = ((Course)cbxPrereq.SelectedItem).ID;
            else SelectedCourse.PrerequisiteID = -1;
            SelectedCourse.UpdateSections(TempSections);
            SelectCourseRow(SelectedCourse.ID);
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

        private void SelectCourseRow(int id)
        {
            dgvCourses.ClearSelection();
            foreach (DataGridViewRow row in dgvCourses.Rows)
            {
                Course c = (Course)row.DataBoundItem;
                if (c != null)
                {
                    if (c.ID == id)
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
            if (!SectionNameUnique(tbxSectionName.Text) && tbxSectionName.Text != SelectedSection.Name)
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
            if (!SectionAbbrUnique(tbxSectionAbbr.Text) && tbxSectionAbbr.Text != SelectedSection.Abbreviation)
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
                for (int i = 1; i <= TempSections.Count; i++)
                {
                    if (i == id)
                    {
                        tmp.Add(TempSections[i]);
                    }
                    else if (i == id + 1)
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
            foreach (Section s in TempSections)
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
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CLRCoreData ccd = CLRFileOps.OpenFile(openFileDialog1.FileName);
                    //ccd.FixPrereqRef();
                    //dgvCourses.DataSource = ccd.BLCourses;
                    CurrentFile = openFileDialog1.FileName;
                    this.Text = "Caribbean Radio Light House Correspondence Program [" + CurrentFile + "]";
                    LoadCLRCoreData(ccd);
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

        private void tpMembers_Click(object sender, EventArgs e)
        {

        }

        #region Member Tab
        private void InitMembership()
        {
            gbxMemberDetails.Enabled = false;
            dgvMembers.AutoGenerateColumns = false;
            dgvMembers.Columns.Clear();
            dgvMembers.Columns.Add(CreateColumn("ID", "ID", "ID", 30));
            dgvMembers.Columns.Add(CreateColumn("First", "First", "FirstName", 74));
            dgvMembers.Columns.Add(CreateColumn("Last", "Last", "LastName", 74));
            dgvMembers.Columns.Add(CreateColumn("Age", "Age", "AgeorAdult", 32));
            dgvMembers.Columns.Add(CreateColumn("Country", "Country", "Country", 60));
            dgvMembers.RowHeadersVisible = false;
            UpdateMembership(CLRData.GetMembership("", cbxInactive.Checked));

        }
        private void InitCompletedCourses()
        {
            dgvCompletedCourses.AutoGenerateColumns = false;
            dgvCompletedCourses.Columns.Clear();
            dgvCompletedCourses.Columns.Add(CreateColumn("Name", "Name", "Name", 74));
            dgvCompletedCourses.Columns.Add(CreateColumn("Completed", "Completed", "CompletionDate", 74));
            dgvCompletedCourses.RowHeadersVisible = false;
        }
        private void UpdateMembership(BindingList<Member> members)
        {
            Members = members;
            dgvMembers.DataSource = Members;
        }
        private void InitMemberDetailCombos()
        {
            PopulateCombo(cbxCity, CLRData.Cities);
            PopulateCombo(cbxPerish, CLRData.Perishes);
            PopulateCombo(cbxCountry, CLRData.Countries);
            PopulateCombo(cbxChurch, CLRData.Churches);
            PopulateCombo(cbxDenomination, CLRData.Denominiations);
        }
        private void PopulateCombo(ComboBox cb, SortedSet<string> ss)
        {
            cb.Items.Clear();
            foreach (string s in ss) cb.Items.Add(s);
        }

        #endregion

        private void cmdAddMember_Click(object sender, EventArgs e)
        {
            Member m = CLRData.CreateNewMember();
            Members.Add(m);
            SelectMember(m.ID);
            SelectMember(m.ID);
            tbxFirstName.Focus();
        }
        private void SelectMember(int id)
        {
            dgvMembers.ClearSelection();
            foreach (DataGridViewRow row in dgvMembers.Rows)
            {
                Member m = (Member)row.DataBoundItem;
                if (m != null)
                {
                    if (m.ID == id)
                    {
                        row.Selected = true;
                        dgvMembers.CurrentCell = dgvMembers.Rows[row.Index].Cells[0];
                        break;
                    }
                }
            }
        }

        private void dgvMembers_SelectionChanged(object sender, EventArgs e)
        {
            Member m = (Member)dgvMembers.CurrentRow.DataBoundItem;
            if (SelectedMember == null) LoadMember(m);
            if (SelectedMember.ID != m.ID) LoadMember(m);
            gbxMemberDetails.Enabled = true;
        }

        private void LoadMember(Member m)
        {
            if (SelectedMember != null)
            {
                if (!AreMemberDetailsSaved())
                {
                    if (MessageBox.Show("Member details have not been saved! Would you like to save now?",
                                        "Unsaved Detail Warning!",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning,
                                        MessageBoxDefaultButton.Button1
                                        ) == DialogResult.Yes
                        )
                    {
                        SaveMemberDetails();
                    }

                }
            }
            SelectedMember = m;
            tbxFirstName.Text = m.FirstName;
            tbxLastName.Text = m.LastName;
            tbxMiddleName.Text = m.MiddleName;
            tbxSuffix.Text = m.Suffix;
            cbxAdult.Checked = m.Adult;
            cbxProfOfFaith.Checked = m.ProffessionOfFaith;
            dtpDoB.Value = m.DoB;
            dtpMembershipDate.Value = m.MembershipDate;
            tbxStreet.Text = m.Address.Street;
            cbxCity.Text = m.Address.City;
            cbxPerish.Text = m.Address.Perish;
            cbxCountry.Text = m.Address.Country;
            tbxZipCode.Text = m.Address.ZipCode;
            tbxCareOf.Text = m.Address.CareOf;
            cbxChurch.Text = m.Church;
            cbxDenomination.Text = m.Denominiation;
            UpdateCompletedCourses(m.ID);
        }
        private void UpdateCompletedCourses(int id)
        {
            CompletedCourses = CLRData.GetCompletedCourses(id);
            dgvCompletedCourses.DataSource = CompletedCourses;
        }
        private void MemberDetails_TextChanged(object sender, EventArgs e)
        {
            UpdateMemberDetailsStatus();
        }

        private bool AreMemberDetailsSaved()
        {
            if (tbxFirstName.Text != SelectedMember.FirstName) return false;
            if (tbxLastName.Text != SelectedMember.LastName) return false;
            if (tbxMiddleName.Text != SelectedMember.MiddleName) return false;
            if (tbxSuffix.Text != SelectedMember.Suffix) return false;
            if (cbxAdult.Checked != SelectedMember.Adult) return false;
            if (cbxProfOfFaith.Checked != SelectedMember.ProffessionOfFaith) return false;
            if (dtpDoB.Value != SelectedMember.DoB) return false;
            if (dtpMembershipDate.Value != SelectedMember.MembershipDate) return false;
            if (tbxStreet.Text != SelectedMember.Address.Street) return false;
            if (cbxCity.Text != SelectedMember.Address.City) return false;
            if (cbxPerish.Text != SelectedMember.Address.Perish) return false;
            if (cbxCountry.Text != SelectedMember.Address.Country) return false;
            if (tbxZipCode.Text != SelectedMember.Address.ZipCode) return false;
            if (tbxCareOf.Text != SelectedMember.Address.CareOf) return false;
            if (cbxChurch.Text != SelectedMember.Church) return false;
            if (cbxDenomination.Text != SelectedMember.Denominiation) return false;
            return true;
        }
        private void UpdateMemberDetailsStatus()
        {
            gbxMemberDetails.Text = (AreMemberDetailsSaved()) ? "Member Details" : "Member Details *MODIFIED*";
        }
        private void SaveMemberDetails()
        {
            SelectedMember.FirstName = tbxFirstName.Text;
            SelectedMember.LastName = tbxLastName.Text;
            SelectedMember.MiddleName = tbxMiddleName.Text;
            SelectedMember.Suffix = tbxSuffix.Text;
            SelectedMember.Adult = cbxAdult.Checked;
            SelectedMember.ProffessionOfFaith = cbxProfOfFaith.Checked;
            SelectedMember.DoB = dtpDoB.Value;
            SelectedMember.MembershipDate = dtpMembershipDate.Value;
            SelectedMember.Address.Street = tbxStreet.Text;
            SelectedMember.Address.City = cbxCity.Text;
            SelectedMember.Address.Perish = cbxPerish.Text;
            SelectedMember.Address.Country = cbxCountry.Text;
            SelectedMember.Address.ZipCode = tbxZipCode.Text;
            SelectedMember.Address.CareOf = tbxCareOf.Text;
            SelectedMember.Church = cbxChurch.Text;
            SelectedMember.Denominiation = cbxDenomination.Text;
            UpdateMemberDetailsStatus();
        }
        private void cmdSaveMember_Click(object sender, EventArgs e)
        {
            SaveMemberDetails();
            SelectMember(SelectedMember.ID);
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            lock (searchlock)
            {
                CLRData.AsyncGetMembership(tbxSearch.Text, cbxInactive.Checked);
            }
        }
        private void MemberSearchEventHandler(object sender, MemberSearchEventArgs msea)
        {
            if (InvokeRequired)
            {
                lock (searchlock)
                {
                    Invoke(new EventHandler<MemberSearchEventArgs>(MemberSearchEventHandler),
                        new object[] { sender, msea });
                }
            }
            else UpdateMembership(msea.Members);
        }

        private void dgvMembers_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Member m = (Member)e.Row.DataBoundItem;
            e.Cancel = (MessageBox.Show(string.Format("Are you sure you want to PERMANENTELY DELETE the member '[{2}] {0} {1}' from the membership?", m.FirstName, m.LastName, m.ID.ToString()), "Caution: Deleting Member in Progress!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel);
            if (!e.Cancel) CLRData.DeleteMember(m.ID);
        }
        private void dgvCompletedCourses_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            CourseStateDisplay csd = (CourseStateDisplay)e.Row.DataBoundItem;
            e.Cancel = (MessageBox.Show(string.Format("Are you sure you want to PERMANENTELY DELETE record of completed course '{3}' for member '[{2}] {0} {1}'?", SelectedMember.FirstName, SelectedMember.LastName, SelectedMember.ID.ToString(),csd.Name), "Caution: Deleting Member in Progress!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel);
            if (!e.Cancel) SelectedMember.DeleteCourseState(csd.ID);
        }


    }
}
