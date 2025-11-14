# Arrays & ArrayList: Complete Solutions Guide

> "Don't look at solutions until you've genuinely tried! Struggle is how you learn."

This document contains complete solutions with explanations for all coding exercises.

**Usage Guidelines:**
1. ⚠️ **ATTEMPT THE PROBLEM FIRST!** Spend at least 30 minutes trying
2. If stuck, re-read the problem and hints
3. Still stuck? Look at the approach explanation (not code yet!)
4. Last resort: Look at the solution code
5. After seeing solution, implement it yourself WITHOUT looking!

---

## Module 2 Solutions: Basic Coding Exercises

### LEVEL 1: BASICS

#### Problem 1.1: Find Maximum Element

```csharp
public static int FindMaximum(int[] arr)
{
    if (arr == null || arr.Length == 0)
        throw new ArgumentException("Array cannot be null or empty");
    
    int max = arr[0];  // Assume first element is max
    
    for (int i = 1; i < arr.Length; i++)
    {
        if (arr[i] > max)
            max = arr[i];
    }
    
    return max;
}
```

**Complexity:** O(n) time, O(1) space

**Key Insights:**
- Must check every element (can't do better than O(n))
- Track maximum seen so far
- Handle edge case: empty array

---

#### Problem 1.2: Reverse Array In-Place

```csharp
public static void ReverseArray(int[] arr)
{
    int left = 0;
    int right = arr.Length - 1;
    
    while (left < right)
    {
        // Swap elements
        int temp = arr[left];
        arr[left] = arr[right];
        arr[right] = temp;
        
        left++;
        right--;
    }
}
```

**Complexity:** O(n) time, O(1) space

**Key Insights:**
- Two pointers from opposite ends
- Swap and move toward center
- Stop when pointers meet/cross
- Only n/2 swaps needed!

---

#### Problem 1.3: Find Second Largest Element

```csharp
public static int FindSecondLargest(int[] arr)
{
    if (arr == null || arr.Length < 2)
        throw new ArgumentException("Array must have at least 2 elements");
    
    int largest = int.MinValue;
    int secondLargest = int.MinValue;
    
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] > largest)
        {
            secondLargest = largest;  // Previous largest becomes second
            largest = arr[i];          // New largest
        }
        else if (arr[i] > secondLargest && arr[i] != largest)
        {
            secondLargest = arr[i];    // Better second largest
        }
    }
    
    if (secondLargest == int.MinValue)
        throw new ArgumentException("No second largest (all elements same?)");
    
    return secondLargest;
}
```

**Complexity:** O(n) time, O(1) space

**Key Insights:**
- ONE pass through array
- Track both largest and second largest simultaneously
- When new largest found, old largest becomes second
- Watch for duplicates of largest value

---

#### Problem 1.4: Remove Duplicates from Sorted Array

```csharp
public static int RemoveDuplicates(int[] arr)
{
    if (arr == null || arr.Length == 0)
        return 0;
    
    int writeIndex = 1;  // Where to write next unique element
    
    for (int readIndex = 1; readIndex < arr.Length; readIndex++)
    {
        // If different from previous element, it's unique
        if (arr[readIndex] != arr[readIndex - 1])
        {
            arr[writeIndex] = arr[readIndex];
            writeIndex++;
        }
    }
    
    return writeIndex;  // New length
}
```

**Complexity:** O(n) time, O(1) space

**Key Insights:**
- Two pointers: one for reading, one for writing
- Skip duplicates during reading
- Only write when element is different
- Works because array is SORTED!

---

### LEVEL 2: TWO POINTERS

#### Problem 2.1: Two Sum (Sorted Array)

```csharp
public static int[] TwoSumSorted(int[] arr, int target)
{
    int left = 0;
    int right = arr.Length - 1;
    
    while (left < right)
    {
        int sum = arr[left] + arr[right];
        
        if (sum == target)
        {
            return new int[] { left + 1, right + 1 };  // 1-indexed
        }
        else if (sum < target)
        {
            left++;   // Need larger sum
        }
        else
        {
            right--;  // Need smaller sum
        }
    }
    
    return new int[] { -1, -1 };  // No solution
}
```

**Complexity:** O(n) time, O(1) space

**Key Insights:**
- Works because array is SORTED
- If sum too small, move left pointer right (increases sum)
- If sum too large, move right pointer left (decreases sum)
- No need for HashMap when sorted!

---

#### Problem 2.2: Move Zeros to End

```csharp
public static void MoveZeros(int[] arr)
{
    int writeIndex = 0;  // Position for next non-zero
    
    // Move all non-zeros to the front
    for (int readIndex = 0; readIndex < arr.Length; readIndex++)
    {
        if (arr[readIndex] != 0)
        {
            arr[writeIndex] = arr[readIndex];
            writeIndex++;
        }
    }
    
    // Fill remaining positions with zeros
    while (writeIndex < arr.Length)
    {
        arr[writeIndex] = 0;
        writeIndex++;
    }
}
```

**Alternative (with swapping):**
```csharp
public static void MoveZeros(int[] arr)
{
    int writeIndex = 0;
    
    for (int readIndex = 0; readIndex < arr.Length; readIndex++)
    {
        if (arr[readIndex] != 0)
        {
            // Swap non-zero with position at writeIndex
            int temp = arr[writeIndex];
            arr[writeIndex] = arr[readIndex];
            arr[readIndex] = temp;
            writeIndex++;
        }
    }
}
```

**Complexity:** O(n) time, O(1) space

**Key Insights:**
- Similar to remove duplicates pattern
- Collect non-zeros at front
- Fill rest with zeros
- Maintains relative order of non-zeros

---

#### Problem 2.3: Container With Most Water

```csharp
public static int MaxArea(int[] heights)
{
    int left = 0;
    int right = heights.Length - 1;
    int maxArea = 0;
    
    while (left < right)
    {
        // Area = width × min(height1, height2)
        int width = right - left;
        int height = Math.Min(heights[left], heights[right]);
        int area = width * height;
        
        maxArea = Math.Max(maxArea, area);
        
        // Move pointer of shorter line (bottleneck)
        if (heights[left] < heights[right])
            left++;
        else
            right--;
    }
    
    return maxArea;
}
```

**Complexity:** O(n) time, O(1) space

**Key Insights:**
- Start with widest container (maximum width)
- Area limited by shorter line (bottleneck)
- Moving shorter line might find taller line → more area
- Moving taller line never helps (width decreases, height can only decrease or stay same)

**Why This Works:**
Say left = 1, right = 8, heights[1] = 3, heights[8] = 7.
- Current area = 7 × 3 = 21
- If we move right to 7: width = 6, height ≤ 3 (still limited by left!)
  - Can't improve!
- Must move left to potentially find height > 3

---

#### Problem 2.4: Three Sum

```csharp
public static int[][] ThreeSum(int[] arr)
{
    Array.Sort(arr);  // MUST sort first!
    List<int[]> result = new List<int[]>();
    
    for (int i = 0; i < arr.Length - 2; i++)
    {
        // Skip duplicates for first element
        if (i > 0 && arr[i] == arr[i - 1])
            continue;
        
        // Two-pointer for remaining two elements
        int left = i + 1;
        int right = arr.Length - 1;
        int target = -arr[i];  // Want arr[i] + arr[left] + arr[right] = 0
        
        while (left < right)
        {
            int sum = arr[left] + arr[right];
            
            if (sum == target)
            {
                result.Add(new int[] { arr[i], arr[left], arr[right] });
                
                // Skip duplicates for second element
                while (left < right && arr[left] == arr[left + 1])
                    left++;
                
                // Skip duplicates for third element
                while (left < right && arr[right] == arr[right - 1])
                    right--;
                
                left++;
                right--;
            }
            else if (sum < target)
            {
                left++;
            }
            else
            {
                right--;
            }
        }
    }
    
    return result.ToArray();
}
```

**Complexity:** O(n²) time, O(1) space (excluding output)

**Key Insights:**
- Fix first element (i), find two elements that sum to -arr[i]
- This reduces to Two Sum problem!
- MUST sort first for two-pointer to work
- MUST skip duplicates to avoid duplicate triplets
- Skip duplicates at all three positions

---

### LEVEL 3: SLIDING WINDOW

#### Problem 3.1: Maximum Sum Subarray of Size K

```csharp
public static int MaxSumSubarray(int[] arr, int k)
{
    if (arr.Length < k)
        throw new ArgumentException("Array smaller than k");
    
    // Calculate sum of first window
    int windowSum = 0;
    for (int i = 0; i < k; i++)
    {
        windowSum += arr[i];
    }
    
    int maxSum = windowSum;
    
    // Slide the window
    for (int i = k; i < arr.Length; i++)
    {
        windowSum += arr[i];        // Add new element
        windowSum -= arr[i - k];    // Remove old element
        maxSum = Math.Max(maxSum, windowSum);
    }
    
    return maxSum;
}
```

**Complexity:** O(n) time, O(1) space

**Key Insights:**
- Instead of recalculating sum for each window (O(nk))
- Subtract element leaving window, add element entering window (O(n))
- This is the essence of sliding window!

**Without sliding window (slow):**
```csharp
// O(n × k) - recalculate each time
for (int i = 0; i <= arr.Length - k; i++)
{
    int sum = 0;
    for (int j = i; j < i + k; j++)
        sum += arr[j];
    maxSum = Math.Max(maxSum, sum);
}
```

---

#### Problem 3.2: Longest Substring Without Repeating Characters

```csharp
public static int LengthOfLongestSubstring(string s)
{
    HashSet<char> window = new HashSet<char>();
    int maxLength = 0;
    int left = 0;
    
    for (int right = 0; right < s.Length; right++)
    {
        // Shrink window until no duplicate
        while (window.Contains(s[right]))
        {
            window.Remove(s[left]);
            left++;
        }
        
        // Add current character
        window.Add(s[right]);
        
        // Update maximum
        maxLength = Math.Max(maxLength, right - left + 1);
    }
    
    return maxLength;
}
```

**Complexity:** O(n) time, O(min(n, m)) space where m = charset size

**Key Insights:**
- Expand window by moving right
- When duplicate found, contract from left until no duplicate
- Use HashSet for O(1) lookup
- Each character added and removed at most once → O(n) total

**Example:** "abcabcbb"
```
Step 1: window = {a}, length = 1
Step 2: window = {a, b}, length = 2
Step 3: window = {a, b, c}, length = 3
Step 4: found 'a' duplicate! Remove from left until no dup
        window = {b, c, a}, length = 3
Step 5: found 'b' duplicate! Remove from left
        window = {c, a, b}, length = 3
...
```

---

### LEVEL 4: PREFIX SUM

#### Problem 4.1: Range Sum Query

```csharp
public class RangeSumQuery
{
    private int[] prefix;
    
    public RangeSumQuery(int[] arr)
    {
        // Build prefix sum array
        prefix = new int[arr.Length + 1];  // prefix[0] = 0 for convenience
        
        for (int i = 0; i < arr.Length; i++)
        {
            prefix[i + 1] = prefix[i] + arr[i];
        }
    }
    
    public int SumRange(int i, int j)
    {
        // Sum from i to j = prefix[j+1] - prefix[i]
        return prefix[j + 1] - prefix[i];
    }
}
```

**Complexity:** O(n) preprocessing, O(1) per query

**Key Insights:**
- prefix[i] = sum of elements from index 0 to i-1
- sum(i, j) = prefix[j+1] - prefix[i]
- Trade space for time: O(n) space for O(1) queries

**Example:** arr = [1, 2, 3, 4, 5]
```
prefix = [0, 1, 3, 6, 10, 15]
          ↑
       prefix[0] = 0

sum(1, 3) = sum of [2, 3, 4]
          = prefix[4] - prefix[1]
          = 10 - 1
          = 9 ✓
```

---

#### Problem 4.2: Subarray Sum Equals K

```csharp
public static int SubarraySum(int[] arr, int k)
{
    Dictionary<int, int> prefixSumCount = new Dictionary<int, int>();
    prefixSumCount[0] = 1;  // Base case: sum 0 seen once (empty subarray)
    
    int currentSum = 0;
    int count = 0;
    
    for (int i = 0; i < arr.Length; i++)
    {
        currentSum += arr[i];
        
        // Check if (currentSum - k) exists
        // If yes, we found subarray(s) summing to k
        if (prefixSumCount.ContainsKey(currentSum - k))
        {
            count += prefixSumCount[currentSum - k];
        }
        
        // Add current sum to map
        if (!prefixSumCount.ContainsKey(currentSum))
            prefixSumCount[currentSum] = 0;
        prefixSumCount[currentSum]++;
    }
    
    return count;
}
```

**Complexity:** O(n) time, O(n) space

**Key Insights:**
- If prefix[j] - prefix[i] = k, then subarray[i+1...j] sums to k
- Rearrange: prefix[i] = prefix[j] - k
- For each j, check if (currentSum - k) exists in map
- Store counts because same prefix sum can occur multiple times!

**Example:** arr = [1, 1, 1], k = 2
```
i=0: currentSum = 1
     currentSum - k = 1 - 2 = -1 (not in map)
     Add 1 to map: {0:1, 1:1}
     
i=1: currentSum = 2
     currentSum - k = 2 - 2 = 0 (in map! count = 1)
     Found subarray [1,1]
     Add 2 to map: {0:1, 1:1, 2:1}
     
i=2: currentSum = 3
     currentSum - k = 3 - 2 = 1 (in map! count = 1)
     Found subarray [1,1] from index 1-2
     Total count = 2 ✓
```

---

#### Problem 4.3: Product of Array Except Self

```csharp
public static int[] ProductExceptSelf(int[] arr)
{
    int n = arr.Length;
    int[] result = new int[n];
    
    // Step 1: result[i] = product of all elements to the LEFT of i
    result[0] = 1;  // No elements to left of first
    for (int i = 1; i < n; i++)
    {
        result[i] = result[i - 1] * arr[i - 1];
    }
    
    // Step 2: Multiply by product of all elements to the RIGHT of i
    int rightProduct = 1;
    for (int i = n - 1; i >= 0; i--)
    {
        result[i] *= rightProduct;
        rightProduct *= arr[i];
    }
    
    return result;
}
```

**Complexity:** O(n) time, O(1) space (excluding output array)

**Key Insights:**
- Product except self = (product of left) × (product of right)
- Two passes: left products, then right products
- Use result array to store intermediate left products
- Second pass multiplies by right product on-the-fly

**Example:** arr = [1, 2, 3, 4]
```
After left pass:  result = [1, 1, 2, 6]
                           ↑  ↑  ↑  ↑
                           1  1  1×2  1×2×3

After right pass: result = [24, 12, 8, 6]
                           ↑   ↑   ↑  ↑
                         1×(2×3×4) 1×(3×4) 2×(4) 6×1

result[0] = 1 × (2×3×4) = 24 ✓
result[1] = 1 × (3×4) = 12 ✓
result[2] = 2 × 4 = 8 ✓
result[3] = 6 × 1 = 6 ✓
```

---

## Module 4 Solutions: Advanced Problems

### Problem 1: Kadane's Algorithm

```csharp
public static int MaxSubarraySum(int[] arr)
{
    int maxEndingHere = arr[0];
    int maxSoFar = arr[0];
    
    for (int i = 1; i < arr.Length; i++)
    {
        // Either extend current subarray or start new one
        maxEndingHere = Math.Max(arr[i], maxEndingHere + arr[i]);
        maxSoFar = Math.Max(maxSoFar, maxEndingHere);
    }
    
    return maxSoFar;
}
```

**With indices:**
```csharp
public static int[] MaxSubarrayWithIndices(int[] arr, out int start, out int end)
{
    int maxEndingHere = arr[0];
    int maxSoFar = arr[0];
    start = 0;
    end = 0;
    int tempStart = 0;
    
    for (int i = 1; i < arr.Length; i++)
    {
        if (arr[i] > maxEndingHere + arr[i])
        {
            maxEndingHere = arr[i];
            tempStart = i;  // Starting new subarray
        }
        else
        {
            maxEndingHere = maxEndingHere + arr[i];
        }
        
        if (maxEndingHere > maxSoFar)
        {
            maxSoFar = maxEndingHere;
            start = tempStart;
            end = i;
        }
    }
    
    int[] result = new int[end - start + 1];
    Array.Copy(arr, start, result, 0, end - start + 1);
    return result;
}
```

**Complexity:** O(n) time, O(1) space

---

### Problem 2: Trapping Rain Water

```csharp
public static int TrapRainWater(int[] heights)
{
    if (heights == null || heights.Length == 0)
        return 0;
    
    int left = 0;
    int right = heights.Length - 1;
    int leftMax = 0;
    int rightMax = 0;
    int water = 0;
    
    while (left < right)
    {
        if (heights[left] < heights[right])
        {
            // Process left side (it's the bottleneck)
            if (heights[left] >= leftMax)
            {
                leftMax = heights[left];  // No water here
            }
            else
            {
                water += leftMax - heights[left];  // Trap water
            }
            left++;
        }
        else
        {
            // Process right side (it's the bottleneck)
            if (heights[right] >= rightMax)
            {
                rightMax = heights[right];  // No water here
            }
            else
            {
                water += rightMax - heights[right];  // Trap water
            }
            right--;
        }
    }
    
    return water;
}
```

**Complexity:** O(n) time, O(1) space

**Key Insight:** Water at position i = min(leftMax, rightMax) - height[i]
By using two pointers, we process from the side with smaller max (the bottleneck).

---

*Continue reading for remaining solutions...*

---

## Tips for Using These Solutions

1. **Don't memorize code** - Understand the pattern
2. **Implement yourself** - Type it out, don't copy-paste
3. **Test edge cases** - Empty array, single element, all same
4. **Explain complexity** - Can you justify the O(n)?
5. **Find variations** - What if input is unsorted? What if negatives not allowed?

Remember: "Struggle + Solution = Learning"

---

Need more solutions or explanations? Just ask!
