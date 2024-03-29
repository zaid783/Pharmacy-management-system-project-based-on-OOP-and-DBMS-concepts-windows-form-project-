﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_Managment.PharmacistUC
{
    public partial class UC_P_MedicineValidityCheck : UserControl
    {
        function fn = new function();
        String query;
        public UC_P_MedicineValidityCheck()
        {
            InitializeComponent();
        }

        private void txtCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtCheck.SelectedIndex == 0)
            {
                query = "Select * from medic where eDate >= getdate()";
                setDataGridView(query, "Valid Medicines", Color.Black);
            }
            else if(txtCheck.SelectedIndex == 1)
            {
                query = "Select * from medic where eDate <= getdate()";
                setDataGridView(query, "Expired Medicines", Color.Red);
            }
            else if (txtCheck.SelectedIndex == 2)
            {
                query = "Select * from medic";
                setDataGridView(query, "View All Medicines", Color.Black);
            }
        }
        private void setDataGridView(String query,String labelName,Color col)
        {
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
            setLabel.Text = labelName;
            setLabel.ForeColor = col;
        }

        private void UC_P_MedicineValidityCheck_Load(object sender, EventArgs e)
        {
            setLabel.Text = "";
        }
    }
}
