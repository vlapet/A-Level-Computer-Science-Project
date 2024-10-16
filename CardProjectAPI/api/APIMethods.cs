using System;
using System.IO;
using System.Drawing;
using CardProjectAPI.lib;
using System.Reflection.PortableExecutable;
using System.Data.SQLite;

namespace CardProjectAPI.api
{
    public static class APIMethods
    {
        public static async Task<byte[]> GetImageBinary(string filePath)
        {
            return await File.ReadAllBytesAsync(filePath);
        }


        public static (List<string>, List<string>) GetRandomFromTableAsList(int NumberOfRows)
        {
            int ItemSelected;
            string sql;
            string DBCardString;
            //SQLiteDataReader NewReader;

            List<string> CardNameString = new List<string>();
            List<string> CardRarityString = new List<string>();

            for (int i = 0; i <= 2; i++)
            {
                // Choose a random row from AvailableCardList
                ItemSelected = new Random().Next(1, NumberOfRows + 1);
                sql = $"SELECT CardName, CardRarity FROM AvailableCardList WHERE rowid == '{ItemSelected}'";

                using var NewReader = Methods.ExecuteQuerySQL(sql, Constants.AVAILABLECARDOPTIONSDBDIR);

                if (NewReader.Read())
                {
                    DBCardString = NewReader.GetString(0);

                    CardNameString.Add(DBCardString);

                    // Check if same card has been selected twice - if it has remove the card from list
                    if (CardNameString.Count == 2 && CardNameString[0] == CardNameString[1])
                    {
                        CardNameString.RemoveAt(1);
                        i--;
                        continue;
                    }
                    else if (CardNameString.Count == 3 && (CardNameString[0] == CardNameString[2] || CardNameString[1] == CardNameString[2]))
                    {
                        CardNameString.RemoveAt(2);
                        i--;
                        continue;
                    }

                    CardRarityString.Add(NewReader.GetString(1));

                }
            }

            return (CardNameString, CardRarityString);
        }

        public static int GenerateRandomIntCurved(int MaxNum)
        {
            int GeneratedInt = new Random().Next(1, MaxNum);
            // TODO: Do something else here

            return GeneratedInt;
        }
    }
}
