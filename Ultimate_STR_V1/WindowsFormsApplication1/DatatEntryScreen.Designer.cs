namespace WindowsFormsApplication1
{
    partial class DatatEntryScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Sbt = new System.Windows.Forms.TextBox();
            this.Cube = new System.Windows.Forms.TextBox();
            this.Beam = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Sbt
            // 
            this.Sbt.Location = new System.Drawing.Point(12, 12);
            this.Sbt.Name = "Sbt";
            this.Sbt.Size = new System.Drawing.Size(100, 20);
            this.Sbt.TabIndex = 0;
            this.Sbt.TextChanged += new System.EventHandler(this.Sbt_TextChanged);
            // 
            // Cube
            // 
            this.Cube.Location = new System.Drawing.Point(12, 38);
            this.Cube.Name = "Cube";
            this.Cube.Size = new System.Drawing.Size(100, 20);
            this.Cube.TabIndex = 1;
            this.Cube.TextChanged += new System.EventHandler(this.Cube_TextChanged);
            // 
            // Beam
            // 
            this.Beam.Location = new System.Drawing.Point(12, 64);
            this.Beam.Name = "Beam";
            this.Beam.Size = new System.Drawing.Size(100, 20);
            this.Beam.TabIndex = 2;
            this.Beam.TextChanged += new System.EventHandler(this.Beam_TextChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(27, 101);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // DatatEntryScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(122, 131);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.Beam);
            this.Controls.Add(this.Cube);
            this.Controls.Add(this.Sbt);
            this.Name = "DatatEntryScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "DatatEntryScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Sbt;
        private System.Windows.Forms.TextBox Cube;
        private System.Windows.Forms.TextBox Beam;
        private System.Windows.Forms.Button btnOk;
    }
}