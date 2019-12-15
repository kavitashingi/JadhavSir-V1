using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;

namespace WindowsFormsApplication1
{
    public partial class reporttemp : Form
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        string theDate;
        string connectionString;
        Bitmap bitmap;
        public reporttemp()
        {
            InitializeComponent();
        }

        private void reporttemp_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet28.temp' table. You can move, or remove it, as needed.


            //  batchcombo.SelectedIndex = -1;
            batchcombo.SelectedValue = "";
            batchcombo.SelectedText = "";
            // batchcombo.SelectedItem = "";
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
                var query = "select distinct (`batchno`) FROM temp where `date stamp` like('" + theDate + "%')  order by `date stamp` ;";

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chembercombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1();
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
            b9.ReadOnly = false;
            b10.ReadOnly = false;
            shifttxt.ReadOnly = false;
            supervisertxt.ReadOnly = false;

            b1.Text = "";
            b2.Text = "";
            b3.Text = "";
            b4.Text = "";
            b5.Text = "";
            b6.Text = "";
            b7.Text = "";
            b8.Text = "";
            b9.Text = "";
            b10.Text = "";
            shifttxt.Text = "";
            supervisertxt.Text = "";
            MessageBox.Show("Please fill Bench No, Shift No, Superviser Name & Press 'OK'");
        }
        void genraterpt()
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




            ReportParameter[] parms = new ReportParameter[16];
            parms[0] = new ReportParameter("Date", theDate);
            parms[1] = new ReportParameter("Batch", batchcombo.SelectedItem.ToString());
            parms[2] = new ReportParameter("Shift", shifttxt.Text);
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
            this.tempTableAdapter.Fill(this.DataSet28.temp, batchcombo.SelectedItem.ToString(), Convert.ToInt16(chembercombo.SelectedItem.ToString()));
            // TODO: This line of code loads data into the 'DataSet28.temp_calculation' table. You can move, or remove it, as needed.
            this.temp_calculationTableAdapter.Fill(this.DataSet28.temp_calculation, batchcombo.SelectedItem.ToString(), Convert.ToInt16(chembercombo.SelectedItem.ToString()));
            //  this.rpmdataTableAdapter.Fill(this.lg_123.rpmdata, batchcombo.SelectedItem.ToString(), theDate);
            // this.reportViewer1.DataBindings
            this.reportViewer1.RefreshReport();
            
        }
        void retrivenameplate()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                var query = "select distinct * FROM nameplate_temp where `date` like('" + theDate + "%') and batchno='" + batchcombo.SelectedItem.ToString() + "' and chemberno=" + chembercombo.SelectedItem.ToString() + ";";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        //id, date, batchno, shift, superviser, b1, b2, b3, b4, b5, b6, b7, b8, b9, b10
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            shifttxt.Text = reader.GetString(3).ToString();
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
                        shifttxt.ReadOnly = true;
                        supervisertxt.ReadOnly = true;

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
                var query = "select count(*) FROM nameplate_temp where `date` like('" + theDate + "%') and batchno='" + batchcombo.SelectedItem.ToString() + "' and chemberno=" + chembercombo.SelectedItem.ToString() + " ;";

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
        void f1()
        {
            if (chembercombo.SelectedIndex != -1)
            {
                //if (datecombo.SelectedText.ToString() == "")
                //{
                //    chembercombo.SelectedIndex = -1;
                //    MessageBox.Show("Plz Select Date First !");

                //}
                if (batchcombo.Items.Count<1)
                {
                    chembercombo.SelectedIndex = -1;
                    MessageBox.Show("No Batch No Is Present in List "+"\n"+"Plz Select Date !");
                }
                else if (batchcombo.SelectedIndex == -1 )
                {
                    chembercombo.SelectedIndex = -1;
                    MessageBox.Show("Plz Select Batch Number First !");
                }

                else
                {


                    nameplate();
                }
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

          //  batchcombo.SelectedIndex = -1;
            batchcombo.SelectedValue = "";
            batchcombo.SelectedText = "";
           // batchcombo.SelectedItem = "";
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
                var query = "select distinct (`batchno`) FROM temp where `date stamp` like('" + theDate + "%')  order by `date stamp` ;";

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

        private void btnok_Click(object sender, EventArgs e)
        {
            if (shifttxt.Text == "" || supervisertxt.Text == "" || b1.Text == "" || b2.Text == "" || b3.Text == "" || b4.Text == "" || b5.Text == "" || b6.Text == "" || b7.Text == "" || b8.Text == "" || b9.Text == "" || b10.Text == "")
            {
                MessageBox.Show("Please Enter All fields ");
            }
            else
            {
                //INSERT INTO nameplate_temp (`date`,  `batchno`,`shift`, `superviser`, `b1`, `b2`, `b3`, `b4`,`b5`,`b6`,`b7`,`b8`,`b9`,`b10`) VALUES('2016-10-22','123','12','12','1','1','1','1','1','1','1','1','1','1');

                string query = "INSERT INTO nameplate_temp (`date`,  `batchno`,`shift`, `superviser`, `b1`, `b2`, `b3`, `b4`,`b5`,`b6`,`b7`,`b8`,`b9`,`b10`,`chemberno`) VALUES('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + batchcombo.SelectedItem.ToString() + "','" + shifttxt.Text + "','" + supervisertxt.Text + "','" + b1.Text + "','" + b2.Text + "','" + b3.Text + "','" + b4.Text + "','" + b5.Text + "','" + b6.Text + "','" + b7.Text + "','" + b8.Text + "','" + b9.Text + "','" + b10.Text + "'," + chembercombo.SelectedItem.ToString() + ");";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
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
                    shifttxt.ReadOnly = true;
                    supervisertxt.ReadOnly = true;
                    genraterpt();
                }
                catch
                {
                }
            }

        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            f1();

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void batchcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            chembercombo.Items.Clear();
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string b = "";
            string qry =
                                "select distinct(`Machine id`) from temp where batchno='" + batchcombo.SelectedItem.ToString() + "' ;";

            try
            {


                using (var command = new MySqlCommand(qry, connection))
                {
                    using (MySqlDataReader reader1 = command.ExecuteReader())
                    {

                        //Iterate through the rows and add it to the combobox's items
                        while (reader1.Read())
                        {
                           chembercombo.Items.Add(reader1.GetString(0));

                            //  batchcombo.Items.Add(reader.GetString("batchno"));
                        }

                    }
                }
                if (chembercombo.Items.Count >= 1)
                    chembercombo.SelectedIndex = 0;
            }
            catch (MySqlException asdx)
            {
            }
        }
    }
}
