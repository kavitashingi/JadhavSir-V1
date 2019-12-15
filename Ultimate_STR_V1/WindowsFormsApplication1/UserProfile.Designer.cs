namespace WindowsFormsApplication1
{
    partial class UserProfile
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
            this.chbSelectAll = new System.Windows.Forms.CheckBox();
            this.chbIsDeveloper = new System.Windows.Forms.CheckBox();
            this.chbShiftChange = new System.Windows.Forms.CheckBox();
            this.chbBondStrength = new System.Windows.Forms.CheckBox();
            this.chbCubeTesting = new System.Windows.Forms.CheckBox();
            this.chbFlexuralStrength = new System.Windows.Forms.CheckBox();
            this.chbSBT = new System.Windows.Forms.CheckBox();
            this.chbTensionRegisterXII = new System.Windows.Forms.CheckBox();
            this.chbTensionRegisterTurnOut = new System.Windows.Forms.CheckBox();
            this.chbTensionRegisterWider = new System.Windows.Forms.CheckBox();
            this.chbTemprature = new System.Windows.Forms.CheckBox();
            this.chbRPMReport = new System.Windows.Forms.CheckBox();
            this.chbMixDesign = new System.Windows.Forms.CheckBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chbSelectAll
            // 
            this.chbSelectAll.AutoSize = true;
            this.chbSelectAll.Location = new System.Drawing.Point(48, 148);
            this.chbSelectAll.Name = "chbSelectAll";
            this.chbSelectAll.Size = new System.Drawing.Size(78, 17);
            this.chbSelectAll.TabIndex = 54;
            this.chbSelectAll.Text = "Select ALL";
            this.chbSelectAll.UseVisualStyleBackColor = true;
            this.chbSelectAll.CheckedChanged += new System.EventHandler(this.chbSelectAll_CheckedChanged);
            // 
            // chbIsDeveloper
            // 
            this.chbIsDeveloper.AutoSize = true;
            this.chbIsDeveloper.Location = new System.Drawing.Point(305, 270);
            this.chbIsDeveloper.Name = "chbIsDeveloper";
            this.chbIsDeveloper.Size = new System.Drawing.Size(82, 17);
            this.chbIsDeveloper.TabIndex = 53;
            this.chbIsDeveloper.Text = "isDeveloper";
            this.chbIsDeveloper.UseVisualStyleBackColor = true;
            // 
            // chbShiftChange
            // 
            this.chbShiftChange.AutoSize = true;
            this.chbShiftChange.Location = new System.Drawing.Point(305, 240);
            this.chbShiftChange.Name = "chbShiftChange";
            this.chbShiftChange.Size = new System.Drawing.Size(87, 17);
            this.chbShiftChange.TabIndex = 52;
            this.chbShiftChange.Text = "Shift Change";
            this.chbShiftChange.UseVisualStyleBackColor = true;
            // 
            // chbBondStrength
            // 
            this.chbBondStrength.AutoSize = true;
            this.chbBondStrength.Location = new System.Drawing.Point(305, 210);
            this.chbBondStrength.Name = "chbBondStrength";
            this.chbBondStrength.Size = new System.Drawing.Size(94, 17);
            this.chbBondStrength.TabIndex = 51;
            this.chbBondStrength.Text = "Bond Strength";
            this.chbBondStrength.UseVisualStyleBackColor = true;
            // 
            // chbCubeTesting
            // 
            this.chbCubeTesting.AutoSize = true;
            this.chbCubeTesting.Location = new System.Drawing.Point(305, 180);
            this.chbCubeTesting.Name = "chbCubeTesting";
            this.chbCubeTesting.Size = new System.Drawing.Size(89, 17);
            this.chbCubeTesting.TabIndex = 50;
            this.chbCubeTesting.Text = "Cube Testing";
            this.chbCubeTesting.UseVisualStyleBackColor = true;
            // 
            // chbFlexuralStrength
            // 
            this.chbFlexuralStrength.AutoSize = true;
            this.chbFlexuralStrength.Location = new System.Drawing.Point(148, 270);
            this.chbFlexuralStrength.Name = "chbFlexuralStrength";
            this.chbFlexuralStrength.Size = new System.Drawing.Size(102, 17);
            this.chbFlexuralStrength.TabIndex = 49;
            this.chbFlexuralStrength.Text = "Flexural Stength";
            this.chbFlexuralStrength.UseVisualStyleBackColor = true;
            // 
            // chbSBT
            // 
            this.chbSBT.AutoSize = true;
            this.chbSBT.Location = new System.Drawing.Point(48, 270);
            this.chbSBT.Name = "chbSBT";
            this.chbSBT.Size = new System.Drawing.Size(47, 17);
            this.chbSBT.TabIndex = 48;
            this.chbSBT.Text = "SBT";
            this.chbSBT.UseVisualStyleBackColor = true;
            // 
            // chbTensionRegisterXII
            // 
            this.chbTensionRegisterXII.AutoSize = true;
            this.chbTensionRegisterXII.Location = new System.Drawing.Point(148, 210);
            this.chbTensionRegisterXII.Name = "chbTensionRegisterXII";
            this.chbTensionRegisterXII.Size = new System.Drawing.Size(122, 17);
            this.chbTensionRegisterXII.TabIndex = 47;
            this.chbTensionRegisterXII.Text = "Tension Register XII";
            this.chbTensionRegisterXII.UseVisualStyleBackColor = true;
            // 
            // chbTensionRegisterTurnOut
            // 
            this.chbTensionRegisterTurnOut.AutoSize = true;
            this.chbTensionRegisterTurnOut.Location = new System.Drawing.Point(148, 180);
            this.chbTensionRegisterTurnOut.Name = "chbTensionRegisterTurnOut";
            this.chbTensionRegisterTurnOut.Size = new System.Drawing.Size(151, 17);
            this.chbTensionRegisterTurnOut.TabIndex = 46;
            this.chbTensionRegisterTurnOut.Text = "Tension Register Turn Out";
            this.chbTensionRegisterTurnOut.UseVisualStyleBackColor = true;
            // 
            // chbTensionRegisterWider
            // 
            this.chbTensionRegisterWider.AutoSize = true;
            this.chbTensionRegisterWider.Location = new System.Drawing.Point(148, 240);
            this.chbTensionRegisterWider.Name = "chbTensionRegisterWider";
            this.chbTensionRegisterWider.Size = new System.Drawing.Size(137, 17);
            this.chbTensionRegisterWider.TabIndex = 45;
            this.chbTensionRegisterWider.Text = "Tension Register Wider";
            this.chbTensionRegisterWider.UseVisualStyleBackColor = true;
            // 
            // chbTemprature
            // 
            this.chbTemprature.AutoSize = true;
            this.chbTemprature.Location = new System.Drawing.Point(48, 240);
            this.chbTemprature.Name = "chbTemprature";
            this.chbTemprature.Size = new System.Drawing.Size(80, 17);
            this.chbTemprature.TabIndex = 44;
            this.chbTemprature.Text = "Temprature";
            this.chbTemprature.UseVisualStyleBackColor = true;
            // 
            // chbRPMReport
            // 
            this.chbRPMReport.AutoSize = true;
            this.chbRPMReport.Location = new System.Drawing.Point(48, 210);
            this.chbRPMReport.Name = "chbRPMReport";
            this.chbRPMReport.Size = new System.Drawing.Size(85, 17);
            this.chbRPMReport.TabIndex = 43;
            this.chbRPMReport.Text = "RPM Report";
            this.chbRPMReport.UseVisualStyleBackColor = true;
            // 
            // chbMixDesign
            // 
            this.chbMixDesign.AutoSize = true;
            this.chbMixDesign.Location = new System.Drawing.Point(48, 180);
            this.chbMixDesign.Name = "chbMixDesign";
            this.chbMixDesign.Size = new System.Drawing.Size(78, 17);
            this.chbMixDesign.TabIndex = 42;
            this.chbMixDesign.Text = "Mix Design";
            this.chbMixDesign.UseVisualStyleBackColor = true;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(228, 125);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(100, 20);
            this.txtConfirmPassword.TabIndex = 41;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(228, 90);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 40;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(228, 55);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 39;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(128, 125);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(91, 13);
            this.lblCompany.TabIndex = 38;
            this.lblCompany.Text = "Confirm Password";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(128, 90);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 37;
            this.lblPassword.Text = "Password";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(128, 55);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(57, 13);
            this.lblUserName.TabIndex = 36;
            this.lblUserName.Text = "UserName";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(195, 303);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 35;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 25);
            this.label1.TabIndex = 34;
            this.label1.Text = "User Registration";
            // 
            // UserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 349);
            this.Controls.Add(this.chbSelectAll);
            this.Controls.Add(this.chbIsDeveloper);
            this.Controls.Add(this.chbShiftChange);
            this.Controls.Add(this.chbBondStrength);
            this.Controls.Add(this.chbCubeTesting);
            this.Controls.Add(this.chbFlexuralStrength);
            this.Controls.Add(this.chbSBT);
            this.Controls.Add(this.chbTensionRegisterXII);
            this.Controls.Add(this.chbTensionRegisterTurnOut);
            this.Controls.Add(this.chbTensionRegisterWider);
            this.Controls.Add(this.chbTemprature);
            this.Controls.Add(this.chbRPMReport);
            this.Controls.Add(this.chbMixDesign);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label1);
            this.Name = "UserProfile";
            this.Text = "UserProfile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbSelectAll;
        private System.Windows.Forms.CheckBox chbIsDeveloper;
        private System.Windows.Forms.CheckBox chbShiftChange;
        private System.Windows.Forms.CheckBox chbBondStrength;
        private System.Windows.Forms.CheckBox chbCubeTesting;
        private System.Windows.Forms.CheckBox chbFlexuralStrength;
        private System.Windows.Forms.CheckBox chbSBT;
        private System.Windows.Forms.CheckBox chbTensionRegisterXII;
        private System.Windows.Forms.CheckBox chbTensionRegisterTurnOut;
        private System.Windows.Forms.CheckBox chbTensionRegisterWider;
        private System.Windows.Forms.CheckBox chbTemprature;
        private System.Windows.Forms.CheckBox chbRPMReport;
        private System.Windows.Forms.CheckBox chbMixDesign;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label1;

    }
}