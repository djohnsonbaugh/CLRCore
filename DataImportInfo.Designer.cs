namespace CLRCore
{
    partial class DataImportInfo
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
            this.cbxData = new System.Windows.Forms.ComboBox();
            this.cbxAdd = new System.Windows.Forms.CheckBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.cmdOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxData
            // 
            this.cbxData.FormattingEnabled = true;
            this.cbxData.Location = new System.Drawing.Point(12, 65);
            this.cbxData.Name = "cbxData";
            this.cbxData.Size = new System.Drawing.Size(237, 21);
            this.cbxData.TabIndex = 0;
            // 
            // cbxAdd
            // 
            this.cbxAdd.AutoSize = true;
            this.cbxAdd.Location = new System.Drawing.Point(13, 93);
            this.cbxAdd.Name = "cbxAdd";
            this.cbxAdd.Size = new System.Drawing.Size(80, 17);
            this.cbxAdd.TabIndex = 1;
            this.cbxAdd.Text = "Add To List";
            this.cbxAdd.UseVisualStyleBackColor = true;
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(13, 13);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(35, 13);
            this.lblQuestion.TabIndex = 2;
            this.lblQuestion.Text = "label1";
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(139, 93);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 23);
            this.cmdOk.TabIndex = 3;
            this.cmdOk.Text = "Ok";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // DataImportInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 141);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.cbxAdd);
            this.Controls.Add(this.cbxData);
            this.Name = "DataImportInfo";
            this.Text = "DataImportInfo";
            this.Load += new System.EventHandler(this.DataImportInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxData;
        private System.Windows.Forms.CheckBox cbxAdd;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Button cmdOk;
    }
}