namespace PayTracker
{
    partial class firstStart
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmdLocal = new System.Windows.Forms.Button();
            this.cmdMySql = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.MaximumSize = new System.Drawing.Size(250, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "What Type of database would you like to use ?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmdLocal
            // 
            this.cmdLocal.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdLocal.Location = new System.Drawing.Point(17, 113);
            this.cmdLocal.Name = "cmdLocal";
            this.cmdLocal.Size = new System.Drawing.Size(113, 52);
            this.cmdLocal.TabIndex = 1;
            this.cmdLocal.Text = "Local File";
            this.cmdLocal.UseVisualStyleBackColor = true;
            this.cmdLocal.Click += new System.EventHandler(this.cmdLocal_Click);
            // 
            // cmdMySql
            // 
            this.cmdMySql.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdMySql.Location = new System.Drawing.Point(145, 113);
            this.cmdMySql.Name = "cmdMySql";
            this.cmdMySql.Size = new System.Drawing.Size(116, 52);
            this.cmdMySql.TabIndex = 3;
            this.cmdMySql.Text = "MySql";
            this.cmdMySql.UseVisualStyleBackColor = true;
            this.cmdMySql.Click += new System.EventHandler(this.cmdMySql_Click);
            // 
            // firstStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.cmdMySql);
            this.Controls.Add(this.cmdLocal);
            this.Controls.Add(this.label1);
            this.Name = "firstStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "firstStart";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdLocal;
        private System.Windows.Forms.Button cmdMySql;
    }
}