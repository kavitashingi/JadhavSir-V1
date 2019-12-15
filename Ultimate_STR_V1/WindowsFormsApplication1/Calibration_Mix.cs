using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;

namespace WindowsFormsApplication1
{
    public partial class Calibration_Mix : Form
    {
        static string sConnectionString = ConfigurationManager.ConnectionStrings["MyConn007"].ConnectionString;
        public MySqlConnection myConn;
        bool IsReportStaerted = false;

        public Calibration_Mix()
        {
            InitializeComponent();
        }

        private void Calibration_Mix_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet28.tbldata_calibration_mix' table. You can move, or remove it, as needed.

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDeadLoad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtObservation1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtObservation2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtObservation3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtRemark.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            btnUpdate.Visible = true;
            btnAdd.Visible = false;
            btnDelete.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtHH.Text != "" && txtMM.Text != "")
                IsReportStaerted = true;
            else
                IsReportStaerted = false;
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            txtHH.Text = "";
            txtMM.Text = "";
            txtId.Text = "";
            txtDeadLoad.Text = "";
            txtObservation1.Text = "";
            txtObservation2.Text = "";
            txtObservation3.Text = "";
            txtRemark.Text = "";
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnAdd.Visible = true;
            try
            {
                myConn = new MySqlConnection(sConnectionString);
                myConn.Open();
                var query = "select CalibrationDate, NextDueDate FROM tbldata_calibration_mix where `CalibrationDate` like('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "%') and `TypeOfReport`='" + TypeCombo.SelectedIndex.ToString() + "' and   MachineName='" + txtMachineName.Text + "' limit 1;";

                using (var command = new MySqlCommand(query, myConn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        int count = 0;
                        DateTime dt = new DateTime();
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            count++;
                            dt = reader.GetDateTime(0);
                            txtHH.Text = dt.Hour.ToString();
                            txtMM.Text = dt.Minute.ToString();
                            NextDueDate.Value = reader.GetDateTime(1);
                            //  batchcombo.Items.Add(reader.GetString("batchno"));
                        }
                        if (count <= 0)
                        {
                            txtHH.ReadOnly = false;
                            txtMM.ReadOnly = false;
                            NextDueDate.Enabled = true;
                            this.tbldata_calibration_mixTableAdapter.Fill(this.DataSet28.tbldata_calibration_mix, dateTimePicker1.Value, dateTimePicker1.Value.AddDays(1), TypeCombo.SelectedIndex.ToString(), txtMachineName.Text);
                            reportViewer1.RefreshReport();
                            IsReportStaerted = false;
                            //MessageBox.Show("Nameplate is not present");
                        }
                        else
                        {
                            string company = "";
                            string connectionString = "datasource=localhost;username=root;password=teamat";
                            string query1111 = "select count(*) from ultimate_ele1.tbl_cmpny";
                            MySqlConnection MyConn1111 = new MySqlConnection(connectionString);
                            MyConn1111.Open();
                            MySqlCommand MyCommand1111 = new MySqlCommand(query1111, MyConn1111);
                            int AnsCount = Convert.ToInt32(MyCommand1111.ExecuteScalar());

                            if (AnsCount == 0)                      // If data occure first time (New Data)
                            {
                                company = "Ultimate Electronics";

                            }
                            else
                            {
                                string query1 = "select cmpny_nm from ultimate_ele1.tbl_cmpny";
                                MySqlConnection MyConn1 = new MySqlConnection(connectionString);
                                MyConn1.Open();
                                MySqlCommand MyCommand1 = new MySqlCommand(query1, MyConn1);
                                //AnsCount = Convert.ToInt32(MyCommand1.ExecuteScalar());
                                company = Convert.ToString(MyCommand1.ExecuteScalar());



                            }


                            ReportParameter[] parms = new ReportParameter[6];
                            parms[0] = new ReportParameter("ReportTitle", "MyReport");
                            parms[1] = new ReportParameter("Col1Name", "Dead Load");
                            parms[2] = new ReportParameter("Col1Unit", "(Kg)");
                            parms[3] = new ReportParameter("Col4Name", "Observed Load");
                            parms[4] = new ReportParameter("ParaName", "Load");
                            parms[5] = new ReportParameter("Company", company);
                            this.reportViewer1.LocalReport.SetParameters(parms);
                            this.tbldata_calibration_mixTableAdapter.Fill(this.DataSet28.tbldata_calibration_mix, dateTimePicker1.Value, dateTimePicker1.Value.AddDays(1), TypeCombo.SelectedIndex.ToString(), txtMachineName.Text);
                            reportViewer1.RefreshReport();
                            txtHH.ReadOnly = true;
                            txtMM.ReadOnly = true;
                            NextDueDate.Enabled = false;
                            IsReportStaerted = true;
                            //MessageBox.Show("Nameplate is  present");
                        }
                    }
                }

                myConn.Close();
            }
            catch (MySqlException ex)
            {
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                DialogResult result = MessageBox.Show("Do you want to Update record..?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    myConn = new MySqlConnection(sConnectionString);
                    try
                    {
                        if (myConn != null) { }
                        myConn.Open();


                        var query = "update tbldata_calibration_mix set  DeadLoad='" + txtDeadLoad.Text + "', Observation1=" + txtObservation1.Text + ", Observation2='" + txtObservation2.Text + "',Observation3='" + txtObservation3.Text + "', remark='" + txtRemark.Text + "' where id=" + txtId.Text + "";
                        using (var command = new MySqlCommand(query, myConn))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                //while (reader.Read())
                                //{

                                //this.mouldnomasterTableAdapter.Fill(this.dataSet28.mouldnomaster);
                                this.tbldata_calibration_mixTableAdapter.Fill(this.DataSet28.tbldata_calibration_mix, dateTimePicker1.Value, dateTimePicker1.Value.AddDays(1), TypeCombo.SelectedIndex.ToString(), txtMachineName.Text);
                                reportViewer1.RefreshReport();
                                txtId.Text = "";
                                txtDeadLoad.Text = "";
                                txtObservation1.Text = "";
                                txtObservation2.Text = "";
                                txtObservation3.Text = "";
                                txtRemark.Text = "";
                                btnDelete.Visible = false;
                                btnUpdate.Visible = false;
                                btnAdd.Visible = true;
                                MessageBox.Show("Record Updation Successfully");
                                //}
                            }
                        }
                        myConn.Close();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("error occured contact Ultimate electronics");
                        //restartApplication();
                    }

                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsReportStaerted && txtDeadLoad.Text != "" && txtObservation1.Text != "" && txtObservation2.Text != "" && txtObservation3.Text != "")
            {
                DialogResult result = MessageBox.Show("Do you want to Insert record..?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    myConn = new MySqlConnection(sConnectionString);
                    try
                    {
                        if (myConn != null) { }
                        myConn.Open();




                        var query = "insert into tbldata_calibration_mix (DeadLoad, Observation1, Observation2, Observation3, Remark, TypeOfReport, CalibrationDate, NextDueDate, MachineName) values('" + txtDeadLoad.Text + "', '" + txtObservation1.Text + "','" + txtObservation2.Text + "','" + txtObservation3.Text + "', '" + txtRemark.Text + "','" + TypeCombo.SelectedIndex.ToString() + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + txtHH.Text + ":" + txtMM.Text + ":00" + "','" + NextDueDate.Value + "','" + txtMachineName.Text + "') ";
                        using (var command = new MySqlCommand(query, myConn))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                //while (reader.Read())
                                //{

                                //      this.mouldnomasterTableAdapter.Fill(this.dataSet28.mouldnomaster);
                                this.tbldata_calibration_mixTableAdapter.Fill(this.DataSet28.tbldata_calibration_mix, dateTimePicker1.Value, dateTimePicker1.Value.AddDays(1), TypeCombo.SelectedIndex.ToString(), txtMachineName.Text);
                                reportViewer1.RefreshReport();

                                txtId.Text = "";
                                txtDeadLoad.Text = "";
                                txtObservation1.Text = "";
                                txtObservation2.Text = "";
                                txtObservation3.Text = "";
                                txtRemark.Text = "";
                                btnDelete.Visible = false;
                                btnUpdate.Visible = false;
                                btnAdd.Visible = true;
                                MessageBox.Show("Record Inserted Successfully");
                                //}
                            }
                        }
                        myConn.Close();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("error occured contact Ultimate electronics");
                        //restartApplication();
                    }

                }
            }
            else
            {
                MessageBox.Show("Please Select All fields");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtDeadLoad.Text = "";
            txtObservation1.Text = "";
            txtObservation2.Text = "";
            txtObservation3.Text = "";
            txtRemark.Text = "";
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnAdd.Visible = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (txtId.Text != "")
            {
                DialogResult result = MessageBox.Show("Do you want to Delete record..?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    myConn = new MySqlConnection(sConnectionString);
                    try
                    {
                        if (myConn != null) { }
                        myConn.Open();


                        var query = "delete from tbldata_calibration_mix  where id=" + txtId.Text + "";
                        using (var command = new MySqlCommand(query, myConn))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                //while (reader.Read())
                                //{

                                //    this.mouldnomasterTableAdapter.Fill(this.dataSet28.mouldnomaster);
                                this.tbldata_calibration_mixTableAdapter.Fill(this.DataSet28.tbldata_calibration_mix, dateTimePicker1.Value, dateTimePicker1.Value.AddDays(1), TypeCombo.SelectedIndex.ToString(), txtMachineName.Text);
                                reportViewer1.RefreshReport();

                                txtId.Text = "";
                                txtDeadLoad.Text = "";
                                txtObservation1.Text = "";
                                txtObservation2.Text = "";
                                txtObservation3.Text = "";
                                txtRemark.Text = "";
                                btnDelete.Visible = false;
                                btnUpdate.Visible = false;
                                btnAdd.Visible = true;
                                MessageBox.Show("Record Deleted Successfully");
                                //}
                            }
                        }
                        myConn.Close();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("error occured contact Ultimate electronics");
                        //restartApplication();
                    }

                }
            }
        }
    }
}
