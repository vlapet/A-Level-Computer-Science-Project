namespace CardProjectClient.components
{
    partial class SignInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignInForm));
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.pnlSignInControls = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.lblSignInUserCredentialsInfo = new System.Windows.Forms.Label();
            this.linklblCreateAccount = new System.Windows.Forms.LinkLabel();
            this.btnSignInCancel = new System.Windows.Forms.Button();
            this.pnlSignInControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUsername.Location = new System.Drawing.Point(298, 169);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 23);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Location = new System.Drawing.Point(298, 224);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(200, 23);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // btnSignIn
            // 
            this.btnSignIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSignIn.BackColor = System.Drawing.Color.Gray;
            this.btnSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignIn.ForeColor = System.Drawing.Color.White;
            this.btnSignIn.Location = new System.Drawing.Point(413, 284);
            this.btnSignIn.MaximumSize = new System.Drawing.Size(80, 25);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(80, 25);
            this.btnSignIn.TabIndex = 2;
            this.btnSignIn.Text = "Log In";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUsername.AutoSize = true;
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(304, 151);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(60, 15);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username";
            this.lblUsername.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPassword.AutoSize = true;
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(304, 206);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(57, 15);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            this.lblPassword.Click += new System.EventHandler(this.label1_Click);
            // 
            // pnlSignInControls
            // 
            this.pnlSignInControls.BackColor = System.Drawing.Color.Transparent;
            this.pnlSignInControls.Controls.Add(this.btnSettings);
            this.pnlSignInControls.Controls.Add(this.lblSignInUserCredentialsInfo);
            this.pnlSignInControls.Controls.Add(this.linklblCreateAccount);
            this.pnlSignInControls.Controls.Add(this.txtPassword);
            this.pnlSignInControls.Controls.Add(this.lblPassword);
            this.pnlSignInControls.Controls.Add(this.txtUsername);
            this.pnlSignInControls.Controls.Add(this.lblUsername);
            this.pnlSignInControls.Controls.Add(this.btnSignInCancel);
            this.pnlSignInControls.Controls.Add(this.btnSignIn);
            this.pnlSignInControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSignInControls.Location = new System.Drawing.Point(0, 0);
            this.pnlSignInControls.Name = "pnlSignInControls";
            this.pnlSignInControls.Size = new System.Drawing.Size(800, 450);
            this.pnlSignInControls.TabIndex = 3;
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.BackColor = System.Drawing.Color.Gray;
            this.btnSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSettings.BackgroundImage")));
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.ForeColor = System.Drawing.Color.Gray;
            this.btnSettings.Location = new System.Drawing.Point(757, 3);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(40, 40);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // lblSignInUserCredentialsInfo
            // 
            this.lblSignInUserCredentialsInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSignInUserCredentialsInfo.AutoSize = true;
            this.lblSignInUserCredentialsInfo.ForeColor = System.Drawing.Color.Red;
            this.lblSignInUserCredentialsInfo.Location = new System.Drawing.Point(301, 266);
            this.lblSignInUserCredentialsInfo.Name = "lblSignInUserCredentialsInfo";
            this.lblSignInUserCredentialsInfo.Size = new System.Drawing.Size(0, 15);
            this.lblSignInUserCredentialsInfo.TabIndex = 4;
            // 
            // linklblCreateAccount
            // 
            this.linklblCreateAccount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linklblCreateAccount.AutoSize = true;
            this.linklblCreateAccount.Location = new System.Drawing.Point(301, 250);
            this.linklblCreateAccount.Name = "linklblCreateAccount";
            this.linklblCreateAccount.Size = new System.Drawing.Size(170, 15);
            this.linklblCreateAccount.TabIndex = 4;
            this.linklblCreateAccount.TabStop = true;
            this.linklblCreateAccount.Text = "Click here to create an account";
            this.linklblCreateAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblCreateAccount_LinkClicked);
            // 
            // btnSignInCancel
            // 
            this.btnSignInCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSignInCancel.BackColor = System.Drawing.Color.Gray;
            this.btnSignInCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignInCancel.ForeColor = System.Drawing.Color.White;
            this.btnSignInCancel.Location = new System.Drawing.Point(302, 284);
            this.btnSignInCancel.MaximumSize = new System.Drawing.Size(80, 25);
            this.btnSignInCancel.Name = "btnSignInCancel";
            this.btnSignInCancel.Size = new System.Drawing.Size(80, 25);
            this.btnSignInCancel.TabIndex = 3;
            this.btnSignInCancel.Text = "Cancel";
            this.btnSignInCancel.UseVisualStyleBackColor = false;
            this.btnSignInCancel.Click += new System.EventHandler(this.btnSignInCancel_Click);
            // 
            // SignInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlSignInControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SignInForm";
            this.Text = "SignInForm";
            this.pnlSignInControls.ResumeLayout(false);
            this.pnlSignInControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnSignIn;
        private Label lblUsername;
        private Label lblPassword;
        private Panel pnlSignInControls;
        private LinkLabel linklblCreateAccount;
        private Button btnSignInCancel;
        private Label lblSignInUserCredentialsInfo;
        private Button btnSettings;
    }
}