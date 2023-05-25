using System;
using System.Linq;
﻿using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTestProject
{
    public static class CombinationsTest
    {
        public static bool AreSetsSame(List<int> a, List<int> b)
        {
            if (a.Count != b.Count) return false;
            var asorted = a.OrderBy(x => x);
            var bsorted = b.OrderBy(x => x);
            return asorted.SequenceEqual(bsorted);
        }

        public static bool DoesOutputSetContain(IEnumerable<List<int>> outputSet, List<int> member)
        {
            foreach (var output in outputSet)
            {
                if (AreSetsSame(output, member))
                    return true;
            }

            return false;
        }

        [Test]
        public static void TestGenerateCombinations()
        {
            var testInput = new[] { 1, 3, 5 };
            var output = GenerateCombinations(testInput);
            
            // How do I validate that the output is valid? 
            // Maybe check that it contains a result I expect? 

            // I know that it should have three lists of length one 

            // Expected results=
            // [], [1], [3], [5], [1,3], [1,5], [3, 5], [1, 3, 5]
            // 1 of length 0,
            // 3 of length 1,
            // 3 of length 2,
            // 1 of length 3. 
            // Total count = 8

            var expectedResults = new List<List<int>>
            {
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

        public static List<List<int>> GenerateCombinations(int[] input)
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

    }
}
