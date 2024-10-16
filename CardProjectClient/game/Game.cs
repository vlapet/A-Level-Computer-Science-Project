#if false

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SQLite;
using CardProjectClient.lib;
using static CardProjectClient.lib.Constants;
using System.Data;
using System.Globalization;

namespace CardProjectClient.game
{
    public class Game
    {
        #if false
        #region Obselete code - remove
        [Obsolete]
        private List<User> Users = new List<User>();    //This is a terrible system - loading all users for a large application would use large amounts of resources

        /// <summary>
        /// Constructor - loads databases if they exist
        /// </summary>
        [Obsolete]
        public Game()
        {
            if (!File.Exists(USERDBCOMPLETEDIR))
                CreateUserDB();
            // Used for debugging - REMOVE
            else
                LoadUsers(ref this.Users);
        }

        /// <summary>
        /// Load users from user database database located at USERDBCOMPLETEDIR
        /// <para> Don't use this, will consume high amounts of resources if a lot of user accounts are loaded </para>
        /// </summary>
        [Obsolete]
        private static void LoadUsers(ref List<User> Users)
        {
            // This method is completely useless - remove <- using it to test parsing of date => debugging DateTime parsing problems
            string sql = "SELECT * FROM Users ORDER BY Username asc";

            SQLiteDataReader reader = Methods.ExecuteQuerySQL(sql);

            while (reader.Read())
            {
                //Users.Add(new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), DateOnly.FromDateTime(reader.GetDateTime(4)), reader.GetInt32(5)));

                Users.Add(User.GetUserFromSQLReader(reader));

            }
        }

        /// <summary>
        /// Create default user db - contains only admin account
        /// Move to API
        /// </summary>
        [Obsolete]
        private static void CreateUserDB()
        {
            if (!Directory.Exists(DBDIR))
                Directory.CreateDirectory(DBDIR);

            SQLiteConnection.CreateFile(USERDBCOMPLETEDIR);


            string sql = "CREATE TABLE Users (Forename VARCHAR(10), Surname VARCHAR(10), Username VARCHAR(10), Password VARCHAR(10), DateOfBirth DATE(10), UserID INTEGER)";
            Methods.ExecuteNonQuerySQL(sql);


            sql = $"INSERT INTO Users (Forename, Surname, Username, Password, DateOfBirth, UserID) values ('Admin', 'Admin', '{ADMINUSERNAME}', '{ADMINUSPASSWORD}' , '{new DateTime(1900, 01, 01).ToShortDateString()}', 0)";
            Methods.ExecuteNonQuerySQL(sql);  
        }

        public List<User> GetUsers()
        {
            return this.Users;
        }

        [Obsolete]
        public void DisplayUsers()
        {
            foreach (var x in Users)
            {
                Console.WriteLine($"Username:{x.Username}\tUserID:{x.UserID}\tNumber of Cards:{x.GetUserCards().Count}");
            }
        }
        [Obsolete]
        public void AddUser(User NewUser)
        {
            this.Users.Add(NewUser);
     
        }
        #endregion
        #endif
    }
}
#endif