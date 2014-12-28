using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PayTracker
{
    public partial class Paid : Form
    {
        private SqlConnection conn = null;
        private SqlDataAdapter da = null;
        private DataSet ds = null;
        private SqlCommand cmd = null;
        public Paid()
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
        }

        private void Paid_Load(object sender, EventArgs e)
        {
            startUp();
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            FormClosing += Paid_FormClosing;
            getData();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{Right}");
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            Start s = new Start();
            s.Show();
            this.Hide();
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

        private void Paid_FormClosing(object sender, FormClosingEventArgs e)
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
        private void getData()
        {
            string connStr = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|Data.mdf;Integrated Security=True;";
            try
            {
                conn = new SqlConnection(connStr);
                string sql = "SELECT * FROM [PayData]";
                da = new SqlDataAdapter(sql, conn);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                ds = new DataSet();
                conn.Open();
                da.Fill(ds, "PayData");
                conn.Close();

                //bind and display
                bindingSource1.DataSource = ds;
                bindingSource1.DataMember = "PayData";
                dg1.DataSource = bindingSource1;
                dg1.ClearSelection();
            }
            catch (SqlException ex)
            {
                if (conn != null)
                {
                    conn.Close();
                }
                MessageBox.Show(ex.Message, "Error Reading Data");
            }
        }
    }
}