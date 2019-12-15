using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Edit_RPM : Form
    {

        static string sConnectionString = ConfigurationManager.ConnectionStrings["MyConn007"].ConnectionString;
        public MySqlConnection myConn7;
        private string server;
        private string database;
        private string uid;
        private string password;
        string theDate;
        string connectionString;

        SqlConnection con;
        MySqlCommandBuilder buil;
        SqlCommandBuilder bui;
        string str, batch;
        int i;

        public Edit_RPM()
        {
            InitializeComponent();
        }

        private void Edit_RPM_Load(object sender, EventArgs e)
        {
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
                GlobalClass.adap = new MySqlDataAdapter("SELECT benchno, castingtime, batchno, rpm1, t1, rpm2, t2, rpm3, t3, rpm4, t4, rpm5, t5, rpm6, t6, rpm7, t7, rpm8, t8 FROM rpmdata where batchno = '" + batch + "' ;", myConn7);
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            str = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            i = dataGridView1.Rows[e.RowIndex].Index;
            RPM_Opereation op = new RPM_Opereation(str, i);
            //Opereation op = new Opereation(str, i);
            op.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            str = "";

            RPM_Opereation op = new RPM_Opereation(str, i);


            op.Show();
        }

        void getbatch()
        {
            try
            {
                batchcombo.SelectedIndex = -1;
                batchcombo.Items.Clear();
                theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                try
                {
                    var query = "select distinct (`batchno`) FROM rpmdata where `castingtime` like('" + theDate + "%')  ;";

                    using (var command = new MySqlCommand(query, myConn7))
                    {
                        using (var reader = command.ExecuteReader())
                        {
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
                    }
                }
                catch (MySqlException ex)
                {
                }
            }
            catch { }
        }

        private void batchcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridfill();
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            try
            {
                getbatch();
            }
            catch
            {
                theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            }
        }               
    }
}
