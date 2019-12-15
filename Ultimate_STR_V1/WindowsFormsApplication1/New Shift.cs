using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class New_Shift : Form
    {
        public New_Shift()
        {
            InitializeComponent();
        }

        private void New_Shift_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet28.tbl_shift' table. You can move, or remove it, as needed.
            this.tbl_shiftTableAdapter.Fill(this.dataSet28.tbl_shift);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tbl_shiftTableAdapter.Update(this.dataSet28.tbl_shift);
            MessageBox.Show("Shift Updated Succesfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                this.tbl_shiftTableAdapter.Update(this.dataSet28.tbl_shift);
                MessageBox.Show("Row Deleted Successfully");
            }  
            else
                MessageBox.Show("Please Select Row");
        }
    }
}
