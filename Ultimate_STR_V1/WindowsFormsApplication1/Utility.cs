using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Utility
    {
        //void getbatch()
        //{
        //    cmbBatchNo.SelectedIndex = -1;
        //    cmbBatchNo.SelectedValue = "";
        //    cmbBatchNo.SelectedText = "";
        //    cmbBatchNo.SelectedItem = "";
        //    cmbBatchNo.Items.Clear();
        //    theDate = dateTimePicker_FS.Value.ToString("yyyy-MM-dd");
        //    server = "localhost";
        //    database = "ultimate_ele1";
        //    uid = "root";
        //    password = "teamat";

        //    connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        //    database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        //    connectionString = "Database=" + database + ";Server=localhost;UID=root;PWD=teamat;";
        //    try
        //    {
        //        connection = new MySqlConnection(connectionString);
        //        connection.Open();
        //        var query = "select distinct (`mbatch`) FROM tbldata_30 where `date` like('" + theDate + "%')  ;";
        //        //MessageBox.Show(query);
        //        using (var command = new MySqlCommand(query, connection))
        //        {
        //            using (var reader = command.ExecuteReader())
        //            {
        //                //Iterate through the rows and add it to the combobox's items
        //                while (reader.Read())
        //                {
        //                    cmbBatchNo.Items.Add(reader.GetString("mbatch"));
        //                }
        //            }
        //        }
        //        if (cmbBatchNo.Items.Count >= 1)
        //            cmbBatchNo.SelectedIndex = 0;
        //        connection.Close();
        //    }
        //    catch (MySqlException ex)
        //    {
        //    }
        //}

    }
}
