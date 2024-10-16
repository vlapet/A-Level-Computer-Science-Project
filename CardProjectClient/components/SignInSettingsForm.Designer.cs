namespace CardProjectClient.components
{
    partial class SignInSettingsForm
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
            this.lblSignInSettingsServerURI = new System.Windows.Forms.Label();
            this.txtBoxSignInSettingsServerURI = new System.Windows.Forms.TextBox();
            this.btnSignInSettingsBack = new System.Windows.Forms.Button();
            this.btnSignInSettingsApply = new System.Windows.Forms.Button();
            this.lblSignInSettingsInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSignInSettingsServerURI
            // 
            this.lblSignInSettingsServerURI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSignInSettingsServerURI.AutoSize = true;
            this.lblSignInSettingsServerURI.ForeColor = System.Drawing.Color.White;
            this.lblSignInSettingsServerURI.Location = new System.Drawing.Point(306, 166);
            this.lblSignInSettingsServerURI.Name = "lblSignInSettingsServerURI";
            this.lblSignInSettingsServerURI.Size = new System.Drawing.Size(89, 15);
            this.lblSignInSettingsServerURI.TabIndex = 0;
            this.lblSignInSettingsServerURI.Text = "Enter server URI";
            // 
            // txtBoxSignInSettingsServerURI
            // 
            this.txtBoxSignInSettingsServerURI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxSignInSettingsServerURI.Location = new System.Drawing.Point(306, 184);
            this.txtBoxSignInSettingsServerURI.Name = "txtBoxSignInSettingsServerURI";
            this.txtBoxSignInSettingsServerURI.Size = new System.Drawing.Size(177, 23);
            this.txtBoxSignInSettingsServerURI.TabIndex = 1;
            // 
            // btnSignInSettingsBack
            // 
            this.btnSignInSettingsBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSignInSettingsBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignInSettingsBack.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSignInSettingsBack.Location = new System.Drawing.Point(308, 236);
            this.btnSignInSettingsBack.Name = "btnSignInSettingsBack";
            this.btnSignInSettingsBack.Size = new System.Drawing.Size(75, 26);
            this.btnSignInSettingsBack.TabIndex = 2;
            this.btnSignInSettingsBack.Text = "Back";
            this.btnSignInSettingsBack.UseVisualStyleBackColor = true;
            this.btnSignInSettingsBack.Click += new System.EventHandler(this.btnSignInSettingsCancel_Click);
            // 
            // btnSignInSettingsApply
            // 
            this.btnSignInSettingsApply.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSignInSettingsApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignInSettingsApply.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSignInSettingsApply.Location = new System.Drawing.Point(408, 236);
            this.btnSignInSettingsApply.Name = "btnSignInSettingsApply";
            this.btnSignInSettingsApply.Size = new System.Drawing.Size(75, 26);
            this.btnSignInSettingsApply.TabIndex = 2;
            this.btnSignInSettingsApply.Text = "Apply";
            this.btnSignInSettingsApply.UseVisualStyleBackColor = true;
            this.btnSignInSettingsApply.Click += new System.EventHandler(this.btnSignInSettingsApply_Click);
            // 
            // lblSignInSettingsInfo
            // 
            this.lblSignInSettingsInfo.AutoSize = true;
            this.lblSignInSettingsInfo.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblSignInSettingsInfo.Location = new System.Drawing.Point(311, 212);
            this.lblSignInSettingsInfo.Name = "lblSignInSettingsInfo";
            this.lblSignInSettingsInfo.Size = new System.Drawing.Size(0, 15);
            this.lblSignInSettingsInfo.TabIndex = 3;
            // 
            // SignInSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSignInSettingsInfo);
            this.Controls.Add(this.btnSignInSettingsApply);
            this.Controls.Add(this.btnSignInSettingsBack);
            this.Controls.Add(this.txtBoxSignInSettingsServerURI);
            this.Controls.Add(this.lblSignInSettingsServerURI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SignInSettingsForm";
            this.Text = "SignInSettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblSignInSettingsServerURI;
        private TextBox txtBoxSignInSettingsServerURI;
        private Button btnSignInSettingsBack;
        private Button btnSignInSettingsApply;
        private Label lblSignInSettingsInfo;
    }
}