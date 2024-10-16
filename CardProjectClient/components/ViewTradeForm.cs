using CardProjectClient.client;
using CardProjectClient.game;
using CardProjectClient.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardProjectClient.components
{
    public partial class ViewTradeForm : Form
    {
        // Could use bool but enum is more clear
        public enum TradeType
        {
            Sent,
            Incoming
        }

        TradeType CurrentTradeType;

        List<Card> UserFromCards = new List<Card>();
        List<Card> UserToCards = new List<Card>();

        User CurrentUser;

        TradeSearch CurrentTradeSearch;

        public ViewTradeForm(User CurrentUser, TradeSearch CurrentTradeSearch, TradeType SearchTradeType)
        {
            this.CurrentTradeType = SearchTradeType;
            this.CurrentTradeSearch = CurrentTradeSearch;
            this.CurrentUser = CurrentUser;

            InitializeComponent();

            this.lblInfo.Text = String.Empty;
        }

        private async void ViewTradeForm_Load(object sender, EventArgs e)
        {
            this.txtBoxTradeName.Text = CurrentTradeSearch.TradeName;

            switch (CurrentTradeType)
            {
                case TradeType.Sent:
                    // Get cards sent in trade id and CurrentTrade.UserFrom

                    this.btnAccept_Delete.Text = "Delete Request";
                    this.btnDeny.Hide();

                    HttpResponseMessage Response;

                    try
                    {
                        Response = await RestClient.GetUserCardsInSentTrade(CurrentTradeSearch);
                    }
                    catch
                    {
                        this.lblInfo.ForeColor = Color.Red;
                        this.lblInfo.Text = "An unexpected error has occurred";
                        return;
                    }
                    Trade CurrentTrade = System.Text.Json.JsonSerializer.Deserialize<Trade>(await Response.Content.ReadAsStringAsync());

                    DataTable CardGiveDataTable = Methods.GetDataTableFromCard(CurrentTrade.CardsGiven, false);
                    DataTable CardReceiveDataTable = Methods.GetDataTableFromCard(CurrentTrade.CardsReceived, false);

                    this.dgvCardsGive.DataSource = CardGiveDataTable;
                    this.dgvCardsReceive.DataSource = CardReceiveDataTable;

                    Response.Dispose();

                    break;
                case TradeType.Incoming:

                    this.btnAccept_Delete.Text = "Accept Request";
                    this.btnDeny.Show();

                    try
                    {
                        Response = await RestClient.GetUserCardsInSentTrade(CurrentTradeSearch);
                    }
                    catch
                    {
                        this.lblInfo.ForeColor = Color.Red;
                        this.lblInfo.Text = "An unexpected error has occurred";
                        return;
                    }

                    CurrentTrade = System.Text.Json.JsonSerializer.Deserialize<Trade>(await Response.Content.ReadAsStringAsync());

                    CardGiveDataTable = Methods.GetDataTableFromCard(CurrentTrade.CardsGiven, false);
                    CardReceiveDataTable = Methods.GetDataTableFromCard(CurrentTrade.CardsReceived, false);

                    this.dgvCardsGive.DataSource = CardReceiveDataTable;
                    this.dgvCardsReceive.DataSource = CardGiveDataTable;

                    Response.Dispose();

                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainForm.RequestNewForm(new SearchForm(this.CurrentUser));
        }

        private async void btnAccept_Delete_Click(object sender, EventArgs e)
        {
            this.lblInfo.ForeColor = Color.Blue;
            this.lblInfo.Text = "Processing";

            switch (CurrentTradeType)
            {
                case TradeType.Sent:                    
                    var Response = await RestClient.DeleteTradeRequest(CurrentTradeSearch);

                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        this.lblInfo.ForeColor = Color.Blue;
                        this.lblInfo.Text = "Trade deleted successfully";
                        ClearForm();
                    }    
                    break;
                case TradeType.Incoming:
                    try
                    {
                        Response = await ProcessTrade(TradeResponseEnum.Accept);
                    }
                    catch
                    {
                        this.lblInfo.ForeColor = Color.Blue;
                        this.lblInfo.Text = "An unexpected error has occurred";
                        return;
                    }
                    
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        this.lblInfo.ForeColor = Color.Blue;
                        this.lblInfo.Text = "Trade accepted successfully";
                        ClearForm();
                    }
                    break;

            }
        }

        private async void btnDeny_Click(object sender, EventArgs e)
        {
            if (CurrentTradeType == TradeType.Sent)
                return;

            this.lblInfo.ForeColor = Color.Blue;
            this.lblInfo.Text = "Processing";

            HttpResponseMessage Response;

            try
            {
                Response = await ProcessTrade(TradeResponseEnum.Deny);
            }
            catch
            {
                this.lblInfo.ForeColor = Color.Red;
                this.lblInfo.Text = "An unexpected error has occurred";
                return;
            }


            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                this.lblInfo.ForeColor = Color.Blue;
                this.lblInfo.Text = "Trade denied successfully";
                ClearForm();
            }
        }

        #region Helper Functions

        private async Task<HttpResponseMessage> ProcessTrade(TradeResponseEnum UserTradeResponse)
        {
            TradeAcceptDeny CurrentTradeAcceptDeny = new TradeAcceptDeny
            {
                CurrentTradeSearch = this.CurrentTradeSearch,
                TradeResponse = UserTradeResponse
            };

            return await RestClient.AcceptDenyTradeRequest(CurrentTradeAcceptDeny);
        }

        // Clears DataGridViews and disables buttons
        private void ClearForm()
        {
            this.dgvCardsGive.DataSource = null;
            this.dgvCardsReceive.DataSource = null;
            this.txtBoxTradeName.Text = String.Empty;

            this.btnAccept_Delete.Enabled = false;
            this.btnDeny.Enabled = false;
        }



#endregion

    }
}
