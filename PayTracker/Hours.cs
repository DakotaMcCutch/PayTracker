﻿using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace PayTracker
{
    public partial class Hours : Form
    {
        //private SqlConnection conn = null;
        //private SqlDataAdapter da = null;
        private MySqlConnection conn = null;
        private MySqlDataAdapter da = null;
        private DataSet ds = null;
        private int rowIndex = -1;
        private string date;
        private TimeSpan start;
        private TimeSpan finish;
        private double rate = 0.0;
        private TimeSpan hours;
        private double pay = 0.0;
        private double paid = 0.0;
        private double totalHours = 0.0;
        private double totalPay = 0.0;
        private double totalPaid = 0.0;
        private double balance = 0.0;

        public Hours()
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
            dtpStart.CustomFormat = "HH:mm";
            dtpStart.ShowUpDown = true;
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpFinish.CustomFormat = "HH:mm";
            dtpFinish.ShowUpDown = true;
            dtpFinish.Format = DateTimePickerFormat.Custom;
        }

        private void Hours_Load(object sender, EventArgs e)
        {
            startUp();
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            dtpStart.ValueChanged += dtpStart_ValueChanged;
            dtpFinish.ValueChanged += dtpFinish_ValueChanged;
            dg1.Click += dg1_Click;
            FormClosing += Hours_FormClosing;
            dg1.RowPostPaint += dg1_RowPostPaint;
            dg1.KeyDown += dg1_KeyDown;
            setTheme();
            getData();
        }

        public void setTheme()
        {
            Button[] cmd = { cmdBack, cmdInsert, cmdUpdate, cmdDelete, cmdImport };
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

        private void dg1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dg1.ClearSelection();
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

        private void dg1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dg1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
                dg1.ClearSelection();
            }
        }

        private void dg1_Click(object sender, EventArgs e)
        {
            populateGrid();
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
                dtpStart.Value = Convert.ToDateTime((dg1.CurrentRow.Cells[1].Value.ToString()));
                dtpFinish.Value = Convert.ToDateTime((dg1.CurrentRow.Cells[2].Value.ToString()));
                setControlState("u/d");
            }
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

        private void dtpFinish_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{Right}");
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{Right}");
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{Right}");
        }

        private void calc()
        {
            int rowCount = Convert.ToInt32(dg1.Rows.Count);
            DateTime oldUnder = new DateTime(2013, 04, 28);
            DateTime newOver = new DateTime(2014, 06, 01);
            if ((Convert.ToDateTime(dtpDate.Value).CompareTo(oldUnder)) <= 0)
            {
                rate = 9.65;
            }
            else if ((Convert.ToDateTime(dtpDate.Value).CompareTo(newOver)) >= 0)
            {
                rate = 11.0;
            }
            else
            {
                rate = 10.25;
            }
            if (rowCount > 0)
            {
                rowCount = Convert.ToInt32(dg1.Rows.Count - 1);
            }
            if (rowCount <= 0)
            {
                date = dtpDate.Value.ToString("yyyy/MM/dd");
                start = dtpStart.Value.TimeOfDay;
                finish = dtpFinish.Value.TimeOfDay;
                hours = finish - start;
                pay = hours.TotalHours * rate;
                paid = 0.00;
                totalHours = hours.TotalHours;
                totalPay = pay;
                totalPaid = paid;
                balance = pay;
            }
            else
            {
                date = dtpDate.Value.ToString("yyyy/MM/dd");
                start = dtpStart.Value.TimeOfDay;
                finish = dtpFinish.Value.TimeOfDay;
                hours = finish - start;
                pay = hours.TotalHours * rate;
                paid = 0.00;
                totalHours = hours.TotalHours;
                totalPay = pay;
                totalPaid = paid;
                balance = pay - paid;
            }
        }

        private void reCalc()
        {
            //dg1.Sort(dg1.Columns["Date"], ListSortDirection.Ascending);
            int safety = dg1.Rows.Count;
            dg1.CurrentCell = dg1.Rows[safety - 1].Cells[0];
            for (int i = 0; i < dg1.Rows.Count; i++)
            {
                if ((i - 1) > 0)
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
                }
            }
        }

        private void clear()
        {
            DateTimePicker[] dtp = { dtpDate, dtpStart, dtpFinish };

            foreach (DateTimePicker d in dtp)
            {
                dtpDate.Text = DateTime.Today.ToString();
                dtpStart.Text = DateTime.Today.ToString();
                dtpFinish.Text = DateTime.Today.ToString();
            }
        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            string[] columns = { "Date", "Start", "Finish", "Hours", "Rate", "Pay", "Paid", "T-Hours", "T-Pay", "T-Paid", "Balance" };
            DateTimePicker[] dtp = { dtpDate, dtpStart, dtpFinish };

            if (validInfo())
            {
                if (validPrimary("i"))
                {
                    //string connStr = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|Data.mdf;Integrated Security=True";
                    //SqlConnection conn = new SqlConnection(connStr);
                    //conn.Open();
                    //SqlCommand cmd = new SqlCommand();
                    //cmd.Connection = conn;
                    //string sql = "Select [Date], [Start], [Finish] FROM [PayData] WHERE [Date] = '" + dtpDate.Value + "'AND [Start] = '" + dtpStart.Value + "'AND [Finish] ='" + dtpFinish.Value + "'";
                    //cmd.CommandText = sql;
                    //DataRow dr = ds.Tables["PayData"].NewRow();
                    //SqlDataReader dataReader = cmd.ExecuteReader();

                    string connStr = "server=192.168.2.39;user id=Owner;password=gseHHt6B;database=Data;persistsecurityinfo=True";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    string sql = "Select Date, Start, Finish FROM PayData WHERE Date = '" + dtpDate.Value + "'AND Start = '" + dtpStart.Value + "'AND Finish ='" + dtpFinish.Value + "'";
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
                else
                {
                    return;
                }
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            string[] columns = { "Date", "Start", "Finish", "Hours", "Rate", "Pay", "Paid", "T-Hours", "T-Pay", "T-Paid", "Balance" };
            DateTimePicker[] dtp = { dtpDate, dtpStart, dtpFinish };

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

        public void formatGrid()
        {
            dg1.Sort(dg1.Columns["Date"], ListSortDirection.Ascending);
            dg1.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
            dg1.ClearSelection();
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

        private void cmdBack_Click(object sender, EventArgs e)
        {
            Start s = new Start();
            s.Show();
            this.Hide();
        }

        private void Hours_FormClosing(object sender, FormClosingEventArgs e)
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

        private void cmdImport_Click(object sender, EventArgs e)
        {
            getFileData();
            //reCalc();
        }

        private void getData()
        {
            string[] columns = { "Date", "Start", "Finish", "Hours", "Rate", "Pay", "Paid", "T-Hours", "T-Pay", "T-Paid", "Balance" };
            string connStr = "server=192.168.2.39;user id=Owner;password=gseHHt6B;database=Data;persistsecurityinfo=True";
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
                    if (i > 2)
                    {
                        dg1.Columns[i].Visible = false;
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
                    if ((dtpDate.Value.Equals(dg1.Rows[i].Cells[0].Value)))
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
                        if ((dtpDate.Text.Equals(dg1.Rows[i].Cells[0].Value.ToString())) && (dtpStart.Text.Equals(dg1.Rows[i].Cells[1].Value.ToString())) && (dtpFinish.Text.Equals(dg1.Rows[i].Cells[2].Value.ToString())))
                        {
                            MessageBox.Show("Entry Exists Already.", "Primary Key Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dtpDate.Focus();
                            return false;
                        }
                        else if ((dtpDate.Text.Equals("")) || (dtpStart.Text.Equals("")) || (dtpFinish.Text.Equals("")))
                        {
                            MessageBox.Show("No Entry Selected!", "Update Record Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (dtpDate.Text.Equals(""))
                            {
                                dtpDate.Focus();
                            }
                            if (dtpStart.Text.Equals(""))
                            {
                                dtpStart.Focus();
                            }
                            if (dtpFinish.Text.Equals(""))
                            {
                                dtpFinish.Focus();
                            }
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void getFileData()
        {
            //string connStr = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|Data.mdf;Integrated Security=True;Connect Timeout=30";
            //conn = new SqlConnection(connStr);
            ////string sql = "SELECT [Date],[Start],[Finish] FROM [PayData]";
            //string sql = "SELECT * FROM [PayData]"; //uncomment when uploading from file
            //da = new SqlDataAdapter(sql, conn);
            //SqlCommandBuilder cb = new SqlCommandBuilder(da);
            //ds = new DataSet();
            //conn.Open();
            //da.Fill(ds, "PayData");
            //conn.Close();
            string connStr = "server=192.168.2.39;user id=Owner;password=gseHHt6B;database=Data;persistsecurityinfo=True";
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
            dg1.ClearSelection();
            StreamReader sr = new StreamReader("Pay.txt");
            string record = sr.ReadLine();
            while (record != null)
            {
                string[] temp = record.Split(',');
                try
                {
                    conn = new MySqlConnection(connStr);
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    sql = "SELECT Date FROM PayData WHERE Date = '" + temp[0] + "'";
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
                        dg1.Columns[0].ValueType = typeof(DateTime);
                        ds.Tables["PayData"].Rows.Add(dr);
                        da.Update(ds, "PayData");
                        formatGrid();
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

        private void cmdRecalc_Click(object sender, EventArgs e)
        {
            reCalc();
        }
    }
}