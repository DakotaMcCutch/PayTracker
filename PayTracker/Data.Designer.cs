namespace PayTracker
{
    partial class Data
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmdBack = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dg1 = new System.Windows.Forms.DataGridView();
            this.cmdImport = new System.Windows.Forms.Button();
            this.lblTotalH = new System.Windows.Forms.Label();
            this.txtTHour = new System.Windows.Forms.TextBox();
            this.txtTPay = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTPaid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdBack
            // 
            this.cmdBack.BackColor = System.Drawing.Color.Tomato;
            this.cmdBack.Location = new System.Drawing.Point(11, 311);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(58, 57);
            this.cmdBack.TabIndex = 79;
            this.cmdBack.Text = "Go Back";
            this.cmdBack.UseVisualStyleBackColor = false;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // dg1
            // 
            this.dg1.AllowUserToAddRows = false;
            this.dg1.AllowUserToDeleteRows = false;
            this.dg1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg1.EnableHeadersVisualStyles = false;
            this.dg1.Location = new System.Drawing.Point(222, 9);
            this.dg1.MultiSelect = false;
            this.dg1.Name = "dg1";
            this.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg1.Size = new System.Drawing.Size(950, 264);
            this.dg1.TabIndex = 85;
            // 
            // cmdImport
            // 
            this.cmdImport.BackColor = System.Drawing.Color.Orange;
            this.cmdImport.Location = new System.Drawing.Point(75, 311);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(141, 57);
            this.cmdImport.TabIndex = 80;
            this.cmdImport.Text = "Import From File";
            this.cmdImport.UseVisualStyleBackColor = false;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // lblTotalH
            // 
            this.lblTotalH.AutoSize = true;
            this.lblTotalH.Location = new System.Drawing.Point(13, 13);
            this.lblTotalH.Name = "lblTotalH";
            this.lblTotalH.Size = new System.Drawing.Size(62, 13);
            this.lblTotalH.TabIndex = 86;
            this.lblTotalH.Text = "Total Hours";
            // 
            // txtTHour
            // 
            this.txtTHour.Location = new System.Drawing.Point(16, 30);
            this.txtTHour.Name = "txtTHour";
            this.txtTHour.ReadOnly = true;
            this.txtTHour.Size = new System.Drawing.Size(100, 20);
            this.txtTHour.TabIndex = 87;
            // 
            // txtTPay
            // 
            this.txtTPay.Location = new System.Drawing.Point(16, 70);
            this.txtTPay.Name = "txtTPay";
            this.txtTPay.ReadOnly = true;
            this.txtTPay.Size = new System.Drawing.Size(100, 20);
            this.txtTPay.TabIndex = 91;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 90;
            this.label2.Text = "Total Pay";
            // 
            // txtTPaid
            // 
            this.txtTPaid.Location = new System.Drawing.Point(16, 110);
            this.txtTPaid.Name = "txtTPaid";
            this.txtTPaid.ReadOnly = true;
            this.txtTPaid.Size = new System.Drawing.Size(100, 20);
            this.txtTPaid.TabIndex = 93;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 92;
            this.label3.Text = "Total Paid";
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(16, 149);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(100, 20);
            this.txtBalance.TabIndex = 95;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 94;
            this.label4.Text = "Balance";
            // 
            // Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 380);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTPaid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTPay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTHour);
            this.Controls.Add(this.lblTotalH);
            this.Controls.Add(this.dg1);
            this.Controls.Add(this.cmdImport);
            this.Controls.Add(this.cmdBack);
            this.Name = "Data";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data";
            this.Load += new System.EventHandler(this.Data_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dg1;
        private System.Windows.Forms.Button cmdImport;
        private System.Windows.Forms.Label lblTotalH;
        private System.Windows.Forms.TextBox txtTHour;
        private System.Windows.Forms.TextBox txtTPay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTPaid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label label4;
    }
}