using CardProjectClient.game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProjectClient.lib
{
    public static class Extension_Methods
    {
        // Used to find index of item in an unsorted array
        public static int FindIndexOf<T>(this List<T> ThisList, T Item)
        {
            for (int i = 0; i < ThisList.Count; i++)
            {
                if (ThisList[i].Equals(Item))
                    return i;
            }

            return -1;
        }

        public static int FindIndexOf(this List<News> ThisList, News Item, bool UseOverride)
        {
            List<string> TitleList = ThisList.Select(x => x.Title).ToList();
            return FindIndexOf<string>(TitleList, Item.Title);
        }


        public static bool ContainsElement<T>(this T[] arr, T item) where T : IComparable
        {
            // First sorts array in ascending order
            Methods.QuickSort(ref arr);

            // Then searches for element
            int Result = Methods.BinarySearch(arr, item);

            // If an index is found then return true; else return false
            if (Result >= 0)
                return true;
            else
                return false;
        }

        public static bool ContainsElement<T>(this List<T> arr, T item) where T : IComparable
        {
            return arr.ToArray().ContainsElement(item);
        }

        public static bool ContainsElement<T>(this IEnumerable<T> arr, T item) where T : IComparable
        {
            return arr.ToArray().ContainsElement(item);
        }
    }
}
