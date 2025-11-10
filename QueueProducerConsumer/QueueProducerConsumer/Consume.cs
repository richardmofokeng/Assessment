using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueueProducerConsumer
{
    public class Consumer
    {

        private QueueList queueList;

        public Consumer(QueueList queue)
        {
            queueList = queue;
        }

        public void Consume()
        {
            while (true)
            {
                int item = queueList.Dequeue();
                Thread.Sleep(3000); // Simulate time taken to consume
            }
        }
    }
}
