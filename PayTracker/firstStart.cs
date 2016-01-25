using System;
using System.Windows.Forms;
using PayTracker.Properties;

namespace PayTracker
{
    public partial class firstStart : Form
    {
        public firstStart()
        {
            InitializeComponent();
        }

        private void firstStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                return;
            }
            if (
                MessageBox.Show(" Do you want to quit?          ", "Quit...", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Settings.Default.Save();
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
            Button[] cmd = {cmdLocal, cmdMySql};
            BackColor = Settings.Default.backColor;
            ForeColor = Settings.Default.foreColor;
            foreach (var b in cmd)
            {
                b.ForeColor = Settings.Default.buttonForeColor;
            }
        }

        private void cmdLocal_Click(object sender, EventArgs e)
        {
            Settings.Default.DatabaseType = "Local";
            Settings.Default.FirstStart = false;
            Settings.Default.Save();
            Hide();
            var s = new Start();
            s.Show();
        }

        private void cmdMySql_Click(object sender, EventArgs e)
        {
            Settings.Default.DatabaseType = "MySql";
            Settings.Default.FirstStart = false;
            Settings.Default.Save();
            Hide();
            var s = new Start();
            s.Show();
        }

        private void firstStart_Load(object sender, EventArgs e)
        {
            setTheme();
            FormClosing += firstStart_FormClosing;
        }
    }
}