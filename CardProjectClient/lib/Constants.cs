using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProjectClient.lib
{
    /// <summary>
    /// Contains all global constants
    /// </summary>
    public static class Constants
    {

#if false
        /// <summary>
        /// Directory of all databases
        /// </summary>
        public const string DBDIR = @"game/data";

        /// <summary>
        /// Complete directory of the user database
        /// </summary>
        public const string USERDBCOMPLETEDIR = $"{DBDIR}/{USERDB}";    /*@"game/data/Users.db"*/

        /// <summary>
        /// Name of the user database
        /// </summary>
        public const string USERDB = "Users.db";


        /// <summary>
        /// Admin username
        /// </summary>
        public const string ADMINUSERNAME = "admin";

        /// <summary>
        /// Admin password
        /// </summary>
        public const string ADMINUSPASSWORD = "password";
#endif

        /// <summary>
        /// Base directory of all databases
        /// </summary>
        public const string MAINDBDIR = @"game/data";

        public const bool COMPILE_OBSELETE_CODE = false;

    }
}
