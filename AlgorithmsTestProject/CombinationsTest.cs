using System;
using System.Linq;
namespace AlgorithmsTestProject
{
    public static class CombinationsTest
    {
        public static bool AreSetsTheSame(List<int> a, List<int> b)
        {
            if (a.Count != b.Count) return false;
            var asorted = a.OrderBy(x => x);
            var bsorted = b.OrderBy(x => x);
            return asorted.SequenceEqual(bsorted);
        }
        public static bool DoesOutputSetContains(List<List<int>> outputSet, List<int> member)
        {
            foreach (var output in outputSet)
            {
                if (AreSetsTheSame(output, member))
                {
                    return true;
                }
            }
            return false;
        }
        [Test]
        public static void TestGenerateCombinations()
        {
            var testInput = new[] { 1, 3, 5 };
            var output = GenerateCombinations(testInput);
            var expectedResults = new List<List<int>> {
                new List<int> { },
                new List<int> { 1 },
                new List<int> { 3 },
                new List<int> { 5 },
                new List<int> { 1, 3 },
                new List<int> { 1, 5 },
                new List<int> { 3, 5 },
                new List<int> { 1, 3, 5 },
            };
            foreach (var expectedResult in expectedResults)
            {
                Assert.IsTrue(DoesOutputSetContains(output, expectedResult));
            }
            Assert.AreEqual(8, output.Count);
        }

        public static void OutputResults(IEnumerable<List<int>> output)
        {
            foreach (var combination in output)
            {
                Console.WriteLine("[" + string.Join(",", combination) + "]");
            }
        }

        [Test]
        public static void ViewTestOutput()
        {
            var testInput = new[] { 1, 3, 5, 7 };
            var combinations = GenerateCombinations(testInput);
            OutputResults(combinations);
        }

        [Test]
        public static void ViewTestOutput2()
        {
            var testInput = new[] { 1, 3, 5, 7 };
            var combinations = GenerateCombinations2(testInput);
            OutputResults(combinations);
        }

        [Test]
        public static void ViewTestOutputWrong()
        {
            var testInput = new[] { 1, 3, 5, 7 };
            var combinations = GenerateCombinationsWrong(new List<int>(), testInput);
            OutputResults(combinations);
        }

        public static void GenerateCombinations(
            int[] input, 
            int index, 
            List<int> previous, 
            List<List<int>> combinations)
        {
            DebugCount++;
            if (index >= input.Length)
                return;
            GenerateCombinations(input, index + 1, previous, combinations);
            var tmp = previous.ToList();
            tmp.Add(input[index]);
            combinations.Add(tmp);
            GenerateCombinations(input, index + 1, tmp, combinations);
        }

        public static IEnumerable<List<int>> GenerateCombinations(int[] input)
        {
            var combinations = new List<List<int>>();
            var currentCombination = new List<int>();
            GenerateCombinationsRecursive(input, combinations, currentCombination, 0);
            return combinations;
        }
        private static void GenerateCombinationsRecursive(int[] input, List<List<int>> combinations, List<int> currentCombination, int startIndex)
        {
            combinations.Add(new List<int>(currentCombination));
            for (int i = startIndex; i < input.Length; i++)
            {
                currentCombination.Add(input[i]);
                GenerateCombinationsRecursive(input, combinations, currentCombination, i + 1);
                currentCombination.RemoveAt(currentCombination.Count - 1);
            }
        }

        public static IEnumerable<List<int>> GenerateCombinations2(int[] input)
        {
            var count = Helper.Pow2(input.Length);
            for (var i = 0; i < count; ++i)
            {
                yield return ChooseInts(i, input);
            }
        }

        public static List<int> ChooseInts(int index, int[] input)
        {
            if (input.Length > 31)
                throw new Exception("Too many inputs");

            var result = new List<int>();
            for (var i = 0; i < input.Length; i++)
            {
                if (Helper.HasBitSet(index, i))
                    result.Add(input[i]);
            }
            return result;
        }

        private static int DebugCount = 0;

        public static void GenerateSumCombinations(
            int[] input,
            int sum,
            int index,
            List<int> previous,
            List<List<int>> combinations)
        {
            DebugCount++;
            if (previous.Sum() > sum)
                return;
            if (index >= input.Length)
                return;
            GenerateSumCombinations(input, sum, index + 1, previous, combinations);
            var tmp = previous.ToList();
            tmp.Add(input[index]);
            if (tmp.Sum() == sum)
                combinations.Add(tmp);
            GenerateSumCombinations(input, sum, index + 1, tmp, combinations);
        }

        public static IEnumerable<List<int>> GenerateSumCombinations(int[] input, int sum)
        {
            var combinations = new List<List<int>>();
            GenerateSumCombinations(input, sum, 0, new List<int>(), combinations);
            return combinations;
        }

        [Test]
        public static void TestSumCombinations()
        {

            var testInput = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            var target = 15;

            DebugCount = 0;
            var result0 = GenerateCombinations(testInput)
                .Where(input => input.Sum() == target);
            Console.WriteLine($"Using sum combinations with brute force:");
            Console.WriteLine($"function called {DebugCount} times");
            OutputResults(result0);

            DebugCount = 0;
            var result1 = GenerateSumCombinations(testInput, target);
            Console.WriteLine($"Using sum combinations with backtracking:");
            Console.WriteLine($"function called {DebugCount} times");
            OutputResults(result1);
        }
    }
}