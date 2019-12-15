using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class CubeWater_Wider : Form
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        string theDate;
        //string connectionString;
        static string sConnectionString = ConfigurationManager.ConnectionStrings["MyConn007"].ConnectionString;
        Keys key;
        public MySqlConnection myConn7;
        SqlConnection con;
        MySqlCommandBuilder buil;
        SqlCommandBuilder bui;
        string str, batch;
        int i;
        public CubeWater_Wider()
        {
            InitializeComponent();
            key = (Keys)Properties.Settings.Default["ControlKeys"];
        }
        void nameplate()
        {

            try
            {
                connection = new MySqlConnection(sConnectionString);
                connection.Open();
                var query = "select count(*) FROM nameplate29_Wider where `date` like('" + theDate + "%') and batchno='" + batchcombo.SelectedItem.ToString() + "'  ;";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        int a = 0;
                        while (reader.Read())
                        {
                            a = Convert.ToInt16(reader.GetInt16(0));
                        }
                        reader.Close();
                        var queryForNoOfRecords = "select count(*) FROM tbldata_29_Wider where `date` like('" + theDate + "%') and mbatch='" + batchcombo.SelectedItem.ToString() + "'  ;";

                        using (var commandForNoOFRecords = new MySqlCommand(queryForNoOfRecords, connection))
                        {
                            using (MySqlDataReader readerForNoOfRecords = commandForNoOFRecords.ExecuteReader())
                            {
                                int count = 0;
                                while (readerForNoOfRecords.Read())
                                {
                                    count = Convert.ToInt32(readerForNoOfRecords.GetInt16(0));
                                }
                                if (count < 6)
                                {
                                    MessageBox.Show("Please Test 6 Cube's And Then Generate Report");
                                    gridfill();
                                }
                                else
                                {
                                    if (a <= 0)
                                    {
                                        gridfill();
                                        fillnameplate();
                                        btnok.Visible = true;
                                    }
                                    else
                                    {
                                        gridfill();
                                        retrivenameplate();
                                    }
                                }
                            }
                        }
                    }
                }

                connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        void fillnameplate()
        {
            shifttxt.ReadOnly = false;
            shifttxt.Text = "";
            MessageBox.Show("Please fill Bench No, Shift Noe & Press 'OK'");
        }
        void gridfill()
        {
            try
            {
                string company = "";
                string query1111 = "select count(*) from ultimate_ele1.tbl_cmpny";
                if (myConn7==null)
                    myConn7 = new MySqlConnection(sConnectionString);
                if (myConn7.State == System.Data.ConnectionState.Closed)
                    myConn7.Open();
                MySqlCommand MyCommand1111 = new MySqlCommand(query1111, myConn7);
                int AnsCount = Convert.ToInt32(MyCommand1111.ExecuteScalar());
                if (AnsCount == 0)                      // If data occure first time (New Data)
                {
                    company = "Ultimate Electronics";
                }
                else
                {
                    string query1 = "select cmpny_nm from ultimate_ele1.tbl_cmpny";
                    MySqlCommand MyCommand1 = new MySqlCommand(query1, myConn7);
                    company = Convert.ToString(MyCommand1.ExecuteScalar());
                }
                batch = batchcombo.SelectedItem.ToString();
                GlobalClass.adap = new MySqlDataAdapter("SELECT mbatch as `Batch No`, cubeno as `Cube No`, initialwt as `Initial WT`, castdate as `Cast Date`, ageindays as `Age IN Days`, `date` as `Date`,  laodinkn as `Laod in kn`, strength as `Strength`, mix_design as `Mix Design` FROM tbldata_29_Wider where mbatch = '" + batch + "' ;", myConn7);
                buil = new MySqlCommandBuilder(GlobalClass.adap);
                GlobalClass.dt = new DataTable();
                GlobalClass.adap.Fill(GlobalClass.dt);
                dataGridView1.DataSource = GlobalClass.dt;
                dataGridView1.ReadOnly = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void genraterpt()
        {
            try
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
                    company = Convert.ToString(MyCommand1.ExecuteScalar());
                }
                ReportParameter[] parms = new ReportParameter[4];
                parms[0] = new ReportParameter("Date", dateTimePicker1.Value.ToString("dd-MM-yyyy"));
                parms[1] = new ReportParameter("Batch", batchcombo.SelectedItem.ToString());
                parms[2] = new ReportParameter("Shift", shifttxt.Text);
                parms[3] = new ReportParameter("Company", company);
                this.reportViewer1.LocalReport.SetParameters(parms);
                this.tbldata_29_WiderTableAdapter1.Fill(this.DataSet28.tbldata_29_Wider, batchcombo.SelectedItem.ToString());
                this.reportViewer1.RefreshReport();
            }
            catch { }
        }
        void retrivenameplate()
        {
            btnok.Visible = false;
            try
            {
                connection = new MySqlConnection(sConnectionString);
                connection.Open();
                var query = "select distinct * FROM nameplate29_Wider where `date` like('" + theDate + "%') and batchno='" + batchcombo.SelectedItem.ToString() + "' ;";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        //id, date, batchno, shift, superviser, b1, b2, b3, b4, b5, b6, b7, b8, b9, b10
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            shifttxt.Text = reader.GetString(3).ToString();
                        }
                        shifttxt.ReadOnly = true;
                    }
                }
                genraterpt();
                connection.Close();
            }
            catch (MySqlException ex)
            {
            }
        }
        private void Form29_2_Load(object sender, EventArgs e)
        {
            getbatch();
            myConn7 = new MySqlConnection(sConnectionString);
            try
            {
                if (myConn7.State == System.Data.ConnectionState.Closed)
                myConn7.Open();
            }
            catch (System.Exception ex)
            {
            }
        }
        void getbatch()
        {
            try
            {
                batchcombo.SelectedIndex = -1;
                batchcombo.SelectedValue = "";
                batchcombo.SelectedText = "";
                batchcombo.SelectedItem = "";
                batchcombo.Items.Clear();
                theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                try
                {
                    connection = new MySqlConnection(sConnectionString);
                    connection.Open();
                    var query = "select distinct (`mbatch`) FROM tbldata_29_Wider where `date` like('" + theDate + "%')  ;";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            //Iterate through the rows and add it to the combobox's items
                            while (reader.Read())
                            {
                                batchcombo.Items.Add(reader.GetString("mbatch"));
                            }
                        }
                    }
                    if (batchcombo.Items.Count >= 1)
                        batchcombo.SelectedIndex = 0;
                    connection.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch { }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            getbatch();
        }

        private void batchcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.reportViewer1.Clear();
            if (batchcombo.SelectedIndex != -1)
                nameplate();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (shifttxt.Text == "" )
            {
                MessageBox.Show("Please Enter All fields ");
            }
            else
            {
                string query = "INSERT INTO nameplate29_Wider (`date`,  `batchno`,`shift`, `supervisor`) VALUES('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + batchcombo.SelectedItem.ToString() + "','" + shifttxt.Text + "',' ');";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    btnok.Visible = false;
                    shifttxt.ReadOnly = true;
                    genraterpt();
                }
                catch
                {
                }

            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            str = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            i = dataGridView1.Rows[e.RowIndex].Index;
            CubeWaterWider_Opereation op = new CubeWaterWider_Opereation(str, i);
            op.Show();
        }

        private void Form29_2_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form29_2_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyData==key)
            {
                if (reportViewer1.Visible == true)
                {
                    reportViewer1.Visible = false;
                    dataGridView1.Visible = true;
                }
                else
                {
                    reportViewer1.Visible = true;
                    dataGridView1.Visible = false;
                }
            }
        }
    }
}
