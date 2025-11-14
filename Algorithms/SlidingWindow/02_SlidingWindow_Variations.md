# Sliding Window: All Variations with Templates

> "Give me six hours to chop down a tree and I will spend the first four sharpening the axe." - Abraham Lincoln

This document provides **battle-tested templates** for every sliding window variation. But more importantly, it explains WHEN and WHY to use each one.

---

## Table of Contents
1. [Fixed Window Template](#1-fixed-window-template)
2. [Variable Window - Longest](#2-variable-window---longest)
3. [Variable Window - Shortest](#3-variable-window---shortest)
4. [Variable Window - Count](#4-variable-window---count)
5. [Advanced Patterns](#5-advanced-patterns)
6. [Pattern Selection Guide](#pattern-selection-guide)

---

## 1. Fixed Window Template

### When to Use
- Problem explicitly states **"size k"**, **"k consecutive"**, or **"window of length k"**
- Window size is **constant and known**

### The Template

```csharp
public int FixedWindowTemplate(int[] arr, int k)
{
    // 1. Handle edge cases
    if (arr.Length < k) return -1;
    
    // 2. Initialize window state
    int windowSum = 0;  // or whatever you're tracking
    
    // 3. Calculate first window
    for (int i = 0; i < k; i++)
    {
        windowSum += arr[i];  // Add to window
    }
    
    // 4. Initialize result
    int result = windowSum;  // or ProcessWindow(windowSum)
    
    // 5. Slide the window
    for (int i = k; i < arr.Length; i++)
    {
        // Remove leftmost element
        windowSum -= arr[i - k];
        
        // Add rightmost element
        windowSum += arr[i];
        
        // Update result
        result = Math.Max(result, windowSum);  // or update based on condition
    }
    
    return result;
}
```

### Key Points

**Index Calculation:**
- Current window: `[i - k + 1, i]` where `i` is the right edge
- Remove: `arr[i - k]` (leftmost element leaving window)
- Add: `arr[i]` (rightmost element entering window)

**Common Variations:**

#### Track Maximum/Minimum
```csharp
int maxValue = int.MinValue;

// In sliding loop:
maxValue = Math.Max(maxValue, currentValue);
```

#### Track Average
```csharp
double average = (double)windowSum / k;
```

#### Track Multiple Metrics
```csharp
int sum = 0;
int product = 1;

// Add element
sum += arr[i];
product *= arr[i];

// Remove element
sum -= arr[i - k];
product /= arr[i - k];
```

---

### Example 1: Maximum Sum of Subarray Size K

**Problem:** Find maximum sum of any subarray of size k.

```csharp
public int MaxSumSubarray(int[] arr, int k)
{
    if (arr.Length < k) return -1;
    
    int windowSum = 0;
    
    // First window
    for (int i = 0; i < k; i++)
        windowSum += arr[i];
    
    int maxSum = windowSum;
    
    // Slide window
    for (int i = k; i < arr.Length; i++)
    {
        windowSum = windowSum - arr[i - k] + arr[i];
        maxSum = Math.Max(maxSum, windowSum);
    }
    
    return maxSum;
}
```

**Complexity:** O(n)  
**Space:** O(1)

---

### Example 2: First Negative Number in Every Window

**Problem:** For each window of size k, find first negative number.

```csharp
public int[] FirstNegativeInWindow(int[] arr, int k)
{
    var result = new List<int>();
    var negatives = new Queue<int>();  // Store indices of negatives
    
    // First window
    for (int i = 0; i < k; i++)
    {
        if (arr[i] < 0)
            negatives.Enqueue(i);
    }
    
    result.Add(negatives.Count > 0 ? arr[negatives.Peek()] : 0);
    
    // Slide window
    for (int i = k; i < arr.Length; i++)
    {
        // Remove elements outside window
        while (negatives.Count > 0 && negatives.Peek() <= i - k)
            negatives.Dequeue();
        
        // Add new element if negative
        if (arr[i] < 0)
            negatives.Enqueue(i);
        
        result.Add(negatives.Count > 0 ? arr[negatives.Peek()] : 0);
    }
    
    return result.ToArray();
}
```

**Key Insight:** Use queue to track relevant elements in window.

---

## 2. Variable Window - Longest

### When to Use
- Finding **"longest"** or **"maximum length"** substring/subarray
- Condition: **"at most k"**, **"with property P"**

### The Mindset

> **"Expand greedily, contract when invalid, track maximum."**

### The Template

```csharp
public int LongestWindowTemplate(int[] arr, int k)
{
    int left = 0;
    int maxLength = 0;
    
    // Track window state
    int windowState = 0;  // sum, count, frequency map, etc.
    
    for (int right = 0; right < arr.Length; right++)
    {
        // 1. EXPAND: Add arr[right] to window
        windowState += arr[right];  // Update state
        
        // 2. CONTRACT: Shrink while condition violated
        while (WindowInvalid(windowState, k))
        {
            windowState -= arr[left];  // Remove arr[left]
            left++;
        }
        
        // 3. UPDATE: Window is now valid, track length
        maxLength = Math.Max(maxLength, right - left + 1);
    }
    
    return maxLength;
}
```

### Key Decision: When to Shrink?

**Pattern 1: "At Most K"**
```csharp
while (distinctCount > k)  // Violated: more than k
    // shrink
```

**Pattern 2: "Valid Condition"**
```csharp
while (sum > target)  // Violated: sum too large
    // shrink
```

**Pattern 3: "Contains Something"**
```csharp
while (!ContainsRequired())  // Not yet valid
    // expand (don't update result yet)
```

---

### Example 1: Longest Substring with At Most K Distinct Characters

**Problem:** Find longest substring with ≤ k distinct characters.

```csharp
public int LongestSubstringKDistinct(string s, int k)
{
    if (k == 0) return 0;
    
    var freq = new Dictionary<char, int>();
    int left = 0;
    int maxLength = 0;
    
    for (int right = 0; right < s.Length; right++)
    {
        // Expand: add s[right]
        char c = s[right];
        if (!freq.ContainsKey(c))
            freq[c] = 0;
        freq[c]++;
        
        // Contract: while > k distinct
        while (freq.Count > k)
        {
            char leftChar = s[left];
            freq[leftChar]--;
            if (freq[leftChar] == 0)
                freq.Remove(leftChar);
            left++;
        }
        
        // Update result
        maxLength = Math.Max(maxLength, right - left + 1);
    }
    
    return maxLength;
}
```

**Trace Example:**
```
s = "eceba", k = 2

right=0: 'e' → {e:1} ✓ len=1
right=1: 'c' → {e:1,c:1} ✓ len=2
right=2: 'e' → {e:2,c:1} ✓ len=3
right=3: 'b' → {e:2,c:1,b:1} ✗ 3 distinct!
         shrink: remove 'e' → {c:1,e:1,b:1} ✗ still 3
         shrink: remove 'c' → {e:1,b:1} ✓ len=2
right=4: 'a' → {e:1,b:1,a:1} ✗ shrink
         remove 'e' → {b:1,a:1} ✓ len=2

Answer: 3
```

---

### Example 2: Longest Subarray with Sum ≤ K

**Problem:** Find longest subarray with sum ≤ k.

```csharp
public int LongestSubarrayWithSumAtMostK(int[] arr, int k)
{
    int left = 0;
    int sum = 0;
    int maxLength = 0;
    
    for (int right = 0; right < arr.Length; right++)
    {
        sum += arr[right];
        
        while (sum > k)
        {
            sum -= arr[left];
            left++;
        }
        
        maxLength = Math.Max(maxLength, right - left + 1);
    }
    
    return maxLength;
}
```

**Why it works:** Sum is cumulative, so shrinking reduces it monotonically.

---

## 3. Variable Window - Shortest

### When to Use
- Finding **"shortest"** or **"minimum length"** substring/subarray
- Condition: **"contains all"**, **"at least k"**

### The Mindset

> **"Expand until valid, then contract while valid, track minimum."**

### The Template

```csharp
public int ShortestWindowTemplate(int[] arr, int target)
{
    int left = 0;
    int minLength = int.MaxValue;
    
    int windowState = 0;
    
    for (int right = 0; right < arr.Length; right++)
    {
        // 1. EXPAND: Add arr[right]
        windowState += arr[right];
        
        // 2. CONTRACT: Shrink WHILE condition satisfied
        while (WindowValid(windowState, target))
        {
            // 3. UPDATE: Window is valid, track minimum
            minLength = Math.Min(minLength, right - left + 1);
            
            // Now try to shrink
            windowState -= arr[left];
            left++;
        }
    }
    
    return minLength == int.MaxValue ? -1 : minLength;
}
```

### Key Difference from "Longest"

**Longest:** Update result AFTER shrinking (want largest valid window)
```csharp
while (invalid)
    shrink();
maxLength = Math.Max(maxLength, right - left + 1);
```

**Shortest:** Update result DURING shrinking (want smallest valid window)
```csharp
while (valid)
{
    minLength = Math.Min(minLength, right - left + 1);
    shrink();
}
```

---

### Example 1: Minimum Window Substring

**Problem:** Find minimum window in `s` containing all characters of `t`.

```csharp
public string MinWindowSubstring(string s, string t)
{
    if (s.Length < t.Length) return "";
    
    // Frequency of characters needed
    var required = new Dictionary<char, int>();
    foreach (char c in t)
    {
        if (!required.ContainsKey(c))
            required[c] = 0;
        required[c]++;
    }
    
    var windowFreq = new Dictionary<char, int>();
    int left = 0;
    int formed = 0;  // How many unique chars have required frequency
    int minLength = int.MaxValue;
    int minLeft = 0;
    
    for (int right = 0; right < s.Length; right++)
    {
        // Expand: add s[right]
        char c = s[right];
        if (!windowFreq.ContainsKey(c))
            windowFreq[c] = 0;
        windowFreq[c]++;
        
        // Check if current char satisfies requirement
        if (required.ContainsKey(c) && windowFreq[c] == required[c])
            formed++;
        
        // Contract: while window is valid
        while (formed == required.Count && left <= right)
        {
            // Update result
            if (right - left + 1 < minLength)
            {
                minLength = right - left + 1;
                minLeft = left;
            }
            
            // Try to shrink
            char leftChar = s[left];
            windowFreq[leftChar]--;
            if (required.ContainsKey(leftChar) && windowFreq[leftChar] < required[leftChar])
                formed--;
            
            left++;
        }
    }
    
    return minLength == int.MaxValue ? "" : s.Substring(minLeft, minLength);
}
```

**Trace Example:**
```
s = "ADOBECODEBANC", t = "ABC"

Expand to: "ADOBEC" → contains A, B, C ✓
Contract: "DOBEC" ✗ missing A
         "ADOBEC" is candidate (len=6)

Continue expanding...
"ADOBECODEBA" → contains A, B, C ✓
Contract: "CODEBA" ✗
         "ODEBAN" ✗
         "BANC" ✓ (len=4) ← better!

Answer: "BANC"
```

---

### Example 2: Minimum Size Subarray Sum

**Problem:** Find minimum length subarray with sum ≥ target.

```csharp
public int MinSubArrayLen(int target, int[] arr)
{
    int left = 0;
    int sum = 0;
    int minLength = int.MaxValue;
    
    for (int right = 0; right < arr.Length; right++)
    {
        sum += arr[right];
        
        // Shrink while valid (sum >= target)
        while (sum >= target)
        {
            minLength = Math.Min(minLength, right - left + 1);
            sum -= arr[left];
            left++;
        }
    }
    
    return minLength == int.MaxValue ? 0 : minLength;
}
```

---

## 4. Variable Window - Count

### When to Use
- Count number of subarrays/substrings satisfying condition
- Often "at most k" or "exactly k"

### The Template

```csharp
public int CountWindowsTemplate(int[] arr, int k)
{
    int left = 0;
    int count = 0;
    int windowState = 0;
    
    for (int right = 0; right < arr.Length; right++)
    {
        // Expand: add arr[right]
        windowState += arr[right];
        
        // Contract: while invalid
        while (WindowInvalid(windowState, k))
        {
            windowState -= arr[left];
            left++;
        }
        
        // Count: all subarrays ending at right
        count += (right - left + 1);
    }
    
    return count;
}
```

### Key Insight: Counting Subarrays

For window `[left, right]`:
- Subarrays ending at `right`: `[left..right]`, `[left+1..right]`, ..., `[right..right]`
- Count: `right - left + 1`

**Example:**
```
Window: [1, 2, 3]
         ↑     ↑
       left  right

Subarrays ending at right:
[1, 2, 3] ← starts at left
[2, 3]    ← starts at left+1
[3]       ← starts at right

Count: 3 = right - left + 1
```

---

### Example 1: Subarrays with K Different Integers

**Problem:** Count subarrays with exactly k distinct integers.

**Trick:** `exactly(k) = atMost(k) - atMost(k-1)`

```csharp
public int SubarraysWithKDistinct(int[] arr, int k)
{
    return AtMostKDistinct(arr, k) - AtMostKDistinct(arr, k - 1);
}

private int AtMostKDistinct(int[] arr, int k)
{
    var freq = new Dictionary<int, int>();
    int left = 0;
    int count = 0;
    
    for (int right = 0; right < arr.Length; right++)
    {
        // Add arr[right]
        if (!freq.ContainsKey(arr[right]))
            freq[arr[right]] = 0;
        freq[arr[right]]++;
        
        // Shrink while > k distinct
        while (freq.Count > k)
        {
            freq[arr[left]]--;
            if (freq[arr[left]] == 0)
                freq.Remove(arr[left]);
            left++;
        }
        
        // Count subarrays ending at right
        count += right - left + 1;
    }
    
    return count;
}
```

**Why the trick works:**
- `atMost(k)`: includes subarrays with 1, 2, ..., k distinct
- `atMost(k-1)`: includes subarrays with 1, 2, ..., k-1 distinct
- Difference: subarrays with EXACTLY k distinct

---

### Example 2: Count Subarrays with Product < K

**Problem:** Count subarrays where product < k.

```csharp
public int NumSubarrayProductLessThanK(int[] arr, int k)
{
    if (k <= 1) return 0;
    
    int left = 0;
    int product = 1;
    int count = 0;
    
    for (int right = 0; right < arr.Length; right++)
    {
        product *= arr[right];
        
        while (product >= k)
        {
            product /= arr[left];
            left++;
        }
        
        count += right - left + 1;
    }
    
    return count;
}
```

**Trace:**
```
arr = [10, 5, 2, 6], k = 100

right=0: [10], product=10 ✓ count += 1
right=1: [10,5], product=50 ✓ count += 2 (subarrays: [10,5], [5])
right=2: [10,5,2], product=100 ✗ shrink to [5,2], product=10 ✓ count += 2
right=3: [5,2,6], product=60 ✓ count += 3

Total: 8
```

---

## 5. Advanced Patterns

### Pattern 1: Maximum in Sliding Window (Using Deque)

**Problem:** Find maximum in each window of size k.

**Challenge:** Need O(1) max query after sliding.

**Solution:** Monotonic decreasing deque.

```csharp
public int[] MaxSlidingWindow(int[] arr, int k)
{
    var result = new List<int>();
    var deque = new LinkedList<int>();  // Stores indices
    
    for (int i = 0; i < arr.Length; i++)
    {
        // Remove elements outside window
        if (deque.Count > 0 && deque.First.Value <= i - k)
            deque.RemoveFirst();
        
        // Maintain decreasing order
        // Remove smaller elements (they'll never be max)
        while (deque.Count > 0 && arr[deque.Last.Value] < arr[i])
            deque.RemoveLast();
        
        deque.AddLast(i);
        
        // Add to result if window is full
        if (i >= k - 1)
            result.Add(arr[deque.First.Value]);
    }
    
    return result.ToArray();
}
```

**Why it works:**
- Deque front = maximum in window
- Remove elements that can't be future maximums
- Maintains O(1) max query

---

### Pattern 2: Longest Repeating Character Replacement

**Problem:** Longest substring with same letter after replacing ≤ k characters.

**Insight:** If window length - max frequency ≤ k, we can make all same.

```csharp
public int CharacterReplacement(string s, int k)
{
    var freq = new int[26];
    int left = 0;
    int maxFreq = 0;
    int maxLength = 0;
    
    for (int right = 0; right < s.Length; right++)
    {
        freq[s[right] - 'A']++;
        maxFreq = Math.Max(maxFreq, freq[s[right] - 'A']);
        
        // If replacements needed > k, shrink
        while (right - left + 1 - maxFreq > k)
        {
            freq[s[left] - 'A']--;
            left++;
        }
        
        maxLength = Math.Max(maxLength, right - left + 1);
    }
    
    return maxLength;
}
```

**Key insight:** `windowLength - maxFreq` = characters to replace.

---

### Pattern 3: Substring with Concatenation of All Words

**Problem:** Find all starting indices where substring is concatenation of given words.

**Approach:** Fixed window with word-level sliding.

```csharp
public IList<int> FindSubstring(string s, string[] words)
{
    var result = new List<int>();
    if (words.Length == 0) return result;
    
    int wordLen = words[0].Length;
    int wordCount = words.Length;
    int windowLen = wordLen * wordCount;
    
    // Frequency of words
    var wordFreq = new Dictionary<string, int>();
    foreach (var word in words)
    {
        if (!wordFreq.ContainsKey(word))
            wordFreq[word] = 0;
        wordFreq[word]++;
    }
    
    // Try starting from each position 0..(wordLen-1)
    for (int offset = 0; offset < wordLen; offset++)
    {
        var windowFreq = new Dictionary<string, int>();
        int left = offset;
        int formed = 0;
        
        for (int right = offset; right <= s.Length - wordLen; right += wordLen)
        {
            string word = s.Substring(right, wordLen);
            
            if (!wordFreq.ContainsKey(word))
            {
                // Invalid word, reset
                windowFreq.Clear();
                formed = 0;
                left = right + wordLen;
                continue;
            }
            
            // Add word
            if (!windowFreq.ContainsKey(word))
                windowFreq[word] = 0;
            windowFreq[word]++;
            
            if (windowFreq[word] == wordFreq[word])
                formed++;
            
            // Shrink if window too large
            while (right - left + wordLen > windowLen)
            {
                string leftWord = s.Substring(left, wordLen);
                if (windowFreq[leftWord] == wordFreq[leftWord])
                    formed--;
                windowFreq[leftWord]--;
                left += wordLen;
            }
            
            // Check if valid
            if (formed == wordFreq.Count)
                result.Add(left);
        }
    }
    
    return result;
}
```

---

## Pattern Selection Guide

### Decision Tree

```
Is window size fixed (given k)?
├─ YES → Use FIXED WINDOW template
│  └─ Examples: max sum size k, avg of k elements
│
└─ NO → Is window size variable?
   ├─ Finding LONGEST?
   │  ├─ YES → Use LONGEST template
   │  │  └─ Contract while INVALID
   │  │     └─ Update result AFTER contracting
   │  │
   │  └─ Examples: longest substring k distinct,
   │                longest subarray sum ≤ k
   │
   ├─ Finding SHORTEST?
   │  ├─ YES → Use SHORTEST template
   │  │  └─ Contract while VALID
   │  │     └─ Update result DURING contracting
   │  │
   │  └─ Examples: min window substring,
   │                min subarray sum ≥ target
   │
   └─ Counting subarrays?
      ├─ YES → Use COUNT template
      │  └─ Add (right - left + 1) each iteration
      │
      └─ Examples: count subarrays product < k,
                   subarrays with k distinct
```

---

## Summary Table

| Pattern | When to Use | Update Result | Key Metric |
|---------|------------|---------------|------------|
| **Fixed** | Size k given | After sliding | Always k elements |
| **Longest** | "Longest", "at most k" | After shrinking | `right - left + 1` |
| **Shortest** | "Shortest", "at least k" | During shrinking | `right - left + 1` |
| **Count** | Count subarrays | Every iteration | `right - left + 1` |

---

## Quick Reference

### Template Skeleton
```csharp
// FIXED
for (int i = k; i < n; i++)
    update(arr[i], arr[i-k]);

// LONGEST
while (invalid) left++;
result = max(result, right - left + 1);

// SHORTEST
while (valid) {
    result = min(result, right - left + 1);
    left++;
}

// COUNT
count += (right - left + 1);
```

---

You now have all the templates! Next: **Practice problems** to internalize these patterns.
