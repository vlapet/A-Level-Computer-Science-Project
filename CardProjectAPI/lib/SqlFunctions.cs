using CardProjectAPI.lib;
using CardProjectAPI.api;
using static CardProjectAPI.lib.Constants;

using System.Data.SQLite;


namespace CardProjectAPI.lib
{
    public static partial class Methods
    {
        /// <summary>
        /// Creates and populates main table
        /// </summary>
        public static void CreateMainTables()
        {
            string sql;
            #region Main Database table - For users and cards
            if (!File.Exists(DATADBDIR))
            {

                SQLiteConnection.CreateFile(DATADBDIR);

                sql = "CREATE TABLE CardProperties (CardID INTEGER NOT NULL, UserID INTEGER NOT NULL, CardRarity VARCHAR(20), CardFrame VARCHAR(20), CardNickname VARCHAR(20), PRIMARY KEY (CardID, UserID))";
                Methods.ExecuteNonQuerySQL(sql);

                sql = "CREATE TABLE Cards (UserID INTEGER, CardID INTEGER NOT NULL PRIMARY KEY, CardName VARCHAR(20), CardHash VARCHAR(20), DateObtained DATETIME(20), FOREIGN KEY (CardID) REFERENCES CardProperties(CardID))";
                Methods.ExecuteNonQuerySQL(sql);

                sql = "CREATE TABLE Users (Forename VARCHAR(20), Surname VARCHAR(20), Username VARCHAR(20) UNIQUE, Password VARCHAR(20), DateOfBirth DATE(10), UserID INTEGER UNIQUE, CoolDownDate DATETIME(20), PRIMARY KEY (Username), FOREIGN KEY (UserID) REFERENCES Cards(UserID))";
                Methods.ExecuteNonQuerySQL(sql);

                sql = "CREATE TABLE Frames (UserID INTEGER, FrameID INTEGER NOT NULL PRIMARY KEY, FrameName VARCHAR(20), FrameHash VARCHAR(20), DateObtained DATETIME(20), CardID INTEGER)";
                Methods.ExecuteNonQuerySQL(sql);

                sql = $"INSERT INTO Users (Forename, Surname, Username, Password, DateOfBirth, UserID) values ('Admin', 'Admin', '{ADMINUSERNAME}', '{DataEncryption.Encrypt(ADMINUSPASSWORD)}' , '{new DateTime(1900, 01, 01).ToShortDateString()}', 0)";
                Methods.ExecuteNonQuerySQL(sql);
            }
            #endregion

            #region Collections
            if (!File.Exists(COLLECTIONDBDIR))
            {
                SQLiteConnection.CreateFile(COLLECTIONDBDIR);

                sql = "CREATE TABLE CardsInCollection (CollectionID INTEGER NOT NULL, UserID INTEGER, CardID INTEGER, PRIMARY KEY (CollectionID, CardID))";
                Methods.ExecuteNonQuerySQL(sql, COLLECTIONDBDIR);

                //sql = "CREATE TABLE Collections (CollectionID INTEGER NOT NULL, UserID INTEGER, CollectionName VARCHAR(20) NOT NULL UNIQUE, IsPublic INTEGER, DateCreated DATETIME(20), PRIMARY KEY (CollectionID), FOREIGN KEY (CollectionID) REFERENCES CardsInCollection(CollectionID))";
                sql = "CREATE TABLE Collections (CollectionID INTEGER NOT NULL, UserID INTEGER, CollectionName VARCHAR(20), IsPublic INTEGER, DateCreated DATETIME(20), PRIMARY KEY (CollectionID), FOREIGN KEY (CollectionID) REFERENCES CardsInCollection(CollectionID))";
                Methods.ExecuteNonQuerySQL(sql, COLLECTIONDBDIR);
            }

            #endregion

            #region Trades

            if (!File.Exists(TRADEDBDIR))
            {
                SQLiteConnection.CreateFile(TRADEDBDIR);

                sql = "CREATE TABLE TradeReceive (TradeID INTEGER NOT NULL, UserFromID INTEGER, UserToID INTEGER, CardReceivedID INTEGER, PRIMARY KEY (TradeID, CardReceivedID))";
                Methods.ExecuteNonQuerySQL(sql, TRADEDBDIR);

                sql = "CREATE TABLE TradeGive (TradeID INTEGER NOT NULL, UserFromID INTEGER, UserToID INTEGER, CardGivenID INTEGER, PRIMARY KEY (TradeID, CardGivenID), FOREIGN KEY (TradeID) REFERENCES TradeReceive(TradeID))";
                Methods.ExecuteNonQuerySQL(sql, TRADEDBDIR);

                sql = "CREATE TABLE Trades (TradeName VARCHAR(20), UserFromID INTEGER, TradeID INTEGER NOT NULL, DateRequested DATETIME(20), UserToID INTEGER, PRIMARY KEY (TradeID), FOREIGN KEY (TradeID) REFERENCES TradeGive(TradeID))";
                Methods.ExecuteNonQuerySQL(sql, TRADEDBDIR);
            }

            #endregion

            #region Available card options

            if (!File.Exists(AVAILABLECARDOPTIONSDBDIR))
            {
                SQLiteConnection.CreateFile(AVAILABLECARDOPTIONSDBDIR);

                sql = "CREATE TABLE AvailableCardRarityList (CardRarity VARCHAR(20) NOT NULL UNIQUE, PRIMARY KEY (CardRarity))";
                Methods.ExecuteNonQuerySQL(sql, AVAILABLECARDOPTIONSDBDIR);

                sql = "CREATE TABLE AvailableCardList (CardName VARCHAR(20) NOT NULL UNIQUE, CardRarity VARCHAR(20), PRIMARY KEY (CardName))";
                Methods.ExecuteNonQuerySQL(sql, AVAILABLECARDOPTIONSDBDIR);

                sql = "CREATE TABLE AvailableFrameList (FrameName VARCHAR(20) NOT NULL UNIQUE, PRIMARY KEY (FrameName))";
                Methods.ExecuteNonQuerySQL(sql, AVAILABLECARDOPTIONSDBDIR);
            }

            #endregion

            #region News

            if (!File.Exists(NEWSDBDIR))
            {
                SQLiteConnection.CreateFile(NEWSDBDIR);

                sql = "CREATE TABLE News (Title VARCHAR(20) NOT NULL UNIQUE, Content TEXT, DateCreated DATETIME(20), PRIMARY KEY (Title))";
                Methods.ExecuteNonQuerySQL(sql, NEWSDBDIR);
            }

            #endregion
        }

        /// <summary>
        /// Adds user entry to main table
        /// </summary>
        /// <param name="Forename"></param>
        /// <param name="Surname"></param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="DateOfBirth"></param>
        /// <param name="UserID"></param>
        public static void CreateUser(string Forename, string Surname, string Username, string Password, DateOnly DateOfBirth, int UserID)
        {
            string sql = $"INSERT INTO Users(Forename, Surname, Username, Password, DateOfBirth, UserID) values('{Forename}', '{Surname}', '{Username}', '{Password}', '{DateOfBirth}', '{UserID}')";
            Methods.ExecuteNonQuerySQL(sql);
        }

        /// <summary>
        /// Deletes user entry from main table and deletes associated file
        /// </summary>
        /// <param name="Username"></param>
        public static void DeleteUser(string Username, string UserID)
        {
            string sql = $"DELETE FROM Users WHERE Username = \"{Username}\"";

            //TODO: sql to delete user from all tables
            Methods.ExecuteNonQuerySQL(sql);

            sql = $"DELETE FROM Cards WHERE UserID = '{UserID}'";
            Methods.ExecuteNonQuerySQL(sql, DATADBDIR);

            sql = $"DELETE FROM CardProperties WHERE UserID = {UserID}";
            Methods.ExecuteNonQuerySQL(sql, DATADBDIR);

            sql = $"DELETE FROM Frames WHERE UserID = '{UserID}'";
            Methods.ExecuteNonQuerySQL(sql, DATADBDIR);

            sql = $"DELETE FROM Collections WHERE UserID = '{UserID}'";
            Methods.ExecuteNonQuerySQL(sql, COLLECTIONDBDIR);

            sql = $"DELETE FROM CardsInCollection WHERE UserID = '{UserID}'";
            Methods.ExecuteNonQuerySQL(sql, COLLECTIONDBDIR);

            sql = $"DELETE FROM Trades WHERE UserFromID = '{UserID}' OR UserToID = '{UserID}'";
            Methods.ExecuteNonQuerySQL(sql, TRADEDBDIR);

            sql = $"DELETE FROM TradeGive WHERE UserToID = '{UserID}'";
            Methods.ExecuteNonQuerySQL(sql, TRADEDBDIR);

            sql = $"DELETE FROM TradeReceive WHERE UserFromID = '{UserID}'";
            Methods.ExecuteNonQuerySQL(sql, TRADEDBDIR);



            GC.Collect();
            GC.WaitForPendingFinalizers();

#if false
            if (File.Exists($"{MAINDBDIR}/{Username}.db"))
                File.Delete($"{MAINDBDIR}/{Username}.db");
#endif
        }

        /// <summary>
        /// Update the user details in the database
        /// </summary>
        /// <param name="NewUserDetails"></param>
        /// <param name="CurrentUser"></param>
        public static void UpdateUser(UserPut NewUserDetails, UserPut CurrentUser)
        {
            string sql;

            if (NewUserDetails.Username != null)
            {
                sql = $"SELECT Username FROM Users WHERE Username == '{NewUserDetails.Username}'";
                using (SQLiteDataReader reader = Methods.ExecuteQuerySQL(sql))
                {

                    // If value with entered username found then inform the user and return
                    if (reader.Read())
                    {
                        // Username already exists
                        throw new ArgumentException("Username already exists");
                    }
                };

                sql = $"UPDATE Users SET Username = '{NewUserDetails.Username}' WHERE UserID = '{CurrentUser.UserID}'";
                Methods.ExecuteNonQuerySQL(sql);
            }

            if (NewUserDetails.Forename != null)
            {
                sql = $"UPDATE Users SET Forename = '{NewUserDetails.Forename}' WHERE UserID = '{CurrentUser.UserID}'";
                Methods.ExecuteNonQuerySQL(sql);
            }

            if (NewUserDetails.Surname != null)
            {
                sql = $"UPDATE Users SET Surname = '{NewUserDetails.Surname}' WHERE UserID = '{CurrentUser.UserID}'";
                Methods.ExecuteNonQuerySQL(sql);
            }

            if (NewUserDetails.Password != null)
            {
                sql = $"UPDATE Users SET Password = '{NewUserDetails.Password}' WHERE UserID = '{CurrentUser.UserID}'";
                Methods.ExecuteNonQuerySQL(sql);
            }

            if (NewUserDetails.DateOfBirth != null)
            {
                sql = $"UPDATE Users SET DateOfBirth = '{DateOnly.FromDateTime((DateTime)NewUserDetails.DateOfBirth)}' WHERE UserID = '{CurrentUser.UserID}'";
                Methods.ExecuteNonQuerySQL(sql);
            }
        }

        /// <summary>
        /// Returns how many row entries a table contains
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static int CountTableRows(string tableName)
        {
            string sql = $"SELECT COUNT(*) FROM {tableName}";
            var Reader = Methods.ExecuteQuerySQL(sql);

            return Reader.GetInt32(0);
        }

        public static void DeleteTradeRequest(TradeSearch CurrentTradeSearch)
        {
            string Sql = $"DELETE FROM Trades WHERE TradeID == '{CurrentTradeSearch.TradeID}'";
            Methods.ExecuteNonQuerySQL(Sql, Constants.TRADEDBDIR);

            Sql = $"DELETE FROM TradeGive WHERE TradeID == '{CurrentTradeSearch.TradeID}'";
            Methods.ExecuteNonQuerySQL(Sql, Constants.TRADEDBDIR);

            Sql = $"DELETE FROM TradeReceive WHERE TradeID == '{CurrentTradeSearch.TradeID}'";
            Methods.ExecuteNonQuerySQL(Sql, Constants.TRADEDBDIR);
        }
    }
}
