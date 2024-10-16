namespace CardProjectClient.components
{
    partial class ConfirmAccountUpdate
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
            this.btnConfirmAccountUpdateNo = new System.Windows.Forms.Button();
            this.btnConfirmAccountUpdateYes = new System.Windows.Forms.Button();
            this.lblConfirmAccountUpdate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConfirmAccountUpdateNo
            // 
            this.btnConfirmAccountUpdateNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfirmAccountUpdateNo.BackColor = System.Drawing.Color.Gray;
            this.btnConfirmAccountUpdateNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmAccountUpdateNo.ForeColor = System.Drawing.Color.White;
            this.btnConfirmAccountUpdateNo.Location = new System.Drawing.Point(298, 249);
            this.btnConfirmAccountUpdateNo.MaximumSize = new System.Drawing.Size(80, 25);
            this.btnConfirmAccountUpdateNo.Name = "btnConfirmAccountUpdateNo";
            this.btnConfirmAccountUpdateNo.Size = new System.Drawing.Size(80, 24);
            this.btnConfirmAccountUpdateNo.TabIndex = 13;
            this.btnConfirmAccountUpdateNo.Text = "No";
            this.btnConfirmAccountUpdateNo.UseVisualStyleBackColor = false;
            this.btnConfirmAccountUpdateNo.Click += new System.EventHandler(this.btnConfirmAccountUpdateNo_Click);
            // 
            // btnConfirmAccountUpdateYes
            // 
            this.btnConfirmAccountUpdateYes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfirmAccountUpdateYes.BackColor = System.Drawing.Color.Gray;
            this.btnConfirmAccountUpdateYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmAccountUpdateYes.ForeColor = System.Drawing.Color.White;
            this.btnConfirmAccountUpdateYes.Location = new System.Drawing.Point(426, 249);
            this.btnConfirmAccountUpdateYes.MaximumSize = new System.Drawing.Size(100, 25);
            this.btnConfirmAccountUpdateYes.Name = "btnConfirmAccountUpdateYes";
            this.btnConfirmAccountUpdateYes.Size = new System.Drawing.Size(80, 24);
            this.btnConfirmAccountUpdateYes.TabIndex = 14;
            this.btnConfirmAccountUpdateYes.Text = "Yes";
            this.btnConfirmAccountUpdateYes.UseVisualStyleBackColor = false;
            this.btnConfirmAccountUpdateYes.Click += new System.EventHandler(this.btnConfirmAccountUpdateYes_Click);
            // 
            // lblConfirmAccountUpdate
            // 
            this.lblConfirmAccountUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblConfirmAccountUpdate.AutoSize = true;
            this.lblConfirmAccountUpdate.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConfirmAccountUpdate.ForeColor = System.Drawing.Color.White;
            this.lblConfirmAccountUpdate.Location = new System.Drawing.Point(118, 177);
            this.lblConfirmAccountUpdate.Name = "lblConfirmAccountUpdate";
            this.lblConfirmAccountUpdate.Size = new System.Drawing.Size(604, 30);
            this.lblConfirmAccountUpdate.TabIndex = 12;
            this.lblConfirmAccountUpdate.Text = "Are you sure you wish to update these properties?";
            // 
            // ConfirmAccountUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConfirmAccountUpdateNo);
            this.Controls.Add(this.btnConfirmAccountUpdateYes);
            this.Controls.Add(this.lblConfirmAccountUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfirmAccountUpdate";
            this.Text = "ConfirmAccountUpdate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnConfirmAccountUpdateNo;
        private Button btnConfirmAccountUpdateYes;
        private Label lblConfirmAccountUpdate;
    }
}