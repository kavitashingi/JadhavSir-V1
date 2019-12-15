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
    public partial class Temp_Opereation : Form
    {
        string userid = "", datetimeMD = "", datetimeMD1 = "", datetimeMD2 = "";
        string batchno, castno, benchno, intialread, rlu, rll, rru, rrl, frlu, frll, frru, frrl, wirelength, cross_section, youngsmodulus, elongation, elongationkn, prestress, mbatch, date;
        string update_txtBox1 = "", update_txtBox2 = "", update_txtBox3 = "", update_txtBox4 = "", update_txtBox5 = "", update_txtBox6 = "", update_txtBox7 = "", update_txtBox8 = "", update_txtBox9 = "", update_txtBox10 = "", update_txtBox11 = "", update_txtBox12 = "", update_txtBox13 = "", update_txtBox14 = "", update_txtBox15 = "", update_txtBox16 = "", update_txtBox17 = "", update_txtBox18 = "";
        int rowId, HourMD, MinMD, SecMD;
        static string sConnectionString = ConfigurationManager.ConnectionStrings["MyConn007"].ConnectionString;
        public MySqlConnection myConn;

        public Temp_Opereation()
        {
            InitializeComponent();
        }

        public Temp_Opereation(string id, int i)
        {
            InitializeComponent();
            userid = id;
            rowId = i;
        }

        private void Opereation_Temp_Load(object sender, EventArgs e)
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
                    //benchno, castingtime, rpm1, t1, batchno, rpm2, t2, rpm3, t3, rpm4, t4, rpm5, t5, rpm6, t6, rpm7, t7, rpm8, t8


                    textBox1.Text = GlobalClass.dt.Rows[rowId][0].ToString();

                    dateTimePicker1.Text = GlobalClass.dt.Rows[rowId][4].ToString();


                    datetimeMD = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");

                    string HourAT = datetimeMD.Substring(11, 2);
                    string MinAT = datetimeMD.Substring(14, 2);
                    string SecAT = datetimeMD.Substring(17, 2);

                    textBox2.Text = GlobalClass.dt.Rows[rowId][1].ToString();

                    textBox3.Text = Convert.ToString(HourAT);

                    textBox4.Text = Convert.ToString(MinAT);

                    textBox5.Text = Convert.ToString(SecAT);

                    textBox6.Text = GlobalClass.dt.Rows[rowId][2].ToString();

                    textBox7.Text = GlobalClass.dt.Rows[rowId][3].ToString();

                    textBox8.Text = GlobalClass.dt.Rows[rowId][5].ToString();

                    //textBox9.Text = GlobalClass.dt.Rows[rowId][6].ToString();

                    //textBox10.Text = GlobalClass.dt.Rows[rowId][7].ToString();

                    //textBox11.Text = GlobalClass.dt.Rows[rowId][8].ToString();

                    //textBox12.Text = GlobalClass.dt.Rows[rowId][9].ToString();

                    //textBox13.Text = GlobalClass.dt.Rows[rowId][10].ToString();

                    //textBox14.Text = GlobalClass.dt.Rows[rowId][11].ToString();

                    //textBox15.Text = GlobalClass.dt.Rows[rowId][12].ToString();

                    //textBox16.Text = GlobalClass.dt.Rows[rowId][13].ToString();

                    //textBox17.Text = GlobalClass.dt.Rows[rowId][14].ToString();

                    //textBox18.Text = GlobalClass.dt.Rows[rowId][15].ToString();

                    //textBox19.Text = GlobalClass.dt.Rows[rowId][16].ToString();

                    //textBox20.Text = GlobalClass.dt.Rows[rowId][17].ToString();

                    //textBox21.Text = GlobalClass.dt.Rows[rowId][18].ToString();


                    update_txtBox1 = textBox1.Text;
                    update_txtBox2 = textBox2.Text;
                    //update_txtBox3 = textBox3.Text;
                    //update_txtBox4 = textBox4.Text;
                    //update_txtBox5 = textBox5.Text;
                    update_txtBox6 = textBox6.Text;
                    update_txtBox7 = textBox7.Text;
                    update_txtBox8 = textBox8.Text;
                    //update_txtBox9 = textBox9.Text;
                    //update_txtBox10 = textBox10.Text;
                    //update_txtBox11 = textBox11.Text;
                    //update_txtBox12 = textBox12.Text;
                    //update_txtBox13 = textBox13.Text;
                    //update_txtBox14 = textBox14.Text;
                    //update_txtBox15 = textBox15.Text;
                    //update_txtBox16 = textBox16.Text;
                    //update_txtBox17 = textBox17.Text;
                    //update_txtBox18 = textBox18.Text;

                    //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

                    HourMD = Convert.ToInt32(textBox3.Text);
                    MinMD = Convert.ToInt32(textBox4.Text);
                    SecMD = Convert.ToInt32(textBox5.Text);

                    //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

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
                if (HourMD <= 24 && MinMD <= 60 && SecMD <= 60)
                {

                    if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || dateTimePicker1.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "" || textBox7.Text.Trim() == "" || textBox8.Text.Trim() == "")//|| textBox9.Text.Trim() == "" || textBox10.Text.Trim() == "" || textBox11.Text.Trim() == "" || textBox12.Text.Trim() == "" || textBox13.Text.Trim() == "" || textBox14.Text.Trim() == "" || textBox15.Text.Trim() == "" || textBox16.Text.Trim() == "" || textBox17.Text.Trim() == "" || textBox18.Text.Trim() == "")
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

                        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

                        HourMD = Convert.ToInt32(textBox3.Text);
                        MinMD = Convert.ToInt32(textBox4.Text);
                        SecMD = Convert.ToInt32(textBox5.Text);

                        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


                        DialogResult result = MessageBox.Show("Do you want to Insert record..?", "Confirmation", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {
                            string OnlyDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                            string AllDate = Convert.ToString(OnlyDate + " " + HourMD + ":" + MinMD + ":" + SecMD);

                            var query = "insert into temp (`Machine id`, `Data available`, `prosess no`, `set value`, `process value`, `date stamp`, `batchno`) values ('" + textBox1.Text.Trim() + "', 1, '" + textBox2.Text.Trim() + "','" + textBox6.Text.Trim() + "','" + textBox7.Text.Trim() + "','" + AllDate + "','" + textBox8.Text.Trim() + "');";

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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (HourMD <= 24 && MinMD <= 60 && SecMD <= 60)
                {

                    if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || dateTimePicker1.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "" || textBox7.Text.Trim() == "" || textBox8.Text.Trim() == "")//|| textBox9.Text.Trim() == "" || textBox10.Text.Trim() == "" || textBox11.Text.Trim() == "" || textBox12.Text.Trim() == "" || textBox13.Text.Trim() == "" || textBox14.Text.Trim() == "" || textBox15.Text.Trim() == "" || textBox16.Text.Trim() == "" || textBox17.Text.Trim() == "" || textBox18.Text.Trim() == "")
                    {

                        MessageBox.Show("Please fill all the entry....");

                    }

                    else
                    {
                        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

                        HourMD = Convert.ToInt32(textBox3.Text);
                        MinMD = Convert.ToInt32(textBox4.Text);
                        SecMD = Convert.ToInt32(textBox5.Text);

                        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@



                        DialogResult result = MessageBox.Show("Do you want to Update record..?", "Confirmation", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {
                            string OnlyDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                            string AllDate = Convert.ToString(OnlyDate + " " + HourMD + ":" + MinMD + ":" + SecMD);


                            var query = "update temp set `Machine id` = '" + textBox1.Text.Trim() + "', `prosess no` = '" + textBox2.Text.Trim() + "', `date stamp`= '" + AllDate + "', `set value` = '" + textBox6.Text.Trim() + "', `process value` = '" + textBox7.Text.Trim() + "', `batchno` = '" + textBox8.Text.Trim() + "' where batchno='" + update_txtBox8 + "' and `set value`='" + update_txtBox6 + "' and `process value`='" + update_txtBox7 + "' and `date stamp` = '" + datetimeMD + "';";

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
                    var query = "delete from temp where batchno='" + update_txtBox8 + "' and `set value`='" + update_txtBox6 + "' and `process value`='" + update_txtBox7 + "' and `date stamp` = '" + datetimeMD + "';";
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
    }
}
