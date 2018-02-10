namespace CLRCore
{
    partial class Preferences
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
            this.cmdClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxTeenMinAge = new System.Windows.Forms.TextBox();
            this.tbxTeenMaxAge = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxAdultMinAge = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.tbxActiveMemberDays = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxLabelName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxFontSize = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxMxCharLength = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(278, 221);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 0;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Teen Min Age";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbxTeenMinAge
            // 
            this.tbxTeenMinAge.Location = new System.Drawing.Point(92, 6);
            this.tbxTeenMinAge.Name = "tbxTeenMinAge";
            this.tbxTeenMinAge.Size = new System.Drawing.Size(42, 20);
            this.tbxTeenMinAge.TabIndex = 2;
            // 
            // tbxTeenMaxAge
            // 
            this.tbxTeenMaxAge.Location = new System.Drawing.Point(92, 30);
            this.tbxTeenMaxAge.Name = "tbxTeenMaxAge";
            this.tbxTeenMaxAge.Size = new System.Drawing.Size(42, 20);
            this.tbxTeenMaxAge.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Teen Max Age";
            // 
            // tbxAdultMinAge
            // 
            this.tbxAdultMinAge.Location = new System.Drawing.Point(92, 56);
            this.tbxAdultMinAge.Name = "tbxAdultMinAge";
            this.tbxAdultMinAge.Size = new System.Drawing.Size(42, 20);
            this.tbxAdultMinAge.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Adult Min Age";
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(197, 221);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 7;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // tbxActiveMemberDays
            // 
            this.tbxActiveMemberDays.Location = new System.Drawing.Point(92, 82);
            this.tbxActiveMemberDays.Name = "tbxActiveMemberDays";
            this.tbxActiveMemberDays.Size = new System.Drawing.Size(42, 20);
            this.tbxActiveMemberDays.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 41);
            this.label4.TabIndex = 8;
            this.label4.Text = "Active Member Cutoff (Days)";
            // 
            // tbxLabelName
            // 
            this.tbxLabelName.Location = new System.Drawing.Point(92, 109);
            this.tbxLabelName.Name = "tbxLabelName";
            this.tbxLabelName.Size = new System.Drawing.Size(243, 20);
            this.tbxLabelName.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Label Name";
            // 
            // tbxFontSize
            // 
            this.tbxFontSize.Location = new System.Drawing.Point(254, 9);
            this.tbxFontSize.Name = "tbxFontSize";
            this.tbxFontSize.Size = new System.Drawing.Size(42, 20);
            this.tbxFontSize.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(174, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Label Font Size";
            // 
            // tbxMxCharLength
            // 
            this.tbxMxCharLength.Location = new System.Drawing.Point(254, 30);
            this.tbxMxCharLength.Name = "tbxMxCharLength";
            this.tbxMxCharLength.Size = new System.Drawing.Size(42, 20);
            this.tbxMxCharLength.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(174, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 31);
            this.label7.TabIndex = 14;
            this.label7.Text = "Label Max Char Length";
            // 
            // Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 266);
            this.Controls.Add(this.tbxMxCharLength);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbxFontSize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbxLabelName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxActiveMemberDays);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.tbxAdultMinAge);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxTeenMaxAge);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxTeenMinAge);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdClose);
            this.Name = "Preferences";
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.Preferences_Load);
            this.Shown += new System.EventHandler(this.Preferences_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxTeenMinAge;
        private System.Windows.Forms.TextBox tbxTeenMaxAge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxAdultMinAge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.TextBox tbxActiveMemberDays;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxLabelName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxFontSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxMxCharLength;
        private System.Windows.Forms.Label label7;
    }
}