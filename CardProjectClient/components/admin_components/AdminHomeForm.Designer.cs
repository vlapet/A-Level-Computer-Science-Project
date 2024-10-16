namespace CardProjectClient.components.admin_components
{
    partial class AdminHomeForm
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
            this.ofdFilePicker = new System.Windows.Forms.OpenFileDialog();
            this.btnAdminHomeTopBar = new System.Windows.Forms.Button();
            this.btnChooseCardImage = new System.Windows.Forms.Button();
            this.btnAddNewCard = new System.Windows.Forms.Button();
            this.txtBoxImagePath = new System.Windows.Forms.TextBox();
            this.grpBoxAddNewCard = new System.Windows.Forms.GroupBox();
            this.cmbBoxRarities = new System.Windows.Forms.ComboBox();
            this.lblAddCardInfo = new System.Windows.Forms.Label();
            this.lblAddNewCard = new System.Windows.Forms.Label();
            this.txtBoxCardName = new System.Windows.Forms.TextBox();
            this.grpBoxAddNewRarity = new System.Windows.Forms.GroupBox();
            this.lblAddRarityInfo = new System.Windows.Forms.Label();
            this.lblAddNewRarity = new System.Windows.Forms.Label();
            this.txtBoxRarity = new System.Windows.Forms.TextBox();
            this.btnAddNewRarity = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpBoxAddNewCard.SuspendLayout();
            this.grpBoxAddNewRarity.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdFilePicker
            // 
            this.ofdFilePicker.FileName = "openFileDialog1";
            // 
            // btnAdminHomeTopBar
            // 
            this.btnAdminHomeTopBar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAdminHomeTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdminHomeTopBar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAdminHomeTopBar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnAdminHomeTopBar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnAdminHomeTopBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminHomeTopBar.ForeColor = System.Drawing.Color.White;
            this.btnAdminHomeTopBar.Location = new System.Drawing.Point(0, 0);
            this.btnAdminHomeTopBar.Name = "btnAdminHomeTopBar";
            this.btnAdminHomeTopBar.Size = new System.Drawing.Size(800, 30);
            this.btnAdminHomeTopBar.TabIndex = 3;
            this.btnAdminHomeTopBar.TabStop = false;
            this.btnAdminHomeTopBar.Text = "Admin Control Panel";
            this.btnAdminHomeTopBar.UseVisualStyleBackColor = false;
            // 
            // btnChooseCardImage
            // 
            this.btnChooseCardImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnChooseCardImage.BackColor = System.Drawing.Color.SteelBlue;
            this.btnChooseCardImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseCardImage.ForeColor = System.Drawing.Color.White;
            this.btnChooseCardImage.Location = new System.Drawing.Point(227, 149);
            this.btnChooseCardImage.Name = "btnChooseCardImage";
            this.btnChooseCardImage.Size = new System.Drawing.Size(122, 26);
            this.btnChooseCardImage.TabIndex = 4;
            this.btnChooseCardImage.Text = "Choose Card Image";
            this.btnChooseCardImage.UseVisualStyleBackColor = false;
            this.btnChooseCardImage.Click += new System.EventHandler(this.btnChooseCardImage_Click);
            // 
            // btnAddNewCard
            // 
            this.btnAddNewCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddNewCard.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddNewCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewCard.ForeColor = System.Drawing.Color.White;
            this.btnAddNewCard.Location = new System.Drawing.Point(105, 250);
            this.btnAddNewCard.Name = "btnAddNewCard";
            this.btnAddNewCard.Size = new System.Drawing.Size(154, 44);
            this.btnAddNewCard.TabIndex = 4;
            this.btnAddNewCard.Text = "Add New Card";
            this.btnAddNewCard.UseVisualStyleBackColor = false;
            this.btnAddNewCard.Click += new System.EventHandler(this.btnAddNewCard_Click);
            // 
            // txtBoxImagePath
            // 
            this.txtBoxImagePath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxImagePath.Location = new System.Drawing.Point(9, 149);
            this.txtBoxImagePath.Name = "txtBoxImagePath";
            this.txtBoxImagePath.Size = new System.Drawing.Size(192, 23);
            this.txtBoxImagePath.TabIndex = 5;
            // 
            // grpBoxAddNewCard
            // 
            this.grpBoxAddNewCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpBoxAddNewCard.Controls.Add(this.btnRefresh);
            this.grpBoxAddNewCard.Controls.Add(this.cmbBoxRarities);
            this.grpBoxAddNewCard.Controls.Add(this.lblAddCardInfo);
            this.grpBoxAddNewCard.Controls.Add(this.lblAddNewCard);
            this.grpBoxAddNewCard.Controls.Add(this.txtBoxCardName);
            this.grpBoxAddNewCard.Controls.Add(this.txtBoxImagePath);
            this.grpBoxAddNewCard.Controls.Add(this.btnAddNewCard);
            this.grpBoxAddNewCard.Controls.Add(this.btnChooseCardImage);
            this.grpBoxAddNewCard.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpBoxAddNewCard.Location = new System.Drawing.Point(34, 69);
            this.grpBoxAddNewCard.Name = "grpBoxAddNewCard";
            this.grpBoxAddNewCard.Size = new System.Drawing.Size(360, 315);
            this.grpBoxAddNewCard.TabIndex = 6;
            this.grpBoxAddNewCard.TabStop = false;
            // 
            // cmbBoxRarities
            // 
            this.cmbBoxRarities.FormattingEnabled = true;
            this.cmbBoxRarities.Location = new System.Drawing.Point(10, 204);
            this.cmbBoxRarities.Name = "cmbBoxRarities";
            this.cmbBoxRarities.Size = new System.Drawing.Size(191, 23);
            this.cmbBoxRarities.TabIndex = 10;
            // 
            // lblAddCardInfo
            // 
            this.lblAddCardInfo.AutoSize = true;
            this.lblAddCardInfo.ForeColor = System.Drawing.Color.White;
            this.lblAddCardInfo.Location = new System.Drawing.Point(126, 230);
            this.lblAddCardInfo.Name = "lblAddCardInfo";
            this.lblAddCardInfo.Size = new System.Drawing.Size(17, 15);
            this.lblAddCardInfo.TabIndex = 9;
            this.lblAddCardInfo.Text = "\"\"";
            // 
            // lblAddNewCard
            // 
            this.lblAddNewCard.AutoSize = true;
            this.lblAddNewCard.ForeColor = System.Drawing.Color.White;
            this.lblAddNewCard.Location = new System.Drawing.Point(143, 78);
            this.lblAddNewCard.Name = "lblAddNewCard";
            this.lblAddNewCard.Size = new System.Drawing.Size(84, 15);
            this.lblAddNewCard.TabIndex = 8;
            this.lblAddNewCard.Text = "Add New Card";
            // 
            // txtBoxCardName
            // 
            this.txtBoxCardName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxCardName.Location = new System.Drawing.Point(10, 103);
            this.txtBoxCardName.Name = "txtBoxCardName";
            this.txtBoxCardName.PlaceholderText = "Enter card name here";
            this.txtBoxCardName.Size = new System.Drawing.Size(339, 23);
            this.txtBoxCardName.TabIndex = 7;
            // 
            // grpBoxAddNewRarity
            // 
            this.grpBoxAddNewRarity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpBoxAddNewRarity.Controls.Add(this.lblAddRarityInfo);
            this.grpBoxAddNewRarity.Controls.Add(this.lblAddNewRarity);
            this.grpBoxAddNewRarity.Controls.Add(this.txtBoxRarity);
            this.grpBoxAddNewRarity.Controls.Add(this.btnAddNewRarity);
            this.grpBoxAddNewRarity.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpBoxAddNewRarity.Location = new System.Drawing.Point(416, 69);
            this.grpBoxAddNewRarity.Name = "grpBoxAddNewRarity";
            this.grpBoxAddNewRarity.Size = new System.Drawing.Size(360, 315);
            this.grpBoxAddNewRarity.TabIndex = 10;
            this.grpBoxAddNewRarity.TabStop = false;
            // 
            // lblAddRarityInfo
            // 
            this.lblAddRarityInfo.AutoSize = true;
            this.lblAddRarityInfo.ForeColor = System.Drawing.Color.White;
            this.lblAddRarityInfo.Location = new System.Drawing.Point(126, 228);
            this.lblAddRarityInfo.Name = "lblAddRarityInfo";
            this.lblAddRarityInfo.Size = new System.Drawing.Size(17, 15);
            this.lblAddRarityInfo.TabIndex = 9;
            this.lblAddRarityInfo.Text = "\"\"";
            // 
            // lblAddNewRarity
            // 
            this.lblAddNewRarity.AutoSize = true;
            this.lblAddNewRarity.ForeColor = System.Drawing.Color.White;
            this.lblAddNewRarity.Location = new System.Drawing.Point(143, 78);
            this.lblAddNewRarity.Name = "lblAddNewRarity";
            this.lblAddNewRarity.Size = new System.Drawing.Size(89, 15);
            this.lblAddNewRarity.TabIndex = 8;
            this.lblAddNewRarity.Text = "Add New Rarity";
            // 
            // txtBoxRarity
            // 
            this.txtBoxRarity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxRarity.Location = new System.Drawing.Point(12, 103);
            this.txtBoxRarity.Name = "txtBoxRarity";
            this.txtBoxRarity.PlaceholderText = "Enter rarity here";
            this.txtBoxRarity.Size = new System.Drawing.Size(339, 23);
            this.txtBoxRarity.TabIndex = 7;
            // 
            // btnAddNewRarity
            // 
            this.btnAddNewRarity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddNewRarity.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddNewRarity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewRarity.ForeColor = System.Drawing.Color.White;
            this.btnAddNewRarity.Location = new System.Drawing.Point(112, 250);
            this.btnAddNewRarity.Name = "btnAddNewRarity";
            this.btnAddNewRarity.Size = new System.Drawing.Size(154, 44);
            this.btnAddNewRarity.TabIndex = 4;
            this.btnAddNewRarity.Text = "Add New Rarity";
            this.btnAddNewRarity.UseVisualStyleBackColor = false;
            this.btnAddNewRarity.Click += new System.EventHandler(this.btnAddNewRarity_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextPage.BackColor = System.Drawing.Color.SteelBlue;
            this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPage.ForeColor = System.Drawing.Color.White;
            this.btnNextPage.Location = new System.Drawing.Point(642, 399);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(134, 39);
            this.btnNextPage.TabIndex = 10;
            this.btnNextPage.Text = "Next Page";
            this.btnNextPage.UseVisualStyleBackColor = false;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(34, 399);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(134, 39);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(227, 201);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(122, 26);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // AdminHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.grpBoxAddNewRarity);
            this.Controls.Add(this.grpBoxAddNewCard);
            this.Controls.Add(this.btnAdminHomeTopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminHomeForm";
            this.Text = "AdminHomeForm";
            this.Load += new System.EventHandler(this.AdminHomeForm_Load);
            this.grpBoxAddNewCard.ResumeLayout(false);
            this.grpBoxAddNewCard.PerformLayout();
            this.grpBoxAddNewRarity.ResumeLayout(false);
            this.grpBoxAddNewRarity.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenFileDialog ofdFilePicker;
        private Button btnAdminHomeTopBar;
        private Button btnChooseCardImage;
        private Button btnAddNewCard;
        private TextBox txtBoxImagePath;
        private GroupBox grpBoxAddNewCard;
        private TextBox txtBoxCardName;
        private Label lblAddNewCard;
        private Label lblAddCardInfo;
        private GroupBox grpBoxAddNewRarity;
        private Label lblAddRarityInfo;
        private Label lblAddNewRarity;
        private TextBox txtBoxRarity;
        private Button btnAddNewRarity;
        private Button btnNextPage;
        private Button btnLogout;
        private ComboBox cmbBoxRarities;
        private Button btnRefresh;
    }
}