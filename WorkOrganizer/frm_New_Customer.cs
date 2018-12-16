using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WorkOrganizer.Data;

namespace WorkOrganizer
{
    public partial class frm_New_Customer : Form
    {
        private bool _canClose = true;

        public frm_New_Customer()
        {
            InitializeComponent();
        }

        private void bnt_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frm_New_Customer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_canClose;
        }

        private void frm_New_Customer_Shown(object sender, EventArgs e)
        {
            Data.Street.SetUpDebugData();

            //here we need to build the street list
            this.cb_Street.Items.Clear();
            foreach (Street s in Street.Streets)
                this.cb_Street.Items.Add($"{s.Name}, {s.Area}");

          //  this.cb_Street.Items.Add("Add New Street");
        }

        //here we save the customer
        private void button1_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer()
            {
                FName = txt_FName.Text,
                SName = txt_SName.Text,
                HouseName = txt_HouseNo.Text,
                StreetId = cb_Street.SelectedIndex,
                // pri

            };
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txt_Price_TextChanged(object sender, EventArgs e)
        {

        }

        private void cb_Job_Type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }
    }
}
