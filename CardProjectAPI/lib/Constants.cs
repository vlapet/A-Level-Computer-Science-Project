using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CardProjectAPI.lib
{
    /// <summary>
    /// Contains all global constants
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Base directory of all databases
        /// </summary>
        public const string MAINDBDIR = @"game/data";

        /// <summary>
        /// Name of the game config file
        /// </summary>
        public const string CONFIG = "gameconfig.txt";

        /// <summary>
        /// Default amount of time the user has to wait before they can request a new card drop
        /// </summary>
        public const int DEFAULTCARDDROPCOOLDOWN = 30;

        /// <summary>
        /// Directory of where database file for all users is kept
        /// </summary>
        public const string ALLUSERSDBDIR = $"{MAINDBDIR}/AllUsers";

        /// <summary>
        /// Path to main dattabase
        /// </summary>
        public const string DATADBDIR = $"{MAINDBDIR}/{DATADB}";

        /// <summary>
        /// Name of main database
        /// </summary>
        public const string DATADB = "Data.db";

        /// <summary>
        /// Directory for user collection database
        /// </summary>
        public const string COLLECTIONDBDIR = $"{MAINDBDIR}/{COLLECTIONDB}";

        /// <summary>
        /// Name of collection database
        /// </summary>
        public const string COLLECTIONDB = "Collections.db";

        /// <summary>
        /// Directory for trade database
        /// </summary>
        public const string TRADEDBDIR = $"{MAINDBDIR}/{TRADEDB}";

        /// <summary>
        /// Name of trade database file
        /// </summary>
        public const string TRADEDB = "Trades.db";

        /// <summary>
        /// Directory of database file that contains all cards and possible atttributes a card can have
        /// </summary>
        public const string AVAILABLECARDOPTIONSDBDIR = $"{MAINDBDIR}/{AVAILABLECARDOPTIONSDB}";

        /// <summary>
        /// Name of database file that contains all cards and possible atttributes a card can hav
        /// </summary>
        public const string AVAILABLECARDOPTIONSDB = $"AvailableCardOptions.db";

        /// <summary>
        /// Directory of the news database
        /// </summary>
        public const string NEWSDBDIR = $"{MAINDBDIR}/{NEWSDB}";

        /// <summary>
        /// Name of the news database
        /// </summary>
        public const string NEWSDB = "News.db";

        /// <summary>
        /// Path to directory where card graphics are stored
        /// </summary>
        public const string CARDDIR = $"{MAINDBDIR}/card_graphics";

        /// <summary>
        /// Path to directory where frame graphics are stored
        /// </summary>
        public const string FRAMEDIR = $"{MAINDBDIR}/frame_graphics";

        /// <summary>
        /// Admin username
        /// </summary>
        public const string ADMINUSERNAME = "admin";

        /// <summary>
        /// Admin password
        /// </summary>
        public const string ADMINUSPASSWORD = "password";

        // Old constants
#if false
        public const string USERDATACOMPLETEDIR = $"{MAINDBDIR}";

        /// <summary>
        /// Complete directory of the user database
        /// </summary>
        public const string ALLUSERDBCOMPLETEDIR = $"{MAINDBDIR}/{USERDB}";    /*@"game/data/AllUsers/Users.db"*/

        /// <summary>
        /// Complete directory of the card database
        /// </summary>
        public const string ALLCARDDBCOMPLETEDIR = $"{MAINDBDIR}/{CARDDB}";

        /// <summary>
        /// Complete directory of all card properties
        /// </summary>
        public const string ALLCARDPROPERTIESDBCOMPLETEDIR = $"{MAINDBDIR}/{CARDPROPERTIESDB}";

        /// <summary>
        /// Name of the user database
        /// </summary>
        public const string USERDB = "Users.db";

        /// <summary>
        /// Name of the card database
        /// </summary>
        public const string CARDDB = "Cards.db";

        /// <summary>
        /// Name of the card properties database
        /// </summary>
        public const string CARDPROPERTIESDB = "CardProperties.db";
#endif
    }
}
