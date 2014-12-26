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
    public partial class Form1 : Form
    {
        public Form1()
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

        private void Form1_Load(object sender, EventArgs e)
        {
            startUp();
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            dtpStart.ValueChanged += dtpStart_ValueChanged;
            dtpFinish.ValueChanged += dtpFinish_ValueChanged;
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

    }
}
