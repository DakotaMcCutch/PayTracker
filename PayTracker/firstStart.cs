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
    public partial class firstStart : Form
    {
        public firstStart()
        {
            InitializeComponent();
            setTheme();
            FormClosing += firstStart_FormClosing;
        }

        void firstStart_FormClosing(object sender, FormClosingEventArgs e)
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

        public void setTheme()
        {
            Button[] cmd = { cmdLocal, cmdMySql};
            this.BackColor = Properties.Settings.Default.backColor;
            this.ForeColor = Properties.Settings.Default.foreColor;
            foreach (Button b in cmd)
            {
                b.ForeColor = Properties.Settings.Default.buttonForeColor;
            }
        }

        private void cmdLocal_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DatabaseType = "Local";
            Properties.Settings.Default.FirstStart = false;
            this.Hide();
            Start s = new Start();
            s.Show();
            

        }

        private void cmdMySql_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DatabaseType = "MySql";
            Properties.Settings.Default.FirstStart = false;
            this.Hide();
            Start s = new Start();
            s.Show();
        }
    }
}
