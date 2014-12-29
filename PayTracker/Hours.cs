﻿using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PayTracker
{
    public partial class Hours : Form
    {
         private SqlConnection conn = null;
        private SqlDataAdapter da = null;
        private DataSet ds = null;
        int rowIndex = -1;
        public Hours()
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

        private void Hours_Load(object sender, EventArgs e)
        {
            startUp();
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            dtpStart.ValueChanged += dtpStart_ValueChanged;
            dtpFinish.ValueChanged += dtpFinish_ValueChanged;
            dg1.Click += dg1_Click;
            FormClosing += Hours_FormClosing;
            getData();
        }

        void dg1_Click(object sender, EventArgs e)
        {
            populateGrid();
        }

        private void populateGrid()
        {
            if(dg1.Rows.Count != 0)
            {
                dg1.CurrentRow.Selected = true;
                rowIndex = dg1.CurrentRow.Index;

                for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if(ds.Tables[0].Rows[i].RowState != DataRowState.Deleted)
                    {
                        if(dg1.CurrentRow.Cells[0].Value.ToString().Equals(ds.Tables[0].Rows[i][0].ToString()))
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
                dtpDate.Enabled = true;
                dtpStart.Enabled = true;
                dtpFinish.Enabled = true;
            }
            else if (state.Equals("u/d"))
            {
                dtpDate.Enabled = false;
            }
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmdHours_Click(object sender, EventArgs e)
        {
            
        }

        private void cmdPaid_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            //string connStr = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|Data.mdf;Integrated Security=True;Connect Timeout=30";
            //StreamReader sr = new StreamReader("Pay.txt");
            //string record = sr.ReadLine();
            //while (record != null)
            //{
            //    string[] temp = record.Split(',');
            //    Debug.WriteLine(temp[0] + " " + temp[1] + " " + temp[2] + " " + temp[3] + " " + temp[4] + " " + temp[5] + " " + temp[6] + " " + temp[7]);
            //    try
            //    {
            //        SqlConnection conn = new SqlConnection(connStr);
            //        conn.Open();
            //        SqlCommand cmd = new SqlCommand();
            //        cmd.Connection = conn;
            //        string sql = "SELECT [Date] FROM [PayData] WHERE [Date] = '" + temp[0] + "'";
            //        Debug.WriteLine(sql);
            //        cmd.CommandText = sql;
            //        DataRow dr = ds.Tables["PayData"].NewRow();
            //        SqlDataReader dataReader = cmd.ExecuteReader();

            //        if (dataReader.HasRows)
            //        {
            //            dataReader.Close();
            //            conn.Close();
            //        }
            //        else
            //        {
            //            dr["Date"] = temp[0];
            //            dr["Start"] = temp[1];
            //            dr["Finish"] = temp[2];
            //            dr["Hours"] = Convert.ToDouble(temp[3]);
            //            dr["Rate"] = Convert.ToDouble(temp[4]);
            //            dr["Pay"] = Convert.ToDouble(temp[5]);
            //            dr["PayW/Meal"] = Convert.ToDouble(temp[6]);
            //            ds.Tables["PayData"].Rows.Add(dr);
            //             da.Update(ds, "PayData");
            //        }
            //    }
            //    catch (SqlException ex)
            //    {

            //        if (conn != null)
            //        {
            //            conn.Close();
            //        }
            //        MessageBox.Show(ex.Message, "Error Reading Data");
            //    }
            //   record = sr.ReadLine();
            //}
            //sr.Close();
        }
        
        private void getData()
        {
            string connStr = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|Data.mdf;Integrated Security=True;";
            try
            {
                conn = new SqlConnection(connStr);
                string sql = "SELECT [Date],[Start],[Finish] FROM [PayData]";
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

        private void dg1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
