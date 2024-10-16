using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardProjectClient.client;
using CardProjectClient.game;
using Newtonsoft.Json;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using CardProjectClient.lib;

namespace CardProjectClient.components
{
    public partial class CreateCollectionForm : Form, IImageHelper
    {
        User CurrentUser;
        //MyCollectionForm PreviousForm;
        object PreviousForm;
        //List<string> Collections;
        List<int> CardsAddedToCollectionIndex = new List<int>();
        List<int> CardsOnScreenIndex = new List<int>();
        List<Card> Cards;
        int PageCount;

        public CreateCollectionForm(User currentUser, /*MyCollectionForm previousForm*/ object previousForm /*, List<string> collections*/)
        {
            InitializeComponent();
            this.CurrentUser = currentUser;
            this.PreviousForm = previousForm;
            //this.Collections = collections;

            this.lblCardsSelected.Text = "";
        }

        /// <summary>
        /// Gets list of all user cards when form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CreateCollectionForm_Load(object sender, EventArgs e)
        {
            this.PageCount = 0;

            UserPut NewCurrentUser = new UserPut
            {
                Forename = this.CurrentUser.Forename,
                Surname = this.CurrentUser.Surname,
                Username = this.CurrentUser.Username,
                Password = null,
                DateOfBirth = this.CurrentUser.DateOfBirth.ToDateTime(TimeOnly.Parse("00:00AM")),
                UserID = this.CurrentUser.UserID
            };

            var response = await RestClient.GetAllUserCards(NewCurrentUser);
            Console.WriteLine($"Response: {response}");

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                this.lblSelectCards.ForeColor = Color.Red;
                this.lblSelectCards.Text = "An unexpected error has occurred";
                return;
            }

            this.Cards = JsonConvert.DeserializeObject<List<Card>>(await response.Content.ReadAsStringAsync());

            Console.WriteLine("Cards: ");
            foreach (Card c in this.Cards)
            {
                Console.Write($"{c.CardName} ");
            }
            Console.WriteLine($"\nCards.Count: {Cards.Count}");

            switch (Cards.Count)
            {
                case 0:
                    this.lblSelectCards.ForeColor = Color.Red;
                    this.lblSelectCards.Text = "No cards found, please gain cards before attempting to create a collection";
                    return;
                case 1:
                    var NewResponse = await RestClient.GetSingleCardImage(this.Cards.First().CardName);
                    byte[] ImageData = JsonConvert.DeserializeObject<byte[]>(await NewResponse.Content.ReadAsStringAsync());
                    this.pctBoxCardImage_1.Image = Image.FromStream(new MemoryStream(ImageData));
                    this.CardsOnScreenIndex.Clear();
                    this.CardsOnScreenIndex.Add(0);
                    return;
                case 2:
                    var Response1 = await RestClient.GetSingleCardImage(Cards.First().CardName);
                    var Response2 = await RestClient.GetSingleCardImage(Cards[1].CardName);
                    byte[] ImageData1 = JsonConvert.DeserializeObject<byte[]>(await Response1.Content.ReadAsStringAsync());
                    byte[] ImageData2 = JsonConvert.DeserializeObject<byte[]>(await Response2.Content.ReadAsStringAsync());
                    this.pctBoxCardImage_1.Image = Image.FromStream(new MemoryStream(ImageData1));
                    this.pctBoxCardImage_2.Image = Image.FromStream(new MemoryStream(ImageData2));
                    this.CardsOnScreenIndex.AddRange(new List<int> { 0, 1});
                    return;
                case int i when i >= 3:
                    var NewResponse2 = await RestClient.GetThreeCardImages(Cards.GetRange(0, 3));
                    List<byte[]> ImageDataMultiple = JsonConvert.DeserializeObject <List<byte[]>>(await NewResponse2.Content.ReadAsStringAsync());
                    SetAllPictureBoxes(ImageDataMultiple);
                    SetImageProperties(1, Cards[0]);
                    SetImageProperties(2, Cards[1]);
                    SetImageProperties(3, Cards[2]);
                    this.CardsOnScreenIndex.AddRange(new List<int> { 0, 1, 2});
                    return;
                default:
                    this.lblSelectCards.ForeColor = Color.Red;
                    this.lblSelectCards.Text = "An unexpected error has occured";
                    return;
            }

        }

        /// <summary>
        /// Return to My Collections form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //MainForm.RequestNewForm(PreviousForm);
            MainForm.RequestNewForm(new MyCollectionForm(CurrentUser));
        }

        private async void btnCreateCollection_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtBoxCollectionName.Text))
            {
                this.lblSelectCards.ForeColor = Color.Red;
                this.lblSelectCards.Text = "Please enter a name for the collection";
                return;
            }

            List<Card> CardsSelected = new List<Card>();
            foreach (int CardIndex in CardsAddedToCollectionIndex)
                CardsSelected.Add(Cards[CardIndex]);

            if (CardsSelected.Count == 0)
            {
                this.lblSelectCards.ForeColor = Color.Red;
                this.lblSelectCards.Text = "No cards selected";
                return;
            }

            this.lblSelectCards.ForeColor = Color.Blue;
            this.lblSelectCards.Text = "Processing...";

            Collection NewCollection = new Collection
            {
                CollectionID = -1,
                UserID = CurrentUser.UserID,
                CollectionName = this.txtBoxCollectionName.Text,
                IsPublic = this.chBoxIsPublic.Checked,
                DateCreated = DateTime.Now,
                Cards = CardsSelected
            };

            HttpResponseMessage Response;

            try
            {
                Response = await RestClient.CreateCollection(NewCollection);
            }
            catch (HttpRequestException ex)
            {
                this.lblSelectCards.ForeColor = Color.Red;
                this.lblSelectCards.Text = "An error has occured";
                return;
            }

            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                this.lblSelectCards.ForeColor = Color.Blue;
                this.lblSelectCards.Text = "Collection created successfully";
            }
            else if (Response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                this.lblSelectCards.ForeColor = Color.Red;
                this.lblSelectCards.Text = "The collection already exists, please enter a different name";
            }
            else
            {
                this.lblSelectCards.ForeColor = Color.Red;
                this.lblSelectCards.Text = "An error has occured";
            }
        }

        /// <summary>
        /// Cycles to next three cards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnNext_Click(object sender, EventArgs e)
        {

            if ((this.Cards.Count - (PageCount + 1) * 3) > 0 && (this.Cards.Count - (PageCount + 1) * 3) < 2 && this.Cards.Count % 3 == 1)
            {
                this.PageCount++;

                var Response = await RestClient.GetSingleCardImage(this.Cards[PageCount * 3].CardName);
                byte[] ImageData_1 = JsonConvert.DeserializeObject<byte[]>(await Response.Content.ReadAsStringAsync());
                SetImageProperties(1, this.Cards[PageCount * 3]);
                this.pctBoxCardImage_1.Image = Image.FromStream(new MemoryStream(ImageData_1));

                SetImageProperties(2, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty);
                this.pctBoxCardImage_2.Image = null;

                SetImageProperties(3, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty);
                this.pctBoxCardImage_3.Image = null;
            }
            else if ((this.Cards.Count - (PageCount + 1) * 3) > 0 && (this.Cards.Count - (PageCount + 1) * 3) < 3 && this.Cards.Count % 3 == 2 )
            {
                this.PageCount++;

                var Response = await RestClient.GetSingleCardImage(this.Cards[PageCount * 3].CardName);
                byte[] ImageData_1 = JsonConvert.DeserializeObject<byte[]>(await Response.Content.ReadAsStringAsync());
                SetImageProperties(1, this.Cards[PageCount * 3]);
                this.pctBoxCardImage_1.Image = Image.FromStream(new MemoryStream(ImageData_1));

                var Response2 = await RestClient.GetSingleCardImage(this.Cards[(PageCount * 3) + 1].CardName);
                byte[] ImageData_2 = JsonConvert.DeserializeObject<byte[]>(await Response2.Content.ReadAsStringAsync());
                SetImageProperties(2, this.Cards[(PageCount * 3) + 1]);
                this.pctBoxCardImage_2.Image = Image.FromStream(new MemoryStream(ImageData_2));

                SetImageProperties(3, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty);
                this.pctBoxCardImage_3.Image = null;
            }
            else if ((PageCount + 1) * 3 <= this.Cards.Count - 1)
            {

                this.PageCount++;
                Console.WriteLine($"PageCount * 3: {PageCount * 3}\t Cards.Count: {Cards.Count}");

                var Response = await RestClient.GetThreeCardImages(this.Cards.GetRange(PageCount * 3, 3));
                List<byte[]> ImageDataMultiple = JsonConvert.DeserializeObject<List<byte[]>>(await Response.Content.ReadAsStringAsync());

                Console.WriteLine("Cards");
                foreach (Card c in Cards.GetRange(PageCount * 3, 3))
                    Console.Write(c.CardName);

                Console.WriteLine("Using LINQ");
                foreach (Card c in Cards.Skip(PageCount * 3).Take(3).ToList())
                    Console.Write(c.CardName);

                UpdateCardsOnScreenIndex();

                //this.CardsOnScreenIndex = this.Cards.GetRange(PageCount * 3, 3));

                foreach (Card c in Cards.GetRange(PageCount * 3, 3))
                {
                    Console.WriteLine(c.CardName);
                }
                SetAllPictureBoxes(ImageDataMultiple);
                SetImageProperties(1, Cards[PageCount * 3]);
                SetImageProperties(2, Cards[(PageCount * 3) + 1]);
                SetImageProperties(3, Cards[(PageCount * 3) + 2]);
            }
            else if ((PageCount + 1) * 3 + 2 <= this.Cards.Count - 1)
            {
                // If problems with getting card index use Cards.Skip(PageNumber).Take(3).ToList()

                var CurrentResponse1 = await RestClient.GetSingleCardImage(this.Cards[(PageCount + 1) * 3].CardName);
                var CurrentResponse2 = await RestClient.GetSingleCardImage(this.Cards[(PageCount + 1) * 3 + 1].CardName);
                byte[] CurrentImageData1 = JsonConvert.DeserializeObject<byte[]>(await CurrentResponse1.Content.ReadAsStringAsync());
                byte[] CurrentImageData2 = JsonConvert.DeserializeObject<byte[]>(await CurrentResponse2.Content.ReadAsStringAsync());
                this.pctBoxCardImage_1.Image = Image.FromStream(new MemoryStream(CurrentImageData1));
                this.pctBoxCardImage_2.Image = Image.FromStream(new MemoryStream(CurrentImageData2));
                PageCount++;
            }
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            if (PageCount == 0)
                return;

            PageCount--;

            var Response = await RestClient.GetThreeCardImages(this.Cards.GetRange(PageCount * 3, 3));
            List<byte[]> ImageDataMultiple = JsonConvert.DeserializeObject<List<byte[]>>(await Response.Content.ReadAsStringAsync());
            Console.WriteLine($"Cards.GetRange(PageCount * 3, 3): ");
            foreach (Card c in Cards.GetRange(PageCount * 3, 3))
            {
                Console.WriteLine(c.CardName);
            }

            UpdateCardsOnScreenIndex();

            SetAllPictureBoxes(ImageDataMultiple);
            SetImageProperties(1, Cards[PageCount * 3]);
            SetImageProperties(2, Cards[(PageCount * 3) + 1]);
            SetImageProperties(3, Cards[(PageCount * 3) + 1]);
            return;
        }

        private void btnAddToCollection_1_Click(object sender, EventArgs e)
        {
            AddCardToCollection(1);
        }

        private void btnAddToCollection_2_Click(object sender, EventArgs e)
        {
            AddCardToCollection(2);
        }

        private void btnAddToCollection_3_Click(object sender, EventArgs e)
        {
            AddCardToCollection(3);
        }

        private void btnRemoveCard_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(this.CmbBoxCardsAdded.Text) || this.CardsAddedToCollectionIndex.Count == 0)
            {
                this.lblCardsSelected.Text = "No cards have been selected";
                return;
            }

            Console.WriteLine($"CardsSelectedOnScreenIndex: {string.Join(" ", this.CardsOnScreenIndex)}");

            int CardSelectedIndex = this.CardsAddedToCollectionIndex[this.CmbBoxCardsAdded.SelectedIndex];
            Console.WriteLine($"CardsSelectedIndex: {CardSelectedIndex}");

            this.CardsAddedToCollectionIndex.RemoveAt(this.CmbBoxCardsAdded.SelectedIndex);

            if (this.CardsOnScreenIndex.Contains(CardSelectedIndex))
            {
                switch (CardSelectedIndex % 3)
                {
                    case 0:
                        this.btnAddToCollection_1.Text = "Add";
                        break;
                    case 1:
                        this.btnAddToCollection_2.Text = "Add";
                        break;
                    case 2:
                        this.btnAddToCollection_3.Text = "Add";
                        break;
                }
            }

            this.lblCardsSelected.Text = String.Empty;
            this.CmbBoxCardsAdded.Text = String.Empty;
            this.CmbBoxCardsAdded.Items.RemoveAt(this.CmbBoxCardsAdded.SelectedIndex);
        }

        #region Helper Functions

        private void SetAllPictureBoxes(List<byte[]> ImageData)
        {
            this.pctBoxCardImage_1.Image = Image.FromStream(new MemoryStream(ImageData[0]));
            this.pctBoxCardImage_2.Image = Image.FromStream(new MemoryStream(ImageData[1]));
            this.pctBoxCardImage_3.Image = Image.FromStream(new MemoryStream(ImageData[2]));
        }

        private void SetImageProperties(int WhichImageData, string CardName, string CardID, string CardRarity, string CardFrame, string CardNickname)
        {
            switch (WhichImageData)
            {
                case 1:
                    this.lblCardNameText_1.Text = CardName;
                    this.lblCardIDText_1.Text = CardID.ToString();
                    this.lblCardRarityText_1.Text = CardRarity;
                    this.lblCardFrameText_1.Text = CardFrame;
                    this.lblCardNicknameText_1.Text = CardNickname;
                    return;
                case 2:
                    this.lblCardNameText_2.Text = CardName;
                    this.lblCardIDText_2.Text = CardID.ToString();
                    this.lblCardRarityText_2.Text = CardRarity;
                    this.lblCardFrameText_2.Text = CardFrame;
                    this.lblCardNicknameText_2.Text = CardNickname;
                    return;
                case 3:
                    this.lblCardNameText_3.Text = CardName;
                    this.lblCardIDText_3.Text = CardID.ToString();
                    this.lblCardRarityText_3.Text = CardRarity;
                    this.lblCardFrameText_3.Text = CardFrame;
                    this.lblCardNicknameText_3.Text = CardNickname;
                    return;
            }
        }

        public void SetImageProperties(int WhichImageData, Card CurrentCard)
        {
            switch (WhichImageData)
            {
                case 1:
                    this.lblCardNameText_1.Text = CurrentCard.CardName;
                    this.lblCardIDText_1.Text = CurrentCard.CardID.ToString();
                    this.lblCardRarityText_1.Text = CurrentCard.Properties.CardRarity;
                    this.lblCardFrameText_1.Text = CurrentCard.Properties.CardFrame;
                    this.lblCardNicknameText_1.Text = CurrentCard.Properties.CardNickname;

                    if (!this.CardsAddedToCollectionIndex.Contains(PageCount * 3))
                    {
                        this.btnAddToCollection_1.Text = "Add";
                    }
                    else
                    {
                        this.btnAddToCollection_1.Text = "Remove";
                    }
                    return;
                case 2:
                    this.lblCardNameText_2.Text = CurrentCard.CardName;
                    this.lblCardIDText_2.Text = CurrentCard.CardID.ToString();
                    this.lblCardRarityText_2.Text = CurrentCard.Properties.CardRarity;
                    this.lblCardFrameText_2.Text = CurrentCard.Properties.CardFrame;
                    this.lblCardNicknameText_2.Text = CurrentCard.Properties.CardNickname;
                    if (!this.CardsAddedToCollectionIndex.Contains((PageCount * 3) + 1))
                    {
                        this.btnAddToCollection_2.Text = "Add";
                    }
                    else
                    {
                        this.btnAddToCollection_2.Text = "Remove";
                    }
                    return;
                case 3:
                    this.lblCardNameText_3.Text = CurrentCard.CardName;
                    this.lblCardIDText_3.Text = CurrentCard.CardID.ToString();
                    this.lblCardRarityText_3.Text = CurrentCard.Properties.CardRarity;
                    this.lblCardFrameText_3.Text = CurrentCard.Properties.CardFrame;
                    this.lblCardNicknameText_3.Text = CurrentCard.Properties.CardNickname;
                    if (!this.CardsAddedToCollectionIndex.Contains((PageCount * 3) + 2))
                    {
                        this.btnAddToCollection_3.Text = "Add";
                    }
                    else
                    {
                        this.btnAddToCollection_3.Text = "Remove";
                    }
                    return;
            }
        }

        public void AddCardToCollection(int AddButtonIndex)
        {
            if (this.CardsOnScreenIndex.Count == 0)
                return;

            switch (AddButtonIndex)
            {
                case 1:
                    if (!this.CardsAddedToCollectionIndex.Contains(PageCount * 3))
                    {
                        this.CardsAddedToCollectionIndex.Add(PageCount * 3);
                        this.btnAddToCollection_1.Text = "Remove";
                    }
                    else
                    {
                        this.CardsAddedToCollectionIndex.Remove(PageCount * 3);
                        this.btnAddToCollection_1.Text = "Add";
                    }
                    break;
                case 2:
                    if ((PageCount * 3) + 1 >= this.Cards.Count)
                        return;

                    if (!this.CardsAddedToCollectionIndex.Contains((PageCount * 3) + 1))
                    {
                        this.CardsAddedToCollectionIndex.Add((PageCount * 3) + 1);
                        this.btnAddToCollection_2.Text = "Remove";
                    }
                    else
                    {
                        this.CardsAddedToCollectionIndex.Remove((PageCount * 3) + 1);
                        this.btnAddToCollection_2.Text = "Add";
                    }
                    break;
                case 3:
                    if ((PageCount * 3) + 2 >= this.Cards.Count)
                        return;

                    if (!this.CardsAddedToCollectionIndex.Contains((PageCount * 3) + 2))
                    {
                        this.CardsAddedToCollectionIndex.Add((PageCount * 3) + 2);
                        this.btnAddToCollection_3.Text = "Remove";
                    }
                    else
                    {
                        this.CardsAddedToCollectionIndex.Remove((PageCount * 3) + 2);
                        this.btnAddToCollection_3.Text = "Add";
                    }
                    break;
            }

            UpdateComboBox();
        }

        private void UpdateComboBox()
        {
            this.CmbBoxCardsAdded.Items.Clear();

            if (this.CardsAddedToCollectionIndex.Count == 0)
                return;

            if (this.CardsOnScreenIndex.Count == 0)
                return;


            foreach (int Number in CardsAddedToCollectionIndex)
                this.CmbBoxCardsAdded.Items.Add($"{Cards[Number].CardName}      {Cards[Number].CardID}");
        }

        private void UpdateCardsOnScreenIndex()
        {
            this.CardsOnScreenIndex.Clear();

            for (int i = PageCount * 3; i < (PageCount * 3) + 3; i++)
                this.CardsOnScreenIndex.Add(i);
        }

        #endregion


    }
}
