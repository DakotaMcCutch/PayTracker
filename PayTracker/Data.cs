using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using PayTracker.Properties;

namespace PayTracker
{
    public partial class Data : Form
    {
        private SqlConnection conn;
        private SqlDataAdapter da;
        private DataSet ds;
        private int rowIndex = -1;

        public Data()
        {
            InitializeComponent();
        }

        private void startUp()
        {
        }

        private void Data_Load(object sender, EventArgs e)
        {
            startUp();
            dg1.RowPostPaint += dg1_RowPostPaint;
            FormClosing += Data_FormClosing;
            dg1.Click += dg1_Click;
            setTheme();
            getData();
            populateGrid();
        }

        private void dg1_Click(object sender, EventArgs e)
        {
        }

        public void setTheme()
        {
            Button[] cmd = {cmdBack, cmdImport};
            BackColor = Settings.Default.backColor;
            ForeColor = Settings.Default.foreColor;
            foreach (var b in cmd)
            {
                b.ForeColor = Settings.Default.buttonForeColor;
            }
            dg1.ColumnHeadersDefaultCellStyle.BackColor = Settings.Default.headerBack;
            dg1.ColumnHeadersDefaultCellStyle.ForeColor = Settings.Default.headerFore;
            dg1.RowHeadersDefaultCellStyle.BackColor = Settings.Default.headerBack;
            dg1.RowHeadersDefaultCellStyle.ForeColor = Settings.Default.headerFore;
            dg1.RowHeadersDefaultCellStyle.SelectionBackColor = Settings.Default.selectionHeaderBack;
            dg1.RowHeadersDefaultCellStyle.SelectionForeColor = Settings.Default.selectionHeaderFore;
            dg1.DefaultCellStyle.BackColor = Settings.Default.cellBack;
            dg1.DefaultCellStyle.ForeColor = Settings.Default.cellFore;
            dg1.DefaultCellStyle.SelectionBackColor = Settings.Default.selectionCellBack;
            dg1.DefaultCellStyle.SelectionForeColor = Settings.Default.selectionCellFore;
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{Right}");
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            var s = new Start();
            s.Show();
            Hide();
        }

        public void formatGrid()
        {
            dg1.Sort(dg1.Columns["Date"], ListSortDirection.Ascending);
            dg1.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
            dg1.ClearSelection();
        }

        private bool validInfo()
        {
            return true;
        }

        private void Data_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                return;
            }
            if (
                MessageBox.Show(" Do you want to quit?          ", "Quit...", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Dispose(true);
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void cmdImport_Click(object sender, EventArgs e)
        {
            getFileData();
            dg1.ClearSelection();
        }

        private void getData()
        {
            string[] columns =
            {
                "Date", "Start", "Finish", "Hours", "Rate", "Pay", "Paid", "T-Hours", "T-Pay", "T-Paid",
                "Balance"
            };
            var connStr =
                "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Data.mdf;Integrated Security=True;";
            try
            {
                conn = new SqlConnection(connStr);
                //string sql = "SELECT [Date],[Start],[Finish] FROM [PayData]";
                var sql = "SELECT * FROM [PayData]"; //uncomment when uploading from file
                da = new SqlDataAdapter(sql, conn);
                var cb = new SqlCommandBuilder(da);
                ds = new DataSet();
                conn.Open();
                da.Fill(ds, "PayData");
                conn.Close();

                //bind and display
                bindingSource1.DataSource = ds;
                bindingSource1.DataMember = "PayData";
                dg1.DataSource = bindingSource1;
                for (var i = 0; i < columns.Length; i++)
                {
                    dg1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (i > 4)
                    {
                        dg1.Columns[i].DefaultCellStyle.Format = "N2";
                    }
                }
                dg1.Columns[0].ValueType = typeof (DateTime);
                formatGrid();
                populateGrid();
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

        private void dg1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                populateGrid();
            }
            else if (e.KeyCode == Keys.Tab)
            {
                populateGrid();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                populateGrid();
            }
        }

        private void populateGrid()
        {
            if (dg1.Rows.Count != 0)
            {
                var safety = dg1.Rows.Count;
                //dg1.Rows[dg1.Rows.Count - 1].Selected = true;
                dg1.CurrentCell = dg1.Rows[safety - 1].Cells[0];
                txtTHour.Text = string.Format(dg1.CurrentRow.Cells[7].Value.ToString(), "N2");
                txtTPay.Text = string.Format(dg1.CurrentRow.Cells[8].Value.ToString(), "N2");
                txtTPaid.Text = string.Format(dg1.CurrentRow.Cells[9].Value.ToString(), "N2");
                txtBalance.Text = string.Format(dg1.CurrentRow.Cells[10].Value.ToString(), "N2");
            }
        }

        private void dg1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (var b = new SolidBrush(dg1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b,
                    e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void clear()
        {
            txtTHour.Text = "";
            txtTPaid.Text = "";
            txtTPay.Text = "";
        }

        private void getFileData()
        {
            var connStr =
                "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Data.mdf;Integrated Security=True;Connect Timeout=30";
            conn = new SqlConnection(connStr);
            //string sql = "SELECT [Date],[Start],[Finish] FROM [PayData]";
            var sql = "SELECT * FROM [PayData]"; //uncomment when uploading from file
            da = new SqlDataAdapter(sql, conn);
            var cb = new SqlCommandBuilder(da);
            ds = new DataSet();
            conn.Open();
            da.Fill(ds, "PayData");
            conn.Close();

            //bind and display
            bindingSource1.DataSource = ds;
            bindingSource1.DataMember = "PayData";
            dg1.DataSource = bindingSource1;
            dg1.ClearSelection();
            var sr = new StreamReader("Pay.txt");
            var record = sr.ReadLine();
            while (record != null)
            {
                var temp = record.Split(',');
                try
                {
                    conn = new SqlConnection(connStr);
                    conn.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    sql = "SELECT [Date] FROM [PayData] WHERE [Date] = '" + temp[0] + "'";
                    cmd.CommandText = sql;
                    var dr = ds.Tables["PayData"].NewRow();
                    var dataReader = cmd.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        dataReader.Close();
                        conn.Close();
                    }
                    else
                    {
                        dr["Date"] = DateTime.ParseExact(temp[0], "yyyy/MM/dd", CultureInfo.InvariantCulture);
                        dr["Start"] = temp[1];
                        dr["Finish"] = temp[2];
                        dr["Hours"] = TimeSpan.FromHours(Convert.ToDouble(temp[3]));
                        dr["Rate"] = Convert.ToDouble(temp[4]);
                        dr["Pay"] = Convert.ToDouble(temp[5]);
                        dr["Paid"] = Convert.ToDouble(temp[6]);
                        dr["T-Hours"] = Convert.ToDouble(temp[7]);
                        dr["T-Pay"] = Convert.ToDouble(temp[8]);
                        dr["T-Paid"] = Convert.ToDouble(temp[9]);
                        dr["Balance"] = Convert.ToDouble(temp[10]);
                        dg1.Columns[0].ValueType = typeof (DateTime);
                        ds.Tables["PayData"].Rows.Add(dr);
                        da.Update(ds, "PayData");
                        formatGrid();
                        populateGrid();
                        dg1.ClearSelection();
                    }
                }
                catch (SqlException ex)
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                    MessageBox.Show(ex.Message, "Error Reading Data");
                }
                record = sr.ReadLine();
            }
            sr.Close();
        }
    }
}