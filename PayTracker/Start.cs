using System;
using System.Drawing;
using System.Windows.Forms;
using PayTracker.Properties;

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
            cbTheme.SelectedValueChanged += cbTheme_SelectedValueChanged;
            cbTheme.SelectedItem = Settings.Default.lastSelect;
            setTheme();
        }

        private void startUp()
        {
            var fStart = Settings.Default.FirstStart;
            if (fStart)
            {
                var fs = new firstStart();
                Hide();

                fs.Show();
                //if (fs != null)
                //{
                //    this.Show();
                //}
            }
        }

        private void cbTheme_SelectedValueChanged(object sender, EventArgs e)
        {
            setTheme();
        }

        public void setTheme()
        {
            if (cbTheme.SelectedItem.ToString() == "Dark")
            {
                Settings.Default.backColor = Color.Black;
                Settings.Default.foreColor = Color.GreenYellow;
                Settings.Default.lastSelect = cbTheme.SelectedItem.ToString();
                Settings.Default.buttonForeColor = Color.Black;
                Settings.Default.headerBack = Color.Black;
                Settings.Default.headerFore = Color.GreenYellow;
                Settings.Default.selectionHeaderBack = Color.Firebrick;
                Settings.Default.selectionHeaderFore = Color.Yellow;
                Settings.Default.cellBack = Color.Black;
                Settings.Default.cellFore = Color.GreenYellow;
                Settings.Default.selectionCellBack = Color.Firebrick;
                Settings.Default.selectionCellFore = Color.Yellow;
                Settings.Default.Save();
            }
            if (cbTheme.SelectedItem.ToString() == "Normal")
            {
                Settings.Default.backColor = SystemColors.Control;
                Settings.Default.foreColor = SystemColors.ControlText;
                Settings.Default.lastSelect = cbTheme.SelectedItem.ToString();
                Settings.Default.buttonForeColor = SystemColors.ControlText;
                Settings.Default.headerBack = SystemColors.Control;
                Settings.Default.headerFore = SystemColors.ControlText;
                Settings.Default.selectionHeaderBack = SystemColors.Highlight;
                Settings.Default.selectionHeaderFore = SystemColors.HighlightText;
                Settings.Default.cellBack = SystemColors.Window;
                Settings.Default.cellFore = SystemColors.ControlText;
                Settings.Default.selectionCellBack = SystemColors.Highlight;
                Settings.Default.selectionCellFore = SystemColors.HighlightText;
                Settings.Default.Save();
            }

            BackColor = Settings.Default.backColor;
            ForeColor = Settings.Default.foreColor;
            cmdHours.ForeColor = SystemColors.ControlText;
            cmdPaid.ForeColor = SystemColors.ControlText;
            cmdAll.ForeColor = SystemColors.ControlText;
            Settings.Default.Save();
        }

        private void Start_FormClosing(object sender, FormClosingEventArgs e)
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

        private void cmdHours_Click(object sender, EventArgs e)
        {
            Hide();
            var h = new Hours();
            h.Show();
        }

        private void cmdPaid_Click(object sender, EventArgs e)
        {
            Hide();
            ;
            var p = new Paid();
            p.Show();
        }

        private void cmdAll_Click(object sender, EventArgs e)
        {
            Hide();
            var d = new Data();
            d.Show();
        }

        private void lblTop_Click(object sender, EventArgs e)
        {

        }
    }
}