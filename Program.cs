using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_Counting_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /***** Count() Example *****/
            var numberList = new List<int> { 1, 2, 3, 4, 5 };
            int count = numberList.Count();
            Console.WriteLine("Count():" + count); // Output: 5

            /***** Length-Array Example *****/
            var numberArray = new int[] { 1, 2, 3, 4, 5 };
            int arraylength = numberArray.Length;
            Console.WriteLine("Array Length:" + arraylength); // Output: 5

            /***** Length-String Example *****/
            string word = "hello";
            int wordlength = word.Length;
            Console.WriteLine("Word Length:" + wordlength); // Output: 5

            /***** LongCount() Example *****/
            var numbers = Enumerable.Range(0, int.MaxValue).Concat(Enumerable.Range(0, 100));
            long longCount100 = numbers.LongCount();
            Console.WriteLine("longCount100 LongCount():" + longCount100); // Output: 2147483647



            /***** LongCount() Example *****/
            //var largeCollection = Enumerable.Range(0, int.MaxValue).Select(x => (long)x).ToList();
            //long longCount = largeCollection.LongCount();
            //Console.WriteLine("LongCount():" + longCount); // Output: 2147483647

            /***** LongCount() Example : System.OutOfMemoryException Solution 1 *****/
            foreach (long number in Enumerable.Range(0, int.MaxValue).Select(x => (long)x))
            {
                // Process each number without storing the entire sequence in memory
                Console.WriteLine("LongCount():" + number);
            }

            /***** LongCount() Example : System.OutOfMemoryException Solution 2 *****/
            const int batchSize = 1000000; // Adjust based on memory capacity
            for (int i = 0; i < int.MaxValue; i += batchSize)
            {
                var batch = Enumerable.Range(i, batchSize).Select(x => (long)x);
                foreach (var number in batch)
                {
                    // Process each number in the batch
                    Console.WriteLine("LongCount():" + number);
                }
            }

            /***** LongCount() Example : System.OutOfMemoryException Solution 3 *****/
            IEnumerable<long> GetLargeSequence()
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    yield return (long)i;
                }
            }

            foreach (long number in GetLargeSequence())
            {
                // Process each number without storing them all
                Console.WriteLine("LongCount():" + number);
            }



        }
    }
}
