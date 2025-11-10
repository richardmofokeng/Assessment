using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueueProducerConsumer
{
    public class QueueList
    {
        private Queue<int> queue = new Queue<int>();
        private readonly int maxSize;
        private readonly object lockObject = new object();

        public QueueList(int size)
        {
            maxSize = size;
        }

        // Add item to queue
        public void Enqueue(int item)
        {
            lock (lockObject)
            {
                while (queue.Count >= maxSize)
                {
                    Monitor.Wait(lockObject); // Wait if queue is full
                }

                queue.Enqueue(item);
                Console.WriteLine($"Produced: {item}");
                Monitor.PulseAll(lockObject); // Notify waiting threads
            }
        }
        

        // Remove item from queue
        public int Dequeue()
        {
            lock (lockObject)
            {
                while (queue.Count == 0)
                {
                    Monitor.Wait(lockObject); // Wait if queue is empty
                }

                int item = queue.Dequeue();
                Console.WriteLine($"Consumed: {item}");
                Monitor.PulseAll(lockObject); // Notify waiting threads
                return item;
            }
        }
    }
}
