using System;
using System.Collections.Generic;
using System.Linq;

namespace SlidingWindowAlgorithms
{
    /// <summary>
    /// Sliding Window: Intuition-Building Problems
    /// 
    /// "The difference between theory and practice is that in theory,
    /// there is no difference between theory and practice."
    /// 
    /// LEARNING APPROACH:
    /// For each problem, BEFORE coding:
    /// 1. Is this fixed or variable window?
    /// 2. What am I tracking in the window?
    /// 3. When do I expand? When do I contract?
    /// 4. How do I update the result?
    /// 
    /// Don't just code—BUILD MENTAL MODELS!
    /// </summary>
    class SlidingWindowProblems
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SLIDING WINDOW: INTUITION-BUILDING PROBLEMS ===\n");
            
            // Uncomment as you solve each section
            // TestLevel1_FixedWindow();
            // TestLevel2_VariableLongest();
            // TestLevel3_VariableShortest();
            // TestLevel4_Counting();
            // TestLevel5_Advanced();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        #region LEVEL 1: FIXED WINDOW - Build Foundation

        /// <summary>
        /// PROBLEM 1.1: Maximum Sum of Subarray of Size K
        /// 
        /// Difficulty: ⭐ (Foundation)
        /// Type: Fixed Window
        /// 
        /// Find the maximum sum of any contiguous subarray of size k.
        /// 
        /// Example:
        ///   Input: arr = [2, 1, 5, 1, 3, 2], k = 3
        ///   Output: 9 (subarray [5, 1, 3])
        /// 
        /// BEFORE CODING:
        /// 1. What's the brute force? Why is it inefficient?
        /// 2. What do you calculate for the first window?
        /// 3. When sliding, what leaves? What enters?
        /// 4. How do you update the sum?
        /// 
        /// INTUITION:
        /// Instead of recalculating sum each time:
        /// New Sum = Old Sum - arr[i-k] + arr[i]
        /// </summary>
        public static int MaxSumSubarrayOfSizeK(int[] arr, int k)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 1.2: Average of Subarrays of Size K
        /// 
        /// Difficulty: ⭐
        /// Type: Fixed Window
        /// 
        /// Calculate average for each subarray of size k.
        /// 
        /// Example:
        ///   Input: arr = [1, 3, 2, 6, -1, 4, 1, 8, 2], k = 5
        ///   Output: [2.2, 2.8, 2.4, 3.6, 2.8]
        /// 
        /// HINT: Use the same sliding window technique!
        /// </summary>
        public static double[] AvgOfSubarrays(int[] arr, int k)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 1.3: Maximum of All Subarrays of Size K
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Type: Fixed Window + Deque
        /// 
        /// Find maximum element in each window of size k.
        /// 
        /// Example:
        ///   Input: arr = [1, 3, -1, -3, 5, 3, 6, 7], k = 3
        ///   Output: [3, 3, 5, 5, 6, 7]
        /// 
        /// CHALLENGE:
        /// Naive approach: O(n × k) - check max in each window
        /// Optimal: O(n) using monotonic deque!
        /// 
        /// INTUITION:
        /// Maintain deque of indices in decreasing order of values.
        /// - Front of deque = maximum in current window
        /// - Remove indices outside window
        /// - Remove indices with smaller values (they can't be future max)
        /// 
        /// WHY THIS WORKS:
        /// If arr[i] > arr[j] and i > j, arr[j] can NEVER be max
        /// in any future window containing i!
        /// </summary>
        public static int[] MaxSlidingWindow(int[] arr, int k)
        {
            // YOUR CODE HERE
            // Use LinkedList<int> as deque
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 1.4: First Negative in Every Window of Size K
        /// 
        /// Difficulty: ⭐⭐
        /// Type: Fixed Window + Queue
        /// 
        /// For each window, find first negative number (or 0 if none).
        /// 
        /// Example:
        ///   Input: arr = [12, -1, -7, 8, -15, 30, 16, 28], k = 3
        ///   Output: [-1, -1, -7, -15, -15, 0]
        /// 
        /// APPROACH:
        /// Use queue to store indices of negative numbers in window.
        /// </summary>
        public static int[] FirstNegativeInWindow(int[] arr, int k)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestLevel1_FixedWindow()
        {
            Console.WriteLine("=== LEVEL 1: FIXED WINDOW ===\n");
            
            // Test 1.1
            Console.WriteLine("Problem 1.1: Max Sum Subarray Size K");
            int[] test1 = { 2, 1, 5, 1, 3, 2 };
            Console.WriteLine($"Input: [{string.Join(", ", test1)}], k = 3");
            Console.WriteLine("Expected: 9");
            // Console.WriteLine($"Your Answer: {MaxSumSubarrayOfSizeK(test1, 3)}");
            Console.WriteLine();
            
            // Test 1.2
            Console.WriteLine("Problem 1.2: Average of Subarrays");
            int[] test2 = { 1, 3, 2, 6, -1, 4, 1, 8, 2 };
            Console.WriteLine($"Input: [{string.Join(", ", test2)}], k = 5");
            Console.WriteLine("Expected: [2.2, 2.8, 2.4, 3.6, 2.8]");
            Console.WriteLine();
            
            // Test 1.3
            Console.WriteLine("Problem 1.3: Max Sliding Window");
            int[] test3 = { 1, 3, -1, -3, 5, 3, 6, 7 };
            Console.WriteLine($"Input: [{string.Join(", ", test3)}], k = 3");
            Console.WriteLine("Expected: [3, 3, 5, 5, 6, 7]");
            Console.WriteLine();
            
            // Test 1.4
            Console.WriteLine("Problem 1.4: First Negative in Window");
            int[] test4 = { 12, -1, -7, 8, -15, 30, 16, 28 };
            Console.WriteLine($"Input: [{string.Join(", ", test4)}], k = 3");
            Console.WriteLine("Expected: [-1, -1, -7, -15, -15, 0]");
            Console.WriteLine();
        }

        #endregion

        #region LEVEL 2: VARIABLE WINDOW - LONGEST

        /// <summary>
        /// PROBLEM 2.1: Longest Substring with At Most K Distinct Characters
        /// 
        /// Difficulty: ⭐⭐
        /// Type: Variable Window (Longest)
        /// 
        /// Find length of longest substring with ≤ k distinct characters.
        /// 
        /// Example:
        ///   Input: s = "eceba", k = 2
        ///   Output: 3 (substring "ece")
        /// 
        /// BEFORE CODING:
        /// 1. How do you track distinct characters?
        /// 2. When do you expand? When do you shrink?
        /// 3. When do you update maxLength?
        /// 
        /// PATTERN:
        /// - Track character frequencies in Dictionary
        /// - Expand: add character to window
        /// - Shrink: while distinct > k, remove from left
        /// - Update: maxLength after shrinking
        /// </summary>
        public static int LongestSubstringKDistinct(string s, int k)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 2.2: Longest Substring Without Repeating Characters
        /// 
        /// Difficulty: ⭐⭐
        /// Type: Variable Window (Longest)
        /// 
        /// Find length of longest substring without repeating characters.
        /// 
        /// Example:
        ///   Input: s = "abcabcbb"
        ///   Output: 3 (substring "abc")
        /// 
        /// THINK: This is similar to k=1 distinct, but slightly different!
        /// Instead of "at most k distinct", it's "all unique".
        /// 
        /// APPROACH:
        /// Use HashSet or Dictionary to track characters in window.
        /// Shrink when duplicate found.
        /// </summary>
        public static int LengthOfLongestSubstring(string s)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 2.3: Longest Subarray with Sum ≤ K
        /// 
        /// Difficulty: ⭐⭐
        /// Type: Variable Window (Longest)
        /// 
        /// Find length of longest subarray with sum ≤ k.
        /// 
        /// Example:
        ///   Input: arr = [1, 2, 3, 4, 5], k = 10
        ///   Output: 4 (subarray [1, 2, 3, 4])
        /// 
        /// DECISION LOGIC:
        /// When sum > k: shrink (too large)
        /// When sum ≤ k: valid, update result
        /// </summary>
        public static int LongestSubarrayWithSumAtMostK(int[] arr, int k)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 2.4: Longest Repeating Character Replacement
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Type: Variable Window (Longest)
        /// 
        /// You can replace at most k characters. Find longest substring
        /// with same character after replacements.
        /// 
        /// Example:
        ///   Input: s = "AABABBA", k = 1
        ///   Output: 4 (replace one B: "AAAA")
        /// 
        /// DEEP INSIGHT:
        /// For a window to be valid:
        /// windowLength - maxFrequency ≤ k
        /// 
        /// WHY?
        /// maxFrequency = most common character
        /// windowLength - maxFrequency = characters to replace
        /// If this ≤ k, we can make all characters the same!
        /// 
        /// Track: frequency of each character, maxFrequency seen
        /// </summary>
        public static int CharacterReplacement(string s, int k)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 2.5: Max Consecutive Ones III
        /// 
        /// Difficulty: ⭐⭐
        /// Type: Variable Window (Longest)
        /// 
        /// Array of 0s and 1s. Flip at most k zeros. Find longest
        /// sequence of 1s.
        /// 
        /// Example:
        ///   Input: arr = [1,1,1,0,0,0,1,1,1,1,0], k = 2
        ///   Output: 6 (flip two 0s: [1,1,1,0,0,1,1,1,1,1])
        /// 
        /// REFRAME THE PROBLEM:
        /// "Longest subarray with at most k zeros"
        /// 
        /// This is the SAME pattern as other "longest" problems!
        /// </summary>
        public static int LongestOnes(int[] arr, int k)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestLevel2_VariableLongest()
        {
            Console.WriteLine("=== LEVEL 2: VARIABLE WINDOW (LONGEST) ===\n");
            
            Console.WriteLine("Problem 2.1: Longest Substring K Distinct");
            Console.WriteLine("Input: s = \"eceba\", k = 2");
            Console.WriteLine("Expected: 3");
            Console.WriteLine();
            
            Console.WriteLine("Problem 2.2: Longest Substring Without Repeating");
            Console.WriteLine("Input: s = \"abcabcbb\"");
            Console.WriteLine("Expected: 3");
            Console.WriteLine();
            
            Console.WriteLine("Problem 2.3: Longest Subarray Sum ≤ K");
            int[] test3 = { 1, 2, 3, 4, 5 };
            Console.WriteLine($"Input: [{string.Join(", ", test3)}], k = 10");
            Console.WriteLine("Expected: 4");
            Console.WriteLine();
            
            Console.WriteLine("Problem 2.4: Character Replacement");
            Console.WriteLine("Input: s = \"AABABBA\", k = 1");
            Console.WriteLine("Expected: 4");
            Console.WriteLine();
            
            Console.WriteLine("Problem 2.5: Max Consecutive Ones III");
            int[] test5 = { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 };
            Console.WriteLine($"Input: [{string.Join(", ", test5)}], k = 2");
            Console.WriteLine("Expected: 6");
            Console.WriteLine();
        }

        #endregion

        #region LEVEL 3: VARIABLE WINDOW - SHORTEST

        /// <summary>
        /// PROBLEM 3.1: Minimum Size Subarray Sum
        /// 
        /// Difficulty: ⭐⭐
        /// Type: Variable Window (Shortest)
        /// 
        /// Find minimum length subarray with sum ≥ target.
        /// 
        /// Example:
        ///   Input: arr = [2, 3, 1, 2, 4, 3], target = 7
        ///   Output: 2 (subarray [4, 3])
        /// 
        /// KEY DIFFERENCE from "Longest":
        /// - Expand: until sum ≥ target
        /// - Shrink: WHILE sum ≥ target (find minimum)
        /// - Update: DURING shrinking
        /// 
        /// Compare to "Longest":
        /// - Expand: always
        /// - Shrink: while INVALID
        /// - Update: AFTER shrinking
        /// </summary>
        public static int MinSubArrayLen(int target, int[] arr)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 3.2: Minimum Window Substring
        /// 
        /// Difficulty: ⭐⭐⭐⭐ (HARD - but teaches deep understanding!)
        /// Type: Variable Window (Shortest)
        /// 
        /// Find minimum window in s containing all characters from t.
        /// 
        /// Example:
        ///   Input: s = "ADOBECODEBANC", t = "ABC"
        ///   Output: "BANC"
        /// 
        /// APPROACH:
        /// 1. Track required character frequencies from t
        /// 2. Expand: add characters to window
        /// 3. When window contains all characters:
        ///    - Update minimum
        ///    - Try to shrink
        /// 4. Continue expanding
        /// 
        /// STATE TO TRACK:
        /// - required: frequency of characters in t
        /// - windowFreq: frequency of characters in current window
        /// - formed: count of unique characters that meet requirement
        /// 
        /// This is COMPLEX - break it down step by step!
        /// </summary>
        public static string MinWindow(string s, string t)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 3.3: Smallest Subarray with Sum Greater Than K
        /// 
        /// Difficulty: ⭐⭐
        /// Type: Variable Window (Shortest)
        /// 
        /// Find length of smallest subarray with sum > k.
        /// 
        /// Example:
        ///   Input: arr = [1, 4, 45, 6, 0, 19], k = 51
        ///   Output: 3 (subarray [4, 45, 6])
        /// 
        /// Similar to Minimum Size Subarray Sum!
        /// </summary>
        public static int SmallestSubarrayWithSumGreaterThanK(int[] arr, int k)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestLevel3_VariableShortest()
        {
            Console.WriteLine("=== LEVEL 3: VARIABLE WINDOW (SHORTEST) ===\n");
            
            Console.WriteLine("Problem 3.1: Minimum Size Subarray Sum");
            int[] test1 = { 2, 3, 1, 2, 4, 3 };
            Console.WriteLine($"Input: [{string.Join(", ", test1)}], target = 7");
            Console.WriteLine("Expected: 2");
            Console.WriteLine();
            
            Console.WriteLine("Problem 3.2: Minimum Window Substring");
            Console.WriteLine("Input: s = \"ADOBECODEBANC\", t = \"ABC\"");
            Console.WriteLine("Expected: \"BANC\"");
            Console.WriteLine();
            
            Console.WriteLine("Problem 3.3: Smallest Subarray Sum > K");
            int[] test3 = { 1, 4, 45, 6, 0, 19 };
            Console.WriteLine($"Input: [{string.Join(", ", test3)}], k = 51");
            Console.WriteLine("Expected: 3");
            Console.WriteLine();
        }

        #endregion

        #region LEVEL 4: COUNTING SUBARRAYS

        /// <summary>
        /// PROBLEM 4.1: Count Subarrays with Product Less Than K
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Type: Variable Window (Count)
        /// 
        /// Count number of contiguous subarrays where product < k.
        /// 
        /// Example:
        ///   Input: arr = [10, 5, 2, 6], k = 100
        ///   Output: 8
        /// 
        /// KEY INSIGHT:
        /// For window [left, right], all subarrays ENDING at right are:
        /// [left..right], [left+1..right], ..., [right..right]
        /// Count = right - left + 1
        /// 
        /// PATTERN:
        /// - Expand: multiply by arr[right]
        /// - Shrink: while product ≥ k
        /// - Count: add (right - left + 1)
        /// 
        /// WHY THIS WORKS:
        /// We're counting all valid subarrays ending at each position!
        /// </summary>
        public static int NumSubarrayProductLessThanK(int[] arr, int k)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 4.2: Subarrays with K Different Integers
        /// 
        /// Difficulty: ⭐⭐⭐⭐ (HARD)
        /// Type: Variable Window (Count)
        /// 
        /// Count subarrays with EXACTLY k distinct integers.
        /// 
        /// Example:
        ///   Input: arr = [1, 2, 1, 2, 3], k = 2
        ///   Output: 7
        /// 
        /// BRILLIANT TRICK:
        /// exactly(k) = atMost(k) - atMost(k-1)
        /// 
        /// WHY?
        /// atMost(k) includes: 1 distinct, 2 distinct, ..., k distinct
        /// atMost(k-1) includes: 1 distinct, 2 distinct, ..., k-1 distinct
        /// Difference = EXACTLY k distinct!
        /// 
        /// First implement AtMostKDistinct helper function.
        /// </summary>
        public static int SubarraysWithKDistinct(int[] arr, int k)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 4.3: Count Number of Nice Subarrays
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Type: Variable Window (Count)
        /// 
        /// Count subarrays with exactly k odd numbers.
        /// 
        /// Example:
        ///   Input: arr = [1, 1, 2, 1, 1], k = 3
        ///   Output: 2 (subarrays: [1,1,2,1], [1,2,1,1])
        /// 
        /// HINT: Use the same trick as Problem 4.2!
        /// exactly(k) = atMost(k) - atMost(k-1)
        /// 
        /// Track count of odd numbers in window.
        /// </summary>
        public static int NumberOfSubarrays(int[] arr, int k)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestLevel4_Counting()
        {
            Console.WriteLine("=== LEVEL 4: COUNTING SUBARRAYS ===\n");
            
            Console.WriteLine("Problem 4.1: Count Product < K");
            int[] test1 = { 10, 5, 2, 6 };
            Console.WriteLine($"Input: [{string.Join(", ", test1)}], k = 100");
            Console.WriteLine("Expected: 8");
            Console.WriteLine();
            
            Console.WriteLine("Problem 4.2: Subarrays K Distinct");
            int[] test2 = { 1, 2, 1, 2, 3 };
            Console.WriteLine($"Input: [{string.Join(", ", test2)}], k = 2");
            Console.WriteLine("Expected: 7");
            Console.WriteLine();
            
            Console.WriteLine("Problem 4.3: Nice Subarrays");
            int[] test3 = { 1, 1, 2, 1, 1 };
            Console.WriteLine($"Input: [{string.Join(", ", test3)}], k = 3");
            Console.WriteLine("Expected: 2");
            Console.WriteLine();
        }

        #endregion

        #region LEVEL 5: ADVANCED CHALLENGES

        /// <summary>
        /// PROBLEM 5.1: Longest Subarray with Ones After K Flips
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Type: Variable Window (Longest)
        /// 
        /// Binary array. Flip at most k zeros to ones.
        /// Find longest contiguous subarray of ones.
        /// 
        /// Example:
        ///   Input: arr = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], k = 3
        ///   Output: 10
        /// 
        /// REFRAME: "Longest subarray with at most k zeros"
        /// 
        /// This tests if you recognize patterns!
        /// </summary>
        public static int LongestSubarray(int[] arr, int k)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 5.2: Permutation in String
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Type: Fixed Window
        /// 
        /// Check if s2 contains a permutation of s1.
        /// 
        /// Example:
        ///   Input: s1 = "ab", s2 = "eidbaooo"
        ///   Output: true (s2 contains "ba")
        /// 
        /// APPROACH:
        /// Fixed window of size s1.Length.
        /// Track character frequencies.
        /// Check if any window matches s1's frequency.
        /// </summary>
        public static bool CheckInclusion(string s1, string s2)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 5.3: Fruit Into Baskets
        /// 
        /// Difficulty: ⭐⭐
        /// Type: Variable Window (Longest)
        /// 
        /// You have two baskets. Each basket can hold one type of fruit.
        /// Find maximum number of fruits you can collect.
        /// (You can only collect contiguous fruits)
        /// 
        /// Example:
        ///   Input: fruits = [1, 2, 1, 2, 3, 2, 2]
        ///   Output: 5 (fruits [2, 1, 2, 3, 2] → NO! Must be contiguous)
        ///          Actually: [1, 2, 1, 2] or [2, 3, 2, 2] → both have 2 types
        ///          Wait, let me recalculate...
        ///          [2, 3, 2, 2] = length 4, 2 types ✓
        ///          But [1, 2, 1, 2, 3] has 3 types...
        ///          Correct answer: [3, 2, 2] or [2, 3, 2, 2] or [1, 2, 1, 2]
        ///          Actually: [1, 2, 1, 2] = 4, then [2, 3, 2, 2] = 4
        ///          
        ///   Let me be precise: longest subarray with ≤ 2 distinct elements
        ///   [1,2,1,2] = 4 elements, 2 types
        ///   [2,3,2,2] = 4 elements, 2 types
        ///   But wait: [2,1,2,3,2,2] starting from index 1 = 5? No, has 3 types.
        ///   
        ///   Correct: "Longest subarray with at most 2 distinct integers"
        /// 
        /// RECOGNIZE THE PATTERN?
        /// This is literally "Longest Substring K Distinct" with k=2!
        /// </summary>
        public static int TotalFruit(int[] fruits)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 5.4: Longest Subarray of 1s After Deleting One Element
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Type: Variable Window (Longest)
        /// 
        /// Binary array. Delete exactly ONE element.
        /// Find longest contiguous subarray of 1s.
        /// 
        /// Example:
        ///   Input: arr = [1, 1, 0, 1, 1, 1, 0, 1, 1]
        ///   Output: 7 (delete either 0, get [1,1,1,1,1,1,1])
        ///          Wait, that's not contiguous...
        ///          Actually: delete arr[2]=0 → [1,1,1,1,1] = 5
        ///                    delete arr[6]=0 → [1,1,0,1,1,1,1,1] still has 0
        ///          
        ///   Let me reconsider: after deleting ONE element,
        ///   find longest sequence of 1s.
        ///   
        ///   If we delete index 2 (the 0): [1,1,_,1,1,1,0,1,1]
        ///   Longest sequence: [1,1,1,1,1] = 5
        ///   
        ///   If we delete index 6 (the 0): [1,1,0,1,1,1,_,1,1]
        ///   Longest sequence: [1,1,1,1] = 4
        /// 
        /// REFRAME: "Longest subarray with at most 1 zero"
        /// But we MUST delete one element!
        /// 
        /// APPROACH:
        /// Find longest window with ≤ 1 zero.
        /// Result = windowLength - 1 (we delete that zero or a 1)
        /// 
        /// Edge case: All 1s? Must delete one, so result = length - 1.
        /// </summary>
        public static int LongestSubarray(int[] arr)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestLevel5_Advanced()
        {
            Console.WriteLine("=== LEVEL 5: ADVANCED CHALLENGES ===\n");
            
            Console.WriteLine("Problem 5.1: Longest Subarray Ones After K Flips");
            int[] test1 = { 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1 };
            Console.WriteLine($"Input: k = 3");
            Console.WriteLine("Expected: 10");
            Console.WriteLine();
            
            Console.WriteLine("Problem 5.2: Permutation in String");
            Console.WriteLine("Input: s1 = \"ab\", s2 = \"eidbaooo\"");
            Console.WriteLine("Expected: true");
            Console.WriteLine();
            
            Console.WriteLine("Problem 5.3: Fruit Into Baskets");
            int[] test3 = { 1, 2, 1, 2, 3, 2, 2 };
            Console.WriteLine($"Input: [{string.Join(", ", test3)}]");
            Console.WriteLine("Expected: 5");
            Console.WriteLine();
            
            Console.WriteLine("Problem 5.4: Longest Subarray After Deleting One");
            int[] test4 = { 1, 1, 0, 1, 1, 1, 0, 1, 1 };
            Console.WriteLine($"Input: [{string.Join(", ", test4)}]");
            Console.WriteLine("Expected: 7");
            Console.WriteLine();
        }

        #endregion
    }
}
