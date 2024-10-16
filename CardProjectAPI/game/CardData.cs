namespace CardProjectAPI.game
{
#if false
    public class CardData
    {
        //Move this to API
        //Values will be pulled from SQL database anyway
        //Consider using Enum instead of dictionary
        //Dictionary values cannot be changed
        public readonly Dictionary<string, double> ID = new Dictionary<string, double>
        {
            //Debug CardIDs
            //CardID followed by drop chance
            //Drop chances MUST add to 1.0
            {"t1",0.3},
            {"t2", 0.2},
            {"t3", 0.1},
            {"t4",0.4}
        };


        public readonly Dictionary<string, double> Rarity = new Dictionary<string, double>
        {
            //Card Rarity followed by drop chance
            //Drop chances MUST add to 1.0
            {"bronze", 0.6},
            {"silver", 0.2},
            {"gold", 0.1},
            {"platinum",0.05},
            {"diamond", 0.03},
            {"emerald", 0.02}
        };

        /// <summary>
        /// Chooses the card to give to the user depending on the input
        /// </summary>
        /// <param name="rarity">The random number generated between 0 and 1</param>
        /// <returns></returns>
        public static int GetCardIndexFromChance(double rarity)    //Think of a better name for thiis function 
        {
            CardData properties = new CardData();

            int index;
            double CumulativeDropChance = 0;
            for (index = 0; index < properties.ID.Count; index++)
            {
                CumulativeDropChance += properties.ID.ElementAt(index).Value;
                if (rarity <= CumulativeDropChance)
                    break;
            }

            return index;
        }

        /// <summary>
        /// Chooses the card rarity depending on the input
        /// </summary>
        /// <param name="chance">The random number generated between 0 and 1</param>
        /// <returns></returns>
        public static int GetCardRarityIndexFromChance(double chance)
        {
            CardData properties = new CardData();

            int index;
            double CumulativeDropChance = 0;
            for (index = 0; index < properties.Rarity.Count; index++)
            {
                CumulativeDropChance += properties.Rarity.ElementAt(index).Value;
                if (chance <= CumulativeDropChance)
                    break;
            }

            return index;
        }
    }
#endif
}
