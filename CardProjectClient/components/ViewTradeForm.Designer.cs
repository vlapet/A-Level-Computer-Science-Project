namespace CardProjectClient.components
{
    partial class ViewTradeForm
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnAccept_Delete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtBoxTradeName = new System.Windows.Forms.TextBox();
            this.lblTradeName = new System.Windows.Forms.Label();
            this.dgvCardsReceive = new System.Windows.Forms.DataGridView();
            this.dgvCardsGive = new System.Windows.Forms.DataGridView();
            this.btnDeny = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardsReceive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardsGive)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(294, 16);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(17, 15);
            this.lblInfo.TabIndex = 24;
            this.lblInfo.Text = "\"\"";
            // 
            // btnAccept_Delete
            // 
            this.btnAccept_Delete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAccept_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept_Delete.ForeColor = System.Drawing.Color.White;
            this.btnAccept_Delete.Location = new System.Drawing.Point(548, 402);
            this.btnAccept_Delete.Name = "btnAccept_Delete";
            this.btnAccept_Delete.Size = new System.Drawing.Size(147, 32);
            this.btnAccept_Delete.TabIndex = 23;
            this.btnAccept_Delete.Text = "Accept";
            this.btnAccept_Delete.UseVisualStyleBackColor = true;
            this.btnAccept_Delete.Click += new System.EventHandler(this.btnAccept_Delete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(119, 402);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(147, 32);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtBoxTradeName
            // 
            this.txtBoxTradeName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxTradeName.Location = new System.Drawing.Point(278, 41);
            this.txtBoxTradeName.Name = "txtBoxTradeName";
            this.txtBoxTradeName.Size = new System.Drawing.Size(252, 23);
            this.txtBoxTradeName.TabIndex = 21;
            // 
            // lblTradeName
            // 
            this.lblTradeName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTradeName.AutoSize = true;
            this.lblTradeName.ForeColor = System.Drawing.Color.White;
            this.lblTradeName.Location = new System.Drawing.Point(184, 44);
            this.lblTradeName.Name = "lblTradeName";
            this.lblTradeName.Size = new System.Drawing.Size(73, 15);
            this.lblTradeName.TabIndex = 20;
            this.lblTradeName.Text = "Trade Name:";
            // 
            // dgvCardsReceive
            // 
            this.dgvCardsReceive.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvCardsReceive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCardsReceive.Location = new System.Drawing.Point(422, 94);
            this.dgvCardsReceive.Name = "dgvCardsReceive";
            this.dgvCardsReceive.RowTemplate.Height = 25;
            this.dgvCardsReceive.Size = new System.Drawing.Size(339, 265);
            this.dgvCardsReceive.TabIndex = 18;
            // 
            // dgvCardsGive
            // 
            this.dgvCardsGive.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvCardsGive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCardsGive.Location = new System.Drawing.Point(39, 94);
            this.dgvCardsGive.Name = "dgvCardsGive";
            this.dgvCardsGive.RowTemplate.Height = 25;
            this.dgvCardsGive.Size = new System.Drawing.Size(337, 265);
            this.dgvCardsGive.TabIndex = 19;
            // 
            // btnDeny
            // 
            this.btnDeny.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeny.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeny.ForeColor = System.Drawing.Color.White;
            this.btnDeny.Location = new System.Drawing.Point(329, 402);
            this.btnDeny.Name = "btnDeny";
            this.btnDeny.Size = new System.Drawing.Size(147, 32);
            this.btnDeny.TabIndex = 25;
            this.btnDeny.Text = "Deny";
            this.btnDeny.UseVisualStyleBackColor = true;
            this.btnDeny.Click += new System.EventHandler(this.btnDeny_Click);
            // 
            // ViewTradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDeny);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnAccept_Delete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtBoxTradeName);
            this.Controls.Add(this.lblTradeName);
            this.Controls.Add(this.dgvCardsReceive);
            this.Controls.Add(this.dgvCardsGive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewTradeForm";
            this.Text = "ViewTradeForm";
            this.Load += new System.EventHandler(this.ViewTradeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardsReceive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardsGive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblInfo;
        private Button btnAccept_Delete;
        private Button btnCancel;
        private TextBox txtBoxTradeName;
        private Label lblTradeName;
        private DataGridView dgvCardsReceive;
        private DataGridView dgvCardsGive;
        private Button btnDeny;
    }
}