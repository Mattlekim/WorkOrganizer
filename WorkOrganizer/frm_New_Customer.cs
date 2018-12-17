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

        private Customer _newCustomer;

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

        //loading all data when the form is shown
        private void frm_New_Customer_Shown(object sender, EventArgs e)
        {
            //create a black customer
            _newCustomer = new Customer();
            lv_Customer_Jobs.Items.Clear();
            //load config file
            Config.Load();

            lb_Job_Types.Items.Clear();
            lb_Job_Types.Items.AddRange(JobType.GetData().ToArray());

            Data.Street.SetUpDebugData();

            

            //here we need to build the street list
            this.cb_Street.Items.Clear();
            foreach (Street s in Street.Streets)
                this.cb_Street.Items.Add($"{s.Name}, {s.Area}");

          //  this.cb_Street.Items.Add("Add New Street");
        }

        //here we save the customer
        private void bnt_Save_Customer_Click(object sender, EventArgs e)
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

        private void bnt_Add_Job_Click(object sender, EventArgs e)
        {
            if (!JobType.IsValid((string)lb_Job_Types.SelectedItem))
            {
                MessageBox.Show("Please select a Job", "Error");
                return;
            }

            float price = 0;
            try
            {
                price = (float)Convert.ToDecimal(txt_Price.Text);
            }
            catch
            {
                MessageBox.Show("Price Must be Set", "Error");
                return;
            }

            int frequency = 0;
            //if the job is repeatable
            if (cb_Repeat.Text == "Yes")
            {
                try
                {
                    frequency = Convert.ToInt32(txt_Frequncy.Text);
                }
                catch
                {
                    MessageBox.Show("Frequency must be Set", "Error");
                    return;
                }
                if (frequency <= 0)
                    MessageBox.Show("Frequency must be greater than 0", "Error");
            }

            _newCustomer.Jobs.Add(new Job((string)lb_Job_Types.SelectedItem, (Repeatable)cb_Repeat.SelectedIndex,
               frequency, price, txt_Job_Notes.Text));
            UpdateCustomerJobs();
        }

        private void UpdateCustomerJobs()
        {
            lv_Customer_Jobs.Items.Clear();

            foreach (Job job in _newCustomer.Jobs)
            {
                lv_Customer_Jobs.Items.Add(
                    new ListViewItem(new string[] {
                    (string)job.Type, job.RepeateJob.ToString(), job.Frequency.ToString(),
                        $"£{job.Price}", job.Notes})
                    {
                        Tag = job,
                    });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void cb_Repeat_SelectedValueChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Text == "Yes")
                txt_Frequncy.Enabled = true;
            else
                txt_Frequncy.Enabled = false;
        }

        private void cm_Right_Click_Jobs_Opening(object sender, CancelEventArgs e)
        {
            if (lv_Customer_Jobs.SelectedIndices.Count > 0)
                cm_Right_Click_Jobs.Enabled = true;
            else
                cm_Right_Click_Jobs.Enabled = false;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Job tmpJob = lv_Customer_Jobs.SelectedItems[0].Tag as Job;

            //now we load up the job
            lb_Job_Types.SelectedIndex = tmpJob.Type.GetIndex();
            txt_Price.Text = tmpJob.Price.ToString();
            cb_Repeat.SelectedIndex = (int)tmpJob.RepeateJob;
            txt_Frequncy.Text = tmpJob.Frequency.ToString();
            txt_Job_Notes.Text = tmpJob.Notes;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
