using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProjectClient.game
{
    public class Card
    {
        private int? _CardID;
        private string? _CardName;
        private string? _CardHash;
        private DateTime? _DateObtained;
        private int? _UserID;

        private CardProperties _Properties = new CardProperties();

        #region Constructors

        public Card(int CardID, string CardRarity)
        {
            this._CardID = CardID;
            this._Properties.CardRarity = CardRarity;
        }

        public Card (int CardID, string CardRarity, string CardName, DateTime DateObtained, int UserID)
        {
            this._CardID = CardID;
            this._Properties.CardRarity = CardRarity;
            this._CardName = CardName;
            this._CardHash = null;
            this._DateObtained = DateObtained;
            this._UserID = UserID;
        }

        public Card(int CardID, string CardRarity, string CardName, string CardHash, DateTime DateObtained, int UserID)
        {
            this._CardID = CardID;
            this._Properties.CardRarity = CardRarity;
            this._CardName = CardName;
            this._CardHash = CardHash;
            this._DateObtained = DateObtained;
            this._UserID = UserID;
        }

        /// <summary>
        /// Set all attributes of a card
        /// </summary>
        /// <param name="CardID"></param>
        /// <param name="CardRarity"></param>
        /// <param name="CardName"></param>
        /// <param name="CardHash"></param>
        /// <param name="DateObtained"></param>
        /// <param name="UserID"></param>
        /// <param name="CardFrame"></param>
        /// <param name="CardNickname"></param>
        [JsonConstructor]
        public Card(int CardID, string CardRarity, string CardName, string CardHash, DateTime DateObtained, int UserID, string CardFrame, string CardNickname)
        {
            this._CardID = CardID;
            this._CardName = CardName;
            this._CardHash = CardHash;
            this._DateObtained = DateObtained;
            this._UserID = UserID;
            this._Properties.CardRarity = CardRarity;
            this._Properties.CardNickname = CardNickname;
            this._Properties.CardFrame = CardFrame;
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Card()
        {

        }

        #endregion

        #region Private Accessors

        public int? CardID
        {
            get => this._CardID;
            set => this._CardID = value;
        }

        public string? CardName
        {
            get => this._CardName;
            set => this._CardName = value;
        }

        public string? CardHash
        {
            get => this._CardHash;
            set => this._CardHash = value;
        }


        public DateTime? DateObtained
        {
            get => this._DateObtained; 
            set => this._DateObtained = value;
        }

        public int? UserID
        {
            get => this._UserID;
            set => this._UserID = value;
        }

        public CardProperties Properties
        {
            get => _Properties;
            set => _Properties = value;
        }

        #endregion


    }
}
