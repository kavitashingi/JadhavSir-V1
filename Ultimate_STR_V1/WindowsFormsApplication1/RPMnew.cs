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
using System.Data.Odbc;
using System.IO;
using System.Resources;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class RPMnew : Form
    {

        static string sConnectionString = ConfigurationManager.ConnectionStrings["MyConn007"].ConnectionString;
        public MySqlConnection myConn7;
        private string server;
        private string database;
        private string uid;
        private string password;
        string theDate;
        string connectionString;
        //string batchno="";
        //SqlConnection con;
        //MySqlCommandBuilder buil;
        //SqlCommandBuilder bui;
        ////string str, batch;
        //int i;


        public OdbcConnection conn;

        SqlConnection con;
        MySqlCommandBuilder buil;
        SqlCommandBuilder bui;
        string str, batch;
        int i;
        public string temp = "";
        public static string Logger_File = "", Logger_Folder = "", Excel_Folder = "", Excel_Path = "";
        //public static string date, batchno, shift, supervisor, mixdesign, water, cement, ca1, ca2, fa, addmix, mbatch = "";
        public static string id, benchno, castingtime, rpm1, t1, batchno, rpm2, t2, rpm3, t3, rpm4, t4, rpm5, t5, rpm6, t6, rpm7, t7, rpm8, t8 = "";


        private MySqlConnection connection;
        Keys key;
        //private string server;
        //private string database;
        //private string uid;
        //private string password;
        //string theDate;
        //string connectionString;
        public RPMnew()
        {
            key = (Keys)Properties.Settings.Default["ControlKeys"];
            InitializeComponent();
        }

        private void RPMnew_Load(object sender, EventArgs e)
        {
            txtbatch.Visible = true;
            batchcombo.Visible = false;
            dateTimePicker1.Visible = false;
            label1.Visible = false;
            VB1.Visible = true;
            VB2.Visible = true;
            VB3.Visible = true;
            VB4.Visible = true;
            VB5.Visible = true;
            VB6.Visible = true;
            VB7.Visible = true;
            VB8.Visible = true;

            myConn7 = new MySqlConnection(sConnectionString);
            conn = new OdbcConnection(sConnectionString);
            try
            {
                if (myConn7 != null) { }
                myConn7.Open();

            }
            catch (System.Exception ex)
            {
                //restartApplication();
            }
            // TODO: This line of code loads data into the 'DataSet28.rpmdata' table. You can move, or remove it, as needed.
            getbatch();

            Resource_File_Values();             // Use for Excel import

        }
        string get_date_of_batch(string batch)
        {
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
                var query = "SELECT castingtime FROM rpmdata where batchno='" + batch + "' order by castingtime limit 0,1;";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            return reader.GetString(0);
                        }
                    }
                }


                connection.Close();

            }
            catch (MySqlException ex)
            {
            }
            return "";
        }
        void fillnameplate()
        {

            shifttxt.ReadOnly = false;
            VB1.ReadOnly = false;
            VB2.ReadOnly = false;
            VB3.ReadOnly = false;
            VB4.ReadOnly = false;
            VB5.ReadOnly = false;
            VB6.ReadOnly = false;
            VB7.ReadOnly = false;
            VB8.ReadOnly = false;

            //  supervisertxt.ReadOnly = false;


            shifttxt.Text = "";
            VB1.Text = "";
            VB2.Text = "";
            VB3.Text = "";
            VB4.Text = "";
            VB5.Text = "";
            VB6.Text = "";
            VB7.Text = "";
            VB8.Text = "";
            //  supervisertxt.Text = "";
            MessageBox.Show("Please fill Bench No, Shift No & Press 'OK'");
        }
        void fillnameplate1()
        {

            shifttxt.ReadOnly = false;
            VB1.ReadOnly = false;
            VB2.ReadOnly = false;
            VB3.ReadOnly = false;
            VB4.ReadOnly = false;
            VB5.ReadOnly = false; ;
            VB6.ReadOnly = false;
            VB7.ReadOnly = false;
            VB8.ReadOnly = false;

            //  supervisertxt.ReadOnly = false;


            shifttxt.Text = "";
            VB1.Text = "";
            VB2.Text = "";
            VB3.Text = "";
            VB4.Text = "";
            VB5.Text = "";
            VB6.Text = "";
            VB7.Text = "";
            VB8.Text = "";
            //  supervisertxt.Text = "";
            MessageBox.Show("Please fill Bench No, Shift No & Press 'OK'");
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

                ReportParameter[] parms = new ReportParameter[12];
                parms[0] = new ReportParameter("Date", dateTimePicker1.Value.ToString("dd-MM-yyyy"));
                parms[1] = new ReportParameter("Batch", batchcombo.SelectedItem.ToString());
                parms[2] = new ReportParameter("Shift", shifttxt.Text);
                parms[3] = new ReportParameter("Company", company);
                parms[4] = new ReportParameter("VB1", VB1.Text);
                parms[5] = new ReportParameter("VB2", VB2.Text);
                parms[6] = new ReportParameter("VB3", VB3.Text);
                parms[7] = new ReportParameter("VB4", VB4.Text);
                parms[8] = new ReportParameter("VB5", VB5.Text);
                parms[9] = new ReportParameter("VB6", VB6.Text);
                parms[10] = new ReportParameter("VB7", VB7.Text);
                parms[11] = new ReportParameter("VB8", VB8.Text);

                this.reportViewer1.LocalReport.SetParameters(parms);

                this.rpmdataTableAdapter.Fill(this.DataSet28.rpmdata, batchcombo.SelectedItem.ToString());
                //  this.rpmdataTableAdapter.Fill(

                //this.rpmdataTableAdapter.Fill(this.lg_123.rpmdata, batchcombo.SelectedItem.ToString());
                // this.rpmdataTableAdapter.Fill(this.
                this.reportViewer1.RefreshReport();

            }
            catch (Exception de)
            {
                MessageBox.Show(de.InnerException.ToString());
            }
        }
        void genraterpt1()
        {
            gridfill1();
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
                query1111 = "select count(*) from ultimate_ele1.rpmdata where batchno='" + txtbatch.Text + "'";
                MyCommand1111 = new MySqlCommand(query1111, MyConn1111);
                AnsCount = Convert.ToInt32(MyCommand1111.ExecuteScalar());

                if (AnsCount == 0)                      // If data occure first time (New Data)
                {
                    MessageBox.Show("Please Enter Valid Batch Number");

                }
                else
                {

                    string nwDate = get_date_of_batch(txtbatch.Text);
                    ReportParameter[] parms = new ReportParameter[12];
                    parms[0] = new ReportParameter("Date", nwDate);
                    parms[1] = new ReportParameter("Batch", txtbatch.Text);
                    parms[2] = new ReportParameter("Shift", shifttxt.Text);
                    parms[3] = new ReportParameter("Company", company);
                    parms[4] = new ReportParameter("VB1", VB1.Text);
                    parms[5] = new ReportParameter("VB2", VB2.Text);
                    parms[6] = new ReportParameter("VB3", VB3.Text);
                    parms[7] = new ReportParameter("VB4", VB4.Text);
                    parms[8] = new ReportParameter("VB5", VB5.Text);
                    parms[9] = new ReportParameter("VB6", VB6.Text);
                    parms[10] = new ReportParameter("VB7", VB7.Text);
                    parms[11] = new ReportParameter("VB8", VB8.Text);
                    this.reportViewer1.LocalReport.SetParameters(parms);

                    this.rpmdataTableAdapter.Fill(this.DataSet28.rpmdata, txtbatch.Text);
                    //  this.rpmdataTableAdapter.Fill(

                    //this.rpmdataTableAdapter.Fill(this.lg_123.rpmdata, batchcombo.SelectedItem.ToString());
                    // this.rpmdataTableAdapter.Fill(this.
                    this.reportViewer1.RefreshReport();

                }
            }
            catch (Exception de)
            {
                MessageBox.Show(de.InnerException.ToString());
            }

        }
        void retrivenameplate()
        {

            btnok.Visible = false;
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                var query = "select distinct * FROM nameplaterpm where `date` like('" + theDate + "%') and batchno='" + batchcombo.SelectedItem.ToString() + "' ;";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        //id, date, batchno, shift, superviser, b1, b2, b3, b4, b5, b6, b7, b8, b9, b10
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            shifttxt.Text = reader.GetString(3).ToString();
                            //   supervisertxt.Text = reader.GetString(4).ToString();
                            VB1.Text = reader.GetString(5).ToString();
                            VB2.Text = reader.GetString(6).ToString();
                            VB3.Text = reader.GetString(7).ToString();
                            VB4.Text = reader.GetString(8).ToString();
                            VB5.Text = reader.GetString(9).ToString();
                            VB6.Text = reader.GetString(10).ToString();
                            VB7.Text = reader.GetString(11).ToString();
                            VB8.Text = reader.GetString(12).ToString();

                            //  batchcombo.Items.Add(reader.GetString("batchno"));
                        }

                        shifttxt.ReadOnly = true;
                        VB1.ReadOnly = true;
                        VB2.ReadOnly = true;
                        VB3.ReadOnly = true;
                        VB4.ReadOnly = true;
                        VB5.ReadOnly = true;
                        VB6.ReadOnly = true;
                        VB7.ReadOnly = true;
                        VB8.ReadOnly = true;

                        //       supervisertxt.ReadOnly = true;

                    }
                }
                genraterpt();
                connection.Close();
            }
            catch (MySqlException ex)
            {
            }
        }
        void nameplate()
        {

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                var query = "select count(*) FROM nameplaterpm where `date` like('" + theDate + "%') and batchno='" + batchcombo.SelectedItem.ToString() + "'  ;";

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
                            //  MessageBox.Show("Nameplate is not present");
                        }
                        else
                        {

                            retrivenameplate();

                        }
                    }
                }

                connection.Close();
            }
            catch (MySqlException ex)
            {
            }
        }
        void retrivenameplate1()
        {

            btnok.Visible = false;
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                var query = "select distinct * FROM nameplaterpm where  batchno='" + txtbatch.Text + "' ;";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        //id, date, batchno, shift, superviser, b1, b2, b3, b4, b5, b6, b7, b8, b9, b10
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            shifttxt.Text = reader.GetString(3).ToString();
                            VB1.Text = reader.GetString(5).ToString();
                            VB2.Text = reader.GetString(6).ToString();
                            VB3.Text = reader.GetString(7).ToString();
                            VB4.Text = reader.GetString(8).ToString();
                            VB5.Text = reader.GetString(9).ToString();
                            VB6.Text = reader.GetString(10).ToString();
                            VB7.Text = reader.GetString(11).ToString();
                            VB8.Text = reader.GetString(12).ToString();
                            //   supervisertxt.Text = reader.GetString(4).ToString();


                            //  batchcombo.Items.Add(reader.GetString("batchno"));
                        }

                        shifttxt.ReadOnly = true;
                        VB1.ReadOnly = true;
                        VB2.ReadOnly = true;
                        VB3.ReadOnly = true;
                        VB4.ReadOnly = true;
                        VB5.ReadOnly = true;
                        VB6.ReadOnly = true;
                        VB7.ReadOnly = true;
                        VB8.ReadOnly = true;

                        //       supervisertxt.ReadOnly = true;

                    }
                }
                genraterpt1();
                connection.Close();
            }
            catch (MySqlException ex)
            {
            }
        }
        void nameplate1()
        {

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                var query = "select count(*) FROM nameplaterpm where  batchno='" + txtbatch.Text + "'  ;";

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

                            fillnameplate1();
                            btnok.Visible = true;
                            //  MessageBox.Show("Nameplate is not present");
                        }
                        else
                        {

                            retrivenameplate1();

                        }
                    }
                }

                connection.Close();
            }
            catch (MySqlException ex)
            {
            }
        }
        void getbatch()
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
                var query = "select distinct (`batchno`) FROM rpmdata where `castingtime` like('" + theDate + "%')  ;";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            batchcombo.Items.Add(reader.GetString("batchno"));
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
                //benchno, castingtime, rpm1, t1, batchno, rpm2, t2, rpm3, t3, rpm4, t4, rpm5, t5, rpm6, t6, rpm7, t7, rpm8, t8
                GlobalClass.adap = new MySqlDataAdapter("SELECT benchno, castingtime, batchno, rpm1, t1, rpm2, t2, rpm3, t3, rpm4, t4, rpm5, t5, rpm6, t6, rpm7, t7, rpm8, t8 FROM rpmdata where batchno = '" + batch + "' order by castingtime ;", myConn7);
                //GlobalClass.adap = new MySqlDataAdapter("SELECT mbatch as `Batch No`, castdate as `Cast Date`, `sleeperno` as `sleeperno`, ageindays as `Age In Days`, `date` as `Date`, loadinkn as `Load In Kn`, strength as `Strength` FROM tbldata_28_2 where mbatch = '" + batch + "' ;", myConn7);

                buil = new MySqlCommandBuilder(GlobalClass.adap);

                GlobalClass.dt = new DataTable();

                GlobalClass.adap.Fill(GlobalClass.dt);

                dataGridView1.DataSource = GlobalClass.dt;

                dataGridView1.ReadOnly = true;

            }
            catch (Exception ex)
            { }
        }
        void gridfill1()
        {

            ////////////////////////////////////////////////////////////


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
                query1111 = "select count(*) from ultimate_ele1.rpmdata where batchno='" + txtbatch.Text + "'";
                MyCommand1111 = new MySqlCommand(query1111, MyConn1111);
                AnsCount = Convert.ToInt32(MyCommand1111.ExecuteScalar());

                if (AnsCount == 0)                      // If data occure first time (New Data)
                {
                    MessageBox.Show("Please Enter Valid Batch Number");

                }
                else
                {

                    batch = txtbatch.Text;
                    //benchno, castingtime, rpm1, t1, batchno, rpm2, t2, rpm3, t3, rpm4, t4, rpm5, t5, rpm6, t6, rpm7, t7, rpm8, t8
                    GlobalClass.adap = new MySqlDataAdapter("SELECT benchno, castingtime, batchno, rpm1, t1, rpm2, t2, rpm3, t3, rpm4, t4, rpm5, t5, rpm6, t6, rpm7, t7, rpm8, t8 FROM rpmdata where batchno = '" + batch + "' order by castingtime ;", myConn7);
                    //GlobalClass.adap = new MySqlDataAdapter("SELECT mbatch as `Batch No`, castdate as `Cast Date`, `sleeperno` as `sleeperno`, ageindays as `Age In Days`, `date` as `Date`, loadinkn as `Load In Kn`, strength as `Strength` FROM tbldata_28_2 where mbatch = '" + batch + "' ;", myConn7);

                    buil = new MySqlCommandBuilder(GlobalClass.adap);

                    GlobalClass.dt = new DataTable();

                    GlobalClass.adap.Fill(GlobalClass.dt);

                    dataGridView1.DataSource = GlobalClass.dt;

                    dataGridView1.ReadOnly = true;

                }
            }
            catch (Exception de)
            {
                MessageBox.Show(de.InnerException.ToString());
            }


            //////////////////////////////////////////////////////////
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            getbatch();
        }

        private void batchcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (batchcombo.Items.Count > 0)
            {
                if (batchcombo.SelectedIndex != -1)
                {
                    //  nameplate();
                    // gridfill();
                }
            }
            else if (batchcombo.Items.Count == 0)
                MessageBox.Show("No record found");
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (shifttxt.Text == "" || VB1.Text == "" || VB2.Text == "" || VB3.Text == "" || VB4.Text == "" || VB5.Text == "" || VB6.Text == "" || VB7.Text == "" || VB8.Text == "")
            {
                MessageBox.Show("Please Enter All fields ");
            }
            else if (rdodate.Checked == true)
            {
                //INSERT INTO nameplate_temp (`date`,  `batchno`,`shift`, `superviser`, `b1`, `b2`, `b3`, `b4`,`b5`,`b6`,`b7`,`b8`,`b9`,`b10`) VALUES('2016-10-22','123','12','12','1','1','1','1','1','1','1','1','1','1');

                string query = "INSERT INTO nameplaterpm (`date`,  `batchno`,`shift`, `supervisor`,vb1,vb2,vb3,vb4,vb5,vb6,vb7,vb8) VALUES('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + batchcombo.SelectedItem.ToString() + "','" + shifttxt.Text + "','','" + VB1.Text + "','" + VB2.Text + "','" + VB3.Text + "','" + VB4.Text + "','" + VB5.Text + "','" + VB6.Text + "','" + VB7.Text + "','" + VB8.Text + "');";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    btnok.Visible = false;

                    shifttxt.ReadOnly = true;
                    VB1.ReadOnly = true;
                    VB2.ReadOnly = true;
                    VB3.ReadOnly = true;
                    VB4.ReadOnly = true;
                    VB5.ReadOnly = true;
                    VB6.ReadOnly = true;
                    VB7.ReadOnly = true;
                    VB8.ReadOnly = true;

                    //   supervisertxt.ReadOnly = true;
                    genraterpt();
                }
                catch
                {
                }
            }
            else if (rdobatch.Checked == true)
            {
                //INSERT INTO nameplate_temp (`date`,  `batchno`,`shift`, `superviser`, `b1`, `b2`, `b3`, `b4`,`b5`,`b6`,`b7`,`b8`,`b9`,`b10`) VALUES('2016-10-22','123','12','12','1','1','1','1','1','1','1','1','1','1');
                //string query = "INSERT INTO nameplaterpm (`date`,  `batchno`,`shift`, `supervisor`) VALUES('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + txtbatch.Text + "','" + shifttxt.Text + "',' ');";
                string query = "INSERT INTO nameplaterpm (`date`,  `batchno`,`shift`, `supervisor`,vb1,vb2,vb3,vb4,vb5,vb6,vb7,vb8) VALUES('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + txtbatch.Text + "','" + shifttxt.Text + "','','" + VB1.Text + "','" + VB2.Text + "','" + VB3.Text + "','" + VB4.Text + "','" + VB5.Text + "','" + VB6.Text + "','" + VB7.Text + "','" + VB8.Text + "');";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    btnok.Visible = false;

                    shifttxt.ReadOnly = true;
                    VB1.ReadOnly = true;
                    VB2.ReadOnly = true;
                    VB3.ReadOnly = true;
                    VB4.ReadOnly = true;
                    VB5.ReadOnly = true;
                    VB6.ReadOnly = true;
                    VB7.ReadOnly = true;
                    VB8.ReadOnly = true;

                    //   supervisertxt.ReadOnly = true;
                    genraterpt1();
                }
                catch
                {
                }
            }
        }

        private void RPMnew_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == key)
            {
                if (reportViewer1.Visible == true)
                {
                    reportViewer1.Visible = false;
                    dataGridView1.Visible = true;
                    btn_import.Visible = true;
                }
                else
                {

                    reportViewer1.Visible = true;
                    dataGridView1.Visible = false;
                    btn_import.Visible = false;
                }
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            str = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            i = dataGridView1.Rows[e.RowIndex].Index;
            RPM_Opereation op = new RPM_Opereation(str, i);
            //Opereation op = new Opereation(str, i);
            op.Show();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void rdobatch_CheckedChanged(object sender, EventArgs e)
        {
            txtbatch.Visible = true;
            batchcombo.Visible = false;
            dateTimePicker1.Visible = false;
            label1.Visible = false;
        }

        private void rdodate_CheckedChanged(object sender, EventArgs e)
        {
            txtbatch.Visible = false;
            batchcombo.Visible = true;
            dateTimePicker1.Visible = true;
            label1.Visible = true;
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            if (rdodate.Checked == true)
            {
                if (batchcombo.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select batch no ");
                }
                else
                {
                    nameplate();
                }
            }
            else
            {
                if (txtbatch.Text == "")
                {
                    MessageBox.Show("Please Enter Batch Number ");
                }
                else
                {
                    nameplate1();
                }

            }
        }


        #region Import Data from Excel File Code

        #region After button click Excel data import code
        private void btn_import_Click(object sender, EventArgs e)
        {
            try
            {
                Import_Excel_File();
            }
            catch (Exception ex)
            {
                temp = " RPM Excel read problem. Please check excel file or file extension. ";
                this.LogError(ex, temp);
            }
        }
        #endregion  After button click Excel data import code

        #region Read Excel file main function
        public void Import_Excel_File()
        {
            try
            {
                bool ans = IsFileOpen(Excel_Path);
                if (ans != true)
                {
                    OleDbConnection oledbConn = null;
                    try
                    {
                        oledbConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Excel_Path + ";Extended Properties='Excel 12.0;HDR=YES;';");
                        oledbConn.Open();
                    }
                    catch (Exception ex)
                    {
                        this.LogError(ex);
                    }

                    OleDbCommand cmd = new OleDbCommand();
                    OleDbDataAdapter oleda = new OleDbDataAdapter();
                    DataSet ds = new DataSet();

                    cmd.Connection = oledbConn;
                    cmd.CommandType = CommandType.Text;

                    try
                    {
                        cmd.CommandText = "SELECT DISTINCT * FROM [Sheet1$] ";
                        oleda = new OleDbDataAdapter(cmd);
                        oleda.Fill(ds);
                    }
                    catch (Exception ex)
                    {
                        this.LogError(ex);
                    }

                    try
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (ds.Tables[0].Rows[i][0].ToString() == "")
                            {
                                continue;
                            }
                            try
                            {
                                #region Old Date format
                                ////25-12-2017 11:59:35
                                //string dd, mm, yy, hh, mi, ss;

                                //dd = input.Substring(0, 2);
                                //mm = input.Substring(3, 2);
                                //yy = input.Substring(6, 4);

                                //hh = input.Substring(11, 2);
                                //mi = input.Substring(14, 2);
                                //ss = input.Substring(17, 2); 
                                #endregion

                                string inputDate = ds.Tables[0].Rows[i][0].ToString();
                                string inputTime = ds.Tables[0].Rows[i][1].ToString();

                                string[] temp_date = inputDate.Split('_');
                                string[] temp_time = inputTime.Split('_');

                                castingtime = Convert.ToString(temp_date[2] + "-" + temp_date[1] + "-" + temp_date[0] + " " + temp_time[0] + ":" + temp_time[1] + ":00");

                                //castingtime = Convert.ToString(yy + "-" + mm + "-" + dd + " " + hh + ":" + mi + ":" + ss);

                                //id, benchno, castingtime, rpm1, t1, batchno, rpm2, t2, rpm3, t3, rpm4, t4, rpm5, t5, rpm6, t6, rpm7, t7, rpm8, t8

                                benchno = ds.Tables[0].Rows[i][3].ToString();
                                batchno = ds.Tables[0].Rows[i][2].ToString();

                                rpm1 = ds.Tables[0].Rows[i][4].ToString();
                                t1 = ds.Tables[0].Rows[i][5].ToString();
                                rpm2 = ds.Tables[0].Rows[i][6].ToString();
                                t2 = ds.Tables[0].Rows[i][7].ToString();
                                rpm3 = ds.Tables[0].Rows[i][8].ToString();
                                t3 = ds.Tables[0].Rows[i][9].ToString();
                                rpm4 = ds.Tables[0].Rows[i][10].ToString();
                                t4 = ds.Tables[0].Rows[i][11].ToString();
                                rpm5 = ds.Tables[0].Rows[i][12].ToString();
                                t5 = ds.Tables[0].Rows[i][13].ToString();
                                rpm6 = ds.Tables[0].Rows[i][14].ToString();
                                t6 = ds.Tables[0].Rows[i][15].ToString();
                                rpm7 = ds.Tables[0].Rows[i][16].ToString();
                                t7 = ds.Tables[0].Rows[i][17].ToString();
                                rpm8 = ds.Tables[0].Rows[i][18].ToString();
                                t8 = ds.Tables[0].Rows[i][19].ToString();


                                if (castingtime != "" || batchno != "" || benchno != "" || rpm1 != "" || rpm2 != "" || rpm3 != "" || rpm4 != "" || rpm5 != "" || rpm6 != "" || rpm7 != "" || rpm8 != "" || t1 != "" || t2 != "" || t3 != "" || t4 != "" || t5 != "" || t6 != "" || t7 != "" || t8 != "")
                                {
                                    string strQuery1082, strQuery1083;
                                    try
                                    {
                                        strQuery1082 = "SELECT count(*) FROM rpmdata where `castingtime`='" + castingtime + "' and batchno='" + batchno.Trim() + "' and benchno='" + benchno.Trim() + "' and rpm1 = '" + rpm1.Trim() + "'  and t1 = '" + t1.Trim() + "' and rpm2 = '" + rpm2.Trim() + "'  and t2 = '" + t2.Trim() + "'  and rpm3 = '" + rpm3.Trim() + "'  and t3 ='" + t3.Trim() + "' and rpm4 ='" + rpm4.Trim() + "'  and t4 ='" + t4.Trim() + "' and rpm5 ='" + rpm5.Trim() + "'  and t5 ='" + t5.Trim() + "' and rpm6 ='" + rpm6.Trim() + "'  and t6 ='" + t6.Trim() + "' and rpm7 ='" + rpm7.Trim() + "'  and t7 = '" + t7.Trim() + "' and rpm8 ='" + rpm8.Trim() + "'  and t8 ='" + t8.Trim() + "' ;";
                                        temp = strQuery1082;
                                        //OdbcCommand cmd10822 = new OdbcCommand(strQuery1082, conn);
                                        MySqlCommand cmd10822 = new MySqlCommand(strQuery1082, myConn7);
                                        int AnsCount2 = Convert.ToInt32(cmd10822.ExecuteScalar());


                                        //strQuery1083 = "SELECT count(*) FROM tbldata_31 where `date`='" + date + "' and batchno='" + batchno.Trim() + "' and mixdesign= '" + mixdesign.Trim() + "' and water='" + water.Trim() + "' and cement='" + cement.Trim() + "' and ca1='" + ca1.Trim() + "'  and ca2= '" + ca2.Trim() + "' and fa='" + fa.Trim() + "' and addmix='" + addmix.Trim() + "' and mbatch='" + batchno.Trim() + "';";
                                        //temp = strQuery1083;
                                        ////OdbcCommand cmd10823 = new OdbcCommand(strQuery1083, conn);
                                        //MySqlCommand cmd10823 = new MySqlCommand(strQuery1083, myConn7);
                                        //int AnsCount3 = Convert.ToInt32(cmd10823.ExecuteScalar());


                                        if (AnsCount2 == 0)// && AnsCount3 == 0)
                                        {

                                            string strQuery2111;
                                            //OdbcDataReader MyReader2111;
                                            MySqlDataReader MyReader2111;
                                            strQuery2111 = "INSERT INTO rpmdata (benchno, castingtime, rpm1, t1, batchno, rpm2, t2, rpm3, t3, rpm4, t4, rpm5, t5, rpm6, t6, rpm7, t7, rpm8, t8)  VALUES ('" + benchno.Trim() + "','" + castingtime.Trim() + "','" + rpm1.Trim() + "','" + t1.Trim() + "','" + batchno.Trim() + "','" + rpm2.Trim() + "','" + t2.Trim() + "','" + rpm3.Trim() + "','" + t3.Trim() + "','" + rpm4.Trim() + "','" + t4.Trim() + "','" + rpm5.Trim() + "','" + t5.Trim() + "','" + rpm6.Trim() + "','" + t6.Trim() + "','" + rpm7.Trim() + "','" + t7.Trim() + "','" + rpm8.Trim() + "','" + t8.Trim() + "');";
                                            temp = strQuery2111;
                                            //OdbcCommand MyCommand2111 = new OdbcCommand(strQuery2111, conn);
                                            MySqlCommand MyCommand2111 = new MySqlCommand(strQuery2111, myConn7);
                                            MyReader2111 = MyCommand2111.ExecuteReader();
                                            MyReader2111.Close();


                                            //string strQuery211;
                                            ////OdbcDataReader MyReader211;
                                            //MySqlDataReader MyReader211;
                                            //strQuery211 = "INSERT INTO tbldata_31 (`date`, batchno, mixdesign, water, cement, ca1, ca2, fa, addmix, mbatch) VALUES ('" + date + "','" + batchno.Trim() + "','" + mixdesign.Trim() + "','" + water.Trim() + "','" + cement.Trim() + "','" + ca1.Trim() + "','" + ca2.Trim() + "','" + fa.Trim() + "','" + addmix.Trim() + "','" + batchno.Trim() + "');";
                                            //temp = strQuery211;
                                            ////OdbcCommand MyCommand211 = new OdbcCommand(strQuery211, conn);
                                            //MySqlCommand MyCommand211 = new MySqlCommand(strQuery211, myConn7);
                                            //MyReader211 = MyCommand211.ExecuteReader();
                                            //MyReader211.Close();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        this.LogError(ex, temp);
                                    }
                                }
                                else
                                { }
                            }
                            catch (Exception ex)
                            {
                                this.LogError(ex);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        this.LogError(ex);
                    }
                    finally
                    {
                        if (oledbConn.State != ConnectionState.Closed)
                            oledbConn.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                this.LogError(ex);
            }
        }
        #endregion Read Excel file main function

        #region Logger File
        private void LogError(Exception ex)
        {

            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            //message += string.Format("StackTrace: {0}", ex.StackTrace);
            //message += Environment.NewLine;
            //message += string.Format("Source: {0}", ex.Source);
            //message += Environment.NewLine;
            //message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            //message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            //string path = Microsoft.SqlServer.Server.MapPath("~/ErrorLog/ErrorLog.txt");

            string fpath = Logger_Folder;
            if (!Directory.Exists(fpath))
            {
                Directory.CreateDirectory(fpath);
            }
            string path = Logger_File;
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
        private void LogError(Exception ex, string temp)
        {

            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("Error Because of this Query: {0}", " ' " + temp + " ' ");
            message += Environment.NewLine;
            //message += string.Format("StackTrace: {0}", ex.StackTrace);
            //message += Environment.NewLine;
            //message += string.Format("Source: {0}", ex.Source);
            //message += Environment.NewLine;
            //message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            //message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            //string path = Microsoft.SqlServer.Server.MapPath("~/ErrorLog/ErrorLog.txt");

            string fpath = Logger_Folder;
            if (!Directory.Exists(fpath))
            {
                Directory.CreateDirectory(fpath);
            }
            string path = Logger_File;
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
        #endregion Logger File

        #region Resource file values
        public void Resource_File_Values()
        {
            try
            {
                string resxFile = @"E:\AT\Excel_Import_Path.resx"; // relative directory to the executable file
                using (ResXResourceSet resxSet = new ResXResourceSet(resxFile))
                {
                    Logger_Folder = resxSet.GetString("Logger_Folder");
                    Logger_File = resxSet.GetString("Logger_File");
                    Excel_Folder = resxSet.GetString("Excel_Folder");
                    Excel_Path = resxSet.GetString("Excel_Path_RPM");
                }
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
        }
        #endregion Resource file values

        public bool IsFileOpen(string path)                                  // Check the CSV File is open or not.  
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
                return false;
            }
            catch (IOException ex)
            {
                return true;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        #endregion  Import Data from Excel File Code

    }
}
