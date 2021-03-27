using System;
using System.Text;

namespace _09HashedSet
{
    class Program
    {
        static StringBuilder outputBuilder = new StringBuilder();
        static HashedSet<int> hashedSet = new HashedSet<int>();

        static void Main(string[] args)
        {
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "End" || commandLine == null)
                {
                    break;
                }
                try
                {
                    ProcessCommand(commandLine);
                }
                catch (Exception e)
                {
                    outputBuilder.AppendLine(e.GetType() + ": " + e.Message);
                }
            }

            Console.WriteLine(outputBuilder.ToString().TrimEnd());
        }
        
        private static void ProcessCommand(string commandLine)
        {
            string[] command = commandLine.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
            switch (command[0])
            {
                case "Count":
                    {
                        outputBuilder.AppendLine(hashedSet.Count.ToString());
                        break;
                    }
                case "Find":
                    {
                        outputBuilder.AppendLine(hashedSet.Find(int.Parse(command[1])).ToString());
                        break;
                    }
                case "Add":
                    {
                        int element = int.Parse(command[1]);
                        if (!hashedSet.Find(element))
                        {
                            hashedSet.Add(element);
                        }

                        break;
                    }
                case "Remove":
                    {
                        int element = int.Parse(command[1]);
                        hashedSet.Remove(element);
                        break;
                    }               
                case "Clear":
                    {
                        hashedSet.Clear();
                        break;
                    }
                case "Union":
                    {
                        string[] elements = command[1].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        HashedSet<int> newHasedhSet = new HashedSet<int>();
                        foreach (string item in elements)
                        {
                            int element = int.Parse(item);
                            if (!newHasedhSet.Find(element))
                            {
                                newHasedhSet.Add(element);
                            }
                        }

                        hashedSet.Union(newHasedhSet);
                        break;
                    }
                case "Intersect":
                    {
                        string[] elements = command[1].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        HashedSet<int> newHasedhSet = new HashedSet<int>();
                        foreach (string item in elements)
                        {
                            int element = int.Parse(item);
                            if (!newHasedhSet.Find(element))
                            {
                                newHasedhSet.Add(element);
                            }
                        }

                        hashedSet.Intersect(newHasedhSet);
                        break;
                    }
                case "Foreach":
                    {
                        foreach (int item in hashedSet)
                        {
                            outputBuilder.Append(item + ", ");
                        }

                        if (outputBuilder.Length > 1)
                        {
                            outputBuilder.Remove(outputBuilder.Length - 2, 2);
                            outputBuilder.AppendLine();
                        }

                        break;
                    }
            }
        }        
    }
}