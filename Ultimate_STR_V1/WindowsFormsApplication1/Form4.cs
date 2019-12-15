using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        string theDate;
        string connectionString;
        Bitmap bitmap;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ultimate_eleDataSet.temp' table. You can move, or remove it, as needed.
            //this.tempTableAdapter.Fill(this.ultimate_eleDataSet.temp);
            //// TODO: This line of code loads data into the 'ultimate_eleDataSet.temp' table. You can move, or remove it, as needed.
            //this.tempTableAdapter.Fill(this.ultimate_eleDataSet.temp);
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
                var query = "select distinct (`batchno`) FROM temp where `date stamp` like('" + theDate + "%') and `prosess no`='1' order by `date stamp` ;";

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
                if(batchcombo.Items.Count>0)
                batchcombo.SelectedIndex = 0;
                connection.Close();
            }
            catch (MySqlException ex)
            {
            }

           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {


        }
        void fillnameplate() {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            chart1.Visible = false;
            label4.Visible = false;
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
        void retrivenameplate()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                var query = "select distinct * FROM nameplate_temp where `date` like('" + theDate + "%') and batchno='" + batchcombo.SelectedItem.ToString() + "' and chemberno="+chembercombo.SelectedItem.ToString()+";";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        //id, date, batchno, shift, superviser, b1, b2, b3, b4, b5, b6, b7, b8, b9, b10
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            shifttxt.Text=reader.GetString(3).ToString();
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
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            chart1.Series.Clear();
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                var query = "select count(*) FROM nameplate_temp where `date` like('" + theDate + "%') and batchno='"+batchcombo.SelectedItem.ToString()+"' and chemberno="+chembercombo.SelectedItem.ToString()+" ;";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        int a=0;
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                         a=Convert.ToInt16(reader.GetInt16(0));

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
        void genraterpt()
        {
             try
                    {
                        dataGridView1.Visible = true;

                        dataGridView2.Visible = true;
                        connection = new MySqlConnection(connectionString);
                        connection.Open();
                        var query = "select `prosess no` as 'Cycle No', round ( TIMESTAMPDIFF(MINUTE,(SELECT `date stamp` from temp where batchno='" + batchcombo.SelectedItem.ToString() + "' and `machine id`='" + chembercombo.SelectedItem.ToString() + "' limit 1), `date stamp`) / 30) as 't1', max( DATE_FORMAT(`date stamp`,' %h.%i ')) as 'Time',`set value`, `process value` from temp where batchno='" + batchcombo.SelectedItem.ToString() + "' and `machine id`='" + chembercombo.SelectedItem.ToString() + "' group by t1;";
                        MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, connection);
                            DataSet DS = new DataSet();
                            mySqlDataAdapter.Fill(DS);
                            dataGridView2.DataSource = DS.Tables[0];
                            double[] temprtr = new double[DS.Tables[0].Rows.Count];
                            double[] temprtr1 = new double[DS.Tables[0].Rows.Count];
                            string[] timea = new string[DS.Tables[0].Rows.Count];
                         //   string t = DS.Tables[0].Rows[0][2].ToString();
                            for (int i = 1; i < DS.Tables[0].Rows.Count; i++)
                            {
                                temprtr[i] = Convert.ToDouble(DS.Tables[0].Rows[i][3].ToString());
                                temprtr1[i] = Convert.ToDouble(DS.Tables[0].Rows[i][4].ToString());
                                timea[i] =  DS.Tables[0].Rows[i][2].ToString();
                            }
                            chart1.Series.Add("Set value");
                            chart1.Series.Add("Process value");
                            chart1.Visible = true;
                            chart1.Series[0].Points.DataBindXY( timea,temprtr);
                            chart1.Series[1].Points.DataBindY(temprtr1);
                            chart1.Series[1].ChartType = SeriesChartType.Line;
                            chart1.Series[1].Color = Color.DarkBlue;
                            chart1.Series[0].Color = Color.Red;
                            chart1.Series[0].ChartType = SeriesChartType.Line;
                            chart1.Series[0].XValueType = ChartValueType.String;
                            chart1.Series[1].XValueType = ChartValueType.String;
                            if (timea.Length < 0)
                                chart1.ChartAreas[0].AxisX.Minimum = Convert.ToDouble(timea[0]);
                            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.Gray;
                            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.Gray;
                        
                            //close connection
                           

                        connection.Close();
                        dataGridView2.Columns.RemoveAt(1);
                        dataGridView2.Columns[1].Width = 60;
                        dataGridView2.Columns[2].Width = 70;
                        dataGridView2.Columns[0].Width = 70;
                        


                    }
                    catch (MySqlException ex)
                    {
                    }
                    try
                    {
                        connection = new MySqlConnection(connectionString);
                        connection.Open();
                        var query = "select b.text as `Activity`, min(a.`date stamp`) as 'Start Time',max(a.`date stamp`) as 'End Time',TIMEDIFF(max(a.`date stamp`),min(a.`date stamp`)) as 'Duration' from temp a, process_cycle b where batchno='" + batchcombo.SelectedItem.ToString() + "' and `machine id`='" + chembercombo.SelectedItem.ToString() + "'and a.`prosess no`=b.id group by a.`prosess no` order by a.`prosess no`;";
                        MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, connection);
                        DataSet DS = new DataSet();
                        mySqlDataAdapter.Fill(DS);
                        dataGridView1.DataSource = DS.Tables[0];

                        //close connection


                        connection.Close();
                        dataGridView1.Columns[1].Width = 135;
                        dataGridView1.Columns[2].Width = 110;
                        dataGridView1.Columns[0].Width = 110;

                        dataGridView1.Columns[3].Width = 110;
                    }
                    catch (MySqlException ex)
                    {
                    }

                
        }
        private void chembercombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            f1();
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
                if (batchcombo.SelectedItem.ToString() == "")
                {
                    chembercombo.SelectedIndex = -1;
                    MessageBox.Show("Plz Select Batch No First !");
                }
                else
                {


                    nameplate();
                }
            }
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
                var query = "select distinct (`batchno`) FROM temp where `date stamp` like('" + theDate + "%') and `prosess no`='1' order by `date stamp` ;";

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

        private void btnok_Click(object sender, EventArgs e)
        {
            if (shifttxt.Text == "" || supervisertxt.Text == "" || b1.Text == "" || b2.Text == "" || b3.Text == "" || b4.Text == "" || b5.Text == "" || b6.Text == "" || b7.Text == "" || b8.Text == "" || b9.Text == "" || b10.Text == "" )
            {
                MessageBox.Show("Please Enter All fields ");
            }
            else
            {
                //INSERT INTO nameplate_temp (`date`,  `batchno`,`shift`, `superviser`, `b1`, `b2`, `b3`, `b4`,`b5`,`b6`,`b7`,`b8`,`b9`,`b10`) VALUES('2016-10-22','123','12','12','1','1','1','1','1','1','1','1','1','1');

                string query = "INSERT INTO nameplate_temp (`date`,  `batchno`,`shift`, `superviser`, `b1`, `b2`, `b3`, `b4`,`b5`,`b6`,`b7`,`b8`,`b9`,`b10`,`chemberno`) VALUES('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','"+batchcombo.SelectedItem.ToString()+"','"+shifttxt.Text+"','"+supervisertxt.Text+"','"+b1.Text+"','"+b2.Text+"','"+b3.Text+"','"+b4.Text+"','"+b5.Text+"','"+b6.Text+"','"+b7.Text+"','"+b8.Text+"','"+b9.Text+"','"+b10.Text+"',"+chembercombo.SelectedItem.ToString()+");";
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

        private void btnprint_Click(object sender, EventArgs e)
        {
            btnprint.Visible = false;
            btnrefresh.Visible = false;
            Panel panel = new Panel();
            this.Controls.Add(panel);

            //Create a Bitmap of size same as that of the Form.
            Graphics grp = panel.CreateGraphics();
            Size formSize = this.ClientSize;
            bitmap = new Bitmap(formSize.Width, formSize.Height, grp);
            grp = Graphics.FromImage(bitmap);

            //Copy screen area that that the Panel covers.
            Point panelLocation = PointToScreen(panel.Location);
            grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formSize);

            //Show the Print Preview Dialog.
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            btnprint.Visible = true;
            btnrefresh.Visible = true;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void batchcombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
