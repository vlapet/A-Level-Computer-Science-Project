namespace CardProjectClient.components
{
    partial class ConfirmCollectionDeletion
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
            this.btnConfirmCollectionDeletionNo = new System.Windows.Forms.Button();
            this.btnConfirmCollectionDeletionYes = new System.Windows.Forms.Button();
            this.lblConfirmAccountDeletion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConfirmCollectionDeletionNo
            // 
            this.btnConfirmCollectionDeletionNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfirmCollectionDeletionNo.BackColor = System.Drawing.Color.Gray;
            this.btnConfirmCollectionDeletionNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmCollectionDeletionNo.ForeColor = System.Drawing.Color.White;
            this.btnConfirmCollectionDeletionNo.Location = new System.Drawing.Point(298, 249);
            this.btnConfirmCollectionDeletionNo.MaximumSize = new System.Drawing.Size(80, 25);
            this.btnConfirmCollectionDeletionNo.Name = "btnConfirmCollectionDeletionNo";
            this.btnConfirmCollectionDeletionNo.Size = new System.Drawing.Size(80, 24);
            this.btnConfirmCollectionDeletionNo.TabIndex = 13;
            this.btnConfirmCollectionDeletionNo.Text = "No";
            this.btnConfirmCollectionDeletionNo.UseVisualStyleBackColor = false;
            this.btnConfirmCollectionDeletionNo.Click += new System.EventHandler(this.btnConfirmCollectionDeletionNo_Click);
            // 
            // btnConfirmCollectionDeletionYes
            // 
            this.btnConfirmCollectionDeletionYes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfirmCollectionDeletionYes.BackColor = System.Drawing.Color.Gray;
            this.btnConfirmCollectionDeletionYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmCollectionDeletionYes.ForeColor = System.Drawing.Color.White;
            this.btnConfirmCollectionDeletionYes.Location = new System.Drawing.Point(426, 249);
            this.btnConfirmCollectionDeletionYes.MaximumSize = new System.Drawing.Size(100, 25);
            this.btnConfirmCollectionDeletionYes.Name = "btnConfirmCollectionDeletionYes";
            this.btnConfirmCollectionDeletionYes.Size = new System.Drawing.Size(80, 24);
            this.btnConfirmCollectionDeletionYes.TabIndex = 14;
            this.btnConfirmCollectionDeletionYes.Text = "Yes";
            this.btnConfirmCollectionDeletionYes.UseVisualStyleBackColor = false;
            this.btnConfirmCollectionDeletionYes.Click += new System.EventHandler(this.btnConfirmCollectionDeletionYes_Click);
            // 
            // lblConfirmAccountDeletion
            // 
            this.lblConfirmAccountDeletion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblConfirmAccountDeletion.AutoSize = true;
            this.lblConfirmAccountDeletion.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblConfirmAccountDeletion.ForeColor = System.Drawing.Color.White;
            this.lblConfirmAccountDeletion.Location = new System.Drawing.Point(103, 179);
            this.lblConfirmAccountDeletion.Name = "lblConfirmAccountDeletion";
            this.lblConfirmAccountDeletion.Size = new System.Drawing.Size(572, 30);
            this.lblConfirmAccountDeletion.TabIndex = 12;
            this.lblConfirmAccountDeletion.Text = "Are you sure you wish to delete this collection?";
            // 
            // ConfirmCollectionDeletion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConfirmCollectionDeletionNo);
            this.Controls.Add(this.btnConfirmCollectionDeletionYes);
            this.Controls.Add(this.lblConfirmAccountDeletion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfirmCollectionDeletion";
            this.Text = "ConfirmCollectionDeletion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnConfirmCollectionDeletionNo;
        private Button btnConfirmCollectionDeletionYes;
        private Label lblConfirmAccountDeletion;
    }
}