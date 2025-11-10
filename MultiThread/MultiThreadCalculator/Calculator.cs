using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadCalculator
{
    public class Calculator
    {
        // For thread-safe console output
        private readonly object _lock = new object();

        public long CalculateFactorial(int number)
        {
            long result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }

        public void PrintResult(int number, long result)
        {
            lock (_lock)
            {
                Console.WriteLine($"Factorial of {number} is {result}");
            }
        }

    }
}
