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
using System.Drawing.Printing;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class SBT1 : Form
    {

        static string sConnectionString = ConfigurationManager.ConnectionStrings["MyConn007"].ConnectionString;
        public MySqlConnection myConn7;
        //private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        string theDate;
        string connectionString;

        SqlConnection con;
        //MySqlConnection conn;
        MySqlCommandBuilder buil;
        SqlCommandBuilder bui;
        string str, batch;
        int i;
        MySqlConnection connection;
        Keys key;
        public SBT1()
        {
            key = (Keys)Properties.Settings.Default["ControlKeys"];
            InitializeComponent();
        }

        private void form28_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ultimate_ele1DataSet.tbldata_28_1' table. You can move, or remove it, as needed.
            
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

            getbatch();
            
        }
        void getbatch()
        {
            try
            {
                batchcombo.SelectedIndex = -1;
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
                    var query = "select distinct (`mbatch`) FROM tbldata_28_1 where `date` like('" + theDate + "%')  ;";
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
                    else
                    {
                        batchcombo.SelectedIndex = -1;
                        batchcombo.SelectedValue = "";
                        batchcombo.SelectedText = "";

                        reportViewer1.Clear();
                    }
                    connection.Close();
                }
                catch (MySqlException ex)
                {
                }
            }
            catch { }
        }
        void gridfill()
        {
            try
            {
                string company = "";
                //string connectionString = "datasource=localhost;username=root;password=teamat";
                string query1111 = "select count(*) from ultimate_ele1.tbl_cmpny";
                //MySqlConnection MyConn1111 = new MySqlConnection(connectionString);
                //MyConn1111.Open();
                //MySqlCommand MyCommand1111 = new MySqlCommand(query1111, MyConn1111);
                MySqlCommand MyCommand1111 = new MySqlCommand(query1111, myConn7);
                int AnsCount = Convert.ToInt32(MyCommand1111.ExecuteScalar());

                if (AnsCount == 0)                      // If data occure first time (New Data)
                {
                    company = "Ultimate Electronics";

                }
                else
                {
                    string query1 = "select cmpny_nm from ultimate_ele1.tbl_cmpny";
                    //MySqlConnection MyConn1 = new MySqlConnection(connectionString);
                    //MyConn1.Open();
                    //MySqlCommand MyCommand1 = new MySqlCommand(query1, MyConn1);
                    MySqlCommand MyCommand1 = new MySqlCommand(query1, myConn7);
                    //AnsCount = Convert.ToInt32(MyCommand1.ExecuteScalar());
                    company = Convert.ToString(MyCommand1.ExecuteScalar());
                }

                batch = batchcombo.SelectedItem.ToString();

                ////string cnString = System.Configuration.ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

                //string cnString = ConfigurationManager.AppSettings["myConnectionString"].ToString();

                //string cnString = "datasource=localhost;username=root;password=teamat";              

                ////con = new SqlConnection(cnString);               

                //if (conn == null)
                //{
                //    conn = new MySqlConnection(cnString);
                //    if ((conn.State == ConnectionState.Broken || conn.State == ConnectionState.Closed) && (conn.State != ConnectionState.Open))
                //    {
                //        conn.Open();
                //    }
                //}

                //GlobalClass.adap = new SqlDataAdapter("SELECT mbatch as `Batch No`, sleeperno as `Sleeper No`, `date` as `Date`,castdate as `Cast Date`, top as `Top`, bottom as `Bottom`, mr1 as `MR1`, mr2 as `MR2` FROM tbldata_28_1 where mbatch = '" + batch + "' ;", con);

                GlobalClass.adap = new MySqlDataAdapter("SELECT mbatch as `Batch No`, sleeperno as `Sleeper No`, `date` as `Date`,castdate as `Cast Date`, top as `Top`, bottom as `Bottom`, mr1 as `MR1`, mr2 as `MR2`,mix_design as `Mix Design` FROM tbldata_28_1 where mbatch = '" + batch + "' ;", myConn7);

                //bui = new SqlCommandBuilder(GlobalClass.adap);

                buil = new MySqlCommandBuilder(GlobalClass.adap);

                GlobalClass.dt = new DataTable();

                GlobalClass.adap.Fill(GlobalClass.dt);

                dataGridView1.DataSource = GlobalClass.dt;

                dataGridView1.ReadOnly = true;

            }
            catch (Exception ex)
            { }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                getbatch();
            }
            catch
            {
            }
        }

        private void batchcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            nameplate();
        }
        void nameplate()
        {
            if (batchcombo.SelectedIndex != -1)
            {
                try
                {
                    connection = new MySqlConnection(connectionString);
                    connection.Open();
                    var query = "select count(*) FROM nameplate28_1 where `date` like('" + theDate + "%') and batchno='" + batchcombo.SelectedItem.ToString() + "'  ;";

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
            else if (batchcombo.Items.Count == 0)
                MessageBox.Show("No Record Found");
            else
            {
                this.reportViewer1.Clear();
                //  MessageBox.Show("No Record Found");
            }
        }
        void fillnameplate()
        {

            shifttxt.ReadOnly = false;
        //    supervisertxt.ReadOnly = false;


            shifttxt.Text = "";
       //     supervisertxt.Text = "";
            MessageBox.Show("Please fill Bench No, Shift No, Superviser Name & Press 'OK'");
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


                //System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                //pg.Margins.Top = 20;
                //pg.Margins.Bottom = 20;
                //pg.Margins.Left = 25;
                //pg.Margins.Right = 25;
                //System.Drawing.Printing.PaperSize size = new PaperSize();
                //size.RawKind = (int)PaperKind.A4Extra;
                //pg.PaperSize = size;
                //reportViewer1.SetPageSettings(pg);

                ReportParameter[] parms = new ReportParameter[4];
                parms[0] = new ReportParameter("Date", dateTimePicker1.Value.ToString("dd-MM-yyyy"));
                parms[1] = new ReportParameter("Batch", batchcombo.SelectedItem.ToString());
                parms[2] = new ReportParameter("Shift", shifttxt.Text);

                parms[3] = new ReportParameter("Company", company);
                // parms[1] = new ReportParameter("param_course", textbox(n).text);
                this.reportViewer1.LocalReport.SetParameters(parms);
                this.tbldata_28_1TableAdapter.Fill(this.DataSet28.tbldata_28_1, batchcombo.SelectedItem.ToString());
               // this.tbldata_28_1TableAdapter1.Fill(this.ultimate_ele1DataSet.tbldata_28_1, batchcombo.SelectedItem.ToString());
               // this.tbldata_28_11TableAdapter.Fill(this.DataSet28.tbldata_28_11, batchcombo.SelectedItem.ToString());
                this.reportViewer1.RefreshReport();
               // this.dataGridView1.Refresh();
            }
            catch(Exception ae) {
                MessageBox.Show(ae.InnerException.ToString());
            }
        }
        void retrivenameplate()
        {

            btnok.Visible = false;
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                var query = "select distinct * FROM nameplate28_1 where `date` like('" + theDate + "%') and batchno='" + batchcombo.SelectedItem.ToString() + "' ;";

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

                string query = "INSERT INTO nameplate28_1 (`date`,  `batchno`,`shift`, `supervisor`) VALUES('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + batchcombo.SelectedItem.ToString() + "','" + shifttxt.Text + "',' ');";
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
                catch(MySqlException eqa)
                {
                    MessageBox.Show(eqa.InnerException.ToString());
                }
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void form28_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void form28_KeyDown(object sender, KeyEventArgs e)
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

        private void label5_Click(object sender, EventArgs e)
        {
            try
            {
             //   this.tbldata_28_11TableAdapter.Update(this.DataSet28.tbldata_28_11);
                this.tbldata_28_1TableAdapter1.Fill(this.ultimate_ele1DataSet.tbldata_28_1, batchcombo.SelectedItem.ToString());
              
                this.reportViewer1.RefreshReport();
                this.dataGridView1.Refresh();
            }
            catch(Exception ae){}
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            str = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            i = dataGridView1.Rows[e.RowIndex].Index;
            SBT1_Opereation op = new SBT1_Opereation(str, i);
            op.Show();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            str = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            i = dataGridView1.Rows[e.RowIndex].Index;
            SBT1_Opereation op = new SBT1_Opereation(str, i);
            op.Show();
        }
    }
}
