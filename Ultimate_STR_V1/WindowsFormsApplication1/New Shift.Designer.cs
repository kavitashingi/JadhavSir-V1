namespace WindowsFormsApplication1
{
    partial class New_Shift
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.shiftidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shiftnmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shiftstarttimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shiftendtimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblshiftBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet28 = new WindowsFormsApplication1.DataSet28();
            this.tbl_shiftTableAdapter = new WindowsFormsApplication1.DataSet28TableAdapters.tbl_shiftTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.lblShiftHeading = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblshiftBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet28)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shiftidDataGridViewTextBoxColumn,
            this.shiftnmDataGridViewTextBoxColumn,
            this.shiftstarttimeDataGridViewTextBoxColumn,
            this.shiftendtimeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tblshiftBindingSource;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(12, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(427, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // shiftidDataGridViewTextBoxColumn
            // 
            this.shiftidDataGridViewTextBoxColumn.DataPropertyName = "shift_id";
            this.shiftidDataGridViewTextBoxColumn.HeaderText = "shift_id";
            this.shiftidDataGridViewTextBoxColumn.Name = "shiftidDataGridViewTextBoxColumn";
            // 
            // shiftnmDataGridViewTextBoxColumn
            // 
            this.shiftnmDataGridViewTextBoxColumn.DataPropertyName = "shift_nm";
            this.shiftnmDataGridViewTextBoxColumn.HeaderText = "shift_nm";
            this.shiftnmDataGridViewTextBoxColumn.Name = "shiftnmDataGridViewTextBoxColumn";
            // 
            // shiftstarttimeDataGridViewTextBoxColumn
            // 
            this.shiftstarttimeDataGridViewTextBoxColumn.DataPropertyName = "shift_start_time";
            this.shiftstarttimeDataGridViewTextBoxColumn.HeaderText = "shift_start_time";
            this.shiftstarttimeDataGridViewTextBoxColumn.Name = "shiftstarttimeDataGridViewTextBoxColumn";
            // 
            // shiftendtimeDataGridViewTextBoxColumn
            // 
            this.shiftendtimeDataGridViewTextBoxColumn.DataPropertyName = "shift_end_time";
            this.shiftendtimeDataGridViewTextBoxColumn.HeaderText = "shift_end_time";
            this.shiftendtimeDataGridViewTextBoxColumn.Name = "shiftendtimeDataGridViewTextBoxColumn";
            // 
            // tblshiftBindingSource
            // 
            this.tblshiftBindingSource.DataMember = "tbl_shift";
            this.tblshiftBindingSource.DataSource = this.dataSet28;
            // 
            // dataSet28
            // 
            this.dataSet28.DataSetName = "DataSet28";
            this.dataSet28.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_shiftTableAdapter
            // 
            this.tbl_shiftTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(245, 229);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblShiftHeading
            // 
            this.lblShiftHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftHeading.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblShiftHeading.Location = new System.Drawing.Point(88, 9);
            this.lblShiftHeading.Name = "lblShiftHeading";
            this.lblShiftHeading.Size = new System.Drawing.Size(264, 32);
            this.lblShiftHeading.TabIndex = 2;
            this.lblShiftHeading.Text = "Shift Time Change";
            this.lblShiftHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(136, 229);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // New_Shift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 264);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblShiftHeading);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "New_Shift";
            this.Text = "New_Shift";
            this.Load += new System.EventHandler(this.New_Shift_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblshiftBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet28)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private DataSet28 dataSet28;
        private System.Windows.Forms.BindingSource tblshiftBindingSource;
        private DataSet28TableAdapters.tbl_shiftTableAdapter tbl_shiftTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn shiftidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shiftnmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shiftstarttimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shiftendtimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblShiftHeading;
        private System.Windows.Forms.Button button2;
    }
}