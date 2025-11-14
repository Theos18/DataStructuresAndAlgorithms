# Two Pointers: Complete Variations Guide

> "Once you understand the principles, you can adapt to any situation." - Bruce Lee

Now that you understand WHY two pointers work, let's explore EVERY variation systematically.

---

## 📋 Table of Contents

1. [Opposite Direction (Convergence)](#type-1-opposite-direction)
2. [Same Direction (Fast/Slow)](#type-2-same-direction)
3. [Multiple Arrays](#type-3-multiple-arrays)
4. [Partitioning (Dutch National Flag)](#type-4-partitioning)
5. [Advanced Patterns](#type-5-advanced-patterns)

---

## Type 1: Opposite Direction (Convergence)

### The Core Idea

```
Two pointers start at opposite ends, move toward each other.

[————————————————————————]
 ↑                      ↑
left                 right

Decision at each step eliminates one end.
```

### When to Use

**Checklist:**
- ✓ Array is sorted (or has useful ordering)
- ✓ Looking for pairs/combinations
- ✓ Need to consider extremes
- ✓ Comparison determines which pointer moves

### The Invariant

**What we maintain:**
- Elements before `left` have been eliminated (too small/invalid)
- Elements after `right` have been eliminated (too large/invalid)
- Solution (if exists) must be in range [left, right]

### Template Pattern

```csharp
int left = 0, right = n - 1;

while (left < right)
{
    // Evaluate current state
    int currentValue = SomeFunction(arr[left], arr[right]);
    
    if (currentValue == target)
    {
        // Found solution
        return;
    }
    else if (currentValue < target)
    {
        left++;   // Need larger value
    }
    else
    {
        right--;  // Need smaller value
    }
}
```

### Classic Problems

#### 1.1: Two Sum (Sorted Array)

**Problem:** Find indices where arr[i] + arr[j] = target

**Intuition:**
```
Why opposite direction works:
- left = smallest, right = largest
- If sum too small → need larger sum → move left right
- If sum too large → need smaller sum → move right left
- Each move eliminates one element permanently
```

**Code:**
```csharp
public int[] TwoSum(int[] arr, int target)
{
    int left = 0, right = arr.Length - 1;
    
    while (left < right)
    {
        int sum = arr[left] + arr[right];
        
        if (sum == target)
            return new int[] { left, right };
        else if (sum < target)
            left++;   // arr[left] too small for arr[right]
        else
            right--;  // arr[right] too large for arr[left]
    }
    
    return new int[] { -1, -1 };
}
```

**Why It Works:**
- When sum < target: arr[left] + arr[right] < target
  - arr[left] + arr[right-1] definitely < target (smaller)
  - arr[left] + arr[right-2] definitely < target
  - → arr[left] can't pair with anything ≤ right
  - → Eliminate arr[left], move left right

**Time:** O(n), **Space:** O(1)

---

#### 1.2: Three Sum

**Problem:** Find all triplets where arr[i] + arr[j] + arr[k] = 0

**Intuition:**
```
Build on Two Sum!
- Fix first element: arr[i]
- Now find two elements that sum to -arr[i]
- That's Two Sum problem on remaining array!
- Repeat for each i
```

**Code:**
```csharp
public List<List<int>> ThreeSum(int[] arr)
{
    Array.Sort(arr);  // MUST sort first!
    List<List<int>> result = new List<List<int>>();
    
    for (int i = 0; i < arr.Length - 2; i++)
    {
        // Skip duplicates for first element
        if (i > 0 && arr[i] == arr[i - 1])
            continue;
        
        // Two Sum on remaining array
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

**Time:** O(n²), **Space:** O(1) excluding output

**Key Insight:** Three Sum = Loop + Two Sum

---

#### 1.3: Container With Most Water

**Problem:** Given heights, find two lines that form container with maximum area

**Intuition:**
```
Area = width × min(height[left], height[right])

Start with maximum width (widest container).
To improve area, we need TALLER lines.

Which pointer to move?
- Move the SHORTER line!
- Why? It's the bottleneck
- Moving taller line can only maintain or decrease height
- Moving shorter line gives chance of finding taller line
```

**Visual:**
```
Heights: [1, 8, 6, 2, 5, 4, 8, 3, 7]
          ↑                       ↑
         left                  right

Area = min(1, 7) × 8 = 1 × 8 = 8

Which to move? LEFT (shorter)
Why? 
- Moving right can't help (1 is bottleneck)
- Moving left might find taller line
```

**Code:**
```csharp
public int MaxArea(int[] heights)
{
    int left = 0, right = heights.Length - 1;
    int maxArea = 0;
    
    while (left < right)
    {
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

**Why It Works:**
- We try widest container first
- Each move reduces width by 1
- We only move the limiting factor (shorter line)
- This guarantees we explore all potentially optimal configurations

**Time:** O(n), **Space:** O(1)

---

#### 1.4: Trapping Rain Water

**Problem:** Calculate water trapped between bars

**Intuition:**
```
Water at position i = min(maxLeft, maxRight) - height[i]

Key insight: Use two pointers to track maxLeft and maxRight!

If heights[left] < heights[right]:
  - Process left side (it's the bottleneck)
  - We KNOW maxRight ≥ heights[right] (right is there!)
  - Water at left = maxLeft - heights[left]

Similar logic for right side.
```

**Code:**
```csharp
public int TrapRainWater(int[] heights)
{
    int left = 0, right = heights.Length - 1;
    int leftMax = 0, rightMax = 0;
    int water = 0;
    
    while (left < right)
    {
        if (heights[left] < heights[right])
        {
            // Process left (it's the bottleneck)
            if (heights[left] >= leftMax)
                leftMax = heights[left];  // No water here
            else
                water += leftMax - heights[left];  // Trap water
            
            left++;
        }
        else
        {
            // Process right (it's the bottleneck)
            if (heights[right] >= rightMax)
                rightMax = heights[right];  // No water here
            else
                water += rightMax - heights[right];  // Trap water
            
            right--;
        }
    }
    
    return water;
}
```

**Time:** O(n), **Space:** O(1)

---

## Type 2: Same Direction (Fast/Slow)

### The Core Idea

```
Two pointers move in same direction at different speeds.

[————————————————————————]
 ↑        ↑
slow    fast

Slow processes elements.
Fast scans ahead.
```

### When to Use

**Checklist:**
- ✓ In-place modification required
- ✓ Partitioning/filtering elements
- ✓ Cycle detection
- ✓ Distance-based problems

### The Invariant

**What we maintain:**
- Elements before `slow` are "processed" (satisfy condition)
- Elements between `slow` and `fast` are "unprocessed" or "rejected"
- `fast` scans ahead looking for valid elements

### Template Pattern

```csharp
int slow = 0, fast = 0;

while (fast < n)
{
    if (ShouldInclude(arr[fast]))
    {
        arr[slow] = arr[fast];  // Include this element
        slow++;
    }
    fast++;
}

// Elements [0, slow) are the result
return slow;
```

### Classic Problems

#### 2.1: Remove Duplicates from Sorted Array

**Problem:** Remove duplicates in-place, return new length

**Intuition:**
```
slow = position for next unique element
fast = scans through array

When arr[fast] != arr[slow-1]:
  - Found a new unique element!
  - Place it at arr[slow]
  - Move slow forward
```

**Code:**
```csharp
public int RemoveDuplicates(int[] arr)
{
    if (arr.Length == 0) return 0;
    
    int slow = 1;  // Position for next unique
    
    for (int fast = 1; fast < arr.Length; fast++)
    {
        if (arr[fast] != arr[fast - 1])
        {
            arr[slow] = arr[fast];
            slow++;
        }
    }
    
    return slow;
}
```

**Why It Works:**
- slow tracks "end of unique elements"
- fast finds next unique element
- When found, copy to slow position

**Time:** O(n), **Space:** O(1)

---

#### 2.2: Move Zeros to End

**Problem:** Move all zeros to end, maintain order of non-zeros

**Intuition:**
```
slow = position for next non-zero
fast = scans for non-zeros

When arr[fast] != 0:
  - Swap arr[slow] and arr[fast]
  - This places non-zero at slow position
  - Moves zero toward end
```

**Code:**
```csharp
public void MoveZeros(int[] arr)
{
    int slow = 0;  // Position for next non-zero
    
    for (int fast = 0; fast < arr.Length; fast++)
    {
        if (arr[fast] != 0)
        {
            // Swap
            int temp = arr[slow];
            arr[slow] = arr[fast];
            arr[fast] = temp;
            
            slow++;
        }
    }
}
```

**Time:** O(n), **Space:** O(1)

---

#### 2.3: Linked List Cycle Detection (Floyd's Algorithm)

**Problem:** Detect if linked list has cycle

**Intuition:**
```
Slow moves 1 step at a time.
Fast moves 2 steps at a time.

If there's a cycle:
- Fast will eventually catch slow (like runners on circular track)
- They meet inside the cycle

If no cycle:
- Fast reaches end (null)
```

**Code:**
```csharp
public bool HasCycle(ListNode head)
{
    if (head == null) return false;
    
    ListNode slow = head;
    ListNode fast = head;
    
    while (fast != null && fast.next != null)
    {
        slow = slow.next;       // Move 1 step
        fast = fast.next.next;  // Move 2 steps
        
        if (slow == fast)
            return true;  // Cycle detected!
    }
    
    return false;  // Reached end, no cycle
}
```

**Why It Works:**
- Distance between slow and fast decreases by 1 each step (in cycle)
- Eventually distance becomes 0 → they meet!

**Time:** O(n), **Space:** O(1)

---

## Type 3: Multiple Arrays

### The Core Idea

```
One pointer per array, coordinate movement.

Array1: [————————————]
         ↑
        ptr1

Array2: [————————————]
         ↑
        ptr2
```

### When to Use

**Checklist:**
- ✓ Merging sorted sequences
- ✓ Finding intersection/union
- ✓ Comparing multiple sequences
- ✓ Each array has independent traversal

### Classic Problems

#### 3.1: Merge Two Sorted Arrays

**Problem:** Merge two sorted arrays into one sorted array

**Intuition:**
```
Compare elements at both pointers.
Take smaller element, move that pointer.
Repeat until one array exhausted.
Copy remaining elements from other array.
```

**Code:**
```csharp
public int[] MergeSorted(int[] arr1, int[] arr2)
{
    int[] result = new int[arr1.Length + arr2.Length];
    int i = 0, j = 0, k = 0;
    
    while (i < arr1.Length && j < arr2.Length)
    {
        if (arr1[i] <= arr2[j])
        {
            result[k++] = arr1[i++];
        }
        else
        {
            result[k++] = arr2[j++];
        }
    }
    
    // Copy remaining elements
    while (i < arr1.Length)
        result[k++] = arr1[i++];
    
    while (j < arr2.Length)
        result[k++] = arr2[j++];
    
    return result;
}
```

**Time:** O(m + n), **Space:** O(m + n)

---

#### 3.2: Intersection of Two Sorted Arrays

**Problem:** Find common elements in both arrays

**Intuition:**
```
If arr1[i] == arr2[j]:
  - Found intersection element
  - Move both pointers

If arr1[i] < arr2[j]:
  - arr1[i] too small, can't match anything ≥ arr2[j]
  - Move i forward

If arr1[i] > arr2[j]:
  - arr2[j] too small, can't match anything ≥ arr1[i]
  - Move j forward
```

**Code:**
```csharp
public List<int> Intersection(int[] arr1, int[] arr2)
{
    List<int> result = new List<int>();
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
        {
            i++;  // arr1[i] too small
        }
        else
        {
            j++;  // arr2[j] too small
        }
    }
    
    return result;
}
```

**Time:** O(m + n), **Space:** O(1) excluding output

---

## Type 4: Partitioning (Dutch National Flag)

### The Core Idea

```
Multiple pointers divide array into regions.

[processed | unknown | processed]
 ←————————  ↑  ————————→
  region1   mid  region2
```

### When to Use

**Checklist:**
- ✓ Sorting with limited distinct values
- ✓ Partitioning by multiple criteria
- ✓ Three-way split needed

### Classic Problem: Sort Colors (0s, 1s, 2s)

**Problem:** Sort array with only 0s, 1s, and 2s in-place

**Intuition:**
```
Use three pointers:
- low: boundary of 0s (everything before low is 0)
- mid: current element being processed
- high: boundary of 2s (everything after high is 2)

Goal: [0s | 1s | 2s]
       ↑   ↑   ↑
      low mid high
```

**Code:**
```csharp
public void SortColors(int[] arr)
{
    int low = 0, mid = 0, high = arr.Length - 1;
    
    while (mid <= high)
    {
        if (arr[mid] == 0)
        {
            // Swap with low, this 0 goes to beginning
            Swap(arr, low, mid);
            low++;
            mid++;
        }
        else if (arr[mid] == 1)
        {
            // 1 is in correct region, just move mid
            mid++;
        }
        else // arr[mid] == 2
        {
            // Swap with high, this 2 goes to end
            Swap(arr, mid, high);
            high--;
            // Don't move mid (need to check swapped element)
        }
    }
}
```

**Why It Works:**
- Invariant maintained:
  - [0, low): all 0s
  - [low, mid): all 1s
  - (high, n-1]: all 2s
  - [mid, high]: unknown

**Time:** O(n), **Space:** O(1)

---

## 🎯 Pattern Recognition Framework

### Decision Tree: Which Type to Use?

```
Question 1: How many sequences?
├─ One array
│  ├─ Question 2: What's the goal?
│  │  ├─ Find pairs/combinations → Type 1 (Opposite Direction)
│  │  ├─ In-place modification → Type 2 (Same Direction)
│  │  └─ Partition into regions → Type 4 (Partitioning)
│  │
│  └─ Question 3: Is it sorted?
│     ├─ Yes → Type 1 likely
│     └─ No → Type 2 or 4 likely
│
└─ Multiple arrays
   └─ Type 3 (Multiple Arrays)
```

### The "Why" Checklist

Before applying two pointers, ask:

**1. What am I trying to eliminate/skip?**
- If nothing → Two pointers won't help

**2. Can I safely skip based on current pointers?**
- If no → Two pointers won't work correctly

**3. How do pointers move?**
- Toward each other → Type 1
- Same direction → Type 2
- Independent → Type 3
- Creating regions → Type 4

**4. What's my invariant?**
- Can I clearly state what property is maintained?
- If unclear → Rethink approach

---

## 🧠 Building Deep Intuition

### Exercise: Derive From Scratch

For each problem type, practice:

1. **Start with brute force**
   - What's the O(n²) solution?
   - What work is redundant?

2. **Identify elimination opportunity**
   - What can I skip?
   - Based on what property?

3. **Design pointer movement**
   - Where do pointers start?
   - When/how do they move?
   - What does each movement eliminate?

4. **Prove correctness**
   - What's the invariant?
   - Why does it guarantee correct answer?

### Practice Problems for Each Type

**Type 1 (Opposite Direction):**
- Two Sum, Three Sum, Four Sum
- Container With Most Water
- Trapping Rain Water
- Valid Palindrome
- Two Sum II (closest sum)

**Type 2 (Same Direction):**
- Remove Duplicates
- Move Zeros
- Remove Element
- Partition Array
- Linked List Cycle

**Type 3 (Multiple Arrays):**
- Merge Sorted Arrays
- Intersection of Arrays
- Median of Two Sorted Arrays
- Merge K Sorted Lists

**Type 4 (Partitioning):**
- Sort Colors
- Dutch National Flag
- Partition Array by Pivot
- Move Zeros (variation)

---

## 🚀 Next Steps

You now know ALL major two-pointer variations!

**Next:**
1. Practice problems in `03_TwoPointers_Problems.cs`
2. For each problem, IDENTIFY the type BEFORE coding
3. Ask yourself: "What am I eliminating and why?"

Remember: **Type matters less than understanding WHY!**

Let's practice! 💪
