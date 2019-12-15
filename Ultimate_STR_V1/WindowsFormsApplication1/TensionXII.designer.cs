namespace WindowsFormsApplication1
{
    partial class TensionXII
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tbldata_32BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet28 = new WindowsFormsApplication1.DataSet28();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnok = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.supervisertxt = new System.Windows.Forms.TextBox();
            this.shifttxt = new System.Windows.Forms.TextBox();
            this.batchcombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbldata_32TableAdapter = new WindowsFormsApplication1.DataSet28TableAdapters.tbldata_32TableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_import = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbldata_32BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbldata_32BindingSource
            // 
            this.tbldata_32BindingSource.DataMember = "tbldata_32";
            this.tbldata_32BindingSource.DataSource = this.DataSet28;
            // 
            // DataSet28
            // 
            this.DataSet28.DataSetName = "DataSet28";
            this.DataSet28.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbldata_32BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication1.Report10.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 148);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1053, 428);
            this.reportViewer1.TabIndex = 0;
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(465, 106);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 41;
            this.btnok.Text = "OK";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Visible = false;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1022, 25);
            this.label5.TabIndex = 40;
            this.label5.Text = "Tension Register ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(184, 71);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(187, 20);
            this.dateTimePicker1.TabIndex = 39;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // supervisertxt
            // 
            this.supervisertxt.Location = new System.Drawing.Point(763, 71);
            this.supervisertxt.Name = "supervisertxt";
            this.supervisertxt.Size = new System.Drawing.Size(100, 20);
            this.supervisertxt.TabIndex = 38;
            // 
            // shifttxt
            // 
            this.shifttxt.Location = new System.Drawing.Point(594, 70);
            this.shifttxt.Name = "shifttxt";
            this.shifttxt.Size = new System.Drawing.Size(100, 20);
            this.shifttxt.TabIndex = 37;
            // 
            // batchcombo
            // 
            this.batchcombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.batchcombo.FormattingEnabled = true;
            this.batchcombo.Location = new System.Drawing.Point(429, 70);
            this.batchcombo.Name = "batchcombo";
            this.batchcombo.Size = new System.Drawing.Size(121, 21);
            this.batchcombo.TabIndex = 36;
            this.batchcombo.SelectedIndexChanged += new System.EventHandler(this.batchcombo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(700, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Superviser";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(560, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Shift";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Batch no";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Date";
            // 
            // tbldata_32TableAdapter
            // 
            this.tbldata_32TableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 148);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1053, 428);
            this.dataGridView1.TabIndex = 81;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // btn_import
            // 
            this.btn_import.Location = new System.Drawing.Point(893, 106);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(75, 23);
            this.btn_import.TabIndex = 82;
            this.btn_import.Text = "Refresh";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Visible = false;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // Form32_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 575);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.supervisertxt);
            this.Controls.Add(this.shifttxt);
            this.Controls.Add(this.batchcombo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.dataGridView1);
            this.KeyPreview = true;
            this.Name = "Form32_1";
            this.Text = "Report Viewer";
            this.Load += new System.EventHandler(this.Form32_1_Load);
            this.Click += new System.EventHandler(this.btn_import_Click);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form32_1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.tbldata_32BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox supervisertxt;
        private System.Windows.Forms.TextBox shifttxt;
        private System.Windows.Forms.ComboBox batchcombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource tbldata_32BindingSource;
        private DataSet28 DataSet28;
        private DataSet28TableAdapters.tbldata_32TableAdapter tbldata_32TableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_import;
    }
}