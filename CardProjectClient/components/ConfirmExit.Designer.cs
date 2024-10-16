namespace CardProjectClient.components
{
    partial class ConfirmExit
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
            this.pnlConfirmExit = new System.Windows.Forms.Panel();
            this.btnConfirmExitNo = new System.Windows.Forms.Button();
            this.btnConfirmExitYes = new System.Windows.Forms.Button();
            this.lblConfirmExit = new System.Windows.Forms.Label();
            this.pnlConfirmExit.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlConfirmExit
            // 
            this.pnlConfirmExit.BackColor = System.Drawing.Color.Gray;
            this.pnlConfirmExit.Controls.Add(this.btnConfirmExitNo);
            this.pnlConfirmExit.Controls.Add(this.btnConfirmExitYes);
            this.pnlConfirmExit.Controls.Add(this.lblConfirmExit);
            this.pnlConfirmExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConfirmExit.Location = new System.Drawing.Point(0, 0);
            this.pnlConfirmExit.Name = "pnlConfirmExit";
            this.pnlConfirmExit.Size = new System.Drawing.Size(800, 450);
            this.pnlConfirmExit.TabIndex = 0;
            // 
            // btnConfirmExitNo
            // 
            this.btnConfirmExitNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfirmExitNo.BackColor = System.Drawing.Color.Gray;
            this.btnConfirmExitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmExitNo.ForeColor = System.Drawing.Color.White;
            this.btnConfirmExitNo.Location = new System.Drawing.Point(288, 248);
            this.btnConfirmExitNo.MaximumSize = new System.Drawing.Size(80, 25);
            this.btnConfirmExitNo.Name = "btnConfirmExitNo";
            this.btnConfirmExitNo.Size = new System.Drawing.Size(80, 24);
            this.btnConfirmExitNo.TabIndex = 7;
            this.btnConfirmExitNo.Text = "No";
            this.btnConfirmExitNo.UseVisualStyleBackColor = false;
            this.btnConfirmExitNo.Click += new System.EventHandler(this.btnConfirmExitNo_Click);
            // 
            // btnConfirmExitYes
            // 
            this.btnConfirmExitYes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfirmExitYes.BackColor = System.Drawing.Color.Gray;
            this.btnConfirmExitYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmExitYes.ForeColor = System.Drawing.Color.White;
            this.btnConfirmExitYes.Location = new System.Drawing.Point(416, 248);
            this.btnConfirmExitYes.MaximumSize = new System.Drawing.Size(100, 25);
            this.btnConfirmExitYes.Name = "btnConfirmExitYes";
            this.btnConfirmExitYes.Size = new System.Drawing.Size(80, 24);
            this.btnConfirmExitYes.TabIndex = 8;
            this.btnConfirmExitYes.Text = "Yes";
            this.btnConfirmExitYes.UseVisualStyleBackColor = false;
            this.btnConfirmExitYes.Click += new System.EventHandler(this.btnConfirmExitYes_Click);
            // 
            // lblConfirmExit
            // 
            this.lblConfirmExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblConfirmExit.AutoSize = true;
            this.lblConfirmExit.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConfirmExit.ForeColor = System.Drawing.Color.White;
            this.lblConfirmExit.Location = new System.Drawing.Point(208, 176);
            this.lblConfirmExit.Name = "lblConfirmExit";
            this.lblConfirmExit.Size = new System.Drawing.Size(362, 30);
            this.lblConfirmExit.TabIndex = 0;
            this.lblConfirmExit.Text = "Are you sure you wish to exit?";
            // 
            // ConfirmExit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlConfirmExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfirmExit";
            this.Text = "ConfirmExit";
            this.pnlConfirmExit.ResumeLayout(false);
            this.pnlConfirmExit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlConfirmExit;
        private Label lblConfirmExit;
        private Button btnConfirmExitNo;
        private Button btnConfirmExitYes;
    }
}