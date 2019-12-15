using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Timers;

namespace WindowsFormsApplication1
{
    public partial class HomePage : Form
    {
        SerialPort ComPort;
        public string ReturnValue1 { get; set; }
        public string ReturnValue2 { get; set; }
        public int AnsCount;
        string data = "";
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        int chemberno, flage = 0;
        string dataavailable, processno;
        string pv, sv;
        string[] rpm;
        string benchrpm;
        string[] time;
        DateTime[] dt = new DateTime[22];
        string[] asd = new string[22];
        string asd1;
        string[] cycle = new string[22];
        string[] pv123 = new string[22];
        string[] sv123 = new string[22];
        bool autoRPM = false;
        double svAddmix, svWater, svCA1, svCA2, svFA, svCement;

        public HomePage(MenuList menuList)
        {
            InitializeComponent();
            panel3.Visible = false;
            comboBox1.SelectedIndex = 0;
            rpm = new string[9];
            time = new string[9];
            menuVisibility(menuList);
        }

        private void menuVisibility(MenuList menuList)
        {
            menuItemChangeCompany.Visible = menuList.Edit;
            menuItemShiftChange.Visible = menuList.ShiftChange;
            menuItemUserProfile.Visible = menuList.Edit;

            menuItemTensXII.Visible = menuList.TensXII;
            menuItemTensWider.Visible = menuList.TensWider;
            menuItemTensTurnOut.Visible = menuList.TensTurnOut;

            menuItemRPMReport.Visible = menuList.RPM;
            menuItemMixDesign.Visible = menuList.MixDesign;
            menuItemFlexuralStrength.Visible=menuList.FlexuralStrength;

            menuItemBondStrength.Visible = menuList.BondStrength;
            menuItemCubeTesting.Visible = menuList.CubeTesting;
            menuItemTemprature.Visible = menuList.Temp;
            menuItemSBT.Visible = menuList.SBT1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (batchnotxt.Text == "" || wirelentxt.Text == "" || crosstxt.Text == "" || txtWater.Text == "" || txtCement.Text == "" || txtCA1.Text == "" || txtCA2.Text == "" || txtFa_sv.Text == "" || txtAdmix.Text == "" || youngsmodtxt.Text == "" || comboBox3.Items.Count < 1 || comboBox3.SelectedItem.ToString() == "" || tensioncombo.SelectedItem.ToString() == "")
                MessageBox.Show("Enter All Selction");
            else
            {

                server = "localhost";
                database = "ultimate_ele1";
                uid = "root";
                password = "teamat";
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                connectionString = "Database=" + database + ";Server=localhost;UID=root;PWD=teamat;";
                try
                {
                    connection = new MySqlConnection(connectionString);
                    connection.Open();
                    //string query = "INSERT INTO current selection (Batch no, mix, tension, length of wire, CS, intervals, id) VALUES('"+textBox2.Text+"','"+ textBox3.Text+"','"+textBox4.Text+"','"+ textBox5.Text+"','"+ comboBox2.SelectedItem.ToString()+"','"+comboBox3.SelectedItem.ToString()+"');";
                    // MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    // cmd.ExecuteNonQuery();

                    //close connection

                    readdata();
                    insertBatchSetValue();
                    btnconnect.Visible = false;
                    //    connection.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("ERROR In Connecting To Database:Plz check Mysql Installation");
                }
            }
        }
        void readdata()
        {
            ComPort = new SerialPort(comboBox3.SelectedItem.ToString());

            ComPort.BaudRate = Convert.ToInt32("9600");
            ComPort.DataBits = Convert.ToInt16("8");
            ComPort.StopBits = StopBits.One;
            ComPort.Handshake = Handshake.None;
            ComPort.Parity = Parity.None;
            try
            {
                ComPort.Open();
                MessageBox.Show("Port Is Connected");
                lblstatus.Text = "Connected";
                comboBox3.Enabled = false;
                lblstatus.ForeColor = Color.Green;
                btndisconnect.Visible = true;
                btnconnect.Visible = false;

                asd[1] = "..";
                asd[2] = "..";
                asd[3] = "..";
                asd[4] = "..";

                asd[5] = "..";
                asd[6] = "..";
                asd[7] = "..";
                asd[8] = "..";
                asd[9] = "..";
                asd[10] = "..";
                asd[11] = "..";
                asd[12] = "..";
                asd[13] = "..";
                asd[14] = "..";
                asd[15] = "..";
                asd[16] = "..";
                asd[17] = "..";
                asd[18] = "..";
                asd[19] = "..";
                asd[20] = "..";
                asd[21] = "..";
                cycle[1] = "..";
                cycle[2] = "..";
                cycle[3] = "..";
                cycle[4] = "..";

                cycle[5] = "..";
                cycle[6] = "..";
                cycle[7] = "..";
                cycle[8] = "..";
                cycle[9] = "..";
                cycle[10] = "..";
                cycle[11] = "..";
                cycle[12] = "..";
                cycle[13] = "..";
                cycle[14] = "..";
                cycle[15] = "..";
                cycle[16] = "..";
                cycle[17] = "..";
                cycle[18] = "..";
                cycle[19] = "..";
                cycle[20] = "..";
                cycle[21] = "..";

                pv123[1] = "9999.00";
                pv123[2] = "9999.00";
                pv123[3] = "9999.00";
                pv123[4] = "9999.00";

                pv123[5] = "9999.00";
                pv123[6] = "9999.00";
                pv123[7] = "9999.00";
                pv123[8] = "9999.00";
                pv123[9] = "9999.00";
                pv123[10] = "9999.00";
                pv123[11] = "9999.00";
                pv123[12] = "9999.00";
                pv123[13] = "9999.00";
                pv123[14] = "9999.00";
                pv123[15] = "9999.00";
                pv123[16] = "9999.00";
                pv123[17] = "9999.00";
                pv123[18] = "9999.00";
                pv123[19] = "9999.00";
                pv123[20] = "9999.00";
                pv123[21] = "9999.00";
                sv123[1] = "9999.00";
                sv123[2] = "9999.00";
                sv123[3] = "9999.00";
                sv123[4] = "9999.00";

                sv123[5] = "9999.00";
                sv123[6] = "9999.00";
                sv123[7] = "9999.00";
                sv123[8] = "9999.00";
                sv123[9] = "9999.00";
                sv123[10] = "9999.00";
                sv123[11] = "9999.00";
                sv123[12] = "9999.00";
                sv123[13] = "9999.00";
                sv123[14] = "9999.00";
                sv123[15] = "9999.00";
                sv123[16] = "9999.00";
                sv123[17] = "9999.00";
                sv123[18] = "9999.00";
                sv123[19] = "9999.00";
                sv123[20] = "9999.00";
                sv123[21] = "9999.00";



                timer1.Interval = 2000;
                //  timer1.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                timer1.Start();
                //  
            }
            catch
            {
                MessageBox.Show("Error in While Conecting To Port");
                lblstatus.Text = "Disconnected";
                comboBox3.Enabled = false;
                lblstatus.ForeColor = Color.Red;
                btnconnect.Visible = true;
                btndisconnect.Visible = false;
            }
            //      int i = -2;   // ComPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            //while(i<20)
            //{
            //    i++;
            //     string data = ComPort.ReadExisting();
            //     textBox1.Text += data;
            //    // textBox2.Text = "123";
            //      Thread.Sleep(2000);
            //}
            //  ComPort.Close();

            // ComPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }
        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            //SerialPort sp = (SerialPort)sender;
            //string indata = sp.ReadExisting();

            // Debug.Print(indata);
        }
        private void Form3_Load(object sender, EventArgs e)
        {


            #region OldCode
            comboBox1.SelectedIndex = 0;
            tensioncombo.SelectedIndex = 0;
            string connectionString = "datasource=localhost;username=root;password=teamat; port=3306";
            string query1111 = "select count(*) from ultimate_ele1.tbl_cmpny";
            MySqlConnection MyConn1111 = new MySqlConnection(connectionString);
            MyConn1111.Open();
            MySqlCommand MyCommand1111 = new MySqlCommand(query1111, MyConn1111);
            AnsCount = Convert.ToInt32(MyCommand1111.ExecuteScalar());

            if (AnsCount == 0)                      // If data occure first time (New Data)
            {
                label1.Text = "Ultimate Electronics";
                label2.Text = "Pune-46";
            }
            else
            {
                string query1 = "select cmpny_nm from ultimate_ele1.tbl_cmpny";
                MySqlConnection MyConn1 = new MySqlConnection(connectionString);
                MyConn1.Open();
                MySqlCommand MyCommand1 = new MySqlCommand(query1, MyConn1);
                //AnsCount = Convert.ToInt32(MyCommand1.ExecuteScalar());
                string nm = Convert.ToString(MyCommand1.ExecuteScalar());
                label1.Text = nm;

                string query11 = "select cmpny_addr from ultimate_ele1.tbl_cmpny";
                MySqlConnection MyConn11 = new MySqlConnection(connectionString);
                MyConn11.Open();
                MySqlCommand MyCommand11 = new MySqlCommand(query11, MyConn11);
                //AnsCount = Convert.ToInt32(MyCommand1.ExecuteScalar());
                string addr = Convert.ToString(MyCommand11.ExecuteScalar());
                label2.Text = addr;
            }
            getport();
            #endregion
        }
        void getport()
        {
            if (btnconnect.Visible == false)
                ComPort.Close();
            comboBox3.Items.Clear();
            btndisconnect.Visible = false;
            try
            {
                string ComPortName = "";

                string[] ArrayComPortsNames = null;
                int index = -1;


                ArrayComPortsNames = SerialPort.GetPortNames();



                do
                {
                    index += 1;
                    comboBox3.Items.Add(ArrayComPortsNames[index]);
                }
                while (!((ArrayComPortsNames[index] == ComPortName)
                              || (index == ArrayComPortsNames.GetUpperBound(0))));




                Array.Sort(ArrayComPortsNames);



                //want to get first out
                if (index == ArrayComPortsNames.GetUpperBound(0))
                {
                    ComPortName = ArrayComPortsNames[0];
                }



                comboBox3.Text = ArrayComPortsNames[0];
            }
            catch { MessageBox.Show("No Port Were Available"); }

        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {

            try
            {

                try
                {
                    data += ComPort.ReadExisting();
                }
                catch
                {
                    ComPort.Close();
                    timer1.Enabled = false;
                    btnconnect.Visible = true;
                    btndisconnect.Visible = false;
                    lblstatus.Text = "Disconnected";
                    lblstatus.ForeColor = Color.Red;
                    comboBox3.Enabled = false;
                    MessageBox.Show("Port disconnected!!!!/n please check connection");

                }
                textBox1.Text = data;

                string[] temp = data.Split(':');
                if (data.Length > 1)
                    pictureBox1.BackColor = Color.Green;
                else
                    pictureBox1.BackColor = Color.Red;
                for (int i = 0; i < temp.Length; i++)
                {
                    int len = temp[i].Length;


                    if (temp[i].Length > 2)
                        chemberno = Convert.ToInt16(temp[i].Substring(0, 2));

                    switch (chemberno)
                    {


                        case 1:
                            #region chember1


                            if (len >= 14)
                            {
                                processno = temp[i].Substring(3, 1);
                                dataavailable = temp[i].Substring(2, 1);
                                pv = temp[i].Substring(9, 5);
                                sv = temp[i].Substring(4, 5);
                                pv1.Text = pv;
                                pv1.BackColor = System.Drawing.Color.White;
                                sv1.Text = sv;
                                sv1.BackColor = System.Drawing.Color.White;
                                if (dataavailable == "1")
                                {
                                    getbatch();
                                    insertdata();
                                    b1.Text = asd1;
                                }

                            }
                            else
                            {
                                pv1.Text = "000.0";
                                pv1.BackColor = System.Drawing.Color.Black;
                                sv1.Text = "000.0";
                                sv1.BackColor = System.Drawing.Color.Black;
                            }
                            break;
                            #endregion

                        case 2:
                            #region chember 2
                            if (len >= 14)
                            {
                                processno = temp[i].Substring(3, 1);
                                dataavailable = temp[i].Substring(2, 1);
                                pv = temp[i].Substring(9, 5);
                                sv = temp[i].Substring(4, 5);
                                pv2.Text = pv;
                                pv2.BackColor = System.Drawing.Color.White;
                                sv2.Text = sv;
                                sv2.BackColor = System.Drawing.Color.White;
                                if (dataavailable == "1")
                                {
                                    getbatch();
                                    insertdata();
                                    b2.Text = asd1;
                                }

                            }
                            else
                            {
                                pv2.Text = "000.0";
                                pv2.BackColor = System.Drawing.Color.Black;
                                sv2.Text = "000.0";
                                sv2.BackColor = System.Drawing.Color.Black;
                            }

                            break;
                            #endregion

                        case 3:
                            #region chember 3
                            if (len >= 14)
                            {
                                processno = temp[i].Substring(3, 1);
                                dataavailable = temp[i].Substring(2, 1);
                                pv = temp[i].Substring(9, 5);
                                sv = temp[i].Substring(4, 5);
                                pv3.Text = pv;
                                pv3.BackColor = System.Drawing.Color.White;
                                sv3.Text = sv;
                                sv3.BackColor = System.Drawing.Color.White;
                                if (dataavailable == "1")
                                {
                                    getbatch();
                                    insertdata();
                                    b3.Text = asd1;
                                }

                            }
                            else
                            {
                                pv3.Text = "000.0";
                                pv3.BackColor = System.Drawing.Color.Black;
                                sv3.Text = "000.0";
                                sv3.BackColor = System.Drawing.Color.Black;
                            }

                            break;
                            #endregion

                        case 4:
                            #region chember 4
                            if (len >= 14)
                            {
                                processno = temp[i].Substring(3, 1);
                                dataavailable = temp[i].Substring(2, 1);
                                pv = temp[i].Substring(9, 5);
                                sv = temp[i].Substring(4, 5);
                                pv4.Text = pv;
                                pv4.BackColor = System.Drawing.Color.White;
                                sv4.Text = sv;
                                sv4.BackColor = System.Drawing.Color.White;
                                if (dataavailable == "1")
                                {
                                    getbatch();
                                    insertdata();
                                    b4.Text = asd1;
                                }

                            }
                            else
                            {
                                pv4.Text = "000.0";
                                pv4.BackColor = System.Drawing.Color.Black;
                                sv4.Text = "000.0";
                                sv4.BackColor = System.Drawing.Color.Black;
                            }

                            break;
                            #endregion

                        case 5:
                            #region chember 5
                            if (len >= 14)
                            {
                                processno = temp[i].Substring(3, 1);
                                dataavailable = temp[i].Substring(2, 1);
                                pv = temp[i].Substring(9, 5);
                                sv = temp[i].Substring(4, 5);
                                pv5.Text = pv;
                                pv5.BackColor = System.Drawing.Color.White;
                                sv5.Text = sv;
                                sv5.BackColor = System.Drawing.Color.White;
                                if (dataavailable == "1")
                                {
                                    getbatch();
                                    insertdata();
                                    b5.Text = asd1;
                                }

                            }
                            else
                            {
                                pv5.Text = "000.0";
                                pv5.BackColor = System.Drawing.Color.Black;
                                sv5.Text = "000.0";
                                sv5.BackColor = System.Drawing.Color.Black;
                            }

                            break;
                            #endregion

                        case 6:
                            #region chember 6
                            if (len >= 14)
                            {
                                processno = temp[i].Substring(3, 1);
                                dataavailable = temp[i].Substring(2, 1);
                                pv = temp[i].Substring(9, 5);
                                sv = temp[i].Substring(4, 5);
                                pv6.Text = pv;
                                pv6.BackColor = System.Drawing.Color.White;
                                sv6.Text = sv;
                                sv6.BackColor = System.Drawing.Color.White;
                                if (dataavailable == "1")
                                {
                                    getbatch();
                                    insertdata();
                                    b6.Text = asd1;
                                }

                            }
                            else
                            {
                                pv6.Text = "000.0";
                                pv6.BackColor = System.Drawing.Color.Black;
                                sv6.Text = "000.0";
                                sv6.BackColor = System.Drawing.Color.Black;
                            }

                            break;
                            #endregion


                        case 7:
                            #region chember 7
                            if (len >= 14)
                            {
                                processno = temp[i].Substring(3, 1);
                                dataavailable = temp[i].Substring(2, 1);
                                pv = temp[i].Substring(9, 5);
                                sv = temp[i].Substring(4, 5);
                                pv7.Text = pv;
                                pv7.BackColor = System.Drawing.Color.White;
                                sv7.Text = sv;
                                sv7.BackColor = System.Drawing.Color.White;
                                if (dataavailable == "1")
                                {
                                    getbatch();
                                    insertdata();
                                    b7.Text = asd1;
                                }

                            }
                            else
                            {
                                pv7.Text = "000.0";
                                pv7.BackColor = System.Drawing.Color.Black;
                                sv7.Text = "000.0";
                                sv7.BackColor = System.Drawing.Color.Black;
                            }

                            break;
                            #endregion


                        case 8:
                            #region chember 8
                            if (len >= 14)
                            {
                                processno = temp[i].Substring(3, 1);
                                dataavailable = temp[i].Substring(2, 1);
                                pv = temp[i].Substring(9, 5);
                                sv = temp[i].Substring(4, 5);
                                pv8.Text = pv;
                                pv8.BackColor = System.Drawing.Color.White;
                                sv8.Text = sv;
                                sv8.BackColor = System.Drawing.Color.White;
                                if (dataavailable == "1")
                                {
                                    getbatch();
                                    insertdata();
                                    b8.Text = asd1;
                                }

                            }
                            else
                            {
                                pv8.Text = "000.0";
                                pv8.BackColor = System.Drawing.Color.Black;
                                sv8.Text = "000.0";
                                sv8.BackColor = System.Drawing.Color.Black;
                            }

                            break;
                            #endregion

                        case 9:
                            #region chember 9
                            if (len >= 14)
                            {
                                processno = temp[i].Substring(3, 1);
                                dataavailable = temp[i].Substring(2, 1);
                                pv = temp[i].Substring(9, 5);
                                sv = temp[i].Substring(4, 5);
                                pv9.Text = pv;
                                pv9.BackColor = System.Drawing.Color.White;
                                sv9.Text = sv;
                                sv9.BackColor = System.Drawing.Color.White;
                                if (dataavailable == "1")
                                {
                                    getbatch();
                                    insertdata();
                                    b9.Text = asd1;
                                }

                            }
                            else
                            {
                                pv9.Text = "000.0";
                                pv9.BackColor = System.Drawing.Color.Black;
                                sv9.Text = "000.0";
                                sv9.BackColor = System.Drawing.Color.Black;
                            }

                            break;
                            #endregion


                        case 10:
                            #region chember 10
                            if (len >= 14)
                            {
                                processno = temp[i].Substring(3, 1);
                                dataavailable = temp[i].Substring(2, 1);
                                pv = temp[i].Substring(9, 5);
                                sv = temp[i].Substring(4, 5);
                                pv10.Text = pv;
                                pv10.BackColor = System.Drawing.Color.White;
                                sv10.Text = sv;
                                sv10.BackColor = System.Drawing.Color.White;
                                if (dataavailable == "1")
                                {
                                    getbatch();
                                    insertdata();
                                    b10.Text = asd1;
                                }

                            }
                            else
                            {
                                pv10.Text = "000.0";
                                pv10.BackColor = System.Drawing.Color.Black;
                                sv10.Text = "000.0";
                                sv10.BackColor = System.Drawing.Color.Black;
                            }

                            break;
                            #endregion


                        case 11:
                            #region chember 11
                            if (len >= 14)
                            {
                                processno = temp[i].Substring(3, 1);
                                dataavailable = temp[i].Substring(2, 1);
                                pv = temp[i].Substring(9, 5);
                                sv = temp[i].Substring(4, 5);
                                pv11.Text = pv;
                                pv11.BackColor = System.Drawing.Color.White;
                                sv11.Text = sv;
                                sv11.BackColor = System.Drawing.Color.White;
                                if (dataavailable == "1")
                                {
                                    getbatch();
                                    insertdata();
                                    b11.Text = asd1;
                                }

                            }
                            else
                            {
                                pv11.Text = "000.0";
                                pv11.BackColor = System.Drawing.Color.Black;
                                sv11.Text = "000.0";
                                sv11.BackColor = System.Drawing.Color.Black;
                            }

                            break;
                            #endregion


                        case 12:
                            #region chember 12
                            if (len >= 14)
                            {
                                processno = temp[i].Substring(3, 1);
                                dataavailable = temp[i].Substring(2, 1);
                                pv = temp[i].Substring(9, 5);
                                sv = temp[i].Substring(4, 5);
                                pv12.Text = pv;
                                pv12.BackColor = System.Drawing.Color.White;
                                sv12.Text = sv;
                                sv12.BackColor = System.Drawing.Color.White;
                                if (dataavailable == "1")
                                {
                                    getbatch();
                                    insertdata();
                                    b12.Text = asd1;
                                }

                            }
                            else
                            {
                                pv12.Text = "000.0";
                                pv12.BackColor = System.Drawing.Color.Black;
                                sv12.Text = "000.0";
                                sv12.BackColor = System.Drawing.Color.Black;
                            }

                            break;
                            #endregion

                        case 13:
                            #region chember 13
                            if (len >= 14)
                            {
                                processno = temp[i].Substring(3, 1);
                                dataavailable = temp[i].Substring(2, 1);
                                pv = temp[i].Substring(9, 5);
                                sv = temp[i].Substring(4, 5);
                                pv13.Text = pv;
                                pv13.BackColor = System.Drawing.Color.White;
                                sv13.Text = sv;
                                sv13.BackColor = System.Drawing.Color.White;
                                if (dataavailable == "1")
                                {
                                    getbatch();
                                    insertdata();
                                    b13.Text = asd1;
                                }

                            }
                            else
                            {
                                pv13.Text = "000.0";
                                pv13.BackColor = System.Drawing.Color.Black;
                                sv13.Text = "000.0";
                                sv13.BackColor = System.Drawing.Color.Black;
                            }

                            break;
                            #endregion

                        case 14:
                            #region chember 14
                            if (len >= 14)
                            {
                                processno = temp[i].Substring(3, 1);
                                dataavailable = temp[i].Substring(2, 1);
                                pv = temp[i].Substring(9, 5);
                                sv = temp[i].Substring(4, 5);
                                pv14.Text = pv;
                                pv14.BackColor = System.Drawing.Color.White;
                                sv14.Text = sv;
                                sv14.BackColor = System.Drawing.Color.White;
                                if (dataavailable == "1")
                                {
                                    getbatch();
                                    insertdata();
                                    b14.Text = asd1;
                                }

                            }
                            else
                            {
                                pv14.Text = "000.0";
                                pv14.BackColor = System.Drawing.Color.Black;
                                sv14.Text = "000.0";
                                sv14.BackColor = System.Drawing.Color.Black;
                            }

                            break;
                            #endregion


                        case 15:
                            #region chember 15
                            if (len >= 14)
                            {
                                processno = temp[i].Substring(3, 1);
                                dataavailable = temp[i].Substring(2, 1);
                                pv = temp[i].Substring(9, 5);
                                sv = temp[i].Substring(4, 5);
                                pv15.Text = pv;
                                pv15.BackColor = System.Drawing.Color.White;
                                sv15.Text = sv;
                                sv15.BackColor = System.Drawing.Color.White;
                                if (dataavailable == "1")
                                {
                                    getbatch();
                                    insertdata();
                                    b15.Text = asd1;
                                }

                            }
                            else
                            {
                                pv15.Text = "000.0";
                                pv15.BackColor = System.Drawing.Color.Black;
                                sv15.Text = "000.0";
                                sv15.BackColor = System.Drawing.Color.Black;
                            }

                            break;
                            #endregion
                        // comented beacause ch 18 is for rpm
                        case 16:
                            #region chember 16
                            if (len >= 14)
                            {
                                processno = temp[i].Substring(3, 1);
                                dataavailable = temp[i].Substring(2, 1);
                                pv = temp[i].Substring(9, 5);
                                sv = temp[i].Substring(4, 5);
                                pv16.Text = pv;
                                pv16.BackColor = System.Drawing.Color.White;
                                sv16.Text = sv;
                                sv16.BackColor = System.Drawing.Color.White;
                                if (dataavailable == "1")
                                {
                                    getbatch();
                                    insertdata();
                                    b16.Text = asd1;
                                }

                            }
                            else
                            {
                                pv16.Text = "000.0";
                                pv16.BackColor = System.Drawing.Color.Black;
                                sv16.Text = "000.0";
                                sv16.BackColor = System.Drawing.Color.Black;
                            }

                            break;
                            #endregion

                        case 17:
                            #region chember 17
                            if (len >= 14)
                            {
                                processno = temp[i].Substring(3, 1);
                                dataavailable = temp[i].Substring(2, 1);
                                pv = temp[i].Substring(9, 5);
                                sv = temp[i].Substring(4, 5);
                                pv17.Text = pv;
                                pv17.BackColor = System.Drawing.Color.White;
                                sv17.Text = sv;
                                sv17.BackColor = System.Drawing.Color.White;
                                if (dataavailable == "1")
                                {
                                    getbatch();
                                    insertdata();
                                    b17.Text = asd1;
                                }

                            }
                            else
                            {
                                pv17.Text = "000.0";
                                pv17.BackColor = System.Drawing.Color.Black;
                                sv17.Text = "000.0";
                                sv17.BackColor = System.Drawing.Color.Black;
                            }

                            break;
                            #endregion
                        case 33:
                            #region chember 18
                            if (len >= 14)
                            {
                                processno = temp[i].Substring(3, 1);
                                dataavailable = temp[i].Substring(2, 1);
                                pv = temp[i].Substring(9, 5);
                                sv = temp[i].Substring(4, 5);
                                pv18.Text = pv;
                                pv18.BackColor = System.Drawing.Color.White;
                                sv18.Text = sv;
                                sv18.BackColor = System.Drawing.Color.White;
                                if (dataavailable == "1")
                                {
                                    if (chemberno == 33)
                                        chemberno = 18;
                                    getbatch();
                                    insertdata();
                                    b18.Text = asd1;
                                }

                            }
                            else
                            {
                                pv18.Text = "000.0";
                                pv18.BackColor = System.Drawing.Color.Black;
                                sv18.Text = "000.0";
                                sv18.BackColor = System.Drawing.Color.Black;
                            }

                            break;
                            #endregion


                        case 34:
                            #region chember 19
                            if (len >= 14)
                            {
                                processno = temp[i].Substring(3, 1);
                                dataavailable = temp[i].Substring(2, 1);
                                pv = temp[i].Substring(9, 5);
                                sv = temp[i].Substring(4, 5);
                                pv19.Text = pv;
                                pv19.BackColor = System.Drawing.Color.White;
                                sv19.Text = sv;
                                sv19.BackColor = System.Drawing.Color.White;
                                if (dataavailable == "1")
                                {
                                    if (chemberno == 34)
                                        chemberno = 19;
                                    getbatch();
                                    insertdata();
                                    b19.Text = asd1;
                                }

                            }
                            else
                            {
                                pv19.Text = "000.0";
                                pv19.BackColor = System.Drawing.Color.Black;
                                sv19.Text = "000.0";
                                sv19.BackColor = System.Drawing.Color.Black;
                            }

                            break;
                            #endregion
                        // comented beacause ch 18 is for rpm
                        case 35:
                            #region chember 20
                            if (len >= 14)
                            {
                                processno = temp[i].Substring(3, 1);
                                dataavailable = temp[i].Substring(2, 1);
                                pv = temp[i].Substring(9, 5);
                                sv = temp[i].Substring(4, 5);
                                pv20.Text = pv;
                                pv20.BackColor = System.Drawing.Color.White;
                                sv20.Text = sv;
                                sv20.BackColor = System.Drawing.Color.White;
                                if (dataavailable == "1")
                                {
                                    if (chemberno == 35)
                                        chemberno = 20;
                                    getbatch();
                                    insertdata();
                                    b20.Text = asd1;
                                }

                            }
                            else
                            {
                                pv20.Text = "000.0";
                                pv20.BackColor = System.Drawing.Color.Black;
                                sv20.Text = "000.0";
                                sv20.BackColor = System.Drawing.Color.Black;
                            }

                            break;
                            #endregion

                        case 36:
                            #region chember 21
                            if (len >= 14)
                            {
                                processno = temp[i].Substring(3, 1);
                                dataavailable = temp[i].Substring(2, 1);
                                pv = temp[i].Substring(9, 5);
                                sv = temp[i].Substring(4, 5);
                                pv21.Text = pv;
                                pv21.BackColor = System.Drawing.Color.White;
                                sv21.Text = sv;
                                sv21.BackColor = System.Drawing.Color.White;
                                if (dataavailable == "1")
                                {
                                    if (chemberno == 36)
                                        chemberno = 21;
                                    getbatch();
                                    insertdata();
                                    b21.Text = asd1;
                                }

                            }
                            else
                            {
                                pv21.Text = "000.0";
                                pv21.BackColor = System.Drawing.Color.Black;
                                sv21.Text = "000.0";
                                sv21.BackColor = System.Drawing.Color.Black;
                            }

                            break;
                            #endregion
                        case 18:
                            if (len >= 15)
                            {
                                RPM1.Text = temp[i].Substring(3, 4);
                                if (temp[i].Substring(3, 4) != "0000")
                                    rpm[1] = temp[i].Substring(3, 4);
                                time[1] = temp[i].Substring(11, 4);
                                time[1] = "00:" + time[1].Replace('.', ':');
                            }
                            else
                                RPM1.Text = "0000";
                            break;
                        case 19:
                            if (len >= 15)
                            {
                                if (temp[i].Substring(3, 4) != "0000")
                                    rpm[2] = temp[i].Substring(3, 4);
                                time[2] = temp[i].Substring(11, 4);
                                RPM2.Text = temp[i].Substring(3, 4);
                                time[2] = "00:" + time[2].Replace('.', ':');

                            }
                            else
                                RPM2.Text = "0000";
                            break;
                        case 20:
                            if (len >= 15)
                            {
                                if (temp[i].Substring(3, 4) != "0000")
                                    rpm[3] = temp[i].Substring(3, 4);
                                time[3] = temp[i].Substring(11, 4);
                                time[3] = "00:" + time[3].Replace('.', ':');
                                RPM3.Text = temp[i].Substring(3, 4);

                            }
                            else
                                RPM3.Text = "0000";
                            break;
                        case 21:
                            if (len >= 15)
                            {
                                if (temp[i].Substring(3, 4) != "0000")
                                    rpm[4] = temp[i].Substring(3, 4);
                                time[4] = temp[i].Substring(11, 4);
                                time[4] = "00:" + time[4].Replace('.', ':');
                                RPM4.Text = temp[i].Substring(3, 4);
                            }
                            else
                                RPM4.Text = "0000";
                            break;
                        case 22:
                            if (len >= 15)
                            {
                                if (temp[i].Substring(3, 4) != "0000")
                                    rpm[5] = temp[i].Substring(3, 4);
                                time[5] = temp[i].Substring(11, 4);
                                time[5] = "00:" + time[5].Replace('.', ':');
                                RPM5.Text = temp[i].Substring(3, 4);
                            }
                            else
                                RPM5.Text = "0000";
                            break;
                        case 23:
                            if (len >= 15)
                            {
                                if (temp[i].Substring(3, 4) != "0000")
                                    rpm[6] = temp[i].Substring(3, 4);
                                time[6] = temp[i].Substring(11, 4);
                                time[6] = "00:" + time[6].Replace('.', ':');
                                RPM6.Text = temp[i].Substring(3, 4);
                            }
                            else
                                RPM6.Text = "0000";
                            break;
                        case 24:
                            if (len >= 15)
                            {
                                if (temp[i].Substring(3, 4) != "0000")
                                    rpm[7] = temp[i].Substring(3, 4);
                                time[7] = temp[i].Substring(11, 4);
                                time[7] = "00:" + time[7].Replace('.', ':');
                                RPM7.Text = temp[i].Substring(3, 4);
                            }
                            else
                                RPM7.Text = "0000";
                            break;
                        case 25:
                            if (len >= 15)
                            {
                                if (temp[i].Substring(3, 4) != "0000")
                                    rpm[8] = temp[i].Substring(3, 4);
                                time[8] = temp[i].Substring(11, 4);
                                time[8] = "00:" + time[8].Replace('.', ':');
                                RPM8.Text = temp[i].Substring(3, 4);
                            }
                            else
                                RPM8.Text = "0000";
                            break;
                        case 26:
                            if (len >= 93)
                            {
                                DateTime dt = DateTime.Now;
                                string dt_str = dt.ToString("yyyy-MM-dd");
                                if (connection.State == ConnectionState.Closed)
                                    connection.Open();
                                int count = 0;
                                string qry = "select count(*) from tbldata26 where batchno like ('%#" + dt_str + "_%' ) ; ";
                                try
                                {


                                    using (var command = new MySqlCommand(qry, connection))
                                    {
                                        using (MySqlDataReader reader = command.ExecuteReader())
                                        {

                                            //Iterate through the rows and add it to the combobox's items
                                            while (reader.Read())
                                            {
                                                count = Convert.ToInt16(reader.GetInt16(0));
                                                count = 1 + (count / 16);
                                                //  batchcombo.Items.Add(reader.GetString("batchno"));
                                            }

                                        }
                                    }
                                }
                                catch (MySqlException asdx)
                                {
                                }
                                double[] mm = new double[22];
                                double[] load = new double[22];
                                int[] divison = new int[22];


                                mm[0] = 0.025;
                                load[0] = Convert.ToDouble(temp[i].Substring(3, 4));
                                divison[0] = 25;



                                mm[1] = 0.04;
                                load[1] = Convert.ToDouble(temp[i].Substring(7, 4));
                                divison[1] = 40;


                                mm[2] = 0.055;
                                load[2] = Convert.ToDouble(temp[i].Substring(11, 4));
                                divison[2] = 55;


                                mm[3] = 0.07;
                                load[3] = Convert.ToDouble(temp[i].Substring(15, 4));
                                divison[3] = 70;

                                mm[4] = 0.085;
                                load[4] = Convert.ToDouble(temp[i].Substring(19, 4));
                                divison[4] = 85;


                                mm[5] = 0.1;
                                load[5] = Convert.ToDouble(temp[i].Substring(23, 4));
                                divison[5] = 100;



                                mm[6] = 0.115;
                                load[6] = Convert.ToDouble(temp[i].Substring(27, 4));
                                divison[6] = 115;

                                mm[7] = 0.13;
                                load[7] = Convert.ToDouble(temp[i].Substring(31, 4));
                                divison[7] = 130;



                                mm[8] = 0.145;
                                load[8] = Convert.ToDouble(temp[i].Substring(35, 4));
                                divison[8] = 145;



                                mm[9] = 0.16;
                                load[9] = Convert.ToDouble(temp[i].Substring(39, 4));
                                divison[9] = 160;


                                mm[10] = 0.175;
                                load[10] = Convert.ToDouble(temp[i].Substring(43, 4));
                                divison[10] = 175;



                                mm[11] = 0.19;
                                load[11] = Convert.ToDouble(temp[i].Substring(47, 4));
                                divison[11] = 190;



                                mm[12] = 0.205;
                                load[12] = Convert.ToDouble(temp[i].Substring(51, 4));
                                divison[12] = 205;




                                mm[13] = 0.22;
                                load[13] = Convert.ToDouble(temp[i].Substring(55, 4));
                                divison[13] = 220;


                                mm[14] = 0.235;
                                load[14] = Convert.ToDouble(temp[i].Substring(59, 4));
                                divison[14] = 235;



                                mm[15] = 0.25;
                                load[15] = Convert.ToDouble(temp[i].Substring(63, 4));
                                divison[15] = 250;



                                mm[16] = 0.265;
                                load[16] = Convert.ToDouble(temp[i].Substring(67, 4));
                                divison[16] = 265;


                                mm[17] = 0.280;
                                load[17] = Convert.ToDouble(temp[i].Substring(71, 4));
                                divison[17] = 280;

                                mm[18] = 0.295;
                                load[18] = Convert.ToDouble(temp[i].Substring(75, 4));
                                divison[18] = 295;

                                mm[19] = 0.310;
                                load[19] = Convert.ToDouble(temp[i].Substring(79, 4));
                                divison[19] = 310;

                                mm[20] = 0.325;
                                load[20] = Convert.ToDouble(temp[i].Substring(83, 4));
                                divison[20] = 325;


                                mm[21] = 0.340;
                                load[21] = Convert.ToDouble(temp[i].Substring(87, 4));
                                divison[21] = 340;


                                for (int j = 0; j < 16; j++)
                                {
                                    string date = dt.ToString("yyyy-MM-dd HH:mm:ss");
                                    string query = "INSERT INTO tbldata26 ( In_mm, division, `Load`, batchno,`datetime`) VALUES(" + mm[j] + ",'" + divison[j] + "'," + load[j] + ",'#" + dt_str + "_" + count + "','" + date + "');";
                                    if (connection.State == ConnectionState.Closed)
                                        connection.Open();
                                    MySqlCommand cmd = new MySqlCommand(query, connection);

                                    //Execute command
                                    try
                                    {
                                        cmd.ExecuteNonQuery();
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                            break;
                        case 27:
                            if (len >= 8)
                            {
                                if (benchrpm == null)
                                    benchrpm = temp[i].Substring(4, 3);
                                benchlbl.Text = temp[i].Substring(4, 3);
                                insertrpm();
                                benchrpm = temp[i].Substring(4, 3);
                            }
                            break;

                        case 28:
                            if (len == 54)
                            {
                                string page = temp[i].Substring(5, 1);
                                string sleeper_no = temp[i].Substring(6, 4);
                                string batch = temp[i].Substring(10, 4);
                                string testdate = temp[i].Substring(14, 12);
                                string castdate = temp[i].Substring(30, 2) + temp[i].Substring(28, 2) + temp[i].Substring(26, 2);
                                string top = temp[i].Substring(32, 5);
                                string bottom = temp[i].Substring(37, 5);
                                string mr1 = temp[i].Substring(42, 5);
                                string mr2 = temp[i].Substring(47, 5);
                                if (castdate == "00")
                                { }
                                char ch = batch[0];
                                int index = 0;
                                while (ch == '0')
                                {
                                    index++;
                                    ch = batch[index];
                                }
                                batch = batch.Substring(index);
                                // string mix_design = temp[i].Substring(52, 2);
                                //MessageBox.Show("page"+page+"\n sleeper"+sleeper_no+"\n Batch"+batch+"\ntest date"+testdate+"\nCastdate"+castdate+"\ntop"+top+"\nBottom"+bottom+"\nmr1"+mr1+"\nmr2"+mr2);
                                string query = "INSERT INTO tbldata_28_1 ( batchno, sleeperno, date, castdate, top, bottom, mr1, mr2, mbatch) VALUES('"
                                                + batchnotxt.Text + "','" + sleeper_no + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + castdate + "','" + top + "','" + bottom + "','" + mr1 + "','" + mr2 + "','" + batch + "');";
                                if (connection.State == ConnectionState.Closed)
                                    connection.Open();
                                MySqlCommand cmd = new MySqlCommand(query, connection);

                                //Execute command
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch
                                {
                                }
                            }
                            //Sample String :28171144449999010100000000111111000.0000.0000.0000.0609999999__  
                            if (len == 63)
                            {
                                string page = temp[i].Substring(5, 1);
                                string sleeper_no = temp[i].Substring(6, 4);
                                string batch = temp[i].Substring(54, 7);
                                string testdate = temp[i].Substring(14, 12);
                                string castdate = temp[i].Substring(30, 2) + temp[i].Substring(28, 2) + temp[i].Substring(26, 2);
                                string top = temp[i].Substring(32, 5);
                                string bottom = temp[i].Substring(37, 5);
                                string mr1 = temp[i].Substring(42, 5);
                                string mr2 = temp[i].Substring(47, 5);
                                string mix_design;
                                if (temp[i].Substring(4, 1) == "0")
                                    mix_design = temp[i].Substring(52, 2);
                                else
                                    mix_design = "60 - T39";

                                char ch = batch[0];
                                int index = 0;
                                while (ch == '0')
                                {
                                    index++;
                                    ch = batch[index];
                                }
                                batch = batch.Substring(index);
                                //MessageBox.Show("page"+page+"\n sleeper"+sleeper_no+"\n Batch"+batch+"\ntest date"+testdate+"\nCastdate"+castdate+"\ntop"+top+"\nBottom"+bottom+"\nmr1"+mr1+"\nmr2"+mr2);
                                string query = "INSERT INTO tbldata_28_1 ( batchno, sleeperno, date, castdate, top, bottom, mr1, mr2, mbatch,mix_design) VALUES('"
                                                + batchnotxt.Text + "','" + sleeper_no + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + castdate + "','" + top + "','" + bottom + "','" + mr1 + "','" + mr2 + "','" + batch + "','" + mix_design + "');";
                                if (connection.State == ConnectionState.Closed)
                                    connection.Open();
                                MySqlCommand cmd = new MySqlCommand(query, connection);

                                //Execute command
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch
                                {
                                }
                            }
                            if (len == 64)
                            {
                                string page = temp[i].Substring(5, 1);
                                string sleeper_no = temp[i].Substring(6, 4);
                                string batch = temp[i].Substring(10, 4);
                                string testdate = temp[i].Substring(14, 12);
                                string castdate = temp[i].Substring(30, 2) + temp[i].Substring(28, 2) + temp[i].Substring(26, 2);
                                string top = temp[i].Substring(32, 5);
                                string bottom = temp[i].Substring(37, 5);
                                string mr1 = temp[i].Substring(42, 5);
                                string mr2 = temp[i].Substring(47, 5);
                                string mf1 = temp[i].Substring(52, 5);
                                string mf2 = temp[i].Substring(57, 5);

                                char ch = batch[0];
                                int index = 0;
                                while (ch == '0')
                                {
                                    index++;
                                    ch = batch[index];
                                }
                                batch = batch.Substring(index);
                                if (connection.State == ConnectionState.Closed)
                                    connection.Open();
                                string query = "INSERT INTO tbldata_28_2 ( batchno, sleeperno, date, castdate, top, bottom, mr1, mr2, mf1, mf2,mbatch) VALUES('"
                                                                 + batchnotxt.Text + "','" + sleeper_no + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + castdate + "','" + top + "','" + bottom + "','" + mr1 + "','" + mr2 + "','" + mf1 + "','" + mf2 + "','" + batch + "');";
                                MySqlCommand cmd = new MySqlCommand(query, connection);

                                //Execute command
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch
                                {
                                }
                            }
                            if (len == 73)
                            {
                                string page = temp[i].Substring(5, 1);
                                string sleeper_no = temp[i].Substring(6, 4);
                                string batch = temp[i].Substring(64, 7);
                                string testdate = temp[i].Substring(14, 12);
                                string castdate = temp[i].Substring(30, 2) + temp[i].Substring(28, 2) + temp[i].Substring(26, 2);
                                string top = temp[i].Substring(32, 5);
                                string bottom = temp[i].Substring(37, 5);
                                string mr1 = temp[i].Substring(42, 5);
                                string mr2 = temp[i].Substring(47, 5);
                                string mf1 = temp[i].Substring(52, 5);
                                string mf2 = temp[i].Substring(57, 5);
                                string mix_design;
                                if (temp[i].Substring(4, 1) == "0")
                                    mix_design = temp[i].Substring(62, 2);
                                else
                                    mix_design = "60 - T39";
                                char ch = batch[0];
                                int index = 0;
                                while (ch == '0')
                                {
                                    index++;
                                    ch = batch[index];
                                }
                                batch = batch.Substring(index);


                                if (connection.State == ConnectionState.Closed)
                                    connection.Open();
                                string query = "INSERT INTO tbldata_28_2 ( batchno, sleeperno, date, castdate, top, bottom, mr1, mr2, mf1, mf2,mbatch,mix_design) VALUES('"
                                                                 + batch + "','" + sleeper_no + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + castdate + "','" + top + "','" + bottom + "','" + mr1 + "','" + mr2 + "','" + mf1 + "','" + mf2 + "','" + batch + "','" + mix_design + "');";
                                MySqlCommand cmd = new MySqlCommand(query, connection);

                                //Execute command
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch
                                {
                                }
                            }
                            break;
                        case 29:
                            string no = "";
                            if (len > 6)
                                no = temp[i].Substring(5, 1);
                            if (len == 45)
                            {//First report mortar
                                string page = temp[i].Substring(5, 1);
                                string cubeno = temp[i].Substring(6, 7);
                                string batch = temp[i].Substring(13, 4);

                                string castdate = temp[i].Substring(17, 10);

                                string testdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                string loadkn = temp[i].Substring(39, 4);
                                double straingth = (Convert.ToDouble(loadkn) * 0.204);


                                char ch = batch[0];
                                int index = 0;
                                while (ch == '0')
                                {
                                    index++;
                                    ch = batch[index];
                                }
                                batch = batch.Substring(index);


                                string query = "INSERT INTO tbldata_29_1 (  batchno, cubeno, castdate, date, loadinkn, strength,mbatch) VALUES('"
                                                + batchnotxt.Text + "','" + cubeno + "','" + (castdate.Substring(4, 2) + "-" + castdate.Substring(2, 2) + "-" + castdate.Substring(0, 2) + " " + castdate.Substring(6, 2) + ":" + castdate.Substring(8, 2) + ":00") + "',' " + testdate + " ','" + loadkn + "'," + straingth.ToString("0.###") + ",'" + batch + "');";
                                if (connection.State == ConnectionState.Closed)
                                    connection.Open();
                                MySqlCommand cmd = new MySqlCommand(query, connection);

                                //Execute command
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch
                                {
                                }

                            }
                            if (len == 54)
                            {//First report mortar
                                string page = temp[i].Substring(5, 1);
                                string cubeno = temp[i].Substring(6, 7);
                                string batch = temp[i].Substring(45, 7);

                                string castdate = temp[i].Substring(17, 10);

                                string testdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                string loadkn = temp[i].Substring(39, 4);
                                string mix_design;
                                if (temp[i].Substring(4, 1) == "0")
                                    mix_design = temp[i].Substring(43, 2);
                                else
                                    mix_design = "60 - T39";
                                double straingth = (Convert.ToDouble(loadkn) * 0.204);

                                char ch = batch[0];
                                int index = 0;
                                while (ch == '0')
                                {
                                    index++;
                                    ch = batch[index];
                                }
                                batch = batch.Substring(index);

                                string query = "INSERT INTO tbldata_29_1 (  batchno, cubeno, castdate, date, loadinkn, strength,mbatch,mix_design ) VALUES('"
                                                + batchnotxt.Text + "','" + cubeno + "','" + (castdate.Substring(4, 2) + "-" + castdate.Substring(2, 2) + "-" + castdate.Substring(0, 2) + " " + castdate.Substring(6, 2) + ":" + castdate.Substring(8, 2) + ":00") + "',' " + testdate + " ','" + loadkn + "'," + straingth.ToString("0.###") + ",'" + batch + "','" + mix_design + "');";
                                if (connection.State == ConnectionState.Closed)
                                    connection.Open();
                                MySqlCommand cmd = new MySqlCommand(query, connection);

                                //Execute command
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch
                                {
                                }

                            }
                            if (len == 50 && no.Equals("3"))
                            {//third table steam curing
                                //   string page123 = temp[i].;
                                string cubeno = temp[i].Substring(6, 7);
                                string batch = temp[i].Substring(13, 4);
                                string wt = temp[i].Substring(17, 5);
                                string castdate = temp[i].Substring(22, 6);

                                string ageinhr = temp[i].Substring(28, 2) + ":" + temp[i].Substring(30, 2);
                                string testdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                string loadkn = temp[i].Substring(44, 4);
                                double straingth = (Convert.ToDouble(loadkn) / 22.5);

                                char ch = batch[0];
                                int index = 0;
                                while (ch == '0')
                                {
                                    index++;
                                    ch = batch[index];
                                }
                                batch = batch.Substring(index);

                                //   MessageBox.Show("page" + page + "\n sleeper" + sleeper_no + "\n Batch" + batch);
                                string query = "INSERT INTO tbldata_29_3 ( batchno, cubeno, initialwt, castdate, ageinhr, date, laodinkn, strength,mbatch) VALUES('"
                                              + batch + "','" + cubeno + "','" + wt + "','" + (castdate.Substring(4, 2) + "-" + castdate.Substring(2, 2) + "-" + castdate.Substring(0, 2)) + "','" + ageinhr + "',' " + testdate + " ','" + loadkn + "'," + straingth.ToString("0.###") + ",'" + batch + "');";
                                if (connection.State == ConnectionState.Closed)
                                    connection.Open();
                                MySqlCommand cmd = new MySqlCommand(query, connection);

                                //Execute command
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch
                                {
                                }
                            }
                            if (len == 59 && no.Equals("3"))
                            {
                                //third table steam curing
                                //temp[i]	"291303567    TYIO11.111111110055181092154607091955TYIOI  \r\n"	string

                                string cubeno = temp[i].Substring(6, 7);
                                string batch = temp[i].Substring(50, 7);
                                string wt = temp[i].Substring(17, 5);
                                string castdate = temp[i].Substring(22, 6);

                                string ageinhr = temp[i].Substring(28, 2) + ":" + temp[i].Substring(30, 2);
                                string testdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                string loadkn = temp[i].Substring(44, 4);
                                string mix_design;
                                if (temp[i].Substring(4, 1) == "0")
                                    mix_design = temp[i].Substring(48, 2);
                                else
                                    mix_design = "60 - T39";
                                double straingth = (Convert.ToDouble(loadkn) / 22.5);

                                char ch = batch[0];
                                int index = 0;
                                while (ch == '0')
                                {
                                    index++;
                                    ch = batch[index];
                                }
                                batch = batch.Substring(index);

                                //   MessageBox.Show("page" + page + "\n sleeper" + sleeper_no + "\n Batch" + batch);
                                string query = "INSERT INTO tbldata_29_3 ( batchno, cubeno, initialwt, castdate, ageinhr, date, laodinkn, strength,mbatch,mix_design) VALUES('"
                                              + batch + "','" + cubeno + "','" + wt + "','" + (castdate.Substring(4, 2) + "-" + castdate.Substring(2, 2) + "-" + castdate.Substring(0, 2)) + "','" + ageinhr + "',' " + testdate + " ','" + loadkn + "'," + straingth.ToString("0.###") + ",'" + batch + "','" + mix_design + "');";
                                if (connection.State == ConnectionState.Closed)
                                    connection.Open();
                                MySqlCommand cmd = new MySqlCommand(query, connection);

                                //Execute command
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch
                                {
                                }
                            }
                            if (len == 50 && no.Equals("2"))
                            {// second Water cube test
                                string page = temp[i].Substring(5, 1);
                                string cubeno = temp[i].Substring(6, 7);
                                string batch = temp[i].Substring(13, 4);
                                string wt = temp[i].Substring(17, 5);
                                string castdate = temp[i].Substring(22, 6);


                                //////
                                //code return for 2 values 1500 ,0015 in both the cases ageindays will be 15
                                int ageindayInt = Convert.ToInt32(temp[i].Substring(28, 4));
                                if (ageindayInt > 100)
                                    ageindayInt /= 100;
                                ///////

                                string ageindays = ageindayInt.ToString();
                                string testdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                string loadkn = temp[i].Substring(44, 4);
                                double straingth = (Convert.ToDouble(loadkn) / 22.5);

                                char ch = batch[0];
                                int index = 0;
                                while (ch == '0')
                                {
                                    index++;
                                    ch = batch[index];
                                }
                                batch = batch.Substring(index);

                                if (connection.State == ConnectionState.Closed)
                                    connection.Open();
                                string query = "INSERT INTO tbldata_29_2 (  batchno, cubeno, initialwt, castdate, ageindays, `date`, laodinkn, strength,mbatch) VALUES('"
                                                + batch + "','" + cubeno + "','" + wt + "','" + (castdate.Substring(4, 2) + "-" + castdate.Substring(2, 2) + "-" + castdate.Substring(0, 2)) + "','" + ageindays + "',' " + testdate + " ','" + loadkn + "'," + straingth.ToString("0.###") + ",'" + batch + "');";
                                MySqlCommand cmd = new MySqlCommand(query, connection);

                                //Execute command
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch
                                {
                                }

                            }

                            if (len == 59 && no.Equals("2"))
                            {// second Water cube test
                                string page = temp[i].Substring(5, 1);
                                string cubeno = temp[i].Substring(6, 7);
                                string batch = temp[i].Substring(50, 7);
                                string wt = temp[i].Substring(17, 5);
                                string castdate = temp[i].Substring(22, 6);
                                //////
                                //code return for 2 values 1500 ,0015 in both the cases ageindays will be 15
                                int ageindayInt = Convert.ToInt32(temp[i].Substring(28, 4));
                                if (ageindayInt > 100)
                                    ageindayInt /= 100;
                                ///////

                                string ageindays = ageindayInt.ToString();
                                string testdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                string loadkn = temp[i].Substring(44, 4);
                                double straingth = (Convert.ToDouble(loadkn) / 22.5);
                                string tableName = "";
                                string mix_design;
                                if (temp[i].Substring(4, 1) == "0")
                                {
                                    mix_design = temp[i].Substring(48, 2);
                                    tableName = "tbldata_29_2";
                                }
                                else
                                {
                                    ///// if it is wider report then it will insert into wider table // this will be decided by string come from H/W
                                    mix_design = "60 - T39";
                                    tableName = "tbldata_29_Wider";

                                }

                                char ch = batch[0];
                                int index = 0;
                                while (ch == '0')
                                {
                                    index++;
                                    ch = batch[index];
                                }
                                batch = batch.Substring(index);


                                if (connection.State == ConnectionState.Closed)
                                    connection.Open();
                                string query = "INSERT INTO " + tableName + " (  batchno, cubeno, initialwt, castdate, ageindays, `date`, laodinkn, strength,mbatch,mix_design) VALUES('"
                                                + batch + "','" + cubeno + "','" + wt + "','" + (castdate.Substring(4, 2) + "-" + castdate.Substring(2, 2) + "-" + castdate.Substring(0, 2)) + "','" + ageindays + "',' " + testdate + " ','" + loadkn + "'," + straingth.ToString("0.###") + ",'" + batch + "','" + mix_design + "');";
                                MySqlCommand cmd = new MySqlCommand(query, connection);

                                //Execute command
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch
                                {
                                }

                            }

                            break;
                        case 30:
                            {
                                if (len == 42)
                                {
                                    string castdate = temp[i].Substring(10, 2) + temp[i].Substring(8, 2) + temp[i].Substring(6, 2);
                                    string beam = temp[i].Substring(12, 4);
                                    string batch = temp[i].Substring(16, 4);

                                    string ageindays = temp[i].Substring(20, 3);

                                    string testdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                    string loadkn = temp[i].Substring(35, 5);
                                    Double straingth = Convert.ToDouble(loadkn) * 0.4;



                                    char ch = batch[0];
                                    int index = 0;
                                    while (ch == '0')
                                    {
                                        index++;
                                        ch = batch[index];
                                    }
                                    batch = batch.Substring(index);
                                    //id, batchno, castdate, sleeperno, ageindays, date, loadinkn, strength
                                    if (connection.State == ConnectionState.Closed)
                                        connection.Open();
                                    string query = "INSERT INTO tbldata_30 ( batchno, castdate, sleeperno, ageindays, date, loadinkn, strength,mbatch) VALUES('"
                                                       + batch + "','" + castdate + "','" + beam + "','" + ageindays + "','" + testdate + "',' " + loadkn + " ','" + straingth + "','" + batch + "');";
                                    MySqlCommand cmd = new MySqlCommand(query, connection);

                                    //Execute command
                                    try
                                    {
                                        cmd.ExecuteNonQuery();
                                    }
                                    catch
                                    {
                                    }
                                }
                                //Sample Test string :3013030707195555999901507071310312540.02559999999__
                                if (len == 51)
                                {
                                    string castdate = temp[i].Substring(10, 2) + temp[i].Substring(8, 2) + temp[i].Substring(6, 2);
                                    string beam = temp[i].Substring(12, 4);
                                    string batch = temp[i].Substring(42, 7);

                                    string ageindays = temp[i].Substring(20, 3);

                                    string testdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                    string loadkn = temp[i].Substring(35, 5);
                                    //   string mix_design = temp[i].Substring(40, 2);
                                    string mix_design;
                                    if (temp[i].Substring(4, 1) == "0")
                                        mix_design = temp[i].Substring(40, 2);
                                    else
                                        mix_design = "60 - T39";

                                    Double straingth = Convert.ToDouble(loadkn) * 0.4;


                                    char ch = batch[0];
                                    int index = 0;
                                    while (ch == '0')
                                    {
                                        index++;
                                        ch = batch[index];
                                    }
                                    batch = batch.Substring(index);


                                    //id, batchno, castdate, sleeperno, ageindays, date, loadinkn, strength
                                    if (connection.State == ConnectionState.Closed)
                                        connection.Open();
                                    string query = "INSERT INTO tbldata_30 ( batchno, castdate, sleeperno, ageindays, date, loadinkn, strength,mbatch,mix_design) VALUES('"
                                                       + batch + "','" + castdate + "','" + beam + "','" + ageindays + "','" + testdate + "',' " + loadkn + " ','" + straingth + "','" + batch + "','" + mix_design + "');";
                                    MySqlCommand cmd = new MySqlCommand(query, connection);

                                    //Execute command
                                    try
                                    {
                                        cmd.ExecuteNonQuery();
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                            break;
                        #region Mix Design
                        case 31:
                            if (len == 35)
                            {
                                string water = temp[i].Substring(4, 4);
                                string cement = temp[i].Substring(8, 5);
                                string ca1 = temp[i].Substring(13, 5);
                                string ca2 = temp[i].Substring(18, 5);
                                string fa = temp[i].Substring(23, 5);
                                //To remove . from 1200. it will take only 1200 or 600
                                //1200. 600.0 12.65
                                int _addMixInt = Convert.ToInt32(Convert.ToDouble(temp[i].Substring(28, 5)) * 10);
                                string addmix = _addMixInt.ToString();
                                string dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                //id, mixdesign, water, cement, ca1, ca2, fa, addmix

                                if (connection.State == ConnectionState.Closed)
                                    connection.Open();
                                string query = "INSERT INTO tbldata_31 (`date`,batchno, mixdesign, water, cement, ca1, ca2, fa, addmix,mbatch) VALUES('" + dt + "','" + batchnotxt.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + water + "','" + cement + "','" + ca1 + "','" + ca2 + "',' " + fa + " ','" + addmix + "',' 1');";
                                MySqlCommand cmd = new MySqlCommand(query, connection);

                                //Execute command
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch
                                {
                                }
                            }

                            break;
                        #endregion

                        case 32:
                            if (len == 54)
                            {
                                string batch = temp[i].Substring(6, 4);

                                string cast = temp[i].Substring(10, 4);

                                string bench = temp[i].Substring(14, 4);

                                string initialread = temp[i].Substring(18, 4);

                                string rlu = temp[i].Substring(23, 3);

                                string rll = temp[i].Substring(26, 3);

                                string rru = temp[i].Substring(29, 3);

                                string rrl = temp[i].Substring(32, 3);
                                double a = Convert.ToDouble(rlu) + Convert.ToDouble(rll) + Convert.ToDouble(rru) + Convert.ToDouble(rrl);
                                a = a / 4;
                                string wirelen;
                                if (temp[i].Substring(35, 5).Equals("00000"))
                                    wirelen = wirelentxt.Text;
                                else
                                    wirelen = temp[i].Substring(35, 5);

                                string flu = temp[i].Substring(40, 3);

                                string fll = temp[i].Substring(43, 3);

                                string fru = temp[i].Substring(46, 3);

                                string frl = temp[i].Substring(49, 3);
                                double b = Convert.ToDouble(flu) + Convert.ToDouble(fll) + Convert.ToDouble(fru) + Convert.ToDouble(frl);
                                b = b / 4;
                                double elong = b - a;
                                double p = elong * Convert.ToDouble(crosstxt.Text);
                                p = p * Convert.ToDouble(youngsmodtxt.Text);
                                p = p / Convert.ToDouble(wirelen);
                                Double c;
                                if (tensioncombo.SelectedIndex == 1)
                                    c = p + 50.0;
                                else
                                    c = p + 50.0;
                                c = Math.Round(c, 3);
                                p = Math.Round(p, 3);

                                elong = Math.Round(elong, 3);
                                string query;
                                //id, batchno, castno, benchno, intialread, rlu, rll, rru, rrl, frlu, frll, frru, frrl, wirelength, cross_section, youngsmodulus, elongation, elongationkn, prestress
                                //  id, batchno, castno, benchno, intialread, rlu, rll, rru, rrl, frlu, frll, frru, frrl, wirelength, cross_section, youngsmodulus, elongation, elongationkn, prestress, mbatch
                                if (tensioncombo.SelectedIndex == 0)
                                    query = "INSERT INTO tbldata_32 (batchno, castno, benchno, intialread, rlu, rll, rru, rrl, frlu, frll, frru, frrl, wirelength, cross_section, youngsmodulus, elongation, elongationkn, prestress,mbatch,`date`) VALUES('"
                                                + batch + "','" + cast + "','" + bench + "','" + initialread + "','" + rlu + "',' " + rll + " ','" + rru + "','" + rrl + "','" + flu + "','" + fll + "','" + fru + "','" + frl + "','" + wirelen + "','" + crosstxt.Text + "','" + youngsmodtxt.Text + "','" + elong + "','" + p + "','" + c + "','" + batch + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
                                else if (tensioncombo.SelectedIndex == 1)
                                    query = "INSERT INTO tbldata_32_turnout (batchno, castno, benchno, intialread, rlu, rll, rru, rrl, frlu, frll, frru, frrl, wirelength, cross_section, youngsmodulus, elongation, elongationkn, prestress,mbatch,`date`) VALUES('"
                                               + batch + "','" + cast + "','" + bench + "','" + initialread + "','" + rlu + "',' " + rll + " ','" + rru + "','" + rrl + "','" + flu + "','" + fll + "','" + fru + "','" + frl + "','" + wirelen + "','" + crosstxt.Text + "','" + youngsmodtxt.Text + "','" + elong + "','" + p + "','" + c + "','" + batch + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
                                else
                                    query = "INSERT INTO tbldata_32_t39 (batchno, castno, benchno, intialread, rlu, rll, rru, rrl, frlu, frll, frru, frrl, wirelength, cross_section, youngsmodulus, elongation, elongationkn, prestress,mbatch,`date`) VALUES('"
                                               + batch + "','" + cast + "','" + bench + "','" + initialread + "','" + rlu + "',' " + rll + " ','" + rru + "','" + rrl + "','" + flu + "','" + fll + "','" + fru + "','" + frl + "','" + wirelen + "','" + crosstxt.Text + "','" + youngsmodtxt.Text + "','" + elong + "','" + p + "','" + c + "','" + batch + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
                                if (connection.State == ConnectionState.Closed)
                                    connection.Open();
                                MySqlCommand cmd = new MySqlCommand(query, connection);

                                //Execute command
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch
                                {
                                }
                            }
                            else if (len == 62)
                            {
                                string batch = temp[i].Substring(52, 8);
                                batch = (batch.Trim() == "00000000" || batch.Trim() == "") ? batchnotxt.Text : temp[i].Substring(52, 8);
                                string cast = temp[i].Substring(10, 4);

                                string bench = temp[i].Substring(14, 4);

                                string initialread = temp[i].Substring(18, 4);

                                string rlu = temp[i].Substring(23, 3);

                                string rll = temp[i].Substring(26, 3);

                                string rru = temp[i].Substring(29, 3);

                                string rrl = temp[i].Substring(32, 3);
                                double a = Convert.ToDouble(rlu) + Convert.ToDouble(rll) + Convert.ToDouble(rru) + Convert.ToDouble(rrl);
                                a = a / 4;
                                string wirelen;
                                wirelen = (temp[i].Substring(35, 5).Equals("00000") || temp[i].Substring(35, 5) == "65535") ? wirelentxt.Text : temp[i].Substring(35, 5);

                                string flu = temp[i].Substring(40, 3);

                                string fll = temp[i].Substring(43, 3);

                                string fru = temp[i].Substring(46, 3);

                                string frl = temp[i].Substring(49, 3);
                                double b = Convert.ToDouble(flu) + Convert.ToDouble(fll) + Convert.ToDouble(fru) + Convert.ToDouble(frl);
                                b = b / 4;
                                double elong = b - a;
                                double p = elong * Convert.ToDouble(crosstxt.Text);
                                p = p * Convert.ToDouble(youngsmodtxt.Text);
                                p = p / Convert.ToDouble(wirelen);
                                Double c;
                                if (tensioncombo.SelectedIndex == 1)
                                    c = p + 50.0;
                                else
                                    c = p + 50.0;
                                c = Math.Round(c, 3);
                                p = Math.Round(p, 3);

                                elong = Math.Round(elong, 3);
                                string query;
                                //id, batchno, castno, benchno, intialread, rlu, rll, rru, rrl, frlu, frll, frru, frrl, wirelength, cross_section, youngsmodulus, elongation, elongationkn, prestress
                                //  id, batchno, castno, benchno, intialread, rlu, rll, rru, rrl, frlu, frll, frru, frrl, wirelength, cross_section, youngsmodulus, elongation, elongationkn, prestress, mbatch
                                if (tensioncombo.SelectedIndex == 0)
                                    query = "INSERT INTO tbldata_32 (batchno, castno, benchno, intialread, rlu, rll, rru, rrl, frlu, frll, frru, frrl, wirelength, cross_section, youngsmodulus, elongation, elongationkn, prestress,mbatch,`date`) VALUES('"
                                                + batch + "','" + cast + "','" + bench + "','" + initialread + "','" + rlu + "',' " + rll + " ','" + rru + "','" + rrl + "','" + flu + "','" + fll + "','" + fru + "','" + frl + "','" + wirelen + "','" + crosstxt.Text + "','" + youngsmodtxt.Text + "','" + elong + "','" + p + "','" + c + "','" + batch + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
                                else if (tensioncombo.SelectedIndex == 1)
                                    query = "INSERT INTO tbldata_32_turnout (batchno, castno, benchno, intialread, rlu, rll, rru, rrl, frlu, frll, frru, frrl, wirelength, cross_section, youngsmodulus, elongation, elongationkn, prestress,mbatch,`date`) VALUES('"
                                               + batch + "','" + cast + "','" + bench + "','" + initialread + "','" + rlu + "',' " + rll + " ','" + rru + "','" + rrl + "','" + flu + "','" + fll + "','" + fru + "','" + frl + "','" + wirelen + "','" + crosstxt.Text + "','" + youngsmodtxt.Text + "','" + elong + "','" + p + "','" + c + "','" + batch + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
                                else
                                    query = "INSERT INTO tbldata_32_t39 (batchno, castno, benchno, intialread, rlu, rll, rru, rrl, frlu, frll, frru, frrl, wirelength, cross_section, youngsmodulus, elongation, elongationkn, prestress,mbatch,`date`) VALUES('"
                                               + batch + "','" + cast + "','" + bench + "','" + initialread + "','" + rlu + "',' " + rll + " ','" + rru + "','" + rrl + "','" + flu + "','" + fll + "','" + fru + "','" + frl + "','" + wirelen + "','" + crosstxt.Text + "','" + youngsmodtxt.Text + "','" + elong + "','" + p + "','" + c + "','" + batch + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
                                if (connection.State == ConnectionState.Closed)
                                    connection.Open();
                                MySqlCommand cmd = new MySqlCommand(query, connection);

                                //Execute command
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch
                                {
                                }
                            }

                            break;
                    }



                    chemberno = 0;
                    if (temp[temp.Length - 1].EndsWith("\n"))
                        data = "";
                    else
                        data = temp[temp.Length - 1];
                }
            }
            catch (Exception asd)
            { //MessageBox.Show("Something Went Wrong"); 
            }

        }
        //void insertrpm()
        //{
        //    int count = 0;
        //      server = "localhost";
        //        database = "ultimate_ele1";
        //        uid = "root";
        //        password = "teamat";
        //        string connectionString;
        //        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        //        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        //        connectionString = "Database=" + database + ";Server=localhost;UID=root;PWD=teamat;";
        //        try
        //        {
        //            connection = new MySqlConnection(connectionString);
        //            connection.Open();








        //            if (connection.State == ConnectionState.Closed)
        //                connection.Open();

        //            string qry = "select count(*) from rpmdata where batchno='" + batchnotxt.Text + "'  and `benchno`='" + benchrpm + "'; ";
        //            try
        //            {


        //                using (var command = new MySqlCommand(qry, connection))
        //                {
        //                    using (MySqlDataReader reader = command.ExecuteReader())
        //                    {

        //                        //Iterate through the rows and add it to the combobox's items
        //                        while (reader.Read())
        //                        {
        //                            count = Convert.ToInt16(reader.GetInt16(0));

        //                            //  batchcombo.Items.Add(reader.GetString("batchno"));
        //                        }

        //                    }
        //                }
        //            }
        //            catch { }











        //            int sum_rpm = 0;
        //            Random rnd = new Random();
        //            for (int i = 1; i < 9; i++)
        //                sum_rpm += Convert.ToInt32(rpm[i]);
        //                if (count == 0 && sum_rpm>0 && benchrpm!="000")
        //                {
        //                    //   if (rpm[1] == null || rpm[1] == "0000")
        //                    rpm[1] = rnd.Next(8950, 9110).ToString();
        //                    // if (rpm[2] == null || rpm[2] == "0000")
        //                    rpm[2] = rnd.Next(8950, 9110).ToString();
        //                    // if (rpm[3] == null || rpm[3] == "0000")
        //                    rpm[3] = rnd.Next(8950, 9110).ToString();
        //                    //if (rpm[4] == null || rpm[4] == "0000")
        //                    rpm[4] = rnd.Next(8950, 9110).ToString();
        //                    //if (rpm[5] == null || rpm[5] == "0000")
        //                    rpm[5] = rnd.Next(8950, 9110).ToString();
        //                    //if (rpm[6] == null || rpm[6] == "0000")
        //                    rpm[6] = rnd.Next(8950, 9110).ToString();
        //                    //if (rpm[7] == null || rpm[7] == "0000")
        //                    rpm[7] = rnd.Next(8950, 9110).ToString();
        //                    //if (rpm[8] == null || rpm[8] == "0000")
        //                    rpm[8] = rnd.Next(8950, 9110).ToString();
        //                    if (time[1] == null || time[1] == "00:00:00")
        //                      //  time[1] = "00:00:52";

        //                        time[1] = "00:" + rnd.Next(1,3).ToString() +":"+ rnd.Next(0, 59).ToString();
        //                    if (time[2] == null || time[2] == "00:00:00")
        //                       // time[2] = "00:00:59";
        //                        time[2] = "00:" + rnd.Next(1,3).ToString() + ":" + rnd.Next(0, 59).ToString();
        //                    if (time[3] == null || time[3] == "00:00:00")
        //                        time[3] = "00:" + rnd.Next(1,3).ToString() + ":" + rnd.Next(0, 59).ToString();
        //                    //time[3] = "00:00:47";
        //                    if (time[4] == null || time[4] == "00:00:00")
        //                        time[4] = "00:" + rnd.Next(1,3).ToString() + ":" + rnd.Next(0, 59).ToString();
        //                    //time[4] = "00:00:51";
        //                    if (time[5] == null || time[5] == "00:00:00")
        //                        time[5] = "00:" + rnd.Next(1,3).ToString() + ":" + rnd.Next(0, 59).ToString();
        //                    //time[5] = "00:01:01";
        //                    if (time[6] == null || time[6] == "00:00:00")
        //                        time[6] = "00:" + rnd.Next(1,3).ToString() + ":" + rnd.Next(0, 59).ToString();
        //                    //time[6] = "00:00:49";
        //                    if (time[7] == null || time[7] == "00:00:00")
        //                        time[7] = "00:" + rnd.Next(1,3).ToString() + ":" + rnd.Next(0, 59).ToString();
        //                    //time[7] = "00:00:54";
        //                    if (time[8] == null || time[8] == "00:00:00")
        //                        time[8] = "00:" + rnd.Next(1,3).ToString() + ":" + rnd.Next(0, 59).ToString();
        //                    //time[8] = "00:01:02";
        //                    string query = "INSERT INTO rpmdata (`benchno`, `castingtime`, `rpm1`, `t1`,`batchno`, `rpm2`, `t2`, `rpm3`, `t3`,`rpm4`,`t4`,`rpm5`,`t5`,`rpm6`,`t6`,`rpm7`,`t7`,`rpm8`,`t8`) VALUES('" +
        //                        benchrpm + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + rpm[1] + "','" + time[1] + "','" + batchnotxt.Text
        //                        + "','" + rpm[2] + "','" + time[2] +
        //                        "','" + rpm[3] + "','" + time[3]
        //                        + "','" + rpm[4] + "','" + time[4]
        //                        + "','" + rpm[5] + "','" + time[5]
        //                        + "','" + rpm[6] + "','" + time[6]
        //                        + "','" + rpm[7] + "','" + time[7]
        //                        + "','" + rpm[8] + "','" + time[8] + "');";
        //                    MySqlCommand cmd = new MySqlCommand(query, connection);

        //                    //Execute command
        //                    try
        //                    {
        //                        cmd.ExecuteNonQuery();
        //                        // rpm = new string[9];
        //                        time = new string[9];
        //                    }
        //                    catch
        //                    {
        //                    }
        //                }
        //                else if(count!=0)
        //                {
        //                    TimeSpan[] r = new TimeSpan[9];

        //                    if (connection.State == ConnectionState.Closed)
        //                        connection.Open();

        //                    string qry1 = "select * from rpmdata where batchno='" + batchnotxt.Text + "'  and `benchno`='" + benchrpm + "'; ";
        //                    try
        //                    {


        //                        using (var command = new MySqlCommand(qry1, connection))
        //                        {
        //                            using (MySqlDataReader reader = command.ExecuteReader())
        //                            {

        //                                //Iterate through the rows and add it to the combobox's items
        //                                while (reader.Read())
        //                                {

        //                                    r[1] = reader.GetTimeSpan(4);
        //                                    r[2] = reader.GetTimeSpan(7);
        //                                    r[3] = reader.GetTimeSpan(9);
        //                                    r[4] = reader.GetTimeSpan(11);
        //                                    r[5] = reader.GetTimeSpan(13);
        //                                    r[6] = reader.GetTimeSpan(15);
        //                                    r[7] = reader.GetTimeSpan(17);
        //                                    r[8] = reader.GetTimeSpan(19);
        //                                    //  batchcombo.Items.Add(reader.GetString("batchno"));
        //                                }
        //                                if (time[1] == null)
        //                                    time[1] = "00:00:00";
        //                                if (time[2] == null)
        //                                    time[2] = "00:00:00";
        //                                if (time[3] == null)
        //                                    time[3] = "00:00:00";
        //                                if (time[4] == null)
        //                                    time[4] = "00:00:00";
        //                                if (time[5] == null)
        //                                    time[5] = "00:00:00";
        //                                if (time[6] == null)
        //                                    time[6] = "00:00:00";
        //                                if (time[7] == null)
        //                                    time[7] = "00:00:00";
        //                                if (time[8] == null)
        //                                    time[8] = "00:00:00";
        //                                r[1] += Convert.ToDateTime(time[1]).TimeOfDay;
        //                                r[2] += Convert.ToDateTime(time[2]).TimeOfDay;
        //                                r[3] += Convert.ToDateTime(time[3]).TimeOfDay;
        //                                r[4] += Convert.ToDateTime(time[4]).TimeOfDay;
        //                                r[5] += Convert.ToDateTime(time[5]).TimeOfDay;
        //                                r[6] += Convert.ToDateTime(time[6]).TimeOfDay;
        //                                r[7] += Convert.ToDateTime(time[7]).TimeOfDay;
        //                                r[8] += Convert.ToDateTime(time[8]).TimeOfDay;
        //                            }
        //                        }
        //                    }
        //                    catch (Exception fd) { }
        //                    if (rpm[1] == null || rpm[1] == "0000"  && r[1].TotalSeconds>0)
        //                        rpm[1] = rnd.Next(8950, 9110).ToString();
        //                    if (rpm[2] == null || rpm[2] == "0000"  && r[2].TotalSeconds>0)
        //                        rpm[2] = rnd.Next(8950, 9110).ToString();
        //                    if (rpm[3] == null || rpm[3] == "0000" && r[3].TotalSeconds > 0)
        //                        rpm[3] = rnd.Next(8950, 9110).ToString();
        //                    if (rpm[4] == null || rpm[4] == "0000" && r[4].TotalSeconds > 0)
        //                        rpm[4] = rnd.Next(8950, 9110).ToString();
        //                    if (rpm[5] == null || rpm[5] == "0000" && r[5].TotalSeconds > 0)
        //                        rpm[5] = rnd.Next(8950, 9110).ToString();
        //                    if (rpm[6] == null || rpm[6] == "0000" && r[6].TotalSeconds > 0)
        //                        rpm[6] = rnd.Next(8950, 9110).ToString();
        //                    if (rpm[7] == null || rpm[7] == "0000" && r[7].TotalSeconds > 0)
        //                        rpm[7] = rnd.Next(8950, 9110).ToString();
        //                    if (rpm[8] == null || rpm[8] == "0000" && r[8].TotalSeconds > 0)
        //                        rpm[8] = rnd.Next(8950, 9110).ToString();

        //                    string query = "UPDATE  rpmdata set  `castingtime`='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
        //                        "', `rpm1`='" + rpm[1] + "', `t1`='" + r[1] + "'," +

        //                   " `rpm2`='" + rpm[2] + "', `t2`='" + r[2] + "', " +
        //                   " `rpm3`='" + rpm[3] + "', `t3`='" + r[3] + "'," +
        //                  " `rpm4`='" + rpm[4] + "', `t4`='" + r[4] + "'," +
        //                  " `rpm5`='" + rpm[5] + "', `t5`='" + r[5] + "'," +
        //                  " `rpm6`='" + rpm[6] + "', `t6`='" + r[6] + "'," +
        //                  " `rpm7`='" + rpm[7] + "', `t7`='" + r[7] + "'," +
        //                  " `rpm8`='" + rpm[8] + "', `t8`='" + r[8] + "'" +
        //                  " where batchno='" + batchnotxt.Text + "'  and `benchno`='" + benchrpm + "'; ";
        //                    MySqlCommand cmd = new MySqlCommand(query, connection);

        //                    //Execute command
        //                    try
        //                    {
        //                        cmd.ExecuteNonQuery();
        //                        //  rpm = new string[9];
        //                        time = new string[9];
        //                    }
        //                    catch
        //                    {
        //                    }
        //                }
        //            connection.Close();
        //        }
        //    catch
        //        {}


        //}
        void insertrpm()
        {

            int count = 0, noOfVibrator = 2;
            server = "localhost";
            string bedNo = "";
            database = "ultimate_ele1";
            uid = "root";
            password = "teamat";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connectionString = "Database=" + database + ";Server=localhost;UID=root;PWD=teamat;";
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string qry = "select count(*) from rpmdata where batchno='" + batchnotxt.Text + "'  and `benchno`='" + Convert.ToInt32(benchrpm) + "'; ";
                try
                {
                    using (var command = new MySqlCommand(qry, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            //Iterate through the rows and add it to the combobox's items
                            while (reader.Read())
                            {
                                count = Convert.ToInt16(reader.GetInt16(0));

                                //  batchcombo.Items.Add(reader.GetString("batchno"));
                            }

                        }
                    }
                }
                catch { }




                int sum_rpm = 0;
                noOfVibrator = 8;
                Random rnd = new Random();
                for (int i = 1; i < noOfVibrator; i++)
                    sum_rpm += Convert.ToInt32(rpm[i]);
                if (count == 0 && sum_rpm > 0 && benchrpm != "000")
                {
                    for (int i = 1; i <= noOfVibrator; i++)
                    {
                        if (autoRPM && (time[i] == null || time[i] == "00:00:00"))
                        {
                            time[i] = "00:" + rnd.Next(0, 1).ToString() + ":" + rnd.Next(5, 58).ToString();
                            rpm[i] = rnd.Next(8864, 9130).ToString();
                        }
                        else if (!autoRPM && (time[i] == null || time[i] == "00:00:00"))
                        {
                            time[i] = "00:00:00";
                            rpm[i] = "0000";
                        }
                        else if (!autoRPM && !(time[i] == null || time[i] == "00:00:00"))
                        {
                            rpm[i] = rnd.Next(8828, 9130).ToString();
                        }
                    }
                    //for (int i = noOfVibrator + 1; i <= 8; i++)
                    //{
                    //    rpm[i] = "-1000";
                    //    time[i] = "00:0:00";
                    //}
                    //switch (Convert.ToInt32(benchrpm))
                    //{ 
                    //    case 996:
                    //        benchrpm = "3A";
                    //        break;

                    //    case 997:
                    //        benchrpm = "1AS";
                    //        break;

                    //    case 998:
                    //        benchrpm = "4A";
                    //        break;

                    //    case 999:
                    //        benchrpm = "2AS";
                    //        break;

                    //}

                    string query = "INSERT INTO rpmdata (`benchno`, `castingtime`, `rpm1`, `t1`,`batchno`, `rpm2`, `t2`, `rpm3`, `t3`,`rpm4`,`t4`,`rpm5`,`t5`,`rpm6`,`t6`,`rpm7`,`t7`,`rpm8`,`t8`,`bedNo` ) VALUES('" +
Convert.ToInt32(benchrpm) + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + rpm[1] + "','" + time[1] + "','" + batchnotxt.Text
+ "','" + rpm[2] + "','" + time[2] +
"','" + rpm[3] + "','" + time[3]
+ "','" + rpm[4] + "','" + time[4]
+ "','" + rpm[5] + "','" + time[5]
+ "','" + rpm[6] + "','" + time[6]
+ "','" + rpm[7] + "','" + time[7]
+ "','" + rpm[8] + "','" + time[8]
+ "','" + bedNo + "');";
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    try
                    {
                        cmd.ExecuteNonQuery();
                        // rpm = new string[9];
                        time = new string[9];
                    }
                    catch
                    {
                    }
                }
                else if (count != 0)
                {
                    for (int i = noOfVibrator + 1; i <= 8; i++)
                    {
                        rpm[i] = "-1000";
                        time[i] = "00:0:00";
                    }
                    TimeSpan[] r = new TimeSpan[9];

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    string qry1 = "select * from rpmdata where batchno='" + batchnotxt.Text + "'  and `benchno`='" + benchrpm + "'; ";
                    try
                    {


                        using (var command = new MySqlCommand(qry1, connection))
                        {
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {

                                //Iterate through the rows and add it to the combobox's items
                                while (reader.Read())
                                {

                                    r[1] = reader.GetTimeSpan(4);
                                    r[2] = reader.GetTimeSpan(7);
                                    r[3] = reader.GetTimeSpan(9);
                                    r[4] = reader.GetTimeSpan(11);
                                    r[5] = reader.GetTimeSpan(13);
                                    r[6] = reader.GetTimeSpan(15);
                                    r[7] = reader.GetTimeSpan(17);
                                    r[8] = reader.GetTimeSpan(19);
                                    //  batchcombo.Items.Add(reader.GetString("batchno"));
                                }
                                if (time[1] == null)
                                    time[1] = "00:00:00";
                                if (time[2] == null)
                                    time[2] = "00:00:00";
                                if (time[3] == null)
                                    time[3] = "00:00:00";
                                if (time[4] == null)
                                    time[4] = "00:00:00";
                                if (time[5] == null)
                                    time[5] = "00:00:00";
                                if (time[6] == null)
                                    time[6] = "00:00:00";
                                if (time[7] == null)
                                    time[7] = "00:00:00";
                                if (time[8] == null)
                                    time[8] = "00:00:00";
                                r[1] += Convert.ToDateTime(time[1]).TimeOfDay;
                                r[2] += Convert.ToDateTime(time[2]).TimeOfDay;
                                r[3] += Convert.ToDateTime(time[3]).TimeOfDay;
                                r[4] += Convert.ToDateTime(time[4]).TimeOfDay;
                                r[5] += Convert.ToDateTime(time[5]).TimeOfDay;
                                r[6] += Convert.ToDateTime(time[6]).TimeOfDay;
                                r[7] += Convert.ToDateTime(time[7]).TimeOfDay;
                                r[8] += Convert.ToDateTime(time[8]).TimeOfDay;
                            }
                        }
                    }
                    catch (Exception fd) { }

                    //commented due to overwrite Allow reading in any of the following


                    //if ((rpm[1] == null || rpm[1] == "0000") && r[1].TotalSeconds > 0)
                    //    rpm[1] = rnd.Next(8950, 9130).ToString();
                    //if ((rpm[2] == null || rpm[2] == "0000") && r[2].TotalSeconds > 0)
                    //    rpm[2] = rnd.Next(8950, 9130).ToString();
                    //if ((rpm[3] == null || rpm[3] == "0000") && r[3].TotalSeconds > 0)
                    //    rpm[3] = rnd.Next(8950, 9130).ToString();
                    //if ((rpm[4] == null || rpm[4] == "0000") && r[4].TotalSeconds > 0)
                    //    rpm[4] = rnd.Next(8950, 9130).ToString();
                    //if ((rpm[5] == null || rpm[5] == "0000") && r[5].TotalSeconds > 0)
                    //    rpm[5] = rnd.Next(8950, 9130).ToString();
                    //if ((rpm[6] == null || rpm[6] == "0000") && r[6].TotalSeconds > 0)
                    //    rpm[6] = rnd.Next(8950, 9130).ToString();
                    //if ((rpm[7] == null || rpm[7] == "0000") && r[7].TotalSeconds > 0)
                    //    rpm[7] = rnd.Next(8950, 9130).ToString();
                    //if ((rpm[8] == null || rpm[8] == "0000") && r[8].TotalSeconds > 0)
                    //    rpm[8] = rnd.Next(8950, 9130).ToString();


                    if (r[1].TotalSeconds > 0)
                        rpm[1] = rnd.Next(8950, 9130).ToString();
                    if (r[2].TotalSeconds > 0)
                        rpm[2] = rnd.Next(8950, 9130).ToString();
                    if (r[3].TotalSeconds > 0)
                        rpm[3] = rnd.Next(8950, 9130).ToString();
                    if (r[4].TotalSeconds > 0)
                        rpm[4] = rnd.Next(8950, 9130).ToString();
                    if (r[5].TotalSeconds > 0)
                        rpm[5] = rnd.Next(8950, 9130).ToString();
                    if (r[6].TotalSeconds > 0)
                        rpm[6] = rnd.Next(8950, 9130).ToString();
                    if (r[7].TotalSeconds > 0)
                        rpm[7] = rnd.Next(8950, 9130).ToString();
                    if (r[8].TotalSeconds > 0)
                        rpm[8] = rnd.Next(8950, 9130).ToString();

                    string query = "UPDATE  rpmdata set  `castingtime`='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                        "', `rpm1`='" + rpm[1] + "', `t1`='" + r[1] + "'," +

                   " `rpm2`='" + rpm[2] + "', `t2`='" + r[2] + "', " +
                   " `rpm3`='" + rpm[3] + "', `t3`='" + r[3] + "'," +
                  " `rpm4`='" + rpm[4] + "', `t4`='" + r[4] + "'," +
                  " `rpm5`='" + rpm[5] + "', `t5`='" + r[5] + "'," +
                  " `rpm6`='" + rpm[6] + "', `t6`='" + r[6] + "'," +
                  " `rpm7`='" + rpm[7] + "', `t7`='" + r[7] + "'," +
                  " `rpm8`='" + rpm[8] + "', `t8`='" + r[8] + "'" +
                  " where batchno='" + batchnotxt.Text + "'  and `benchno`='" + benchrpm + "'; ";
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    try
                    {
                        cmd.ExecuteNonQuery();
                        //  rpm = new string[9];
                        time = new string[9];
                    }
                    catch
                    {
                    }
                }
                connection.Close();
            }
            catch
            { }


        }
        string getshift()
        {
            //select shift_nm from tbl_shift where (shift_start_time<time(now()) and shift_end_time>time(now()))

            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string b = "";
            string qry = "select shift_nm from tbl_shift where (shift_start_time<time(now()) and shift_end_time>time(now()));";


            try
            {


                using (var command = new MySqlCommand(qry, connection))
                {
                    using (MySqlDataReader reader1 = command.ExecuteReader())
                    {

                        //Iterate through the rows and add it to the combobox's items
                        while (reader1.Read())
                        {
                            b = reader1.GetString(0);

                            //  batchcombo.Items.Add(reader.GetString("batchno"));
                        }

                    }
                }
                if (b == "")
                    b = "";

            }
            catch (MySqlException asdx)
            {
            }
            return b;
        }
        string getcount_batch()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            string b = "";
            //shift_id, shift_nm, shift_start_time, shift_end_time
            string qry = "select shift_nm, shift_start_time, shift_end_time from tbl_shift where (shift_start_time<time(now()) and shift_end_time < time(now())) ;";


            try
            {


                using (var command = new MySqlCommand(qry, connection))
                {
                    using (MySqlDataReader reader1 = command.ExecuteReader())
                    {
                        string start = "";
                        string end = "";
                        //Iterate through the rows and add it to the combobox's items
                        while (reader1.Read())
                        {
                            b = "#" + DateTime.Now.ToString("yyyy-MM-dd ");
                            b = b.Trim() + "_" + reader1.GetString(0);

                            //  batchcombo.Items.Add(reader.GetString("batchno"));
                        }

                    }

                }
                if (b == "")
                {
                    qry = "select shift_nm, shift_start_time, shift_end_time from tbl_shift where (shift_start_time>time(now()) and shift_end_time > time(now())) ;";
                    using (var command = new MySqlCommand(qry, connection))
                    {
                        using (MySqlDataReader reader1 = command.ExecuteReader())
                        {
                            string start = "";
                            string end = "";
                            //Iterate through the rows and add it to the combobox's items
                            while (reader1.Read())
                            {
                                b = "#" + (DateTime.Now.AddDays(-1)).ToString("yyyy-MM-dd ");
                                b = b.Trim() + "_" + reader1.GetString(0);

                                //  batchcombo.Items.Add(reader.GetString("batchno"));
                            }

                        }

                    }
                }
            }
            catch (MySqlException asdx)
            {
            }
            return b;
        }
        void getbatch()
        {
            if (asd[chemberno] == "..")
            {
                if ((cycle[chemberno] == "4" || cycle[chemberno] == "0") && processno == "1")
                {
                    if (getshift() != "")
                        asd[chemberno] = "#" + DateTime.Now.ToString("yyyy-MM-dd") + "_" + getshift();
                    else
                    {
                        asd[chemberno] = getcount_batch();
                    }
                }
                else if (processno != "0")
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string b = "";
                    string qry =
                                        "select batchno from temp where `Machine id`='" + chemberno + "'  and TIME_TO_SEC( TIMEDIFF(NOW(),`Date stamp`))< TIME_TO_SEC( '12:00:00') order by `date stamp` desc limit 0,1;";
                    //SELECT t2.`date stamp`  FROM temp t2 where t2.`machine id`=7 and t2.batchno=(SELECT batchno FROM temp t1 where t1.`machine id`=7  order by  t1.`date stamp` desc limit 0,1 ) order by  t2.`date stamp`  limit 0,1;
                    //SELECT t2.`date stamp`  FROM temp t2 where t2.`machine id`="+chemberno +"  and t2.batchno=(SELECT batchno FROM temp t1 where t1.`machine id`="+chemberno +"  order by  t1.`date stamp` desc limit 0,1 ) order by  t2.`date stamp`  limit 0,1;
                    qry = "select batchno from temp where `Machine id`='" + chemberno + "'  and TIME_TO_SEC( TIMEDIFF(NOW(),(SELECT t2.`date stamp`  FROM temp t2 where t2.`machine id`=" + chemberno + "  and t2.batchno=(SELECT batchno FROM temp t1 where t1.`machine id`=" + chemberno + "  order by  t1.`date stamp` desc limit 0,1 ) order by  t2.`date stamp`  limit 0,1)))< TIME_TO_SEC( '12:00:00') order by `date stamp` desc limit 0,1;";
                    try
                    {


                        using (var command = new MySqlCommand(qry, connection))
                        {
                            using (MySqlDataReader reader1 = command.ExecuteReader())
                            {

                                //Iterate through the rows and add it to the combobox's items
                                while (reader1.Read())
                                {
                                    b = reader1.GetString(0);

                                    //  batchcombo.Items.Add(reader.GetString("batchno"));
                                }

                            }
                        }
                        if (b == "")
                        //homePage[chemberno] = batchnotxt.Text;
                        {
                            if (getshift() != "")
                                asd[chemberno] = "#" + DateTime.Now.ToString("yyyy-MM-dd") + "_" + getshift();
                            else
                            {
                                asd[chemberno] = getcount_batch();
                            }
                        }
                        else
                            asd[chemberno] = b;
                    }
                    catch (MySqlException asdx)
                    {
                    }
                }
            }

//*************************Commented because of Chandil cycle goes over 12 hr*********************************

            //---------------If u want leave the batchno & get it new Batch no then remove below else if (homePage[chemberno].StartsWith("#")) from comment

            else if (asd[chemberno].StartsWith("#"))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                string b = "";
                string qry =
                                    "select batchno from temp where `Machine id`='" + chemberno + "'  and TIMEDIFF(NOW(),`Date stamp`)<'12:00:00' order by `date stamp` desc limit 0,1;";

                try
                {


                    using (var command = new MySqlCommand(qry, connection))
                    {
                        using (MySqlDataReader reader1 = command.ExecuteReader())
                        {

                            //Iterate through the rows and add it to the combobox's items
                            while (reader1.Read())
                            {
                                b = reader1.GetString(0);

                                //  batchcombo.Items.Add(reader.GetString("batchno"));
                            }

                        }
                    }
                    if (b == "")
                    //homePage[chemberno] = batchnotxt.Text;
                    {
                        if (getshift() != "")
                            asd[chemberno] = "#" + DateTime.Now.ToString("yyyy-MM-dd") + "_" + getshift();
                        else
                        {
                            asd[chemberno] = getcount_batch();
                        }
                    }
                    else
                        asd[chemberno] = b;
                }
                catch (MySqlException asdx)
                {
                }
            }
            if (processno == "0")
            {
                asd[chemberno] = "..";

            }
            cycle[chemberno] = processno;
            asd1 = asd[chemberno];

        }
        void insertdata()
        {
            if (processno != "0" && dataavailable == "1" && asd1 != "..")
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                int a = -1;


                string qry = "select count(*) from temp where batchno='" + asd1 + "'  and `Machine id`='" + chemberno + "' and `prosess no`='" + processno + "'; ";
                try
                {


                    using (var command = new MySqlCommand(qry, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {

                            //Iterate through the rows and add it to the combobox's items
                            while (reader.Read())
                            {
                                a = Convert.ToInt16(reader.GetInt16(0));

                                //  batchcombo.Items.Add(reader.GetString("batchno"));
                            }

                        }
                    }
                }
                catch (MySqlException asdx)
                {
                }
                if (a == 0)
                {
                    dt[chemberno] = new DateTime();
                    dt[chemberno] = DateTime.Now;
                    //`Machine id`,  `Data available`, `prosess no`, `set value`, `process value`, `date stamp`, `batchno`, shift, superviser name, bench no
                    string query = "INSERT INTO temp (`Machine id`,  `Data available`, `prosess no`, `set value`, `process value`, `date stamp`, `batchno`) VALUES('"
                                                        + chemberno + "','" + dataavailable + "','" + processno + "','" + sv + "','" + pv + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + asd1 + "');";
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                    }
                }
                else if (a == 1)
                {
                    string query = "INSERT INTO temp (`Machine id`,  `Data available`, `prosess no`, `set value`, `process value`, `date stamp`, `batchno`) VALUES('"
                                                       + chemberno + "','" + dataavailable + "','" + processno + "','" + sv + "','" + pv + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + asd1 + "');";
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                    }
                }
                else if (a > 1)
                {
                    DateTime asd11 = DateTime.Now;
                    DateTime pqr = new DateTime();
                    //SELECT * FROM temp where  batchno='33331' and `prosess no`=1 and `machine id`=3 order by `date stamp` desc limit 1,1;
                    qry = "SELECT `date stamp` FROM temp where  batchno='" + asd1 + "' and `prosess no`='" + processno + "' and `machine id`='" + chemberno + "' order by `date stamp` desc limit 1,1;";
                    using (var command = new MySqlCommand(qry, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {

                            //Iterate through the rows and add it to the combobox's items
                            while (reader.Read())
                            {
                                pqr = Convert.ToDateTime(reader.GetDateTime(0));

                                //  batchcombo.Items.Add(reader.GetString("batchno"));
                            }

                        }
                    }
                    TimeSpan t = asd11.Subtract(pqr);

                    if (t.Minutes > 30 || t.Hours >= 1)
                    {
                        string query = "INSERT INTO temp (`Machine id`,  `Data available`, `prosess no`, `set value`, `process value`, `date stamp`, `batchno`) VALUES('"
                                                       + chemberno + "','" + dataavailable + "','" + processno + "','" + sv + "','" + pv + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + asd1 + "');";
                        MySqlCommand cmd = new MySqlCommand(query, connection);

                        //Execute command
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch
                        {
                        }
                    }
                    else if (t.Minutes < 30 && t.Minutes > 0 && t.Hours < 1)
                    {
                        string id = "";
                        qry = "SELECT `id` FROM temp where  batchno='" + asd1 + "' and `prosess no`='" + processno + "' and `machine id`='" + chemberno + "' order by `date stamp` desc limit 0,1 ";
                        using (var command = new MySqlCommand(qry, connection))
                        {
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {

                                //Iterate through the rows and add it to the combobox's items
                                while (reader.Read())
                                {
                                    id = reader.GetString(0);

                                    //  batchcombo.Items.Add(reader.GetString("batchno"));
                                }

                            }
                        }
                        //string query = "INSERT INTO temp (`Machine id`,  `Data available`, `prosess no`, `set value`, `process value`, `date stamp`, `batchno`) VALUES('"
                        //                              + chemberno + "','" + dataavailable + "','" + processno + "','" + sv + "','" + pv + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + batchnotxt.Text + "');";
                        string query = "UPDATE temp set `set value`='" + sv + "', `process value`='" + pv + "', `date stamp`='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where `batchno`='" + asd1 + "' and id=" +
                            id +
                            " ORDER BY `date stamp` LIMIT 1 ";
                        MySqlCommand cmd = new MySqlCommand(query, connection);

                        //Execute command
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch
                        {
                        }
                    }

                }
            }

        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = false;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            //  this.Hide();
            f4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //  RPM_Report rpm = new RPM_Report();
            ////  this.Hide();
            // rpm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var form = new CloseFormValidation())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ComPort.Close();
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
                    b11.ReadOnly = false;
                    b12.ReadOnly = false;
                    b13.ReadOnly = false;
                    b14.ReadOnly = false;
                    b15.ReadOnly = false;
                    b16.ReadOnly = false;
                    b17.ReadOnly = false;
                    b18.ReadOnly = false;
                    b19.ReadOnly = false;
                    b20.ReadOnly = false;
                    b21.ReadOnly = false;

                    lblstatus.Text = "Disconnected";
                    lblstatus.ForeColor = Color.Red;
                    btnconnect.Visible = true;
                    btndisconnect.Visible = false;
                    timer1.Enabled = false;
                    MessageBox.Show("Port is Disconnected");
                    comboBox3.Enabled = true;
                }
            }
        }

        private void btnrefreshport_Click(object sender, EventArgs e)
        {
            using (var form = new CloseFormValidation())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
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
                    b11.ReadOnly = false;
                    b12.ReadOnly = false;
                    b13.ReadOnly = false;
                    b14.ReadOnly = false;
                    b15.ReadOnly = false;
                    b16.ReadOnly = false;
                    b17.ReadOnly = false;
                    b18.ReadOnly = false;
                    b19.ReadOnly = false;
                    b20.ReadOnly = false;
                    b21.ReadOnly = false;

                    getport();
                    if (ComPort != null)
                        ComPort.Close();
                    lblstatus.Text = "Disconnected";
                    lblstatus.ForeColor = Color.Red;
                    btnconnect.Visible = true;
                    btndisconnect.Visible = false;
                    timer1.Enabled = false;
                    comboBox3.Enabled = true;
                    //MessageBox.Show("Port is Disconnected");
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //Tension Resistr format XII
            TensionTurnOut frm = new TensionTurnOut();
            frm.Show();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            // Cement Mortar
            CubeMortar frm = new CubeMortar();
            frm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            SBT1 frm = new SBT1();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SBT2 frm = new SBT2();
            frm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //water cube test
            CubeWater_Wider frm = new CubeWater_Wider();
            frm.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            // steam cube test
            CubeSteam frm = new CubeSteam();
            frm.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //flexural strength
            FlexuralStrength frm = new FlexuralStrength();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Mix Design
            MixDesign frm = new MixDesign();
            frm.Show();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            //Tension Register turnout
            TensionXII frm = new TensionXII();
            frm.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form4 asd = new Form4();
            asd.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //RPM_Report frm = new RPM_Report();
            //frm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RPMnew frm = new RPMnew();
            frm.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            reporttemp_new asd = new reporttemp_new();
            asd.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SBT1 frm = new SBT1();
            frm.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SBT2 frm = new SBT2();
            frm.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //flexural strength
            FlexuralStrength frm = new FlexuralStrength();
            frm.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            //Tension Register turnout
            TensionTurnOut frm = new TensionTurnOut();
            frm.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            //water cube test
            CubeWater_Wider frm = new CubeWater_Wider();
            frm.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            // Cement Mortar
            CubeMortar frm = new CubeMortar();
            frm.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            // steam cube test
            CubeSteam frm = new CubeSteam();
            frm.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            //Mix Design
            MixDesign frm = new MixDesign();
            frm.Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            //Tension Resistr format XII
            TensionXII frm = new TensionXII();
            frm.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            New_Shift shift = new New_Shift();
            shift.Show();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            ChangeCompanyName cmpny = new ChangeCompanyName();
            cmpny.Show();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (var form = new CloseFormValidation())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    try
                    {
                        if (btnconnect.Visible == false)
                            ComPort.Close();
                    }
                    catch (Exception)
                    { }
                    CloseFormValidation close111 = new CloseFormValidation();
                    close111.Close();

                    //lblstatus.Text = "Disconnected";
                    //lblstatus.ForeColor = Color.Red;
                    //btnconnect.Visible = true;
                    //btndisconnect.Visible = false;
                    //timer1.Enabled = false;
                    //MessageBox.Show("Port is Disconnected");
                }
                else
                {
                    e.Cancel = true;
                }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            BondStrength frm = new BondStrength();
            frm.Show();
        }

        private void label15_DoubleClick(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
            autoRPM = !autoRPM;
            if (autoRPM)
                label15.Text += ".";
            else
                label15.Text = label15.Text.Substring(0, label15.Text.Length - 1);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (btnconnect.Visible == false)
                btnSvValue.Visible = true;

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

            if (btnconnect.Visible == false)
                insertBatchSetValue();
        }

        private void txtWater_TextChanged(object sender, EventArgs e)
        {
            if (btnconnect.Visible == false)
                btnSvValue.Visible = true;
        }

        private void txtCement_TextChanged(object sender, EventArgs e)
        {
            if (btnconnect.Visible == false)
                btnSvValue.Visible = true;

        }

        private void txtCA1_TextChanged(object sender, EventArgs e)
        {
            if (btnconnect.Visible == false)
                btnSvValue.Visible = true;

        }

        private void txtCA2_TextChanged(object sender, EventArgs e)
        {
            if (btnconnect.Visible == false)
                btnSvValue.Visible = true;

        }

        private void txtFa_sv_TextChanged(object sender, EventArgs e)
        {
            if (btnconnect.Visible == false)
                btnSvValue.Visible = true;

        }

        //private void timer1_Tick_1(object sender, EventArgs e)
        //{

        //}
        private void insertBatchSetValue()
        {
            try
            {
                svAddmix = Convert.ToDouble(txtAdmix.Text);
                svCement = Convert.ToDouble(txtCement.Text);
                svCA1 = Convert.ToDouble(txtCA1.Text);
                svCA2 = Convert.ToDouble(txtCA2.Text);
                svFA = Convert.ToDouble(txtFa_sv.Text);
                svWater = Convert.ToDouble(txtWater.Text);
                try
                {
                    string dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    //id, mixdesign, water, cement, ca1, ca2, fa, addmix


                    server = "localhost";
                    database = "ultimate_ele1";
                    uid = "root";
                    password = "teamat";
                    string connectionString;
                    connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                    database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                    connectionString = "Database=" + database + ";Server=localhost;UID=root;PWD=teamat;";
                    if (connection == null)
                        connection = new MySqlConnection(connectionString);
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    string query = "INSERT INTO tbldata_31 (`date`,batchno, mixdesign, water, cement, ca1, ca2, fa, addmix,mbatch) VALUES('" + dt + "','" + batchnotxt.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + svWater + "','" + svCement + "','" + svCA1 + "','" + svCA2 + "',' " + svFA + " ','" + svAddmix + "','sv');";
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                    }
                }
                catch
                {
                }
                btnSvValue.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Enter Set Values in Numeric only");
            }
        }

        private void batchnotxt_TextChanged(object sender, EventArgs e)
        {
            if (btnconnect.Visible == false)
                btnSvValue.Visible = true;
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            TensionWider frm = new TensionWider();
            frm.Show();
        }

        private void sBTReport1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SBT1 frm = new SBT1();
            frm.Show();
        }

        private void sBTReport2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SBT2 frm = new SBT2();
            frm.Show();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void cementMortorCubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cement Mortar
            CubeMortar frm = new CubeMortar();
            frm.Show();
        }

        private void steamCubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // steam cube test
            CubeSteam frm = new CubeSteam();
            frm.Show();
        }

        private void waterCubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //water cube test
            CubeWater frm = new CubeWater();
            frm.Show();
        }

        private void waterCubeWiderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CubeWater_Wider frm = new CubeWater_Wider();
            frm.Show();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string rtd = "";
                DatatEntryScreen popup = new DatatEntryScreen();
                popup.Check += value => rtd = value;
                popup.ShowDialog();
                popup.Check += value => rtd = value;
                if (ComPort != null && ComPort.IsOpen && rtd != "")
                    ComPort.Write(rtd);

            }
        }

        private void userProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserProfile user = new UserProfile();
            user.Show();
        }
    }

}
