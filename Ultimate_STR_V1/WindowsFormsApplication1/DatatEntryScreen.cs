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
    public partial class DatatEntryScreen : Form
    {
        public event Action<string> Check;
        public DatatEntryScreen()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string SendData = "";
            if (Sbt.Text.Length >= 3)
                SendData+="ZS" + Sbt.Text.Substring(0,3) + "#";
            if (Cube.Text.Length >= 3)
                SendData += "ZC" + Cube.Text.Substring(0, 3) + "#";
            if (Beam.Text.Length >= 3)
                SendData += "ZB" + Beam.Text.Substring(0, 3) + "#";
            Check(SendData);
            this.Close();
        }

        private void Sbt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Sbt.Text, "^[a-zA-Z ]") || Sbt.Text.Length>3)
            {
                Sbt.Text = Sbt.Text.Substring(0, Sbt.Text.Length - 1);
            }
        }

        private void Cube_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Cube.Text, "^[a-zA-Z ]") || Cube.Text.Length > 3)
            {
                Cube.Text = Cube.Text.Substring(0, Cube.Text.Length - 1);
            }
        }

        private void Beam_TextChanged(object sender, EventArgs e)
        {
            if ((System.Text.RegularExpressions.Regex.IsMatch(Beam.Text, "^[a-zA-Z ]")) || Beam.Text.Length > 3)
            {
                Beam.Text = Beam.Text.Substring(0, Beam.Text.Length - 1);
            }
        }
    }
}
