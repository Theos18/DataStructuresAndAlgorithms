using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayMastery
{
    /// <summary>
    /// Advanced Array Problems: Master-Level Challenges
    /// 
    /// "Everyone knows that debugging is twice as hard as writing a program 
    /// in the first place. So if you're as clever as you can be when you write it, 
    /// how will you ever debug it?" - Brian Kernighan
    /// 
    /// These problems will test your deep understanding of arrays.
    /// They appear frequently in FAANG interviews.
    /// 
    /// Difficulty Scale:
    /// ⭐⭐⭐ = Medium (Google, Microsoft)
    /// ⭐⭐⭐⭐ = Hard (Amazon, Facebook)
    /// ⭐⭐⭐⭐⭐ = Very Hard (Competitive Programming)
    /// </summary>
    class AdvancedArrayProblems
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ADVANCED ARRAY PROBLEMS ===\n");
            
            // Uncomment as you solve
            // TestKadanesAlgorithm();
            // TestTrappingRainWater();
            // TestMaxProductSubarray();
            // TestLongestConsecutiveSequence();
            // TestMedianOfTwoSortedArrays();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        #region PROBLEM 1: Kadane's Algorithm - Maximum Subarray Sum

        /// <summary>
        /// PROBLEM 1: Maximum Subarray Sum (Kadane's Algorithm)
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Time: O(n) | Space: O(1)
        /// 
        /// Find the contiguous subarray with the largest sum.
        /// 
        /// Example:
        ///   Input: [-2, 1, -3, 4, -1, 2, 1, -5, 4]
        ///   Output: 6 (subarray [4, -1, 2, 1])
        /// 
        /// THE INSIGHT:
        /// At each position, you have two choices:
        /// 1. Extend the current subarray (add current element to previous sum)
        /// 2. Start a new subarray (just take current element)
        /// 
        /// Choose whichever gives you a larger sum!
        /// 
        /// MATHEMATICAL FORMULATION:
        /// maxEndingHere[i] = max(arr[i], maxEndingHere[i-1] + arr[i])
        /// maxSoFar = max(maxSoFar, maxEndingHere[i])
        /// 
        /// WHY THIS WORKS:
        /// If maxEndingHere[i-1] is negative, adding it to arr[i] 
        /// only makes arr[i] smaller. Better to start fresh!
        /// 
        /// FOLLOW-UP: Can you also return the start and end indices?
        /// </summary>
        public static int MaxSubarraySum(int[] arr)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// BONUS: Return the actual subarray, not just the sum
        /// </summary>
        public static int[] MaxSubarrayWithIndices(int[] arr, out int start, out int end)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestKadanesAlgorithm()
        {
            Console.WriteLine("=== PROBLEM 1: Maximum Subarray Sum (Kadane's) ===\n");
            
            int[] test1 = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            Console.WriteLine($"Input: [{string.Join(", ", test1)}]");
            Console.WriteLine($"Expected: 6 (subarray [4, -1, 2, 1])");
            // Console.WriteLine($"Your Answer: {MaxSubarraySum(test1)}");
            Console.WriteLine();
            
            int[] test2 = { -1, -2, -3, -4 };
            Console.WriteLine($"Input: [{string.Join(", ", test2)}]");
            Console.WriteLine($"Expected: -1 (all negative, pick least negative)");
            // Console.WriteLine($"Your Answer: {MaxSubarraySum(test2)}");
            Console.WriteLine();
            
            int[] test3 = { 5, -3, 5 };
            Console.WriteLine($"Input: [{string.Join(", ", test3)}]");
            Console.WriteLine($"Expected: 7 (entire array)");
            // Console.WriteLine($"Your Answer: {MaxSubarraySum(test3)}");
            Console.WriteLine();
        }

        #endregion

        #region PROBLEM 2: Trapping Rain Water

        /// <summary>
        /// PROBLEM 2: Trapping Rain Water
        /// 
        /// Difficulty: ⭐⭐⭐⭐
        /// Time: O(n) | Space: O(1)
        /// 
        /// Given heights representing an elevation map where width of each bar is 1,
        /// compute how much water it can trap after raining.
        /// 
        /// Example:
        ///   Input: [0,1,0,2,1,0,1,3,2,1,2,1]
        ///   Output: 6
        /// 
        /// Visualization:
        ///        █
        ///    █ ▓▓█▓█
        ///  █▓█▓█▓█▓█
        /// ─────────────
        /// ▓ = trapped water
        /// 
        /// THE INSIGHT (Two Pointers):
        /// Water level at position i = min(maxLeft, maxRight) - height[i]
        /// 
        /// Use two pointers from both ends:
        /// - Track leftMax and rightMax
        /// - Move pointer with smaller max (that's the bottleneck!)
        /// - Add water at that position
        /// 
        /// WHY THIS WORKS:
        /// The amount of water above position i is limited by the 
        /// minimum of the tallest bars on its left and right.
        /// By moving from the side with smaller max, we ensure 
        /// we know the bottleneck for that position.
        /// 
        /// This is a CLASSIC problem asked by Google, Amazon, Meta!
        /// </summary>
        public static int TrapRainWater(int[] heights)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestTrappingRainWater()
        {
            Console.WriteLine("=== PROBLEM 2: Trapping Rain Water ===\n");
            
            int[] test1 = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            Console.WriteLine($"Input: [{string.Join(", ", test1)}]");
            Console.WriteLine(@"
       █
   █ ▓▓█▓█
 █▓█▓█▓█▓█
Expected: 6 units of water");
            // Console.WriteLine($"Your Answer: {TrapRainWater(test1)}");
            Console.WriteLine();
            
            int[] test2 = { 4, 2, 0, 3, 2, 5 };
            Console.WriteLine($"Input: [{string.Join(", ", test2)}]");
            Console.WriteLine("Expected: 9");
            // Console.WriteLine($"Your Answer: {TrapRainWater(test2)}");
            Console.WriteLine();
        }

        #endregion

        #region PROBLEM 3: Maximum Product Subarray

        /// <summary>
        /// PROBLEM 3: Maximum Product Subarray
        /// 
        /// Difficulty: ⭐⭐⭐⭐
        /// Time: O(n) | Space: O(1)
        /// 
        /// Find the contiguous subarray with the largest product.
        /// 
        /// Example:
        ///   Input: [2, 3, -2, 4]
        ///   Output: 6 (subarray [2, 3])
        /// 
        /// THE TWIST:
        /// Unlike Kadane's algorithm for sum, products have a twist:
        /// - Negative × Negative = Positive (can become large!)
        /// - Need to track BOTH max and min products
        /// 
        /// Example: [-2, 3, -4]
        /// At -2: max = -2, min = -2
        /// At 3:  max = 3, min = -6 (keep the -6!)
        /// At -4: max = 24 (min × -4 = -6 × -4), min = -12
        /// 
        /// THE INSIGHT:
        /// Keep track of both maxProduct and minProduct ending at current position.
        /// When you see a negative number, maxProduct and minProduct swap roles!
        /// 
        /// IMPLEMENTATION:
        /// maxProduct = max(arr[i], maxProduct × arr[i], minProduct × arr[i])
        /// minProduct = min(arr[i], maxProduct × arr[i], minProduct × arr[i])
        /// 
        /// Edge cases:
        /// - What if array contains 0?
        /// - All negative numbers?
        /// </summary>
        public static int MaxProductSubarray(int[] arr)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestMaxProductSubarray()
        {
            Console.WriteLine("=== PROBLEM 3: Maximum Product Subarray ===\n");
            
            int[] test1 = { 2, 3, -2, 4 };
            Console.WriteLine($"Input: [{string.Join(", ", test1)}]");
            Console.WriteLine($"Expected: 6 (subarray [2, 3])");
            // Console.WriteLine($"Your Answer: {MaxProductSubarray(test1)}");
            Console.WriteLine();
            
            int[] test2 = { -2, 0, -1 };
            Console.WriteLine($"Input: [{string.Join(", ", test2)}]");
            Console.WriteLine($"Expected: 0");
            // Console.WriteLine($"Your Answer: {MaxProductSubarray(test2)}");
            Console.WriteLine();
            
            int[] test3 = { -2, 3, -4 };
            Console.WriteLine($"Input: [{string.Join(", ", test3)}]");
            Console.WriteLine($"Expected: 24 (entire array)");
            // Console.WriteLine($"Your Answer: {MaxProductSubarray(test3)}");
            Console.WriteLine();
        }

        #endregion

        #region PROBLEM 4: Longest Consecutive Sequence

        /// <summary>
        /// PROBLEM 4: Longest Consecutive Sequence
        /// 
        /// Difficulty: ⭐⭐⭐⭐
        /// Time: O(n) | Space: O(n)
        /// 
        /// Find the length of the longest consecutive elements sequence.
        /// Your algorithm must run in O(n) time.
        /// 
        /// Example:
        ///   Input: [100, 4, 200, 1, 3, 2]
        ///   Output: 4 (sequence [1, 2, 3, 4])
        /// 
        /// NAIVE APPROACH: O(n log n)
        /// Sort the array, then find longest consecutive run.
        /// 
        /// OPTIMAL APPROACH: O(n) using HashSet
        /// 
        /// THE INSIGHT:
        /// Use a HashSet for O(1) lookups.
        /// For each number, only start counting if it's the START of a sequence.
        /// How to know if it's a start? Check if (num - 1) exists!
        /// 
        /// Example: [100, 4, 200, 1, 3, 2]
        /// HashSet: {100, 4, 200, 1, 3, 2}
        /// 
        /// Check 100: 99 not in set → START of sequence
        ///   Check 101, 102... not in set → length = 1
        /// 
        /// Check 4: 3 in set → NOT a start, skip
        /// 
        /// Check 200: 199 not in set → START
        ///   Check 201... not in set → length = 1
        /// 
        /// Check 1: 0 not in set → START of sequence
        ///   Check 2 (exists), 3 (exists), 4 (exists), 5 (doesn't) → length = 4
        /// 
        /// WHY O(n)?
        /// Each element is visited at most twice:
        /// 1. Once when we check if it's a start
        /// 2. Once when we're counting from a previous start
        /// </summary>
        public static int LongestConsecutive(int[] arr)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestLongestConsecutiveSequence()
        {
            Console.WriteLine("=== PROBLEM 4: Longest Consecutive Sequence ===\n");
            
            int[] test1 = { 100, 4, 200, 1, 3, 2 };
            Console.WriteLine($"Input: [{string.Join(", ", test1)}]");
            Console.WriteLine($"Expected: 4 (sequence [1, 2, 3, 4])");
            // Console.WriteLine($"Your Answer: {LongestConsecutive(test1)}");
            Console.WriteLine();
            
            int[] test2 = { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 };
            Console.WriteLine($"Input: [{string.Join(", ", test2)}]");
            Console.WriteLine($"Expected: 9 (sequence [0,1,2,3,4,5,6,7,8])");
            // Console.WriteLine($"Your Answer: {LongestConsecutive(test2)}");
            Console.WriteLine();
        }

        #endregion

        #region PROBLEM 5: Median of Two Sorted Arrays

        /// <summary>
        /// PROBLEM 5: Median of Two Sorted Arrays
        /// 
        /// Difficulty: ⭐⭐⭐⭐⭐ (VERY HARD - LeetCode Hard)
        /// Time: O(log(min(m, n))) | Space: O(1)
        /// 
        /// Find the median of two sorted arrays.
        /// 
        /// Example 1:
        ///   Input: arr1 = [1, 3], arr2 = [2]
        ///   Output: 2.0
        ///   Explanation: Merged = [1, 2, 3], median = 2
        /// 
        /// Example 2:
        ///   Input: arr1 = [1, 2], arr2 = [3, 4]
        ///   Output: 2.5
        ///   Explanation: Merged = [1, 2, 3, 4], median = (2 + 3) / 2 = 2.5
        /// 
        /// NAIVE APPROACH: O(m + n)
        /// Merge both arrays, find median.
        /// 
        /// OPTIMAL APPROACH: O(log(min(m, n))) using Binary Search
        /// 
        /// THE INSIGHT:
        /// We don't need to merge! We just need to partition both arrays
        /// such that:
        /// 1. Left half has same number of elements as right half
        /// 2. Every element in left half ≤ every element in right half
        /// 
        /// Visualization:
        ///   arr1: [1  2  3  4  5  6]
        ///              ↑
        ///         left | right
        /// 
        ///   arr2: [7  8  9  10  11  12  13  14]
        ///                    ↑
        ///              left  | right
        /// 
        /// Conditions for valid partition:
        /// - max(left1) ≤ min(right2)
        /// - max(left2) ≤ min(right1)
        /// 
        /// Then median = average of max(left1, left2) and min(right1, right2)
        /// 
        /// Binary search on the smaller array to find correct partition!
        /// 
        /// This is one of the HARDEST interview questions.
        /// Don't feel bad if it takes multiple attempts!
        /// 
        /// HINT: Work through examples on paper first!
        /// </summary>
        public static double FindMedianSortedArrays(int[] arr1, int[] arr2)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestMedianOfTwoSortedArrays()
        {
            Console.WriteLine("=== PROBLEM 5: Median of Two Sorted Arrays ===\n");
            
            int[] test1a = { 1, 3 };
            int[] test1b = { 2 };
            Console.WriteLine($"Input: [{string.Join(", ", test1a)}], [{string.Join(", ", test1b)}]");
            Console.WriteLine($"Expected: 2.0");
            // Console.WriteLine($"Your Answer: {FindMedianSortedArrays(test1a, test1b)}");
            Console.WriteLine();
            
            int[] test2a = { 1, 2 };
            int[] test2b = { 3, 4 };
            Console.WriteLine($"Input: [{string.Join(", ", test2a)}], [{string.Join(", ", test2b)}]");
            Console.WriteLine($"Expected: 2.5");
            // Console.WriteLine($"Your Answer: {FindMedianSortedArrays(test2a, test2b)}");
            Console.WriteLine();
        }

        #endregion

        #region PROBLEM 6: Next Permutation

        /// <summary>
        /// PROBLEM 6: Next Permutation
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Time: O(n) | Space: O(1)
        /// 
        /// Find the next lexicographically greater permutation.
        /// If no such permutation exists, return the lowest possible order (sorted).
        /// 
        /// Example:
        ///   Input: [1, 2, 3]
        ///   Output: [1, 3, 2]
        /// 
        ///   Input: [3, 2, 1]
        ///   Output: [1, 2, 3] (no next permutation, wrap around)
        /// 
        ///   Input: [1, 5, 8, 4, 7, 6, 5, 3, 1]
        ///   Output: [1, 5, 8, 5, 1, 3, 4, 6, 7]
        /// 
        /// ALGORITHM:
        /// 1. Find the largest index i such that arr[i] < arr[i + 1]
        ///    (Find the "pivot" - rightmost ascending position)
        /// 2. If no such index exists, reverse the entire array
        /// 3. Find the largest index j > i such that arr[i] < arr[j]
        /// 4. Swap arr[i] and arr[j]
        /// 5. Reverse the subarray arr[i + 1...end]
        /// 
        /// Example: [1, 5, 8, 4, 7, 6, 5, 3, 1]
        ///                    ↑ (pivot at index 3)
        /// 
        /// Step 1: pivot = 4 (at index 3)
        /// Step 2: Find rightmost element > 4 → 5 (at index 6)
        /// Step 3: Swap 4 and 5 → [1, 5, 8, 5, 7, 6, 4, 3, 1]
        /// Step 4: Reverse [7, 6, 4, 3, 1] → [1, 5, 8, 5, 1, 3, 4, 6, 7]
        /// 
        /// WHY THIS WORKS:
        /// We want the next larger permutation, so we need to:
        /// 1. Make a small increase (swap pivot with next larger element)
        /// 2. Minimize the rest (reverse to get smallest arrangement)
        /// </summary>
        public static void NextPermutation(int[] arr)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestNextPermutation()
        {
            Console.WriteLine("=== PROBLEM 6: Next Permutation ===\n");
            
            int[] test1 = { 1, 2, 3 };
            Console.WriteLine($"Input: [{string.Join(", ", test1)}]");
            Console.WriteLine($"Expected: [1, 3, 2]");
            // NextPermutation(test1);
            // Console.WriteLine($"Your Answer: [{string.Join(", ", test1)}]");
            Console.WriteLine();
            
            int[] test2 = { 3, 2, 1 };
            Console.WriteLine($"Input: [{string.Join(", ", test2)}]");
            Console.WriteLine($"Expected: [1, 2, 3]");
            // NextPermutation(test2);
            // Console.WriteLine($"Your Answer: [{string.Join(", ", test2)}]");
            Console.WriteLine();
            
            int[] test3 = { 1, 5, 8, 4, 7, 6, 5, 3, 1 };
            Console.WriteLine($"Input: [{string.Join(", ", test3)}]");
            Console.WriteLine($"Expected: [1, 5, 8, 5, 1, 3, 4, 6, 7]");
            // NextPermutation(test3);
            // Console.WriteLine($"Your Answer: [{string.Join(", ", test3)}]");
            Console.WriteLine();
        }

        #endregion

        #region PROBLEM 7: Merge Intervals

        /// <summary>
        /// PROBLEM 7: Merge Overlapping Intervals
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Time: O(n log n) | Space: O(n)
        /// 
        /// Given a collection of intervals, merge all overlapping intervals.
        /// 
        /// Example:
        ///   Input: [[1,3], [2,6], [8,10], [15,18]]
        ///   Output: [[1,6], [8,10], [15,18]]
        ///   
        ///   Explanation: [1,3] and [2,6] overlap → [1,6]
        /// 
        /// ALGORITHM:
        /// 1. Sort intervals by start time
        /// 2. Iterate through sorted intervals
        /// 3. If current interval overlaps with previous merged interval, merge them
        /// 4. Otherwise, add current interval to result
        /// 
        /// OVERLAP CONDITION:
        /// Two intervals [a, b] and [c, d] overlap if:
        /// c ≤ b (second interval starts before or when first interval ends)
        /// 
        /// Example walkthrough:
        /// Input: [[1,3], [2,6], [8,10], [15,18]]
        /// 
        /// After sort (already sorted): [[1,3], [2,6], [8,10], [15,18]]
        /// 
        /// Start with [1,3]
        /// Check [2,6]: 2 ≤ 3? Yes → merge to [1, max(3,6)] = [1,6]
        /// Check [8,10]: 8 ≤ 6? No → add [1,6] to result, start new with [8,10]
        /// Check [15,18]: 15 ≤ 10? No → add [8,10] to result, start new with [15,18]
        /// End: add [15,18] to result
        /// 
        /// Result: [[1,6], [8,10], [15,18]]
        /// </summary>
        public static int[][] MergeIntervals(int[][] intervals)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestMergeIntervals()
        {
            Console.WriteLine("=== PROBLEM 7: Merge Intervals ===\n");
            
            int[][] test1 = { new[] { 1, 3 }, new[] { 2, 6 }, new[] { 8, 10 }, new[] { 15, 18 } };
            Console.WriteLine("Input: [[1,3], [2,6], [8,10], [15,18]]");
            Console.WriteLine("Expected: [[1,6], [8,10], [15,18]]");
            // var result1 = MergeIntervals(test1);
            // Console.Write("Your Answer: [");
            // Console.WriteLine(string.Join(", ", result1.Select(i => $"[{i[0]},{i[1]}]")));
            // Console.WriteLine("]");
            Console.WriteLine();
            
            int[][] test2 = { new[] { 1, 4 }, new[] { 4, 5 } };
            Console.WriteLine("Input: [[1,4], [4,5]]");
            Console.WriteLine("Expected: [[1,5]]");
            // var result2 = MergeIntervals(test2);
            // Console.Write("Your Answer: [");
            // Console.WriteLine(string.Join(", ", result2.Select(i => $"[{i[0]},{i[1]}]")));
            // Console.WriteLine("]");
            Console.WriteLine();
        }

        #endregion

        #region PROBLEM 8: Find Missing Number in Sequence

        /// <summary>
        /// PROBLEM 8: Find Missing Number
        /// 
        /// Difficulty: ⭐⭐
        /// Time: O(n) | Space: O(1)
        /// 
        /// Given an array containing n distinct numbers in range [0, n],
        /// find the one number that is missing.
        /// 
        /// Example:
        ///   Input: [3, 0, 1]
        ///   Output: 2 (range is [0, 3], 2 is missing)
        /// 
        ///   Input: [9,6,4,2,3,5,7,0,1]
        ///   Output: 8
        /// 
        /// MULTIPLE SOLUTIONS:
        /// 
        /// Solution 1: Sum Formula
        /// Expected sum = n × (n + 1) / 2
        /// Actual sum = sum of array elements
        /// Missing = Expected - Actual
        /// 
        /// Solution 2: XOR (Clever!)
        /// Property: a ⊕ a = 0, a ⊕ 0 = a
        /// XOR all numbers from 0 to n with all array elements
        /// All present numbers cancel out, missing number remains!
        /// 
        /// Example: [3, 0, 1], n = 3
        /// XOR: 0 ⊕ 1 ⊕ 2 ⊕ 3 ⊕ 3 ⊕ 0 ⊕ 1
        ///    = (0 ⊕ 0) ⊕ (1 ⊕ 1) ⊕ 2 ⊕ (3 ⊕ 3)
        ///    = 0 ⊕ 0 ⊕ 2 ⊕ 0
        ///    = 2 ✓
        /// 
        /// Challenge: Implement both ways!
        /// </summary>
        public static int MissingNumber(int[] arr)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestMissingNumber()
        {
            Console.WriteLine("=== PROBLEM 8: Find Missing Number ===\n");
            
            int[] test1 = { 3, 0, 1 };
            Console.WriteLine($"Input: [{string.Join(", ", test1)}]");
            Console.WriteLine($"Expected: 2");
            // Console.WriteLine($"Your Answer: {MissingNumber(test1)}");
            Console.WriteLine();
            
            int[] test2 = { 9, 6, 4, 2, 3, 5, 7, 0, 1 };
            Console.WriteLine($"Input: [{string.Join(", ", test2)}]");
            Console.WriteLine($"Expected: 8");
            // Console.WriteLine($"Your Answer: {MissingNumber(test2)}");
            Console.WriteLine();
        }

        #endregion

        #region BONUS: Stock Buy/Sell Problems

        /// <summary>
        /// BONUS PROBLEM: Best Time to Buy and Sell Stock
        /// 
        /// Difficulty: ⭐⭐
        /// Time: O(n) | Space: O(1)
        /// 
        /// You can buy once and sell once. Maximize profit.
        /// 
        /// Example:
        ///   Input: [7, 1, 5, 3, 6, 4]
        ///   Output: 5 (buy at 1, sell at 6)
        /// 
        /// THE INSIGHT:
        /// Track minimum price seen so far.
        /// At each price, calculate profit if we sell now.
        /// Keep track of maximum profit.
        /// 
        /// Why? We want to buy at lowest point before a peak!
        /// </summary>
        public static int MaxProfit(int[] prices)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// BONUS PROBLEM 2: Buy and Sell Stock II (Multiple Transactions)
        /// 
        /// Difficulty: ⭐⭐
        /// Time: O(n) | Space: O(1)
        /// 
        /// You can buy and sell multiple times.
        /// But you must sell before buying again.
        /// 
        /// Example:
        ///   Input: [7, 1, 5, 3, 6, 4]
        ///   Output: 7 (buy at 1, sell at 5: profit 4, buy at 3, sell at 6: profit 3)
        /// 
        /// THE INSIGHT:
        /// Add up all positive differences!
        /// If tomorrow's price > today's price, we make that profit.
        /// 
        /// This is like saying: buy today, sell tomorrow if profitable,
        /// repeat. (Equivalent to holding through uptrends)
        /// </summary>
        public static int MaxProfitMultiple(int[] prices)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestStockProblems()
        {
            Console.WriteLine("=== BONUS: Stock Buy/Sell Problems ===\n");
            
            int[] test1 = { 7, 1, 5, 3, 6, 4 };
            Console.WriteLine($"Input: [{string.Join(", ", test1)}]");
            Console.WriteLine("Single transaction - Expected: 5");
            // Console.WriteLine($"Your Answer: {MaxProfit(test1)}");
            Console.WriteLine("Multiple transactions - Expected: 7");
            // Console.WriteLine($"Your Answer: {MaxProfitMultiple(test1)}");
            Console.WriteLine();
        }

        #endregion
    }
}
