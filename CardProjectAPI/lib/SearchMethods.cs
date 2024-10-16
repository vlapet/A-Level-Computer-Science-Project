using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardProjectAPI.game;

namespace CardProjectAPI.lib
{
    public static partial class Methods
    {
        public static int SearchForIndex<T>(string value, List<T> iterable)
        {
            int index;
            for (index = 0; index < iterable.Count; index++)
            {
                if (value == iterable[index].ToString())
                    return index;
            }

            return -1;
        }

        #region Binary search

        static int _BinarySearch<T>(T[] arr, T item, int Lower, int Upper) where T : IComparable
        {
            Console.WriteLine($"Lower: {Lower}\tUpper: {Upper}");
            if (Lower > Upper)
                return -1;


            int Midpoint = (Upper + Lower) / 2;
            int index = 0;

            if (arr[Midpoint].CompareTo(item) == 0)
                return Midpoint;

            if (item.CompareTo(arr[Midpoint]) < 0)
                index = _BinarySearch(arr, item, Lower, Midpoint - 1);
            else
                index = _BinarySearch(arr, item, Midpoint + 1, Upper);

            return index;
        }

        public static int BinarySearch<T>(T[] arr, T item) where T : IComparable
        {
            return _BinarySearch<T>(arr, item, 0, arr.Length - 1);
        }

        #endregion
    }
}
