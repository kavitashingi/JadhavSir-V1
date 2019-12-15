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
    public partial class UserProfile : Form
    {
        Boolean isDataPresent = false;
        static string dbConnectionString = ConfigurationManager.ConnectionStrings["UltimateConnectionString"].ConnectionString;
        int id;

        public UserProfile()
        {
            InitializeComponent();
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                #region checkAllFiedsEntered
                if (txtUserName.Text.Trim() == "" || txtPassword.Text.Trim() == "" || txtConfirmPassword.Text.Trim() == "")
                {

                    MessageBox.Show("Please fill all the entry....");

                }
                #endregion
                #region MatchPassword
                else if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
                {
                    MessageBox.Show("Please keep password and confirm password same....");
                }
                #endregion
              
                else
                {
                    if (isDataPresent)
                    {
                        using (MySqlConnection dbConnection = new MySqlConnection(dbConnectionString))
                        {
                            dbConnection.Open();

                            string query = "update tbluserprofile set PWD='" + txtPassword.Text.Trim() + "', MixDesign=" + chbMixDesign.Checked + ",RPM= " + chbRPMReport.Checked + ", Temp=" + chbTemprature.Checked + ", TensWider=" + chbTensionRegisterWider.Checked + ", TensTurnOut=" + chbTensionRegisterTurnOut.Checked + ", TensXII=" + chbTensionRegisterXII.Checked + ", SBT1=" + chbSBT.Checked + ", FlexuralStrength=" + chbFlexuralStrength.Checked + ", CubeTesting=" + chbCubeTesting.Checked + ", BondStrength=" + chbBondStrength.Checked + ", ShiftChange=" + chbShiftChange.Checked + ", Edit=" + chbIsDeveloper.Checked + " where ID="+id+";";

                            using (MySqlCommand dbCommand = new MySqlCommand(query, dbConnection))
                            {
                                using (MySqlDataReader dataReader = dbCommand.ExecuteReader())
                                {
                                    var output = dataReader.Read();
                                    clearFields();
                                    dbConnection.Close();
                                    
                                }
                            }
                        }
                    }
                    else
                    {
                        using (MySqlConnection dbConnection = new MySqlConnection(dbConnectionString))
                        {
                            dbConnection.Open();

                            string query = "insert into tbluserprofile (UserName, PWD, MixDesign, RPM, Temp, TensWider, TensTurnOut, TensXII, SBT1, SBT2, FlexuralStrength, CubeTesting, BondStrength, ShiftChange, Edit) values ('" + txtUserName.Text.Trim() + "','" + txtPassword.Text.Trim() + "'," + chbMixDesign.Checked + "," + chbRPMReport.Checked + "," + chbTemprature.Checked + "," + chbTensionRegisterWider.Checked + "," + chbTensionRegisterTurnOut.Checked + "," + chbTensionRegisterXII.Checked + "," + chbSBT.Checked + ",0," + chbFlexuralStrength.Checked + "," + chbCubeTesting.Checked + "," + chbBondStrength.Checked + "," + chbShiftChange.Checked + "," + chbIsDeveloper.Checked + ");";

                            using (MySqlCommand dbCommand = new MySqlCommand(query, dbConnection))
                            {
                                using (MySqlDataReader dataReader = dbCommand.ExecuteReader())
                                {
                                    var output = dataReader.Read();
                                    clearFields();
                                    txtUserName.Text = "";
                                    dbConnection.Close();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex);
            }


        }
        private void clearFields()
        {
            txtConfirmPassword.Text = "";
            txtPassword.Text = "";
            
            chbSelectAll.Checked = false;
            allUnChecked();
            id = 0;
            isDataPresent = false;
        }

        private void allChecked()
        {
            chbMixDesign.Checked = true;
            chbRPMReport.Checked = true;
            chbTemprature.Checked = true;
            chbTensionRegisterWider.Checked = true;
            chbTensionRegisterTurnOut.Checked = true;
            chbTensionRegisterXII.Checked = true;
            chbSBT.Checked = true;
            chbFlexuralStrength.Checked = true;
            chbCubeTesting.Checked = true;
            chbBondStrength.Checked = true;
            chbShiftChange.Checked = true;
            chbIsDeveloper.Checked = true;
        }

        private void allUnChecked()
        {
            chbMixDesign.Checked = false;
            chbRPMReport.Checked = false;
            chbTemprature.Checked = false;
            chbTensionRegisterWider.Checked = false;
            chbTensionRegisterTurnOut.Checked = false;
            chbTensionRegisterXII.Checked = false;
            chbSBT.Checked = false;
            chbFlexuralStrength.Checked = false;
            chbCubeTesting.Checked = false;
            chbBondStrength.Checked = false;
            chbShiftChange.Checked = false;
            chbIsDeveloper.Checked = false;
        }

        private void chbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSelectAll.Checked == true)
            {
                allChecked();
            }
            else
            {
                allUnChecked();
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            clearFields();
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            using (MySqlConnection dbConnection = new MySqlConnection(dbConnectionString))
            {
                dbConnection.Open();
                string username = txtUserName.Text.Trim();
                string query = "select * from tbluserprofile where UserName='" + username + "';";

                using (MySqlCommand dbCommand = new MySqlCommand(query, dbConnection))
                {
                    using (MySqlDataReader dataReader = dbCommand.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            isDataPresent = true;
                            id = Convert.ToInt32(dataReader["ID"]);
                            txtPassword.Text = (string)dataReader["PWD"];
                            txtConfirmPassword.Text = (string)dataReader["PWD"];
                            chbMixDesign.Checked = (Boolean)dataReader["MixDesign"];
                            chbRPMReport.Checked = (Boolean)dataReader["RPM"];
                            chbTemprature.Checked = (Boolean)dataReader["Temp"];
                            chbTensionRegisterWider.Checked = (Boolean)dataReader["TensWider"];
                            chbTensionRegisterTurnOut.Checked = (Boolean)dataReader["TensTurnOut"];
                            chbTensionRegisterXII.Checked = (Boolean)dataReader["TensXII"];
                            chbSBT.Checked = (Boolean)dataReader["SBT1"];
                            chbFlexuralStrength.Checked = (Boolean)dataReader["FlexuralStrength"];
                            chbCubeTesting.Checked = (Boolean)dataReader["CubeTesting"];
                            chbBondStrength.Checked = (Boolean)dataReader["BondStrength"];
                            chbShiftChange.Checked = (Boolean)dataReader["ShiftChange"];
                            chbIsDeveloper.Checked = (Boolean)dataReader["Edit"];
                        }
                    }
                }
            }
        }
    }
}
