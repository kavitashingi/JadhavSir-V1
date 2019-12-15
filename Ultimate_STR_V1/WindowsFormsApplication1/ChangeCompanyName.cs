using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class ChangeCompanyName : Form
    {
        public int AnsCount;
        public ChangeCompanyName()
        {
            InitializeComponent();
        }

        private void ChangeCompanyName_Load(object sender, EventArgs e)
        {
            //getCmpnyName();
        }

        public void getCmpnyName()
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string cmpny_nm = Convert.ToString(textBox1.Text);
                string cmpny_addr = Convert.ToString(textBox2.Text);
                
               string connectionString = "datasource=localhost;username=root;password=teamat";

               string query1 = "select count(*) from ultimate_ele1.tbl_cmpny";
               
                
                MySqlConnection MyConn1 = new MySqlConnection(connectionString);
                MyConn1.Open();
                MySqlCommand MyCommand1 = new MySqlCommand(query1, MyConn1);
                AnsCount = Convert.ToInt32(MyCommand1.ExecuteScalar());

                if (AnsCount == 0)                      // If data occure first time (New Data)
                {
                    MySqlDataReader MyReader2;
                    string strQuery3 = "INSERT INTO ultimate_ele1.tbl_cmpny(cmpny_nm, cmpny_addr) VALUES ('" + cmpny_nm + "','" + cmpny_addr + "');";
                    MySqlCommand MyCommand2 = new MySqlCommand(strQuery3, MyConn1);
                    MyReader2 = MyCommand2.ExecuteReader();
                    MyReader2.Close();
                    MessageBox.Show("Data Insert Successfully");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }

                else                                   // If some changes occure then update that fields
                {
                    MySqlDataReader MyReader202;
                    string strQuery303 = "UPDATE ultimate_ele1.tbl_cmpny SET cmpny_nm='" + cmpny_nm + "' , cmpny_addr='" + cmpny_addr + "';";
                    MySqlCommand MyCommand202 = new MySqlCommand(strQuery303, MyConn1);
                    MyReader202 = MyCommand202.ExecuteReader();
                    MyReader202.Close();
                    MessageBox.Show("Data Update Successfully");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                MyConn1.Close();
            }
            else 
            {
                MessageBox.Show("Enter valid Company Name or Address");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getCmpnyName();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeCompanyName cmpny = new ChangeCompanyName();
            cmpny.Close();
            this.Close();
        }
    }
}
