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
    public partial class CubeWater : Form
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        string theDate;
        string connectionString;
        static string sConnectionString = ConfigurationManager.ConnectionStrings["MyConn007"].ConnectionString;
        public MySqlConnection myConn7;
        Keys key;


        SqlConnection con;
        MySqlCommandBuilder buil;
        SqlCommandBuilder bui;
        string str, batch;
        int i;
        public CubeWater()
        {
            InitializeComponent();
            key = (Keys)Properties.Settings.Default["ControlKeys"];
        }
        void nameplate()
        {

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                var query = "select count(*) FROM nameplate29_2 where `date` like('" + theDate + "%') and batchno='" + batchcombo.SelectedItem.ToString() + "'  ;";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        int a = 0;
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            a = Convert.ToInt16(reader.GetInt16(0));

                            //  batchcombo.Items.Add(reader.GetString("batchno"));
                        }
                        if (a <= 0)
                        {

                            fillnameplate();
                            btnok.Visible = true;
                            //MessageBox.Show("Nameplate is not present");
                        }
                        else
                        {

                            retrivenameplate();
                            //MessageBox.Show("Nameplate is  present");
                        }
                    }
                }

                connection.Close();
            }
            catch (MySqlException ex)
            {
            }
        }
        void fillnameplate()
        {

            shifttxt.ReadOnly = false;
            //supervisertxt.ReadOnly = false;


            shifttxt.Text = "";
          //  supervisertxt.Text = "";
            MessageBox.Show("Please fill Bench No, Shift Noe & Press 'OK'");
           
        }
        void gridfill()
        {
            try
            {
                string company = "";
                string query1111 = "select count(*) from ultimate_ele1.tbl_cmpny";
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


                GlobalClass.adap = new MySqlDataAdapter("SELECT mbatch as `Batch No`, cubeno as `Cube No`, initialwt as `Initial WT`, castdate as `Cast Date`, ageindays as `Age IN Days`, `date` as `Date`,  laodinkn as `Laod in kn`, strength as `Strength`, mix_design as `Mix Design`  FROM tbldata_29_2 where mbatch = '" + batch + "' ;", myConn7);

                buil = new MySqlCommandBuilder(GlobalClass.adap);

                GlobalClass.dt = new DataTable();

                GlobalClass.adap.Fill(GlobalClass.dt);

                dataGridView1.DataSource = GlobalClass.dt;

                dataGridView1.ReadOnly = true;

            }
            catch (Exception ex)
            { }
        }
        void genraterpt()
        {
            gridfill();
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
                    //AnsCount = Convert.ToInt32(MyCommand1.ExecuteScalar());
                    company = Convert.ToString(MyCommand1.ExecuteScalar());



                }
                ReportParameter[] parms = new ReportParameter[4];
                parms[0] = new ReportParameter("Date", dateTimePicker1.Value.ToString("dd-MM-yyyy"));
                parms[1] = new ReportParameter("Batch", batchcombo.SelectedItem.ToString());
                parms[2] = new ReportParameter("Shift", shifttxt.Text);

                parms[3] = new ReportParameter("Company", company);
                this.reportViewer1.LocalReport.SetParameters(parms);
                this.tbldata_29_2TableAdapter.Fill(this.DataSet28.tbldata_29_2, batchcombo.SelectedItem.ToString());

                this.reportViewer1.RefreshReport();
            }
            catch { }
        }
        void retrivenameplate()
        {

            btnok.Visible = false;
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                var query = "select distinct * FROM nameplate29_2 where `date` like('" + theDate + "%') and batchno='" + batchcombo.SelectedItem.ToString() + "' ;";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        //id, date, batchno, shift, superviser, b1, b2, b3, b4, b5, b6, b7, b8, b9, b10
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            shifttxt.Text = reader.GetString(3).ToString();
                            //supervisertxt.Text = reader.GetString(4).ToString();


                            //  batchcombo.Items.Add(reader.GetString("batchno"));
                        }

                        shifttxt.ReadOnly = true;
                      //  supervisertxt.ReadOnly = true;

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
                if (myConn7 != null) { }
                myConn7.Open();

            }
            catch (System.Exception ex)
            {
                //restartApplication();
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
                server = "localhost";
                database = "ultimate_ele1";
                uid = "root";
                password = "teamat";

                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                connectionString = "Database=" + database + ";Server=localhost;UID=root;PWD=teamat;";
                try
                {
                    connection = new MySqlConnection(connectionString);
                    connection.Open();
                    var query = "select distinct (`mbatch`) FROM tbldata_29_2 where `date` like('" + theDate + "%')  ;";
                    //MessageBox.Show(query);
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
            if (batchcombo.SelectedIndex != -1)
                nameplate();
            else
            {
              //  MessageBox.Show("No Record Found!");
                this.reportViewer1.Clear();
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (shifttxt.Text == "" )
            {
                MessageBox.Show("Please Enter All fields ");
            }
            else
            {
                //INSERT INTO nameplate_temp (`date`,  `batchno`,`shift`, `superviser`, `b1`, `b2`, `b3`, `b4`,`b5`,`b6`,`b7`,`b8`,`b9`,`b10`) VALUES('2016-10-22','123','12','12','1','1','1','1','1','1','1','1','1','1');

                string query = "INSERT INTO nameplate29_2 (`date`,  `batchno`,`shift`, `supervisor`) VALUES('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + batchcombo.SelectedItem.ToString() + "','" + shifttxt.Text + "',' ');";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    btnok.Visible = false;

                    shifttxt.ReadOnly = true;
                  //  supervisertxt.ReadOnly = true;
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
            //Opereation_Form29_2 op = new Opereation_Form29_2(str, i);
            CubeWater_Opereation op = new CubeWater_Opereation(str, i);
            //Opereation op = new Opereation(str, i);
            op.Show();
        }

        private void Form29_2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form29_2_KeyPress(object sender, KeyEventArgs e)
        {
            
        }

        private void Form29_2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == key)
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
