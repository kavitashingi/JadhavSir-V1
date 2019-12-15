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
    public partial class reporttemp_new : Form
    {
        private MySqlConnection connection;
        static string sConnectionString = ConfigurationManager.ConnectionStrings["MyConn007"].ConnectionString;
        public MySqlConnection myConn7;
        private string server;
        private string database;
        private string uid;
        private string password;
        string theDate;
        string connectionString;
        Keys key;

        public OdbcConnection conn;

        SqlConnection con;
        MySqlCommandBuilder buil;
        SqlCommandBuilder bui;
        string str, batch;
        int i;
        public string temp = "";
        public static string Logger_File = "", Logger_Folder = "", Excel_Folder = "", Excel_Path = "";
        public string tempbatch = "", Machine_id, prosess_no, set_value, process_value, date_stamp, batchno = "";
        int tempminut = -30;

        void retrivenameplate(string batch)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                var query = "select distinct * FROM nameplate_temp where `date` like('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "%') and batchno='" + batch + "' and chemberno=" + chembercombo.SelectedItem.ToString() + ";";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        //id, date, batchno, shift, superviser, b1, b2, b3, b4, b5, b6, b7, b8, b9, b10
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {

                            supervisertxt.Text = reader.GetString(4).ToString();
                            b1.Text = reader.GetString(5).ToString();
                            b2.Text = reader.GetString(6).ToString();
                            b3.Text = reader.GetString(7).ToString();
                            b4.Text = reader.GetString(8).ToString();
                            b5.Text = reader.GetString(9).ToString();
                            b6.Text = reader.GetString(10).ToString();
                            b7.Text = reader.GetString(11).ToString();
                            b8.Text = reader.GetString(12).ToString();
                            b9.Text = reader.GetString(13).ToString();
                            b10.Text = reader.GetString(14).ToString();
                            batchtxt.Text = reader.GetString(2).ToString();
                            //  batchcombo.Items.Add(reader.GetString("batchno"));
                        }
                        b1.ReadOnly = true;
                        b2.ReadOnly = true;
                        b3.ReadOnly = true;
                        b4.ReadOnly = true;
                        b5.ReadOnly = true;
                        b6.ReadOnly = true;
                        b7.ReadOnly = true;
                        b8.ReadOnly = true;
                        b9.ReadOnly = true;
                        b10.ReadOnly = true;

                        batchtxt.ReadOnly = true;
                        supervisertxt.ReadOnly = true;
                        genraterpt();
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

            btnok.Visible = true;
            b1.ReadOnly = false;
            b2.ReadOnly = false;
            b3.ReadOnly = false;
            b4.ReadOnly = false;
            b5.ReadOnly = false;
            b6.ReadOnly = false;
            b7.ReadOnly = false;
            b8.ReadOnly = false;
            b9.ReadOnly = true;
            b10.ReadOnly = false;
            batchtxt.ReadOnly = false;
            supervisertxt.ReadOnly = false;

            b1.Text = "";
            b2.Text = "";
            b3.Text = "";
            b4.Text = "";
            b5.Text = "";
            b6.Text = "";
            b7.Text = "";
            b8.Text = "";
            b9.Text = "L.B.C.";
            b10.Text = "";
            batchtxt.Text = "";
            supervisertxt.Text = "";
            MessageBox.Show("Please fill Bench No, Shift No, Superviser Name & Press 'OK'");
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

                batch = batchtxt.Text;
                //Machine id, prosess no, set value, process value, date stamp, batchno
                GlobalClass.adap = new MySqlDataAdapter("SELECT `Machine id`, `prosess no`, `set value`, `process value`, `date stamp`, `batchno` FROM temp where batchno = '" + batch + "' and `machine id`='" + chembercombo.SelectedItem.ToString() + "' order by `date stamp`", myConn7);
                //GlobalClass.adap = new MySqlDataAdapter("SELECT `Machine id`, `prosess no`, `set value`, `process value`, `date stamp`, `batchno` FROM temp where batchno = '" + batch + "' ;", myConn7);
                ////GlobalClass.adap = new MySqlDataAdapter("SELECT mbatch as `Batch No`, castdate as `Cast Date`, `sleeperno` as `sleeperno`, ageindays as `Age In Days`, `date` as `Date`, loadinkn as `Load In Kn`, strength as `Strength` FROM tbldata_28_2 where mbatch = '" + batch + "' ;", myConn7);

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




            ReportParameter[] parms = new ReportParameter[16];
            parms[0] = new ReportParameter("Date", dateTimePicker1.Value.ToString("dd-MM-yyyy"));
            parms[1] = new ReportParameter("Batch", batchtxt.Text);
            parms[2] = new ReportParameter("Shift", shiftcombo.SelectedItem.ToString());
            parms[3] = new ReportParameter("Supervisor", supervisertxt.Text);
            parms[4] = new ReportParameter("Chember", chembercombo.SelectedItem.ToString());
            parms[5] = new ReportParameter("B1", b1.Text);
            parms[6] = new ReportParameter("B2", b2.Text);
            parms[7] = new ReportParameter("B3", b3.Text);
            parms[8] = new ReportParameter("B4", b4.Text);
            parms[9] = new ReportParameter("B5", b5.Text);
            parms[10] = new ReportParameter("B6", b6.Text);
            parms[11] = new ReportParameter("B7", b7.Text);
            parms[12] = new ReportParameter("B8", b8.Text);
            parms[13] = new ReportParameter("B9", b9.Text);
            parms[14] = new ReportParameter("B10", b10.Text);
            parms[15] = new ReportParameter("Company", company);
            // parms[1] = new ReportParameter("param_course", textbox(n).text);

            this.reportViewer1.LocalReport.SetParameters(parms);
            // TODO: This line of code loads data into the 'DataSet28.temp' table. You can move, or remove it, as needed.
            this.tempTableAdapter.Fill(this.DataSet28.temp, batchtxt.Text, Convert.ToInt16(chembercombo.SelectedItem.ToString()));
            // TODO: This line of code loads data into the 'DataSet28.temp_calculation' table. You can move, or remove it, as needed.
            this.temp_calculationTableAdapter.Fill(this.DataSet28.temp_calculation, batchtxt.Text, Convert.ToInt16(chembercombo.SelectedItem.ToString()));
            //  this.rpmdataTableAdapter.Fill(this.lg_123.rpmdata, batchcombo.SelectedItem.ToString(), theDate);
            // this.reportViewer1.DataBindings
            this.reportViewer1.RefreshReport();


        }
        public reporttemp_new()
        {
            InitializeComponent();
        }
        string getbatchfrmtemp()
        {

            //select batchno from nameplate_temp where date(`date`)='2016-10-26' and shift='1' and chemberno='1';
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string b = "";
            string qry = "select count(*) from temp where batchno='#" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "_" + shiftcombo.SelectedItem.ToString() + "' and `machine id`='" + chembercombo.SelectedItem.ToString() + "';";


            try
            {


                using (var command = new MySqlCommand(qry, connection))
                {
                    using (MySqlDataReader reader1 = command.ExecuteReader())
                    {

                        //Iterate through the rows and add it to the combobox's items
                        while (reader1.Read())
                        {
                            b = reader1.GetString(0);

                            //  batchcombo.Items.Add(reader.GetString("batchno"));
                        }

                    }
                }
                if (Convert.ToInt16(b) < 1)
                    MessageBox.Show("No Data Present");
                else
                {
                    qry = "select batchno from temp where batchno='#" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "_" + shiftcombo.SelectedItem.ToString() + "' and `machine id`='" + chembercombo.SelectedItem.ToString() + "';";

                    try
                    {


                        using (var command = new MySqlCommand(qry, connection))
                        {
                            using (MySqlDataReader reader1 = command.ExecuteReader())
                            {

                                //Iterate through the rows and add it to the combobox's items
                                while (reader1.Read())
                                {
                                    b = reader1.GetString(0);

                                    //  batchcombo.Items.Add(reader.GetString("batchno"));
                                }

                            }
                        }

                    }
                    catch (MySqlException asdx)
                    {
                    }
                    MessageBox.Show("Enter all fields & press Ok");
                }

            }
            catch (MySqlException asdx)
            {
            }
            return b;
        }
        string getbatch()
        {

            //select batchno from nameplate_temp where date(`date`)='2016-10-26' and shift='1' and chemberno='1';
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string b = "";
            string qry = "select batchno from nameplate_temp where date(`date`)='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and shift='" + shiftcombo.SelectedItem.ToString() + "' and chemberno='" + chembercombo.SelectedItem.ToString() + "';";


            try
            {


                using (var command = new MySqlCommand(qry, connection))
                {
                    using (MySqlDataReader reader1 = command.ExecuteReader())
                    {

                        //Iterate through the rows and add it to the combobox's items
                        while (reader1.Read())
                        {
                            b = reader1.GetString(0);

                            //  batchcombo.Items.Add(reader.GetString("batchno"));
                        }

                    }
                }
                if (b == "")
                {
                    b = getbatchfrmtemp();
                    if (b != "0")
                    {
                        fillnameplate();
                        tempbatch = b;
                    }
                }
                else
                    retrivenameplate(b);


            }
            catch (MySqlException asdx)
            {
            }
            return b;
        }
        private void shiftcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (connection.State == ConnectionState.Closed)
            //    connection.Open();
            //string b = "";
            //string qry = "select distinct(`chemberno`) from nameplate_temp where date(`date`)='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and shift='" + shiftcombo.SelectedItem.ToString() + "';";


            //try
            //{


            //    using (var command = new MySqlCommand(qry, connection))
            //    {
            //        chembercombo.Items.Clear();
            //        using (MySqlDataReader reader1 = command.ExecuteReader())
            //        {

            //            //Iterate through the rows and add it to the combobox's items
            //            while (reader1.Read())
            //            {
            //                chembercombo.Items.Add(reader1.GetString(0));

            //                //  batchcombo.Items.Add(reader.GetString("batchno"));
            //            }

            //        }
            //    }



            //}
            //catch (MySqlException asdx)
            //{
            //}

        }

        private void reporttemp_new_Load(object sender, EventArgs e)
        {
            key = (Keys)Properties.Settings.Default["ControlKeys"];
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

            Resource_File_Values();             // Use for Excel import

            server = "localhost";
            database = "ultimate_ele1";
            uid = "root";
            password = "teamat";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connectionString = "Database=" + database + ";Server=localhost;UID=root;PWD=teamat;";
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR In Connecting To Database:Plz check Mysql Installation");
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {

            try
            {
                if (batchtxt.Text.StartsWith("#") || batchtxt.Text == "" || supervisertxt.Text == "" || b1.Text == "" || b2.Text == "" || b3.Text == "" || b4.Text == "" || b5.Text == "" || b6.Text == "" || b7.Text == "" || b8.Text == "" || b9.Text == "")
                {
                    if (batchtxt.Text.StartsWith("#"))
                        MessageBox.Show("Please Enter Valid Batch Number ");
                    else
                        MessageBox.Show("Please Enter All Field ");
                }
                else
                {
                    //INSERT INTO nameplate_temp (`date`,  `batchno`,`shift`, `superviser`, `b1`, `b2`, `b3`, `b4`,`b5`,`b6`,`b7`,`b8`,`b9`,`b10`) VALUES('2016-10-22','123','12','12','1','1','1','1','1','1','1','1','1','1');

                    string query = "INSERT INTO nameplate_temp (`date`,  `batchno`,`shift`, `superviser`, `b1`, `b2`, `b3`, `b4`,`b5`,`b6`,`b7`,`b8`,`b9`,`b10`,`chemberno`) VALUES('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + batchtxt.Text.ToString() + "','" + shiftcombo.SelectedItem.ToString() + "','" + supervisertxt.Text + "','" + b1.Text + "','" + b2.Text + "','" + b3.Text + "','" + b4.Text + "','" + b5.Text + "','" + b6.Text + "','" + b7.Text + "','" + b8.Text + "','" + b9.Text + "','" + b10.Text + "'," + chembercombo.SelectedItem.ToString() + ");";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    string query1 = "update temp set batchno='" + batchtxt.Text + "' where batchno='" + tempbatch + "' and `machine id`='" + chembercombo.SelectedItem.ToString() + "' ;";
                    MySqlCommand cmd1 = new MySqlCommand(query1, connection);

                    //Execute command
                    try
                    {
                        if (connection.State == ConnectionState.Closed)
                            connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();
                        connection.Close();
                        btnok.Visible = false;
                        b1.ReadOnly = true;
                        b2.ReadOnly = true;
                        b3.ReadOnly = true;
                        b4.ReadOnly = true;
                        b5.ReadOnly = true;
                        b6.ReadOnly = true;
                        b7.ReadOnly = true;
                        b8.ReadOnly = true;
                        b9.ReadOnly = true;
                        b10.ReadOnly = true;
                        batchtxt.ReadOnly = true;
                        supervisertxt.ReadOnly = true;
                        genraterpt();
                    }
                    catch
                    {
                    }
                }

            }
            catch (Exception jh)
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chembercombo.SelectedIndex == -1 || chembercombo.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Please select chember no");
            }
            else if (shiftcombo.SelectedItem == null)
            {
                MessageBox.Show("Please select  Shift ");

            }

            else
            {
                reportViewer1.Clear();
                batchtxt.Text = getbatch();
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            if (chembercombo.SelectedIndex == -1 || chembercombo.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Please select chember no");
            }
            else
            {
                reportViewer1.Clear();
                batchtxt.Text = getbatch();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //  shiftcombo.SelectedIndex = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void reporttemp_new_KeyUp(object sender, KeyEventArgs e)
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

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            str = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            i = dataGridView1.Rows[e.RowIndex].Index;
            Temp_Opereation op = new Temp_Opereation(str, i);
            //Opereation op = new Opereation(str, i);
            op.Show();
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
                temp = " Temperature Excel read problem. Please check excel file or file extension. ";
                this.LogError(ex, temp);
            }
        }
        #endregion  After button click Excel data import code

        #region Read Excel file main function
        public void Import_Excel_File()
        {
            try
            {
                tempminut = -30;
                Random rnd = new Random();
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
                        cmd.CommandText = "SELECT DISTINCT * FROM [Sheet1$] ORDER BY [Sr No] ";
                        oleda = new OleDbDataAdapter(cmd);
                        oleda.Fill(ds);
                    }
                    catch (Exception ex)
                    {
                        this.LogError(ex);
                    }

                    try
                    {
                        string temp_datestamp = "";
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
                                string temp = ds.Tables[0].Rows[i][7].ToString();
                                string inputDate = ds.Tables[0].Rows[i][2].ToString();
                                string inputTime = ds.Tables[0].Rows[i][3].ToString();

                                string[] temp_date = inputDate.Split('_');
                                string[] temp_time = inputTime.Split('_');
                                if (i == 1)
                                {
                                    temp_datestamp = Convert.ToString(temp_date[2] + "-" + temp_date[1] + "-" + temp_date[0] + " " + temp_time[0] + ":" + temp_time[1] + ":00");
                                }
                                DateTime dt = Convert.ToDateTime(temp_datestamp);
                                if (ds.Tables[0].Rows[i][5].ToString() == ds.Tables[0].Rows[i - 1][5].ToString())
                                    tempminut += 30;
                                dt = dt.AddMinutes(tempminut);
                                int randomSec = 0 - rnd.Next(1, 90);
                                dt = dt.AddSeconds(randomSec);
                                date_stamp = dt.ToString("yyyy-MM-dd HH:mm:ss");
                                //id, benchno, castingtime, rpm1, t1, batchno, rpm2, t2, rpm3, t3, rpm4, t4, rpm5, t5, rpm6, t6, rpm7, t7, rpm8, t8

                                batchno = ds.Tables[0].Rows[i][1].ToString();
                                Machine_id = ds.Tables[0].Rows[i][4].ToString();
                                prosess_no = ds.Tables[0].Rows[i][5].ToString();
                                set_value = ds.Tables[0].Rows[i][6].ToString();
                                process_value = ds.Tables[0].Rows[i][7].ToString();

                                if (date_stamp != "" || batchno != "" || Machine_id != "" || prosess_no != "" || set_value != "" || process_value != "")
                                {
                                    string strQuery1082, strQuery1083;
                                    try
                                    {

                                        strQuery1082 = "SELECT count(*) FROM temp where `Machine id` ='" + Machine_id.Trim() + "' and `prosess no` ='" + prosess_no.Trim() + "' and `set value`='" + set_value.Trim() + "' and `process value` = '" + process_value.Trim() + "'  and `date stamp` = '" + date_stamp + "' and `batchno` = '" + batchno.Trim() + "' ;";
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
                                            strQuery2111 = "INSERT INTO temp (`Machine id`, `prosess no`, `set value`, `process value`, `date stamp`, `batchno`)  VALUES ('" + Machine_id.Trim() + "','" + prosess_no.Trim() + "','" + set_value.Trim() + "','" + process_value.Trim() + "','" + date_stamp + "','" + batchno.Trim() + "' );";
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
                    Excel_Path = resxSet.GetString("Excel_Path_Tempareture");
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

        private void tempBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }


    }
}