using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardProjectClient.game;
using CardProjectClient.lib;
using CardProjectClient.client;
using static System.Windows.Forms.Design.AxImporter;

namespace CardProjectClient.components
{
    // Inherits IJsonParse interface
    public partial class HomeForm : Form, IImageCore
    {
        private User _CurrentUser;
        private GetRecentCard RecentCard;

        #region Constructors

        public HomeForm(User currentUser)
        {
            this.CurrentUser = currentUser;
            InitializeComponent();

            this.leftMenuBar1.CurrentUser = this.CurrentUser;
            Console.WriteLine($"In HomeForm\tCurrentUser: {CurrentUser}");
        }

#endregion

        #region Private Accessors

        public User CurrentUser
        {
            get => _CurrentUser;
            set => _CurrentUser = value;
        }

        #endregion

        #region Functions

        private async void HomeForm_Load(object sender, EventArgs e)
        {
            this.lblInfo.Text = String.Empty;

            HttpResponseMessage Response;

            try
            {
                Response = await RestClient.GetNews(0);
            }
            catch
            {
                this.lblInfo.ForeColor = Color.Red;
                this.lblInfo.Text = "An unexpected error has occurred";
                return;
            }

            if (Response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                this.lblInfo.ForeColor = Color.Red;
                this.lblInfo.Text = "No news found";
            }
            else if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                System.Text.Json.JsonSerializerOptions JOptions = new();
                JOptions.WriteIndented = true;
                string TempString;

                try
                {
                    TempString = await JsonParseMethods.ParseToObjectFromWebResponse<string>(Response);
                }
                catch
                {
                    this.lblInfo.ForeColor = Color.Red;
                    this.lblInfo.Text = "An unexpected error has occurred";
                    return;
                }


                TempString = TempString.Replace(@"\n", @"\\n");
                News CurrentNews = JsonParseMethods.ParseToObjectFromJsonSynchronous<News>(TempString, JOptions);
                CurrentNews.Content = CurrentNews.Content.Replace(@"\n", Environment.NewLine);

                this.txtBoxTitle.Text = CurrentNews.Title;
                this.txtBoxContent.Text = CurrentNews.Content;
            }

            UserPut CurrentUserPut = new UserPut
            {
                UserID = CurrentUser.UserID,
            };

            Response = await RestClient.GetMostRecentCard(CurrentUserPut);
            try
            {

                this.RecentCard = await System.Text.Json.JsonSerializer.DeserializeAsync<GetRecentCard>(await Response.Content.ReadAsStreamAsync());
                SetImageProperties(RecentCard.ThisCard);

                this.pctBoxCardImage.Image = Image.FromStream(new MemoryStream(this.RecentCard.ThisCardImage));

                if (!string.IsNullOrWhiteSpace(this.RecentCard.ThisCard.Properties.CardFrame))
                    this.pctBoxCardFrame.Image = Image.FromStream(new MemoryStream(this.RecentCard.ThisFrame.FrameImage));
            }
            catch
            {
                this.lblInfo.ForeColor = Color.Red;
                this.lblInfo.Text = "No card found";
            }
        }


        private void btnViewCard_Click(object sender, EventArgs e)
        {
            if (this.RecentCard == null)
                return;

            MainForm.RequestNewForm(new ViewCardForm(this.RecentCard.ThisCard, CurrentUser, this));
        }

#if false
        private void btnCreateTradeRequest_Click(object sender, EventArgs e)
        {
            //MainForm.RequestNewForm(new CreateTradeRequestForm(CurrentUser))
        }
#endif

        private void btnCreateNewCollection_Click(object sender, EventArgs e)
        {
            MainForm.RequestNewForm(new CreateCollectionForm(CurrentUser, this));
        }


#endregion

#region Helper methods

        public void SetImageProperties(Card CurrentUserCard)
        {
            this.lblCardIDText.Text = CurrentUserCard.CardID.ToString();
            this.lblCardNameText.Text = CurrentUserCard.CardName;
            this.lblCardRarityText.Text = CurrentUserCard.Properties.CardRarity;
            this.lblCardNicknameText.Text = CurrentUserCard.Properties.CardNickname;
            this.lblCardFrameText.Text = CurrentUserCard.Properties.CardFrame;
            this.lblDateObtainedText.Text = DateOnly.FromDateTime((DateTime)CurrentUserCard.DateObtained).ToString();
        }


#endregion


    }
}
