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

namespace WindowsFormsApplication1
{
    public partial class CubeWaterWider_Opereation : Form
    {
        string update_cmbMixDesign = "60-T39", userid = "", datetimeMD = "", datetimeMD1 = "", datetimeMD2 = "", update_txtBox1 = "", update_txtBox2 = "", update_txtBox3 = "", update_txtBox4 = "", update_txtBox5 = "", update_txtBox6 = "", update_txtBox7 = "", update_txtBox8 = "";
        int rowId, HourMD, MinMD, SecMD;
        static string sConnectionString = ConfigurationManager.ConnectionStrings["MyConn007"].ConnectionString;
        public MySqlConnection myConn;

        public CubeWaterWider_Opereation(string id, int i)
        {
            InitializeComponent();
            userid = id;
            rowId = i;
        }

        private void Opereation_Form29_Wider_Load(object sender, EventArgs e)
        {
            myConn = new MySqlConnection(sConnectionString);
            try
            {
                if (myConn != null) { }
                myConn.Open();

            }
            catch (System.Exception ex)
            {
                //restartApplication();
            }

            int rowcount = GlobalClass.dt.Rows.Count;
            if (GlobalClass.dt.Rows.Count == 0)
            {

                button2.Visible = false;

                button1.Visible = true;

            }

            else if (userid == "")
            {

                button2.Visible = false;

                button1.Visible = true;

            }

            else
            {
                try
                {
                    textBox1.Text = GlobalClass.dt.Rows[rowId][0].ToString();

                    textBox2.Text = GlobalClass.dt.Rows[rowId][1].ToString();

                    textBox3.Text = GlobalClass.dt.Rows[rowId][2].ToString();

                    dateTimePicker1.Text = GlobalClass.dt.Rows[rowId][3].ToString();

                    textBox4.Text = GlobalClass.dt.Rows[rowId][4].ToString();

                    dateTimePicker2.Text = GlobalClass.dt.Rows[rowId][5].ToString();

                    textBox5.Text = GlobalClass.dt.Rows[rowId][6].ToString();

                    textBox6.Text = GlobalClass.dt.Rows[rowId][7].ToString();
                  
                    update_txtBox1 = textBox1.Text;
                    update_txtBox2 = textBox2.Text;
                    datetimeMD1 = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    datetimeMD2 = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    update_txtBox3 = textBox3.Text;
                    update_txtBox4 = textBox4.Text;
                    update_txtBox5 = textBox5.Text;
                    update_txtBox6 = textBox6.Text;
                    string HourAT = datetimeMD2.Substring(11, 2);
                    string MinAT = datetimeMD2.Substring(14, 2);
                    string SecAT = datetimeMD2.Substring(17, 2);
                    textBox19.Text = Convert.ToString(HourAT);
                    textBox20.Text = Convert.ToString(MinAT);
                    textBox21.Text = Convert.ToString(SecAT);
                    //update_txtBox7 = textBox7.Text;
                    //update_txtBox8 = textBox8.Text;

                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || dateTimePicker1.Text.Trim() == "" || dateTimePicker2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
                {

                    MessageBox.Show("Please fill all the entry....");

                }

                else
                {
                    //DataRow dr;

                    //dr = GlobalClass.dt.NewRow();

                    //dr[0] = textBox1.Text.Trim();
                    //dr[1] = textBox2.Text.Trim();
                    //dr[2] = dateTimePicker1.Text.Trim();
                    //dr[3] = dateTimePicker2.Text.Trim();
                    //dr[4] = textBox5.Text.Trim();
                    //dr[5] = textBox6.Text.Trim();
                    //dr[6] = textBox7.Text.Trim();
                    //dr[7] = textBox8.Text.Trim();                                      

                    //GlobalClass.dt.Rows.Add(dr);

                    //GlobalClass.adap.Update(GlobalClass.dt);

                     HourMD = Convert.ToInt32(textBox19.Text);
                    MinMD = Convert.ToInt32(textBox20.Text);
                    SecMD = Convert.ToInt32(textBox21.Text);
                    if (HourMD <= 24 && MinMD <= 60 && SecMD <= 60)
                    {
                        string OnlyDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                        string AllDate = Convert.ToString(OnlyDate + " " + HourMD + ":" + MinMD + ":" + SecMD);
                        DialogResult result = MessageBox.Show("Do you want to Insert record..?", "Confirmation", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {
                            var query = "insert into tbldata_29_Wider (batchno, cubeno, initialwt, castdate, ageindays, date, laodinkn, strength, mbatch, mix_design) values ('" + textBox1.Text.Trim() + "', '" + textBox2.Text.Trim() + "', '" + textBox3.Text.Trim() + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', '" + textBox4.Text.Trim() + "','" + AllDate + "','" + textBox5.Text.Trim() + "','" + textBox6.Text.Trim() + "','" + textBox1.Text.Trim() + "','" + update_cmbMixDesign + "');";
                            using (var command = new MySqlCommand(query, myConn))
                            {
                                using (var reader = command.ExecuteReader())
                                {
                                    //while (reader.Read())
                                    //{
                                    MessageBox.Show("Record Insert Successfully");
                                    //}
                                }
                            }
                        }
                        else if (result == DialogResult.No)
                        {
                            MessageBox.Show("Insert Operation Cancled");
                        }
                        else
                        {
                            this.Close();
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please Insert Correct Time");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                //GlobalClass.dt.Rows[rowId][0] = textBox1.Text.Trim();

                //GlobalClass.dt.Rows[rowId][1] = textBox2.Text.Trim();

                //string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm:ss");

                //string theDate1 = dateTimePicker2.Value.ToString("yyyy-MM-dd");

                ////string theDate = Convert.ToString(DateTime.ParseExact(dateTimePicker1.Value.ToString(), "yyyy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture));

                ////string theDate1 = Convert.ToString(DateTime.ParseExact(dateTimePicker2.Value.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture));

                //GlobalClass.dt.Rows[rowId][2] = Convert.ToDateTime(theDate);

                //GlobalClass.dt.Rows[rowId][3] = Convert.ToDateTime(theDate1);

                //GlobalClass.dt.Rows[rowId][4] = textBox5.Text.Trim();

                //GlobalClass.dt.Rows[rowId][5] = textBox6.Text.Trim();

                //GlobalClass.dt.Rows[rowId][6] = textBox7.Text.Trim();

                //GlobalClass.dt.Rows[rowId][7] = textBox8.Text.Trim();

                //GlobalClass.dt.Rows[rowId][9] = textBox1.Text.Trim();

                //GlobalClass.adap.Update(GlobalClass.dt);
                  HourMD = Convert.ToInt32(textBox19.Text);
                    MinMD = Convert.ToInt32(textBox20.Text);
                    SecMD = Convert.ToInt32(textBox21.Text);
                    if (HourMD <= 24 && MinMD <= 60 && SecMD <= 60)
                    {
                        string OnlyDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                        string AllDate = Convert.ToString(OnlyDate + " " + HourMD + ":" + MinMD + ":" + SecMD);
                        DialogResult result = MessageBox.Show("Do you want to Update record..?", "Confirmation", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {
                            var query = "update tbldata_29_Wider set mix_design='" + update_cmbMixDesign + "', batchno = '" + textBox1.Text.Trim() + "', cubeno = '" + textBox2.Text.Trim() + "', initialwt = '" + textBox3.Text.Trim() + "', `castdate`= '" + dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss") + "', ageindays = '" + textBox4.Text.Trim() + "', `date`= '" + AllDate + "', laodinkn= '" + textBox5.Text.Trim() + "', strength= '" + textBox6.Text.Trim() + "', mbatch = '" + textBox1.Text.Trim() + "' where mbatch='" + update_txtBox1 + "' and cubeno = '" + update_txtBox2 + "' and  initialwt = '" + update_txtBox3 + "' and  `castdate`= '" + datetimeMD1 + "' and  ageindays = '" + update_txtBox4 + "' and  `date`= '" + datetimeMD2 + "' and  laodinkn= '" + update_txtBox5 + "' and strength= '" + update_txtBox6 + "';";
                            using (var command = new MySqlCommand(query, myConn))
                            {
                                using (var reader = command.ExecuteReader())
                                {
                                    //while (reader.Read())
                                    //{
                                    MessageBox.Show("Record Updation Successfully");
                                    //}
                                }
                            }
                        }
                        else if (result == DialogResult.No)
                        {
                            MessageBox.Show("Update Operation Cancled");
                        }
                        else
                        {
                            this.Close();
                        }

                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Please Insert Correct Time");
                    }
            }

                    
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to Delete record..?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    var query = "delete from tbldata_29_Wider where mbatch='" + update_txtBox1 + "' and batchno = '" + update_txtBox1 + "' and  cubeno = '" + update_txtBox2 + "' and  initialwt = '" + update_txtBox3 + "' and  `castdate`= '" + datetimeMD1 + "' and  ageindays = '" + update_txtBox4 + "' and  `date`= '" + datetimeMD2 + "' and  laodinkn= '" + update_txtBox5 + "' and strength= '" + update_txtBox6 + "';";
                    using (var command = new MySqlCommand(query, myConn))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            //while (reader.Read())
                            //{
                            MessageBox.Show("Record Delete Successfully");
                            //}
                        }
                    }
                }
                else if (result == DialogResult.No)
                {
                    MessageBox.Show("Delete Operation Cancled");
                }
                else
                {
                    this.Close();
                }

                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox6.Text = (Math.Round((Convert.ToDouble(textBox5.Text.Trim()) / 22.5),3)).ToString();
            }
            catch { }
        }       
    }
}
