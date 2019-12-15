namespace WindowsFormsApplication1
{
    partial class RPMnew
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rpmdataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet28 = new WindowsFormsApplication1.DataSet28();
            this.btnok = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.shifttxt = new System.Windows.Forms.TextBox();
            this.batchcombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rpmdataTableAdapter = new WindowsFormsApplication1.DataSet28TableAdapters.rpmdataTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rdobatch = new System.Windows.Forms.RadioButton();
            this.rdodate = new System.Windows.Forms.RadioButton();
            this.txtbatch = new System.Windows.Forms.TextBox();
            this.btnshow = new System.Windows.Forms.Button();
            this.btn_import = new System.Windows.Forms.Button();
            this.VB1 = new System.Windows.Forms.TextBox();
            this.VB2 = new System.Windows.Forms.TextBox();
            this.VB3 = new System.Windows.Forms.TextBox();
            this.VB4 = new System.Windows.Forms.TextBox();
            this.VB8 = new System.Windows.Forms.TextBox();
            this.VB7 = new System.Windows.Forms.TextBox();
            this.VB6 = new System.Windows.Forms.TextBox();
            this.VB5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rpmdataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // rpmdataBindingSource
            // 
            this.rpmdataBindingSource.DataMember = "rpmdata";
            this.rpmdataBindingSource.DataSource = this.DataSet28;
            // 
            // DataSet28
            // 
            this.DataSet28.DataSetName = "DataSet28";
            this.DataSet28.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(387, 109);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 29;
            this.btnok.Text = "OK";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Visible = false;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(323, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 25);
            this.label5.TabIndex = 28;
            this.label5.Text = "RPM Report";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(161, 77);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(187, 20);
            this.dateTimePicker1.TabIndex = 27;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // shifttxt
            // 
            this.shifttxt.Location = new System.Drawing.Point(575, 75);
            this.shifttxt.Name = "shifttxt";
            this.shifttxt.Size = new System.Drawing.Size(100, 20);
            this.shifttxt.TabIndex = 26;
            // 
            // batchcombo
            // 
            this.batchcombo.FormattingEnabled = true;
            this.batchcombo.Location = new System.Drawing.Point(414, 76);
            this.batchcombo.Name = "batchcombo";
            this.batchcombo.Size = new System.Drawing.Size(124, 21);
            this.batchcombo.TabIndex = 25;
            this.batchcombo.SelectedIndexChanged += new System.EventHandler(this.batchcombo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(541, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Shift";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(354, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Batch no";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Date";
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 39;
            reportDataSource4.Name = "DataSet1";
            reportDataSource4.Value = this.rpmdataBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication1.Report13.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-2, 167);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(779, 516);
            this.reportViewer1.TabIndex = 30;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // rpmdataTableAdapter
            // 
            this.rpmdataTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-2, 192);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(761, 323);
            this.dataGridView1.TabIndex = 112;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // rdobatch
            // 
            this.rdobatch.AutoSize = true;
            this.rdobatch.Checked = true;
            this.rdobatch.Location = new System.Drawing.Point(266, 52);
            this.rdobatch.Name = "rdobatch";
            this.rdobatch.Size = new System.Drawing.Size(115, 17);
            this.rdobatch.TabIndex = 113;
            this.rdobatch.TabStop = true;
            this.rdobatch.Text = "Batch Wise Report";
            this.rdobatch.UseVisualStyleBackColor = true;
            this.rdobatch.CheckedChanged += new System.EventHandler(this.rdobatch_CheckedChanged);
            // 
            // rdodate
            // 
            this.rdodate.AutoSize = true;
            this.rdodate.Location = new System.Drawing.Point(381, 52);
            this.rdodate.Name = "rdodate";
            this.rdodate.Size = new System.Drawing.Size(110, 17);
            this.rdodate.TabIndex = 114;
            this.rdodate.Text = "Date Wise Report";
            this.rdodate.UseVisualStyleBackColor = true;
            this.rdodate.CheckedChanged += new System.EventHandler(this.rdodate_CheckedChanged);
            // 
            // txtbatch
            // 
            this.txtbatch.Location = new System.Drawing.Point(414, 76);
            this.txtbatch.Name = "txtbatch";
            this.txtbatch.Size = new System.Drawing.Size(124, 20);
            this.txtbatch.TabIndex = 115;
            this.txtbatch.Visible = false;
            // 
            // btnshow
            // 
            this.btnshow.Location = new System.Drawing.Point(286, 109);
            this.btnshow.Name = "btnshow";
            this.btnshow.Size = new System.Drawing.Size(75, 23);
            this.btnshow.TabIndex = 116;
            this.btnshow.Text = "Show Report";
            this.btnshow.UseVisualStyleBackColor = true;
            this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
            // 
            // btn_import
            // 
            this.btn_import.Location = new System.Drawing.Point(670, 109);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(75, 23);
            this.btn_import.TabIndex = 117;
            this.btn_import.Text = "Refresh";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Visible = false;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // VB1
            // 
            this.VB1.Location = new System.Drawing.Point(145, 141);
            this.VB1.Name = "VB1";
            this.VB1.Size = new System.Drawing.Size(49, 20);
            this.VB1.TabIndex = 118;
            // 
            // VB2
            // 
            this.VB2.Location = new System.Drawing.Point(200, 141);
            this.VB2.Name = "VB2";
            this.VB2.Size = new System.Drawing.Size(49, 20);
            this.VB2.TabIndex = 119;
            // 
            // VB3
            // 
            this.VB3.Location = new System.Drawing.Point(261, 141);
            this.VB3.Name = "VB3";
            this.VB3.Size = new System.Drawing.Size(49, 20);
            this.VB3.TabIndex = 120;
            // 
            // VB4
            // 
            this.VB4.Location = new System.Drawing.Point(316, 141);
            this.VB4.Name = "VB4";
            this.VB4.Size = new System.Drawing.Size(49, 20);
            this.VB4.TabIndex = 121;
            // 
            // VB8
            // 
            this.VB8.Location = new System.Drawing.Point(544, 141);
            this.VB8.Name = "VB8";
            this.VB8.Size = new System.Drawing.Size(49, 20);
            this.VB8.TabIndex = 125;
            // 
            // VB7
            // 
            this.VB7.Location = new System.Drawing.Point(489, 141);
            this.VB7.Name = "VB7";
            this.VB7.Size = new System.Drawing.Size(49, 20);
            this.VB7.TabIndex = 124;
            // 
            // VB6
            // 
            this.VB6.Location = new System.Drawing.Point(428, 141);
            this.VB6.Name = "VB6";
            this.VB6.Size = new System.Drawing.Size(49, 20);
            this.VB6.TabIndex = 123;
            // 
            // VB5
            // 
            this.VB5.Location = new System.Drawing.Point(373, 141);
            this.VB5.Name = "VB5";
            this.VB5.Size = new System.Drawing.Size(49, 20);
            this.VB5.TabIndex = 122;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 126;
            this.label4.Text = "Vibrator No :-";
            // 
            // RPMnew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 684);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.VB8);
            this.Controls.Add(this.VB7);
            this.Controls.Add(this.VB6);
            this.Controls.Add(this.VB5);
            this.Controls.Add(this.VB4);
            this.Controls.Add(this.VB3);
            this.Controls.Add(this.VB2);
            this.Controls.Add(this.VB1);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.btnshow);
            this.Controls.Add(this.rdodate);
            this.Controls.Add(this.rdobatch);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.shifttxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.batchcombo);
            this.Controls.Add(this.txtbatch);
            this.KeyPreview = true;
            this.Name = "RPMnew";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "RPM Report";
            this.Load += new System.EventHandler(this.RPMnew_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RPMnew_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.rpmdataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox shifttxt;
        private System.Windows.Forms.ComboBox batchcombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource rpmdataBindingSource;
        private DataSet28 DataSet28;
        private DataSet28TableAdapters.rpmdataTableAdapter rpmdataTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton rdobatch;
        private System.Windows.Forms.RadioButton rdodate;
        private System.Windows.Forms.TextBox txtbatch;
        private System.Windows.Forms.Button btnshow;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.TextBox VB1;
        private System.Windows.Forms.TextBox VB2;
        private System.Windows.Forms.TextBox VB3;
        private System.Windows.Forms.TextBox VB4;
        private System.Windows.Forms.TextBox VB8;
        private System.Windows.Forms.TextBox VB7;
        private System.Windows.Forms.TextBox VB6;
        private System.Windows.Forms.TextBox VB5;
        private System.Windows.Forms.Label label4;
    }
}