using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_Managment.AddministratorUC
{
    public partial class UC_ViewUser : UserControl
    {
        function fn = new function();
        String query;
        String currentUser = "";
        public UC_ViewUser()
        {
            InitializeComponent();
        }

        public string ID
        {
            set { currentUser = value; }
        }

        private void UC_ViewUser_Load(object sender, EventArgs e)
        {
            query = "select * from users";
            DataSet ds= fn.getData(query);
            guna2DataGridView4.DataSource = ds.Tables[0];
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            query = "select * from users where username like '" + txtUsername.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView4.DataSource = ds.Tables[0];
        }

        String userName;
        private void guna2DataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                userName = guna2DataGridView4.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
            catch { }
        }
        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_ViewUser_Load(this, null);
        }
    }
}
