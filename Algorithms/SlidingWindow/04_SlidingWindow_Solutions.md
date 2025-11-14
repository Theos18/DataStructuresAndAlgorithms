# Sliding Window: Complete Solutions Guide

> "Understanding is deeper than knowledge." - Albert Einstein

This guide explains the THINKING PROCESS behind each solution, not just the code.

---

## LEVEL 1: FIXED WINDOW

### Problem 1.1: Maximum Sum Subarray Size K

**Solution:**
```csharp
public static int MaxSumSubarrayOfSizeK(int[] arr, int k)
{
    int windowSum = 0;
    
    // Calculate first window
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

**Complexity:** O(n), Space: O(1)

---

### Problem 1.3: Max Sliding Window (Deque)

**Key Insight:** Maintain monotonic decreasing deque.

**Solution:**
```csharp
public static int[] MaxSlidingWindow(int[] arr, int k)
{
    var result = new List<int>();
    var deque = new LinkedList<int>();
    
    for (int i = 0; i < arr.Length; i++)
    {
        // Remove indices outside window
        if (deque.Count > 0 && deque.First.Value <= i - k)
            deque.RemoveFirst();
        
        // Maintain decreasing order
        while (deque.Count > 0 && arr[deque.Last.Value] < arr[i])
            deque.RemoveLast();
        
        deque.AddLast(i);
        
        if (i >= k - 1)
            result.Add(arr[deque.First.Value]);
    }
    
    return result.ToArray();
}
```

**Why:** Front of deque = max in window. Remove smaller elements.

---

## LEVEL 2: VARIABLE LONGEST

### Problem 2.1: Longest Substring K Distinct

**Solution:**
```csharp
public static int LongestSubstringKDistinct(string s, int k)
{
    var freq = new Dictionary<char, int>();
    int left = 0, maxLength = 0;
    
    for (int right = 0; right < s.Length; right++)
    {
        if (!freq.ContainsKey(s[right]))
            freq[s[right]] = 0;
        freq[s[right]]++;
        
        while (freq.Count > k)
        {
            freq[s[left]]--;
            if (freq[s[left]] == 0)
                freq.Remove(s[left]);
            left++;
        }
        
        maxLength = Math.Max(maxLength, right - left + 1);
    }
    
    return maxLength;
}
```

**Pattern:** Expand, shrink when invalid, update max.

---

### Problem 2.4: Character Replacement

**Key Formula:** `windowLength - maxFrequency ≤ k`

**Solution:**
```csharp
public static int CharacterReplacement(string s, int k)
{
    int[] freq = new int[26];
    int left = 0, maxFreq = 0, maxLength = 0;
    
    for (int right = 0; right < s.Length; right++)
    {
        freq[s[right] - 'A']++;
        maxFreq = Math.Max(maxFreq, freq[s[right] - 'A']);
        
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

---

## LEVEL 3: VARIABLE SHORTEST

### Problem 3.1: Minimum Size Subarray Sum

**Key Difference:** Update DURING shrinking.

**Solution:**
```csharp
public static int MinSubArrayLen(int target, int[] arr)
{
    int left = 0, sum = 0;
    int minLength = int.MaxValue;
    
    for (int right = 0; right < arr.Length; right++)
    {
        sum += arr[right];
        
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

### Problem 3.2: Minimum Window Substring

**Complex but systematic:**

**Solution:**
```csharp
public static string MinWindow(string s, string t)
{
    var required = new Dictionary<char, int>();
    foreach (char c in t)
    {
        if (!required.ContainsKey(c))
            required[c] = 0;
        required[c]++;
    }
    
    var windowFreq = new Dictionary<char, int>();
    int left = 0, formed = 0;
    int minLength = int.MaxValue, minLeft = 0;
    
    for (int right = 0; right < s.Length; right++)
    {
        char c = s[right];
        if (!windowFreq.ContainsKey(c))
            windowFreq[c] = 0;
        windowFreq[c]++;
        
        if (required.ContainsKey(c) && windowFreq[c] == required[c])
            formed++;
        
        while (formed == required.Count)
        {
            if (right - left + 1 < minLength)
            {
                minLength = right - left + 1;
                minLeft = left;
            }
            
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

---

## LEVEL 4: COUNTING

### Problem 4.1: Count Product < K

**Key:** `count += right - left + 1`

**Solution:**
```csharp
public static int NumSubarrayProductLessThanK(int[] arr, int k)
{
    if (k <= 1) return 0;
    
    int left = 0, product = 1, count = 0;
    
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

---

### Problem 4.2: K Distinct (Exact)

**Trick:** `exactly(k) = atMost(k) - atMost(k-1)`

**Solution:**
```csharp
public static int SubarraysWithKDistinct(int[] arr, int k)
{
    return AtMostKDistinct(arr, k) - AtMostKDistinct(arr, k - 1);
}

private static int AtMostKDistinct(int[] arr, int k)
{
    var freq = new Dictionary<int, int>();
    int left = 0, count = 0;
    
    for (int right = 0; right < arr.Length; right++)
    {
        if (!freq.ContainsKey(arr[right]))
            freq[arr[right]] = 0;
        freq[arr[right]]++;
        
        while (freq.Count > k)
        {
            freq[arr[left]]--;
            if (freq[arr[left]] == 0)
                freq.Remove(arr[left]);
            left++;
        }
        
        count += right - left + 1;
    }
    
    return count;
}
```

---

## Pattern Recognition Summary

| Problem Type | Shrink Condition | Update Timing | Key Metric |
|-------------|------------------|---------------|------------|
| **Fixed k** | After k elements | After slide | Always k |
| **Longest** | While invalid | After shrinking | max length |
| **Shortest** | While valid | During shrinking | min length |
| **Count** | While invalid | Every iteration | sum of lengths |

---

## Meta-Learning: The Framework

After solving these problems, you should recognize:

### 1. Fixed Window Pattern
- **Recognize:** "size k", "k consecutive"
- **Template:** Calculate first, slide by removing/adding
- **Complexity:** O(n)

### 2. Longest Pattern
- **Recognize:** "longest", "maximum", "at most k"
- **Template:** Expand always, shrink when invalid
- **Update:** After shrinking (want largest valid)

### 3. Shortest Pattern
- **Recognize:** "shortest", "minimum", "at least k"
- **Template:** Expand always, shrink while valid
- **Update:** During shrinking (want smallest valid)

### 4. Counting Pattern
- **Recognize:** "count subarrays", "how many"
- **Template:** Expand always, shrink when invalid
- **Count:** `right - left + 1` (subarrays ending at right)

---

## Advanced Insights

### Why Sliding Window Works

**Mathematical Invariant:**
- For contiguous problems, we can maintain state incrementally
- Adding/removing one element updates result in O(1)
- Total complexity: O(n) instead of O(n²)

### When It Doesn't Apply

❌ **Median of subarray** - requires sorting  
❌ **Non-contiguous** - elements not in sequence  
❌ **Complex dependencies** - can't update incrementally

---

You now have complete solutions with deep understanding. Practice recognizing patterns in new problems!
