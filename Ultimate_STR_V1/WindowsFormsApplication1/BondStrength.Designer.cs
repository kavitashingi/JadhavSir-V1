namespace WindowsFormsApplication1
{
    partial class BondStrength
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
            this.tbldata26BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet28 = new WindowsFormsApplication1.DataSet28();
            this.btnshow = new System.Windows.Forms.Button();
            this.txtbatch = new System.Windows.Forms.TextBox();
            this.btnok = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.shifttxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.batchcombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.newbatch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lc_of_dg = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lc_of_mc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dia_of_rod = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Mix_design_combo = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbldata26TableAdapter = new WindowsFormsApplication1.DataSet28TableAdapters.tbldata26TableAdapter();
            this.CubeCombo = new System.Windows.Forms.ComboBox();
            this.cube_Combo = new System.Windows.Forms.Label();
            this.CUBE_TEXT = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tbldata26BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbldata26BindingSource
            // 
            this.tbldata26BindingSource.DataMember = "tbldata26";
            this.tbldata26BindingSource.DataSource = this.DataSet28;
            // 
            // DataSet28
            // 
            this.DataSet28.DataSetName = "DataSet28";
            this.DataSet28.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnshow
            // 
            this.btnshow.Location = new System.Drawing.Point(315, -67);
            this.btnshow.Name = "btnshow";
            this.btnshow.Size = new System.Drawing.Size(75, 23);
            this.btnshow.TabIndex = 80;
            this.btnshow.Text = "Show ";
            this.btnshow.UseVisualStyleBackColor = true;
            // 
            // txtbatch
            // 
            this.txtbatch.Location = new System.Drawing.Point(-18, -64);
            this.txtbatch.Name = "txtbatch";
            this.txtbatch.Size = new System.Drawing.Size(100, 20);
            this.txtbatch.TabIndex = 79;
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(94, -28);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(85, 23);
            this.btnok.TabIndex = 78;
            this.btnok.Text = "OK";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, -106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(295, 25);
            this.label5.TabIndex = 77;
            this.label5.Text = "Static Bending Test Report";
            // 
            // shifttxt
            // 
            this.shifttxt.Location = new System.Drawing.Point(142, -64);
            this.shifttxt.Name = "shifttxt";
            this.shifttxt.Size = new System.Drawing.Size(110, 20);
            this.shifttxt.TabIndex = 76;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, -56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 75;
            this.label3.Text = "Shift";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-92, -56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 74;
            this.label2.Text = "Batch no";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(172, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 25);
            this.label1.TabIndex = 85;
            this.label1.Text = "Bond Strength By PullOut Method";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbldata26BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication1.Report16.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-2, 170);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(749, 463);
            this.reportViewer1.TabIndex = 81;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(97, 57);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(187, 20);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // batchcombo
            // 
            this.batchcombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.batchcombo.FormattingEnabled = true;
            this.batchcombo.Location = new System.Drawing.Point(370, 56);
            this.batchcombo.Name = "batchcombo";
            this.batchcombo.Size = new System.Drawing.Size(121, 21);
            this.batchcombo.TabIndex = 2;
            this.batchcombo.SelectedIndexChanged += new System.EventHandler(this.batchcombo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(298, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 87;
            this.label6.Text = "Batch no";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 86;
            this.label7.Text = "Date";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Location = new System.Drawing.Point(97, 84);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(187, 20);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 93;
            this.label8.Text = "Casting Date";
            // 
            // newbatch
            // 
            this.newbatch.Location = new System.Drawing.Point(392, 83);
            this.newbatch.Name = "newbatch";
            this.newbatch.Size = new System.Drawing.Size(100, 20);
            this.newbatch.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(298, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 95;
            this.label9.Text = "New Batch No";
            // 
            // lc_of_dg
            // 
            this.lc_of_dg.Location = new System.Drawing.Point(606, 108);
            this.lc_of_dg.Name = "lc_of_dg";
            this.lc_of_dg.Size = new System.Drawing.Size(100, 20);
            this.lc_of_dg.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(505, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 97;
            this.label10.Text = "Least Count of DG";
            // 
            // lc_of_mc
            // 
            this.lc_of_mc.Location = new System.Drawing.Point(184, 108);
            this.lc_of_mc.Name = "lc_of_mc";
            this.lc_of_mc.Size = new System.Drawing.Size(100, 20);
            this.lc_of_mc.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 115);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 13);
            this.label11.TabIndex = 99;
            this.label11.Text = "Least count of Machine";
            // 
            // dia_of_rod
            // 
            this.dia_of_rod.Location = new System.Drawing.Point(393, 108);
            this.dia_of_rod.Name = "dia_of_rod";
            this.dia_of_rod.Size = new System.Drawing.Size(100, 20);
            this.dia_of_rod.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(295, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 13);
            this.label12.TabIndex = 101;
            this.label12.Text = "Diameter Of Rod";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // Mix_design_combo
            // 
            this.Mix_design_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Mix_design_combo.FormattingEnabled = true;
            this.Mix_design_combo.Items.AddRange(new object[] {
            "M55",
            "M60",
            "M60 - T39"});
            this.Mix_design_combo.Location = new System.Drawing.Point(586, 82);
            this.Mix_design_combo.Name = "Mix_design_combo";
            this.Mix_design_combo.Size = new System.Drawing.Size(121, 21);
            this.Mix_design_combo.TabIndex = 6;
            this.Mix_design_combo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(505, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 103;
            this.label13.Text = "Mix Design";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // tbldata26TableAdapter
            // 
            this.tbldata26TableAdapter.ClearBeforeFill = true;
            // 
            // CubeCombo
            // 
            this.CubeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CubeCombo.FormattingEnabled = true;
            this.CubeCombo.Location = new System.Drawing.Point(586, 56);
            this.CubeCombo.Name = "CubeCombo";
            this.CubeCombo.Size = new System.Drawing.Size(121, 21);
            this.CubeCombo.TabIndex = 3;
            this.CubeCombo.SelectedIndexChanged += new System.EventHandler(this.CubeCombo_SelectedIndexChanged);
            // 
            // cube_Combo
            // 
            this.cube_Combo.AutoSize = true;
            this.cube_Combo.Location = new System.Drawing.Point(505, 64);
            this.cube_Combo.Name = "cube_Combo";
            this.cube_Combo.Size = new System.Drawing.Size(49, 13);
            this.cube_Combo.TabIndex = 105;
            this.cube_Combo.Text = "Cube No";
            // 
            // CUBE_TEXT
            // 
            this.CUBE_TEXT.Location = new System.Drawing.Point(586, 56);
            this.CUBE_TEXT.Name = "CUBE_TEXT";
            this.CUBE_TEXT.Size = new System.Drawing.Size(121, 20);
            this.CUBE_TEXT.TabIndex = 107;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-2, 170);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(737, 419);
            this.dataGridView1.TabIndex = 108;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Form26
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(752, 599);
            this.Controls.Add(this.cube_Combo);
            this.Controls.Add(this.Mix_design_combo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dia_of_rod);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lc_of_mc);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lc_of_dg);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.newbatch);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.batchcombo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnshow);
            this.Controls.Add(this.txtbatch);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.shifttxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CubeCombo);
            this.Controls.Add(this.CUBE_TEXT);
            this.Controls.Add(this.dataGridView1);
            this.KeyPreview = true;
            this.Name = "Form26";
            this.Text = "Form26";
            this.Load += new System.EventHandler(this.Form26_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form26_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form26_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.tbldata26BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnshow;
        private System.Windows.Forms.TextBox txtbatch;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox shifttxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox batchcombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox newbatch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox lc_of_dg;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox lc_of_mc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox dia_of_rod;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox Mix_design_combo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.BindingSource tbldata26BindingSource;
        private DataSet28 DataSet28;
        private DataSet28TableAdapters.tbldata26TableAdapter tbldata26TableAdapter;
        private System.Windows.Forms.ComboBox CubeCombo;
        private System.Windows.Forms.Label cube_Combo;
        private System.Windows.Forms.TextBox CUBE_TEXT;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}