namespace AlgorithmsTestProject;

public static class ArrayProblems
{
    public static bool AreArraysEqual<T>(T[] xs, T[] ys)
    {
            if (xs.Length != ys.Length)
                return false;

            for (int i = 0; i < xs.Length; i++)
            {
                if (!xs[i].Equals(ys[i]))
                    return false;
            }

            return true;
    }

    public static void Swap<T>(T[] xs, int a, int b)
    {
        if (a < 0 || a >= xs.Length || b < 0 || b >= xs.Length)
            throw new IndexOutOfRangeException();

        T temp = xs[a];
        xs[a] = xs[b];
        xs[b] = temp;
    }
    
    public static T FirstElement<T>(T[] xs)
    {
        if (xs.Length < 1)
        {
            throw new IndexOutOfRangeException();
        }

        return xs[0];
    }

    public static T LastElement<T>(T[] xs)
    {
        if (xs.Length < 1)
        {
            throw new Exception("Array is empty.");
        }

        return xs[xs.Length - 1];
    }

    public static T MiddleElement<T>(T[] xs)
    {
        if (xs.Length < 1)
        {
            throw new IndexOutOfRangeException();
        }

        int middleIndex = xs.Length / 2;
        return xs[middleIndex];
    }

    public static void Reverse<T>(T[] xs)
    {
        int start = 0;
        int end = xs.Length - 1;

        while (start < end)
        {
            T temp = xs[start];
            xs[start] = xs[end];
            xs[end] = temp;

            start++;
            end--;
        }
    }

    public static int CountElement<T>(T[] xs, T element)
    {
        int count = 0;
        for (int i = 0; i < xs.Length; i++)
        {
            if (EqualityComparer<T>.Default.Equals(xs[i], element))
            {
                count++;
            }
        }
        return count;
    }

    public static string ToCommaDelimitedString<T>(T[] xs)
    {
        return string.Join(",", xs);
    }

    // Bonus problems

    public static int Count<T>(T[] xs, Func<T, bool> predicate)
    {
        int count = 0;
        foreach (T item in xs)
        {
            if (predicate(item)) //predicate = 1
            {
                count++;
            }
        }
        return count;
    }

    public static T Min<T>(T[] xs, Func<T, T, int> comparer)
    {
        if (xs.Length < 1)
        {
            throw new IndexOutOfRangeException();
        }

        T minValue = xs[0];
        for (int i = 1; i < xs.Length; i++)
        {
            if (comparer(xs[i], minValue) < 0) // if a-b < 0 alors xs[i] < 0  
            {
                minValue = xs[i]; // update minValue
            }
        }

        return minValue;
    }

    public static T Max<T>(T[] xs, Func<T, T, int> comparer)
    {
        if (xs.Length < 1)
        {
            throw new IndexOutOfRangeException();
        }

        T maxValue = xs[0]; //
        for (int i = 1; i < xs.Length; i++)
        {
            if (comparer(xs[i], maxValue) > 0) // if a-b > 0 alors xs[i] > 0
            {
                maxValue = xs[i]; // update minValue
            }
        }
        return maxValue;
    }

    public static bool HasDuplicates<T>(T[] xs)
    {
        for (int i = 0; i < xs.Length; i++)
        {
            for (int j = i + 1; j < xs.Length; j++)
            {
                if (EqualityComparer<T>.Default.Equals(xs[i], xs[j]))
                {
                    return true; // has a duplicate
                }
            }
        }

        return false; // doesn't habve a duplicate
    }
}
