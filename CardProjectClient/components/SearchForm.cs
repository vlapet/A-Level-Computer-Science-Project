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
using System.Net.Http;
using System.Reflection;
using CardProjectClient.lib;
using System.Runtime.CompilerServices;
using static CardProjectClient.lib.Extension_Methods;

namespace CardProjectClient.components
{
    public partial class SearchForm : Form
    {
        User CurrentUser;
        List<Card> UserCards = new List<Card>();
        List<News> AllNews = new List<News>();


        SearchTypes CurrentSearchType;
        SearchTypes PreviousSearchType;

        public SearchForm(User currentUser)
        {
            InitializeComponent();

            this.lblSearchInfo.Text = String.Empty;
            this.CurrentUser = currentUser;
            this.dataGridViewMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.leftMenuBar1.CurrentUser = this.CurrentUser;

            Console.WriteLine($"Current User: {CurrentUser}");
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {


            this.btnViewSelectedItem.Enabled = false;
            this.btnCreateTradeRequest.Enabled = false;
        }

        private void lblSearchObject_Click(object sender, EventArgs e)
        {

        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.CmbBoxSearchType.SelectedItem == null || string.IsNullOrWhiteSpace(this.CmbBoxSearchType.SelectedItem.ToString()))
            {
                this.lblSearchInfo.ForeColor = Color.Red;
                this.lblSearchInfo.Text = "No search type selected";
                return;
            }

            this.lblSearchInfo.ForeColor = Color.Blue;
            this.lblSearchInfo.Text = "Processing...";

            NewSearch NewSearchRequest = new NewSearch
            {
                //SearchType = this.CmbBoxSearchType.SelectedItem.ToString(),
                SearchType = (SearchTypes)this.CmbBoxSearchType.SelectedIndex,
                SearchKeyword = string.IsNullOrWhiteSpace(this.txtBoxSearchKeywords.Text) ? null : this.txtBoxSearchKeywords.Text,
                UserID = CurrentUser.UserID
            };

            HttpResponseMessage Response;
            try
            {
                Response = await RestClient.SearchObject(NewSearchRequest);
            }
            catch
            {
                this.lblSearchInfo.ForeColor = Color.Red;
                this.lblSearchInfo.Text = "An unexcpected error has occurred";
                return;
            }

            if (Response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                this.lblSearchInfo.ForeColor = Color.Red;
                this.lblSearchInfo.Text = "An unexpected error has occuered";
                return;
            }

            this.CurrentSearchType = NewSearchRequest.SearchType;

            string ResponseString = await Response.Content.ReadAsStringAsync();
            this.lblSearchInfo.Text = String.Empty;


            SetSearchResults(ResponseString);
        }

        private void btnViewSelectedItem_Click(object sender, EventArgs e)
        {
            if (!CheckInstantiated())
                return;

            if (string.IsNullOrWhiteSpace(CmbBoxSearchType.SelectedItem.ToString()))
            {
                this.lblSearchInfo.ForeColor = Color.Red;
                this.lblSearchInfo.Text = "No search type selected";
            }



            int SelectedIndex = this.dataGridViewMain.CurrentCell.RowIndex;
            DataGridViewRow SelectedRow = this.dataGridViewMain.Rows[SelectedIndex];


            switch (CurrentSearchType)
            {
                case SearchTypes.Cards:
                    Card CurrentCard = new Card
                    {
                        CardID = Convert.ToInt32(SelectedRow.Cells["CardID"].Value),
                        CardName = SelectedRow.Cells["Card Name"].Value.ToString(),
                        CardHash = SelectedRow.Cells["Card Hash"].Value.ToString(),
                        DateObtained = DateTime.Parse(SelectedRow.Cells["Date Obtained"].Value.ToString()),
                        Properties = new CardProperties
                        {
                            CardRarity = SelectedRow.Cells["Card Rarity"].Value.ToString(),
                            CardFrame = SelectedRow.Cells["Card Frame"].Value.ToString(),
                            CardNickname = SelectedRow.Cells["Card Nickname"].Value.ToString()
                        }
                    };

                    MainForm.RequestNewForm(new ViewCardForm(CurrentCard, CurrentUser, this));
                    break;
                case SearchTypes.Collections:
                    Collection CurrentCollection = new Collection
                    {
                        CollectionID = Convert.ToInt32(SelectedRow.Cells["CollectionID"].Value),
                        CollectionName = SelectedRow.Cells["Collection Name"].Value.ToString(),
                        IsPublic = SelectedRow.Cells["Is Public"].Value.ToString().ToLower() == "false" ? false : true,
                        DateCreated = DateTime.Parse(SelectedRow.Cells["Date Created"].Value.ToString()),
                        UserID = this.CurrentUser.UserID
                    };
                    MainForm.RequestNewForm(new MyCollectionForm(CurrentUser, CurrentCollection));
                    break;
                case SearchTypes.TradesSent:
                case SearchTypes.IncomingTrades:

                    TradeSearch CurrentTrade = new TradeSearch
                    {
                        TradeName = SelectedRow.Cells["Trade Name"].Value.ToString(),
                        UserFromID = Convert.ToInt32(SelectedRow.Cells["User from ID"].Value),
                        UserToID = Convert.ToInt32(SelectedRow.Cells["User to ID"].Value),
                        DateRequested = DateTime.Parse(SelectedRow.Cells["Date Requested"].Value.ToString()),
                        TradeID = Convert.ToInt32(SelectedRow.Cells["TradeID"].Value)
                    };

                    if (CurrentSearchType == SearchTypes.TradesSent)
                        MainForm.RequestNewForm(new ViewTradeForm(CurrentUser, CurrentTrade, ViewTradeForm.TradeType.Sent));
                    else if (CurrentSearchType == SearchTypes.IncomingTrades)
                        MainForm.RequestNewForm(new ViewTradeForm(CurrentUser, CurrentTrade, ViewTradeForm.TradeType.Incoming));

                    break;
                case SearchTypes.News:

                    News CurrentNews = new News
                    {
                        Title = SelectedRow.Cells["Title"].Value.ToString(),
                        DateCreated = DateTime.Parse(SelectedRow.Cells["Date Created"].Value.ToString())
                    };

                    int Page = AllNews.FindIndexOf(CurrentNews, true);

                    MainForm.RequestNewForm(new NewsForm(CurrentUser, Page, CurrentNews));

                    break;
                case SearchTypes.AvailableCards:

                    AvailableCardSearch CurrentCardSearch = new AvailableCardSearch
                    {
                        CardName = SelectedRow.Cells["Card Name"].Value.ToString(),
                        CardRarity = SelectedRow.Cells["Card Rarity"].Value.ToString()
                    };

                    MainForm.RequestNewForm(new ViewCardForm(CurrentUser, this, CurrentCardSearch));
                    
                    break;
                case SearchTypes.AvailableFrames:

                    string FrameName = SelectedRow.Cells["Frame Name"].Value.ToString();

                    MainForm.RequestNewForm(new ViewCardForm(CurrentUser, this, FrameName));

                    break;
            }
        }

        private void btnCreateTradeRequest_Click(object sender, EventArgs e)
        {
            if (!CheckInstantiated())
                return;

            if (this.CurrentSearchType != SearchTypes.Users)
            {
                this.lblSearchInfo.ForeColor = Color.Red;
                this.lblSearchInfo.Text = "Please select a user to trade with";
                return;
            }

            int SelectedIndex = this.dataGridViewMain.CurrentCell.RowIndex;
            var SelectedRow = this.dataGridViewMain.Rows[SelectedIndex];

            UserPut TradeUser = new UserPut
            {
                Username = SelectedRow.Cells["Username"].Value.ToString(),
                DateOfBirth = DateTime.Parse(SelectedRow.Cells["Date of Birth"].Value.ToString()),
                UserID = Convert.ToInt32(SelectedRow.Cells["UserID"].Value)
            };

            MainForm.RequestNewForm(new CreateTradeRequestForm(this.CurrentUser, TradeUser));
        }

        private void btnCreateCollection_Click(object sender, EventArgs e)
        {
            MainForm.RequestNewForm(new CreateCollectionForm(CurrentUser, this));
        }




        #region Helper Functions

        private async void SetSearchResults(string ResponseString)
        {
            Console.WriteLine($"Setting results: {ResponseString}");
            Console.WriteLine($"Cmb: {this.CmbBoxSearchType.Text}");

            DataTable DT = new DataTable();

            //switch (CmbBoxSearchType.SelectedItem.ToString())
            switch (this.CurrentSearchType)
            {
                //case "Users":
                case SearchTypes.Users:
                    // Fill table with users

                    List<UserSearchResults> Results = System.Text.Json.JsonSerializer.Deserialize<List<UserSearchResults>>(ResponseString);

                    DT.Columns.Add("Username", typeof(string));
                    DT.Columns.Add("Date of Birth", typeof(string));
                    DT.Columns.Add("UserID", typeof(int));

                    DataRow NewRow;

                    foreach (UserSearchResults CurrentResult in Results)
                    {
                        NewRow = DT.NewRow();
                        Console.WriteLine($"U: {CurrentResult.Username}\tD: {CurrentResult.DateOfBirth.ToShortDateString()}\tUi: {CurrentResult.UserID}");
                        NewRow["Username"] = CurrentResult.Username;
                        NewRow["Date of Birth"] = CurrentResult.DateOfBirth.ToShortDateString();
                        NewRow["UserID"] = CurrentResult.UserID;
                        DT.Rows.Add(NewRow);
                    }

                    //this.CurrentSearchType = SearchTypes.Users;
                    break;
                //case "Cards":
                case SearchTypes.Cards:
                    // Fill table with cards the current user has
                    List<Card> CardSearchResult = System.Text.Json.JsonSerializer.Deserialize<List<Card>>(ResponseString);
                    UserCards = CardSearchResult;

                    DT = Methods.GetDataTableFromCard(CardSearchResult, false);

                    //this.CurrentSearchType = SearchTypes.Cards;
                    break;
                //case "Collections":
                case SearchTypes.Collections:
                    // Show list of collections
                    // When user selects a collection - load collection form

                    List<CollectionSearchResults> NewCollectionSearchResults = System.Text.Json.JsonSerializer.Deserialize<List<CollectionSearchResults>>(ResponseString);

                    DT.Columns.AddRange(new DataColumn[]
                    {
                        new DataColumn("CollectionID"),
                        new DataColumn("Collection Name"),
                        new DataColumn("Is Public"),
                        new DataColumn("Date Created"),
                    });

                    foreach (CollectionSearchResults CurrentCollectionSearchResult in NewCollectionSearchResults)
                    {
                        NewRow = DT.NewRow();
                        NewRow["CollectionID"] = CurrentCollectionSearchResult.CollectionID;
                        NewRow["Collection Name"] = CurrentCollectionSearchResult.CollectionName;
                        NewRow["Is Public"] = CurrentCollectionSearchResult.IsPublic;
                        NewRow["Date Created"] = CurrentCollectionSearchResult.DateCreated.ToString();

                        DT.Rows.Add(NewRow);
                    }

                    this.CurrentSearchType = SearchTypes.Collections;
                    break;

                //case "Trades Sent":
                case SearchTypes.TradesSent:
                    
                    Console.WriteLine("\nSetting Trades sent\n");
                    List<TradeSearch> CurrentTradeSearchResult = System.Text.Json.JsonSerializer.Deserialize<List<TradeSearch>>(ResponseString);


                    DT.Columns.AddRange(new DataColumn[]
                    {
                        new DataColumn("Trade Name"),
                        new DataColumn("User from ID"),
                        new DataColumn("User to ID"),
                        new DataColumn("Date Requested"),
                        new DataColumn("TradeID"),
                    });

                    foreach (TradeSearch CurrentTradeSearch in CurrentTradeSearchResult)
                    {
                        NewRow = DT.NewRow();
                        NewRow["Trade Name"] = CurrentTradeSearch.TradeName;
                        NewRow["User from ID"] = CurrentTradeSearch.UserFromID;
                        NewRow["User to ID"] = CurrentTradeSearch.UserToID;
                        NewRow["Date Requested"] = CurrentTradeSearch.DateRequested.ToString();
                        NewRow["TradeID"] = CurrentTradeSearch.TradeID;

                        DT.Rows.Add(NewRow);
                    }

                    //this.CurrentSearchType = SearchTypes.TradesSent;
                    CurrentTradeSearchResult = new List<TradeSearch>();

                    break;
                //case "Incoming Trades":
                case SearchTypes.IncomingTrades:

                    CurrentTradeSearchResult = System.Text.Json.JsonSerializer.Deserialize<List<TradeSearch>>(ResponseString);

                    DT.Columns.AddRange(new DataColumn[]
                    {
                        new DataColumn("Trade Name"),
                        new DataColumn("User from ID"),
                        new DataColumn("User to ID"),
                        new DataColumn("Date Requested"),
                        new DataColumn("TradeID"),
                    });

                    foreach (TradeSearch CurrentTradeSearch in CurrentTradeSearchResult)
                    {
                        NewRow = DT.NewRow();
                        NewRow["Trade Name"] = CurrentTradeSearch.TradeName;
                        NewRow["User from ID"] = CurrentTradeSearch.UserFromID;
                        NewRow["User to ID"] = CurrentTradeSearch.UserToID;
                        NewRow["Date Requested"] = CurrentTradeSearch.DateRequested.ToString();
                        NewRow["TradeID"] = CurrentTradeSearch.TradeID;

                        DT.Rows.Add(NewRow);
                    }

                    //this.CurrentSearchType = SearchTypes.IncomingTrades;

                    break;
                //case "News":
                case SearchTypes.News:

                    this.AllNews = System.Text.Json.JsonSerializer.Deserialize<List<News>>(ResponseString);

                    DT.Columns.AddRange(new DataColumn[]
                    {
                        new DataColumn("Title"),
                        new DataColumn("Date Created")
                    });

                    foreach (News CurrentNews in this.AllNews)
                    {
                        NewRow = DT.NewRow();
                        NewRow["Title"] = CurrentNews.Title;
                        NewRow["Date Created"] = CurrentNews.DateCreated.ToString();

                        DT.Rows.Add(NewRow);
                    }

                    //this.CurrentSearchType = SearchTypes.News;

                    break;
                case SearchTypes.AvailableCards:
                    List<AvailableCardSearch> CurrentAvailableCardSearch = JsonParseMethods.ParseToObjectFromJsonSynchronous<List<AvailableCardSearch>>(ResponseString);

                    DT.Columns.AddRange(new DataColumn[]
                    {
                        new DataColumn("Card Name"),
                        new DataColumn("Card Rarity"),
                    });

                    foreach (AvailableCardSearch ThisAvailableCardSearch in CurrentAvailableCardSearch)
                    {
                        NewRow = DT.NewRow();
                        NewRow["Card Name"] = ThisAvailableCardSearch.CardName;
                        NewRow["Card Rarity"] = ThisAvailableCardSearch.CardRarity;

                        DT.Rows.Add(NewRow);
                    }

                    break;
                case SearchTypes.AvailableFrames:

                    List<string> Frames = JsonParseMethods.ParseToObjectFromJsonSynchronous<List<string>>(ResponseString);

                    DT.Columns.AddRange(new DataColumn[]
                    {
                        new DataColumn("Frame Name")
                    });

                    foreach (string ThisFrame in Frames)
                    {
                        NewRow = DT.NewRow();
                        NewRow["Frame Name"] = ThisFrame;

                        DT.Rows.Add(NewRow);
                    }
                    
                    break;
            }

            this.dataGridViewMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMain.DataSource = DT;

            UpdateButtons();
        }


        private bool CheckInstantiated()
        {
            if (this.dataGridViewMain.CurrentCell == null)
            {
                this.lblSearchInfo.ForeColor = Color.Red;
                this.lblSearchInfo.Text = "No row selected";
                return false;
            }

            return true;
        }

        private void UpdateButtons()
        {
            if (this.CurrentSearchType == SearchTypes.Users)
            {
                this.btnViewSelectedItem.Enabled = false;
                this.btnCreateTradeRequest.Enabled = true;
            }
            else
            {
                this.btnViewSelectedItem.Enabled = true;
                this.btnCreateTradeRequest.Enabled = false;
            }
        }


        #endregion


    }
}
