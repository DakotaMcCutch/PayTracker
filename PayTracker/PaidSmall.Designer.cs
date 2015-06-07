namespace PayTracker
{
    partial class PaidSmall
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
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cmdBack = new System.Windows.Forms.Button();
            this.cmdInsert = new System.Windows.Forms.Button();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblInsertMessage = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(13, 74);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(148, 20);
            this.txtAmount.TabIndex = 72;
            this.txtAmount.Text = "0.00";
            // 
            // cmdBack
            // 
            this.cmdBack.BackColor = System.Drawing.Color.Tomato;
            this.cmdBack.Location = new System.Drawing.Point(56, 174);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(58, 57);
            this.cmdBack.TabIndex = 77;
            this.cmdBack.Text = "Go Back";
            this.cmdBack.UseVisualStyleBackColor = false;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // cmdInsert
            // 
            this.cmdInsert.BackColor = System.Drawing.Color.GreenYellow;
            this.cmdInsert.Location = new System.Drawing.Point(11, 111);
            this.cmdInsert.Name = "cmdInsert";
            this.cmdInsert.Size = new System.Drawing.Size(150, 57);
            this.cmdInsert.TabIndex = 73;
            this.cmdInsert.Text = "Insert";
            this.cmdInsert.UseVisualStyleBackColor = false;
            this.cmdInsert.Click += new System.EventHandler(this.cmdInsert_Click);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(16, 57);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(73, 13);
            this.lblStart.TabIndex = 78;
            this.lblStart.Text = "Amount Paid: ";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(13, 30);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(148, 20);
            this.dtpDate.TabIndex = 71;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(13, 13);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 75;
            this.lblDate.Text = "Date:";
            // 
            // lblInsertMessage
            // 
            this.lblInsertMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertMessage.Location = new System.Drawing.Point(343, 285);
            this.lblInsertMessage.Name = "lblInsertMessage";
            this.lblInsertMessage.Size = new System.Drawing.Size(390, 23);
            this.lblInsertMessage.TabIndex = 80;
            // 
            // PaidSmall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 259);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.cmdBack);
            this.Controls.Add(this.cmdInsert);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblInsertMessage);
            this.Name = "PaidSmall";
            this.Text = "PaidSmall";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.Button cmdInsert;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label lblInsertMessage;
    }
}