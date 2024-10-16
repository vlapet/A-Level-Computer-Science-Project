using CardProjectClient.client;
using Newtonsoft.Json;
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

namespace CardProjectClient.components
{
    public partial class CardDropForm : Form, IImageHelperExtensions
    {
        User CurrentUser;

        public CardDropForm(User currentUser)
        {
            InitializeComponent();
            CurrentUser = currentUser;

            this.leftMenuBar1.CurrentUser = this.CurrentUser;

            this.lblCardName_1.Text = String.Empty;
            this.lblCardName_2.Text = String.Empty;
            this.lblCardName_3.Text = String.Empty;

            this.lblCardNameContent_1.Text = String.Empty;
            this.lblCardNameContent_2.Text = String.Empty;
            this.lblCardNameContent_3.Text = String.Empty;

            this.lblCardID_1.Text = String.Empty;
            this.lblCardID_2.Text = String.Empty;
            this.lblCardID_3.Text = String.Empty;

            this.lblCardIDContent_1.Text = String.Empty;
            this.lblCardIDContent_2.Text = String.Empty;
            this.lblCardIDContent_3.Text = String.Empty;

            this.lblCardRarity_1.Text = String.Empty;
            this.lblCardRarity_2.Text = String.Empty;
            this.lblCardRarity_3.Text = String.Empty;

            this.lblCardRarityContent_1.Text = String.Empty;
            this.lblCardRarityContent_2.Text = String.Empty;
            this.lblCardRarityContent_3.Text = String.Empty;

            this.lblFrame.Text = String.Empty;
            this.lblFrameContent.Text = String.Empty;

            this.lblFrameID.Text = String.Empty;
            this.lblFrameIDContent.Text = String.Empty;
        }


        private async void btnCardDropNewCardDrop_Click(object sender, EventArgs e)
        {
            try
            {
                UserPut NewUserPut = new UserPut
                {
                    Forename = this.CurrentUser.Forename,
                    Surname = this.CurrentUser.Surname,
                    Username = this.CurrentUser.Username,
                    Password = null,
                    DateOfBirth = null,
                    UserID = this.CurrentUser.UserID
                };

                this.lblCardDropInfo.ForeColor = Color.Blue;
                this.lblCardDropInfo.Text = "Processing request";

                HttpResponseMessage response;

                try
                {
                    response = await RestClient.NewCardDrop(NewUserPut);
                }
                catch
                {
                    this.lblCardDropInfo.ForeColor = Color.Red;
                    this.lblCardDropInfo.Text = "An unexpected error has occurred";
                    return;
                }

                if (response.StatusCode == System.Net.HttpStatusCode.PreconditionFailed)
                {
                    TimeSpan CoolDownTimer = await JsonParseMethods.ParseToObjectFromWebResponse<TimeSpan>(response);
                    this.lblCardDropInfo.ForeColor = Color.Red;
                    this.lblCardDropInfo.Text = $"Unable to drop more cards as you still have {Math.Round(CoolDownTimer.TotalSeconds)} seconds left";
                    return;
                }

                CardDrop NewCardDrop = System.Text.Json.JsonSerializer.Deserialize<CardDrop>(await response.Content.ReadAsStringAsync());

                this.lblCardDropInfo.Text = String.Empty;

                // Adds image to picture boxes
                SetImageProperties(1, NewCardDrop.Cards[0].ImageTitle, NewCardDrop.Cards[0].CardID.ToString(), NewCardDrop.Cards[0].CardRarity);
                SetImageProperties(2, NewCardDrop.Cards[1].ImageTitle, NewCardDrop.Cards[1].CardID.ToString(), NewCardDrop.Cards[1].CardRarity);
                SetImageProperties(3, NewCardDrop.Cards[2].ImageTitle, NewCardDrop.Cards[2].CardID.ToString(), NewCardDrop.Cards[2].CardRarity);

                this.pctBoxCardDrop_1.Image = Image.FromStream(new MemoryStream(NewCardDrop.Cards[0].ImageData));
                this.pctBoxCardDrop_2.Image = Image.FromStream(new MemoryStream(NewCardDrop.Cards[1].ImageData));
                this.pctBoxCardDrop_3.Image = Image.FromStream(new MemoryStream(NewCardDrop.Cards[2].ImageData));

                this.lblFrame.Text = "Frame:";
                this.lblFrameContent.Text = NewCardDrop.Frame.FrameName;

                this.lblFrameID.Text = "Frame ID:";
                this.lblFrameIDContent.Text = NewCardDrop.Frame.FrameID.ToString();

                this.pctBoxFrame.Image = Image.FromStream(new MemoryStream(NewCardDrop.Frame.FrameImageData));
            }
            catch (Exception ex)
            {
                this.lblCardDropInfo.ForeColor = Color.Red;
                this.lblCardDropInfo.Text = "An unexpected error has occurred";
            }

            Console.WriteLine("Success");
        }

        #region Helper methods

        public void SetImageProperties(int WhichImageData, string CardName, string CardID, string CardRarity, string CardFrame = null, string CardNickname = null)
        {
            switch (WhichImageData)
            {
                case 1:
                    this.lblCardID_1.Text = "Card ID:";
                    this.lblCardIDContent_1.Text = CardID.ToString();

                    this.lblCardName_1.Text = "Card Name:";
                    this.lblCardNameContent_1.Text = CardName;

                    this.lblCardRarity_1.Text = "Rarity:";
                    this.lblCardRarityContent_1.Text = CardRarity;
                    break;
                case 2:
                    this.lblCardID_2.Text = "Card ID:";
                    this.lblCardIDContent_2.Text = CardID.ToString();

                    this.lblCardName_2.Text = "Card Name:";
                    this.lblCardNameContent_2.Text = CardName;

                    this.lblCardRarity_2.Text = "Rarity:";
                    this.lblCardRarityContent_2.Text = CardRarity;
                    break;
                case 3:
                    this.lblCardID_3.Text = "Card ID:";
                    this.lblCardIDContent_3.Text = CardID.ToString();

                    this.lblCardName_3.Text = "Card Name:";
                    this.lblCardNameContent_3.Text = CardName;

                    this.lblCardRarity_3.Text = "Rarity:";
                    this.lblCardRarityContent_3.Text = CardRarity;
                    break;
            }
        }

        #endregion
    }
}
