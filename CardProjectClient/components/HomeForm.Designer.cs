namespace CardProjectClient.components
{
    partial class HomeForm
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
            this.btnHomeTopBar = new System.Windows.Forms.Button();
            this.txtBoxContent = new System.Windows.Forms.TextBox();
            this.txtBoxTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRecentCard = new System.Windows.Forms.Label();
            this.pctBoxCardImage = new System.Windows.Forms.PictureBox();
            this.pctBoxCardFrame = new System.Windows.Forms.PictureBox();
            this.lblDateObtainedText = new System.Windows.Forms.Label();
            this.lblDateObtained = new System.Windows.Forms.Label();
            this.lblCardNicknameText = new System.Windows.Forms.Label();
            this.lblCardFrameText = new System.Windows.Forms.Label();
            this.lblCardRarityText = new System.Windows.Forms.Label();
            this.lblCardIDText = new System.Windows.Forms.Label();
            this.lblCardNameText = new System.Windows.Forms.Label();
            this.lblCardNickname = new System.Windows.Forms.Label();
            this.lblCardFrame = new System.Windows.Forms.Label();
            this.lblCardRarity = new System.Windows.Forms.Label();
            this.lblCardID = new System.Windows.Forms.Label();
            this.lblCardName = new System.Windows.Forms.Label();
            this.btnViewCard = new System.Windows.Forms.Button();
            this.btnCreateNewCollection = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxCardImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxCardFrame)).BeginInit();
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
            this.leftMenuBar1.TabIndex = 0;
            // 
            // btnHomeTopBar
            // 
            this.btnHomeTopBar.BackColor = System.Drawing.Color.DimGray;
            this.btnHomeTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHomeTopBar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHomeTopBar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnHomeTopBar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnHomeTopBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHomeTopBar.ForeColor = System.Drawing.Color.White;
            this.btnHomeTopBar.Location = new System.Drawing.Point(0, 0);
            this.btnHomeTopBar.Name = "btnHomeTopBar";
            this.btnHomeTopBar.Size = new System.Drawing.Size(800, 30);
            this.btnHomeTopBar.TabIndex = 4;
            this.btnHomeTopBar.TabStop = false;
            this.btnHomeTopBar.Text = "Home";
            this.btnHomeTopBar.UseVisualStyleBackColor = false;
            // 
            // txtBoxContent
            // 
            this.txtBoxContent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxContent.BackColor = System.Drawing.Color.LightGray;
            this.txtBoxContent.Location = new System.Drawing.Point(165, 82);
            this.txtBoxContent.Multiline = true;
            this.txtBoxContent.Name = "txtBoxContent";
            this.txtBoxContent.ReadOnly = true;
            this.txtBoxContent.Size = new System.Drawing.Size(252, 318);
            this.txtBoxContent.TabIndex = 11;
            // 
            // txtBoxTitle
            // 
            this.txtBoxTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxTitle.BackColor = System.Drawing.Color.LightGray;
            this.txtBoxTitle.Location = new System.Drawing.Point(212, 51);
            this.txtBoxTitle.Name = "txtBoxTitle";
            this.txtBoxTitle.ReadOnly = true;
            this.txtBoxTitle.Size = new System.Drawing.Size(205, 23);
            this.txtBoxTitle.TabIndex = 10;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(174, 54);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(32, 15);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Title:";
            // 
            // lblRecentCard
            // 
            this.lblRecentCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRecentCard.AutoSize = true;
            this.lblRecentCard.ForeColor = System.Drawing.Color.White;
            this.lblRecentCard.Location = new System.Drawing.Point(450, 54);
            this.lblRecentCard.Name = "lblRecentCard";
            this.lblRecentCard.Size = new System.Drawing.Size(99, 15);
            this.lblRecentCard.TabIndex = 12;
            this.lblRecentCard.Text = "Most recent card:";
            // 
            // pctBoxCardImage
            // 
            this.pctBoxCardImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctBoxCardImage.Location = new System.Drawing.Point(450, 94);
            this.pctBoxCardImage.Name = "pctBoxCardImage";
            this.pctBoxCardImage.Size = new System.Drawing.Size(135, 216);
            this.pctBoxCardImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctBoxCardImage.TabIndex = 64;
            this.pctBoxCardImage.TabStop = false;
            // 
            // pctBoxCardFrame
            // 
            this.pctBoxCardFrame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctBoxCardFrame.Location = new System.Drawing.Point(443, 84);
            this.pctBoxCardFrame.Name = "pctBoxCardFrame";
            this.pctBoxCardFrame.Size = new System.Drawing.Size(149, 238);
            this.pctBoxCardFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctBoxCardFrame.TabIndex = 77;
            this.pctBoxCardFrame.TabStop = false;
            // 
            // lblDateObtainedText
            // 
            this.lblDateObtainedText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDateObtainedText.AutoSize = true;
            this.lblDateObtainedText.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDateObtainedText.ForeColor = System.Drawing.Color.White;
            this.lblDateObtainedText.Location = new System.Drawing.Point(703, 165);
            this.lblDateObtainedText.Name = "lblDateObtainedText";
            this.lblDateObtainedText.Size = new System.Drawing.Size(15, 16);
            this.lblDateObtainedText.TabIndex = 76;
            this.lblDateObtainedText.Text = "\"\"";
            // 
            // lblDateObtained
            // 
            this.lblDateObtained.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDateObtained.AutoSize = true;
            this.lblDateObtained.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDateObtained.ForeColor = System.Drawing.Color.White;
            this.lblDateObtained.Location = new System.Drawing.Point(598, 165);
            this.lblDateObtained.Name = "lblDateObtained";
            this.lblDateObtained.Size = new System.Drawing.Size(95, 16);
            this.lblDateObtained.TabIndex = 75;
            this.lblDateObtained.Text = "Date Obtained:";
            // 
            // lblCardNicknameText
            // 
            this.lblCardNicknameText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardNicknameText.AutoSize = true;
            this.lblCardNicknameText.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCardNicknameText.ForeColor = System.Drawing.Color.White;
            this.lblCardNicknameText.Location = new System.Drawing.Point(703, 149);
            this.lblCardNicknameText.Name = "lblCardNicknameText";
            this.lblCardNicknameText.Size = new System.Drawing.Size(15, 16);
            this.lblCardNicknameText.TabIndex = 70;
            this.lblCardNicknameText.Text = "\"\"";
            // 
            // lblCardFrameText
            // 
            this.lblCardFrameText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardFrameText.AutoSize = true;
            this.lblCardFrameText.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCardFrameText.ForeColor = System.Drawing.Color.White;
            this.lblCardFrameText.Location = new System.Drawing.Point(703, 133);
            this.lblCardFrameText.Name = "lblCardFrameText";
            this.lblCardFrameText.Size = new System.Drawing.Size(15, 16);
            this.lblCardFrameText.TabIndex = 71;
            this.lblCardFrameText.Text = "\"\"";
            // 
            // lblCardRarityText
            // 
            this.lblCardRarityText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardRarityText.AutoSize = true;
            this.lblCardRarityText.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCardRarityText.ForeColor = System.Drawing.Color.White;
            this.lblCardRarityText.Location = new System.Drawing.Point(703, 117);
            this.lblCardRarityText.Name = "lblCardRarityText";
            this.lblCardRarityText.Size = new System.Drawing.Size(15, 16);
            this.lblCardRarityText.TabIndex = 72;
            this.lblCardRarityText.Text = "\"\"";
            // 
            // lblCardIDText
            // 
            this.lblCardIDText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardIDText.AutoSize = true;
            this.lblCardIDText.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCardIDText.ForeColor = System.Drawing.Color.White;
            this.lblCardIDText.Location = new System.Drawing.Point(703, 101);
            this.lblCardIDText.Name = "lblCardIDText";
            this.lblCardIDText.Size = new System.Drawing.Size(15, 16);
            this.lblCardIDText.TabIndex = 73;
            this.lblCardIDText.Text = "\"\"";
            // 
            // lblCardNameText
            // 
            this.lblCardNameText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardNameText.AutoSize = true;
            this.lblCardNameText.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCardNameText.ForeColor = System.Drawing.Color.White;
            this.lblCardNameText.Location = new System.Drawing.Point(703, 85);
            this.lblCardNameText.Name = "lblCardNameText";
            this.lblCardNameText.Size = new System.Drawing.Size(15, 16);
            this.lblCardNameText.TabIndex = 74;
            this.lblCardNameText.Text = "\"\"";
            // 
            // lblCardNickname
            // 
            this.lblCardNickname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardNickname.AutoSize = true;
            this.lblCardNickname.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCardNickname.ForeColor = System.Drawing.Color.White;
            this.lblCardNickname.Location = new System.Drawing.Point(598, 149);
            this.lblCardNickname.Name = "lblCardNickname";
            this.lblCardNickname.Size = new System.Drawing.Size(103, 16);
            this.lblCardNickname.TabIndex = 65;
            this.lblCardNickname.Text = "Card Nickname:";
            // 
            // lblCardFrame
            // 
            this.lblCardFrame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardFrame.AutoSize = true;
            this.lblCardFrame.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCardFrame.ForeColor = System.Drawing.Color.White;
            this.lblCardFrame.Location = new System.Drawing.Point(598, 133);
            this.lblCardFrame.Name = "lblCardFrame";
            this.lblCardFrame.Size = new System.Drawing.Size(79, 16);
            this.lblCardFrame.TabIndex = 66;
            this.lblCardFrame.Text = "Card Frame:";
            // 
            // lblCardRarity
            // 
            this.lblCardRarity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardRarity.AutoSize = true;
            this.lblCardRarity.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCardRarity.ForeColor = System.Drawing.Color.White;
            this.lblCardRarity.Location = new System.Drawing.Point(598, 117);
            this.lblCardRarity.Name = "lblCardRarity";
            this.lblCardRarity.Size = new System.Drawing.Size(74, 16);
            this.lblCardRarity.TabIndex = 67;
            this.lblCardRarity.Text = "Card Rarity:";
            // 
            // lblCardID
            // 
            this.lblCardID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardID.AutoSize = true;
            this.lblCardID.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCardID.ForeColor = System.Drawing.Color.White;
            this.lblCardID.Location = new System.Drawing.Point(598, 101);
            this.lblCardID.Name = "lblCardID";
            this.lblCardID.Size = new System.Drawing.Size(54, 16);
            this.lblCardID.TabIndex = 68;
            this.lblCardID.Text = "Card ID:";
            // 
            // lblCardName
            // 
            this.lblCardName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardName.AutoSize = true;
            this.lblCardName.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCardName.ForeColor = System.Drawing.Color.White;
            this.lblCardName.Location = new System.Drawing.Point(598, 85);
            this.lblCardName.Name = "lblCardName";
            this.lblCardName.Size = new System.Drawing.Size(78, 16);
            this.lblCardName.TabIndex = 69;
            this.lblCardName.Text = "Card Name:";
            // 
            // btnViewCard
            // 
            this.btnViewCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnViewCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewCard.ForeColor = System.Drawing.Color.White;
            this.btnViewCard.Location = new System.Drawing.Point(612, 195);
            this.btnViewCard.Name = "btnViewCard";
            this.btnViewCard.Size = new System.Drawing.Size(142, 37);
            this.btnViewCard.TabIndex = 78;
            this.btnViewCard.Text = "View Card";
            this.btnViewCard.UseVisualStyleBackColor = true;
            this.btnViewCard.Click += new System.EventHandler(this.btnViewCard_Click);
            // 
            // btnCreateNewCollection
            // 
            this.btnCreateNewCollection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreateNewCollection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateNewCollection.ForeColor = System.Drawing.Color.White;
            this.btnCreateNewCollection.Location = new System.Drawing.Point(530, 355);
            this.btnCreateNewCollection.Name = "btnCreateNewCollection";
            this.btnCreateNewCollection.Size = new System.Drawing.Size(142, 45);
            this.btnCreateNewCollection.TabIndex = 78;
            this.btnCreateNewCollection.Text = "Create a new Collection";
            this.btnCreateNewCollection.UseVisualStyleBackColor = true;
            this.btnCreateNewCollection.Click += new System.EventHandler(this.btnCreateNewCollection_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(598, 54);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(17, 15);
            this.lblInfo.TabIndex = 79;
            this.lblInfo.Text = "\"\"";
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnCreateNewCollection);
            this.Controls.Add(this.btnViewCard);
            this.Controls.Add(this.pctBoxCardImage);
            this.Controls.Add(this.pctBoxCardFrame);
            this.Controls.Add(this.lblDateObtainedText);
            this.Controls.Add(this.lblDateObtained);
            this.Controls.Add(this.lblCardNicknameText);
            this.Controls.Add(this.lblCardFrameText);
            this.Controls.Add(this.lblCardRarityText);
            this.Controls.Add(this.lblCardIDText);
            this.Controls.Add(this.lblCardNameText);
            this.Controls.Add(this.lblCardNickname);
            this.Controls.Add(this.lblCardFrame);
            this.Controls.Add(this.lblCardRarity);
            this.Controls.Add(this.lblCardID);
            this.Controls.Add(this.lblCardName);
            this.Controls.Add(this.lblRecentCard);
            this.Controls.Add(this.txtBoxContent);
            this.Controls.Add(this.txtBoxTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.leftMenuBar1);
            this.Controls.Add(this.btnHomeTopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            this.Load += new System.EventHandler(this.HomeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxCardImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxCardFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LeftMenuBar leftMenuBar1;
        private Button btnHomeTopBar;
        private TextBox txtBoxContent;
        private TextBox txtBoxTitle;
        private Label lblTitle;
        private Label lblRecentCard;
        private PictureBox pctBoxCardImage;
        private PictureBox pctBoxCardFrame;
        private Label lblDateObtainedText;
        private Label lblDateObtained;
        private Label lblCardNicknameText;
        private Label lblCardFrameText;
        private Label lblCardRarityText;
        private Label lblCardIDText;
        private Label lblCardNameText;
        private Label lblCardNickname;
        private Label lblCardFrame;
        private Label lblCardRarity;
        private Label lblCardID;
        private Label lblCardName;
        private Button btnViewCard;
        private Button btnCreateNewCollection;
        private Label lblInfo;
    }
}