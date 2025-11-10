using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiThreadTest;
using System;
using System.Collections.Generic;

namespace MultiThreadTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var numbersToCalculate = new List<int> { 5, 7, 10, 12, 15 };

            MultiThreadCalculator manager = new MultiThreadCalculator();

            Console.WriteLine("Calculating factorials concurrently...\n");

            var results = await manager.CalculateFactorialsAsync(numbersToCalculate);

            Console.WriteLine("Results:");
            foreach (var kvp in results)
            {
                Console.WriteLine($"Factorial of {kvp.Key} = {kvp.Value}");
            }

            Console.WriteLine("\nAll factorial calculations completed.");
        }
    }
}
