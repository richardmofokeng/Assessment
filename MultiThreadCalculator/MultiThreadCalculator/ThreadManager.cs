using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadCalculator
{
    public class  ThreadManager
    {
        private readonly Calculator _calculator;

        public ThreadManager()
        {
            _calculator = new Calculator();
        }

        public async Task CalculateFactorialsConcurrently(List<int> numbers)
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
