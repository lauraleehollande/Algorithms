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
            var current = array.ToList();
            var result = new List<int>();
            while (current.Count > 0)
            {
                var x = current.Min();
                result.Add(x);
                current.Remove(x);
            }
            result.CopyTo(array);
        }

        public static void MergeSort(int[] array)
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

        public static void HeapSort(int[] array)
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
            bool isSwapped = true;
            int start = 0;
            int end = array.Length;

            while (isSwapped == true)
            {

                //Reset this flag.  
                //It is possible for this to be true from a prior iteration.
                isSwapped = false;

                //Do a bubble sort on this array, from low to high. 
                //If something changed, make isSwapped true.
                for (int i = start; i < end - 1; ++i)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        isSwapped = true;
                    }
                }

                //If no swaps are made, the array is sorted.
                if (isSwapped == false)
                    break;

                //We need to reset the isSwapped flag for the high-to-low pass
                isSwapped = false;

                //The item we just moved is in its rightful place, 
                //so we no longer need to consider it unsorted.
                end = end - 1;

                //Now we bubble sort from high to low
                for (int i = end - 1; i >= start; i--)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        isSwapped = true;
                    }
                }

                //Finally, we need to increase the starting point 
                //for the next low-to-high pass.
                start = start + 1;
            }
        }


        public static void QuickSort(int[] array)
        {
            QuickSortRecursive(array, 0, array.Length - 1);
        }

        private static void QuickSortRecursive(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSortRecursive(array, left, pivotIndex - 1);
                QuickSortRecursive(array, pivotIndex + 1, right);
            }
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivotValue = array[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivotValue)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, right);
            return i + 1;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
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

        public static void GnomeSort(int[] array)
        {
            for (int i = 1; i < array.Length;)
            {
                if (array[i - 1] <= array[i])
                    ++i;
                else
                {
                    int tmp = array[i];
                    array[i] = array[i - 1];
                    array[i - 1] = tmp;
                    --i;
                    if (i == 0)
                        i = 1;
                }
            }
        }

        public static void SelectionSort(int[] array)
        {
            throw new NotImplementedException();
        }
    }
}
