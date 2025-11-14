using System;
using System.Linq;

namespace ArrayMastery
{
    /// <summary>
    /// Arrays: Hands-On Coding Exercises
    /// 
    /// "I don't want yes-men around me. I want everyone to tell me the truth 
    /// even if it costs them their jobs." - Sam Goldwyn
    /// 
    /// Translation: Your code either works or it doesn't. Let's find out.
    /// 
    /// INSTRUCTIONS:
    /// 1. Read the problem
    /// 2. Think about time/space complexity
    /// 3. Implement your solution
    /// 4. Test with provided test cases
    /// 5. Compare with the solution
    /// 
    /// DO NOT SKIP TO SOLUTIONS! Struggle is how you learn.
    /// </summary>
    class ArrayExercises
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ARRAY MASTERY: CODING EXERCISES ===\n");

            // Uncomment each section as you solve it
            // TestLevel1_Basics();
            // TestLevel2_TwoPointers();
            // TestLevel3_SlidingWindow();
            // TestLevel4_PrefixSum();
            // TestLevel5_Matrix();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        #region LEVEL 1: BASICS - Understanding Arrays

        /// <summary>
        /// PROBLEM 1.1: Find Maximum Element
        /// 
        /// Difficulty: ⭐ (Warm-up)
        /// Time: O(n) | Space: O(1)
        /// 
        /// Given an array of integers, return the maximum element.
        /// 
        /// Example:
        ///   Input: [3, 1, 4, 1, 5, 9, 2, 6]
        ///   Output: 9
        /// 
        /// Your Task: Implement without using built-in Max() function first!
        /// </summary>
        public static int FindMaximum(int[] arr)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 1.2: Reverse Array In-Place
        /// 
        /// Difficulty: ⭐ (Warm-up)
        /// Time: O(n) | Space: O(1)
        /// 
        /// Reverse an array without using extra space for another array.
        /// 
        /// Example:
        ///   Input: [1, 2, 3, 4, 5]
        ///   Output: [5, 4, 3, 2, 1]
        /// 
        /// Hint: Two pointers - one at start, one at end
        /// </summary>
        public static void ReverseArray(int[] arr)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 1.3: Find Second Largest Element
        /// 
        /// Difficulty: ⭐⭐
        /// Time: O(n) | Space: O(1)
        /// 
        /// Find the second largest element in the array.
        /// Assume array has at least 2 distinct elements.
        /// 
        /// Example:
        ///   Input: [12, 35, 1, 10, 34, 1]
        ///   Output: 34
        /// 
        /// Challenge: Do it in ONE pass!
        /// Hint: Keep track of largest and second largest simultaneously
        /// </summary>
        public static int FindSecondLargest(int[] arr)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 1.4: Remove Duplicates from Sorted Array
        /// 
        /// Difficulty: ⭐⭐
        /// Time: O(n) | Space: O(1)
        /// 
        /// Given a SORTED array, remove duplicates in-place.
        /// Return the new length.
        /// 
        /// Example:
        ///   Input: [1, 1, 2, 2, 2, 3, 4, 4, 5]
        ///   Output: 5, arr = [1, 2, 3, 4, 5, ...]
        /// 
        /// Note: Elements after the new length don't matter.
        /// Hint: Two pointers - one for reading, one for writing
        /// </summary>
        public static int RemoveDuplicates(int[] arr)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestLevel1_Basics()
        {
            Console.WriteLine("=== LEVEL 1: BASICS ===\n");

            // Test 1.1: Find Maximum
            Console.WriteLine("Test 1.1: Find Maximum");
            int[] test1 = { 3, 1, 4, 1, 5, 9, 2, 6 };
            Console.WriteLine($"Input: [{string.Join(", ", test1)}]");
            Console.WriteLine($"Expected: 9");
            // Console.WriteLine($"Your Answer: {FindMaximum(test1)}");
            Console.WriteLine();

            // Test 1.2: Reverse Array
            Console.WriteLine("Test 1.2: Reverse Array");
            int[] test2 = { 1, 2, 3, 4, 5 };
            Console.WriteLine($"Input: [{string.Join(", ", test2)}]");
            Console.WriteLine($"Expected: [5, 4, 3, 2, 1]");
            // ReverseArray(test2);
            // Console.WriteLine($"Your Answer: [{string.Join(", ", test2)}]");
            Console.WriteLine();

            // Test 1.3: Second Largest
            Console.WriteLine("Test 1.3: Find Second Largest");
            int[] test3 = { 12, 35, 1, 10, 34, 1 };
            Console.WriteLine($"Input: [{string.Join(", ", test3)}]");
            Console.WriteLine($"Expected: 34");
            // Console.WriteLine($"Your Answer: {FindSecondLargest(test3)}");
            Console.WriteLine();

            // Test 1.4: Remove Duplicates
            Console.WriteLine("Test 1.4: Remove Duplicates");
            int[] test4 = { 1, 1, 2, 2, 2, 3, 4, 4, 5 };
            Console.WriteLine($"Input: [{string.Join(", ", test4)}]");
            Console.WriteLine($"Expected Length: 5");
            // int newLen = RemoveDuplicates(test4);
            // Console.WriteLine($"Your Answer: {newLen}, arr = [{string.Join(", ", test4.Take(newLen))}]");
            Console.WriteLine();
        }

        #endregion

        #region LEVEL 2: TWO POINTERS - The Swiss Army Knife

        /// <summary>
        /// PROBLEM 2.1: Two Sum (Array is SORTED)
        /// 
        /// Difficulty: ⭐⭐
        /// Time: O(n) | Space: O(1)
        /// 
        /// Find two numbers that add up to a target.
        /// Return their indices (1-indexed).
        /// 
        /// Example:
        ///   Input: arr = [2, 7, 11, 15], target = 9
        ///   Output: [1, 2] (because arr[0] + arr[1] = 2 + 7 = 9)
        /// 
        /// Hint: Two pointers from both ends!
        /// Why does this work? If sum too small, move left pointer right.
        /// If sum too large, move right pointer left.
        /// </summary>
        public static int[] TwoSumSorted(int[] arr, int target)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 2.2: Move Zeros to End
        /// 
        /// Difficulty: ⭐⭐
        /// Time: O(n) | Space: O(1)
        /// 
        /// Move all zeros to the end while maintaining relative order of non-zeros.
        /// 
        /// Example:
        ///   Input: [0, 1, 0, 3, 12]
        ///   Output: [1, 3, 12, 0, 0]
        /// 
        /// Hint: One pointer for next non-zero position, one for scanning
        /// </summary>
        public static void MoveZeros(int[] arr)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 2.3: Container With Most Water
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Time: O(n) | Space: O(1)
        /// 
        /// Given n non-negative integers representing heights,
        /// find two lines that together with x-axis forms a container
        /// that contains the most water.
        /// 
        /// Example:
        ///   Input: [1, 8, 6, 2, 5, 4, 8, 3, 7]
        ///   Output: 49
        /// 
        /// Explanation: Max area between indices 1 and 8 = min(8,7) * 7 = 49
        /// 
        /// Hint: Start with widest container, then move pointer of shorter line
        /// </summary>
        public static int MaxArea(int[] heights)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 2.4: 3Sum (Find three numbers that sum to zero)
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Time: O(n²) | Space: O(1) excluding output
        /// 
        /// Find all unique triplets [a, b, c] where a + b + c = 0.
        /// 
        /// Example:
        ///   Input: [-1, 0, 1, 2, -1, -4]
        ///   Output: [[-1, -1, 2], [-1, 0, 1]]
        /// 
        /// Hint: Sort first, then for each element, use two-pointer for remaining two
        /// This is a CLASSIC interview question!
        /// </summary>
        public static int[][] ThreeSum(int[] arr)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestLevel2_TwoPointers()
        {
            Console.WriteLine("=== LEVEL 2: TWO POINTERS ===\n");

            // Test 2.1
            Console.WriteLine("Test 2.1: Two Sum (Sorted)");
            int[] test1 = { 2, 7, 11, 15 };
            Console.WriteLine($"Input: [{string.Join(", ", test1)}], target = 9");
            Console.WriteLine($"Expected: [1, 2]");
            // var result1 = TwoSumSorted(test1, 9);
            // Console.WriteLine($"Your Answer: [{string.Join(", ", result1)}]");
            Console.WriteLine();

            // Test 2.2
            Console.WriteLine("Test 2.2: Move Zeros");
            int[] test2 = { 0, 1, 0, 3, 12 };
            Console.WriteLine($"Input: [{string.Join(", ", test2)}]");
            Console.WriteLine($"Expected: [1, 3, 12, 0, 0]");
            // MoveZeros(test2);
            // Console.WriteLine($"Your Answer: [{string.Join(", ", test2)}]");
            Console.WriteLine();

            // Test 2.3
            Console.WriteLine("Test 2.3: Container With Most Water");
            int[] test3 = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            Console.WriteLine($"Input: [{string.Join(", ", test3)}]");
            Console.WriteLine($"Expected: 49");
            // Console.WriteLine($"Your Answer: {MaxArea(test3)}");
            Console.WriteLine();

            // Test 2.4
            Console.WriteLine("Test 2.4: Three Sum");
            int[] test4 = { -1, 0, 1, 2, -1, -4 };
            Console.WriteLine($"Input: [{string.Join(", ", test4)}]");
            Console.WriteLine($"Expected: [[-1, -1, 2], [-1, 0, 1]]");
            // var result4 = ThreeSum(test4);
            // Console.WriteLine($"Your Answer:");
            // foreach(var triplet in result4)
            //     Console.WriteLine($"  [{string.Join(", ", triplet)}]");
            Console.WriteLine();
        }

        #endregion

        #region LEVEL 3: SLIDING WINDOW - For Subarrays

        /// <summary>
        /// PROBLEM 3.1: Maximum Sum Subarray of Size K
        /// 
        /// Difficulty: ⭐⭐
        /// Time: O(n) | Space: O(1)
        /// 
        /// Find the maximum sum of a contiguous subarray of size k.
        /// 
        /// Example:
        ///   Input: arr = [2, 1, 5, 1, 3, 2], k = 3
        ///   Output: 9 (subarray [5, 1, 3])
        /// 
        /// Hint: Instead of recalculating sum for each window,
        /// subtract the leftmost element and add the new element!
        /// </summary>
        public static int MaxSumSubarray(int[] arr, int k)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 3.2: Longest Substring Without Repeating Characters
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Time: O(n) | Space: O(min(n, m)) where m is charset size
        /// 
        /// Find the length of the longest substring without repeating characters.
        /// 
        /// Example:
        ///   Input: "abcabcbb"
        ///   Output: 3 (substring "abc")
        /// 
        /// Hint: Use a HashSet to track characters in current window.
        /// Expand window by adding characters, contract when duplicate found.
        /// </summary>
        public static int LengthOfLongestSubstring(string s)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 3.3: Minimum Window Substring
        /// 
        /// Difficulty: ⭐⭐⭐⭐ (HARD - Google, Facebook favorite!)
        /// Time: O(n + m) | Space: O(m)
        /// 
        /// Find the minimum window in string s that contains all characters of string t.
        /// 
        /// Example:
        ///   Input: s = "ADOBECODEBANC", t = "ABC"
        ///   Output: "BANC"
        /// 
        /// Hint: Two pointers + HashMap
        /// 1. Expand right until all chars of t are in window
        /// 2. Contract left while all chars still present
        /// 3. Track minimum window
        /// 
        /// This is HARD. Don't feel bad if it takes time!
        /// </summary>
        public static string MinWindow(string s, string t)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 3.4: Maximum of All Subarrays of Size K
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Time: O(n) | Space: O(k)
        /// 
        /// Find maximum element in all contiguous subarrays of size k.
        /// 
        /// Example:
        ///   Input: arr = [1, 3, -1, -3, 5, 3, 6, 7], k = 3
        ///   Output: [3, 3, 5, 5, 6, 7]
        /// 
        /// Hint: Use a Deque (double-ended queue) to store indices
        /// Maintain decreasing order of values in deque
        /// </summary>
        public static int[] MaxSlidingWindow(int[] arr, int k)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestLevel3_SlidingWindow()
        {
            Console.WriteLine("=== LEVEL 3: SLIDING WINDOW ===\n");

            // Test 3.1
            Console.WriteLine("Test 3.1: Max Sum Subarray Size K");
            int[] test1 = { 2, 1, 5, 1, 3, 2 };
            Console.WriteLine($"Input: [{string.Join(", ", test1)}], k = 3");
            Console.WriteLine($"Expected: 9");
            // Console.WriteLine($"Your Answer: {MaxSumSubarray(test1, 3)}");
            Console.WriteLine();

            // Test 3.2
            Console.WriteLine("Test 3.2: Longest Substring Without Repeating");
            string test2 = "abcabcbb";
            Console.WriteLine($"Input: \"{test2}\"");
            Console.WriteLine($"Expected: 3");
            // Console.WriteLine($"Your Answer: {LengthOfLongestSubstring(test2)}");
            Console.WriteLine();

            // Test 3.3
            Console.WriteLine("Test 3.3: Minimum Window Substring");
            string s = "ADOBECODEBANC", t = "ABC";
            Console.WriteLine($"Input: s = \"{s}\", t = \"{t}\"");
            Console.WriteLine($"Expected: \"BANC\"");
            // Console.WriteLine($"Your Answer: \"{MinWindow(s, t)}\"");
            Console.WriteLine();

            // Test 3.4
            Console.WriteLine("Test 3.4: Max Sliding Window");
            int[] test4 = { 1, 3, -1, -3, 5, 3, 6, 7 };
            Console.WriteLine($"Input: [{string.Join(", ", test4)}], k = 3");
            Console.WriteLine($"Expected: [3, 3, 5, 5, 6, 7]");
            // var result4 = MaxSlidingWindow(test4, 3);
            // Console.WriteLine($"Your Answer: [{string.Join(", ", result4)}]");
            Console.WriteLine();
        }

        #endregion

        #region LEVEL 4: PREFIX SUM - Cumulative Intelligence

        /// <summary>
        /// PROBLEM 4.1: Range Sum Query
        /// 
        /// Difficulty: ⭐⭐
        /// Time: O(1) per query after O(n) preprocessing | Space: O(n)
        /// 
        /// Given an array, answer multiple queries asking for sum[i..j].
        /// 
        /// Example:
        ///   Input: arr = [1, 2, 3, 4, 5]
        ///   Query(0, 2) → 6 (1+2+3)
        ///   Query(1, 4) → 14 (2+3+4+5)
        /// 
        /// Hint: Build prefix sum array where prefix[i] = sum(arr[0..i])
        /// Then sum(i, j) = prefix[j] - prefix[i-1]
        /// </summary>
        public class RangeSumQuery
        {
            private int[] prefix;

            public RangeSumQuery(int[] arr)
            {
                // YOUR CODE HERE
                throw new NotImplementedException();
            }

            public int SumRange(int i, int j)
            {
                // YOUR CODE HERE
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// PROBLEM 4.2: Subarray Sum Equals K
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Time: O(n) | Space: O(n)
        /// 
        /// Count number of continuous subarrays whose sum equals k.
        /// 
        /// Example:
        ///   Input: arr = [1, 1, 1], k = 2
        ///   Output: 2 (subarrays [1,1] at positions [0,1] and [1,2])
        /// 
        /// Hint: Use prefix sum + HashMap
        /// For each position, check if (currentSum - k) exists in map
        /// Why? If prefix[j] - prefix[i] = k, then subarray[i+1..j] sums to k
        /// </summary>
        public static int SubarraySum(int[] arr, int k)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 4.3: Product of Array Except Self
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Time: O(n) | Space: O(1) excluding output array
        /// 
        /// Return array where output[i] = product of all elements except arr[i].
        /// DO NOT use division!
        /// 
        /// Example:
        ///   Input: [1, 2, 3, 4]
        ///   Output: [24, 12, 8, 6]
        ///   
        /// Explanation:
        ///   output[0] = 2*3*4 = 24
        ///   output[1] = 1*3*4 = 12
        ///   output[2] = 1*2*4 = 8
        ///   output[3] = 1*2*3 = 6
        /// 
        /// Hint: Two passes - left products, then right products
        /// </summary>
        public static int[] ProductExceptSelf(int[] arr)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestLevel4_PrefixSum()
        {
            Console.WriteLine("=== LEVEL 4: PREFIX SUM ===\n");

            // Test 4.1
            Console.WriteLine("Test 4.1: Range Sum Query");
            int[] test1 = { 1, 2, 3, 4, 5 };
            Console.WriteLine($"Input: [{string.Join(", ", test1)}]");
            // var rsq = new RangeSumQuery(test1);
            // Console.WriteLine($"Query(0, 2): Expected 6, Got {rsq.SumRange(0, 2)}");
            // Console.WriteLine($"Query(1, 4): Expected 14, Got {rsq.SumRange(1, 4)}");
            Console.WriteLine();

            // Test 4.2
            Console.WriteLine("Test 4.2: Subarray Sum Equals K");
            int[] test2 = { 1, 1, 1 };
            Console.WriteLine($"Input: [{string.Join(", ", test2)}], k = 2");
            Console.WriteLine($"Expected: 2");
            // Console.WriteLine($"Your Answer: {SubarraySum(test2, 2)}");
            Console.WriteLine();

            // Test 4.3
            Console.WriteLine("Test 4.3: Product Except Self");
            int[] test3 = { 1, 2, 3, 4 };
            Console.WriteLine($"Input: [{string.Join(", ", test3)}]");
            Console.WriteLine($"Expected: [24, 12, 8, 6]");
            // var result3 = ProductExceptSelf(test3);
            // Console.WriteLine($"Your Answer: [{string.Join(", ", result3)}]");
            Console.WriteLine();
        }

        #endregion

        #region LEVEL 5: MATRIX (2D ARRAYS) - Next Dimension

        /// <summary>
        /// PROBLEM 5.1: Spiral Matrix Traversal
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Time: O(m*n) | Space: O(1) excluding output
        /// 
        /// Return all elements of matrix in spiral order.
        /// 
        /// Example:
        ///   Input: [[1,  2,  3,  4],
        ///           [5,  6,  7,  8],
        ///           [9, 10, 11, 12]]
        ///   Output: [1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7]
        /// 
        /// Hint: Four boundaries - top, bottom, left, right
        /// Move right → down → left → up, shrinking boundaries each time
        /// </summary>
        public static int[] SpiralOrder(int[,] matrix)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 5.2: Rotate Matrix 90° Clockwise
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Time: O(n²) | Space: O(1)
        /// 
        /// Rotate n×n matrix 90 degrees clockwise IN-PLACE.
        /// 
        /// Example:
        ///   Input: [[1, 2, 3],     Output: [[7, 4, 1],
        ///           [4, 5, 6],              [8, 5, 2],
        ///           [7, 8, 9]]              [9, 6, 3]]
        /// 
        /// Hint: Two steps:
        /// 1. Transpose (swap matrix[i][j] with matrix[j][i])
        /// 2. Reverse each row
        /// </summary>
        public static void RotateMatrix(int[,] matrix)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 5.3: Set Matrix Zeroes
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Time: O(m*n) | Space: O(1)
        /// 
        /// If an element is 0, set its entire row and column to 0.
        /// Do it IN-PLACE.
        /// 
        /// Example:
        ///   Input: [[1, 1, 1],     Output: [[1, 0, 1],
        ///           [1, 0, 1],              [0, 0, 0],
        ///           [1, 1, 1]]              [1, 0, 1]]
        /// 
        /// Hint: Use first row and first column as markers!
        /// </summary>
        public static void SetZeroes(int[,] matrix)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        /// <summary>
        /// PROBLEM 5.4: Search in Row-wise and Column-wise Sorted Matrix
        /// 
        /// Difficulty: ⭐⭐⭐
        /// Time: O(m + n) | Space: O(1)
        /// 
        /// Each row is sorted left to right.
        /// Each column is sorted top to bottom.
        /// 
        /// Example:
        ///   Matrix: [[1,  4,  7, 11],
        ///            [2,  5,  8, 12],
        ///            [3,  6,  9, 16],
        ///            [10, 13, 14, 17]]
        ///   Search 5: true
        ///   Search 20: false
        /// 
        /// Hint: Start from top-right corner!
        /// If target < current, move left
        /// If target > current, move down
        /// Why does this work? Think about it!
        /// </summary>
        public static bool SearchMatrix(int[,] matrix, int target)
        {
            // YOUR CODE HERE
            throw new NotImplementedException();
        }

        static void TestLevel5_Matrix()
        {
            Console.WriteLine("=== LEVEL 5: MATRIX (2D ARRAYS) ===\n");

            // Test 5.1
            Console.WriteLine("Test 5.1: Spiral Matrix");
            int[,] test1 = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
            Console.WriteLine($"Expected: [1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7]");
            // var result1 = SpiralOrder(test1);
            // Console.WriteLine($"Your Answer: [{string.Join(", ", result1)}]");
            Console.WriteLine();

            // Test 5.2
            Console.WriteLine("Test 5.2: Rotate Matrix 90°");
            int[,] test2 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Console.WriteLine("Input:\n[[1, 2, 3],\n [4, 5, 6],\n [7, 8, 9]]");
            Console.WriteLine("Expected:\n[[7, 4, 1],\n [8, 5, 2],\n [9, 6, 3]]");
            // RotateMatrix(test2);
            // Console.WriteLine("Your Answer:");
            // PrintMatrix(test2);
            Console.WriteLine();

            // Test 5.3
            Console.WriteLine("Test 5.3: Set Matrix Zeroes");
            int[,] test3 = { { 1, 1, 1 }, { 1, 0, 1 }, { 1, 1, 1 } };
            Console.WriteLine("Input:\n[[1, 1, 1],\n [1, 0, 1],\n [1, 1, 1]]");
            Console.WriteLine("Expected:\n[[1, 0, 1],\n [0, 0, 0],\n [1, 0, 1]]");
            // SetZeroes(test3);
            // Console.WriteLine("Your Answer:");
            // PrintMatrix(test3);
            Console.WriteLine();

            // Test 5.4
            Console.WriteLine("Test 5.4: Search in Sorted Matrix");
            int[,] test4 = { { 1, 4, 7, 11 }, { 2, 5, 8, 12 }, { 3, 6, 9, 16 }, { 10, 13, 14, 17 } };
            Console.WriteLine("Matrix: Row-wise and column-wise sorted");
            Console.WriteLine($"Search 5: Expected true");
            // Console.WriteLine($"Search 5: Got {SearchMatrix(test4, 5)}");
            Console.WriteLine($"Search 20: Expected false");
            // Console.WriteLine($"Search 20: Got {SearchMatrix(test4, 20)}");
            Console.WriteLine();
        }

        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                Console.Write("[");
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                    if (j < cols - 1) Console.Write(", ");
                }
                Console.WriteLine("]");
            }
        }

        #endregion
    }
}
