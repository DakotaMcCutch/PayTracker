using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PayTracker
{
    public partial class Paid : Form
    {
        private MySqlConnection conn = null;
        private MySqlDataAdapter da = null;
        private DataSet ds = null;
        private int rowIndex = -1;
        private string date = "";
        private TimeSpan start;
        private TimeSpan finish;
        private double rate = 0.0;
        private TimeSpan hours;
        private double pay = 0.0;
        private double paid = 0.0;
        private double totalHours;
        private double totalPay = 0.0;
        private double totalPaid = 0.0;
        private double balance = 0.0;

        public Paid()
        {
            InitializeComponent();
        }

        private void startUp()
        {
            dtpDate.MinDate = DateTime.Today.AddYears(-99);
            dtpDate.MaxDate = DateTime.Today;
            dtpDate.Text = DateTime.Today.ToString();
            dtpDate.CustomFormat = "dd/MM/yyyy";
            dtpDate.Format = DateTimePickerFormat.Custom;
        }

        private void Paid_Load(object sender, EventArgs e)
        {
            startUp();
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            dg1.RowPostPaint += dg1_RowPostPaint;
            FormClosing += Paid_FormClosing;
            dg1.Click += dg1_Click;
            setTheme();
            getData();
        }

        private void dg1_Click(object sender, EventArgs e)
        {
            populateGrid();
        }

        public void setTheme()
        {
            Button[] cmd = { cmdBack, cmdInsert, cmdUpdate, cmdDelete };
            this.BackColor = Properties.Settings.Default.backColor;
            this.ForeColor = Properties.Settings.Default.foreColor;
            foreach (Button b in cmd)
            {
                b.ForeColor = Properties.Settings.Default.buttonForeColor;
            }
            dg1.ColumnHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.headerBack;
            dg1.ColumnHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.headerFore;
            dg1.RowHeadersDefaultCellStyle.BackColor = Properties.Settings.Default.headerBack;
            dg1.RowHeadersDefaultCellStyle.ForeColor = Properties.Settings.Default.headerFore;
            dg1.RowHeadersDefaultCellStyle.SelectionBackColor = Properties.Settings.Default.selectionHeaderBack;
            dg1.RowHeadersDefaultCellStyle.SelectionForeColor = Properties.Settings.Default.selectionHeaderFore;
            dg1.DefaultCellStyle.BackColor = Properties.Settings.Default.cellBack;
            dg1.DefaultCellStyle.ForeColor = Properties.Settings.Default.cellFore;
            dg1.DefaultCellStyle.SelectionBackColor = Properties.Settings.Default.selectionCellBack;
            dg1.DefaultCellStyle.SelectionForeColor = Properties.Settings.Default.selectionCellFore;
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

        private void reCalc()
        {
            //dg1.Sort(dg1.Columns["Date"], ListSortDirection.Ascending);
            int safety = dg1.Rows.Count;
            dg1.Rows[safety - 1].Selected = true;
            for (int i = 0; i < dg1.Rows.Count; i++)
            {
                if ((i - 1) >= 0)
                {
                    totalHours = TimeSpan.Parse(dg1.Rows[i].Cells[3].Value.ToString()).TotalHours + Convert.ToDouble(dg1.Rows[i - 1].Cells[7].Value.ToString());
                    totalPay = Convert.ToDouble(dg1.Rows[i].Cells[5].Value.ToString()) + Convert.ToDouble(dg1.Rows[i - 1].Cells[8].Value.ToString());
                    totalPaid = Convert.ToDouble(dg1.Rows[i].Cells[6].Value.ToString()) + Convert.ToDouble(dg1.Rows[i - 1].Cells[9].Value.ToString());
                    balance = Convert.ToDouble(dg1.Rows[i].Cells[5].Value.ToString()) + Convert.ToDouble(dg1.Rows[i - 1].Cells[10].Value.ToString()) - Convert.ToDouble(dg1.Rows[i].Cells[6].Value.ToString());
                    if (validInfo())
                    {
                        if (validPrimary("u"))
                        {
                            DataRow dr = ds.Tables[0].Rows[i];
                            dr["T-Hours"] = totalHours;
                            dr["T-Pay"] = totalPay;
                            dr["T-Paid"] = totalPaid;
                            dr["Balance"] = balance;
                            da.Update(ds, "PayData");
                            formatGrid();
                            dg1.ClearSelection();
                        }
                    }
                    dg1.ClearSelection();
                }
                dg1.ClearSelection();
            }
        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            string[] columns = { "Date", "Start", "Finish", "Hours", "Rate", "Pay", "Paid", "T-Hours", "T-Rate", "T-Pay", "T-Paid", "Balance" };
            DateTimePicker[] dtp = { dtpDate, };
            ArrayList a = new ArrayList { date, start, finish, hours, rate, pay, paid, totalHours, totalPay, totalPaid };
            if (validInfo())
            {
                if (validPrimary("i"))
                {
                    string connStr = "id=Owner;persistsecurityinfo=True;database=Data;allowuservariables=True;pooling=False";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    string sql = "Select Date, Start, Finish FROM PayData WHERE Date = '" + dtpDate.Text.ToString() + "'AND [Paid]= '" + txtAmount.Text.ToString() + "'";
                    cmd.CommandText = sql;
                    DataRow dr = ds.Tables["PayData"].NewRow();
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        dataReader.Close();
                        conn.Close();
                    }
                    else
                    {
                        calc();
                        dr["Date"] = date;
                        dr["Start"] = start;
                        dr["Finish"] = finish;
                        dr["Hours"] = hours.TotalHours;
                        dr["Rate"] = rate;
                        dr["Pay"] = pay;
                        dr["Paid"] = paid;
                        dr["T-Hours"] = totalHours;
                        dr["T-Pay"] = totalPay;
                        dr["T-Paid"] = totalPaid;
                        dr["Balance"] = balance;

                        ds.Tables["PayData"].Rows.Add(dr);
                        da.Update(ds, "PayData");
                        clear();
                        setControlState("i");
                        formatGrid();
                        dg1.ClearSelection();
                        reCalc();
                    }
                }
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            string[] columns = { "Date", "Start", "Finish", "Hours", "Rate", "Pay", "Paid", "T-Hours", "T-Pay", "T-Paid", "Balance" };
            DateTimePicker[] dtp = { dtpDate };

            if (validInfo())
            {
                if (validPrimary("u"))
                {
                    DataRow dr = ds.Tables[0].Rows[rowIndex];
                    calc();
                    dr["Date"] = date;
                    dr["Start"] = start;
                    dr["Finish"] = finish;
                    dr["Hours"] = hours.TotalHours;
                    dr["Rate"] = rate;
                    dr["Pay"] = pay;
                    dr["Paid"] = paid;
                    dr["T-Hours"] = totalHours;
                    dr["T-Pay"] = totalPay;
                    dr["T-Paid"] = totalPaid;
                    dr["Balance"] = balance;
                    da.Update(ds, "PayData");
                    clear();
                    setControlState("i");
                    formatGrid();
                    dg1.ClearSelection();
                    reCalc();
                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this entry?", "Confirm Entry Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    ds.Tables[0].Rows[rowIndex].Delete();
                    da.Update(ds, "PayData");
                }
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("No Entry Selected!", "Delete Entry Error");
                return;
            }
            setControlState("i");
            formatGrid();
            dg1.ClearSelection();
            reCalc();
        }

        public void formatGrid()
        {
            dg1.Sort(dg1.Columns["Date"], ListSortDirection.Ascending);
            dg1.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private bool validInfo()
        {
            return true;
        }

        private bool validPrimary(string state)
        {
            if (state.Equals("i"))
            {
                for (int i = 0; i < dg1.Rows.Count; i++)
                {
                    if ((dtpDate.Text.Equals(dg1.Rows[i].Cells[0].Value.ToString())) && (txtAmount.Text.Equals(dg1.Rows[i].Cells[1].Value.ToString())))
                    {
                        MessageBox.Show("Entry Exists Already.", "Primary Key Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dtpDate.Focus();
                        return false;
                    }
                }
                return true;
            }
            else if (state.Equals("u"))
            {
                for (int i = 0; i < dg1.Rows.Count; i++)
                {
                    if (i != dg1.CurrentRow.Index)
                    {
                        if ((dtpDate.Text.Equals(dg1.Rows[i].Cells[0].Value.ToString())) && (txtAmount.Text.Equals(dg1.Rows[i].Cells[1].Value.ToString())))
                        {
                            MessageBox.Show("Entry Exists Already.", "Primary Key Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dtpDate.Focus();
                            return false;
                        }
                        else if ((dtpDate.Text.Equals("")) || (txtAmount.Text.Equals("")))
                        {
                            MessageBox.Show("No Entry Selected!", "Update Record Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (dtpDate.Text.Equals(""))
                            {
                                dtpDate.Focus();
                            }
                            if (txtAmount.Text.Equals(""))
                            {
                                txtAmount.Focus();
                            }
                            return false;
                        }
                    }
                }
            }
            return true;
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
            string[] columns = { "Date", "Start", "Finish", "Hours", "Rate", "Pay", "Paid", "T-Hours", "T-Pay", "T-Paid", "Balance" };
            string connStr = "id=Owner;persistsecurityinfo=True;database=Data;allowuservariables=True;pooling=False";
            try
            {
                conn = new MySqlConnection(connStr);
                //string sql = "SELECT Date,Start,Finish FROM PayData";
                string sql = "SELECT * FROM PayData"; //uncomment when uploading from file
                da = new MySqlDataAdapter(sql, conn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                ds = new DataSet();
                conn.Open();
                da.Fill(ds, "PayData");
                conn.Close();

                //bind and display
                bindingSource1.DataSource = ds;
                bindingSource1.DataMember = "PayData";
                dg1.DataSource = bindingSource1;
                for (int i = 0; i < columns.Length; i++)
                {
                    dg1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (i == 1 || i == 2 || i == 3 || i == 4)
                    {
                        dg1.Columns[i].Visible = false;
                    }
                    if (i > 4)
                    {
                        dg1.Columns[i].DefaultCellStyle.Format = "N2";
                    }
                }
                dg1.Columns[0].ValueType = typeof(DateTime);
                formatGrid();
                dg1.ClearSelection();
                setControlState("i");
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
                setControlState("i");
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
                dg1.CurrentRow.Selected = true;
                rowIndex = dg1.CurrentRow.Index;

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i].RowState != DataRowState.Deleted)
                    {
                        if (dg1.CurrentRow.Cells[0].Value.ToString().Equals(ds.Tables[0].Rows[i][0].ToString()))
                        {
                            rowIndex = i;
                            break;
                        }
                    }
                }
                dtpDate.Value = Convert.ToDateTime((dg1.CurrentRow.Cells[0].Value.ToString()));
                txtAmount.Text = dg1.CurrentRow.Cells[6].Value.ToString();
                setControlState("u/d");
            }
        }

        private void dg1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dg1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void calc()
        {
            int rowCount = Convert.ToInt32(dg1.Rows.Count);
            if (rowCount > 0)
            {
                rowCount = Convert.ToInt32(dg1.Rows.Count - 1);
            }
            if (rowCount <= 0)
            {
                date = dtpDate.Value.ToString("yyyy/MM/dd");
                start = new TimeSpan(0, 0, 0);
                finish = new TimeSpan(0, 0, 0);
                hours = finish - start;
                rate = 0.00;
                pay = 0.00;
                paid = Convert.ToDouble(txtAmount.Text.ToString());
                totalHours = hours.TotalHours;
                totalPay = pay;
                totalPaid = paid;
                balance = pay - paid;
            }
            else
            {
                date = dtpDate.Value.ToString("yyyy/MM/dd");
                start = new TimeSpan(0, 0, 0);
                finish = new TimeSpan(0, 0, 0);
                hours = start - finish;
                rate = 0.00;
                pay = 0.00;
                paid = Convert.ToDouble(txtAmount.Text.ToString());
                totalHours = hours.TotalHours;
                totalPay = pay;
                totalPaid = paid;
                balance = pay - paid;
            }
        }

        private void clear()
        {
            dtpDate.Text = DateTime.Today.ToString();
            txtAmount.Text = "0.00";
        }

        private void setControlState(string state)
        {
            if (state.Equals("i"))
            {
                clear();
                dtpDate.Enabled = true;
                lblInsertMessage.Text = "";
                cmdInsert.Enabled = true;
                cmdUpdate.Enabled = false;
                cmdDelete.Enabled = false;
                cmdUpdate.Hide();
                cmdDelete.Hide();
                cmdInsert.Show();
            }
            else if (state.Equals("u/d"))
            {
                dtpDate.Enabled = false;
                lblInsertMessage.Text = "Press Esc To Go Back To Insert Mode";
                cmdInsert.Enabled = false;
                cmdUpdate.Enabled = true;
                cmdDelete.Enabled = true;
                cmdUpdate.Show();
                cmdDelete.Show();
                cmdInsert.Hide();
            }
        }
    }
}