using MultiThreadCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThread
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersToCalculate = new List<int> { 1, 3, 5, 7, 9,12,15 };

            ThreadManager manager = new ThreadManager();

            Console.WriteLine("Calculating factorials concurrently...\n");

            var results =  manager.CalculateFactorialsAsync(numbersToCalculate);

            Console.WriteLine("Results:");
            foreach (var k in results.Result)
            {
                Console.WriteLine($"Factorial of {k.Key} = {k.Value}");
            }

            Console.WriteLine("\nAll factorial calculations completed.");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
