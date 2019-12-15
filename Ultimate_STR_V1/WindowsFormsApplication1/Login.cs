using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        static string dbConnectionString = ConfigurationManager.ConnectionStrings["UltimateConnectionString"].ConnectionString;

        private string server;
        private string database;
        private string uid;
        private string password;
        HomePage homePage;
        MenuList menuList;

        public Login()
        {
            InitializeComponent();
            menuList = new MenuList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text.Trim() == "Ultimate" && textBox2.Text.Trim() == "JadhavSir@123")
            //{
            //    MessageBox.Show("Login successfully ");

            //    homePage = new Form3(menuList);
            //    homePage.Show();
            //    this.Hide();
            //}
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                using (MySqlConnection dbConnection = new MySqlConnection(dbConnectionString))
                {
                    dbConnection.Open();
                    var query = "select * from tbluserprofile where UserName='" + username + "' and PWD='" + password + "';";
                    //var query = "select * from tbluserprofile where UserName='" + username + "' and PWD='" + password + "';";
                    using (MySqlCommand dbCommand = new MySqlCommand(query, dbConnection))
                    {
                        using (MySqlDataReader dataReader = dbCommand.ExecuteReader())
                        {
                            if (dataReader.Read())
                            {
                                menuList.MixDesign = (Boolean)dataReader["MixDesign"];
                                menuList.RPM = (Boolean)dataReader["RPM"];
                                menuList.Temp = (Boolean)dataReader["Temp"];
                                menuList.TensWider = (Boolean)dataReader["TensWider"];
                                menuList.TensTurnOut = (Boolean)dataReader["TensTurnOut"];
                                menuList.TensXII = (Boolean)dataReader["TensXII"];
                                menuList.SBT1 = (Boolean)dataReader["SBT1"];
                                menuList.FlexuralStrength = (Boolean)dataReader["FlexuralStrength"];
                                menuList.CubeTesting = (Boolean)dataReader["CubeTesting"];
                                menuList.BondStrength = (Boolean)dataReader["BondStrength"];
                                menuList.ShiftChange = (Boolean)dataReader["ShiftChange"];
                                menuList.Edit = (Boolean)dataReader["Edit"];
                                
                                homePage = new HomePage(menuList);
                                    homePage.Show();
                                    this.Hide();
                            }
                            else
                            {
                                label4.Text = "Please Enter Valid Name & Password";
                            }
                        }
                    }
                }


            }
            else
            {

                label4.Text = "Please Enter Valid Name & Password";
                //Form3 homePage = new Form3();
                //homePage.Show();
                //this.Hide();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Leave(object sender, EventArgs e)
        {

        }

        private void groupBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            //{
            //    if (textBox1.Text.Trim() == "Ultimate" && textBox2.Text.Trim() == "JadhavSir@123")
            //    {
            //        MessageBox.Show("Login successfully ");
            //        Form3 asd = new Form3(edit);
            //        asd.Show();
            //        this.Hide();
            //    }
            //    else
            //    {

            //        label4.Text = "Please Enter Valid Name & Password";
            //    }
            //}
        }
    }
}
