using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProjectAPI.game
{
    /// <summary>
    /// Used to store a trade
    /// </summary>
    public class Trade
    {
        private string _TradeName;
        private List<Card> _CardsGiven;
        private List<Card> _CardsReceived;
        private DateTime _DateRequested;
        private int _UserFromID;
        private int _UserToID;

        public Trade()
        {

        }

        #region Helper functions

        public string TradeName
        {
            get => this._TradeName;
            set => this._TradeName = value;
        }

        public List<Card> CardsGiven
        {
            get => this._CardsGiven;
            set => this._CardsGiven = value;
        }

        public List<Card> CardsReceived
        {
            get => this._CardsReceived;
            set => this._CardsReceived = value;
        }

        public DateTime DateRequested
        {
            get => this._DateRequested;
            set => this._DateRequested = value;
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

        #endregion
    }

    /// <summary>
    /// Used to store whether user accepts or denies the trade request
    /// </summary>
    public enum TradeResponseEnum
    {
        Accept,
        Deny
    }
}
