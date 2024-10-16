namespace CardProjectClient.components
{
    partial class ConfirmAccountDeletion
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
            this.btnConfirmAccountDeletionNo = new System.Windows.Forms.Button();
            this.btnConfirmAccountDeletionYes = new System.Windows.Forms.Button();
            this.lblConfirmAccountDeletion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConfirmAccountDeletionNo
            // 
            this.btnConfirmAccountDeletionNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfirmAccountDeletionNo.BackColor = System.Drawing.Color.Gray;
            this.btnConfirmAccountDeletionNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmAccountDeletionNo.ForeColor = System.Drawing.Color.White;
            this.btnConfirmAccountDeletionNo.Location = new System.Drawing.Point(299, 249);
            this.btnConfirmAccountDeletionNo.MaximumSize = new System.Drawing.Size(80, 25);
            this.btnConfirmAccountDeletionNo.Name = "btnConfirmAccountDeletionNo";
            this.btnConfirmAccountDeletionNo.Size = new System.Drawing.Size(80, 24);
            this.btnConfirmAccountDeletionNo.TabIndex = 10;
            this.btnConfirmAccountDeletionNo.Text = "No";
            this.btnConfirmAccountDeletionNo.UseVisualStyleBackColor = false;
            this.btnConfirmAccountDeletionNo.Click += new System.EventHandler(this.btnConfirmAccountDeletionNo_Click);
            // 
            // btnConfirmAccountDeletionYes
            // 
            this.btnConfirmAccountDeletionYes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfirmAccountDeletionYes.BackColor = System.Drawing.Color.Gray;
            this.btnConfirmAccountDeletionYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmAccountDeletionYes.ForeColor = System.Drawing.Color.White;
            this.btnConfirmAccountDeletionYes.Location = new System.Drawing.Point(427, 249);
            this.btnConfirmAccountDeletionYes.MaximumSize = new System.Drawing.Size(100, 25);
            this.btnConfirmAccountDeletionYes.Name = "btnConfirmAccountDeletionYes";
            this.btnConfirmAccountDeletionYes.Size = new System.Drawing.Size(80, 24);
            this.btnConfirmAccountDeletionYes.TabIndex = 11;
            this.btnConfirmAccountDeletionYes.Text = "Yes";
            this.btnConfirmAccountDeletionYes.UseVisualStyleBackColor = false;
            this.btnConfirmAccountDeletionYes.Click += new System.EventHandler(this.btnConfirmAccountDeletionYes_Click);
            // 
            // lblConfirmAccountDeletion
            // 
            this.lblConfirmAccountDeletion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblConfirmAccountDeletion.AutoSize = true;
            this.lblConfirmAccountDeletion.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConfirmAccountDeletion.ForeColor = System.Drawing.Color.White;
            this.lblConfirmAccountDeletion.Location = new System.Drawing.Point(119, 177);
            this.lblConfirmAccountDeletion.Name = "lblConfirmAccountDeletion";
            this.lblConfirmAccountDeletion.Size = new System.Drawing.Size(565, 30);
            this.lblConfirmAccountDeletion.TabIndex = 9;
            this.lblConfirmAccountDeletion.Text = "Are you sure you wish to delete your account?";
            // 
            // ConfirmAccountDeletion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConfirmAccountDeletionNo);
            this.Controls.Add(this.btnConfirmAccountDeletionYes);
            this.Controls.Add(this.lblConfirmAccountDeletion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfirmAccountDeletion";
            this.Text = "ConfirmAccountDeletion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnConfirmAccountDeletionNo;
        private Button btnConfirmAccountDeletionYes;
        private Label lblConfirmAccountDeletion;
    }
}