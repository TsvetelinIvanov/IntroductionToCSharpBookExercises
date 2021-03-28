using System;
using System.Text;

namespace _08PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<decimal> priorityQueue = new PriorityQueue<decimal>();
            StringBuilder outputBuilder = new StringBuilder();
            while (true)
            {                
                string[] commandLine = Console.ReadLine().Split();
                string command = commandLine[0];
                if (command == "Count")
                {
                    outputBuilder.AppendLine(priorityQueue.Count.ToString());
                }
                else if (command == "Add")
                {
                    decimal number = decimal.Parse(commandLine[1]);
                    priorityQueue.Enqueue(number);
                }
                else if (command == "Dequeue")
                {
                    if (priorityQueue.Count > 0)
                    {                        
                        outputBuilder.AppendLine(priorityQueue.Dequeue().ToString());
                    }
                    else
                    {
                        outputBuilder.AppendLine("The priority queue is empty!");
                    }
                }
                else if (command == "End")
                {
                    break;
                }
            }

            Console.Write(outputBuilder);
        }       
    }
}