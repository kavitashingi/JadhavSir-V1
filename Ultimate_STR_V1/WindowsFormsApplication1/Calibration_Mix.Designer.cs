namespace WindowsFormsApplication1
{
    partial class Calibration_Mix
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.btnok = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.TypeCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMM = new System.Windows.Forms.TextBox();
            this.txtHH = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.NextDueDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMachineName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtDeadLoad = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtObservation1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtObservation2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtObservation3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tbldata_calibration_mixBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet28 = new WindowsFormsApplication1.DataSet28();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deadLoadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observation1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observation2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observation3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeOfReportDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calibrationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nextDueDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machineNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbldata_calibration_mixTableAdapter = new WindowsFormsApplication1.DataSet28TableAdapters.tbldata_calibration_mixTableAdapter();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbldata_calibration_mixBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet28)).BeginInit();
            this.SuspendLayout();
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(743, 48);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 39;
            this.btnok.Text = "Search";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(392, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 25);
            this.label5.TabIndex = 38;
            this.label5.Text = "Calibration 1";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(177, 56);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(187, 20);
            this.dateTimePicker1.TabIndex = 37;
            // 
            // TypeCombo
            // 
            this.TypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeCombo.FormattingEnabled = true;
            this.TypeCombo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.TypeCombo.Location = new System.Drawing.Point(416, 55);
            this.TypeCombo.Name = "TypeCombo";
            this.TypeCombo.Size = new System.Drawing.Size(121, 21);
            this.TypeCombo.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(374, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(150, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Time";
            // 
            // txtMM
            // 
            this.txtMM.Location = new System.Drawing.Point(236, 97);
            this.txtMM.Name = "txtMM";
            this.txtMM.Size = new System.Drawing.Size(40, 20);
            this.txtMM.TabIndex = 191;
            // 
            // txtHH
            // 
            this.txtHH.Location = new System.Drawing.Point(186, 97);
            this.txtHH.Name = "txtHH";
            this.txtHH.Size = new System.Drawing.Size(40, 20);
            this.txtHH.TabIndex = 190;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(243, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 189;
            this.label7.Text = "Min";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(189, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 188;
            this.label8.Text = "Hour";
            // 
            // NextDueDate
            // 
            this.NextDueDate.Location = new System.Drawing.Point(368, 96);
            this.NextDueDate.Name = "NextDueDate";
            this.NextDueDate.Size = new System.Drawing.Size(187, 20);
            this.NextDueDate.TabIndex = 193;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 192;
            this.label3.Text = "Next Due On";
            // 
            // txtMachineName
            // 
            this.txtMachineName.Location = new System.Drawing.Point(636, 52);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(83, 20);
            this.txtMachineName.TabIndex = 195;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(551, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 194;
            this.label6.Text = "Machine Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.deadLoadDataGridViewTextBoxColumn,
            this.observation1DataGridViewTextBoxColumn,
            this.observation2DataGridViewTextBoxColumn,
            this.observation3DataGridViewTextBoxColumn,
            this.remarkDataGridViewTextBoxColumn,
            this.typeOfReportDataGridViewTextBoxColumn,
            this.calibrationDateDataGridViewTextBoxColumn,
            this.nextDueDateDataGridViewTextBoxColumn,
            this.machineNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tbldata_calibration_mixBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 196);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(512, 349);
            this.dataGridView1.TabIndex = 196;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.tbldata_calibration_mixBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication1.Calibratration_Mix_RDLC.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(547, 198);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(485, 347);
            this.reportViewer1.TabIndex = 197;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(407, 122);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 198;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDeadLoad
            // 
            this.txtDeadLoad.Location = new System.Drawing.Point(80, 157);
            this.txtDeadLoad.Name = "txtDeadLoad";
            this.txtDeadLoad.Size = new System.Drawing.Size(40, 20);
            this.txtDeadLoad.TabIndex = 200;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 199;
            this.label9.Text = "Dead Load";
            // 
            // txtObservation1
            // 
            this.txtObservation1.Location = new System.Drawing.Point(211, 157);
            this.txtObservation1.Name = "txtObservation1";
            this.txtObservation1.Size = new System.Drawing.Size(40, 20);
            this.txtObservation1.TabIndex = 202;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(132, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 201;
            this.label10.Text = "Observation 1";
            // 
            // txtObservation2
            // 
            this.txtObservation2.Location = new System.Drawing.Point(332, 157);
            this.txtObservation2.Name = "txtObservation2";
            this.txtObservation2.Size = new System.Drawing.Size(40, 20);
            this.txtObservation2.TabIndex = 204;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(253, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 203;
            this.label11.Text = "Observation 2";
            // 
            // txtObservation3
            // 
            this.txtObservation3.Location = new System.Drawing.Point(452, 157);
            this.txtObservation3.Name = "txtObservation3";
            this.txtObservation3.Size = new System.Drawing.Size(40, 20);
            this.txtObservation3.TabIndex = 206;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(377, 160);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 205;
            this.label12.Text = "Observation 3";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(789, 155);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 23);
            this.btnAdd.TabIndex = 207;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(951, 155);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(76, 23);
            this.button3.TabIndex = 208;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(789, 155);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(76, 23);
            this.btnUpdate.TabIndex = 209;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tbldata_calibration_mixBindingSource
            // 
            this.tbldata_calibration_mixBindingSource.DataMember = "tbldata_calibration_mix";
            this.tbldata_calibration_mixBindingSource.DataSource = this.DataSet28;
            // 
            // DataSet28
            // 
            this.DataSet28.DataSetName = "DataSet28";
            this.DataSet28.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deadLoadDataGridViewTextBoxColumn
            // 
            this.deadLoadDataGridViewTextBoxColumn.DataPropertyName = "DeadLoad";
            this.deadLoadDataGridViewTextBoxColumn.HeaderText = "DeadLoad";
            this.deadLoadDataGridViewTextBoxColumn.Name = "deadLoadDataGridViewTextBoxColumn";
            this.deadLoadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // observation1DataGridViewTextBoxColumn
            // 
            this.observation1DataGridViewTextBoxColumn.DataPropertyName = "Observation1";
            this.observation1DataGridViewTextBoxColumn.HeaderText = "Observation1";
            this.observation1DataGridViewTextBoxColumn.Name = "observation1DataGridViewTextBoxColumn";
            this.observation1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // observation2DataGridViewTextBoxColumn
            // 
            this.observation2DataGridViewTextBoxColumn.DataPropertyName = "Observation2";
            this.observation2DataGridViewTextBoxColumn.HeaderText = "Observation2";
            this.observation2DataGridViewTextBoxColumn.Name = "observation2DataGridViewTextBoxColumn";
            this.observation2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // observation3DataGridViewTextBoxColumn
            // 
            this.observation3DataGridViewTextBoxColumn.DataPropertyName = "Observation3";
            this.observation3DataGridViewTextBoxColumn.HeaderText = "Observation3";
            this.observation3DataGridViewTextBoxColumn.Name = "observation3DataGridViewTextBoxColumn";
            this.observation3DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // remarkDataGridViewTextBoxColumn
            // 
            this.remarkDataGridViewTextBoxColumn.DataPropertyName = "Remark";
            this.remarkDataGridViewTextBoxColumn.HeaderText = "Remark";
            this.remarkDataGridViewTextBoxColumn.Name = "remarkDataGridViewTextBoxColumn";
            this.remarkDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeOfReportDataGridViewTextBoxColumn
            // 
            this.typeOfReportDataGridViewTextBoxColumn.DataPropertyName = "TypeOfReport";
            this.typeOfReportDataGridViewTextBoxColumn.HeaderText = "TypeOfReport";
            this.typeOfReportDataGridViewTextBoxColumn.Name = "typeOfReportDataGridViewTextBoxColumn";
            this.typeOfReportDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // calibrationDateDataGridViewTextBoxColumn
            // 
            this.calibrationDateDataGridViewTextBoxColumn.DataPropertyName = "CalibrationDate";
            this.calibrationDateDataGridViewTextBoxColumn.HeaderText = "CalibrationDate";
            this.calibrationDateDataGridViewTextBoxColumn.Name = "calibrationDateDataGridViewTextBoxColumn";
            this.calibrationDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nextDueDateDataGridViewTextBoxColumn
            // 
            this.nextDueDateDataGridViewTextBoxColumn.DataPropertyName = "NextDueDate";
            this.nextDueDateDataGridViewTextBoxColumn.HeaderText = "NextDueDate";
            this.nextDueDateDataGridViewTextBoxColumn.Name = "nextDueDateDataGridViewTextBoxColumn";
            this.nextDueDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // machineNameDataGridViewTextBoxColumn
            // 
            this.machineNameDataGridViewTextBoxColumn.DataPropertyName = "MachineName";
            this.machineNameDataGridViewTextBoxColumn.HeaderText = "MachineName";
            this.machineNameDataGridViewTextBoxColumn.Name = "machineNameDataGridViewTextBoxColumn";
            this.machineNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tbldata_calibration_mixTableAdapter
            // 
            this.tbldata_calibration_mixTableAdapter.ClearBeforeFill = true;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(734, 157);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(40, 20);
            this.txtId.TabIndex = 210;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(712, 160);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 13);
            this.label13.TabIndex = 211;
            this.label13.Text = "Id";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(870, 155);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(76, 23);
            this.btnDelete.TabIndex = 212;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(544, 157);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(162, 20);
            this.txtRemark.TabIndex = 214;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(498, 160);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 213;
            this.label14.Text = "Remark";
            // 
            // Calibration_Mix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 535);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtObservation3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtObservation2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtObservation1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDeadLoad);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtMachineName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.NextDueDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMM);
            this.Controls.Add(this.txtHH);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.TypeCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Name = "Calibration_Mix";
            this.Text = "Calibration_Mix";
            this.Load += new System.EventHandler(this.Calibration_Mix_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbldata_calibration_mixBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet28)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox TypeCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMM;
        private System.Windows.Forms.TextBox txtHH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker NextDueDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMachineName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbldata_calibration_mixBindingSource;
        private DataSet28 DataSet28;
        private DataSet28TableAdapters.tbldata_calibration_mixTableAdapter tbldata_calibration_mixTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deadLoadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observation1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observation2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observation3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeOfReportDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn calibrationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nextDueDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtDeadLoad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtObservation1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtObservation2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtObservation3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label14;
    }
}