namespace CardProjectClient.components
{
    partial class MyDetails
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
            this.leftMenuBar1 = new CardProjectClient.components.LeftMenuBar();
            this.btnMyDetailsTopBar = new System.Windows.Forms.Button();
            this.btnMyDetailsDeleteAccount = new System.Windows.Forms.Button();
            this.lblMyDetailsForename = new System.Windows.Forms.Label();
            this.lblMyDetailsSurname = new System.Windows.Forms.Label();
            this.lblMyDetailsUsername = new System.Windows.Forms.Label();
            this.lblMyDetailsPassword = new System.Windows.Forms.Label();
            this.lblMyDetailsDateOfBirth = new System.Windows.Forms.Label();
            this.lblMyDetailsUserID = new System.Windows.Forms.Label();
            this.txtBoxMyDetailsForename = new System.Windows.Forms.TextBox();
            this.txtBoxMyDetailsSurname = new System.Windows.Forms.TextBox();
            this.txtBoxMyDetailsUsername = new System.Windows.Forms.TextBox();
            this.txtBoxMyDetailsPassword = new System.Windows.Forms.TextBox();
            this.txtBoxMyDetailsDateOfBirth = new System.Windows.Forms.TextBox();
            this.txtBoxMyDetailsUserID = new System.Windows.Forms.TextBox();
            this.txtBoxMyDetailsDateOfBirthNew = new System.Windows.Forms.TextBox();
            this.txtBoxMyDetailsPasswordNew = new System.Windows.Forms.TextBox();
            this.txtBoxMyDetailsUsernameNew = new System.Windows.Forms.TextBox();
            this.txtBoxMyDetailsSurnameNew = new System.Windows.Forms.TextBox();
            this.txtBoxMyDetailsForenameNew = new System.Windows.Forms.TextBox();
            this.btnMyDetailsUpdateAccount = new System.Windows.Forms.Button();
            this.lblMyDetailsInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // leftMenuBar1
            // 
            this.leftMenuBar1.BackColor = System.Drawing.Color.DimGray;
            this.leftMenuBar1.CurrentUser = null;
            this.leftMenuBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftMenuBar1.Location = new System.Drawing.Point(0, 30);
            this.leftMenuBar1.Name = "leftMenuBar1";
            this.leftMenuBar1.Size = new System.Drawing.Size(130, 420);
            this.leftMenuBar1.TabIndex = 0;
            this.leftMenuBar1.Load += new System.EventHandler(this.leftMenuBar1_Load);
            // 
            // btnMyDetailsTopBar
            // 
            this.btnMyDetailsTopBar.BackColor = System.Drawing.Color.DimGray;
            this.btnMyDetailsTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMyDetailsTopBar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMyDetailsTopBar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnMyDetailsTopBar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnMyDetailsTopBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyDetailsTopBar.ForeColor = System.Drawing.Color.White;
            this.btnMyDetailsTopBar.Location = new System.Drawing.Point(0, 0);
            this.btnMyDetailsTopBar.Name = "btnMyDetailsTopBar";
            this.btnMyDetailsTopBar.Size = new System.Drawing.Size(800, 30);
            this.btnMyDetailsTopBar.TabIndex = 1;
            this.btnMyDetailsTopBar.TabStop = false;
            this.btnMyDetailsTopBar.Text = "My Details";
            this.btnMyDetailsTopBar.UseVisualStyleBackColor = false;
            this.btnMyDetailsTopBar.Click += new System.EventHandler(this.btnMyDetailsTopBar_Click);
            // 
            // btnMyDetailsDeleteAccount
            // 
            this.btnMyDetailsDeleteAccount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnMyDetailsDeleteAccount.BackColor = System.Drawing.Color.DimGray;
            this.btnMyDetailsDeleteAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyDetailsDeleteAccount.ForeColor = System.Drawing.Color.White;
            this.btnMyDetailsDeleteAccount.Location = new System.Drawing.Point(221, 399);
            this.btnMyDetailsDeleteAccount.Name = "btnMyDetailsDeleteAccount";
            this.btnMyDetailsDeleteAccount.Size = new System.Drawing.Size(153, 39);
            this.btnMyDetailsDeleteAccount.TabIndex = 2;
            this.btnMyDetailsDeleteAccount.Text = "Delete Account";
            this.btnMyDetailsDeleteAccount.UseVisualStyleBackColor = false;
            this.btnMyDetailsDeleteAccount.Click += new System.EventHandler(this.btnMyDetailsDeleteAccount_Click);
            // 
            // lblMyDetailsForename
            // 
            this.lblMyDetailsForename.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMyDetailsForename.AutoSize = true;
            this.lblMyDetailsForename.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMyDetailsForename.ForeColor = System.Drawing.Color.White;
            this.lblMyDetailsForename.Location = new System.Drawing.Point(221, 144);
            this.lblMyDetailsForename.Name = "lblMyDetailsForename";
            this.lblMyDetailsForename.Size = new System.Drawing.Size(81, 17);
            this.lblMyDetailsForename.TabIndex = 3;
            this.lblMyDetailsForename.Text = "Forename:";
            // 
            // lblMyDetailsSurname
            // 
            this.lblMyDetailsSurname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMyDetailsSurname.AutoSize = true;
            this.lblMyDetailsSurname.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMyDetailsSurname.ForeColor = System.Drawing.Color.White;
            this.lblMyDetailsSurname.Location = new System.Drawing.Point(221, 171);
            this.lblMyDetailsSurname.Name = "lblMyDetailsSurname";
            this.lblMyDetailsSurname.Size = new System.Drawing.Size(71, 17);
            this.lblMyDetailsSurname.TabIndex = 4;
            this.lblMyDetailsSurname.Text = "Surname:";
            // 
            // lblMyDetailsUsername
            // 
            this.lblMyDetailsUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMyDetailsUsername.AutoSize = true;
            this.lblMyDetailsUsername.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMyDetailsUsername.ForeColor = System.Drawing.Color.White;
            this.lblMyDetailsUsername.Location = new System.Drawing.Point(221, 199);
            this.lblMyDetailsUsername.Name = "lblMyDetailsUsername";
            this.lblMyDetailsUsername.Size = new System.Drawing.Size(80, 17);
            this.lblMyDetailsUsername.TabIndex = 5;
            this.lblMyDetailsUsername.Text = "Username:";
            // 
            // lblMyDetailsPassword
            // 
            this.lblMyDetailsPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMyDetailsPassword.AutoSize = true;
            this.lblMyDetailsPassword.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMyDetailsPassword.ForeColor = System.Drawing.Color.White;
            this.lblMyDetailsPassword.Location = new System.Drawing.Point(221, 226);
            this.lblMyDetailsPassword.Name = "lblMyDetailsPassword";
            this.lblMyDetailsPassword.Size = new System.Drawing.Size(74, 17);
            this.lblMyDetailsPassword.TabIndex = 6;
            this.lblMyDetailsPassword.Text = "Password:";
            // 
            // lblMyDetailsDateOfBirth
            // 
            this.lblMyDetailsDateOfBirth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMyDetailsDateOfBirth.AutoSize = true;
            this.lblMyDetailsDateOfBirth.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMyDetailsDateOfBirth.ForeColor = System.Drawing.Color.White;
            this.lblMyDetailsDateOfBirth.Location = new System.Drawing.Point(221, 252);
            this.lblMyDetailsDateOfBirth.Name = "lblMyDetailsDateOfBirth";
            this.lblMyDetailsDateOfBirth.Size = new System.Drawing.Size(93, 17);
            this.lblMyDetailsDateOfBirth.TabIndex = 7;
            this.lblMyDetailsDateOfBirth.Text = "Date of Birth:";
            // 
            // lblMyDetailsUserID
            // 
            this.lblMyDetailsUserID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMyDetailsUserID.AutoSize = true;
            this.lblMyDetailsUserID.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMyDetailsUserID.ForeColor = System.Drawing.Color.White;
            this.lblMyDetailsUserID.Location = new System.Drawing.Point(221, 278);
            this.lblMyDetailsUserID.Name = "lblMyDetailsUserID";
            this.lblMyDetailsUserID.Size = new System.Drawing.Size(54, 17);
            this.lblMyDetailsUserID.TabIndex = 8;
            this.lblMyDetailsUserID.Text = "UserID:";
            // 
            // txtBoxMyDetailsForename
            // 
            this.txtBoxMyDetailsForename.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxMyDetailsForename.BackColor = System.Drawing.Color.DarkGray;
            this.txtBoxMyDetailsForename.Location = new System.Drawing.Point(354, 142);
            this.txtBoxMyDetailsForename.Name = "txtBoxMyDetailsForename";
            this.txtBoxMyDetailsForename.Size = new System.Drawing.Size(154, 23);
            this.txtBoxMyDetailsForename.TabIndex = 9;
            // 
            // txtBoxMyDetailsSurname
            // 
            this.txtBoxMyDetailsSurname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxMyDetailsSurname.BackColor = System.Drawing.Color.DarkGray;
            this.txtBoxMyDetailsSurname.Location = new System.Drawing.Point(354, 169);
            this.txtBoxMyDetailsSurname.Name = "txtBoxMyDetailsSurname";
            this.txtBoxMyDetailsSurname.Size = new System.Drawing.Size(154, 23);
            this.txtBoxMyDetailsSurname.TabIndex = 10;
            // 
            // txtBoxMyDetailsUsername
            // 
            this.txtBoxMyDetailsUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxMyDetailsUsername.BackColor = System.Drawing.Color.DarkGray;
            this.txtBoxMyDetailsUsername.Location = new System.Drawing.Point(354, 196);
            this.txtBoxMyDetailsUsername.Name = "txtBoxMyDetailsUsername";
            this.txtBoxMyDetailsUsername.Size = new System.Drawing.Size(154, 23);
            this.txtBoxMyDetailsUsername.TabIndex = 11;
            // 
            // txtBoxMyDetailsPassword
            // 
            this.txtBoxMyDetailsPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxMyDetailsPassword.BackColor = System.Drawing.Color.DarkGray;
            this.txtBoxMyDetailsPassword.Location = new System.Drawing.Point(354, 222);
            this.txtBoxMyDetailsPassword.Name = "txtBoxMyDetailsPassword";
            this.txtBoxMyDetailsPassword.Size = new System.Drawing.Size(154, 23);
            this.txtBoxMyDetailsPassword.TabIndex = 12;
            // 
            // txtBoxMyDetailsDateOfBirth
            // 
            this.txtBoxMyDetailsDateOfBirth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxMyDetailsDateOfBirth.BackColor = System.Drawing.Color.DarkGray;
            this.txtBoxMyDetailsDateOfBirth.Location = new System.Drawing.Point(354, 248);
            this.txtBoxMyDetailsDateOfBirth.Name = "txtBoxMyDetailsDateOfBirth";
            this.txtBoxMyDetailsDateOfBirth.Size = new System.Drawing.Size(154, 23);
            this.txtBoxMyDetailsDateOfBirth.TabIndex = 13;
            // 
            // txtBoxMyDetailsUserID
            // 
            this.txtBoxMyDetailsUserID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxMyDetailsUserID.BackColor = System.Drawing.Color.DarkGray;
            this.txtBoxMyDetailsUserID.Location = new System.Drawing.Point(354, 274);
            this.txtBoxMyDetailsUserID.Name = "txtBoxMyDetailsUserID";
            this.txtBoxMyDetailsUserID.Size = new System.Drawing.Size(154, 23);
            this.txtBoxMyDetailsUserID.TabIndex = 14;
            // 
            // txtBoxMyDetailsDateOfBirthNew
            // 
            this.txtBoxMyDetailsDateOfBirthNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxMyDetailsDateOfBirthNew.BackColor = System.Drawing.Color.DarkGray;
            this.txtBoxMyDetailsDateOfBirthNew.Location = new System.Drawing.Point(533, 248);
            this.txtBoxMyDetailsDateOfBirthNew.Name = "txtBoxMyDetailsDateOfBirthNew";
            this.txtBoxMyDetailsDateOfBirthNew.Size = new System.Drawing.Size(154, 23);
            this.txtBoxMyDetailsDateOfBirthNew.TabIndex = 19;
            // 
            // txtBoxMyDetailsPasswordNew
            // 
            this.txtBoxMyDetailsPasswordNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxMyDetailsPasswordNew.BackColor = System.Drawing.Color.DarkGray;
            this.txtBoxMyDetailsPasswordNew.Location = new System.Drawing.Point(533, 222);
            this.txtBoxMyDetailsPasswordNew.Name = "txtBoxMyDetailsPasswordNew";
            this.txtBoxMyDetailsPasswordNew.Size = new System.Drawing.Size(154, 23);
            this.txtBoxMyDetailsPasswordNew.TabIndex = 18;
            // 
            // txtBoxMyDetailsUsernameNew
            // 
            this.txtBoxMyDetailsUsernameNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxMyDetailsUsernameNew.BackColor = System.Drawing.Color.DarkGray;
            this.txtBoxMyDetailsUsernameNew.Location = new System.Drawing.Point(533, 196);
            this.txtBoxMyDetailsUsernameNew.Name = "txtBoxMyDetailsUsernameNew";
            this.txtBoxMyDetailsUsernameNew.Size = new System.Drawing.Size(154, 23);
            this.txtBoxMyDetailsUsernameNew.TabIndex = 17;
            // 
            // txtBoxMyDetailsSurnameNew
            // 
            this.txtBoxMyDetailsSurnameNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxMyDetailsSurnameNew.BackColor = System.Drawing.Color.DarkGray;
            this.txtBoxMyDetailsSurnameNew.Location = new System.Drawing.Point(533, 169);
            this.txtBoxMyDetailsSurnameNew.Name = "txtBoxMyDetailsSurnameNew";
            this.txtBoxMyDetailsSurnameNew.Size = new System.Drawing.Size(154, 23);
            this.txtBoxMyDetailsSurnameNew.TabIndex = 16;
            // 
            // txtBoxMyDetailsForenameNew
            // 
            this.txtBoxMyDetailsForenameNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxMyDetailsForenameNew.BackColor = System.Drawing.Color.DarkGray;
            this.txtBoxMyDetailsForenameNew.Location = new System.Drawing.Point(533, 142);
            this.txtBoxMyDetailsForenameNew.Name = "txtBoxMyDetailsForenameNew";
            this.txtBoxMyDetailsForenameNew.Size = new System.Drawing.Size(154, 23);
            this.txtBoxMyDetailsForenameNew.TabIndex = 15;
            // 
            // btnMyDetailsUpdateAccount
            // 
            this.btnMyDetailsUpdateAccount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnMyDetailsUpdateAccount.BackColor = System.Drawing.Color.DimGray;
            this.btnMyDetailsUpdateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyDetailsUpdateAccount.ForeColor = System.Drawing.Color.White;
            this.btnMyDetailsUpdateAccount.Location = new System.Drawing.Point(533, 399);
            this.btnMyDetailsUpdateAccount.Name = "btnMyDetailsUpdateAccount";
            this.btnMyDetailsUpdateAccount.Size = new System.Drawing.Size(153, 39);
            this.btnMyDetailsUpdateAccount.TabIndex = 2;
            this.btnMyDetailsUpdateAccount.Text = "Update Account";
            this.btnMyDetailsUpdateAccount.UseVisualStyleBackColor = false;
            this.btnMyDetailsUpdateAccount.Click += new System.EventHandler(this.btnMyDetailsUpdateAccount_Click);
            // 
            // lblMyDetailsInfo
            // 
            this.lblMyDetailsInfo.AutoSize = true;
            this.lblMyDetailsInfo.ForeColor = System.Drawing.Color.Red;
            this.lblMyDetailsInfo.Location = new System.Drawing.Point(356, 315);
            this.lblMyDetailsInfo.Name = "lblMyDetailsInfo";
            this.lblMyDetailsInfo.Size = new System.Drawing.Size(0, 15);
            this.lblMyDetailsInfo.TabIndex = 21;
            // 
            // MyDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMyDetailsInfo);
            this.Controls.Add(this.txtBoxMyDetailsDateOfBirthNew);
            this.Controls.Add(this.txtBoxMyDetailsPasswordNew);
            this.Controls.Add(this.txtBoxMyDetailsUsernameNew);
            this.Controls.Add(this.txtBoxMyDetailsSurnameNew);
            this.Controls.Add(this.txtBoxMyDetailsForenameNew);
            this.Controls.Add(this.txtBoxMyDetailsUserID);
            this.Controls.Add(this.txtBoxMyDetailsDateOfBirth);
            this.Controls.Add(this.txtBoxMyDetailsPassword);
            this.Controls.Add(this.txtBoxMyDetailsUsername);
            this.Controls.Add(this.txtBoxMyDetailsSurname);
            this.Controls.Add(this.txtBoxMyDetailsForename);
            this.Controls.Add(this.lblMyDetailsUserID);
            this.Controls.Add(this.lblMyDetailsDateOfBirth);
            this.Controls.Add(this.lblMyDetailsPassword);
            this.Controls.Add(this.lblMyDetailsUsername);
            this.Controls.Add(this.lblMyDetailsSurname);
            this.Controls.Add(this.lblMyDetailsForename);
            this.Controls.Add(this.btnMyDetailsUpdateAccount);
            this.Controls.Add(this.btnMyDetailsDeleteAccount);
            this.Controls.Add(this.leftMenuBar1);
            this.Controls.Add(this.btnMyDetailsTopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MyDetails";
            this.Text = "MyDetails";
            this.Load += new System.EventHandler(this.MyDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LeftMenuBar leftMenuBar1;
        private Button btnMyDetailsTopBar;
        private Button btnMyDetailsDeleteAccount;
        private Label lblMyDetailsForename;
        private Label lblMyDetailsSurname;
        private Label lblMyDetailsUsername;
        private Label lblMyDetailsPassword;
        private Label lblMyDetailsDateOfBirth;
        private Label lblMyDetailsUserID;
        private TextBox txtBoxMyDetailsForename;
        private TextBox txtBoxMyDetailsSurname;
        private TextBox txtBoxMyDetailsUsername;
        private TextBox txtBoxMyDetailsPassword;
        private TextBox txtBoxMyDetailsDateOfBirth;
        private TextBox txtBoxMyDetailsUserID;
        private TextBox txtBoxMyDetailsDateOfBirthNew;
        private TextBox txtBoxMyDetailsPasswordNew;
        private TextBox txtBoxMyDetailsUsernameNew;
        private TextBox txtBoxMyDetailsSurnameNew;
        private TextBox txtBoxMyDetailsForenameNew;
        private Button btnMyDetailsUpdateAccount;
        private Label lblMyDetailsInfo;
    }
}