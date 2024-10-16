using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using CardProjectAPI.lib;
using static CardProjectAPI.lib.Constants;
using System.Data;
using System.Globalization;

namespace CardProjectAPI.game
{
    static class Game
    {
        /// <summary>
        /// Check if any files are missing
        /// </summary>
        public static void CheckFiles()
        {
            if (!File.Exists(DATADBDIR) || !File.Exists(COLLECTIONDBDIR) || !File.Exists(TRADEDBDIR) || !File.Exists(AVAILABLECARDOPTIONSDBDIR) || !File.Exists(NEWSDBDIR))
                CreateUserDB();
        }

        /// <summary>
        /// Create all databases - "Users" contains only admin account
        /// <para>TODO: Can be moved to seperate file </para>
        /// </summary>
        private static void CreateUserDB()
        {
            if (!Directory.Exists(MAINDBDIR))
                Directory.CreateDirectory(MAINDBDIR);

            if (!Directory.Exists(CARDDIR))
                Directory.CreateDirectory(CARDDIR);

            if (!Directory.Exists(FRAMEDIR))
                Directory.CreateDirectory(FRAMEDIR);

            Methods.CreateMainTables();
        }

        /// <summary>
        /// Checks if config files exists
        /// Creates a new config file if it doesn't exist
        /// </summary>
        public static async Task<Config> GetGameConfig()
        {
            string ConfigFilePath = $"{Constants.MAINDBDIR}/{Constants.CONFIG}";
            System.Text.Json.JsonSerializerOptions JOptions = new();
            JOptions.IncludeFields = true;

            if (!File.Exists(ConfigFilePath))
            {
                Config GameConfig = new Config(Constants.DEFAULTCARDDROPCOOLDOWN);

                string JsonConfig = System.Text.Json.JsonSerializer.Serialize(GameConfig, JOptions);

                File.WriteAllText(ConfigFilePath, JsonConfig);

                return GameConfig;
            }
            else
            {
                var FileText = new StreamReader(ConfigFilePath);
                Config GameConfig = System.Text.Json.JsonSerializer.Deserialize<Config>(await FileText.ReadToEndAsync(), JOptions);
                return GameConfig;
            }
        }

    }
}
