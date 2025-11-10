using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadCalculator
{
    public class ThreadManager
    {
        private readonly Calculator _calculator;

        public ThreadManager()
        {
            _calculator = new Calculator();
        }
        // Returns a thread-safe dictionary of number -> factorial
        public async Task<System.Collections.Concurrent.ConcurrentDictionary<int, long>> CalculateFactorialsAsync(List<int> numbers)
        {
            var results = new System.Collections.Concurrent.ConcurrentDictionary<int, long>();
            var tasks = new List<Task>();

            foreach (int number in numbers)
            {
                tasks.Add(Task.Run(() =>
                {
                    long factorial = _calculator.CalculateFactorial(number);
                    results[number] = factorial; // Thread-safe
                }));
            }

            await Task.WhenAll(tasks);
            return results;
        }
        public async Task CalculateConcurrently(List<int> numbers)
        {
            List<Task> tasks = new List<Task>();

            foreach (int number in numbers)
            {
                tasks.Add(Task.Run(() =>
                {
                    long result = _calculator.CalculateFactorial(number);
                    _calculator.PrintResult(number, result);
                }));
            }

            await Task.WhenAll(tasks); // Wait for all tasks to complete
        }
    }
}
