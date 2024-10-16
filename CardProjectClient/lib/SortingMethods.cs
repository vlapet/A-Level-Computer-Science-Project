using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProjectClient.lib
{
    public static partial class Methods
    {
        #region Quicksort

        private static int Partition<T>(ref T[] InputArray, int Left, int Right) where T : IComparable
        {
            T Pivot = InputArray[Right];
            int LowerIndex = (Left - 1);

            for (int j = Left; j <= Right - 1; j++)
            {
                if (InputArray[j].CompareTo(Pivot) < 0)
                {
                    LowerIndex++;
                    (InputArray[LowerIndex], InputArray[j]) = (InputArray[j], InputArray[LowerIndex]);
                }
            }

            (InputArray[LowerIndex + 1], InputArray[Right]) = (InputArray[Right], InputArray[LowerIndex + 1]);
            return (LowerIndex + 1);
        }

        public static void QuickSort<T>(ref T[] InputArray, int Left, int Right) where T : IComparable
        {
            if (Left < Right)
            {
                int PivotIndex = Partition(ref InputArray, Left, Right);
                QuickSort(ref InputArray, Left, PivotIndex - 1);
                QuickSort(ref InputArray, PivotIndex + 1, Right);
            }
        }


        // Allows quicksort to be called without extra parameters
        public static void QuickSort<T>(ref T[] InputArray) where T : IComparable
        {
            QuickSort(ref InputArray, 0, InputArray.Length - 1);
        }

        #endregion
    }
}
