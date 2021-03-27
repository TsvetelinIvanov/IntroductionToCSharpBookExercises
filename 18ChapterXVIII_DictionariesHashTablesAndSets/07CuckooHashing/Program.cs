using System;
using System.Collections.Generic;
using System.Text;

namespace _07CuckooHashing
{
    class Program
    {
        private static StringBuilder outputBuilder = new StringBuilder();
        private static CuckooHashingTable<int, int> hashTable = new CuckooHashingTable<int, int>();

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
                case "this":
                    {
                        int key = int.Parse(command[1]);
                        if (hashTable.ContainsKey(key))
                        {
                            outputBuilder.AppendLine(hashTable[key].ToString());
                        }

                        break;
                    }
                case "Count":
                    {
                        outputBuilder.AppendLine(hashTable.Count.ToString());
                        break;
                    }
                case "ContainsKey":
                    {
                        outputBuilder.AppendLine(hashTable.ContainsKey(int.Parse(command[1])).ToString());
                        break;
                    }
                case "Keys":
                    {
                        outputBuilder.AppendLine(string.Join(", ", hashTable.Keys));
                        break;
                    }
                case "Values":
                    {
                        outputBuilder.AppendLine(string.Join(", ", hashTable.Values));
                        break;
                    }
                case "Add":
                    {
                        string[] arguments = command[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        int key = int.Parse(arguments[0]);
                        if (!hashTable.ContainsKey(key))
                        {
                            hashTable.Add(key, int.Parse(arguments[1]));
                        }

                        break;
                    }
                case "Remove":
                    {
                        int key = int.Parse(command[1]);
                        if (hashTable.ContainsKey(key))
                        {
                            hashTable.Remove(int.Parse(command[1]));
                        }

                        break;
                    }
                case "Clear":
                    {
                        hashTable.Clear();
                        break;
                    }
                case "Foreach":
                    {
                        foreach (KeyValuePair<int, int> item in hashTable)
                        {
                            outputBuilder.AppendLine(item.Key + "->" + item.Value);
                        }

                        break;
                    }
            }
        }
    }
}