using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayTracker
{
    public partial class Hours : Form
    {
        public Hours()
        {
            InitializeComponent();
        }

        private void startUp()
        {
            dtpDate.MinDate = DateTime.Today.AddYears(-99);
            dtpDate.MaxDate = DateTime.Today;
            dtpDate.Text = DateTime.Today.ToString();
            dtpDate.CustomFormat = "MM/dd/yyyy";
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpStart.CustomFormat = "HH:mm";
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpFinish.CustomFormat = "HH:mm";
            dtpFinish.Format = DateTimePickerFormat.Custom;

        }

        private void Hours_Load(object sender, EventArgs e)
        {
            startUp();
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            dtpStart.ValueChanged += dtpStart_ValueChanged;
            dtpFinish.ValueChanged += dtpFinish_ValueChanged;
            FormClosing += Hours_FormClosing;
        }

        void dtpFinish_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{Right}");
        }

        void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{Right}");
        }

        void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{Right}");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmdHours_Click(object sender, EventArgs e)
        {
            
        }

        private void cmdPaid_Click(object sender, EventArgs e)
        {

        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {

        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {

        }

        private void cmdBack_Click(object sender, EventArgs e)
        {         
            Start s = new Start();
            s.Show();
            this.Hide();
        }
        private void Hours_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                return;
            }
            if (System.Windows.Forms.MessageBox.Show(" Do you want to quit?          ", "Quit...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
                Dispose(true);

            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
