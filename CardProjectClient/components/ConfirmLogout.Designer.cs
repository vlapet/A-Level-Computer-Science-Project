namespace CardProjectClient.components
{
    partial class ConfirmLogout
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
            this.btnConfirmLogoutNo = new System.Windows.Forms.Button();
            this.btnConfirmLogoutYes = new System.Windows.Forms.Button();
            this.lblConfirmLogout = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConfirmLogoutNo
            // 
            this.btnConfirmLogoutNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfirmLogoutNo.BackColor = System.Drawing.Color.Gray;
            this.btnConfirmLogoutNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmLogoutNo.ForeColor = System.Drawing.Color.White;
            this.btnConfirmLogoutNo.Location = new System.Drawing.Point(299, 249);
            this.btnConfirmLogoutNo.MaximumSize = new System.Drawing.Size(80, 25);
            this.btnConfirmLogoutNo.Name = "btnConfirmLogoutNo";
            this.btnConfirmLogoutNo.Size = new System.Drawing.Size(80, 24);
            this.btnConfirmLogoutNo.TabIndex = 10;
            this.btnConfirmLogoutNo.Text = "No";
            this.btnConfirmLogoutNo.UseVisualStyleBackColor = false;
            this.btnConfirmLogoutNo.Click += new System.EventHandler(this.btnConfirmLogoutNo_Click);
            // 
            // btnConfirmLogoutYes
            // 
            this.btnConfirmLogoutYes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfirmLogoutYes.BackColor = System.Drawing.Color.Gray;
            this.btnConfirmLogoutYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmLogoutYes.ForeColor = System.Drawing.Color.White;
            this.btnConfirmLogoutYes.Location = new System.Drawing.Point(427, 249);
            this.btnConfirmLogoutYes.MaximumSize = new System.Drawing.Size(100, 25);
            this.btnConfirmLogoutYes.Name = "btnConfirmLogoutYes";
            this.btnConfirmLogoutYes.Size = new System.Drawing.Size(80, 24);
            this.btnConfirmLogoutYes.TabIndex = 11;
            this.btnConfirmLogoutYes.Text = "Yes";
            this.btnConfirmLogoutYes.UseVisualStyleBackColor = false;
            this.btnConfirmLogoutYes.Click += new System.EventHandler(this.btnConfirmLogoutYes_Click);
            // 
            // lblConfirmLogout
            // 
            this.lblConfirmLogout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblConfirmLogout.AutoSize = true;
            this.lblConfirmLogout.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConfirmLogout.ForeColor = System.Drawing.Color.White;
            this.lblConfirmLogout.Location = new System.Drawing.Point(201, 177);
            this.lblConfirmLogout.Name = "lblConfirmLogout";
            this.lblConfirmLogout.Size = new System.Drawing.Size(397, 30);
            this.lblConfirmLogout.TabIndex = 9;
            this.lblConfirmLogout.Text = "Are you sure you wish to logout?";
            // 
            // ConfirmLogout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConfirmLogoutNo);
            this.Controls.Add(this.btnConfirmLogoutYes);
            this.Controls.Add(this.lblConfirmLogout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfirmLogout";
            this.Text = "ConfirmLogout";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnConfirmLogoutNo;
        private Button btnConfirmLogoutYes;
        private Label lblConfirmLogout;
    }
}