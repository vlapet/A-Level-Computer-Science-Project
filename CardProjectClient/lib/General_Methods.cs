using CardProjectClient.game;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProjectClient.lib
{
    public static partial class Methods
    {
        public static DataTable GetDataTableFromCard(List<Card> CardList, bool IncludeCheckbox)
        {
            DataTable DT = new DataTable();
            DataRow NewRow;

            if (IncludeCheckbox)
            {
                DT.Columns.Add(new DataColumn("Selected", typeof(bool)));
                DT.Columns[0].ReadOnly = false;
            }

            DT.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("CardID"),
                new DataColumn("Card Name"),
                new DataColumn("Card Hash"),
                new DataColumn("Date Obtained"),
                new DataColumn("Card Rarity"),
                new DataColumn("Card Frame"),
                new DataColumn("Card Nickname"),
            });



            foreach (Card CurrentCard in CardList)
            {
                NewRow = DT.NewRow();


                if (IncludeCheckbox)
                {
                    NewRow["Selected"] = false;
                }

                NewRow["CardID"] = CurrentCard.CardID;
                NewRow["Card Name"] = CurrentCard.CardName;
                NewRow["Card Hash"] = CurrentCard.CardHash;
                NewRow["Date Obtained"] = CurrentCard.DateObtained;
                NewRow["Card Rarity"] = CurrentCard.Properties.CardRarity;
                NewRow["Card Frame"] = CurrentCard.Properties.CardFrame;
                NewRow["Card Nickname"] = CurrentCard.Properties.CardNickname;

                DT.Rows.Add(NewRow);
            }

            return DT;
        }
    }
}
