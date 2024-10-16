using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProjectClient.game
{
    public class User
    {
        private List<Card> _Cards;
        private string _Forename;
        private string _Surname;
        private string _Username;
        private string _Password;
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        private DateOnly _DateOfBirth;
        private int _UserID;

        #region Constructor
        /// <summary>
        /// Constructor for User
        /// </summary>
        /// <param name="Forename"></param>
        /// <param name="Surname"></param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="UserID"></param>s
        public User(string Forename, string Surname, string Username, string Password, DateOnly DateOfBirth, int UserID)
        {
            this.Forename = Forename;
            this.Surname = Surname;
            this.Username = Username;
            this.Password = Password;
            this.DateOfBirth = DateOfBirth;
            this.UserID = UserID;
            this._Cards = new List<Card>();
        }

        /// <summary>
        /// Constructor for DateTime
        /// </summary>
        /// <param name="Forename"></param>
        /// <param name="Surname"></param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="DateOfBirth"></param>
        /// <param name="UserID"></param>
        [JsonConstructor]
        public User(string Forename, string Surname, string Username, string Password, DateTime DateOfBirth, int UserID)
        {
            this.Forename = Forename;
            this.Surname = Surname;
            this.Username = Username;
            this.Password = Password;
            this.DateOfBirth = DateOnly.FromDateTime(DateOfBirth);
            this.UserID = UserID;
            this._Cards = new List<Card>();
        }

        /// <summary>
        /// Constructor for User - takes less parameters, leaves other attributes as null - possibly remove?
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="UserID"></param>
        public User(string Username, string Password, int UserID)
        {
            this.Username = Username;
            this.Password = Password;
            this.UserID = UserID;
            this._Cards = new List<Card>();
        }

        #endregion


        /// <summary>
        /// Methods used to access private attributes
        /// </summary>
        /// <returns></returns>

        #region Private Accessors
        public List<Card> GetUserCards()
        {
            return this._Cards;
        }

        [JsonProperty("Forename")]
        public string Forename
        {
            get => this._Forename;
            set => this._Forename = value;
        }

        [JsonProperty("Surname")]
        public string Surname
        {
            get => this._Surname;
            set => this._Surname = value;
        }

        [JsonProperty("Username")]
        public string Username
        {
            get => this._Username;
            set => this._Username = value;
        }

        [JsonProperty("Password")]
        public string Password
        {
            get => this._Password;
            set => this._Password = value;
        }

        [JsonProperty("DateOfBirth")]
        public DateOnly DateOfBirth
        {
            get => this._DateOfBirth;
            set => this._DateOfBirth = value;
        }

        [JsonProperty("UserID")]
        public int UserID
        {
            get => this._UserID;
            set => this._UserID = value;
        }

        public void AddCard(Card card)
        {
            this._Cards.Add(card);
        }

        #endregion


        #region Helper Methods
        public void DisplayCards()
        {
            foreach (var x in _Cards)
            {
                Console.WriteLine($"Card Name:{x.CardName}\tCardID:{x.CardID}\tCardRarity:{x.Properties.CardRarity}");
            }
        }
        /// <summary>
        /// Gets user properties from SQL query and returns user object with properties set
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        /*
        public static User GetUserFromSQLReader(SQLiteDataReader reader)
        {
            return new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), DateOnly.Parse(reader.GetString(4)), reader.GetInt32(5));
        }
        */
        /// <summary>
        /// Parses the JSON returned by the API
        /// </summary>
        /// <param name="JSON"></param>
        /// <returns></returns>
         
        /*
        public static User ParseUserJsonRequest(string JSON)
        {
            return new User();
        }
        */
        #endregion
    }
}
