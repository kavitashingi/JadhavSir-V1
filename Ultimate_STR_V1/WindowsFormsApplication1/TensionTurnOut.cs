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
    public partial class TensionTurnOut : Form
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




        SqlConnection con;
        MySqlCommandBuilder buil;
        SqlCommandBuilder bui;
        string str, batch;
        int i;

        public OdbcConnection conn;

        public string temp = "";
        public static string Logger_File = "", Logger_Folder = "", Excel_Folder = "", Excel_Path = "";
        public static string id, batchno, castno, benchno, intialread, rlu, rll, rru, rrl, frlu, frll, frru, frrl, wirelength, cross_section, youngsmodulus, elongation, elongationkn, prestress, mbatch, date = "";
        public double Cal_rlu, Cal_rll, Cal_rru, Cal_rrl, Cal_frlu, Cal_frll, Cal_frru, Cal_frrl, Cal_wirelength, Cal_cross_section, Cal_youngsmodulus, Cal_elongation, Cal_elongationkn, Cal_prestress = 0;
        public double A, B = 0;
        Keys key;
        public TensionTurnOut()
        {
            key = (Keys)Properties.Settings.Default["ControlKeys"];
            InitializeComponent();
        }
        void nameplate()
        {

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                var query = "select count(*) FROM nameplate32_2 where `date` like('" + theDate + "%') and batchno='" + batchcombo.SelectedItem.ToString() + "'  ;";

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
        void fillnameplate()
        {

            shifttxt.ReadOnly = false;
            //supervisertxt.ReadOnly = false;


            shifttxt.Text = "";
            //supervisertxt.Text = "";
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

                ReportParameter[] parms = new ReportParameter[4];
                parms[0] = new ReportParameter("Date", dateTimePicker1.Value.ToString("dd-MM-yyyy"));
                parms[1] = new ReportParameter("Batch", batchcombo.SelectedItem.ToString());
                parms[2] = new ReportParameter("Shift", shifttxt.Text);
                parms[3] = new ReportParameter("Company", company);
                // parms[1] = new ReportParameter("param_course", textbox(n).text);
                this.reportViewer1.LocalReport.SetParameters(parms);
                //   this.tbldata_28_1TableAdapter.Fill(this.DataSet28.tbldata_28_1, batchcombo.SelectedItem.ToString());
                this.tbldata_32_turnoutTableAdapter.Fill(this.DataSet28.tbldata_32_turnout, batchcombo.SelectedItem.ToString());
                this.reportViewer1.RefreshReport();
            }
            catch { }
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
                //batchno, castno, benchno, intialread, rlu, rll, rru, rrl,                         frlu, frll, frru, frrl, wirelength, cross_section, youngsmodulus, elongation, elongationkn, prestress, mbatch, date
                GlobalClass.adap = new MySqlDataAdapter("SELECT batchno as `Batch No`, castno as `Cast No`, `benchno` as `Bench No`, intialread as `Intialread`, rlu as `RLU`, rll as `RLL`, rru as `RRU`, rrl as `RRL`, frlu as `FRLU`, frll as `FRLL`, frru, frrl, wirelength, cross_section, youngsmodulus, elongation, elongationkn, prestress, mbatch, date FROM tbldata_32_turnout where batchno = '" + batch + "' ;", myConn7);

                buil = new MySqlCommandBuilder(GlobalClass.adap);

                GlobalClass.dt = new DataTable();

                GlobalClass.adap.Fill(GlobalClass.dt);

                dataGridView1.DataSource = GlobalClass.dt;

                dataGridView1.ReadOnly = true;

            }
            catch (Exception ex)
            { }
        }
        void retrivenameplate()
        {

            btnok.Visible = false;
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                var query = "select distinct * FROM nameplate32_2 where `date` like('" + theDate + "%') and batchno='" + batchcombo.SelectedItem.ToString() + "' ;";

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
                        //supervisertxt.ReadOnly = true;

                    }
                }
                genraterpt();
                connection.Close();
            }
            catch (MySqlException ex)
            {
            }
        }

        private void Form32_2_Load(object sender, EventArgs e)
        {
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
        void getbatch()
        {
            try
            {
                //batchcombo.SelectedIndex = -1;
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
                    var query = "select distinct (`batchno`) FROM tbldata_32_turnout where `date` like('" + theDate + "%')  ;";

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
            if (shifttxt.Text == "")
            {
                MessageBox.Show("Please Enter All fields ");
            }
            else
            {
                //INSERT INTO nameplate_temp (`date`,  `batchno`,`shift`, `superviser`, `b1`, `b2`, `b3`, `b4`,`b5`,`b6`,`b7`,`b8`,`b9`,`b10`) VALUES('2016-10-22','123','12','12','1','1','1','1','1','1','1','1','1','1');

                string query = "INSERT INTO nameplate32_2 (`date`,  `batchno`,`shift`, `supervisor`) VALUES('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + batchcombo.SelectedItem.ToString() + "','" + shifttxt.Text + "',' ');";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    btnok.Visible = false;

                    shifttxt.ReadOnly = true;
                    //supervisertxt.ReadOnly = true;
                    genraterpt();
                }
                catch
                {
                }

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            str = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            i = dataGridView1.Rows[e.RowIndex].Index;
            TensionTurnOut_Opereation op = new TensionTurnOut_Opereation(str, i);
            //Opereation op = new Opereation(str, i);
            op.Show();


        }

        private void Form32_2_KeyUp(object sender, KeyEventArgs e)
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
                temp = " Tension Excel read problem. Please check excel file or file extension. ";
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

                                date = Convert.ToString(temp_date[2] + "-" + temp_date[1] + "-" + temp_date[0] + " " + temp_time[0] + ":" + temp_time[1] + ":00");

                                //id, benchno, castingtime, rpm1, t1, batchno, rpm2, t2, rpm3, t3, rpm4, t4, rpm5, t5, rpm6, t6, rpm7, t7, rpm8, t8

                                benchno = ds.Tables[0].Rows[i][3].ToString();
                                batchno = ds.Tables[0].Rows[i][2].ToString();

                                intialread = ds.Tables[0].Rows[i][4].ToString();

                                rlu = ds.Tables[0].Rows[i][5].ToString();
                                Cal_rlu = Convert.ToDouble(rlu);
                                rll = ds.Tables[0].Rows[i][6].ToString();
                                Cal_rll = Convert.ToDouble(rll);
                                rru = ds.Tables[0].Rows[i][7].ToString();
                                Cal_rru = Convert.ToDouble(rru);
                                rrl = ds.Tables[0].Rows[i][8].ToString();
                                Cal_rrl = Convert.ToDouble(rrl);
                                frlu = ds.Tables[0].Rows[i][9].ToString();
                                Cal_frlu = Convert.ToDouble(frlu);
                                frll = ds.Tables[0].Rows[i][10].ToString();
                                Cal_frll = Convert.ToDouble(frll);
                                frru = ds.Tables[0].Rows[i][11].ToString();
                                Cal_frru = Convert.ToDouble(frru);
                                frrl = ds.Tables[0].Rows[i][12].ToString();
                                Cal_frrl = Convert.ToDouble(frrl);

                                wirelength = ds.Tables[0].Rows[i][13].ToString();
                                Cal_wirelength = Convert.ToDouble(wirelength);
                                cross_section = ds.Tables[0].Rows[i][14].ToString();
                                Cal_cross_section = Convert.ToDouble(cross_section);
                                youngsmodulus = ds.Tables[0].Rows[i][15].ToString();
                                Cal_youngsmodulus = Convert.ToDouble(youngsmodulus);

                                A = Convert.ToDouble(((Cal_rlu + Cal_rll + Cal_rru + Cal_rrl) / 4));
                                B = Convert.ToDouble(((Cal_frlu + Cal_frll + Cal_frru + Cal_frrl) / 4));

                                Cal_elongation = Convert.ToDouble(B - A);
                                elongation = Convert.ToString(Cal_elongation);

                                //Cal_elongationkn = Convert.ToDouble(((Cal_elongation * Cal_cross_section * Cal_youngsmodulus) / Cal_wirelength));
                                //elongationkn = Convert.ToString(Cal_elongationkn);

                                //Cal_prestress = Convert.ToDouble((Cal_elongationkn + 50));
                                //prestress = Convert.ToString(Cal_prestress);

                                Cal_elongationkn = Math.Round(Convert.ToDouble(((Cal_elongation * Cal_cross_section * Cal_youngsmodulus) / Cal_wirelength)), 3);
                                elongationkn = Convert.ToString(Cal_elongationkn);

                                Cal_prestress = Math.Round(Convert.ToDouble((Cal_elongationkn + 50)), 3);

                                prestress = Convert.ToString(Cal_prestress);



                                //elongation = ds.Tables[0].Rows[i][15].ToString();
                                //elongationkn = ds.Tables[0].Rows[i][16].ToString();
                                //prestress = ds.Tables[0].Rows[i][17].ToString();

                                mbatch = ds.Tables[0].Rows[i][2].ToString();

                                if (date != "" || batchno != "" || benchno != "" || intialread != "" || rlu != "" || rll != "" || rru != "" || rrl != "" || frlu != "" || frll != "" || frru != "" || frrl != "" || wirelength != "" || cross_section != "" || youngsmodulus != "" || elongation != "" || elongationkn != "" || prestress != "" || mbatch != "")
                                {
                                    string strQuery1082, strQuery1083;
                                    try
                                    {
                                        strQuery1082 = "SELECT count(*) FROM tbldata_32_turnout where `date`='" + date + "' and batchno='" + batchno.Trim() + "' and benchno='" + benchno.Trim() + "' and intialread = '" + intialread.Trim() + "'  and rlu = '" + rlu.Trim() + "' and rll = '" + rll.Trim() + "'  and rru = '" + rru.Trim() + "'  and rrl = '" + rrl.Trim() + "'  and frlu ='" + frlu.Trim() + "' and frll ='" + frll.Trim() + "'  and frru ='" + frru.Trim() + "' and frrl ='" + frrl.Trim() + "'  and wirelength ='" + wirelength.Trim() + "' and cross_section ='" + cross_section.Trim() + "'  and youngsmodulus ='" + youngsmodulus.Trim() + "' and elongation ='" + elongation.Trim() + "'  and elongationkn = '" + elongationkn.Trim() + "' and prestress ='" + prestress.Trim() + "'  and mbatch ='" + mbatch.Trim() + "' ;";
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
                                            strQuery2111 = "INSERT INTO tbldata_32_turnout (batchno, benchno, intialread, rlu, rll, rru, rrl, frlu, frll, frru, frrl, wirelength, cross_section, youngsmodulus, elongation, elongationkn, prestress, mbatch, `date`)  VALUES ('" + batchno.Trim() + "','" + benchno.Trim() + "','" + intialread.Trim() + "','" + rlu.Trim() + "','" + rll.Trim() + "','" + rru.Trim() + "','" + rrl.Trim() + "','" + frlu.Trim() + "','" + frll.Trim() + "','" + frru.Trim() + "','" + frrl.Trim() + "','" + wirelength.Trim() + "','" + cross_section.Trim() + "','" + youngsmodulus.Trim() + "','" + elongation.Trim() + "','" + elongationkn.Trim() + "','" + prestress.Trim() + "','" + mbatch.Trim() + "','" + date.Trim() + "');";
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
                    Excel_Path = resxSet.GetString("Excel_Path_Tension");
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
