using System;
using System.Windows.Forms;

namespace PayTracker
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void Start_Load(object sender, EventArgs e)
        {
            FormClosing += Start_FormClosing;
        }

        private void Start_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                return;
            }
            if (System.Windows.Forms.MessageBox.Show(" Do you want to quit?          ", "Quit...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Dispose(true);
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void cmdHours_Click(object sender, EventArgs e)
        {
            this.Hide();
            Hours h = new Hours();
            h.Show();
        }

        private void cmdPaid_Click(object sender, EventArgs e)
        {
            this.Hide(); ;
            Paid p = new Paid();
            p.Show();
        }
    }
}