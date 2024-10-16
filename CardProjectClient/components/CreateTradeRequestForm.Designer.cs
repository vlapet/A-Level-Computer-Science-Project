namespace CardProjectClient.components
{
    partial class CreateTradeRequestForm
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
            this.dgvCardsReceive = new System.Windows.Forms.DataGridView();
            this.dgvCardsGive = new System.Windows.Forms.DataGridView();
            this.lblTradeName = new System.Windows.Forms.Label();
            this.txtBoxTradeName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreateTradeRequest = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardsReceive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardsGive)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCardsReceive
            // 
            this.dgvCardsReceive.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvCardsReceive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCardsReceive.Location = new System.Drawing.Point(420, 98);
            this.dgvCardsReceive.Name = "dgvCardsReceive";
            this.dgvCardsReceive.RowTemplate.Height = 25;
            this.dgvCardsReceive.Size = new System.Drawing.Size(339, 265);
            this.dgvCardsReceive.TabIndex = 0;
            // 
            // dgvCardsGive
            // 
            this.dgvCardsGive.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvCardsGive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCardsGive.Location = new System.Drawing.Point(37, 98);
            this.dgvCardsGive.Name = "dgvCardsGive";
            this.dgvCardsGive.RowTemplate.Height = 25;
            this.dgvCardsGive.Size = new System.Drawing.Size(337, 265);
            this.dgvCardsGive.TabIndex = 0;
            // 
            // lblTradeName
            // 
            this.lblTradeName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTradeName.AutoSize = true;
            this.lblTradeName.ForeColor = System.Drawing.Color.White;
            this.lblTradeName.Location = new System.Drawing.Point(182, 48);
            this.lblTradeName.Name = "lblTradeName";
            this.lblTradeName.Size = new System.Drawing.Size(73, 15);
            this.lblTradeName.TabIndex = 1;
            this.lblTradeName.Text = "Trade Name:";
            // 
            // txtBoxTradeName
            // 
            this.txtBoxTradeName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxTradeName.Location = new System.Drawing.Point(276, 45);
            this.txtBoxTradeName.Name = "txtBoxTradeName";
            this.txtBoxTradeName.Size = new System.Drawing.Size(252, 23);
            this.txtBoxTradeName.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(117, 406);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(147, 32);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreateTradeRequest
            // 
            this.btnCreateTradeRequest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreateTradeRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTradeRequest.ForeColor = System.Drawing.Color.White;
            this.btnCreateTradeRequest.Location = new System.Drawing.Point(546, 406);
            this.btnCreateTradeRequest.Name = "btnCreateTradeRequest";
            this.btnCreateTradeRequest.Size = new System.Drawing.Size(147, 32);
            this.btnCreateTradeRequest.TabIndex = 16;
            this.btnCreateTradeRequest.Text = "Create Trade Request";
            this.btnCreateTradeRequest.UseVisualStyleBackColor = true;
            this.btnCreateTradeRequest.Click += new System.EventHandler(this.btnCreateTradeRequest_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(292, 20);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(17, 15);
            this.lblInfo.TabIndex = 17;
            this.lblInfo.Text = "\"\"";
            // 
            // CreateTradeRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnCreateTradeRequest);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtBoxTradeName);
            this.Controls.Add(this.lblTradeName);
            this.Controls.Add(this.dgvCardsReceive);
            this.Controls.Add(this.dgvCardsGive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateTradeRequestForm";
            this.Text = "CreateTradeRequestForm";
            this.Load += new System.EventHandler(this.CreateTradeRequestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardsReceive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardsGive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvCardsReceive;
        private DataGridView dgvCardsGive;
        private Label lblTradeName;
        private TextBox txtBoxTradeName;
        private Button btnCancel;
        private Button btnCreateTradeRequest;
        private Label lblInfo;
    }
}