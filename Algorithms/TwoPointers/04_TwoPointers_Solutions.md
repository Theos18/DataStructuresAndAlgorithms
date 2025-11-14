# Two Pointers: Solutions Guide

> "Understanding is a kind of ecstasy." - Carl Sagan

This guide doesn't just give you the code—it explains the **THINKING PROCESS** behind each solution. Focus on understanding WHY each decision is made.

---

## Table of Contents
- [Level 1: Opposite Direction](#level-1-opposite-direction)
- [Level 2: Same Direction](#level-2-same-direction)
- [Level 3: Multiple Arrays](#level-3-multiple-arrays)
- [Level 4: Partitioning](#level-4-partitioning)
- [Level 5: Advanced](#level-5-advanced)

---

## LEVEL 1: OPPOSITE DIRECTION

### Problem 1.1: Two Sum in Sorted Array

**Brute Force Analysis:**
```
Check every pair: O(n²)
for i in 0..n:
    for j in i+1..n:
        if arr[i] + arr[j] == target: return [i, j]
```

**The Redundancy:**  
If `arr[0] + arr[n-1]` is too large, we don't need to check `arr[0]` with ANY element larger than `arr[n-1]`. We've eliminated `arr[n-1]` from consideration!

**The Invariant:**  
At any point, the solution (if exists) must be in `[left, right]` range.

**Decision Logic:**
- If `sum < target`: Need larger sum → move `left++` (smallest element too small)
- If `sum > target`: Need smaller sum → move `right--` (largest element too large)
- If `sum == target`: Found it!

**Solution:**
```csharp
public static int[] TwoSumSorted(int[] arr, int target)
{
    int left = 0, right = arr.Length - 1;
    
    while (left < right)
    {
        int sum = arr[left] + arr[right];
        
        if (sum == target)
            return new int[] { left, right };
        else if (sum < target)
            left++;   // Need larger sum
        else
            right--;  // Need smaller sum
    }
    
    return new int[] { -1, -1 };  // No solution
}
```

**Complexity:**
- Time: O(n) - single pass
- Space: O(1) - only pointers

**Why This Works:**  
Because array is sorted, moving left pointer always increases sum, moving right pointer always decreases sum. We're doing a **guided binary search** through the solution space!

---

### Problem 1.2: Three Sum

**The Reduction:**  
Three Sum → Two Sum!

For each element `arr[i]`, we need to find two elements that sum to `-arr[i]`.

**Why Sort?**  
To use Two Sum Sorted technique on the remaining array.

**Handling Duplicates:**  
Skip duplicate values for the first element to avoid duplicate triplets.

**Solution:**
```csharp
public static List<List<int>> ThreeSum(int[] arr)
{
    Array.Sort(arr);  // MUST sort first
    var result = new List<List<int>>();
    
    for (int i = 0; i < arr.Length - 2; i++)
    {
        // Skip duplicates for first element
        if (i > 0 && arr[i] == arr[i - 1])
            continue;
        
        // Now find two numbers that sum to -arr[i]
        int left = i + 1;
        int right = arr.Length - 1;
        int target = -arr[i];
        
        while (left < right)
        {
            int sum = arr[left] + arr[right];
            
            if (sum == target)
            {
                result.Add(new List<int> { arr[i], arr[left], arr[right] });
                
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
                left++;
            else
                right--;
        }
    }
    
    return result;
}
```

**Complexity:**
- Time: O(n²) - O(n log n) sort + O(n) × O(n) nested loop
- Space: O(1) ignoring output

**Key Insight:**  
By fixing one element, we reduce the problem by one dimension!

---

### Problem 1.3: Container With Most Water

**Initial Thought:**  
Start with maximum width (left=0, right=n-1). To potentially increase area, we need to find taller lines.

**Critical Insight:**  
The **shorter line** is the bottleneck! Moving the taller line can only:
- Keep height same (if new line is taller)
- Decrease height (if new line is shorter)
- Width DEFINITELY decreases

But moving the shorter line gives a CHANCE of finding a taller line that compensates for the width loss.

**Solution:**
```csharp
public static int MaxArea(int[] heights)
{
    int left = 0, right = heights.Length - 1;
    int maxArea = 0;
    
    while (left < right)
    {
        // Calculate current area
        int width = right - left;
        int height = Math.Min(heights[left], heights[right]);
        int area = width * height;
        
        maxArea = Math.Max(maxArea, area);
        
        // Move the shorter line (bottleneck)
        if (heights[left] < heights[right])
            left++;
        else
            right--;
    }
    
    return maxArea;
}
```

**Why This is Optimal:**  
We never miss the optimal solution because:
- We start with maximum width
- We only discard configurations that can't be better
- Moving the shorter line is the ONLY way to potentially improve

**Complexity:**
- Time: O(n) - single pass
- Space: O(1)

---

### Problem 1.4: Valid Palindrome

**The Simplest Pattern:**  
Compare from both ends inward.

**Solution:**
```csharp
public static bool IsPalindrome(string s)
{
    int left = 0, right = s.Length - 1;
    
    while (left < right)
    {
        // Skip non-alphanumeric characters
        while (left < right && !char.IsLetterOrDigit(s[left]))
            left++;
        while (left < right && !char.IsLetterOrDigit(s[right]))
            right--;
        
        // Compare characters (case-insensitive)
        if (char.ToLower(s[left]) != char.ToLower(s[right]))
            return false;
        
        left++;
        right--;
    }
    
    return true;
}
```

**Complexity:**
- Time: O(n)
- Space: O(1)

---

### Problem 1.5: Trapping Rain Water

**Traditional Approach:**
```
For each position i:
    water[i] = min(maxLeft[i], maxRight[i]) - height[i]
```
Requires O(n) space for maxLeft and maxRight arrays.

**Two Pointers Insight:**  
We don't need to pre-calculate maxLeft/maxRight for ALL positions!

**Key Observation:**  
If `heights[left] < heights[right]`:
- LEFT side is the bottleneck
- We KNOW maxRight ≥ heights[right] (it's standing right there!)
- So water at left = maxLeft - heights[left]
- We can calculate it NOW!

**Visual Understanding:**
```
Left bottleneck (heights[left] < heights[right]):
    █
  ? █   <- Right side guarantees at least this height
█ ? █
^
left

The ? water level is limited by maxLeft, not right side!
```

**Solution:**
```csharp
public static int TrapRainWater(int[] heights)
{
    if (heights.Length == 0) return 0;
    
    int left = 0, right = heights.Length - 1;
    int leftMax = 0, rightMax = 0;
    int water = 0;
    
    while (left < right)
    {
        if (heights[left] < heights[right])
        {
            // LEFT is bottleneck, process left side
            if (heights[left] >= leftMax)
                leftMax = heights[left];  // Update max
            else
                water += leftMax - heights[left];  // Add water
            
            left++;
        }
        else
        {
            // RIGHT is bottleneck, process right side
            if (heights[right] >= rightMax)
                rightMax = heights[right];
            else
                water += rightMax - heights[right];
            
            right--;
        }
    }
    
    return water;
}
```

**Why This Works:**  
At each step, we process the side with smaller boundary height because:
1. That side's water level is DETERMINED by its max height so far
2. The other side guarantees sufficient height (it's taller!)
3. We can confidently calculate water without knowing exact maxRight/maxLeft

**Complexity:**
- Time: O(n) - single pass
- Space: O(1) - only variables!

**This is GENIUS-LEVEL optimization!** Draw it out to truly understand.

---

## LEVEL 2: SAME DIRECTION

### Problem 2.1: Remove Duplicates from Sorted Array

**Invariant:**  
Elements `[0, slow)` contain unique elements in sorted order.

**Logic:**
- `slow` = position for next unique element
- `fast` = scans through array
- When `arr[fast]` is different from last unique element, place it at `slow`

**Solution:**
```csharp
public static int RemoveDuplicates(int[] arr)
{
    if (arr.Length == 0) return 0;
    
    int slow = 1;  // Position for next unique element
    
    for (int fast = 1; fast < arr.Length; fast++)
    {
        if (arr[fast] != arr[slow - 1])
        {
            arr[slow] = arr[fast];
            slow++;
        }
    }
    
    return slow;  // New length
}
```

**Trace Example:**
```
Input: [1, 1, 2, 2, 2, 3, 4, 4]

slow=1, fast=1: arr[1]=1 == arr[0]=1, skip
slow=1, fast=2: arr[2]=2 != arr[0]=1, arr[1]=2, slow=2
slow=2, fast=3: arr[3]=2 == arr[1]=2, skip
slow=2, fast=4: arr[4]=2 == arr[1]=2, skip
slow=2, fast=5: arr[5]=3 != arr[1]=2, arr[2]=3, slow=3
slow=3, fast=6: arr[6]=4 != arr[2]=3, arr[3]=4, slow=4
slow=4, fast=7: arr[7]=4 == arr[3]=4, skip

Result: [1, 2, 3, 4, ...], length = 4
```

**Complexity:**
- Time: O(n)
- Space: O(1)

---

### Problem 2.2: Move Zeros to End

**Approach 1: Collect Non-Zeros**
```csharp
public static void MoveZeros(int[] arr)
{
    int slow = 0;  // Position for next non-zero
    
    // Move all non-zeros to front
    for (int fast = 0; fast < arr.Length; fast++)
    {
        if (arr[fast] != 0)
        {
            arr[slow] = arr[fast];
            slow++;
        }
    }
    
    // Fill remaining with zeros
    while (slow < arr.Length)
    {
        arr[slow] = 0;
        slow++;
    }
}
```

**Approach 2: Swap (More Elegant)**
```csharp
public static void MoveZeros(int[] arr)
{
    int slow = 0;  // Boundary of non-zero region
    
    for (int fast = 0; fast < arr.Length; fast++)
    {
        if (arr[fast] != 0)
        {
            // Swap non-zero to front
            int temp = arr[slow];
            arr[slow] = arr[fast];
            arr[fast] = temp;
            
            slow++;
        }
    }
}
```

**Invariant:**  
Elements `[0, slow)` are non-zero, elements `[slow, fast)` are zeros.

**Complexity:**
- Time: O(n)
- Space: O(1)

---

### Problem 2.3: Remove Element

**Pattern Recognition:**  
Same as Remove Duplicates, but removing specific value instead.

**Solution:**
```csharp
public static int RemoveElement(int[] arr, int val)
{
    int slow = 0;  // Position for next valid element
    
    for (int fast = 0; fast < arr.Length; fast++)
    {
        if (arr[fast] != val)
        {
            arr[slow] = arr[fast];
            slow++;
        }
    }
    
    return slow;
}
```

**Complexity:**
- Time: O(n)
- Space: O(1)

---

### Problem 2.4: Partition Array

**This is QuickSort's Core!**

**Invariant:**
- `[0, slow)`: elements < pivot
- `[slow, fast)`: elements ≥ pivot
- `[fast, n)`: unprocessed

**Solution:**
```csharp
public static int PartitionArray(int[] arr, int pivot)
{
    int slow = 0;  // Boundary of "less than pivot" region
    
    for (int fast = 0; fast < arr.Length; fast++)
    {
        if (arr[fast] < pivot)
        {
            // Swap to "less than" region
            int temp = arr[slow];
            arr[slow] = arr[fast];
            arr[fast] = temp;
            
            slow++;
        }
    }
    
    return slow;  // Index where pivot region starts
}
```

**Trace Example:**
```
Input: [3, 5, 1, 2, 4, 2], pivot = 3

slow=0, fast=0: 3 >= 3, skip
slow=0, fast=1: 5 >= 3, skip
slow=0, fast=2: 1 < 3, swap(0,2) → [1, 5, 3, 2, 4, 2], slow=1
slow=1, fast=3: 2 < 3, swap(1,3) → [1, 2, 3, 5, 4, 2], slow=2
slow=2, fast=4: 4 >= 3, skip
slow=2, fast=5: 2 < 3, swap(2,5) → [1, 2, 2, 5, 4, 3], slow=3

Result: [1, 2, 2 | 5, 4, 3], pivot index = 3
```

**Complexity:**
- Time: O(n)
- Space: O(1)

---

### Problem 2.5: Sort by Parity

**Recognition:**  
This is Partition Array where pivot concept = "evenness"!

**Solution:**
```csharp
public static int[] SortByParity(int[] arr)
{
    int slow = 0;  // Boundary of even numbers
    
    for (int fast = 0; fast < arr.Length; fast++)
    {
        if (arr[fast] % 2 == 0)  // Even number
        {
            int temp = arr[slow];
            arr[slow] = arr[fast];
            arr[fast] = temp;
            
            slow++;
        }
    }
    
    return arr;
}
```

**Complexity:**
- Time: O(n)
- Space: O(1)

---

## LEVEL 3: MULTIPLE ARRAYS

### Problem 3.1: Merge Two Sorted Arrays

**The Merge Step in MergeSort!**

**Logic:**  
Compare elements at both pointers, take smaller one.

**Solution:**
```csharp
public static int[] MergeSortedArrays(int[] arr1, int[] arr2)
{
    int[] result = new int[arr1.Length + arr2.Length];
    int i = 0, j = 0, k = 0;
    
    // Merge while both arrays have elements
    while (i < arr1.Length && j < arr2.Length)
    {
        if (arr1[i] <= arr2[j])
            result[k++] = arr1[i++];
        else
            result[k++] = arr2[j++];
    }
    
    // Copy remaining elements from arr1
    while (i < arr1.Length)
        result[k++] = arr1[i++];
    
    // Copy remaining elements from arr2
    while (j < arr2.Length)
        result[k++] = arr2[j++];
    
    return result;
}
```

**Complexity:**
- Time: O(n + m)
- Space: O(n + m) for result

---

### Problem 3.2: Intersection of Two Sorted Arrays

**Decision Logic:**
```
if arr1[i] == arr2[j]: Found intersection → move both
if arr1[i] < arr2[j]:  arr1[i] too small → move i
if arr1[i] > arr2[j]:  arr2[j] too small → move j
```

**Solution:**
```csharp
public static List<int> IntersectionSorted(int[] arr1, int[] arr2)
{
    var result = new List<int>();
    int i = 0, j = 0;
    
    while (i < arr1.Length && j < arr2.Length)
    {
        if (arr1[i] == arr2[j])
        {
            result.Add(arr1[i]);
            i++;
            j++;
        }
        else if (arr1[i] < arr2[j])
            i++;  // arr1[i] too small
        else
            j++;  // arr2[j] too small
    }
    
    return result;
}
```

**Complexity:**
- Time: O(n + m)
- Space: O(min(n, m)) for result

---

### Problem 3.3: Merge Intervals

**Approach:**
1. Sort by start time
2. Track "current merged interval"
3. For each next interval:
   - If overlaps with current: Extend current
   - If doesn't overlap: Add current to result, start new

**Overlap Condition:**  
`next.start ≤ current.end`

**Solution:**
```csharp
public static int[][] MergeIntervals(int[][] intervals)
{
    if (intervals.Length == 0) return new int[0][];
    
    // Sort by start time
    Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
    
    var result = new List<int[]>();
    int[] current = intervals[0];
    
    for (int i = 1; i < intervals.Length; i++)
    {
        if (intervals[i][0] <= current[1])
        {
            // Overlap: extend current interval
            current[1] = Math.Max(current[1], intervals[i][1]);
        }
        else
        {
            // No overlap: save current, start new
            result.Add(current);
            current = intervals[i];
        }
    }
    
    result.Add(current);  // Don't forget last interval!
    return result.ToArray();
}
```

**Trace Example:**
```
Input: [[1,3], [2,6], [8,10], [15,18]]

After sort: [[1,3], [2,6], [8,10], [15,18]]

current = [1,3]
i=1: [2,6], 2 ≤ 3 → overlap, extend to [1,6]
i=2: [8,10], 8 > 6 → no overlap, save [1,6], current = [8,10]
i=3: [15,18], 15 > 10 → no overlap, save [8,10], current = [15,18]
End: save [15,18]

Result: [[1,6], [8,10], [15,18]]
```

**Complexity:**
- Time: O(n log n) - sorting dominates
- Space: O(n) for result

---

## LEVEL 4: PARTITIONING

### Problem 4.1: Sort Colors (Dutch National Flag)

**Three Regions:**
```
[0, low):   all 0s
[low, mid): all 1s
(high, n]:  all 2s
[mid, high]: unknown (process this region)
```

**Decision Logic:**
```
If arr[mid] == 0: Swap with low, move both (we know arr[low] is 1)
If arr[mid] == 1: Just move mid (it's in correct region)
If arr[mid] == 2: Swap with high, move high (don't move mid! we don't know what we got)
```

**Solution:**
```csharp
public static void SortColors(int[] arr)
{
    int low = 0;     // Boundary of 0s
    int mid = 0;     // Current element
    int high = arr.Length - 1;  // Boundary of 2s
    
    while (mid <= high)
    {
        if (arr[mid] == 0)
        {
            // Swap with low region
            int temp = arr[low];
            arr[low] = arr[mid];
            arr[mid] = temp;
            
            low++;
            mid++;  // We know arr[low] was 1, safe to move mid
        }
        else if (arr[mid] == 1)
        {
            mid++;  // Already in correct position
        }
        else  // arr[mid] == 2
        {
            // Swap with high region
            int temp = arr[high];
            arr[high] = arr[mid];
            arr[mid] = temp;
            
            high--;
            // Don't move mid! We need to process swapped element
        }
    }
}
```

**Trace Example:**
```
Input: [2, 0, 2, 1, 1, 0]
         ^        ^     ^
       low,mid        high

mid=0: arr[0]=2, swap(0,5) → [0,0,2,1,1,2], high=4
mid=0: arr[0]=0, swap(0,0) → [0,0,2,1,1,2], low=1, mid=1
mid=1: arr[1]=0, swap(1,1) → [0,0,2,1,1,2], low=2, mid=2
mid=2: arr[2]=2, swap(2,4) → [0,0,1,1,2,2], high=3
mid=2: arr[2]=1, mid=3
mid=3: arr[3]=1, mid=4
mid=4: mid > high, STOP

Result: [0, 0, 1, 1, 2, 2]
```

**Complexity:**
- Time: O(n) - single pass
- Space: O(1)

**This is one of the most elegant algorithms in computer science!**

---

### Problem 4.2: Three-Way Partition

**Generalization of Sort Colors:**  
Instead of 0/1/2, partition by < pivot / == pivot / > pivot.

**Solution:**
```csharp
public static void ThreeWayPartition(int[] arr, int pivot)
{
    int low = 0;
    int mid = 0;
    int high = arr.Length - 1;
    
    while (mid <= high)
    {
        if (arr[mid] < pivot)
        {
            int temp = arr[low];
            arr[low] = arr[mid];
            arr[mid] = temp;
            low++;
            mid++;
        }
        else if (arr[mid] == pivot)
        {
            mid++;
        }
        else  // arr[mid] > pivot
        {
            int temp = arr[high];
            arr[high] = arr[mid];
            arr[mid] = temp;
            high--;
        }
    }
}
```

**Complexity:**
- Time: O(n)
- Space: O(1)

---

## LEVEL 5: ADVANCED

### Problem 5.1: Four Sum

**Reduction Chain:**  
Four Sum → Three Sum → Two Sum

**Solution:**
```csharp
public static List<List<int>> FourSum(int[] arr, int target)
{
    Array.Sort(arr);
    var result = new List<List<int>>();
    
    for (int i = 0; i < arr.Length - 3; i++)
    {
        // Skip duplicates for first element
        if (i > 0 && arr[i] == arr[i - 1]) continue;
        
        for (int j = i + 1; j < arr.Length - 2; j++)
        {
            // Skip duplicates for second element
            if (j > i + 1 && arr[j] == arr[j - 1]) continue;
            
            // Two pointers for remaining two elements
            int left = j + 1;
            int right = arr.Length - 1;
            long twoSumTarget = (long)target - arr[i] - arr[j];
            
            while (left < right)
            {
                long sum = arr[left] + arr[right];
                
                if (sum == twoSumTarget)
                {
                    result.Add(new List<int> { arr[i], arr[j], arr[left], arr[right] });
                    
                    while (left < right && arr[left] == arr[left + 1]) left++;
                    while (left < right && arr[right] == arr[right - 1]) right--;
                    
                    left++;
                    right--;
                }
                else if (sum < twoSumTarget)
                    left++;
                else
                    right--;
            }
        }
    }
    
    return result;
}
```

**Complexity:**
- Time: O(n³) - two nested loops + O(n) two pointers
- Space: O(1) ignoring output

---

### Problem 5.2: Boats to Save People

**Greedy Insight:**  
Try to pair heaviest with lightest. If they can't fit together, heaviest person needs their own boat.

**Solution:**
```csharp
public static int NumRescueBoats(int[] people, int limit)
{
    Array.Sort(people);
    
    int left = 0, right = people.Length - 1;
    int boats = 0;
    
    while (left <= right)
    {
        if (people[left] + people[right] <= limit)
        {
            // Both fit in one boat
            left++;
            right--;
        }
        else
        {
            // Heaviest person needs own boat
            right--;
        }
        
        boats++;
    }
    
    return boats;
}
```

**Why Greedy Works:**  
If heaviest can't pair with lightest, they can't pair with ANYONE (everyone else is heavier than lightest).

**Complexity:**
- Time: O(n log n) - sorting
- Space: O(1)

---

### Problem 5.3: Subarray Product Less Than K

**Insight:**  
For window `[left, right]` with product < k:
- Number of subarrays ending at `right` = `right - left + 1`

Example: `[10, 5, 2]`  
Subarrays ending at index 2: `[2]`, `[5,2]`, `[10,5,2]` → 3 subarrays

**Solution:**
```csharp
public static int NumSubarrayProductLessThanK(int[] arr, int k)
{
    if (k <= 1) return 0;  // No products can be < 1
    
    int left = 0;
    int product = 1;
    int count = 0;
    
    for (int right = 0; right < arr.Length; right++)
    {
        product *= arr[right];
        
        // Shrink window while product >= k
        while (product >= k)
        {
            product /= arr[left];
            left++;
        }
        
        // Count subarrays ending at right
        count += right - left + 1;
    }
    
    return count;
}
```

**Trace Example:**
```
Input: [10, 5, 2, 6], k = 100

right=0: product=10, count += 1 → [10]
right=1: product=50, count += 2 → [10,5], [5]
right=2: product=100, shrink: product=10, left=1
         count += 2 → [5,2], [2]
right=3: product=60, count += 3 → [5,2,6], [2,6], [6]

Total: 8
```

**Complexity:**
- Time: O(n) - each element visited at most twice
- Space: O(1)

---

## Meta-Pattern Recognition

After solving these problems, you should recognize:

1. **Opposite Direction:**
   - Sorted data with target condition
   - Elimination from both ends
   - Examples: Two Sum, Three Sum, Container, Trapping Water

2. **Same Direction:**
   - In-place modifications
   - Building result array region
   - Invariant: `[0, slow)` has desired property
   - Examples: Remove Duplicates, Partition, Move Zeros

3. **Multiple Arrays:**
   - Coordinating pointers across arrays
   - Merge-like operations
   - Examples: Merge Sorted, Intersection

4. **Partitioning:**
   - Multiple regions with invariants
   - Often 3+ pointers
   - Examples: Sort Colors, Three-Way Partition

Now you don't just have solutions—you have **MENTAL MODELS** for recognizing and solving two-pointer problems!
