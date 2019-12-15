using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WinForms;

namespace WindowsFormsApplication1
{
    public partial class BondStrength : Form
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
        double ld1, ld16, des1, des16;
        MySqlConnection connection;
        Keys key;

        public BondStrength()
        {
            key = (Keys)Properties.Settings.Default["ControlKeys"];
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void Form26_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet28.tbldata26' table. You can move, or remove it, as needed.
            //this.tbldata26TableAdapter.Fill(this.DataSet28.tbldata26,"A123","1");
            //// TODO: This line of code loads data into the 'DataSet28.tbldata26' table. You can move, or remove it, as needed.
            ////this.tbldata26TableAdapter.Fill(this.DataSet28.tbldata26,"123");
            //this.reportViewer1.RefreshReport();

            myConn7 = new MySqlConnection(sConnectionString);
            //    conn = new OdbcConnection(sConnectionString);
            try
            {
                if (myConn7 != null) { }
                myConn7.Open();


                //   if (conn != null) { }
                //   conn.Open();

            }
            catch (System.Exception ex)
            {
                //restartApplication();
            }

            getbatch();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            //Mix_design_combo.SelectedIndex = -1;
            //shifttxt.Text = "";
            //lc_of_dg.Text = "";
            //lc_of_mc.Text = "";
            //dia_of_rod.Text = "";
            //newbatch.Text = "";
            if (Convert.ToDateTime(dateTimePicker1.Text) <= Convert.ToDateTime(dateTimePicker2.Text))
            {
                MessageBox.Show("Please Enter valid Casting Date \n Casting Date must be smaller than Testing Date");
            }
            else if (lc_of_dg.Text == "")
            {
                MessageBox.Show("Please Enter Least Count of Dail Gauge ");
            }
            else if (lc_of_mc.Text == "")
            {
                MessageBox.Show("Please Enter Least Count of Machine");
            }
            else if (dia_of_rod.Text == "")
            {
                MessageBox.Show("Please Enter Diameter of Rod ");
            }
            else if (lc_of_dg.Text == "")
            {
                MessageBox.Show("Please Enter Least Count of Dail Gauge ");
            }
            else if (newbatch.Text == "")
            {
                MessageBox.Show("Please Enter New Batch No ");
            }
            else if (CUBE_TEXT.Text == "")
            {
                MessageBox.Show("  Please Enter Cube No ");
            }
            else if (Mix_design_combo.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Mix Design ");
            }
            else if (newbatch.Text != "")
            {
                try
                {
                    connection = new MySqlConnection(connectionString);
                    connection.Open();
                    var query = "select count(*) FROM nameplate26 where cube_no='" + CUBE_TEXT.Text + "' and batchno='" + newbatch.Text + "'  ;";

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


                                string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                                string theDate1 = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                                //INSERT INTO nameplate_temp (`date`,  `batchno`,`shift`, `superviser`, `b1`, `b2`, `b3`, `b4`,`b5`,`b6`,`b7`,`b8`,`b9`,`b10`) VALUES('2016-10-22','123','12','12','1','1','1','1','1','1','1','1','1','1');
                                MySqlConnection connection1 = new MySqlConnection(connectionString);
                                string query1 = "INSERT INTO nameplate26 ( batchno, date_time, casting_date, LS_dail_gauge, daimeter_of_rod, mix_design, Least_count_machine, cube_no) VALUES('" + newbatch.Text + "','" + theDate + "','" + theDate1 + "','" + lc_of_dg.Text + "','" + dia_of_rod.Text + "','" + Mix_design_combo.SelectedItem.ToString() + "','" + lc_of_mc.Text + "','" + CUBE_TEXT.Text + "');";
                                MySqlCommand cmd = new MySqlCommand(query1, connection1);

                                //Execute command
                                try
                                {

                                    if (connection1.State == ConnectionState.Closed || connection1 == null)
                                        connection1.Open();
                                    cmd.ExecuteNonQuery();
                                    connection.Close();
                                    btnok.Visible = false;

                                    shifttxt.ReadOnly = true;
                                    //  supervisertxt.ReadOnly = true;

                                }
                                catch (MySqlException eqa)
                                {
                                    MessageBox.Show(eqa.InnerException.ToString());
                                }
                                string query11 = "update   tbldata26 set batchno='" + newbatch.Text + "' , cube_no='" + CUBE_TEXT.Text + "' where batchno='" + batchcombo.SelectedItem.ToString() + "';";
                                MySqlCommand cmd1 = new MySqlCommand(query11, connection);

                                //Execute command
                                try
                                {
                                    connection.Open();
                                    cmd1.ExecuteNonQuery();
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
                            else
                            {


                                MessageBox.Show("Please Enter Valid Batch No & Cube No.. \n The Report is already present for Batch No:-" + newbatch.Text + "Cube no:-" + CUBE_TEXT.Text);
                            }
                        }
                    }

                    connection.Close();
                }
                catch (MySqlException ex)
                {
                }
            }


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
                    var query = "select distinct (`batchno`) FROM tbldata26 where `datetime` like('" + theDate + "%')  ;";
                    //MessageBox.Show(query);
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
        void getcube()
        {
            try
            {
                if (batchcombo.SelectedIndex != -1 || batchcombo.SelectedIndex != 0)
                {
                    CubeCombo.Items.Clear();
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
                        var query = "select distinct (`cube_no`) FROM nameplate26 where `batchno`='" + batchcombo.SelectedItem.ToString() + "';";
                        //MessageBox.Show(query);
                        using (var command = new MySqlCommand(query, connection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                //Iterate through the rows and add it to the combobox's items
                                while (reader.Read())
                                {
                                    CubeCombo.Items.Add(reader.GetString("cube_no"));
                                }
                            }
                        }

                        if (CubeCombo.Items.Count >= 1)
                        {
                            CUBE_TEXT.Text = CubeCombo.Items[0].ToString();
                            CubeCombo.SelectedIndex = 0;
                            CubeCombo.Visible = true;
                            //   CUBE_TEXT.Text = CubeCombo.SelectedItem.ToString();

                            //reportViewer1.Clear();
                        }
                        else
                        {
                            CubeCombo.SelectedIndex = -1;
                            CubeCombo.SelectedValue = "";
                            CubeCombo.SelectedText = "";
                            button1.Visible = true;
                            CubeCombo.Visible = false;
                            CUBE_TEXT.Visible = true;
                            //  nameplate();
                            fillnameplate();
                            reportViewer1.Clear();
                        }
                        connection.Close();

                    }
                    catch (MySqlException ex)
                    {
                    }
                }
            }
            catch { }
        }

        private void batchcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nameplate();
            getcube();

        }
        void nameplate()
        {
            if (batchcombo.SelectedIndex != -1)
            {
                try
                {
                    connection = new MySqlConnection(connectionString);
                    connection.Open();
                    var query = "select count(*) FROM nameplate26 where `date_time` like('" + theDate + "%') and batchno='" + batchcombo.SelectedItem.ToString() + "'  ;";

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

            dateTimePicker2.Enabled = true;
            lc_of_dg.ReadOnly = false;
            lc_of_mc.ReadOnly = false;
            dia_of_rod.ReadOnly = false;
            newbatch.ReadOnly = false;
            Mix_design_combo.SelectedIndex = -1;
            shifttxt.Text = "";
            lc_of_dg.Text = "";
            lc_of_mc.Text = "";
            dia_of_rod.Text = "";
            newbatch.Text = "";

            MessageBox.Show("Please fill all field & Press 'OK'");
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
                getload();
                string dbatch = batchcombo.SelectedItem.ToString();
                string cubeNo;

                if (dbatch.StartsWith("#"))
                    cubeNo = CUBE_TEXT.Text;
                else
                    cubeNo = CubeCombo.SelectedItem.ToString();
                ReportParameter[] parms = new ReportParameter[12];
                parms[0] = new ReportParameter("Company", company);
                parms[1] = new ReportParameter("Casting_Date", dateTimePicker2.Value.ToString("dd-MM-yyyy"));
                parms[2] = new ReportParameter("Batch", newbatch.Text);
                parms[3] = new ReportParameter("LC_mc", lc_of_mc.Text);
                parms[4] = new ReportParameter("LC_Dg", lc_of_dg.Text);
                parms[5] = new ReportParameter("Dia_rod", dia_of_rod.Text);
                parms[6] = new ReportParameter("mix_design", Mix_design_combo.SelectedItem.ToString());
                parms[7] = new ReportParameter("cube_no", cubeNo);
                parms[8] = new ReportParameter("l1", ld1.ToString());
                parms[9] = new ReportParameter("l16", ld16.ToString());
                parms[10] = new ReportParameter("des1", des1.ToString());
                parms[11] = new ReportParameter("des16", des16.ToString());
                // parms[1] = new ReportParameter("param_course", textbox(n).text);
                this.reportViewer1.LocalReport.SetParameters(parms);
                // this.tbldata_28_1TableAdapter.Fill(this.DataSet28.tbldata_28_1, batchcombo.SelectedItem.ToString());
                // this.tbldata26TableAdapter.Fill(this.DataSet28.tbldata26, batchcombo.SelectedItem.ToString(),CUBE_TEXT.Text);
                //// this.tbldata_28_1TableAdapter1.Fill(this.ultimate_ele1DataSet.tbldata_28_1, batchcombo.SelectedItem.ToString());
                //// this.tbldata_28_11TableAdapter.Fill(this.DataSet28.tbldata_28_11, batchcombo.SelectedItem.ToString());
                //this.reportViewer1.RefreshReport();
                //this.reportViewer1.Refresh();
                // this.dataGridView1.Refresh();

                this.tbldata26TableAdapter.Fill(this.DataSet28.tbldata26, newbatch.Text, cubeNo);
                // this.tbldata26TableAdapter.Fill(this.DataSet28.tbldata26,'A123','1');
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ae)
            {
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
                var query = "";
                string dbatch = batchcombo.SelectedItem.ToString();
                if (dbatch.StartsWith("#"))
                    query = "select * FROM nameplate26 where `batchno`='" + newbatch.Text + "' and cube_no='" + CUBE_TEXT.Text + "' ;";
                else
                    query = "select * FROM nameplate26  where `batchno`='" + dbatch + "' and cube_no='" + CUBE_TEXT.Text + "';";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        //id, date, batchno, shift, superviser, b1, b2, b3, b4, b5, b6, b7, b8, b9, b10
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {

                            dateTimePicker2.Enabled = false;
                            lc_of_dg.ReadOnly = true;
                            lc_of_mc.ReadOnly = true;
                            dia_of_rod.ReadOnly = true;
                            newbatch.ReadOnly = true;

                            //id, batchno, date_time, casting_date, LS_dail_gauge, daimeter_of_rod, mix_design, Least_count_machine, cube_no


                            newbatch.Text = reader.GetString(1);
                            dateTimePicker2.Text = reader.GetString(3);
                            lc_of_dg.Text = reader.GetString(4);
                            dia_of_rod.Text = reader.GetString(5);
                            Mix_design_combo.SelectedItem = reader.GetString(6);
                            //  Mix_design_combo.SelectedText = reader.GetString(6);
                            lc_of_mc.Text = reader.GetString(7);
                            CUBE_TEXT.Text = reader.GetString(8);

                        }
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CubeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nameplate();
            retrivenameplate();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
        void getload()
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
                //id, In_mm, division, Load, batchno, datetime, cube_no
                string dbatch = batchcombo.SelectedItem.ToString();
                if (CubeCombo.Items.Count >= 1)
                CUBE_TEXT.Text = CubeCombo.SelectedItem.ToString();
                var query = "";
                if (dbatch.StartsWith("#"))
                    query = "select `Load`,`In_mm` FROM tbldata26 where `batchno`='" + newbatch.Text + "' and cube_no='" + CUBE_TEXT.Text + "' and `In_mm` in ('0.25','0.025') order by `id`;";
                else
                    query = "select `Load`,`In_mm` FROM tbldata26 where `batchno`='" + dbatch + "' and cube_no='" + CUBE_TEXT.Text + "' and `In_mm` in ('0.25','0.025') order by `id`;";
                //MessageBox.Show(query);
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        for (int i = 0; reader.Read(); i++)
                        {
                            if (i == 0)
                            {
                                ld1 = Convert.ToDouble(reader.GetString(0));
                                des1 = Convert.ToDouble(reader.GetString(1));
                            }
                            else
                            {
                                ld16 = Convert.ToDouble(reader.GetString(0));
                                des16 = Convert.ToDouble(reader.GetString(1));
                            }
                        }
                    }
                }


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

                batch = newbatch.Text;
                //date, batchno, mixdesign, water, cement, ca1, ca2, fa, addmix, mbatch    
                GlobalClass.adap = new MySqlDataAdapter("SELECT In_mm, division, `Load`, batchno, `datetime`, cube_no FROM tbldata26 where batchno = '" + batch + "' ;", myConn7);
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

        private void Form26_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form26_KeyDown(object sender, KeyEventArgs e)
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            str = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            i = dataGridView1.Rows[e.RowIndex].Index;
            Operation_Form26 op = new Operation_Form26(str, i);
            //Opereation op = new Opereation(str, i);
            op.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {

        }
    }
}
