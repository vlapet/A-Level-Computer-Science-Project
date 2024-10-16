namespace CardProjectClient.components
{
    partial class SearchForm
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
            this.btnSearchTopBar = new System.Windows.Forms.Button();
            this.leftMenuBar1 = new CardProjectClient.components.LeftMenuBar();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.lblSearchType = new System.Windows.Forms.Label();
            this.CmbBoxSearchType = new System.Windows.Forms.ComboBox();
            this.lblSearchObject = new System.Windows.Forms.Label();
            this.txtBoxSearchKeywords = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCreateCollection = new System.Windows.Forms.Button();
            this.btnCreateTradeRequest = new System.Windows.Forms.Button();
            this.btnViewSelectedItem = new System.Windows.Forms.Button();
            this.lblSearchInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearchTopBar
            // 
            this.btnSearchTopBar.BackColor = System.Drawing.Color.DimGray;
            this.btnSearchTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSearchTopBar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearchTopBar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnSearchTopBar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnSearchTopBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchTopBar.ForeColor = System.Drawing.Color.White;
            this.btnSearchTopBar.Location = new System.Drawing.Point(0, 0);
            this.btnSearchTopBar.Name = "btnSearchTopBar";
            this.btnSearchTopBar.Size = new System.Drawing.Size(800, 30);
            this.btnSearchTopBar.TabIndex = 3;
            this.btnSearchTopBar.TabStop = false;
            this.btnSearchTopBar.Text = "Search";
            this.btnSearchTopBar.UseVisualStyleBackColor = false;
            // 
            // leftMenuBar1
            // 
            this.leftMenuBar1.BackColor = System.Drawing.Color.DimGray;
            this.leftMenuBar1.CurrentUser = null;
            this.leftMenuBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftMenuBar1.Location = new System.Drawing.Point(0, 30);
            this.leftMenuBar1.Name = "leftMenuBar1";
            this.leftMenuBar1.Size = new System.Drawing.Size(130, 420);
            this.leftMenuBar1.TabIndex = 4;
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.AllowUserToAddRows = false;
            this.dataGridViewMain.AllowUserToDeleteRows = false;
            this.dataGridViewMain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Location = new System.Drawing.Point(206, 127);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.ReadOnly = true;
            this.dataGridViewMain.RowTemplate.Height = 25;
            this.dataGridViewMain.Size = new System.Drawing.Size(503, 198);
            this.dataGridViewMain.TabIndex = 5;
            // 
            // lblSearchType
            // 
            this.lblSearchType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSearchType.AutoSize = true;
            this.lblSearchType.ForeColor = System.Drawing.Color.White;
            this.lblSearchType.Location = new System.Drawing.Point(206, 63);
            this.lblSearchType.Name = "lblSearchType";
            this.lblSearchType.Size = new System.Drawing.Size(72, 15);
            this.lblSearchType.TabIndex = 6;
            this.lblSearchType.Text = "Search Type:";
            // 
            // CmbBoxSearchType
            // 
            this.CmbBoxSearchType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CmbBoxSearchType.FormattingEnabled = true;
            this.CmbBoxSearchType.Items.AddRange(new object[] {
            "Users",
            "Cards",
            "Collections",
            "Trades Sent",
            "Incoming Trades",
            "News",
            "Available Cards",
            "Available Frames"});
            this.CmbBoxSearchType.Location = new System.Drawing.Point(304, 60);
            this.CmbBoxSearchType.Name = "CmbBoxSearchType";
            this.CmbBoxSearchType.Size = new System.Drawing.Size(242, 23);
            this.CmbBoxSearchType.TabIndex = 7;
            // 
            // lblSearchObject
            // 
            this.lblSearchObject.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSearchObject.AutoSize = true;
            this.lblSearchObject.ForeColor = System.Drawing.Color.White;
            this.lblSearchObject.Location = new System.Drawing.Point(206, 98);
            this.lblSearchObject.Name = "lblSearchObject";
            this.lblSearchObject.Size = new System.Drawing.Size(99, 15);
            this.lblSearchObject.TabIndex = 9;
            this.lblSearchObject.Text = "Search Keywords:";
            this.lblSearchObject.Click += new System.EventHandler(this.lblSearchObject_Click);
            // 
            // txtBoxSearchKeywords
            // 
            this.txtBoxSearchKeywords.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxSearchKeywords.Location = new System.Drawing.Point(304, 95);
            this.txtBoxSearchKeywords.Name = "txtBoxSearchKeywords";
            this.txtBoxSearchKeywords.Size = new System.Drawing.Size(242, 23);
            this.txtBoxSearchKeywords.TabIndex = 12;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(553, 95);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(156, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCreateCollection
            // 
            this.btnCreateCollection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreateCollection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateCollection.ForeColor = System.Drawing.Color.White;
            this.btnCreateCollection.Location = new System.Drawing.Point(206, 389);
            this.btnCreateCollection.Name = "btnCreateCollection";
            this.btnCreateCollection.Size = new System.Drawing.Size(147, 32);
            this.btnCreateCollection.TabIndex = 14;
            this.btnCreateCollection.Text = "Create a new collection";
            this.btnCreateCollection.UseVisualStyleBackColor = true;
            this.btnCreateCollection.Click += new System.EventHandler(this.btnCreateCollection_Click);
            // 
            // btnCreateTradeRequest
            // 
            this.btnCreateTradeRequest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreateTradeRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTradeRequest.ForeColor = System.Drawing.Color.White;
            this.btnCreateTradeRequest.Location = new System.Drawing.Point(373, 389);
            this.btnCreateTradeRequest.Name = "btnCreateTradeRequest";
            this.btnCreateTradeRequest.Size = new System.Drawing.Size(173, 32);
            this.btnCreateTradeRequest.TabIndex = 15;
            this.btnCreateTradeRequest.Text = "Create a new trade request";
            this.btnCreateTradeRequest.UseVisualStyleBackColor = true;
            this.btnCreateTradeRequest.Click += new System.EventHandler(this.btnCreateTradeRequest_Click);
            // 
            // btnViewSelectedItem
            // 
            this.btnViewSelectedItem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnViewSelectedItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewSelectedItem.ForeColor = System.Drawing.Color.White;
            this.btnViewSelectedItem.Location = new System.Drawing.Point(567, 389);
            this.btnViewSelectedItem.Name = "btnViewSelectedItem";
            this.btnViewSelectedItem.Size = new System.Drawing.Size(142, 32);
            this.btnViewSelectedItem.TabIndex = 16;
            this.btnViewSelectedItem.Text = "View selected item";
            this.btnViewSelectedItem.UseVisualStyleBackColor = true;
            this.btnViewSelectedItem.Click += new System.EventHandler(this.btnViewSelectedItem_Click);
            // 
            // lblSearchInfo
            // 
            this.lblSearchInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSearchInfo.AutoSize = true;
            this.lblSearchInfo.ForeColor = System.Drawing.Color.Red;
            this.lblSearchInfo.Location = new System.Drawing.Point(304, 39);
            this.lblSearchInfo.Name = "lblSearchInfo";
            this.lblSearchInfo.Size = new System.Drawing.Size(17, 15);
            this.lblSearchInfo.TabIndex = 17;
            this.lblSearchInfo.Text = "\"\"";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSearchInfo);
            this.Controls.Add(this.btnViewSelectedItem);
            this.Controls.Add(this.btnCreateTradeRequest);
            this.Controls.Add(this.btnCreateCollection);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtBoxSearchKeywords);
            this.Controls.Add(this.lblSearchObject);
            this.Controls.Add(this.CmbBoxSearchType);
            this.Controls.Add(this.lblSearchType);
            this.Controls.Add(this.dataGridViewMain);
            this.Controls.Add(this.leftMenuBar1);
            this.Controls.Add(this.btnSearchTopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSearchTopBar;
        private LeftMenuBar leftMenuBar1;
        private DataGridView dataGridViewMain;
        private Label lblSearchType;
        private ComboBox CmbBoxSearchType;
        private Label lblSearchObject;
        private TextBox txtBoxSearchKeywords;
        private Button btnSearch;
        private Button btnCreateCollection;
        private Button btnCreateTradeRequest;
        private Button btnViewSelectedItem;
        private Label lblSearchInfo;
    }
}