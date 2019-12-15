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
    public partial class TensionWider_Opereation : Form
    {
        string userid = "", datetimeMD = "";
        string batchno, castno, benchno, intialread, rlu, rll, rru, rrl, frlu, frll, frru, frrl, wirelength, cross_section, youngsmodulus, elongation, elongationkn, prestress, mbatch, date;
        string update_txtBox1 = "", update_txtBox2 = "", update_txtBox3 = "", update_txtBox4 = "", update_txtBox5 = "", update_txtBox6 = "", update_txtBox7 = "", update_txtBox8 = "", update_txtBox9 = "", update_txtBox10 = "", update_txtBox11 = "", update_txtBox12 = "", update_txtBox13 = "", update_txtBox14 = "", update_txtBox15 = "", update_txtBox16 = "", update_txtBox17 = "", update_txtBox18 = "";
        int rowId, HourMD, MinMD, SecMD;
        static string sConnectionString = ConfigurationManager.ConnectionStrings["MyConn007"].ConnectionString;
        public MySqlConnection myConn;

        public TensionWider_Opereation()
        {
            InitializeComponent();
        }

        public TensionWider_Opereation(string id, int i)
        {
            InitializeComponent();
            userid = id;
            rowId = i;
        }

        private void Opereation_Form32_2_Load(object sender, EventArgs e)
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

                    textBox4.Text = GlobalClass.dt.Rows[rowId][3].ToString();

                    textBox5.Text = GlobalClass.dt.Rows[rowId][4].ToString();

                    textBox6.Text = GlobalClass.dt.Rows[rowId][5].ToString();

                    textBox7.Text = GlobalClass.dt.Rows[rowId][6].ToString();

                    textBox8.Text = GlobalClass.dt.Rows[rowId][7].ToString();

                    textBox9.Text = GlobalClass.dt.Rows[rowId][8].ToString();

                    textBox10.Text = GlobalClass.dt.Rows[rowId][9].ToString();

                    textBox11.Text = GlobalClass.dt.Rows[rowId][10].ToString();

                    textBox12.Text = GlobalClass.dt.Rows[rowId][11].ToString();

                    textBox13.Text = GlobalClass.dt.Rows[rowId][12].ToString();

                    textBox14.Text = GlobalClass.dt.Rows[rowId][13].ToString();

                    textBox15.Text = GlobalClass.dt.Rows[rowId][14].ToString();

                    textBox16.Text = GlobalClass.dt.Rows[rowId][15].ToString();

                    textBox17.Text = GlobalClass.dt.Rows[rowId][16].ToString();

                    textBox18.Text = GlobalClass.dt.Rows[rowId][17].ToString();
                    DateTime mydt = Convert.ToDateTime(GlobalClass.dt.Rows[rowId][19]);
                    datetimeMD = mydt.ToString("yyyy-MM-dd HH:mm:ss");
                    dateTimePicker1.Text = datetimeMD;

                    string HourAT = mydt.Hour.ToString();
                    string MinAT = mydt.Minute.ToString();
                    string SecAT = mydt.Second.ToString();

                    textBox19.Text = HourAT;
                    textBox20.Text = MinAT;
                    textBox21.Text = SecAT; ;

                    update_txtBox1 = textBox1.Text;
                    update_txtBox2 = textBox2.Text;
                    update_txtBox3 = textBox3.Text;
                    update_txtBox4 = textBox4.Text;
                    update_txtBox5 = textBox5.Text;
                    update_txtBox6 = textBox6.Text;
                    update_txtBox7 = textBox7.Text;
                    update_txtBox8 = textBox8.Text;
                    update_txtBox9 = textBox9.Text;
                    update_txtBox10 = textBox10.Text;
                    update_txtBox11 = textBox11.Text;
                    update_txtBox12 = textBox12.Text;
                    update_txtBox13 = textBox13.Text;
                    update_txtBox14 = textBox14.Text;
                    update_txtBox15 = textBox15.Text;
                    update_txtBox16 = textBox16.Text;
                    update_txtBox17 = textBox17.Text;
                    update_txtBox18 = textBox18.Text;

                    //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

                    HourMD = Convert.ToInt32(textBox19.Text);
                    MinMD = Convert.ToInt32(textBox20.Text);
                    SecMD = Convert.ToInt32(textBox21.Text);

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

                    if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || dateTimePicker1.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "" || textBox7.Text.Trim() == "" || textBox8.Text.Trim() == "" || textBox9.Text.Trim() == "" || textBox10.Text.Trim() == "" || textBox11.Text.Trim() == "" || textBox12.Text.Trim() == "" || textBox13.Text.Trim() == "" || textBox14.Text.Trim() == "" || textBox15.Text.Trim() == "")// || textBox16.Text.Trim() == "" || textBox17.Text.Trim() == "" || textBox18.Text.Trim() == "")
                    {

                        MessageBox.Show("Please fill all the entry....");

                    }

                    else
                    {

                        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

                        HourMD = Convert.ToInt32(textBox19.Text);
                        MinMD = Convert.ToInt32(textBox20.Text);
                        SecMD = Convert.ToInt32(textBox21.Text);

                        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


                        DialogResult result = MessageBox.Show("Do you want to Insert record..?", "Confirmation", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {


                            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

                            double A, B, ELong, ElongKN, PreStress111, Txt5, Txt6, Txt7, Txt8, Txt9, Txt10, Txt11, Txt12, Txt13, Txt14, Txt15;

                            Txt5 = Convert.ToDouble(textBox5.Text.Trim());
                            Txt6 = Convert.ToDouble(textBox6.Text.Trim());
                            Txt7 = Convert.ToDouble(textBox7.Text.Trim());
                            Txt8 = Convert.ToDouble(textBox8.Text.Trim());
                            Txt9 = Convert.ToDouble(textBox9.Text.Trim());
                            Txt10 = Convert.ToDouble(textBox10.Text.Trim());
                            Txt11 = Convert.ToDouble(textBox11.Text.Trim());
                            Txt12 = Convert.ToDouble(textBox12.Text.Trim());
                            Txt13 = Convert.ToDouble(textBox13.Text.Trim());
                            Txt14 = Convert.ToDouble(textBox14.Text.Trim());
                            Txt15 = Convert.ToDouble(textBox15.Text.Trim());

                            A = ((Txt5 + Txt6 + Txt7 + Txt8) / 4);
                            B = ((Txt9 + Txt10 + Txt11 + Txt12) / 4);

                            ELong = (B - A);
                            ELong = System.Math.Round(ELong, 3);

                            ElongKN = (((B - A) * Txt14 * Txt15) / Txt13);
                            ElongKN = System.Math.Round(ElongKN, 3);

                            PreStress111 = ElongKN + 50;
                            PreStress111 = System.Math.Round(PreStress111, 3);

                            textBox16.Text = Convert.ToString(ELong);
                            textBox17.Text = Convert.ToString(ElongKN);
                            textBox18.Text = Convert.ToString(PreStress111);


                            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@





                            string OnlyDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                            string AllDate = Convert.ToString(OnlyDate + " " + HourMD + ":" + MinMD + ":" + SecMD);

                            var query = "insert into tbldata_32_t39 (batchno, castno, benchno, intialread, rlu, rll, rru, rrl, frlu, frll, frru, frrl, wirelength, cross_section, youngsmodulus, elongation, elongationkn, prestress, mbatch, `date`) values ('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + textBox6.Text.Trim() + "','" + textBox7.Text.Trim() + "','" + textBox8.Text.Trim() + "','" + textBox9.Text.Trim() + "','" + textBox10.Text.Trim() + "','" + textBox11.Text.Trim() + "','" + textBox12.Text.Trim() + "','" + textBox13.Text.Trim() + "','" + textBox14.Text.Trim() + "','" + textBox15.Text.Trim() + "','" + textBox16.Text.Trim() + "','" + textBox17.Text.Trim() + "','" + textBox18.Text.Trim() + "','" + textBox1.Text.Trim() + "','" + AllDate + "');";

                            using (var command = new MySqlCommand(query, myConn))
                            {
                                using (var reader = command.ExecuteReader())
                                {
                                    //while (reader.Read())
                                    //{
                                    //MessageBox.Show("Record Insert Successfully");
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

                    if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || dateTimePicker1.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "" || textBox7.Text.Trim() == "" || textBox8.Text.Trim() == "" || textBox9.Text.Trim() == "" || textBox10.Text.Trim() == "" || textBox11.Text.Trim() == "" || textBox12.Text.Trim() == "" || textBox13.Text.Trim() == "" || textBox14.Text.Trim() == "" || textBox15.Text.Trim() == "")// || textBox16.Text.Trim() == "" || textBox17.Text.Trim() == "" || textBox18.Text.Trim() == "")
                    {

                        MessageBox.Show("Please fill all the entry....");

                    }

                    else
                    {
                        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

                        HourMD = Convert.ToInt32(textBox19.Text);
                        MinMD = Convert.ToInt32(textBox20.Text);
                        SecMD = Convert.ToInt32(textBox21.Text);

                        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@



                        DialogResult result = MessageBox.Show("Do you want to Update record..?", "Confirmation", MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {


                            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

                            double A, B, ELong, ElongKN, PreStress111, Txt5, Txt6, Txt7, Txt8, Txt9, Txt10, Txt11, Txt12, Txt13, Txt14, Txt15;

                            Txt5 = Convert.ToDouble(textBox5.Text.Trim());
                            Txt6 = Convert.ToDouble(textBox6.Text.Trim());
                            Txt7 = Convert.ToDouble(textBox7.Text.Trim());
                            Txt8 = Convert.ToDouble(textBox8.Text.Trim());
                            Txt9 = Convert.ToDouble(textBox9.Text.Trim());
                            Txt10 = Convert.ToDouble(textBox10.Text.Trim());
                            Txt11 = Convert.ToDouble(textBox11.Text.Trim());
                            Txt12 = Convert.ToDouble(textBox12.Text.Trim());
                            Txt13 = Convert.ToDouble(textBox13.Text.Trim());
                            Txt14 = Convert.ToDouble(textBox14.Text.Trim());
                            Txt15 = Convert.ToDouble(textBox15.Text.Trim());

                            A = ((Txt5 + Txt6 + Txt7 + Txt8) / 4);
                            B = ((Txt9 + Txt10 + Txt11 + Txt12) / 4);

                            ELong = (B - A);
                            ELong = System.Math.Round(ELong, 3);

                            ElongKN = (((B - A) * Txt14 * Txt15) / Txt13);
                            ElongKN = System.Math.Round(ElongKN, 3);

                            PreStress111 = ElongKN + 50;
                            PreStress111 = System.Math.Round(PreStress111, 3);

                            textBox16.Text = Convert.ToString(ELong);
                            textBox17.Text = Convert.ToString(ElongKN);
                            textBox18.Text = Convert.ToString(PreStress111);


                            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@






                            string OnlyDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                            string AllDate = Convert.ToString(OnlyDate + " " + HourMD + ":" + MinMD + ":" + SecMD);


                            var query = "update tbldata_32_t39 set mbatch = '" + update_txtBox1 + "', date= '" + AllDate + "', castno= '" + textBox2.Text.Trim() + "', benchno= '" + textBox3.Text.Trim() + "', intialread= '" + textBox4.Text.Trim() + "', rlu= '" + textBox5.Text.Trim() + "', rll= '" + textBox6.Text.Trim() + "', rru= '" + textBox7.Text.Trim() + "', rrl= '" + textBox8.Text.Trim() + "', frlu= '" + textBox9.Text.Trim() + "', frll= '" + textBox10.Text.Trim() + "', frru= '" + textBox11.Text.Trim() + "', frrl= '" + textBox12.Text.Trim() + "', wirelength= '" + textBox13.Text.Trim() + "', cross_section= '" + textBox14.Text.Trim() + "', youngsmodulus= '" + textBox15.Text.Trim() + "', elongation= '" + textBox16.Text.Trim() + "', elongationkn= '" + textBox17.Text.Trim() + "', prestress= '" + textBox18.Text.Trim() + "' where batchno='" + update_txtBox1 + "' and date = '" + datetimeMD + "' and benchno='" + update_txtBox3 + (update_txtBox2.Trim() == "" ? "';" : "' and castno='" + update_txtBox2 + "';");

                            using (var command = new MySqlCommand(query, myConn))
                            {
                                using (var reader = command.ExecuteReader())
                                {
                                    //while (reader.Read())
                                    //{
                                    //MessageBox.Show("Record Updation Successfully");
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
                    var query = "delete from tbldata_32_t39 where mbatch='" + update_txtBox1 + "' and  batchno='" + update_txtBox1 + "' and date = '" + datetimeMD + "';";
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
