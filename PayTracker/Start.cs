using System;
using System.Drawing;
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
            cbTheme.SelectedValueChanged += cbTheme_SelectedValueChanged;
            cbTheme.SelectedItem = Properties.Settings.Default.lastSelect;
            setTheme();
           
        }

        private void startUp()
        {
            bool fStart = Properties.Settings.Default.FirstStart;
            if (fStart == true)
            {

                firstStart fs = new firstStart();
                this.Hide();

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
                Properties.Settings.Default.backColor = Color.Black;
                Properties.Settings.Default.foreColor = Color.GreenYellow;
                Properties.Settings.Default.lastSelect = cbTheme.SelectedItem.ToString();
                Properties.Settings.Default.buttonForeColor = Color.Black;
                Properties.Settings.Default.headerBack = Color.Black;
                Properties.Settings.Default.headerFore = Color.GreenYellow;
                Properties.Settings.Default.selectionHeaderBack = Color.Firebrick;
                Properties.Settings.Default.selectionHeaderFore = Color.Yellow;
                Properties.Settings.Default.cellBack = Color.Black;
                Properties.Settings.Default.cellFore = Color.GreenYellow;
                Properties.Settings.Default.selectionCellBack = Color.Firebrick;
                Properties.Settings.Default.selectionCellFore = Color.Yellow;
                Properties.Settings.Default.Save();
            }
            if (cbTheme.SelectedItem.ToString() == "Normal")
            {
                Properties.Settings.Default.backColor = SystemColors.Control;
                Properties.Settings.Default.foreColor = SystemColors.ControlText;
                Properties.Settings.Default.lastSelect = cbTheme.SelectedItem.ToString();
                Properties.Settings.Default.buttonForeColor = SystemColors.ControlText;
                Properties.Settings.Default.headerBack = SystemColors.Control;
                Properties.Settings.Default.headerFore = SystemColors.ControlText;
                Properties.Settings.Default.selectionHeaderBack = SystemColors.Highlight;
                Properties.Settings.Default.selectionHeaderFore = SystemColors.HighlightText;
                Properties.Settings.Default.cellBack = SystemColors.Window;
                Properties.Settings.Default.cellFore = SystemColors.ControlText;
                Properties.Settings.Default.selectionCellBack = SystemColors.Highlight;
                Properties.Settings.Default.selectionCellFore = SystemColors.HighlightText;
                Properties.Settings.Default.Save();
            }

            this.BackColor = Properties.Settings.Default.backColor;
            this.ForeColor = Properties.Settings.Default.foreColor;
            cmdHours.ForeColor = SystemColors.ControlText;
            cmdPaid.ForeColor = SystemColors.ControlText;
            cmdAll.ForeColor = SystemColors.ControlText;
            Properties.Settings.Default.Save();
        }

        private void Start_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                return;
            }
            if (System.Windows.Forms.MessageBox.Show(" Do you want to quit?          ", "Quit...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Properties.Settings.Default.Save();
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

        private void cmdAll_Click(object sender, EventArgs e)
        {
            this.Hide();
            Data d = new Data();
            d.Show();
        }
    }
}