using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SQLite;
using static CardProjectClient.lib.Constants;

namespace CardProjectClient.lib
{
    public static partial class Methods
    {
#if false
        /// <summary>
        /// Establishes connection to database specified
        /// </summary>
        /// <param name="dbDir"> The database to connect to </param>
        /// <returns></returns>
        public static SQLiteConnection GetDBConnection(string dbDir)
        {
            return new SQLiteConnection($"Data Source={dbDir}; Version=3; ");
        }

        /// <summary>
        /// Executes non-query SQL code
        /// </summary>
        /// <param name="sql"> The code that is to be executed </param>
        public static void ExecuteNonQuerySQL(string sql)
        {
            SQLiteConnection dbConnection = GetDBConnection(USERDBCOMPLETEDIR);
            dbConnection.Open();

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);

            command.ExecuteNonQuery();

        }

        /// <summary>
        /// Executes an SQL query and returns the output
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>Returns the output of the SQL query as an SQLiteDataReader object</returns>
        public static SQLiteDataReader ExecuteQuerySQL(string sql)
        {
            SQLiteConnection dbConnection = GetDBConnection(USERDBCOMPLETEDIR);
            dbConnection.Open();

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            return command.ExecuteReader();
        }
#endif


    }
}
