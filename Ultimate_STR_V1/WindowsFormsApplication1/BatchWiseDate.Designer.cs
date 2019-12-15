namespace WindowsFormsApplication1
{
    partial class BatchWiseDate
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
            this.lblBatchNo = new System.Windows.Forms.Label();
            this.txtBatchNo = new System.Windows.Forms.TextBox();
            this.chbListDate = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // lblBatchNo
            // 
            this.lblBatchNo.AutoSize = true;
            this.lblBatchNo.Location = new System.Drawing.Point(1, 13);
            this.lblBatchNo.Name = "lblBatchNo";
            this.lblBatchNo.Size = new System.Drawing.Size(83, 13);
            this.lblBatchNo.TabIndex = 0;
            this.lblBatchNo.Text = "Enter Batch No.";
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Location = new System.Drawing.Point(90, 10);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.Size = new System.Drawing.Size(100, 20);
            this.txtBatchNo.TabIndex = 1;
            // 
            // chbListDate
            // 
            this.chbListDate.FormattingEnabled = true;
            this.chbListDate.Location = new System.Drawing.Point(4, 56);
            this.chbListDate.Name = "chbListDate";
            this.chbListDate.Size = new System.Drawing.Size(186, 199);
            this.chbListDate.TabIndex = 2;
            this.chbListDate.SelectedIndexChanged += new System.EventHandler(this.chbListDate_SelectedIndexChanged);
            // 
            // BatchWiseDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 262);
            this.Controls.Add(this.chbListDate);
            this.Controls.Add(this.txtBatchNo);
            this.Controls.Add(this.lblBatchNo);
            this.Name = "BatchWiseDate";
            this.Text = "BatchWiseDate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBatchNo;
        private System.Windows.Forms.TextBox txtBatchNo;
        private System.Windows.Forms.CheckedListBox chbListDate;
    }
}