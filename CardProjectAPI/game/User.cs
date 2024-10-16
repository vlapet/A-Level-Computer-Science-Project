using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CardProjectAPI.game
{
    class User
    {
        private List<Card> _Cards;
        private string _Forename;
        private string _Surname;
        private string _Username;
        private string _Password;
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        private DateOnly _DateOfBirth;
        private int _UserID;

        #region struct User for DateTime workaround
        public struct sUser
        {
            public string Forename;
            public string Surname;
            public string Username;
            public string Password;
            public DateTime DateOfBirth;
            public int UserID;

            #region Constructor
            /// <summary>
            /// Constructor for User
            /// </summary>
            /// <param name="Forename"></param>
            /// <param name="Surname"></param>
            /// <param name="Username"></param>
            /// <param name="Password"></param>
            /// <param name="UserID"></param>
            public sUser(string Forename, string Surname, string Username, string Password, DateTime DateOfBirth, int UserID)
            {
                this.Forename = Forename;
                this.Surname = Surname;
                this.Username = Username;
                this.Password = Password;
                this.DateOfBirth = DateOfBirth;
                this.UserID = UserID;
            }

            #endregion
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for User
        /// </summary>
        /// <param name="Forename"></param>
        /// <param name="Surname"></param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="UserID"></param>
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
        /// Constructor for user without UserID parameter and DateTime parameter instead of DateOnly
        /// </summary>
        /// <param name="Forename"></param>
        /// <param name="Surname"></param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="DateOfBirth"></param>
        public User(string Forename, string Surname, string Username, string Password, DateTime DateOfBirth)
        {
            this.Forename = Forename;
            this.Surname = Surname;
            this.Username = Username;
            this.Password = Password;
            this.DateOfBirth = DateOnly.FromDateTime(DateOfBirth);
            this.UserID = -1;
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

        public string Forename
        {
            get => this._Forename;
            set => this._Forename = value;
        }

        public string Surname
        {
            get => this._Surname;
            set => this._Surname = value;
        }

        public string Username
        {
            get => this._Username;
            set => this._Username = value;
        }

        public string Password
        {
            get => this._Password;
            set => this._Password = value;
        }

        public DateOnly DateOfBirth
        {
            get => this._DateOfBirth;
            set => this._DateOfBirth = value;
        }

        public int UserID
        {
            get => this._UserID;
            set => this._UserID = value;
        }

        public void AddCard(Card card)
        {
            this._Cards.Add(card);
        }

        // this.DateOfBirth.ToDateTime(TimeOnly.Parse("00:00AM"))

        /// <summary>
        /// Workaround for Newtonsoft.JsonSerializer not working with DateOnly
        /// </summary>
        /// <returns></returns>
        public sUser GetUserWithDateTimeAsStruct()
        {
            var t = new sUser(this.Forename, this.Surname, this.Username, this.Password, this.DateOfBirth.ToDateTime(TimeOnly.Parse("00:00AM")), this.UserID);            

            return t;            
        }

        #endregion


        #region Helper Methods
        
        [Obsolete]
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
        public static User GetUserFromSQLReader(SQLiteDataReader reader)
        {
            return new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), DateOnly.Parse(reader.GetString(4)), reader.GetInt32(5));
        }
        #endregion
    }
}
