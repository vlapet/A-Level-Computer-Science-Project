using CardProjectAPI.game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CardProjectAPI.game
{
    public class Collection
    {
        private int _CollectionID;
        private int _UserID;
        private string _CollectionName;
        private bool _IsPublic;
        private DateTime _DateCreated;
        private List<Card> _Cards;

        #region Constructors

        public Collection(int collectionID, int userID, string collectionName, bool isPublic, DateTime dateCreated, List<Card> cards)
        {
            this._CollectionID = collectionID;
            this._UserID = userID;
            this._CollectionName = collectionName;
            this._IsPublic = isPublic;
            this._DateCreated = dateCreated;
            this._Cards = cards;
        }

        [JsonConstructor]
        public Collection()
        {

        }

        #endregion

        #region Private Accessors

        public int CollectionID
        {
            get => this._CollectionID;
            set => this._CollectionID = value;
        }

        public int UserID
        {
            get => this._UserID;
            set => this._UserID = value;
        }

        public string CollectionName
        {
            get => this._CollectionName;
            set => this._CollectionName = value;
        }

        public bool IsPublic
        {
            get => this._IsPublic;
            set => this._IsPublic = value;
        }

        public DateTime DateCreated
        {
            get => this._DateCreated;
            set => this._DateCreated = value;
        }

        public List<Card> Cards
        {
            get => this._Cards;
            set => this._Cards = value;
        }


        #endregion
    }
}

