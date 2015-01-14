using System;
using System.Collections.Generic;
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
            setTheme();
        }

        void cbTheme_SelectedValueChanged(object sender, EventArgs e)
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
            else if (cbTheme.SelectedItem == "Normal")
            {
                Properties.Settings.Default.backColor = default(Color);
                Properties.Settings.Default.foreColor = default(Color);
                Properties.Settings.Default.lastSelect = cbTheme.SelectedItem.ToString();
                Properties.Settings.Default.buttonForeColor = default(Color);
                Properties.Settings.Default.headerBack = default(Color);
                Properties.Settings.Default.headerFore = default(Color);
                Properties.Settings.Default.selectionHeaderBack = default(Color);
                Properties.Settings.Default.selectionHeaderFore = default(Color);
                Properties.Settings.Default.cellBack = default(Color);
                Properties.Settings.Default.cellFore = default(Color);
                Properties.Settings.Default.selectionCellBack = default(Color);
                Properties.Settings.Default.selectionCellFore = default(Color);
                Properties.Settings.Default.Save();
            }
            cbTheme.SelectedItem = Properties.Settings.Default.lastSelect;
            this.BackColor = Properties.Settings.Default.backColor;
            this.ForeColor = Properties.Settings.Default.foreColor;
            cmdHours.ForeColor = Color.Black;
            cmdPaid.ForeColor = Color.Black;
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
    }
}