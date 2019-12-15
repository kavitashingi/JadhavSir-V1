using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.Odbc;

namespace WindowsFormsApplication1
{
    public partial class ShiftChange : Form
    {

        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        DataSet ds = new DataSet();
        TimeSpan shiftdate, interval;
        string Shift1Start = "", Shift1End = "", Shift2Start = "", Shift2End = "", Shift3Start = "", Shift3End = "";
        
        public ShiftChange()
        {
            InitializeComponent();             
        }

        private void ShiftChange_Load(object sender, EventArgs e)
        {
            comboBox1Fill();
            comboBox2Fill();
            comboBox3Fill();
            comboBox4Fill();
            comboBox5Fill();
            comboBox6Fill();
        }

        #region ComboBoxFill
        public void comboBox1Fill()
        {
            comboBox1.Items.Add("00:00");
            comboBox1.Items.Add("01:00");
            comboBox1.Items.Add("02:00");
            comboBox1.Items.Add("03:00");
            comboBox1.Items.Add("04:00");
            comboBox1.Items.Add("05:00");
            comboBox1.Items.Add("06:00");
            comboBox1.Items.Add("07:00");
            comboBox1.Items.Add("08:00");
            comboBox1.Items.Add("09:00");
            comboBox1.Items.Add("10:00");
            comboBox1.Items.Add("11:00");
            comboBox1.Items.Add("12:00");
            comboBox1.Items.Add("13:00");
            comboBox1.Items.Add("14:00");
            comboBox1.Items.Add("15:00");
            comboBox1.Items.Add("16:00");
            comboBox1.Items.Add("17:00");
            comboBox1.Items.Add("18:00");
            comboBox1.Items.Add("19:00");
            comboBox1.Items.Add("20:00");
            comboBox1.Items.Add("21:00");
            comboBox1.Items.Add("22:00");
            comboBox1.Items.Add("23:00");
        }

        public void comboBox2Fill()
        {
            comboBox3.Items.Add("00:00");
            comboBox3.Items.Add("01:00");
            comboBox3.Items.Add("02:00");
            comboBox3.Items.Add("03:00");
            comboBox3.Items.Add("04:00");
            comboBox3.Items.Add("05:00");
            comboBox3.Items.Add("06:00");
            comboBox3.Items.Add("07:00");
            comboBox3.Items.Add("08:00");
            comboBox3.Items.Add("09:00");
            comboBox3.Items.Add("10:00");
            comboBox3.Items.Add("11:00");
            comboBox3.Items.Add("12:00");
            comboBox3.Items.Add("13:00");
            comboBox3.Items.Add("14:00");
            comboBox3.Items.Add("15:00");
            comboBox3.Items.Add("16:00");
            comboBox3.Items.Add("17:00");
            comboBox3.Items.Add("18:00");
            comboBox3.Items.Add("19:00");
            comboBox3.Items.Add("20:00");
            comboBox3.Items.Add("21:00");
            comboBox3.Items.Add("22:00");
            comboBox3.Items.Add("23:00");
        }

        public void comboBox3Fill()
        {
            comboBox4.Items.Add("00:00");
            comboBox4.Items.Add("01:00");
            comboBox4.Items.Add("02:00");
            comboBox4.Items.Add("03:00");
            comboBox4.Items.Add("04:00");
            comboBox4.Items.Add("05:00");
            comboBox4.Items.Add("06:00");
            comboBox4.Items.Add("07:00");
            comboBox4.Items.Add("08:00");
            comboBox4.Items.Add("09:00");
            comboBox4.Items.Add("10:00");
            comboBox4.Items.Add("11:00");
            comboBox4.Items.Add("12:00");
            comboBox4.Items.Add("13:00");
            comboBox4.Items.Add("14:00");
            comboBox4.Items.Add("15:00");
            comboBox4.Items.Add("16:00");
            comboBox4.Items.Add("17:00");
            comboBox4.Items.Add("18:00");
            comboBox4.Items.Add("19:00");
            comboBox4.Items.Add("20:00");
            comboBox4.Items.Add("21:00");
            comboBox4.Items.Add("22:00");
            comboBox4.Items.Add("23:00");
        }

        public void comboBox4Fill()
        {
            comboBox5.Items.Add("00:00");
            comboBox5.Items.Add("01:00");
            comboBox5.Items.Add("02:00");
            comboBox5.Items.Add("03:00");
            comboBox5.Items.Add("04:00");
            comboBox5.Items.Add("05:00");
            comboBox5.Items.Add("06:00");
            comboBox5.Items.Add("07:00");
            comboBox5.Items.Add("08:00");
            comboBox5.Items.Add("09:00");
            comboBox5.Items.Add("10:00");
            comboBox5.Items.Add("11:00");
            comboBox5.Items.Add("12:00");
            comboBox5.Items.Add("13:00");
            comboBox5.Items.Add("14:00");
            comboBox5.Items.Add("15:00");
            comboBox5.Items.Add("16:00");
            comboBox5.Items.Add("17:00");
            comboBox5.Items.Add("18:00");
            comboBox5.Items.Add("19:00");
            comboBox5.Items.Add("20:00");
            comboBox5.Items.Add("21:00");
            comboBox5.Items.Add("22:00");
            comboBox5.Items.Add("23:00");
        }

        public void comboBox5Fill()
        {
            comboBox6.Items.Add("00:00");
            comboBox6.Items.Add("01:00");
            comboBox6.Items.Add("02:00");
            comboBox6.Items.Add("03:00");
            comboBox6.Items.Add("04:00");
            comboBox6.Items.Add("05:00");
            comboBox6.Items.Add("06:00");
            comboBox6.Items.Add("07:00");
            comboBox6.Items.Add("08:00");
            comboBox6.Items.Add("09:00");
            comboBox6.Items.Add("10:00");
            comboBox6.Items.Add("11:00");
            comboBox6.Items.Add("12:00");
            comboBox6.Items.Add("13:00");
            comboBox6.Items.Add("14:00");
            comboBox6.Items.Add("15:00");
            comboBox6.Items.Add("16:00");
            comboBox6.Items.Add("17:00");
            comboBox6.Items.Add("18:00");
            comboBox6.Items.Add("19:00");
            comboBox6.Items.Add("20:00");
            comboBox6.Items.Add("21:00");
            comboBox6.Items.Add("22:00");
            comboBox6.Items.Add("23:00");
        }

        public void comboBox6Fill()
        {
            comboBox2.Items.Add("00:00");
            comboBox2.Items.Add("01:00");
            comboBox2.Items.Add("02:00");
            comboBox2.Items.Add("03:00");
            comboBox2.Items.Add("04:00");
            comboBox2.Items.Add("05:00");
            comboBox2.Items.Add("06:00");
            comboBox2.Items.Add("07:00");
            comboBox2.Items.Add("08:00");
            comboBox2.Items.Add("09:00");
            comboBox2.Items.Add("10:00");
            comboBox2.Items.Add("11:00");
            comboBox2.Items.Add("12:00");
            comboBox2.Items.Add("13:00");
            comboBox2.Items.Add("14:00");
            comboBox2.Items.Add("15:00");
            comboBox2.Items.Add("16:00");
            comboBox2.Items.Add("17:00");
            comboBox2.Items.Add("18:00");
            comboBox2.Items.Add("19:00");
            comboBox2.Items.Add("20:00");
            comboBox2.Items.Add("21:00");
            comboBox2.Items.Add("22:00");
            comboBox2.Items.Add("23:00");
        } 
        #endregion

        //public void getshifttimings()
        //{
        //    server = "localhost";
        //    database = "ultimate_ele1";
        //    uid = "root";
        //    password = "teamat";
        //    string connectionString;
        //    connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        //    database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        //    connectionString = "Database=" + database + ";Server=localhost;UID=root;PWD=teamat;";

        //    string sql1 = "select shift_nm, shift_start_time, shift_end_time from tbl_shift";
        //    OdbcDataAdapter da = new OdbcDataAdapter(sql1, connectionString);
        //    da = new OdbcDataAdapter(sql1, connectionString);
        //    da.Fill(ds);
        //    Shift1Start = ds.Tables[0].Rows[0][1].ToString();
        //    Shift1End = ds.Tables[0].Rows[0][2].ToString();
        //    Shift2Start = ds.Tables[0].Rows[1][1].ToString();
        //    Shift2End = ds.Tables[0].Rows[1][2].ToString();
        //    Shift3Start = ds.Tables[0].Rows[2][1].ToString();
        //    Shift3End = ds.Tables[0].Rows[2][2].ToString();
        //    interval = new TimeSpan(00, 00, 01);
        //    shiftdate = TimeSpan.Parse(Shift3End).Subtract(interval);
        //}

        private void button1_Click(object sender, EventArgs e)
        {            
            try
            {
                //server = "localhost";
                //database = "ultimate_ele1";
                //uid = "root";
                //password = "teamat";
                string connectionString;
                //connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                //database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                //connectionString = "Database=" + database + ";Server=localhost;UID=root;PWD=teamat;";

                Shift1Start = Convert.ToString(comboBox1.Text + ":00");
                Shift1End = Convert.ToString(comboBox2.Text + ":00");

                Shift2Start = Convert.ToString(comboBox3.Text + ":00");
                Shift2End = Convert.ToString(comboBox4.Text + ":00");

                Shift3Start = Convert.ToString(comboBox5.Text + ":00");
                Shift3End = Convert.ToString(comboBox6.Text + ":00");
       
                if(Shift1Start == ":00")
                {
                    Shift1Start = "00:00:00";
                }

                if (Shift2Start == ":00")
                {
                    Shift2Start = "00:00:00";
                }

                if (Shift3Start == ":00")
                {
                    Shift3Start = "00:00:00";
                }

                if (Shift1End == ":00")
                {
                    Shift1End = "00:00:00";
                }

                if (Shift2End == ":00")
                {
                    Shift2End = "00:00:00";
                }

                if (Shift3End == ":00")
                {
                    Shift3End = "00:00:00";
                }               

                //connection = new MySqlConnection(connectionString);            

                connectionString = "datasource=localhost;port=3306;username=root;password=teamat";


                    string query1 = "update ultimate_ele1.tbl_shift set shift_start_time = '" + Shift1Start + "', shift_end_time = '" + Shift1End + "' where shift_nm = '1';";
                   // MySqlCommand cmd1 = new MySqlCommand(query1, connection);

                    string query2 = "update ultimate_ele1.tbl_shift set shift_start_time = '" + Shift2Start + "', shift_end_time = '" + Shift2End + "' where shift_nm = '2';";
                    //MySqlCommand cmd2 = new MySqlCommand(query2, connection);

                    string query3 = "update ultimate_ele1.tbl_shift set shift_start_time = '" + Shift3Start + "', shift_end_time = '" + Shift3End + "' where shift_nm = '3';";
                    //MySqlCommand cmd3 = new MySqlCommand(query3, connection);

                    MySqlConnection MyConn1 = new MySqlConnection(connectionString);
                    MySqlCommand MyCommand1 = new MySqlCommand(query1, MyConn1);
                    MySqlDataReader MyReader1;
                    MyConn1.Open();
                    MyReader1 = MyCommand1.ExecuteReader();
                    //MessageBox.Show("Data Updated");
                    while (MyReader1.Read())
                    {
                    }
                    MyConn1.Close();


                    MySqlConnection MyConn2 = new MySqlConnection(connectionString);
                    MySqlCommand MyCommand2 = new MySqlCommand(query2, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    //MessageBox.Show("Data Updated");
                    while (MyReader2.Read())
                    {
                    }
                    MyConn2.Close();


                    MySqlConnection MyConn3 = new MySqlConnection(connectionString);
                    MySqlCommand MyCommand3 = new MySqlCommand(query3, MyConn3);
                    MySqlDataReader MyReader3;
                    MyConn3.Open();
                    MyReader3 = MyCommand3.ExecuteReader();
                    //MessageBox.Show("Data Updated");
                    while (MyReader3.Read())
                    {
                    }
                    MyConn3.Close();
                    MessageBox.Show("Shift Time Update Successfully");

                    //try
                    //{
                    //    cmd1.ExecuteNonQuery();
                    //    cmd2.ExecuteNonQuery();
                    //    cmd3.ExecuteNonQuery();

                    //    MessageBox.Show("Shift Time Updation Successfully");
                    //    connection.Close();
                    //}
                    //catch
                    //{
                    //    MessageBox.Show("Shift Time Updation Failed");
                    //}
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERROR In Connecting To Database:Plz check Mysql Installation");
            }     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShiftChange shift = new ShiftChange();
            shift.Close();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
