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
using CardProjectClient.client;
using System.Runtime.ConstrainedExecution;
using Newtonsoft.Json;
using CardProjectClient.lib;
using System.Runtime.InteropServices;

namespace CardProjectClient.components
{
    public partial class ViewCardForm : Form, IImageCore
    {
        public enum FromAvailable
        {
            NotFromAvailable,
            AvailableCardView,
            AvailableFrameView
        }

        object PreviousForm;
        Card CurrentCard;
        User CurrentUser;
        List<GetFrames> UserFrames = new List<GetFrames>();
        List<string> UserCollections = new List<string>();
        List<Collection> UserCollectionsWithCard = new List<Collection>();

        AvailableCardSearch? CurrentCardSearch = null;
        string? FrameName = null;

        FromAvailable IsFromAvailable;

        public ViewCardForm(Card CurrentCard, User CurrentUser, object PreviousForm)
        {
            InitializeComponent();
            this.PreviousForm = PreviousForm;
            this.CurrentCard = CurrentCard;
            this.CurrentUser = CurrentUser;
            this.lblViewCardInfo.Text = String.Empty;
            this.IsFromAvailable = FromAvailable.NotFromAvailable;
        }

        public ViewCardForm(User CurrentUser, object PreviousForm, AvailableCardSearch CurrentCardSearch)
        {
            InitializeComponent();
            this.PreviousForm = PreviousForm;
            this.CurrentCard = CurrentCard;
            this.CurrentUser = CurrentUser;
            this.lblViewCardInfo.Text = String.Empty;
            this.IsFromAvailable = FromAvailable.AvailableCardView;
            this.CurrentCardSearch = CurrentCardSearch;
        }

        public ViewCardForm(User CurrentUser,  object PreviousForm, string FrameName)
        {
            InitializeComponent();
            this.PreviousForm = PreviousForm;
            this.CurrentCard = CurrentCard;
            this.CurrentUser = CurrentUser;
            this.lblViewCardInfo.Text = String.Empty;
            this.IsFromAvailable = FromAvailable.AvailableFrameView;
            this.FrameName = FrameName;
        }

        private async void ViewCardForm_Load(object sender, EventArgs e)
        {
            // This is only called when the user requests to see a card or frame retrieve from searching for available cards or frames
            if (IsFromAvailable == FromAvailable.AvailableCardView || IsFromAvailable == FromAvailable.AvailableFrameView)
            {
                IsFromAvailableView();

                return;
            }

            HttpResponseMessage Response;

            try
            {
                Response = await RestClient.GetSingleCardImage(CurrentCard.CardName);
            }
            catch
            {
                this.lblViewCardInfo.ForeColor = Color.Red;
                this.lblViewCardInfo.Text = "An unexpected error has occurred";
                return;
            }
            //byte[] ImageData = System.Text.Json.JsonSerializer.Deserialize<byte[]>(await Response.Content.ReadAsStringAsync());
            byte[] ImageData = await JsonParseMethods.ParseToObjectFromWebResponse<byte[]>(Response);

            this.pctBoxCardImage.Image = Image.FromStream(new MemoryStream(ImageData));
            SetImageProperties(this.CurrentCard);

            UserPut CurrentUserPut = new UserPut
            {
                UserID = CurrentUser.UserID
            };

            this.cmbBoxSetCardFrame.Items.Add("(None)");
            this.cmbBoxAddToCollection.Items.Add("(None)");
            this.cmbBoxRemoveFromCollection.Items.Add("(None)");

            this.cmbBoxSetCardFrame.SelectedIndex = 0;
            this.cmbBoxAddToCollection.SelectedIndex = 0;
            this.cmbBoxRemoveFromCollection.SelectedIndex = 0;

            Response = await RestClient.GetAllCollectionsWithCard(CurrentCard);
            this.UserCollectionsWithCard = System.Text.Json.JsonSerializer.Deserialize<List<Collection>>(await Response.Content.ReadAsStringAsync());
            this.cmbBoxRemoveFromCollection.Items.AddRange(this.UserCollectionsWithCard.Select(x => x.CollectionName).ToArray());

            Response = await RestClient.GetAllUserCollections(CurrentUserPut);

            // TODO: TEST THIS - SEEMS TO BE WORKING
            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                this.UserCollections = JsonConvert.DeserializeObject<List<string>>(await Response.Content.ReadAsStringAsync());
                List<string> TempCollections = this.UserCollections.Select(CurrentCollectionString =>
                {
                    if (!UserCollectionsWithCard.Select(x => x.CollectionName).ContainsElement(CurrentCollectionString))
                        return CurrentCollectionString;

                    return null;
                }).Where(x => x != null).ToList();
                

                this.UserCollections = TempCollections;

                this.cmbBoxAddToCollection.Items.AddRange(this.UserCollections.ToArray());
            }


            Response = await RestClient.GetAllUserFrames(CurrentUserPut);
            List<GetFrames> GetUserFrames = System.Text.Json.JsonSerializer.Deserialize<List<GetFrames>>(await Response.Content.ReadAsStringAsync());

            // Only display available frames
            foreach (GetFrames CurrentFrame in GetUserFrames)
            {
                if (CurrentFrame.CardID == null)
                    this.UserFrames.Add(CurrentFrame);
            }

            this.cmbBoxSetCardFrame.Items.AddRange(this.UserFrames.Select(x => x.FrameName).ToArray());

            if (string.IsNullOrWhiteSpace(this.CurrentCard.Properties.CardFrame))
            {
                return;
            }

            Response = await RestClient.GetSingleCardFrame(CurrentCard.Properties.CardFrame);
            //byte[] FrameImage = System.Text.Json.JsonSerializer.Deserialize<byte[]>(await Response.Content.ReadAsStringAsync());
            byte[] FrameImage = await JsonParseMethods.ParseToObjectFromWebResponse<byte[]>(Response);

            this.pctBoxCardFrame.Image = Image.FromStream(new MemoryStream(FrameImage));


            //throw new NotImplementedException();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm.RequestNewForm(new SearchForm(CurrentUser));
        }

        private async void btnApply_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(this.txtBoxSetCardNickname.Text) && string.IsNullOrWhiteSpace(this.cmbBoxSetCardFrame.SelectedItem.ToString()))
            {
                this.lblViewCardInfo.ForeColor = Color.Red;
                this.lblViewCardInfo.Text = "No properties have been changed";
            }

            Console.WriteLine($"{cmbBoxAddToCollection.SelectedItem.ToString()}\t{cmbBoxRemoveFromCollection.SelectedItem.ToString()}");

            if (cmbBoxAddToCollection.SelectedItem == cmbBoxRemoveFromCollection.SelectedItem && cmbBoxAddToCollection.SelectedItem != "(None)" && cmbBoxAddToCollection.SelectedItem != "(None)")
            {
                this.lblViewCardInfo.ForeColor = Color.Red;
                this.lblViewCardInfo.Text = "Cannot add to same collection that card is being removed from";
                return;
            }

            UpdateCard NewCardUpdate = new UpdateCard
            {
                UserID = CurrentUser.UserID,
                CardID = int.Parse(CurrentCard.CardID.ToString()),
                CardNickname = string.IsNullOrWhiteSpace(this.txtBoxSetCardNickname.Text) ? null : this.txtBoxSetCardNickname.Text,
                AddToCollection = cmbBoxAddToCollection.SelectedItem == null || string.IsNullOrWhiteSpace(cmbBoxAddToCollection.SelectedItem.ToString()) || cmbBoxAddToCollection.SelectedItem.ToString() == "(None)" ? null : this.cmbBoxAddToCollection.SelectedItem.ToString(),
                RemoveFromCollection = cmbBoxRemoveFromCollection.SelectedItem == null || string.IsNullOrWhiteSpace(cmbBoxRemoveFromCollection.SelectedItem.ToString()) || cmbBoxRemoveFromCollection.SelectedItem.ToString() == "(None)" ? null : this.cmbBoxRemoveFromCollection.SelectedItem.ToString(), 
                CardFrame = cmbBoxSetCardFrame.SelectedItem == null || string.IsNullOrWhiteSpace(cmbBoxSetCardFrame.SelectedItem.ToString()) || cmbBoxSetCardFrame.SelectedItem.ToString() == "(None)" ? null : this.cmbBoxSetCardFrame.SelectedItem.ToString(),
                CardFrameID = cmbBoxSetCardFrame.SelectedItem == null || string.IsNullOrWhiteSpace(cmbBoxSetCardFrame.SelectedItem.ToString()) || cmbBoxSetCardFrame.SelectedItem.ToString() == "(None)" ? null : UserFrames.ElementAt(cmbBoxSetCardFrame.SelectedIndex - 1).FrameID
            };

            // TODO: TEST THIS CODE

            var Response = await RestClient.UpdateCard(NewCardUpdate);

            if (Response.StatusCode == System.Net.HttpStatusCode.MethodNotAllowed)
            {
                this.lblViewCardInfo.ForeColor = Color.Red;
                this.lblViewCardInfo.Text = "Frame is already attached to another card - disallowed";
                return;
            }
            else if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                this.lblViewCardInfo.ForeColor = Color.Blue;
                this.lblViewCardInfo.Text = "Properties updated successfully";

                if (!String.IsNullOrWhiteSpace(NewCardUpdate.CardNickname))
                    this.CurrentCard.Properties.CardNickname = NewCardUpdate.CardNickname;

                if (!String.IsNullOrWhiteSpace(NewCardUpdate.CardFrame))
                    this.CurrentCard.Properties.CardFrame = NewCardUpdate.CardFrame;

                MainForm.RequestNewForm(new ViewCardForm(this.CurrentCard, this.CurrentUser, PreviousForm));
            }
        }

        #region Helper Functions

        public void SetImageProperties(Card CurrentUserCard)
        {
            this.lblCardIDText.Text = CurrentUserCard.CardID.ToString();
            this.lblCardNameText.Text = CurrentUserCard.CardName;
            this.lblCardRarityText.Text = CurrentUserCard.Properties.CardRarity;
            this.lblCardNicknameText.Text = CurrentUserCard.Properties.CardNickname;
            this.lblCardFrameText.Text = CurrentUserCard.Properties.CardFrame;
            this.lblDateObtainedText.Text = CurrentUserCard.DateObtained.ToString();
        }


        private async void IsFromAvailableView()
        {
            this.lblSetCardNickname.Text = String.Empty;
            this.lblSetCardFrame.Text = String.Empty;
            this.lblRemoveFromCollection.Text = String.Empty;
            this.lblAddToCollection.Text = String.Empty;

            this.lblCardID.Text = String.Empty;
            this.lblCardIDText.Text = String.Empty;
            this.lblCardNickname.Text = String.Empty;
            this.lblCardNicknameText.Text = String.Empty;
            this.lblDateObtained.Text = String.Empty;
            this.lblDateObtainedText.Text = String.Empty;

            this.cmbBoxAddToCollection.Hide();
            this.cmbBoxRemoveFromCollection.Hide();
            this.cmbBoxSetCardFrame.Hide();
            this.txtBoxSetCardNickname.Hide();

            this.btnApply.Hide();

            if (this.CurrentCardSearch != null)
            {
                this.lblCardFrame.Text = String.Empty;
                this.lblCardFrameText.Text = String.Empty;

                this.lblCardNameText.Text = CurrentCardSearch.CardName;
                this.lblCardRarityText.Text = CurrentCardSearch.CardRarity;


                var Response = await RestClient.GetSingleCardImage(CurrentCardSearch.CardName);
                byte[] ImageData = await JsonParseMethods.ParseToObjectFromWebResponse<byte[]>(Response);

                this.pctBoxCardImage.Image = Image.FromStream(new MemoryStream(ImageData));
            }
            else if (this.FrameName != null)
            {
                this.lblCardName.Text = String.Empty;
                this.lblCardNameText.Text = String.Empty;
                this.lblCardRarity.Text = String.Empty;
                this.lblCardRarityText.Text = String.Empty;

                this.lblCardFrameText.Text = FrameName;

                var Response = await RestClient.GetSingleCardFrame(FrameName);
                byte[] FrameImage = await JsonParseMethods.ParseToObjectFromWebResponse<byte[]>(Response);

                this.pctBoxCardFrame.Image = Image.FromStream(new MemoryStream(FrameImage));
            }
        }


        #endregion


    }
}
