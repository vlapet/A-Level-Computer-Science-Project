using CardProjectAPI.game;
using CardProjectAPI.lib;
using Newtonsoft.Json;

namespace CardProjectAPI.api
{
    public class UserGet
    {
        public string Username { get; set; }
        public string Password { get; set; }

        [JsonConstructor]
        public UserGet (string username, string password)
        {
            Username = username;
            Password = password;
        }
    }

    /// <summary>
    /// Model class used for converting user properties to Json
    /// <para> This class is used during the process of converting all user properties except UserID to json </para> 
    /// <para> Need to parse to DateTime as Newtosoft does not support DateOnly </para>
    /// </summary>
    public class UserPost
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }

        [JsonConstructor]
        public UserPost(string forename, string surname, string username, string password, DateTime date_of_birth)
        {
            Forename = forename;
            Surname = surname;
            Username = username;
            Password = password;
            DateOfBirth = date_of_birth;
        }
    }

    /// <summary>
    /// Similar to UserPost but every attribute is nullable
    /// </summary>
    public class UserPut
    {
        public string? Forename { get; set; }
        public string? Surname { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? UserID { get; set; }

        [JsonConstructor]
        public UserPut(string? forename, string? surname, string? username, string? password, DateTime? date_of_birth, int? userID)
        {
            Forename = forename;
            Surname = surname;
            Username = username;
            Password = password;
            DateOfBirth = date_of_birth;
            UserID = userID;
        }

        public UserPut()
        {

        }
    }

    /// <summary>
    /// Class used to store card details while being sent from client to server
    /// </summary>
    public class AddCard
    {
        private byte[] _CardImage;
        private string _CardName;
        private string _CardRarity;

        public AddCard()
        {
            
        }

        #region Private Accessors

        public byte[] CardImage
        {
            get => this._CardImage;
            set => this._CardImage = value;
        }

        public string CardName
        {
            get => this._CardName;
            set => this._CardName = value;
        }

        public string CardRarity
        {
            get => this._CardRarity;
            set => this._CardRarity = value;
        }

        #endregion

    }

    /// <summary>
    /// Class used to store card details while being sent from client to server
    /// </summary>
    public class AddFrame
    {
        public byte[] FrameImage { get; set; }
        public string FrameName { get; set; }

        [JsonConstructor]
        public AddFrame(byte[] cardImage, string cardName)
        {
            this.FrameImage = cardImage;
            this.FrameName = cardName;
        }

        public AddFrame()
        {

        }
    }

    /// <summary>
    /// Model class used for containing card information during card drops
    /// </summary>
    public class CardDropCards
    {
        public string CardRarity { get; set; }
        public string ImageTitle { get; set; }  // Image title is CardName
        public byte[] ImageData { get; set; }
        public int CardID { get; set; }

        public CardDropCards(string cardRarity, string imageTitle, byte[] ImageData, int cardID)
        {
            this.CardRarity = cardRarity;
            this.ImageTitle = imageTitle;
            this.ImageData = ImageData;
            this.CardID = cardID;
        }
    }

    /// <summary>
    /// Model class used for containing frame data
    /// </summary>
    public class CardDropFrame
    {
        public string FrameName { get; set; }
        public byte[] FrameImageData { get; set; }
        public int FrameID { get; set; }

        public CardDropFrame()
        {

        }
    }

    /// <summary>
    /// Model class used for sending card drop data
    /// </summary>
    public class CardDrop
    {
        public List<CardDropCards> Cards { get; set; }
        public CardDropFrame Frame { get; set; }
    }

    /// <summary>
    /// Model class used for retrieving a specific collection
    /// </summary>
    public class GetCollection
    {
        private string _CollectionName;
        private int _UserID;

        public GetCollection()
        {

        }

        #region Private Accessors

        public string CollectionName
        {
            get => _CollectionName;
            set => _CollectionName = value;
        }

        public int UserID
        {
            get => _UserID;
            set => _UserID = value;
        }
        #endregion

    }

    /// <summary>
    /// Model class used for updating an existing collection
    /// </summary>
    public class UpdateCollection
    {
        private bool _IsPublic;
        private string? _NewCollectionName;
        private List<Card>? _CardsRemoved;
        private int _CollectionID;

        public UpdateCollection()
        {

        }

        #region Private Accessors

        public bool IsPublic
        {
            get => _IsPublic;
            set => _IsPublic = value;
        }

        public string? NewCollectionName
        {
            get => _NewCollectionName;
            set => _NewCollectionName = value;
        }

        public List<Card>? CardsRemoved
        {
            get => _CardsRemoved;
            set => _CardsRemoved = value;
        }

        public int CollectionID
        {
            get => _CollectionID;
            set => _CollectionID = value;
        }

        #endregion

    }

    /// <summary>
    /// Model class used to send search request
    /// </summary>
    public class NewSearch
    {
        private string? _SearchKeyword;
        private SearchTypes _SearchType;
        private int _UserID;

        public NewSearch()
        {

        }

        #region Private Accessors

        public string? SearchKeyword
        {
            get => _SearchKeyword;
            set => _SearchKeyword = value;
        }

        public SearchTypes SearchType
        {
            get => _SearchType;
            set => _SearchType = value;
        }

        public int UserID
        {
            get => _UserID;
            set => _UserID = value;
        }

        #endregion
    }


    /// <summary>
    /// Model class used to return results when searching for a user
    /// </summary>
    public class UserSearchResults
    {
        private string _Username;
        private DateTime _DateOfBirth;
        private int _UserID;

        public UserSearchResults()
        {

        }

        #region Private Accessors

        public string Username
        {
            get => _Username;
            set => _Username = value;
        }

        public DateTime DateOfBirth
        {
            get => _DateOfBirth;
            set => _DateOfBirth = value;
        }

        public int UserID
        {
            get => _UserID;
            set => _UserID = value;
        }

        #endregion
    }

    /// <summary>
    /// Model class used for return collections from search query
    /// </summary>
    public class CollectionSearchResults
    {
        private int _CollectionID;
        private string _CollectionName;
        private bool _IsPublic;
        private DateTime _DateCreated;

        public CollectionSearchResults()
        {

        }

        #region Private Accessors

        public int CollectionID
        {
            get => _CollectionID;
            set => _CollectionID = value;
        }

        public string CollectionName
        {
            get => _CollectionName;
            set => _CollectionName = value;
        }

        public bool IsPublic
        {
            get => _IsPublic;
            set => _IsPublic = value;
        }

        public DateTime DateCreated
        {
            get => _DateCreated;
            set => _DateCreated = value;
        }

        #endregion
    }

    /// <summary>
    /// Model class used for updating card properties
    /// </summary>
    public class UpdateCard
    {
        private int _UserID;
        private int _CardID;
        private string? _CardNickname;
        private string? _CardFrame;
        private string? _AddToCollection;
        private string? _RemoveFromCollection;
        private int? _CardFrameID;

        public UpdateCard()
        {

        }

        #region Private Accessors

        public int UserID
        {
            get => _UserID;
            set => _UserID = value;
        }

        public int CardID
        {
            get => _CardID;
            set => _CardID = value;
        }

        public string? CardNickname
        {
            get => _CardNickname;
            set => _CardNickname = value;
        }

        public string? CardFrame
        {
            get => _CardFrame;
            set => _CardFrame = value;
        }

        public string? AddToCollection
        {
            get => _AddToCollection;
            set => _AddToCollection = value;
        }

        public string? RemoveFromCollection
        {
            get => _RemoveFromCollection;
            set => _RemoveFromCollection = value;
        }

        public int? CardFrameID
        {
            get => _CardFrameID;
            set => _CardFrameID = value;
        }

        #endregion
    }

    /// <summary>
    /// Model class used for getting user frames
    /// </summary>
    public class GetFrames
    {
        private string _FrameName;
        private int _FrameID;
        private int? _CardID;

        public GetFrames()
        {

        }

        #region Private Accessors

        public string FrameName
        {
            get => _FrameName;
            set => _FrameName = value;
        }

        public int FrameID
        {
            get => _FrameID;
            set => _FrameID = value;
        }

        public int? CardID
        {
            get => _CardID;
            set => _CardID = value;
        }


        #endregion
    }

    /// <summary>
    /// Model class used to send Trade search results
    /// </summary>
    public class TradeSearch
    {
        private string _TradeName;
        private int _UserFromID;
        private int _UserToID;
        private DateTime _DateRequested;
        private int _TradeID;

        public TradeSearch()
        {

        }

        #region Private Accessors

        public string TradeName
        {
            get => this._TradeName;
            set => this._TradeName = value;
        }

        public int UserFromID
        {
            get => this._UserFromID;
            set => this._UserFromID = value;
        }

        public int UserToID
        {
            get => this._UserToID;
            set => this._UserToID = value;
        }

        public DateTime DateRequested
        {
            get => this._DateRequested;
            set => this._DateRequested = value;
        }

        public int TradeID
        {
            get => this._TradeID;
            set => this._TradeID = value;
        }

        #endregion
    }

    /// <summary>
    /// Model class used to store current trade request (stored in TradeSearch model class) and to store whether user accepts request or not
    /// </summary>
    public class TradeAcceptDeny
    {
        private TradeResponseEnum _TradeResponse;
        private TradeSearch _CurrentTradeSearch;

        public TradeAcceptDeny()
        {

        }

        #region Private Accessors

        public TradeResponseEnum TradeResponse
        {
            get => this._TradeResponse;
            set => this._TradeResponse = value;
        }

        public TradeSearch CurrentTradeSearch
        {
            get => this._CurrentTradeSearch;
            set => this._CurrentTradeSearch = value;
        }

        #endregion
    }

    /// <summary>
    /// Model class used for getting the most recent card
    /// <para>Uses 'Card' and 'AddFrame' classes to store requered data</para>
    /// </summary>
    public class GetRecentCard
    {
        private Card _ThisCard;
        private AddFrame _ThisFrame;
        private byte[] _ThisCardImage;

        public GetRecentCard()
        {

        }

        #region Private Accessors

        public Card ThisCard
        {
            get => this._ThisCard;
            set => this._ThisCard = value;
        }

        public AddFrame ThisFrame
        {
            get => this._ThisFrame;
            set => this._ThisFrame = value;
        }

        public byte[] ThisCardImage
        {
            get => this._ThisCardImage;
            set => this._ThisCardImage = value;
        }

        #endregion
    }

    /// <summary>
    /// Model class used to send available card search results
    /// </summary>
    public class AvailableCardSearch
    {
        private string _CardName;
        private string _CardRarity;

        public AvailableCardSearch()
        {

        }

        public string CardName
        {
            get => _CardName;
            set => _CardName = value;
        }

        public string CardRarity
        {
            get => _CardRarity;
            set => _CardRarity = value;
        }

    }
}
