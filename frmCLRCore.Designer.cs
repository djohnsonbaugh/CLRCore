namespace CLRCore
{
    partial class frmCLRCore
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileImportData = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileExportData = new System.Windows.Forms.ToolStripMenuItem();
            this.tcData = new System.Windows.Forms.TabControl();
            this.tpMembers = new System.Windows.Forms.TabPage();
            this.tpCourses = new System.Windows.Forms.TabPage();
            this.gbxCourseDescription = new System.Windows.Forms.GroupBox();
            this.cmdAddInventory = new System.Windows.Forms.Button();
            this.gbxSections = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tbxInventory = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxSectionAbbr = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxSectionName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdMoveUp = new System.Windows.Forms.Button();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdMoveDown = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbxLink = new System.Windows.Forms.TextBox();
            this.llblLink = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rbxDescription = new System.Windows.Forms.RichTextBox();
            this.tbxMaxAge = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxMinAge = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxAbbr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxInventory = new System.Windows.Forms.GroupBox();
            this.cbxShowDeprecated = new System.Windows.Forms.CheckBox();
            this.cmdNewCourse = new System.Windows.Forms.Button();
            this.dgvCourses = new System.Windows.Forms.DataGridView();
            this.cmdSaveCourse = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1.SuspendLayout();
            this.tcData.SuspendLayout();
            this.tpCourses.SuspendLayout();
            this.gbxCourseDescription.SuspendLayout();
            this.gbxSections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbxInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(830, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFileImportData,
            this.miFileExportData});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(37, 20);
            this.miFile.Text = "File";
            // 
            // miFileImportData
            // 
            this.miFileImportData.Name = "miFileImportData";
            this.miFileImportData.Size = new System.Drawing.Size(146, 22);
            this.miFileImportData.Text = "Import Data...";
            // 
            // miFileExportData
            // 
            this.miFileExportData.Name = "miFileExportData";
            this.miFileExportData.Size = new System.Drawing.Size(146, 22);
            this.miFileExportData.Text = "Export Data...";
            // 
            // tcData
            // 
            this.tcData.Controls.Add(this.tpMembers);
            this.tcData.Controls.Add(this.tpCourses);
            this.tcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcData.Location = new System.Drawing.Point(0, 24);
            this.tcData.Name = "tcData";
            this.tcData.SelectedIndex = 0;
            this.tcData.Size = new System.Drawing.Size(830, 521);
            this.tcData.TabIndex = 1;
            // 
            // tpMembers
            // 
            this.tpMembers.Location = new System.Drawing.Point(4, 22);
            this.tpMembers.Name = "tpMembers";
            this.tpMembers.Padding = new System.Windows.Forms.Padding(3);
            this.tpMembers.Size = new System.Drawing.Size(822, 495);
            this.tpMembers.TabIndex = 0;
            this.tpMembers.Text = "Members";
            this.tpMembers.UseVisualStyleBackColor = true;
            // 
            // tpCourses
            // 
            this.tpCourses.Controls.Add(this.gbxCourseDescription);
            this.tpCourses.Controls.Add(this.gbxInventory);
            this.tpCourses.Location = new System.Drawing.Point(4, 22);
            this.tpCourses.Name = "tpCourses";
            this.tpCourses.Padding = new System.Windows.Forms.Padding(3);
            this.tpCourses.Size = new System.Drawing.Size(822, 495);
            this.tpCourses.TabIndex = 1;
            this.tpCourses.Text = " Courses";
            this.tpCourses.UseVisualStyleBackColor = true;
            // 
            // gbxCourseDescription
            // 
            this.gbxCourseDescription.Controls.Add(this.cmdSaveCourse);
            this.gbxCourseDescription.Controls.Add(this.cmdAddInventory);
            this.gbxCourseDescription.Controls.Add(this.gbxSections);
            this.gbxCourseDescription.Controls.Add(this.tbxLink);
            this.gbxCourseDescription.Controls.Add(this.llblLink);
            this.gbxCourseDescription.Controls.Add(this.label6);
            this.gbxCourseDescription.Controls.Add(this.checkBox1);
            this.gbxCourseDescription.Controls.Add(this.label5);
            this.gbxCourseDescription.Controls.Add(this.rbxDescription);
            this.gbxCourseDescription.Controls.Add(this.tbxMaxAge);
            this.gbxCourseDescription.Controls.Add(this.label4);
            this.gbxCourseDescription.Controls.Add(this.tbxMinAge);
            this.gbxCourseDescription.Controls.Add(this.label3);
            this.gbxCourseDescription.Controls.Add(this.tbxAbbr);
            this.gbxCourseDescription.Controls.Add(this.label2);
            this.gbxCourseDescription.Controls.Add(this.tbxName);
            this.gbxCourseDescription.Controls.Add(this.label1);
            this.gbxCourseDescription.Location = new System.Drawing.Point(296, 6);
            this.gbxCourseDescription.Name = "gbxCourseDescription";
            this.gbxCourseDescription.Size = new System.Drawing.Size(523, 483);
            this.gbxCourseDescription.TabIndex = 1;
            this.gbxCourseDescription.TabStop = false;
            this.gbxCourseDescription.Text = "Selected Course Description";
            // 
            // cmdAddInventory
            // 
            this.cmdAddInventory.Location = new System.Drawing.Point(409, 209);
            this.cmdAddInventory.Name = "cmdAddInventory";
            this.cmdAddInventory.Size = new System.Drawing.Size(90, 23);
            this.cmdAddInventory.TabIndex = 15;
            this.cmdAddInventory.Text = "Add Inventory";
            this.cmdAddInventory.UseVisualStyleBackColor = true;
            // 
            // gbxSections
            // 
            this.gbxSections.Controls.Add(this.label10);
            this.gbxSections.Controls.Add(this.richTextBox1);
            this.gbxSections.Controls.Add(this.tbxInventory);
            this.gbxSections.Controls.Add(this.label9);
            this.gbxSections.Controls.Add(this.tbxSectionAbbr);
            this.gbxSections.Controls.Add(this.label8);
            this.gbxSections.Controls.Add(this.tbxSectionName);
            this.gbxSections.Controls.Add(this.label7);
            this.gbxSections.Controls.Add(this.cmdMoveUp);
            this.gbxSections.Controls.Add(this.cmdRemove);
            this.gbxSections.Controls.Add(this.cmdAdd);
            this.gbxSections.Controls.Add(this.cmdMoveDown);
            this.gbxSections.Controls.Add(this.dataGridView1);
            this.gbxSections.Location = new System.Drawing.Point(7, 233);
            this.gbxSections.Name = "gbxSections";
            this.gbxSections.Size = new System.Drawing.Size(510, 244);
            this.gbxSections.TabIndex = 14;
            this.gbxSections.TabStop = false;
            this.gbxSections.Text = "Course Sections";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(275, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Inventory Locations";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(278, 128);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(226, 110);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // tbxInventory
            // 
            this.tbxInventory.Location = new System.Drawing.Point(385, 76);
            this.tbxInventory.Name = "tbxInventory";
            this.tbxInventory.Size = new System.Drawing.Size(48, 20);
            this.tbxInventory.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(382, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Inventory";
            // 
            // tbxSectionAbbr
            // 
            this.tbxSectionAbbr.Location = new System.Drawing.Point(278, 76);
            this.tbxSectionAbbr.Name = "tbxSectionAbbr";
            this.tbxSectionAbbr.Size = new System.Drawing.Size(92, 20);
            this.tbxSectionAbbr.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(275, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Abbreviation";
            // 
            // tbxSectionName
            // 
            this.tbxSectionName.Location = new System.Drawing.Point(278, 37);
            this.tbxSectionName.Name = "tbxSectionName";
            this.tbxSectionName.Size = new System.Drawing.Size(226, 20);
            this.tbxSectionName.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(275, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Name";
            // 
            // cmdMoveUp
            // 
            this.cmdMoveUp.Location = new System.Drawing.Point(237, 21);
            this.cmdMoveUp.Name = "cmdMoveUp";
            this.cmdMoveUp.Size = new System.Drawing.Size(23, 23);
            this.cmdMoveUp.TabIndex = 5;
            this.cmdMoveUp.Text = "↑";
            this.cmdMoveUp.UseVisualStyleBackColor = true;
            // 
            // cmdRemove
            // 
            this.cmdRemove.Location = new System.Drawing.Point(237, 50);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(23, 23);
            this.cmdRemove.TabIndex = 4;
            this.cmdRemove.Text = "-";
            this.cmdRemove.UseVisualStyleBackColor = true;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(237, 79);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(23, 23);
            this.cmdAdd.TabIndex = 3;
            this.cmdAdd.Text = "+";
            this.cmdAdd.UseVisualStyleBackColor = true;
            // 
            // cmdMoveDown
            // 
            this.cmdMoveDown.Location = new System.Drawing.Point(237, 108);
            this.cmdMoveDown.Name = "cmdMoveDown";
            this.cmdMoveDown.Size = new System.Drawing.Size(23, 23);
            this.cmdMoveDown.TabIndex = 2;
            this.cmdMoveDown.Text = "↓";
            this.cmdMoveDown.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(225, 219);
            this.dataGridView1.TabIndex = 1;
            // 
            // tbxLink
            // 
            this.tbxLink.Location = new System.Drawing.Point(78, 75);
            this.tbxLink.Name = "tbxLink";
            this.tbxLink.Size = new System.Drawing.Size(421, 20);
            this.tbxLink.TabIndex = 5;
            // 
            // llblLink
            // 
            this.llblLink.AutoSize = true;
            this.llblLink.Location = new System.Drawing.Point(75, 75);
            this.llblLink.Name = "llblLink";
            this.llblLink.Size = new System.Drawing.Size(55, 13);
            this.llblLink.TabIndex = 12;
            this.llblLink.TabStop = true;
            this.llblLink.Text = "linkLabel1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Link";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(417, 48);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Deprecated";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Description";
            // 
            // rbxDescription
            // 
            this.rbxDescription.Location = new System.Drawing.Point(9, 125);
            this.rbxDescription.Name = "rbxDescription";
            this.rbxDescription.Size = new System.Drawing.Size(490, 78);
            this.rbxDescription.TabIndex = 6;
            this.rbxDescription.Text = "";
            // 
            // tbxMaxAge
            // 
            this.tbxMaxAge.Location = new System.Drawing.Point(334, 46);
            this.tbxMaxAge.Name = "tbxMaxAge";
            this.tbxMaxAge.Size = new System.Drawing.Size(43, 20);
            this.tbxMaxAge.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Max Age";
            // 
            // tbxMinAge
            // 
            this.tbxMinAge.Location = new System.Drawing.Point(233, 46);
            this.tbxMinAge.Name = "tbxMinAge";
            this.tbxMinAge.Size = new System.Drawing.Size(43, 20);
            this.tbxMinAge.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Min Age";
            // 
            // tbxAbbr
            // 
            this.tbxAbbr.Location = new System.Drawing.Point(78, 46);
            this.tbxAbbr.Name = "tbxAbbr";
            this.tbxAbbr.Size = new System.Drawing.Size(97, 20);
            this.tbxAbbr.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Abbreviation";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(78, 20);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(421, 20);
            this.tbxName.TabIndex = 0;
            this.tbxName.TextChanged += new System.EventHandler(this.tbxName_TextChanged);
            this.tbxName.Validating += new System.ComponentModel.CancelEventHandler(this.tbxName_Validating);
            this.tbxName.Validated += new System.EventHandler(this.tbxName_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // gbxInventory
            // 
            this.gbxInventory.Controls.Add(this.cbxShowDeprecated);
            this.gbxInventory.Controls.Add(this.cmdNewCourse);
            this.gbxInventory.Controls.Add(this.dgvCourses);
            this.gbxInventory.Location = new System.Drawing.Point(8, 6);
            this.gbxInventory.Name = "gbxInventory";
            this.gbxInventory.Size = new System.Drawing.Size(282, 486);
            this.gbxInventory.TabIndex = 0;
            this.gbxInventory.TabStop = false;
            this.gbxInventory.Text = "Course Inventory";
            // 
            // cbxShowDeprecated
            // 
            this.cbxShowDeprecated.AutoSize = true;
            this.cbxShowDeprecated.Location = new System.Drawing.Point(88, 463);
            this.cbxShowDeprecated.Name = "cbxShowDeprecated";
            this.cbxShowDeprecated.Size = new System.Drawing.Size(153, 17);
            this.cbxShowDeprecated.TabIndex = 2;
            this.cbxShowDeprecated.Text = "Show Deprecated Courses";
            this.cbxShowDeprecated.UseVisualStyleBackColor = true;
            // 
            // cmdNewCourse
            // 
            this.cmdNewCourse.Location = new System.Drawing.Point(6, 460);
            this.cmdNewCourse.Name = "cmdNewCourse";
            this.cmdNewCourse.Size = new System.Drawing.Size(75, 23);
            this.cmdNewCourse.TabIndex = 1;
            this.cmdNewCourse.Text = "Add Course";
            this.cmdNewCourse.UseVisualStyleBackColor = true;
            this.cmdNewCourse.Click += new System.EventHandler(this.cmdNewCourse_Click);
            // 
            // dgvCourses
            // 
            this.dgvCourses.AllowUserToOrderColumns = true;
            this.dgvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourses.Location = new System.Drawing.Point(6, 13);
            this.dgvCourses.MultiSelect = false;
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.ReadOnly = true;
            this.dgvCourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCourses.Size = new System.Drawing.Size(270, 443);
            this.dgvCourses.TabIndex = 0;
            this.dgvCourses.SelectionChanged += new System.EventHandler(this.dgvCourses_SelectionChanged);
            // 
            // cmdSaveCourse
            // 
            this.cmdSaveCourse.Location = new System.Drawing.Point(313, 209);
            this.cmdSaveCourse.Name = "cmdSaveCourse";
            this.cmdSaveCourse.Size = new System.Drawing.Size(90, 23);
            this.cmdSaveCourse.TabIndex = 16;
            this.cmdSaveCourse.Text = "Save Changes";
            this.cmdSaveCourse.UseVisualStyleBackColor = true;
            this.cmdSaveCourse.Click += new System.EventHandler(this.cmdSaveCourse_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmCLRCore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 545);
            this.Controls.Add(this.tcData);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmCLRCore";
            this.Text = "Caribbean Radio Light House Correspondence Program";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tcData.ResumeLayout(false);
            this.tpCourses.ResumeLayout(false);
            this.gbxCourseDescription.ResumeLayout(false);
            this.gbxCourseDescription.PerformLayout();
            this.gbxSections.ResumeLayout(false);
            this.gbxSections.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbxInventory.ResumeLayout(false);
            this.gbxInventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miFileImportData;
        private System.Windows.Forms.ToolStripMenuItem miFileExportData;
        private System.Windows.Forms.TabControl tcData;
        private System.Windows.Forms.TabPage tpMembers;
        private System.Windows.Forms.TabPage tpCourses;
        private System.Windows.Forms.GroupBox gbxInventory;
        private System.Windows.Forms.DataGridView dgvCourses;
        private System.Windows.Forms.GroupBox gbxCourseDescription;
        private System.Windows.Forms.TextBox tbxAbbr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxMaxAge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxMinAge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxLink;
        private System.Windows.Forms.LinkLabel llblLink;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rbxDescription;
        private System.Windows.Forms.GroupBox gbxSections;
        private System.Windows.Forms.Button cmdMoveDown;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button cmdMoveUp;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.TextBox tbxSectionAbbr;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxSectionName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox tbxInventory;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cmdAddInventory;
        private System.Windows.Forms.CheckBox cbxShowDeprecated;
        private System.Windows.Forms.Button cmdNewCourse;
        private System.Windows.Forms.Button cmdSaveCourse;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

