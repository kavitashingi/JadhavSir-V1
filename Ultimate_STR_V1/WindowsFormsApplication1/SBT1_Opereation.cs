using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Data;

using System.Drawing;

using System.Linq;

using System.Text;

using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class SBT1_Opereation : Form
    {
        string update_cmbMixDesign = "", userid = "", datetimeMD1 = "", datetimeMD2 = "", update_txtBox1 = "", update_txtBox2 = "", update_txtBox3 = "", update_txtBox4 = "", update_txtBox5 = "", update_txtBox6 = "", update_txtBox7 = "", update_txtBox8 = "";

        int rowId;

        static string sConnectionString = ConfigurationManager.ConnectionStrings["MyConn007"].ConnectionString;
        public MySqlConnection myConn;

        public SBT1_Opereation(string id, int i)
        {

            InitializeComponent();

            userid = id;

            rowId = i;

        }

        private void Opereation_Load(object sender, EventArgs e)
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
                    dateTimePicker1.Text = GlobalClass.dt.Rows[rowId][2].ToString();
                    dateTimePicker2.Text = GlobalClass.dt.Rows[rowId][3].ToString();
                    textBox5.Text = GlobalClass.dt.Rows[rowId][4].ToString();
                    textBox6.Text = GlobalClass.dt.Rows[rowId][5].ToString();
                    textBox7.Text = GlobalClass.dt.Rows[rowId][6].ToString();
                    textBox8.Text = GlobalClass.dt.Rows[rowId][7].ToString();
                    cmbMixDesign.SelectedItem = GlobalClass.dt.Rows[rowId][8].ToString();

                    
                    update_txtBox1 = textBox1.Text;
                    update_txtBox2 = textBox2.Text;
                    datetimeMD1 = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    datetimeMD2 = dateTimePicker2.Value.ToString("yyyy-MM-dd ");                    
                    //update_txtBox3 = textBox3.Text;
                    //update_txtBox4 = textBox4.Text;
                    update_txtBox5 = textBox5.Text;
                    update_txtBox6 = textBox6.Text;
                    update_txtBox7 = textBox7.Text;
                    update_txtBox8 = textBox8.Text;
                    update_cmbMixDesign = cmbMixDesign.SelectedText;
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

                if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || dateTimePicker1.Text.Trim() == "" || dateTimePicker2.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "" || textBox7.Text.Trim() == "" || textBox8.Text.Trim() == "")
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


                    DialogResult result = MessageBox.Show("Do you want to Insert record..?", "Confirmation", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        var query = "insert into tbldata_28_1 (batchno, sleeperno, date, castdate, top, bottom, mr1, mr2, mbatch, mix_design) values ('" + textBox1.Text.Trim() + "', '" + textBox2.Text.Trim() + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm:ss") + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "','" + textBox5.Text.Trim() + "','" + textBox6.Text.Trim() + "','" + textBox7.Text.Trim() + "','" + textBox8.Text.Trim() + "','" + textBox1.Text.Trim() + "','"+cmbMixDesign.SelectedItem.ToString()+"');";
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

                DialogResult result = MessageBox.Show("Do you want to Update record..?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    //var query = "update tbldata_31 set `date`= '" + dateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm:ss") + "', batchno = '" + textBox1.Text.Trim() + "', mixdesign = '" + textBox2.Text.Trim() + "', water= '" + textBox3.Text.Trim() + "', cement= '" + textBox4.Text.Trim() + "', ca1= '" + textBox5.Text.Trim() + "', ca2= '" + textBox6.Text.Trim() + "', fa= '" + textBox7.Text.Trim() + "', addmix= '" + textBox8.Text.Trim() + "', mbatch = '" + textBox1.Text.Trim() + "' where mbatch='" + update_txtBox1 + "' and  `date`= '" + datetimeMD + "' and batchno = '" + update_txtBox1 + "' and mixdesign = '" + update_txtBox2 + "' and water= '" + update_txtBox3 + "' and cement= '" + update_txtBox4 + "' and ca1= '" + update_txtBox5 + "' and ca2= '" + update_txtBox6 + "' and fa= '" + update_txtBox7 + "' and addmix= '" + update_txtBox8 + "';";
                    var query = "update tbldata_28_1 set mix_design='"+cmbMixDesign.SelectedItem+"', batchno = '" + textBox1.Text.Trim() + "', sleeperno = '" + textBox2.Text.Trim() + "', `date`= '" + dateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm:ss") + "', castdate= '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "', top= '" + textBox5.Text.Trim() + "', bottom= '" + textBox6.Text.Trim() + "', mr1= '" + textBox7.Text.Trim() + "', mr2= '" + textBox8.Text.Trim() + "', mbatch = '" + textBox1.Text.Trim() + "' where mbatch='" + update_txtBox1 + "' and  sleeperno = '" + update_txtBox2 + "' and  `date`= '" + datetimeMD1 + "' and  castdate= '" + datetimeMD2 + "' and  top= '" + update_txtBox5 + "' and  bottom= '" + update_txtBox6 + "' and  mr1= '" + update_txtBox7 + "' and mr2= '" + update_txtBox8 + "';";
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
                    var query = "delete from tbldata_28_1 where mbatch='" + update_txtBox1 + "' and batchno = '" + update_txtBox1 + "' and  sleeperno = '" + update_txtBox2 + "' and  `date`= '" + datetimeMD1 + "' and  castdate= '" + datetimeMD2 + "' and  top= '" + update_txtBox5 + "' and  bottom= '" + update_txtBox6 + "' and  mr1= '" + update_txtBox7 + "' and mr2= '" + update_txtBox8 + "';";
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
