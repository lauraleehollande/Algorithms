using System;
using NUnit.Framework;

namespace AlgorithmsTestProject
{
    public static class ArraySortProblems
    {
        public static void MySort1(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[i])
                    {
                        ArrayProblems.Swap(array, i, j);
                    }
                }
            }
        }

        public static void MySort2(int[] array)
        {
        }

        public static void MergeSort(int[] array)
        {
            throw new NotImplementedException();
        }

        public static void HeapSort(int[] array)
        {
            throw new NotImplementedException();
        }

        public static void BubbleSort(int[] array)
        {
            if (array.Length < 1)
            {
                throw new Exception("Array is empty.");
            }

            for (int i = array.Length; i > 0; i--)
            {
                for (int j = 1; j < i; j++)
                {
                    if (array[j - 1] > array[j])
                    {
                        int intermediate = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = intermediate;
                    }
                }
            }
        }

        public static void ShuffleSort(int[] array)
        {
            throw new NotImplementedException();
        }

        public static void IntroSort(int[] array)
        {
            throw new NotImplementedException();
        }

        public static void CocktailSort(int[] array)
        {
            throw new NotImplementedException();
        }

        public static void QuickSort(int[] array)
        {
            throw new NotImplementedException();
        }

        public static void BlockSort(int[] array)
        {
            throw new NotImplementedException();
        }

        public static void BogoSort(int[] array)
        {
            throw new NotImplementedException();
        }

        public static void DoNothingSort(int[] array)
        {
        }

        public static void EvilSort(int[] array)
        {
            Array.Fill(array, 0);
        }
    }
}
