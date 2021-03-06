﻿using System;
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
    public partial class DataImportInfo : Form
    {
        SortedSet<string> List;
        Boolean canceling = false;
        public DataImportInfo(SortedSet<string> list, string input, string context = "")
        {
            InitializeComponent();
            List = list;
            lblQuestion.Text = "The input data is '" + input + ".' Correct if neccessary. Context: " + context;
            foreach (string s in List)
            {
                cbxData.Items.Add(s);
            }
            cbxData.Text = input;
        }

        private void DataImportInfo_Load(object sender, EventArgs e)
        {

        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (cbxAdd.Checked && !List.Contains(cbxData.Text)) List.Add(cbxData.Text);
            this.Hide();
        }
        public string GetInput()
        {
            canceling = false;
            this.ShowDialog();
            if (canceling) return null;
            return cbxData.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            canceling = true;
            this.Hide();
        }
    }
}
