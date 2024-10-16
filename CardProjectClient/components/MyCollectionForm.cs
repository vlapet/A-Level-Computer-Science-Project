using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardProjectClient.client;
using CardProjectClient.game;
using CardProjectClient.lib;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace CardProjectClient.components
{
    public partial class MyCollectionForm : Form, IImageHelper, IImageHelperExtensions
    {
        User CurrentUser;
        List<string> StringCollections;
        Collection CurrentCollection = new Collection();
        List<int> CardsOnScreenIndex = new List<int>();
        List<int> CardsRemovedIndex = new List<int>();
        int PageCount;
        private bool FromOtherForm = false;

        public MyCollectionForm(User CurrentUser)
        {
            this.CurrentUser = CurrentUser;
            InitializeComponent();

            this.leftMenuBar1.CurrentUser = this.CurrentUser;
        }

        public MyCollectionForm(User CurrentUser, Collection CurrentCollection)
        {
            this.FromOtherForm = true;
            this.CurrentCollection = CurrentCollection;
            this.CurrentUser = CurrentUser;
            InitializeComponent();

            this.leftMenuBar1.CurrentUser = this.CurrentUser;
        }

        private async void MyCollectionForm_Load(object sender, EventArgs e)
        {
            PageCount = 0;

            this.lblCollectionInfo.Text = String.Empty;

            UserPut NewCurrentUser = new UserPut
            {
                Forename = null,
                Surname = null,
                Username = this.CurrentUser.Username,
                Password = null,
                DateOfBirth = null,
                UserID = this.CurrentUser.UserID
            };

            var response = await RestClient.GetAllUserCollections(NewCurrentUser);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                this.lblCollectionInfo.ForeColor = Color.Blue;
                this.lblCollectionInfo.Text = "No collections found";
                return;
            }
            else if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                this.lblCollectionInfo.ForeColor = Color.Red;
                this.lblCollectionInfo.Text = "An unexpected error has occured";
                return;
            }

            //List<string> Collections = JsonConvert.DeserializeObject<List<string>>(await response.Content.ReadAsStringAsync());
            //List<string> Collections = System.Text.Json.JsonSerializer.Deserialize<List<string>>(await response.Content.ReadAsStringAsync());
            List<string> Collections = await JsonParseMethods.ParseToObjectFromWebResponse<List<string>>(response);
            this.StringCollections = Collections;

            this.CmbBoxSelectCollection.Items.AddRange(Collections.ToArray());
            UpdateCardsOnScreenIndex();

            if (this.FromOtherForm)
            {
                Console.WriteLine("Called if");


                int LocationIndex = CmbBoxSelectCollection.Items.IndexOf(CurrentCollection.CollectionName);

                this.CmbBoxSelectCollection.SelectedIndex = LocationIndex;

                GetCollection UserGetCollection = new GetCollection
                {
                    CollectionName = this.CurrentCollection.CollectionName,
                    UserID = this.CurrentUser.UserID
                };


                FromOtherForm = false;
                ShowCollection(UserGetCollection);
            }
        }

        private void btnCreateCollection_Click(object sender, EventArgs e)
        {
            MainForm.RequestNewForm(new CreateCollectionForm(CurrentUser, this));
        }

        private async void btnSelectCollection_Click(object sender, EventArgs e)
        {
            PageCount = 0;

            if (string.IsNullOrWhiteSpace(this.CmbBoxSelectCollection.Text))
            {
                SetLabel(ref this.lblCollectionInfo, Color.Red, "No collection selected");
                return;
            }
            int SelectedCollectionIndex = this.CmbBoxSelectCollection.SelectedIndex;

            GetCollection UserGetCollection = new GetCollection
            {
                UserID = CurrentUser.UserID,
                CollectionName = this.CmbBoxSelectCollection.Text
            };

            ShowCollection(UserGetCollection);
        }

        private void btnCollectionOpt_1_Click(object sender, EventArgs e)
        {
            RemoveCardFromCollection(1);
        }

        private void btnCollectionOpt_2_Click(object sender, EventArgs e)
        {
            RemoveCardFromCollection(2);
        }

        private async void btnNextView_Click(object sender, EventArgs e)
        {
            // TODO: Test this when feature to delete cards is added
            Console.WriteLine($"Current Page count: {PageCount}");
            if (this.CurrentCollection.Cards == null)
                return;

            if ((PageCount + 1) * 2 < this.CurrentCollection.Cards.Count - 1)
            {
                bool OutOfBounds = false;
                byte[] ImageData_2 = null;
                this.PageCount++;
                Console.WriteLine($"PageCount * 2: {PageCount * 2}\t Cards.Count: {this.CurrentCollection.Cards.Count}");

                var Response = await RestClient.GetSingleCardImage(this.CurrentCollection.Cards[PageCount * 2].CardName);
                byte[] ImageData_1 = JsonConvert.DeserializeObject<byte[]>(await Response.Content.ReadAsStringAsync());

                var Response2 = await RestClient.GetSingleCardImage(this.CurrentCollection.Cards[(PageCount * 2) + 1].CardName);
                ImageData_2 = JsonConvert.DeserializeObject<byte[]>(await Response2.Content.ReadAsStringAsync());



                Console.WriteLine("Cards");
                foreach (Card c in this.CurrentCollection.Cards.GetRange(PageCount * 2, 2))
                    Console.Write(c.CardName);

                Console.WriteLine("Using LINQ");
                foreach (Card c in this.CurrentCollection.Cards.Skip(PageCount * 2).Take(2).ToList())
                    Console.Write(c.CardName);

                UpdateCardsOnScreenIndex();

                //this.CardsOnScreenIndex = this.Cards.GetRange(PageCount * 3, 3));

                foreach (Card c in this.CurrentCollection.Cards.GetRange(PageCount * 2, 2))
                {
                    Console.WriteLine(c.CardName);
                }
                //SetAllPictureBoxes(ImageDataMultiple);

                this.pctBoxCardImage_1.Image = Image.FromStream(new MemoryStream(ImageData_1));
                SetImageProperties(1, this.CurrentCollection.Cards[PageCount * 2]);

                this.pctBoxCardImage_2.Image = Image.FromStream(new MemoryStream(ImageData_2));
                SetImageProperties(2, this.CurrentCollection.Cards[(PageCount * 2) + 1]);

            }
            else if ((PageCount + 1) * 2 <= this.CurrentCollection.Cards.Count - 1)
            {
                // If problems with getting card index use Cards.Skip(PageNumber).Take(3).ToList()

                var CurrentResponse1 = await RestClient.GetSingleCardImage(this.CurrentCollection.Cards[(PageCount + 1) * 2].CardName);
                byte[] CurrentImageData1 = JsonConvert.DeserializeObject<byte[]>(await CurrentResponse1.Content.ReadAsStringAsync());
                this.pctBoxCardImage_1.Image = Image.FromStream(new MemoryStream(CurrentImageData1));
                SetImageProperties(1, this.CurrentCollection.Cards[(PageCount + 1) * 2]);
                SetImageProperties(2, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty);


                this.pctBoxCardImage_2.Image = null;
                this.btnCollectionOpt_2.Text = "Remove";

                /*
                this.lblCardNameText_2.Text = String.Empty;
                this.lblCardIDText_2.Text = String.Empty;
                this.lblCardRarityText_2.Text = String.Empty;
                this.lblCardFrameText_2.Text = String.Empty;
                this.lblCardNicknameText_2.Text = String.Empty;
                */
                PageCount++;

                UpdateCardsOnScreenIndex();
                this.CardsOnScreenIndex.RemoveAt(1);
            }
        }

        private async void btnPreviousView_Click(object sender, EventArgs e)
        {
            if (PageCount == 0)
                return;

            PageCount--;

            var Response = await RestClient.GetSingleCardImage(this.CurrentCollection.Cards[PageCount * 2].CardName);
            byte[] ImageData_1 = JsonConvert.DeserializeObject<byte[]>(await Response.Content.ReadAsStringAsync());

            var Response2 = await RestClient.GetSingleCardImage(this.CurrentCollection.Cards[(PageCount * 2) + 1].CardName);
            byte[] ImageData_2 = JsonConvert.DeserializeObject<byte[]>(await Response2.Content.ReadAsStringAsync());
            Console.WriteLine($"Cards.GetRange(PageCount * 3, 3): ");
            foreach (Card c in CurrentCollection.Cards.GetRange(PageCount * 2, 2))
            {
                Console.WriteLine(c.CardName);
            }

            UpdateCardsOnScreenIndex();

            this.pctBoxCardImage_1.Image = Image.FromStream(new MemoryStream(ImageData_1));
            this.pctBoxCardImage_2.Image = Image.FromStream(new MemoryStream(ImageData_2));

            SetImageProperties(1, CurrentCollection.Cards[PageCount * 2]);
            SetImageProperties(2, CurrentCollection.Cards[(PageCount * 2) + 1]);
            return;
        }

        private void btnCancelRemoved_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.CmbBoxCardsRemoved.Text) || this.CardsRemovedIndex.Count == 0)
            {
                this.lblCollectionInfo.Text = "No cards have been selected";
                return;
            }

            Console.WriteLine($"CardsSelectedOnScreenIndex: {string.Join(" ", this.CardsOnScreenIndex)}");

            int CardSelectedIndex = this.CardsRemovedIndex[this.CmbBoxCardsRemoved.SelectedIndex];
            Console.WriteLine($"CardsSelectedIndex: {CardSelectedIndex}");

            this.CardsRemovedIndex.RemoveAt(this.CmbBoxCardsRemoved.SelectedIndex);

            //if (this.CardsOnScreenIndex.Contains(CardSelectedIndex))
            if (this.CardsOnScreenIndex.ContainsElement(CardSelectedIndex))
            {
                switch (CardSelectedIndex % 2)
                {
                    case 0:
                        this.btnCollectionOpt_1.Text = "Remove";
                        break;
                    case 1:
                        this.btnCollectionOpt_2.Text = "Remove";
                        break;

                }
            }

            this.lblCollectionInfo.Text = String.Empty;
            this.CmbBoxCardsRemoved.Text = String.Empty;
            this.CmbBoxCardsRemoved.Items.RemoveAt(this.CmbBoxCardsRemoved.SelectedIndex);
        }

        /// <summary>
        /// Apply changes to collection selected
        /// Send information to API
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnApplyChanges_Click(object sender, EventArgs e)
        {
            List<Card> RemovedCards = new List<Card>();
            bool CollectionIsPublic = this.chBoxIsPublic.Checked;
            string? NewName;

            if (string.IsNullOrWhiteSpace(this.txtBoxNewName.Text))
                NewName = null;
            else
                NewName = this.txtBoxNewName.Text;

            foreach (int CardRemove in this.CardsRemovedIndex)
                RemovedCards.Add(this.CurrentCollection.Cards[CardRemove]);

            UpdateCollection UpdateUserCollection = new UpdateCollection
            {
                IsPublic = CollectionIsPublic,
                NewCollectionName = NewName,
                CardsRemoved = RemovedCards,
                CollectionID = CurrentCollection.CollectionID
            };

            var Response = await RestClient.UpdateCollection(UpdateUserCollection);

            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                this.lblCollectionInfo.ForeColor = Color.Blue;
                this.lblCollectionInfo.Text = "Successfully modified collection";

                /*

                PageCount = 0;
                UpdateCardsOnScreenIndex();

                SetImageProperties(1, "", "", "", "", "");
                SetImageProperties(2, "", "", "", "", "");

                CmbBoxCardsRemoved.Items.Clear();
                CmbBoxSelectCollection.Items.Clear();
                */

                MainForm.RequestNewForm(new MyCollectionForm(CurrentUser));

                //TEST THIS CODE
            }
        }

        private void btnDeleteCollection_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.CmbBoxSelectCollection.Text))
            {
                this.lblCollectionInfo.ForeColor = Color.Red;
                this.lblCollectionInfo.Text = "No collection selected";
                return;
            }

            MainForm.RequestNewForm(new ConfirmCollectionDeletion(CurrentUser, CurrentCollection, this));
        }

        #region Helper functions

        private async void ShowCollection(GetCollection UserGetCollection)
        {
            var Response = await RestClient.GetUserCollection(UserGetCollection);

            this.CurrentCollection = System.Text.Json.JsonSerializer.Deserialize<Collection>(await Response.Content.ReadAsStringAsync());

            HttpResponseMessage Response2;
            List<byte[]> CurrentImageData = new List<byte[]>();

            Console.Write($"C__: {CurrentCollection.CollectionName}\tC_ID: {CurrentCollection.CollectionID}\tC_Count: {CurrentCollection.Cards.Count}\tCC_IDs:");
            foreach (Card x in this.CurrentCollection.Cards)
                Console.Write("_ " + x.CardID);

            Console.WriteLine();

            if (this.CurrentCollection.IsPublic == true)
                this.chBoxIsPublic.Checked = true;
            else
                this.chBoxIsPublic.Checked = false;

            if (this.CurrentCollection.Cards.Count == 0)
            {
                this.lblCollectionInfo.ForeColor = Color.Red;
                this.lblCollectionInfo.Text = "No cards found";
                return;
            }
            else if (this.CurrentCollection.Cards.Count == 1)
            {
                Response2 = await RestClient.GetSingleCardImage(this.CurrentCollection.Cards.First().CardName);
                CurrentImageData.Add(System.Text.Json.JsonSerializer.Deserialize<byte[]>(await Response2.Content.ReadAsStringAsync()));
                this.pctBoxCardImage_1.Image = Image.FromStream(new MemoryStream(CurrentImageData.First()));

                SetImageProperties(1, this.CurrentCollection.Cards.First());

                this.pctBoxCardImage_2.Image = null;
                SetImageProperties(2, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty);
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    Response2 = await RestClient.GetSingleCardImage(this.CurrentCollection.Cards[i].CardName);
                    CurrentImageData.Add(System.Text.Json.JsonSerializer.Deserialize<byte[]>(await Response2.Content.ReadAsStringAsync()));
                }

                this.pctBoxCardImage_1.Image = Image.FromStream(new MemoryStream(CurrentImageData[0]));
                this.pctBoxCardImage_2.Image = Image.FromStream(new MemoryStream(CurrentImageData[1]));
                SetImageProperties(1, this.CurrentCollection.Cards[0]);
                SetImageProperties(2, this.CurrentCollection.Cards[1]);
            }



        }

        private void SetLabel(ref Label SetLabel, Color LabelColour, string LabelText)
        {
            SetLabel.ForeColor = LabelColour;
            SetLabel.Text = LabelText;
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
                    //if (!this.CardsRemovedIndex.Contains(PageCount * 2))
                    if (!this.CardsRemovedIndex.ContainsElement(PageCount * 2))
                    {
                        this.btnCollectionOpt_1.Text = "Remove";
                    }
                    else
                    {
                        this.btnCollectionOpt_1.Text = "Add";
                    }
                    return;
                case 2:
                    this.lblCardNameText_2.Text = CurrentCard.CardName;
                    this.lblCardIDText_2.Text = CurrentCard.CardID.ToString();
                    this.lblCardRarityText_2.Text = CurrentCard.Properties.CardRarity;
                    this.lblCardFrameText_2.Text = CurrentCard.Properties.CardFrame;
                    this.lblCardNicknameText_2.Text = CurrentCard.Properties.CardNickname;
                    //if (!this.CardsRemovedIndex.Contains((PageCount * 2) + 1))
                    if (!this.CardsRemovedIndex.ContainsElement((PageCount * 2) + 1))
                    {
                        this.btnCollectionOpt_2.Text = "Remove";
                    }
                    else
                    {
                        this.btnCollectionOpt_2.Text = "Add";
                    }
                    return;
            }
        }

        public void SetImageProperties(int WhichImageData, string CardName, string CardID, string CardRarity, string CardFrame, string CardNickname)
        {
            switch (WhichImageData)
            {
                // Changed .Contains for .ContainsElement
                case 1:
                    this.lblCardNameText_1.Text = CardName;
                    this.lblCardIDText_1.Text = CardID.ToString();
                    this.lblCardRarityText_1.Text = CardRarity;
                    this.lblCardFrameText_1.Text = CardFrame;
                    this.lblCardNicknameText_1.Text = CardNickname;
                    if (!this.CardsRemovedIndex.ContainsElement(PageCount * 2))
                    {
                        this.btnCollectionOpt_1.Text = "Remove";
                    }
                    else
                    {
                        this.btnCollectionOpt_1.Text = "Add";
                    }
                    return;
                case 2:
                    this.lblCardNameText_2.Text = CardName;
                    this.lblCardIDText_2.Text = CardID.ToString();
                    this.lblCardRarityText_2.Text = CardRarity;
                    this.lblCardFrameText_2.Text = CardFrame;
                    this.lblCardNicknameText_2.Text = CardNickname;
                    if (!this.CardsRemovedIndex.ContainsElement((PageCount * 2) + 1))
                    {
                        this.btnCollectionOpt_2.Text = "Remove";
                    }
                    else
                    {
                        this.btnCollectionOpt_2.Text = "Add";
                    }
                    return;
            }
        }

        private void UpdateCardsOnScreenIndex()
        {
            this.CardsOnScreenIndex.Clear();

            for (int i = PageCount * 2; i < (PageCount * 2) + 2; i++)
                this.CardsOnScreenIndex.Add(i);
        }

        public void RemoveCardFromCollection(int AddButtonIndex)
        {
            // Change .Contains for .ContainsElement
            switch (AddButtonIndex)
            {
                case 1:
                    if (!this.CardsRemovedIndex.ContainsElement(PageCount * 2))
                    {
                        this.CardsRemovedIndex.Add(PageCount * 2);
                        this.btnCollectionOpt_1.Text = "Add";
                    }
                    else
                    {
                        this.CardsRemovedIndex.Remove(PageCount * 2);
                        this.btnCollectionOpt_1.Text = "Remove";
                    }
                    break;
                case 2:
                    if ((PageCount * 2) + 1 >= CurrentCollection.Cards.Count)
                        return;

                    if (!this.CardsRemovedIndex.ContainsElement((PageCount * 2) + 1))
                    {
                        this.CardsRemovedIndex.Add((PageCount * 2) + 1);
                        this.btnCollectionOpt_2.Text = "Add";
                    }
                    else
                    {
                        this.CardsRemovedIndex.Remove((PageCount * 2) + 1);
                        this.btnCollectionOpt_2.Text = "Remove";
                    }
                    break;

            }

            UpdateComboBox();
        }

        private void UpdateComboBox()
        {
            this.CmbBoxCardsRemoved.Items.Clear();

            if (this.CardsRemovedIndex.Count == 0)
                return;


            foreach (int Number in CardsRemovedIndex)
                this.CmbBoxCardsRemoved.Items.Add($"{CurrentCollection.Cards[Number].CardName}      {CurrentCollection.Cards[Number].CardID}");
        }




        #endregion


    }
}
