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
            this.SuspendLayout();
            // 
            // cmdPaid
            // 
            this.cmdPaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cmdPaid.Location = new System.Drawing.Point(12, 159);
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
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 262);
            this.Controls.Add(this.cmdPaid);
            this.Controls.Add(this.cmdHours);
            this.Controls.Add(this.lblTop);
            this.Name = "Start";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start";
            this.Load += new System.EventHandler(this.Start_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdPaid;
        private System.Windows.Forms.Button cmdHours;
        private System.Windows.Forms.Label lblTop;
    }
}