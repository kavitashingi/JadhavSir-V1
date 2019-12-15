using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace WindowsFormsApplication1
{
    public partial class Backup : Form
    {
        public Backup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Radio_Backup.Checked)
            {
                saveFileDialog1.ShowDialog();
            }
            else
            {
                openFileDialog1.ShowDialog();
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
             string sConnectionString = ConfigurationManager.ConnectionStrings["MyConn007"].ConnectionString;
            //string file = "C:\\backup.sql";
            //using (MySqlConnection conn = new MySqlConnection(sConnectionString))
            //{
            //    using (MySqlCommand cmd = new MySqlCommand())
            //    {
            //        using (MySqlBackup mb = new MySqlBackup(cmd))
            //        {
            //            cmd.Connection = conn;
            //            conn.Open();
            //            mb.ExportToFile(file);
            //            conn.Close();
            //        }
            //    }
            //}
        }
    }
}
