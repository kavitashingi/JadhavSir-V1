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

namespace WindowsFormsApplication1
{
    public partial class RPM_Report : Form
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        string theDate;
        string connectionString;
        public RPM_Report()
        {
            InitializeComponent();
        }

        private void RPM_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet28.rpmdata' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'ultimate_eleDataSet.rpmdata' table. You can move, or remove it, as needed.
           // this.rpmdataTableAdapter.Fill(this.ultimate_eleDataSet.rpmdata);
            // TODO: This line of code loads data into the 'lg_123.rpmdata' table. You can move, or remove it, as needed.

           // this.reportViewer2.RefreshReport();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
               // this.rpmdataTableAdapter.FillBy(this.lg_123.rpmdata);
            }
            catch (System.Exception ex)
            {
               // System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void rpmdataBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
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

                connection.Close();
            }
            catch (MySqlException ex)
            {
            }
        }
        void fillnameplate()
        {
           
            shifttxt.ReadOnly = false;
            supervisertxt.ReadOnly = false;

           
            shifttxt.Text = "";
            supervisertxt.Text = "";
            MessageBox.Show("Please fill Bench No, Shift No, Superviser Name & Press 'OK'");
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
                            supervisertxt.Text = reader.GetString(4).ToString();
                            

                            //  batchcombo.Items.Add(reader.GetString("batchno"));
                        }
                      
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
                            MessageBox.Show("Nameplate is not present");
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

        private void batchcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            nameplate();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (shifttxt.Text == "" || supervisertxt.Text == "")
            {
                MessageBox.Show("Please Enter All fields ");
            }
            else
            {
                //INSERT INTO nameplate_temp (`date`,  `batchno`,`shift`, `superviser`, `b1`, `b2`, `b3`, `b4`,`b5`,`b6`,`b7`,`b8`,`b9`,`b10`) VALUES('2016-10-22','123','12','12','1','1','1','1','1','1','1','1','1','1');

                string query = "INSERT INTO nameplaterpm (`date`,  `batchno`,`shift`, `supervisor`) VALUES('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + batchcombo.SelectedItem.ToString() + "','" + shifttxt.Text + "','" + supervisertxt.Text + "');";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    btnok.Visible = false;

                    shifttxt.ReadOnly = true;
                    supervisertxt.ReadOnly = true;
                    genraterpt();
                }
                catch
                {
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

                ReportParameter[] parms = new ReportParameter[4];
                parms[0] = new ReportParameter("Date", dateTimePicker1.Value.ToString("dd-MM-yyyy"));
                parms[1] = new ReportParameter("Batch", batchcombo.SelectedItem.ToString());
                parms[2] = new ReportParameter("Shift", shifttxt.Text);
              
                parms[3] = new ReportParameter("Company", company);
                this.reportViewer1.LocalReport.SetParameters(parms);


                this.rpmdataTableAdapter.Fill(this.lg_123.rpmdata, batchcombo.SelectedItem.ToString());
        
                this.reportViewer1.RefreshReport();

            }
            catch(Exception de)
            {
                MessageBox.Show(de.InnerException.ToString());
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
