using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueueProducerConsumer
{
    public class Producer
    {
        private QueueList queueList;
        private Random random = new Random();

        public Producer(QueueList queue)
        {
            queueList = queue;
        }

        public void Produce()
        {
            while (true)
            {
                int number = random.Next(1, 100); // Generate random number
                queueList.Enqueue(number);
                Thread.Sleep(500); // Simulate time taken to produce
            }
        }
    }
}
