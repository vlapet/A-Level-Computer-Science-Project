using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardProjectClient.client;
using CardProjectClient.game;
using CardProjectClient.lib;

namespace CardProjectClient.components
{
    public partial class CreateTradeRequestForm : Form
    {
        User CurrentUser;
        UserPut TradeUser;

        public CreateTradeRequestForm(User CurrentUser, UserPut TradeUser)
        {
            InitializeComponent();

            this.CurrentUser = CurrentUser;
            this.TradeUser = TradeUser;

            this.lblInfo.Text = String.Empty;
        }

        private async void CreateTradeRequestForm_Load(object sender, EventArgs e)
        {
            UserPut CurrentUserPut = new UserPut
            {
                UserID = CurrentUser.UserID,
            };


            HttpResponseMessage Response;
            HttpResponseMessage Response2;

            try
            {
                Response = await RestClient.GetUserFromTradeCards(CurrentUserPut);
                Response2 = await RestClient.GetAllTradeUserCards(TradeUser);
            }
            catch
            {
                this.lblInfo.ForeColor = Color.Red;
                this.lblInfo.Text = "An unexpected error has occurred";
                return;
            }

            List<Card> CurrentUserCards = System.Text.Json.JsonSerializer.Deserialize<List<Card>>(await Response.Content.ReadAsStringAsync());
            List<Card> TradeUserCards = System.Text.Json.JsonSerializer.Deserialize<List<Card>>(await Response2.Content.ReadAsStringAsync());

            Console.WriteLine(string.Join(", ", CurrentUserCards));
            Console.WriteLine(string.Join(", ", TradeUserCards));

            if (CurrentUserCards.Count == 0)
            {
                this.lblInfo.ForeColor = Color.Red;
                this.lblInfo.Text = "No cards found, please acquire cards before trading";
                this.btnCreateTradeRequest.Enabled = false;
                return;
            }
            else if (TradeUserCards.Count == 0)
            {
                this.lblInfo.ForeColor = Color.Red;
                this.lblInfo.Text = "The user you wish to trade with has no available cards";
                this.btnCreateTradeRequest.Enabled = false;
                return;
            }

            DataTable DTCurrentUser = Methods.GetDataTableFromCard(CurrentUserCards, true);
            this.dgvCardsGive.DataSource = DTCurrentUser;

            DataTable DTTradeUser = Methods.GetDataTableFromCard(TradeUserCards, true);
            this.dgvCardsReceive.DataSource = DTTradeUser;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainForm.RequestNewForm(new SearchForm(CurrentUser));
        }

        private async void btnCreateTradeRequest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxTradeName.Text))
            {
                this.lblInfo.ForeColor = Color.Red;
                this.lblInfo.Text = "Please input a trade name";
                return;
            }

            List<Card> CurrentUserSelectedCards = GetCardsFromDataGridView(this.dgvCardsGive, this.CurrentUser.UserID);
            List<Card> TradeUserSelectedCards = GetCardsFromDataGridView(this.dgvCardsReceive, (int)this.TradeUser.UserID);

            if (CurrentUserSelectedCards.Count == 0 || TradeUserSelectedCards.Count == 0)
            {
                this.lblInfo.ForeColor = Color.Red;
                this.lblInfo.Text = "Please select cards from both to trade";

                return;
            }

            this.lblInfo.ForeColor = Color.Blue;
            this.lblInfo.Text = "Processing";

            Trade NewTrade = new Trade
            {
                TradeName = this.txtBoxTradeName.Text,
                CardsGiven = CurrentUserSelectedCards,
                CardsReceived = TradeUserSelectedCards,
                UserFromID = CurrentUser.UserID,
                UserToID = (int)TradeUser.UserID
            };

            var Response = await RestClient.CreateNewTradeRequest(NewTrade);

            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                this.lblInfo.ForeColor = Color.Blue;
                this.lblInfo.Text = "Trade created successfully";

                this.btnCreateTradeRequest.Enabled = false;
            }
            else if (Response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                this.lblInfo.ForeColor = Color.Red;
                this.lblInfo.Text = "Trade request with that name already exists";
                return;
            }
            else if (Response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                this.lblInfo.ForeColor = Color.Red;
                this.lblInfo.Text = "Cards are already being used in another trade request";
                return;
            }

        }

        #region Helper Functions

        private static List<Card> GetCardsFromDataGridView(DataGridView CurrentDataGridView, int InputUserID)
        {
            List<Card> SelectedCards = new List<Card>();
            DataGridViewRow CurrentRow;

            for (int i = 0; i < CurrentDataGridView.RowCount; i++)
            {
                CurrentRow = CurrentDataGridView.Rows[i];

                if (Convert.ToBoolean(CurrentDataGridView.Rows[i].Cells[0].Value))
                    SelectedCards.Add(new Card
                    {
                        CardID = Convert.ToInt32(CurrentRow.Cells["CardID"].Value),
                        CardName = CurrentRow.Cells["Card Name"].Value.ToString(),
                        CardHash = CurrentRow.Cells["Card Hash"].Value.ToString(),
                        DateObtained = DateTime.Parse(CurrentRow.Cells["Date Obtained"].Value.ToString()),
                        UserID = InputUserID,
                        Properties = new CardProperties
                        {
                            CardRarity = CurrentRow.Cells["Card Rarity"].Value.ToString(),
                            CardFrame = CurrentRow.Cells["Card Frame"].Value.ToString(),
                            CardNickname = CurrentRow.Cells["Card Nickname"].Value.ToString()
                        }
                    });
            }

            return SelectedCards;
        }

        #endregion
    }
}
