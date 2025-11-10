using QueueProducerConsumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueueConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueList queue = new QueueList(3); // Maximum 3 items in queue

            Producer producer = new Producer(queue);
            Consumer consumer = new Consumer(queue);
           

            Thread producerThread = new Thread(producer.Produce);
            Thread consumerThread = new Thread(consumer.Consume);

            producerThread.Start();
            consumerThread.Start();

            Thread.Sleep(3000);

            producerThread.Join();
            consumerThread.Join();
        }
    }
}
