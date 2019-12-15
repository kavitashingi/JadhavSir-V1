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
    public partial class Form28_1_B : Form
    {
          private MySqlConnection connection;
          static string sConnectionString = ConfigurationManager.ConnectionStrings["MyConn007"].ConnectionString;
          SqlConnection con;
          MySqlCommandBuilder buil;
          SqlCommandBuilder bui;
          string str, batch;
          int i;
          public MySqlConnection myConn7;
        private string server;
        private string database;
        private string uid;
        private string password;
        string theDate;
        string connectionString;
        Keys key;
        public Form28_1_B()
        {
            InitializeComponent();
            key = (Keys)Properties.Settings.Default["ControlKeys"];

        }
        void chechbatch()
        {
            if (txtbatch.Text == "")
            {
                MessageBox.Show("Please Enter Batch Number ");
            }
            else
            {

                try
                {
                    string company = "";
                    string connectionString = "datasource=localhost;username=root;password=teamat";
                    string query1111 = "select count(*) from ultimate_ele1.tbl_cmpny";
                    MySqlConnection MyConn1111 = new MySqlConnection(connectionString);
                    MyConn1111.Open();
                    MySqlCommand MyCommand1111 = new MySqlCommand(query1111, MyConn1111);

                    query1111 = "select count(*) from ultimate_ele1.tbldata_28_1 where mbatch='" + txtbatch.Text + "'";
                    MyCommand1111 = new MySqlCommand(query1111, MyConn1111);
                    int AnsCount = Convert.ToInt32(MyCommand1111.ExecuteScalar());

                    if (AnsCount == 0)                      // check data is present for this batch
                    {
                        MessageBox.Show("Please Enter Valid Batch Number");

                    }
                    else
                    {
                        nameplate();
                    }
                }
                catch (Exception de)
                {
                    MessageBox.Show(de.InnerException.ToString());
                }
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
                    //AnsCount = Convert.ToInt32(MyCommand1.ExecuteScalar());
                    company = Convert.ToString(MyCommand1.ExecuteScalar());



                }

                ReportParameter[] parms = new ReportParameter[3];
              
                parms[0] = new ReportParameter("Batch",txtbatch.Text);
                parms[1] = new ReportParameter("Shift", "1");

                parms[2] = new ReportParameter("Company", company);
                this.reportViewer1.LocalReport.SetParameters(parms);

                this.tbldata_28_1TableAdapter.Fill(this.DataSet28.tbldata_28_1, txtbatch.Text);

                this.reportViewer1.RefreshReport();

            }
            catch (Exception de)
            {
                MessageBox.Show(de.InnerException.ToString());
            }
        }
        private void btnshow_Click(object sender, EventArgs e)
        {
            chechbatch(); 

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet28.tbldata_28_1' table. You can move, or remove it, as needed.
            // this.tbldata_28_1TableAdapter.Fill(this.DataSet28.tbldata_28_1);
            reportViewer1.Visible = true;
            dataGridView1.Visible = false;
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

        void nameplate()
        {

            try
            {
                server = "localhost";
                database = "ultimate_ele1";
                uid = "root";
                password = "teamat";

                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                connectionString = "Database=" + database + ";Server=localhost;UID=root;PWD=teamat;";
                connection = new MySqlConnection(connectionString);
                connection.Open();
                var query = "select count(*) FROM nameplate28_1 where  batchno='" + txtbatch.Text + "'  ;";

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
            catch (Exception ex)
            {
            }
        }

        void gridfill()
        {
            try
            {
               

                batch =txtbatch.Text;

                GlobalClass.adap = new MySqlDataAdapter("SELECT mbatch as `Batch No`, sleeperno as `Sleeper No`, `date` as `Date`,castdate as `Cast Date`, top as `Top`, bottom as `Bottom`, mr1 as `MR1`, mr2 as `MR2`, mf1 as `MF1`, mf2 as `MF2` FROM tbldata_28_2 where mbatch = '" + batch + "' ;", myConn7);

                buil = new MySqlCommandBuilder(GlobalClass.adap);

                GlobalClass.dt = new DataTable();

                GlobalClass.adap.Fill(GlobalClass.dt);

                dataGridView1.DataSource = GlobalClass.dt;

                dataGridView1.ReadOnly = true;

            }
            catch (Exception ex)
            { }
        }
       
        void fillnameplate()
        {

            shifttxt.ReadOnly = false;
            //    supervisertxt.ReadOnly = false;


            shifttxt.Text = "";
            //     supervisertxt.Text = "";
            MessageBox.Show("Please fill Bench No, Shift No, Superviser Name & Press 'OK'");
        }
        
        void retrivenameplate()
        {

            btnok.Visible = false;
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                var query = "select distinct * FROM nameplate28_1 where `date` batchno='" + txtbatch.Text + "' ;";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        //id, date, batchno, shift, superviser, b1, b2, b3, b4, b5, b6, b7, b8, b9, b10
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            shifttxt.Text = reader.GetString(3).ToString();
                            //     supervisertxt.Text = reader.GetString(4).ToString();


                            //  batchcombo.Items.Add(reader.GetString("batchno"));
                        }

                        shifttxt.ReadOnly = true;
                        //   supervisertxt.ReadOnly = true;

                    }
                }
                genraterpt();
                connection.Close();
            }
            catch (MySqlException ex)
            {
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (shifttxt.Text == "")
            {
                MessageBox.Show("Please Enter All fields ");
            }
            else
            {
                //INSERT INTO nameplate_temp (`date`,  `batchno`,`shift`, `superviser`, `b1`, `b2`, `b3`, `b4`,`b5`,`b6`,`b7`,`b8`,`b9`,`b10`) VALUES('2016-10-22','123','12','12','1','1','1','1','1','1','1','1','1','1');

                string query = "INSERT INTO nameplate28_1 (`date`,  `batchno`,`shift`, `supervisor`) VALUES('2016-12-12 12:12:12 ','" + txtbatch.Text + "','" + shifttxt.Text + "',' ');";
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
                catch (MySqlException eqa)
                {
                    MessageBox.Show(eqa.InnerException.ToString());
                }
            }

        }

        private void Form28_1_B_KeyUp(object sender, KeyEventArgs e)
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
