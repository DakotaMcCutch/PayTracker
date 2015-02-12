namespace PayTracker
{
    partial class Start
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
            this.cmdPaid = new System.Windows.Forms.Button();
            this.cmdHours = new System.Windows.Forms.Button();
            this.lblTop = new System.Windows.Forms.Label();
            this.cbTheme = new System.Windows.Forms.ComboBox();
            this.lblTheme = new System.Windows.Forms.Label();
            this.cmdAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdPaid
            // 
            this.cmdPaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cmdPaid.Location = new System.Drawing.Point(12, 147);
            this.cmdPaid.Name = "cmdPaid";
            this.cmdPaid.Size = new System.Drawing.Size(317, 76);
            this.cmdPaid.TabIndex = 56;
            this.cmdPaid.Text = "Paid";
            this.cmdPaid.UseVisualStyleBackColor = false;
            this.cmdPaid.Click += new System.EventHandler(this.cmdPaid_Click);
            // 
            // cmdHours
            // 
            this.cmdHours.BackColor = System.Drawing.Color.Orange;
            this.cmdHours.Location = new System.Drawing.Point(12, 65);
            this.cmdHours.Name = "cmdHours";
            this.cmdHours.Size = new System.Drawing.Size(317, 76);
            this.cmdHours.TabIndex = 55;
            this.cmdHours.Text = "Hours";
            this.cmdHours.UseVisualStyleBackColor = false;
            this.cmdHours.Click += new System.EventHandler(this.cmdHours_Click);
            // 
            // lblTop
            // 
            this.lblTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTop.Location = new System.Drawing.Point(7, 4);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(333, 57);
            this.lblTop.TabIndex = 54;
            this.lblTop.Text = "Please select the mode that you want to enter";
            this.lblTop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbTheme
            // 
            this.cbTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTheme.FormattingEnabled = true;
            this.cbTheme.Items.AddRange(new object[] {
            "Normal",
            "Dark"});
            this.cbTheme.Location = new System.Drawing.Point(119, 317);
            this.cbTheme.Name = "cbTheme";
            this.cbTheme.Size = new System.Drawing.Size(121, 21);
            this.cbTheme.TabIndex = 57;
            // 
            // lblTheme
            // 
            this.lblTheme.AutoSize = true;
            this.lblTheme.Location = new System.Drawing.Point(61, 320);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(46, 13);
            this.lblTheme.TabIndex = 58;
            this.lblTheme.Text = "Theme :";
            // 
            // cmdAll
            // 
            this.cmdAll.BackColor = System.Drawing.Color.Yellow;
            this.cmdAll.Location = new System.Drawing.Point(12, 229);
            this.cmdAll.Name = "cmdAll";
            this.cmdAll.Size = new System.Drawing.Size(317, 76);
            this.cmdAll.TabIndex = 59;
            this.cmdAll.Text = "All Data";
            this.cmdAll.UseVisualStyleBackColor = false;
            this.cmdAll.Click += new System.EventHandler(this.cmdAll_Click);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(357, 352);
            this.Controls.Add(this.cmdAll);
            this.Controls.Add(this.lblTheme);
            this.Controls.Add(this.cbTheme);
            this.Controls.Add(this.cmdPaid);
            this.Controls.Add(this.cmdHours);
            this.Controls.Add(this.lblTop);
            this.Name = "Start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start";
            this.Load += new System.EventHandler(this.Start_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdPaid;
        private System.Windows.Forms.Button cmdHours;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.ComboBox cbTheme;
        private System.Windows.Forms.Label lblTheme;
        private System.Windows.Forms.Button cmdAll;
    }
}