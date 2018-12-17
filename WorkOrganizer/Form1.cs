using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WorkOrganizer.Data.DataBase;

namespace WorkOrganizer
{
    public partial class Form1 : Form
    {
        private CustomerDataBase _Customers;

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_New_Customer frmnew = new frm_New_Customer();
            frmnew.Tag = _Customers;
            frmnew.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
