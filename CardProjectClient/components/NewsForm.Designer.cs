namespace CardProjectClient.components
{
    partial class NewsForm
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
            this.btnNewsTopBar = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtBoxTitle = new System.Windows.Forms.TextBox();
            this.txtBoxContent = new System.Windows.Forms.TextBox();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
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
            this.leftMenuBar1.TabIndex = 6;
            // 
            // btnNewsTopBar
            // 
            this.btnNewsTopBar.BackColor = System.Drawing.Color.DimGray;
            this.btnNewsTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNewsTopBar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNewsTopBar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnNewsTopBar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnNewsTopBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewsTopBar.ForeColor = System.Drawing.Color.White;
            this.btnNewsTopBar.Location = new System.Drawing.Point(0, 0);
            this.btnNewsTopBar.Name = "btnNewsTopBar";
            this.btnNewsTopBar.Size = new System.Drawing.Size(800, 30);
            this.btnNewsTopBar.TabIndex = 5;
            this.btnNewsTopBar.TabStop = false;
            this.btnNewsTopBar.Text = "News";
            this.btnNewsTopBar.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(327, 49);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(32, 15);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Title:";
            // 
            // txtBoxTitle
            // 
            this.txtBoxTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxTitle.BackColor = System.Drawing.Color.LightGray;
            this.txtBoxTitle.Location = new System.Drawing.Point(365, 46);
            this.txtBoxTitle.Name = "txtBoxTitle";
            this.txtBoxTitle.ReadOnly = true;
            this.txtBoxTitle.Size = new System.Drawing.Size(234, 23);
            this.txtBoxTitle.TabIndex = 8;
            // 
            // txtBoxContent
            // 
            this.txtBoxContent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxContent.BackColor = System.Drawing.Color.LightGray;
            this.txtBoxContent.Location = new System.Drawing.Point(230, 77);
            this.txtBoxContent.Multiline = true;
            this.txtBoxContent.Name = "txtBoxContent";
            this.txtBoxContent.ReadOnly = true;
            this.txtBoxContent.Size = new System.Drawing.Size(471, 318);
            this.txtBoxContent.TabIndex = 8;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(230, 408);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(129, 37);
            this.btnPrevious.TabIndex = 9;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(572, 408);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(129, 37);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(384, 419);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(17, 15);
            this.lblInfo.TabIndex = 11;
            this.lblInfo.Text = "\"\"";
            // 
            // NewsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.txtBoxContent);
            this.Controls.Add(this.txtBoxTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.leftMenuBar1);
            this.Controls.Add(this.btnNewsTopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewsForm";
            this.Text = "NewsForm";
            this.Load += new System.EventHandler(this.NewsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LeftMenuBar leftMenuBar1;
        private Button btnNewsTopBar;
        private Label lblTitle;
        private TextBox txtBoxTitle;
        private TextBox txtBoxContent;
        private Button btnPrevious;
        private Button btnNext;
        private Label lblInfo;
    }
}