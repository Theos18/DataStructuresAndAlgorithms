using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ArrayMastery
{
    /// <summary>
    /// Performance Benchmarking: See Theory in Action
    /// 
    /// "In theory, theory and practice are the same. In practice, they are not." - Yogi Berra
    /// 
    /// Run these experiments to PROVE the concepts you learned:
    /// 1. Cache locality effects
    /// 2. ArrayList growth amortization
    /// 3. Array vs ArrayList performance
    /// 4. Sequential vs random access
    /// 5. Matrix traversal order impact
    /// 
    /// INSTRUCTIONS:
    /// Run each benchmark and observe the results.
    /// Try to predict the results BEFORE running!
    /// </summary>
    class PerformanceBenchmarks
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ARRAY PERFORMANCE BENCHMARKS ===\n");
            Console.WriteLine("WARNING: These tests take time. Be patient!\n");
            
            // Uncomment to run each benchmark
            // BenchmarkCacheLocality();
            // BenchmarkArrayListGrowth();
            // BenchmarkArrayVsArrayList();
            // BenchmarkSequentialVsRandom();
            // BenchmarkMatrixTraversal();
            // BenchmarkAllocationStrategies();
            // VisualizeArrayListGrowth();
            
            Console.WriteLine("\n=== ALL BENCHMARKS COMPLETE ===");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        #region BENCHMARK 1: Cache Locality

        /// <summary>
        /// EXPERIMENT: Prove that sequential access is faster than random access
        /// 
        /// THEORY:
        /// - Sequential: Cache prefetches next elements → Fast
        /// - Random: Every access might be a cache miss → Slow
        /// 
        /// EXPECTATION: Sequential should be 10-100x faster!
        /// </summary>
        static void BenchmarkCacheLocality()
        {
            Console.WriteLine("=== BENCHMARK 1: Cache Locality ===\n");
            
            const int SIZE = 10_000_000;
            int[] arr = new int[SIZE];
            Random rand = new Random(42); // Fixed seed for consistency
            
            // Fill array with random data
            for (int i = 0; i < SIZE; i++)
                arr[i] = rand.Next();
            
            // Test 1: Sequential Access
            Stopwatch sw = Stopwatch.StartNew();
            long sum1 = 0;
            for (int i = 0; i < SIZE; i++)
            {
                sum1 += arr[i];
            }
            sw.Stop();
            long sequentialMs = sw.ElapsedMilliseconds;
            
            // Test 2: Random Access (same number of accesses)
            int[] indices = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
                indices[i] = rand.Next(SIZE);
            
            sw.Restart();
            long sum2 = 0;
            for (int i = 0; i < SIZE; i++)
            {
                sum2 += arr[indices[i]];
            }
            sw.Stop();
            long randomMs = sw.ElapsedMilliseconds;
            
            // Results
            Console.WriteLine($"Array Size: {SIZE:N0} elements");
            Console.WriteLine($"Sequential Access: {sequentialMs} ms");
            Console.WriteLine($"Random Access: {randomMs} ms");
            Console.WriteLine($"Random is {(double)randomMs / sequentialMs:F2}x SLOWER");
            Console.WriteLine("\nWHY? Cache prefetching helps sequential but not random!\n");
            
            // Test 3: Stride Access (skip every N elements)
            Console.WriteLine("=== Stride Access Test ===");
            int[] strides = { 1, 2, 4, 8, 16, 32, 64 };
            
            foreach (int stride in strides)
            {
                sw.Restart();
                long sum = 0;
                for (int i = 0; i < SIZE; i += stride)
                {
                    sum += arr[i];
                }
                sw.Stop();
                
                Console.WriteLine($"Stride {stride,2}: {sw.ElapsedMilliseconds,4} ms " +
                                $"({(double)sw.ElapsedMilliseconds / sequentialMs:F2}x)");
            }
            
            Console.WriteLine("\nOBSERVATION: Larger strides = more cache misses = slower!\n");
        }

        #endregion

        #region BENCHMARK 2: ArrayList Growth

        /// <summary>
        /// EXPERIMENT: Measure the cost of ArrayList resizing
        /// 
        /// THEORY:
        /// - Growing by 2x: O(n) total copies, O(1) amortized
        /// - Pre-allocating: No resizes, faster
        /// 
        /// EXPECTATION: Pre-allocation should be significantly faster
        /// </summary>
        static void BenchmarkArrayListGrowth()
        {
            Console.WriteLine("=== BENCHMARK 2: ArrayList Growth ===\n");
            
            const int SIZE = 1_000_000;
            
            // Test 1: No pre-allocation (many resizes)
            Stopwatch sw = Stopwatch.StartNew();
            List<int> list1 = new List<int>();
            for (int i = 0; i < SIZE; i++)
            {
                list1.Add(i);
            }
            sw.Stop();
            long noPreallocMs = sw.ElapsedMilliseconds;
            
            // Test 2: With pre-allocation (no resizes)
            sw.Restart();
            List<int> list2 = new List<int>(SIZE);
            for (int i = 0; i < SIZE; i++)
            {
                list2.Add(i);
            }
            sw.Stop();
            long preallocMs = sw.ElapsedMilliseconds;
            
            // Results
            Console.WriteLine($"Adding {SIZE:N0} elements:");
            Console.WriteLine($"Without pre-allocation: {noPreallocMs} ms");
            Console.WriteLine($"With pre-allocation: {preallocMs} ms");
            Console.WriteLine($"Pre-allocation is {(double)noPreallocMs / preallocMs:F2}x FASTER");
            Console.WriteLine("\nWHY? No time wasted copying during resizes!\n");
            
            // Test 3: Count resizes
            Console.WriteLine("=== Resize Count Visualization ===");
            int resizeCount = 0;
            int lastCapacity = 0;
            List<int> list3 = new List<int>();
            
            Console.WriteLine($"{"Count",10} {"Capacity",10} {"Action",15}");
            Console.WriteLine(new string('-', 40));
            
            for (int i = 0; i < 1000; i++)
            {
                list3.Add(i);
                if (list3.Capacity != lastCapacity)
                {
                    Console.WriteLine($"{list3.Count,10} {list3.Capacity,10} {"RESIZE!",15}");
                    resizeCount++;
                    lastCapacity = list3.Capacity;
                }
            }
            
            Console.WriteLine($"\nTotal resizes for 1000 elements: {resizeCount}");
            Console.WriteLine($"Growth pattern: {string.Join(" → ", GetCapacitySequence(1000))}\n");
        }

        static List<int> GetCapacitySequence(int count)
        {
            List<int> sequence = new List<int>();
            List<int> list = new List<int>();
            int lastCapacity = 0;
            
            for (int i = 0; i < count; i++)
            {
                list.Add(i);
                if (list.Capacity != lastCapacity)
                {
                    sequence.Add(list.Capacity);
                    lastCapacity = list.Capacity;
                }
            }
            
            return sequence;
        }

        #endregion

        #region BENCHMARK 3: Array vs ArrayList

        /// <summary>
        /// EXPERIMENT: Compare raw performance of Array vs ArrayList
        /// 
        /// THEORY:
        /// - Array: Direct memory access
        /// - ArrayList: Indirect (through internal array) + bounds checking
        /// - But JIT optimizes ArrayList to nearly the same!
        /// 
        /// EXPECTATION: Array should be slightly faster, but not by much
        /// </summary>
        static void BenchmarkArrayVsArrayList()
        {
            Console.WriteLine("=== BENCHMARK 3: Array vs ArrayList ===\n");
            
            const int SIZE = 10_000_000;
            const int ITERATIONS = 10;
            
            int[] arr = new int[SIZE];
            List<int> list = new List<int>(SIZE);
            
            // Initialize both
            for (int i = 0; i < SIZE; i++)
            {
                arr[i] = i;
                list.Add(i);
            }
            
            // Test 1: Read performance
            Stopwatch sw = Stopwatch.StartNew();
            long sum1 = 0;
            for (int iter = 0; iter < ITERATIONS; iter++)
            {
                for (int i = 0; i < SIZE; i++)
                {
                    sum1 += arr[i];
                }
            }
            sw.Stop();
            long arrayReadMs = sw.ElapsedMilliseconds;
            
            sw.Restart();
            long sum2 = 0;
            for (int iter = 0; iter < ITERATIONS; iter++)
            {
                for (int i = 0; i < SIZE; i++)
                {
                    sum2 += list[i];
                }
            }
            sw.Stop();
            long listReadMs = sw.ElapsedMilliseconds;
            
            // Test 2: Write performance
            sw.Restart();
            for (int iter = 0; iter < ITERATIONS; iter++)
            {
                for (int i = 0; i < SIZE; i++)
                {
                    arr[i] = i * 2;
                }
            }
            sw.Stop();
            long arrayWriteMs = sw.ElapsedMilliseconds;
            
            sw.Restart();
            for (int iter = 0; iter < ITERATIONS; iter++)
            {
                for (int i = 0; i < SIZE; i++)
                {
                    list[i] = i * 2;
                }
            }
            sw.Stop();
            long listWriteMs = sw.ElapsedMilliseconds;
            
            // Results
            Console.WriteLine($"Size: {SIZE:N0} elements, {ITERATIONS} iterations each\n");
            
            Console.WriteLine("READ Performance:");
            Console.WriteLine($"  Array:     {arrayReadMs} ms");
            Console.WriteLine($"  ArrayList: {listReadMs} ms");
            Console.WriteLine($"  Difference: {Math.Abs(arrayReadMs - listReadMs)} ms " +
                            $"({(Math.Max(arrayReadMs, listReadMs) / (double)Math.Min(arrayReadMs, listReadMs)):F2}x)\n");
            
            Console.WriteLine("WRITE Performance:");
            Console.WriteLine($"  Array:     {arrayWriteMs} ms");
            Console.WriteLine($"  ArrayList: {listWriteMs} ms");
            Console.WriteLine($"  Difference: {Math.Abs(arrayWriteMs - listWriteMs)} ms " +
                            $"({(Math.Max(arrayWriteMs, listWriteMs) / (double)Math.Min(arrayWriteMs, listWriteMs)):F2}x)\n");
            
            Console.WriteLine("CONCLUSION: JIT compiler makes ArrayList nearly as fast as Array!\n");
        }

        #endregion

        #region BENCHMARK 4: Sequential vs Random Access

        /// <summary>
        /// EXPERIMENT: Visualize the performance cliff of random access
        /// 
        /// THEORY:
        /// Cache line size is typically 64 bytes (16 ints).
        /// Random access within a cache line is fast.
        /// Random access across cache lines is slow.
        /// </summary>
        static void BenchmarkSequentialVsRandom()
        {
            Console.WriteLine("=== BENCHMARK 4: Sequential vs Random Access Pattern ===\n");
            
            const int SIZE = 10_000_000;
            int[] arr = new int[SIZE];
            Random rand = new Random(42);
            
            for (int i = 0; i < SIZE; i++)
                arr[i] = rand.Next();
            
            // Test different access patterns
            Console.WriteLine($"{"Pattern",-30} {"Time (ms)",10} {"Relative",10}");
            Console.WriteLine(new string('-', 55));
            
            // 1. Fully sequential
            Stopwatch sw = Stopwatch.StartNew();
            long sum = 0;
            for (int i = 0; i < SIZE; i++)
                sum += arr[i];
            sw.Stop();
            long baselineMs = sw.ElapsedMilliseconds;
            Console.WriteLine($"{"Sequential (stride 1)",-30} {baselineMs,10} {"1.00x",10}");
            
            // 2. Skip every other (stride 2)
            sw.Restart();
            sum = 0;
            for (int i = 0; i < SIZE; i += 2)
                sum += arr[i];
            sw.Stop();
            Console.WriteLine($"{"Stride 2",-30} {sw.ElapsedMilliseconds,10} " +
                            $"{(double)sw.ElapsedMilliseconds / baselineMs:F2}x");
            
            // 3. Skip every 16 (cache line boundary)
            sw.Restart();
            sum = 0;
            for (int i = 0; i < SIZE; i += 16)
                sum += arr[i];
            sw.Stop();
            Console.WriteLine($"{"Stride 16 (cache line)",-30} {sw.ElapsedMilliseconds,10} " +
                            $"{(double)sw.ElapsedMilliseconds / baselineMs:F2}x");
            
            // 4. Skip every 1024 (page boundary)
            sw.Restart();
            sum = 0;
            for (int i = 0; i < SIZE; i += 1024)
                sum += arr[i];
            sw.Stop();
            Console.WriteLine($"{"Stride 1024 (page boundary)",-30} {sw.ElapsedMilliseconds,10} " +
                            $"{(double)sw.ElapsedMilliseconds / baselineMs:F2}x");
            
            // 5. Completely random
            int[] indices = Enumerable.Range(0, SIZE).OrderBy(x => rand.Next()).ToArray();
            sw.Restart();
            sum = 0;
            for (int i = 0; i < SIZE; i++)
                sum += arr[indices[i]];
            sw.Stop();
            Console.WriteLine($"{"Completely Random",-30} {sw.ElapsedMilliseconds,10} " +
                            $"{(double)sw.ElapsedMilliseconds / baselineMs:F2}x");
            
            Console.WriteLine("\nOBSERVATION: Sequential >> Strided >> Random\n");
        }

        #endregion

        #region BENCHMARK 5: Matrix Traversal

        /// <summary>
        /// EXPERIMENT: Prove that row-major traversal is faster than column-major
        /// 
        /// THEORY:
        /// C# uses row-major order: rows are stored sequentially.
        /// Accessing by row is cache-friendly.
        /// Accessing by column jumps around in memory.
        /// 
        /// EXPECTATION: Row-major should be significantly faster!
        /// </summary>
        static void BenchmarkMatrixTraversal()
        {
            Console.WriteLine("=== BENCHMARK 5: Matrix Traversal Order ===\n");
            
            const int ROWS = 4000;
            const int COLS = 4000;
            
            Console.WriteLine($"Matrix size: {ROWS} × {COLS} = {ROWS * COLS:N0} elements");
            Console.WriteLine($"Memory: {ROWS * COLS * sizeof(int) / (1024 * 1024)} MB\n");
            
            int[,] matrix = new int[ROWS, COLS];
            
            // Initialize
            for (int i = 0; i < ROWS; i++)
                for (int j = 0; j < COLS; j++)
                    matrix[i, j] = i * COLS + j;
            
            // Test 1: Row-major (cache-friendly)
            Stopwatch sw = Stopwatch.StartNew();
            long sum1 = 0;
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    sum1 += matrix[i, j];
                }
            }
            sw.Stop();
            long rowMajorMs = sw.ElapsedMilliseconds;
            
            // Test 2: Column-major (cache-hostile)
            sw.Restart();
            long sum2 = 0;
            for (int j = 0; j < COLS; j++)
            {
                for (int i = 0; i < ROWS; i++)
                {
                    sum2 += matrix[i, j];
                }
            }
            sw.Stop();
            long colMajorMs = sw.ElapsedMilliseconds;
            
            // Results
            Console.WriteLine($"Row-major traversal (i then j): {rowMajorMs} ms");
            Console.WriteLine($"Column-major traversal (j then i): {colMajorMs} ms");
            Console.WriteLine($"\nColumn-major is {(double)colMajorMs / rowMajorMs:F2}x SLOWER");
            Console.WriteLine("\nWHY? Each column access jumps {0} bytes in memory!", COLS * sizeof(int));
            Console.WriteLine("Cache line size is only ~64 bytes, so most accesses miss cache!\n");
            
            // Visualization
            Console.WriteLine("=== Memory Layout Visualization ===\n");
            Console.WriteLine("Row-major (FAST):");
            Console.WriteLine("Access order: [0,0] → [0,1] → [0,2] → ... (sequential in memory)");
            Console.WriteLine("▓▓▓▓▓▓▓▓▓▓▓▓ ← Cache line loaded once, used fully\n");
            
            Console.WriteLine("Column-major (SLOW):");
            Console.WriteLine("Access order: [0,0] → [1,0] → [2,0] → ... (jumping in memory)");
            Console.WriteLine("▓░░░░░░░░░░░ ← Cache line loaded, only 1 element used");
            Console.WriteLine("░▓░░░░░░░░░░ ← New cache line for next element");
            Console.WriteLine("░░▓░░░░░░░░░ ← New cache line again!");
            Console.WriteLine("... cache thrashing!\n");
        }

        #endregion

        #region BENCHMARK 6: Allocation Strategies

        /// <summary>
        /// EXPERIMENT: Compare different allocation strategies
        /// </summary>
        static void BenchmarkAllocationStrategies()
        {
            Console.WriteLine("=== BENCHMARK 6: Allocation Strategies ===\n");
            
            const int FINAL_SIZE = 1_000_000;
            
            // Strategy 1: Start from 0, let it grow naturally
            Stopwatch sw = Stopwatch.StartNew();
            List<int> list1 = new List<int>();
            for (int i = 0; i < FINAL_SIZE; i++)
                list1.Add(i);
            sw.Stop();
            long naturalGrowthMs = sw.ElapsedMilliseconds;
            
            // Strategy 2: Pre-allocate exact size
            sw.Restart();
            List<int> list2 = new List<int>(FINAL_SIZE);
            for (int i = 0; i < FINAL_SIZE; i++)
                list2.Add(i);
            sw.Stop();
            long exactPreallocMs = sw.ElapsedMilliseconds;
            
            // Strategy 3: Pre-allocate too much (waste space)
            sw.Restart();
            List<int> list3 = new List<int>(FINAL_SIZE * 2);
            for (int i = 0; i < FINAL_SIZE; i++)
                list3.Add(i);
            sw.Stop();
            long overPreallocMs = sw.ElapsedMilliseconds;
            
            // Strategy 4: Use array (if size known)
            sw.Restart();
            int[] arr = new int[FINAL_SIZE];
            for (int i = 0; i < FINAL_SIZE; i++)
                arr[i] = i;
            sw.Stop();
            long arrayMs = sw.ElapsedMilliseconds;
            
            // Results
            Console.WriteLine($"Adding {FINAL_SIZE:N0} elements:\n");
            
            Console.WriteLine($"{"Strategy",-30} {"Time",8} {"Memory Waste",15} {"Speed",10}");
            Console.WriteLine(new string('-', 70));
            
            Console.WriteLine($"{"Natural growth (no prealloc)",-30} {naturalGrowthMs,8} {"~50%",15} {"baseline",10}");
            Console.WriteLine($"{"Exact pre-allocation",-30} {exactPreallocMs,8} {"0%",15} " +
                            $"{(double)naturalGrowthMs / exactPreallocMs:F2}x");
            Console.WriteLine($"{"Over pre-allocation (2x)",-30} {overPreallocMs,8} {"~50%",15} " +
                            $"{(double)naturalGrowthMs / overPreallocMs:F2}x");
            Console.WriteLine($"{"Array (fixed size)",-30} {arrayMs,8} {"0%",15} " +
                            $"{(double)naturalGrowthMs / arrayMs:F2}x");
            
            Console.WriteLine("\n=== Memory Usage ===");
            Console.WriteLine($"List (natural): Capacity = {list1.Capacity:N0}, Count = {list1.Count:N0}, " +
                            $"Waste = {list1.Capacity - list1.Count:N0} ({(double)(list1.Capacity - list1.Count) / list1.Capacity:P})");
            Console.WriteLine($"List (exact):   Capacity = {list2.Capacity:N0}, Count = {list2.Count:N0}, " +
                            $"Waste = {list2.Capacity - list2.Count:N0}");
            Console.WriteLine($"List (over):    Capacity = {list3.Capacity:N0}, Count = {list3.Count:N0}, " +
                            $"Waste = {list3.Capacity - list3.Count:N0} ({(double)(list3.Capacity - list3.Count) / list3.Capacity:P})");
            
            Console.WriteLine("\nBEST PRACTICE:");
            Console.WriteLine("- Know the size? Use exact pre-allocation or array");
            Console.WriteLine("- Don't know? Use natural growth (waste is acceptable)");
            Console.WriteLine("- Need flexibility? ArrayList. Need speed? Array.\n");
        }

        #endregion

        #region VISUALIZATION: ArrayList Growth

        /// <summary>
        /// VISUALIZATION: Watch ArrayList grow in real-time
        /// </summary>
        static void VisualizeArrayListGrowth()
        {
            Console.WriteLine("=== VISUALIZATION: ArrayList Growth ===\n");
            
            List<int> list = new List<int>();
            int lastCapacity = 0;
            int copyOperations = 0;
            int totalCopies = 0;
            
            Console.WriteLine($"{"Count",8} {"Capacity",10} {"Action",20} {"Total Copies",15}");
            Console.WriteLine(new string('-', 60));
            
            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
                
                if (list.Capacity != lastCapacity)
                {
                    // A resize occurred
                    copyOperations++;
                    totalCopies += list.Count - 1; // Had to copy all existing elements
                    
                    Console.WriteLine($"{list.Count,8} {list.Capacity,10} " +
                                    $"{"RESIZE (copied " + (list.Count - 1) + ")",20} {totalCopies,15}");
                    
                    lastCapacity = list.Capacity;
                }
            }
            
            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"\nSummary:");
            Console.WriteLine($"  Total elements added: 100");
            Console.WriteLine($"  Total resize operations: {copyOperations}");
            Console.WriteLine($"  Total elements copied: {totalCopies}");
            Console.WriteLine($"  Average copies per add: {totalCopies / 100.0:F2}");
            Console.WriteLine($"\nThis is AMORTIZED O(1) - constant on average!");
            
            // Show growth rate
            Console.WriteLine($"\nGrowth rate: {string.Join(" → ", GetCapacitySequence(100))}");
            Console.WriteLine("Pattern: Doubles each time (2x growth factor)\n");
        }

        #endregion

        #region HELPER: Memory Size Formatter

        static string FormatBytes(long bytes)
        {
            string[] suffixes = { "B", "KB", "MB", "GB" };
            int suffixIndex = 0;
            double size = bytes;
            
            while (size >= 1024 && suffixIndex < suffixes.Length - 1)
            {
                size /= 1024;
                suffixIndex++;
            }
            
            return $"{size:F2} {suffixes[suffixIndex]}";
        }

        #endregion
    }
}
