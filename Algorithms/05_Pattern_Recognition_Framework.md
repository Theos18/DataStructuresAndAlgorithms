# Pattern Recognition Framework: Two Pointers vs Sliding Window

> "The essence of mathematics is not to make simple things complicated, but to make complicated things simple." - S. Gudder

**Purpose:** This framework helps you RECOGNIZE which technique to use when you see a new problem.

---

## The Core Question

When you see an array/string problem, ask:

### Question 1: Is it about CONTIGUOUS elements?

```
YES (subarray/substring) → Consider SLIDING WINDOW
NO (subsequence/any pair) → Consider TWO POINTERS
```

---

## Complete Decision Tree

```
┌─────────────────────────────────────┐
│  New Array/String Problem           │
└─────────────────┬───────────────────┘
                  │
                  ▼
        ┌─────────────────────┐
        │ Contiguous elements? │
        │ (subarray/substring) │
        └──────┬─────────┬─────┘
               │         │
            YES│         │NO
               │         │
               ▼         ▼
    ┌──────────────┐  ┌────────────────┐
    │ SLIDING      │  │ TWO POINTERS   │
    │ WINDOW       │  │ or OTHER       │
    └──────┬───────┘  └────────┬───────┘
           │                    │
           ▼                    ▼
    ┌──────────────────┐  ┌──────────────────┐
    │ Window size      │  │ Array sorted?    │
    │ fixed or         │  │                  │
    │ variable?        │  │                  │
    └─────┬───────┬────┘  └─────┬──────┬─────┘
          │       │             │      │
       FIXED│  VAR│          YES│      │NO
          │       │             │      │
          ▼       ▼             ▼      ▼
    ┌─────────┐┌────────┐  ┌────────────────┐
    │ Fixed   ││Variable│  │ Opposite or    │
    │ Window  ││Window  │  │ Same Direction?│
    │ Pattern ││Pattern │  │                │
    └─────────┘└───┬────┘  └───┬───────┬────┘
                   │           │       │
                   ▼           ▼       ▼
            ┌──────────────┐┌──────┐┌──────┐
            │ Longest?     ││Sorted││Modify│
            │ Shortest?    ││data  ││Array │
            │ Count?       ││      ││      │
            └──────────────┘└──────┘└──────┘
```

---

## PART 1: Identifying Sliding Window

### Red Flags for Sliding Window

✅ **Keywords:**
- "subarray" (contiguous)
- "substring" (contiguous)
- "consecutive elements"
- "window of size k"

✅ **Questions:**
- "longest subarray with..."
- "shortest substring containing..."
- "maximum sum of k elements"
- "count subarrays where..."

✅ **Characteristics:**
- Elements must be **in a row**
- You can update result **incrementally**
- Currently O(n²) nested loops

### NOT Sliding Window

❌ **Keywords:**
- "subsequence" (can skip elements)
- "any pair/triplet" (not necessarily contiguous)

❌ **Problems:**
- Two Sum (any pair) → Two Pointers
- Median of subarray → Can't update incrementally
- Non-contiguous elements

---

## PART 2: Identifying Two Pointers

### Red Flags for Two Pointers

✅ **Keywords:**
- "sorted array"
- "pair/triplet" summing to target
- "remove duplicates in-place"
- "partition array"
- "palindrome"

✅ **Questions:**
- "Find two numbers that sum to..."
- "Move zeros to end"
- "Check if palindrome"
- "Merge two sorted arrays"

✅ **Characteristics:**
- Array is **sorted** (or can be sorted)
- Need to **eliminate candidates**
- Modifying array **in-place**
- Comparing from **both ends**

---

## PART 3: Sub-Patterns

### Sliding Window Sub-Patterns

#### 1. Fixed Window
**Recognize:**
- "size k" explicitly given
- "every k consecutive elements"
- "k-length subarray"

**Template:**
```csharp
for (int i = k; i < n; i++)
    update(arr[i], arr[i-k]);
```

**Examples:**
- Max sum of size k
- Average of k elements
- Max in each window of size k

---

#### 2. Variable Window - Longest
**Recognize:**
- "**longest**" or "**maximum length**"
- "**at most** k distinct/zeros/etc."

**Template:**
```csharp
while (invalid)
    shrink();
maxLength = max(maxLength, right - left + 1);
```

**Examples:**
- Longest substring with ≤ k distinct
- Longest subarray with sum ≤ target
- Max consecutive 1s with k flips

---

#### 3. Variable Window - Shortest
**Recognize:**
- "**shortest**" or "**minimum length**"
- "**at least** k" or "**contains all**"

**Template:**
```csharp
while (valid) {
    minLength = min(minLength, right - left + 1);
    shrink();
}
```

**Examples:**
- Minimum window substring
- Shortest subarray with sum ≥ target

---

#### 4. Variable Window - Count
**Recognize:**
- "**count** number of subarrays"
- "**how many** subarrays"

**Template:**
```csharp
while (invalid)
    shrink();
count += (right - left + 1);
```

**Examples:**
- Count subarrays with product < k
- Count subarrays with k distinct

---

### Two Pointers Sub-Patterns

#### 1. Opposite Direction
**Recognize:**
- **Sorted** array
- Finding **pair** that sums to target
- **Palindrome** checking
- **Container** problems

**Template:**
```csharp
left = 0, right = n - 1;
while (left < right) {
    if (condition)
        // move appropriate pointer
}
```

**Examples:**
- Two Sum (sorted)
- Container with most water
- Valid palindrome
- Trapping rain water

---

#### 2. Same Direction (Fast/Slow)
**Recognize:**
- **In-place** modification
- "remove duplicates"
- "move zeros"
- "partition array"

**Template:**
```csharp
slow = 0;
for (int fast = 0; fast < n; fast++) {
    if (condition)
        arr[slow++] = arr[fast];
}
```

**Examples:**
- Remove duplicates
- Move zeros to end
- Partition array
- Sort colors (3 pointers)

---

#### 3. Multiple Arrays
**Recognize:**
- **Two or more** sorted arrays
- **Merge** operations
- Finding **common** elements

**Template:**
```csharp
int i = 0, j = 0;
while (i < n && j < m) {
    if (arr1[i] < arr2[j])
        i++;
    else if (arr1[i] > arr2[j])
        j++;
    else {
        // found match
        i++; j++;
    }
}
```

**Examples:**
- Merge sorted arrays
- Intersection of arrays
- Merge intervals

---

## PART 4: Quick Reference Table

| Feature | Two Pointers | Sliding Window |
|---------|-------------|----------------|
| **Elements** | Any positions | Contiguous only |
| **Sorted?** | Often yes | Not required |
| **Window size** | N/A | Fixed or variable |
| **Complexity** | O(n) or O(n²) | O(n) |
| **Use when** | Pairs, sorting | Subarrays |

---

## PART 5: Practice Recognition

Read each problem and IDENTIFY the pattern BEFORE looking at the answer.

### Problem A
> "Find longest substring with at most 2 distinct characters."

<details>
<summary>Answer</summary>

**Pattern:** Sliding Window - Variable Longest  
**Why:** "Longest" + "substring" (contiguous) + "at most k"  
**Template:** Expand, shrink when > 2 distinct, track max
</details>

---

### Problem B
> "Given sorted array, find pair summing to target."

<details>
<summary>Answer</summary>

**Pattern:** Two Pointers - Opposite Direction  
**Why:** "Sorted" + "pair" + target condition  
**Template:** left=0, right=n-1, compare sum
</details>

---

### Problem C
> "Count subarrays where product < k."

<details>
<summary>Answer</summary>

**Pattern:** Sliding Window - Variable Count  
**Why:** "Count subarrays" (contiguous) + condition  
**Template:** Expand, shrink when invalid, count += right - left + 1
</details>

---

### Problem D
> "Remove duplicates from sorted array in-place."

<details>
<summary>Answer</summary>

**Pattern:** Two Pointers - Same Direction  
**Why:** "In-place" + "sorted" + modification  
**Template:** slow/fast pointers, slow tracks unique position
</details>

---

### Problem E
> "Find maximum sum of any 5 consecutive elements."

<details>
<summary>Answer</summary>

**Pattern:** Sliding Window - Fixed  
**Why:** "5 consecutive" = fixed size window  
**Template:** Calculate first window, slide by removing/adding
</details>

---

### Problem F
> "Minimum window in s containing all characters from t."

<details>
<summary>Answer</summary>

**Pattern:** Sliding Window - Variable Shortest  
**Why:** "Minimum window" + "containing all" (at least)  
**Template:** Expand until valid, shrink while valid, track min
</details>

---

## PART 6: The Mental Checklist

When you see a new problem, ask these questions IN ORDER:

### Step 1: Contiguous?
- [ ] Does it involve subarray/substring?
- [ ] Must elements be consecutive?

**If YES → Consider Sliding Window**  
**If NO → Consider Two Pointers**

### Step 2: Is Array Sorted? (for Two Pointers)
- [ ] Is array sorted?
- [ ] Can I sort it?

**If YES → Likely Opposite Direction**  
**If NO → Check if in-place modification**

### Step 3: What's the Goal? (for Sliding Window)
- [ ] "longest"? → Variable Longest
- [ ] "shortest"? → Variable Shortest
- [ ] "count"? → Variable Count
- [ ] "size k"? → Fixed Window

### Step 4: Can I Update Incrementally?
- [ ] Adding element: O(1) update?
- [ ] Removing element: O(1) update?

**If NO → May need different approach (e.g., median needs sorting)**

---

## PART 7: Common Mistakes

### Mistake 1: Confusing Subsequence and Subarray

❌ **Wrong:** "Longest subsequence with sum ≤ k" → Sliding window  
✓ **Correct:** Subsequence can skip elements → DP or other approach

### Mistake 2: Using Sliding Window on Unsorted Two Sum

❌ **Wrong:** Two sum on unsorted array → Sliding window  
✓ **Correct:** Use HashMap or sort first + two pointers

### Mistake 3: Fixed Window for Variable Size Problem

❌ **Wrong:** "Longest substring k distinct" → Fixed window  
✓ **Correct:** "Longest" means variable size

### Mistake 4: Not Recognizing Sort Requirement

❌ **Wrong:** Three sum on unsorted → Try without sorting  
✓ **Correct:** MUST sort first for two pointers elimination

---

## PART 8: Advanced Recognition

### When Both Might Apply

**Problem:** "Longest subarray with sum = k"

**Approach 1:** Prefix sum + HashMap (O(n))  
**Approach 2:** Sliding window (only if all positive!)

**Key:** Sliding window works when shrinking **monotonically** improves condition.

### Hybrid Patterns

**Problem:** "Three Sum"
- Sort array → Two Pointers (outer loop)
- Fix one element → Two Pointers (inner)

**Problem:** "Sliding Window Maximum"
- Sliding Window structure
- Monotonic deque for O(1) max

---

## PART 9: The Algorithm Selection Tree

```python
def select_algorithm(problem):
    if "contiguous" in problem.keywords:
        if "size k" in problem:
            return "Fixed Window"
        elif "longest" in problem:
            return "Variable Window - Longest"
        elif "shortest" in problem:
            return "Variable Window - Shortest"
        elif "count" in problem:
            return "Variable Window - Count"
    
    elif "sorted" in problem or can_sort(problem):
        if "pair" in problem or "target sum" in problem:
            return "Two Pointers - Opposite"
        elif "in-place" in problem:
            return "Two Pointers - Same Direction"
    
    elif "multiple arrays" in problem and all_sorted(arrays):
        return "Two Pointers - Multiple Arrays"
    
    return "Consider other approaches"
```

---

## PART 10: Mastery Exercise

For EACH of these problems, identify:
1. Pattern (Two Pointers or Sliding Window)
2. Sub-pattern (specific variant)
3. Why you chose it

### Problems:

1. "Find longest substring with all unique characters"
2. "Partition array into three parts: <pivot, =pivot, >pivot"
3. "Maximum average of k consecutive elements"
4. "Find triplets summing to zero"
5. "Count subarrays with exactly k odd numbers"
6. "Move all zeros to end maintaining order"
7. "Check if s2 contains permutation of s1"
8. "Longest subarray with at most 2 distinct integers"

---

## Summary: The One-Page Cheatsheet

### Sliding Window
- **Contiguous** elements
- **Incremental** updates
- **Fixed** or **variable** size

### Two Pointers
- **Any** positions
- Often **sorted**
- **Opposite** or **same** direction

### Quick Decide:
1. Contiguous? → Sliding Window
2. Sorted pairs? → Two Pointers
3. In-place modify? → Two Pointers
4. Size k given? → Fixed Window
5. "Longest"? → Variable Longest
6. "Shortest"? → Variable Shortest
7. "Count"? → Variable Count

---

**You now have a systematic framework for pattern recognition!** Practice applying it to new problems until it becomes intuitive.
