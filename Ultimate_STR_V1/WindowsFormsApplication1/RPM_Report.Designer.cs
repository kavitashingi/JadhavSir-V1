namespace WindowsFormsApplication1
{
    partial class RPM_Report
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.supervisertxt = new System.Windows.Forms.TextBox();
            this.shifttxt = new System.Windows.Forms.TextBox();
            this.batchcombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnok = new System.Windows.Forms.Button();
            this.rpmdataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lg_123 = new WindowsFormsApplication1.lg_123();
            this.ultimate_eleDataSet = new WindowsFormsApplication1.ultimate_eleDataSet();
            this.rpmdataTableAdapter = new WindowsFormsApplication1.lg_123TableAdapters.rpmdataTableAdapter();
            this.DataSet28 = new WindowsFormsApplication1.DataSet28();
            this.rpmdataTableAdapter1 = new WindowsFormsApplication1.DataSet28TableAdapters.rpmdataTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.rpmdataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lg_123)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultimate_eleDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet28)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.rpmdataBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication1.Report13.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 100);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(774, 643);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Batch no";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(420, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Shift";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(560, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Superviser";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(44, 52);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(187, 20);
            this.dateTimePicker1.TabIndex = 19;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // supervisertxt
            // 
            this.supervisertxt.Location = new System.Drawing.Point(623, 52);
            this.supervisertxt.Name = "supervisertxt";
            this.supervisertxt.Size = new System.Drawing.Size(100, 20);
            this.supervisertxt.TabIndex = 18;
            // 
            // shifttxt
            // 
            this.shifttxt.Location = new System.Drawing.Point(454, 51);
            this.shifttxt.Name = "shifttxt";
            this.shifttxt.Size = new System.Drawing.Size(100, 20);
            this.shifttxt.TabIndex = 17;
            // 
            // batchcombo
            // 
            this.batchcombo.FormattingEnabled = true;
            this.batchcombo.Location = new System.Drawing.Point(289, 51);
            this.batchcombo.Name = "batchcombo";
            this.batchcombo.Size = new System.Drawing.Size(121, 21);
            this.batchcombo.TabIndex = 16;
            this.batchcombo.SelectedIndexChanged += new System.EventHandler(this.batchcombo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(281, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "RPM Report";
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(335, 74);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 21;
            this.btnok.Text = "OK";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Visible = false;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // rpmdataBindingSource
            // 
            this.rpmdataBindingSource.DataMember = "rpmdata";
            this.rpmdataBindingSource.DataSource = this.DataSet28;
            this.rpmdataBindingSource.CurrentChanged += new System.EventHandler(this.rpmdataBindingSource_CurrentChanged);
            // 
            // lg_123
            // 
            this.lg_123.DataSetName = "lg_123";
            this.lg_123.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ultimate_eleDataSet
            // 
            this.ultimate_eleDataSet.DataSetName = "ultimate_eleDataSet";
            this.ultimate_eleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rpmdataTableAdapter
            // 
            this.rpmdataTableAdapter.ClearBeforeFill = true;
            // 
            // DataSet28
            // 
            this.DataSet28.DataSetName = "DataSet28";
            this.DataSet28.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rpmdataTableAdapter1
            // 
            this.rpmdataTableAdapter1.ClearBeforeFill = true;
            // 
            // RPM_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 733);
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
            this.Name = "RPM_Report";
            this.Text = "RPM_Report";
            this.Load += new System.EventHandler(this.RPM_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rpmdataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lg_123)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultimate_eleDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet28)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private ultimate_eleDataSet ultimate_eleDataSet;
        private lg_123 lg_123;
        private System.Windows.Forms.BindingSource rpmdataBindingSource;
        private lg_123TableAdapters.rpmdataTableAdapter rpmdataTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox supervisertxt;
        private System.Windows.Forms.TextBox shifttxt;
        private System.Windows.Forms.ComboBox batchcombo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnok;
        private DataSet28 DataSet28;
        private DataSet28TableAdapters.rpmdataTableAdapter rpmdataTableAdapter1;
    }
}