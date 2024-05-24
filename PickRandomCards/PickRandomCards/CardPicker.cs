using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickRandomCards
{
    internal class CardPicker
    {
        static Random random = new Random();
        public static string[] PickSomeCards(int numberofCards)
        {
            string[] pickedCards = new string[numberofCards];
            for (int i=0; i<numberofCards; i++)
            {
                pickedCards[i] = RandomValue() + " of " + RandomSuit();
            }
            return pickedCards;
        }

        private static string RandomValue()
        {
            int rand = random.Next(1, 14);
            string ret = new string("");
            switch (rand)
            {
                case 11:
                    ret = "Jack";
                    break;
                case 12:
                    ret = "Queen";
                    break;
                case 13:
                    ret = "King";
                    break;
                default:
                    ret = rand.ToString();
                    break;
            }
            return ret;
        }

        private static string RandomSuit()
        {
            int rand = random.Next(4);
            string ret = new string("");
            switch (rand)
            {
                case 0:
                    ret = "Diamond";
                    break;
                case 1:
                    ret = "Clubs";
                    break;
                case 2:
                    ret = "Spade";
                    break;
                case 3:
                    ret = "Heart";
                    break;
                default:
                    break;

            }
            return ret;
        }
    }
}
