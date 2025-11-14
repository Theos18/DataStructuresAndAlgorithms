using System;
using System.Collections.Generic;
using System.Linq;

namespace TwoPointersAlgorithms
{
    /// <summary>
    /// Two Pointers: Intuition-Building Problems
    /// 
    /// "I hear and I forget. I see and I remember. I do and I understand." - Confucius
    /// 
    /// INSTRUCTIONS:
    /// These problems are designed to build intuition, not test pattern matching.
    /// 
    /// For EACH problem:
    /// 1. Read the problem carefully
    /// 2. Ask yourself: "What's the brute force approach?"
    /// 3. Ask: "What redundant work am I doing?"
    /// 4. Ask: "Can I eliminate candidates? How?"
    /// 5. Identify which two-pointer type applies
    /// 6. State your invariant BEFORE coding
    /// 7. Implement and test
    /// 
    /// Don't just code—UNDERSTAND WHY your approach works!
    /// </summary>
    class TwoPointersProblems
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== TWO POINTERS: INTUITION-BUILDING PROBLEMS ===\n");
            
            // Uncomment as you solve each section
            // TestLevel1_OppositeDirection();
            // TestLevel2_SameDirection();
            // TestLevel3_MultipleArrays();
            // TestLevel4_Partitioning();
            // TestLevel5_Advanced();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        #region LEVEL 1: OPPOSITE DIRECTION - Build Core Intuition

        /// <summary>
        /// PROBLEM 1.1: Two Sum in Sorted Array
        /// 
        /// Difficulty: ⭐⭐ (Foundational)
        /// Type: Opposite Direction
        /// 
        /// Given a SORTED array, find two numbers that sum to target.
        /// Return their indices (0-based).
        /// 
        /// Example:
        ///   Input: arr = [2, 7, 11, 15], target = 9
        ///   Output: [0, 1] (because arr[0] + arr[1] = 2 + 7 = 9)
        /// 
        /// BEFORE CODING, ANSWER:
        /// 1. What's the brute force approach and its complexity?
        /// 2. Why does starting at opposite ends make sense?
        /// 3. If sum is too large, which pointer should move? WHY?
        /// 4. If sum is too small, which pointer should move? WHY?
        /// 5. What candidates are eliminated with each move?
        /// 
        /// State your invariant: "At any point, the solution must be..."
        /// </summary>
        public static int[] TwoSumSorted(int[] arr, int target)
        {
            // YOUR INVARIANT HERE:
            // 
            
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 1.2: Three Sum
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Type: Opposite Direction (nested)
        /// 
        /// Find all unique triplets [a, b, c] where a + b + c = 0.
        /// 
        /// Example:
        ///   Input: [-1, 0, 1, 2, -1, -4]
        ///   Output: [[-1, -1, 2], [-1, 0, 1]]
        /// 
        /// INTUITION QUESTIONS:
        /// 1. How can you reduce this to Two Sum?
        /// 2. Fix one element, what are you looking for in the rest?
        /// 3. How do you avoid duplicate triplets?
        /// 4. Why must you sort first?
        /// 
        /// HINT: Think of it as: for each arr[i], find two numbers that sum to -arr[i]
        /// </summary>
        public static List<List<int>> ThreeSum(int[] arr)
        {
            // YOUR APPROACH:
            // Step 1: Fix first element
            // Step 2: Use two pointers on remaining array for Two Sum
            // Step 3: Handle duplicates
            
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 1.3: Container With Most Water
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Type: Opposite Direction
        /// 
        /// You have an array of heights. Find two lines that together with x-axis
        /// form a container that holds the most water.
        /// 
        /// Example:
        ///   Input: [1, 8, 6, 2, 5, 4, 8, 3, 7]
        ///   Output: 49
        ///   Explanation: heights[1] = 8 and heights[8] = 7
        ///                Area = min(8, 7) × (8 - 1) = 7 × 7 = 49
        /// 
        /// DEEP THINKING:
        /// 1. Area = width × min(height[left], height[right])
        /// 2. Start with maximum width. How to improve?
        /// 3. When should you move left pointer? When should you move right?
        /// 4. Which line is the "bottleneck"?
        /// 5. Why does moving the taller line never help?
        /// 
        /// KEY INSIGHT: Always move the SHORTER line!
        /// WHY? The shorter line limits the height. Moving it gives a chance
        /// of finding a taller line. Moving the taller line can only maintain
        /// or decrease the height while width definitely decreases.
        /// </summary>
        public static int MaxArea(int[] heights)
        {
            // INVARIANT: 
            // We've checked all containers with width > (right - left)
            
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 1.4: Valid Palindrome
        /// 
        /// Difficulty: ⭐
        /// Type: Opposite Direction
        /// 
        /// Given a string, determine if it's a palindrome, considering only
        /// alphanumeric characters and ignoring cases.
        /// 
        /// Example:
        ///   Input: "A man, a plan, a canal: Panama"
        ///   Output: true
        /// 
        /// INTUITION:
        /// 1. Palindrome means same forwards and backwards
        /// 2. Compare characters from both ends
        /// 3. If they match, move both pointers inward
        /// 4. If they don't match, not a palindrome
        /// 
        /// This is the SIMPLEST two-pointer pattern!
        /// </summary>
        public static bool IsPalindrome(string s)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 1.5: Trapping Rain Water
        /// 
        /// Difficulty: ⭐⭐⭐⭐ (HARD but teaches deep intuition!)
        /// Type: Opposite Direction
        /// 
        /// Given heights of bars, calculate how much water can be trapped after rain.
        /// 
        /// Example:
        ///   Input: [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1]
        ///   Output: 6
        /// 
        /// VISUALIZATION:
        ///        █
        ///    █ ▓▓█▓█
        ///  █▓█▓█▓█▓█
        /// ▓ = water
        /// 
        /// DEEP INTUITION:
        /// 1. Water at position i = min(maxLeft, maxRight) - height[i]
        /// 2. We need maxLeft and maxRight for each position
        /// 3. Traditional approach: Two passes to calculate these → O(n), but uses O(n) space
        /// 4. Two pointers approach: Calculate on the fly!
        /// 
        /// KEY INSIGHT:
        /// If heights[left] < heights[right]:
        ///   - The LEFT side is the bottleneck
        ///   - We can calculate water at left position NOW
        ///   - We know maxRight ≥ heights[right] (it's right there!)
        ///   - Water at left = maxLeft - heights[left]
        /// 
        /// Think about WHY this works! Draw it out!
        /// </summary>
        public static int TrapRainWater(int[] heights)
        {
            // VARIABLES NEEDED:
            // - left, right pointers
            // - leftMax, rightMax (maximum heights seen so far from each side)
            // - water (accumulated)
            
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestLevel1_OppositeDirection()
        {
            Console.WriteLine("=== LEVEL 1: OPPOSITE DIRECTION ===\n");
            
            // Test 1.1
            Console.WriteLine("Problem 1.1: Two Sum (Sorted)");
            int[] test1 = { 2, 7, 11, 15 };
            Console.WriteLine($"Input: [{string.Join(", ", test1)}], target = 9");
            Console.WriteLine("Expected: [0, 1]");
            // var result1 = TwoSumSorted(test1, 9);
            // Console.WriteLine($"Your Answer: [{string.Join(", ", result1)}]");
            Console.WriteLine();
            
            // Test 1.2
            Console.WriteLine("Problem 1.2: Three Sum");
            int[] test2 = { -1, 0, 1, 2, -1, -4 };
            Console.WriteLine($"Input: [{string.Join(", ", test2)}]");
            Console.WriteLine("Expected: [[-1, -1, 2], [-1, 0, 1]]");
            // var result2 = ThreeSum(test2);
            Console.WriteLine();
            
            // Test 1.3
            Console.WriteLine("Problem 1.3: Container With Most Water");
            int[] test3 = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            Console.WriteLine($"Input: [{string.Join(", ", test3)}]");
            Console.WriteLine("Expected: 49");
            // Console.WriteLine($"Your Answer: {MaxArea(test3)}");
            Console.WriteLine();
            
            // Test 1.4
            Console.WriteLine("Problem 1.4: Valid Palindrome");
            string test4 = "A man, a plan, a canal: Panama";
            Console.WriteLine($"Input: \"{test4}\"");
            Console.WriteLine("Expected: true");
            // Console.WriteLine($"Your Answer: {IsPalindrome(test4)}");
            Console.WriteLine();
            
            // Test 1.5
            Console.WriteLine("Problem 1.5: Trapping Rain Water");
            int[] test5 = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            Console.WriteLine($"Input: [{string.Join(", ", test5)}]");
            Console.WriteLine("Expected: 6");
            // Console.WriteLine($"Your Answer: {TrapRainWater(test5)}");
            Console.WriteLine();
        }

        #endregion

        #region LEVEL 2: SAME DIRECTION - In-Place Modifications

        /// <summary>
        /// PROBLEM 2.1: Remove Duplicates from Sorted Array
        /// 
        /// Difficulty: ⭐⭐
        /// Type: Same Direction (Fast/Slow)
        /// 
        /// Remove duplicates in-place from sorted array. Return new length.
        /// 
        /// Example:
        ///   Input: [1, 1, 2, 2, 2, 3, 4, 4]
        ///   Output: 4, array becomes [1, 2, 3, 4, ...]
        /// 
        /// INTUITION:
        /// 1. slow = position for next unique element
        /// 2. fast = scans through array
        /// 3. When arr[fast] != arr[slow-1], found new unique → place at slow
        /// 
        /// INVARIANT: Elements [0, slow) are unique
        /// </summary>
        public static int RemoveDuplicates(int[] arr)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 2.2: Move Zeros to End
        /// 
        /// Difficulty: ⭐⭐
        /// Type: Same Direction
        /// 
        /// Move all zeros to end while maintaining relative order of non-zeros.
        /// 
        /// Example:
        ///   Input: [0, 1, 0, 3, 12]
        ///   Output: [1, 3, 12, 0, 0]
        /// 
        /// APPROACH 1: Collect non-zeros, then fill zeros
        /// APPROACH 2: Swap non-zeros to front (elegant!)
        /// 
        /// THINK: What's your invariant for each approach?
        /// </summary>
        public static void MoveZeros(int[] arr)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 2.3: Remove Element
        /// 
        /// Difficulty: ⭐
        /// Type: Same Direction
        /// 
        /// Remove all instances of a value in-place. Return new length.
        /// 
        /// Example:
        ///   Input: arr = [3, 2, 2, 3], val = 3
        ///   Output: 2, array becomes [2, 2, ...]
        /// 
        /// SIMILAR TO: Remove Duplicates
        /// But now we're removing a specific value, not duplicates.
        /// 
        /// Can you see the pattern?
        /// </summary>
        public static int RemoveElement(int[] arr, int val)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 2.4: Partition Array
        /// 
        /// Difficulty: ⭐⭐
        /// Type: Same Direction
        /// 
        /// Rearrange array so all elements < pivot come before all elements ≥ pivot.
        /// Return index where pivot region starts.
        /// 
        /// Example:
        ///   Input: [3, 5, 1, 2, 4, 2], pivot = 3
        ///   Output: 3, array might become [1, 2, 2, 3, 5, 4]
        /// 
        /// This is the CORE of QuickSort!
        /// 
        /// INVARIANT: 
        /// - Elements [0, slow) are < pivot
        /// - Elements [slow, fast) are ≥ pivot
        /// - Elements [fast, n) are unprocessed
        /// </summary>
        public static int PartitionArray(int[] arr, int pivot)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 2.5: Sort Array by Parity
        /// 
        /// Difficulty: ⭐⭐
        /// Type: Same Direction
        /// 
        /// Rearrange so all even numbers come before all odd numbers.
        /// 
        /// Example:
        ///   Input: [3, 1, 2, 4]
        ///   Output: [2, 4, 3, 1] (or any arrangement with evens first)
        /// 
        /// THINK: This is similar to Partition Array!
        /// What's your "pivot" concept here?
        /// </summary>
        public static int[] SortByParity(int[] arr)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestLevel2_SameDirection()
        {
            Console.WriteLine("=== LEVEL 2: SAME DIRECTION ===\n");
            
            Console.WriteLine("Problem 2.1: Remove Duplicates");
            int[] test1 = { 1, 1, 2, 2, 2, 3, 4, 4 };
            Console.WriteLine($"Input: [{string.Join(", ", test1)}]");
            Console.WriteLine("Expected: 4");
            Console.WriteLine();
            
            Console.WriteLine("Problem 2.2: Move Zeros");
            int[] test2 = { 0, 1, 0, 3, 12 };
            Console.WriteLine($"Input: [{string.Join(", ", test2)}]");
            Console.WriteLine("Expected: [1, 3, 12, 0, 0]");
            Console.WriteLine();
            
            Console.WriteLine("Problem 2.3: Remove Element");
            int[] test3 = { 3, 2, 2, 3 };
            Console.WriteLine($"Input: [{string.Join(", ", test3)}], val = 3");
            Console.WriteLine("Expected: 2");
            Console.WriteLine();
            
            Console.WriteLine("Problem 2.4: Partition Array");
            int[] test4 = { 3, 5, 1, 2, 4, 2 };
            Console.WriteLine($"Input: [{string.Join(", ", test4)}], pivot = 3");
            Console.WriteLine("Expected: 3 (elements < 3 come first)");
            Console.WriteLine();
            
            Console.WriteLine("Problem 2.5: Sort by Parity");
            int[] test5 = { 3, 1, 2, 4 };
            Console.WriteLine($"Input: [{string.Join(", ", test5)}]");
            Console.WriteLine("Expected: [2, 4, 3, 1] (evens first)");
            Console.WriteLine();
        }

        #endregion

        #region LEVEL 3: MULTIPLE ARRAYS - Coordination

        /// <summary>
        /// PROBLEM 3.1: Merge Two Sorted Arrays
        /// 
        /// Difficulty: ⭐⭐
        /// Type: Multiple Arrays
        /// 
        /// Merge two sorted arrays into one sorted array.
        /// 
        /// Example:
        ///   Input: arr1 = [1, 3, 5], arr2 = [2, 4, 6]
        ///   Output: [1, 2, 3, 4, 5, 6]
        /// 
        /// INTUITION:
        /// Compare elements at both pointers, take smaller one.
        /// This is the MERGE step in MergeSort!
        /// </summary>
        public static int[] MergeSortedArrays(int[] arr1, int[] arr2)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 3.2: Intersection of Two Sorted Arrays
        /// 
        /// Difficulty: ⭐⭐
        /// Type: Multiple Arrays
        /// 
        /// Find common elements in both sorted arrays.
        /// 
        /// Example:
        ///   Input: arr1 = [1, 2, 2, 3], arr2 = [2, 2, 3, 4]
        ///   Output: [2, 2, 3]
        /// 
        /// DECISION LOGIC:
        /// If arr1[i] == arr2[j]: Found intersection, move both
        /// If arr1[i] < arr2[j]: arr1[i] too small, move i
        /// If arr1[i] > arr2[j]: arr2[j] too small, move j
        /// </summary>
        public static List<int> IntersectionSorted(int[] arr1, int[] arr2)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 3.3: Merge Intervals
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Type: Multiple Arrays (conceptually)
        /// 
        /// Given intervals, merge all overlapping ones.
        /// 
        /// Example:
        ///   Input: [[1,3], [2,6], [8,10], [15,18]]
        ///   Output: [[1,6], [8,10], [15,18]]
        /// 
        /// APPROACH:
        /// 1. Sort intervals by start time
        /// 2. Use pointer to track "current merged interval"
        /// 3. Compare next interval with current
        /// 4. Merge if overlap, otherwise start new interval
        /// 
        /// OVERLAP CONDITION: next.start ≤ current.end
        /// </summary>
        public static int[][] MergeIntervals(int[][] intervals)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestLevel3_MultipleArrays()
        {
            Console.WriteLine("=== LEVEL 3: MULTIPLE ARRAYS ===\n");
            
            Console.WriteLine("Problem 3.1: Merge Sorted Arrays");
            int[] test1a = { 1, 3, 5 };
            int[] test1b = { 2, 4, 6 };
            Console.WriteLine($"Input: [{string.Join(", ", test1a)}], [{string.Join(", ", test1b)}]");
            Console.WriteLine("Expected: [1, 2, 3, 4, 5, 6]");
            Console.WriteLine();
            
            Console.WriteLine("Problem 3.2: Intersection");
            int[] test2a = { 1, 2, 2, 3 };
            int[] test2b = { 2, 2, 3, 4 };
            Console.WriteLine($"Input: [{string.Join(", ", test2a)}], [{string.Join(", ", test2b)}]");
            Console.WriteLine("Expected: [2, 2, 3]");
            Console.WriteLine();
            
            Console.WriteLine("Problem 3.3: Merge Intervals");
            Console.WriteLine("Input: [[1,3], [2,6], [8,10], [15,18]]");
            Console.WriteLine("Expected: [[1,6], [8,10], [15,18]]");
            Console.WriteLine();
        }

        #endregion

        #region LEVEL 4: PARTITIONING - Region Control

        /// <summary>
        /// PROBLEM 4.1: Sort Colors (Dutch National Flag)
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Type: Partitioning
        /// 
        /// Sort array containing only 0s, 1s, and 2s in-place.
        /// 
        /// Example:
        ///   Input: [2, 0, 2, 1, 1, 0]
        ///   Output: [0, 0, 1, 1, 2, 2]
        /// 
        /// THREE POINTERS:
        /// - low: boundary of 0s
        /// - mid: current element
        /// - high: boundary of 2s
        /// 
        /// INVARIANT:
        /// [0, low): all 0s
        /// [low, mid): all 1s
        /// (high, n-1]: all 2s
        /// [mid, high]: unknown
        /// 
        /// DECISION:
        /// If arr[mid] == 0: swap with low, move both
        /// If arr[mid] == 1: just move mid
        /// If arr[mid] == 2: swap with high, move high (don't move mid!)
        /// </summary>
        public static void SortColors(int[] arr)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 4.2: Partition into Three Parts
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Type: Partitioning
        /// 
        /// Partition array into three parts: < pivot, == pivot, > pivot
        /// 
        /// Example:
        ///   Input: [3, 5, 1, 3, 2, 3, 4], pivot = 3
        ///   Output: [1, 2, 3, 3, 3, 5, 4] (any order within each part)
        /// 
        /// This generalizes Sort Colors!
        /// </summary>
        public static void ThreeWayPartition(int[] arr, int pivot)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestLevel4_Partitioning()
        {
            Console.WriteLine("=== LEVEL 4: PARTITIONING ===\n");
            
            Console.WriteLine("Problem 4.1: Sort Colors");
            int[] test1 = { 2, 0, 2, 1, 1, 0 };
            Console.WriteLine($"Input: [{string.Join(", ", test1)}]");
            Console.WriteLine("Expected: [0, 0, 1, 1, 2, 2]");
            Console.WriteLine();
            
            Console.WriteLine("Problem 4.2: Three-Way Partition");
            int[] test2 = { 3, 5, 1, 3, 2, 3, 4 };
            Console.WriteLine($"Input: [{string.Join(", ", test2)}], pivot = 3");
            Console.WriteLine("Expected: [<3] [==3] [>3]");
            Console.WriteLine();
        }

        #endregion

        #region LEVEL 5: ADVANCED - Combining Techniques

        /// <summary>
        /// PROBLEM 5.1: Four Sum
        /// 
        /// Difficulty: ⭐⭐⭐⭐
        /// Type: Opposite Direction (nested twice!)
        /// 
        /// Find all unique quadruplets [a, b, c, d] where a + b + c + d = target.
        /// 
        /// REDUCTION:
        /// Four Sum → Three Sum → Two Sum
        /// 
        /// Fix two elements (nested loops), use two pointers for remaining two.
        /// </summary>
        public static List<List<int>> FourSum(int[] arr, int target)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 5.2: Boats to Save People
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Type: Opposite Direction
        /// 
        /// Each boat can carry at most 2 people with combined weight ≤ limit.
        /// Find minimum number of boats needed.
        /// 
        /// Example:
        ///   Input: people = [3, 2, 2, 1], limit = 3
        ///   Output: 3 (boats: [1,2], [2], [3])
        /// 
        /// GREEDY INSIGHT:
        /// Pair heaviest person with lightest person.
        /// If they fit together, use 1 boat.
        /// If not, heaviest person needs their own boat.
        /// </summary>
        public static int NumRescueBoats(int[] people, int limit)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 5.3: Subarray Product Less Than K
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Type: Same Direction (Sliding Window variation)
        /// 
        /// Count number of contiguous subarrays where product < k.
        /// 
        /// Example:
        ///   Input: arr = [10, 5, 2, 6], k = 100
        ///   Output: 8
        ///   Subarrays: [10], [5], [2], [6], [10,5], [5,2], [2,6], [5,2,6]
        /// 
        /// INSIGHT:
        /// Use two pointers to maintain window where product < k.
        /// For each right position, count how many subarrays end at right.
        /// </summary>
        public static int NumSubarrayProductLessThanK(int[] arr, int k)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestLevel5_Advanced()
        {
            Console.WriteLine("=== LEVEL 5: ADVANCED ===\n");
            
            Console.WriteLine("Problem 5.1: Four Sum");
            int[] test1 = { 1, 0, -1, 0, -2, 2 };
            Console.WriteLine($"Input: [{string.Join(", ", test1)}], target = 0");
            Console.WriteLine("Expected: [[-2,-1,1,2], [-2,0,0,2], [-1,0,0,1]]");
            Console.WriteLine();
            
            Console.WriteLine("Problem 5.2: Boats to Save People");
            int[] test2 = { 3, 2, 2, 1 };
            Console.WriteLine($"Input: people = [{string.Join(", ", test2)}], limit = 3");
            Console.WriteLine("Expected: 3");
            Console.WriteLine();
            
            Console.WriteLine("Problem 5.3: Subarray Product Less Than K");
            int[] test3 = { 10, 5, 2, 6 };
            Console.WriteLine($"Input: [{string.Join(", ", test3)}], k = 100");
            Console.WriteLine("Expected: 8");
            Console.WriteLine();
        }

        #endregion
    }
}
