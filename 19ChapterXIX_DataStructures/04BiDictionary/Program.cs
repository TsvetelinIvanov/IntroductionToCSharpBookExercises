using System;
using System.Collections.Generic;
using System.Text;

namespace _04BiDictionary
{
    class Program
    {
        public static BiDictionary<string, string, int> biDictionary = new BiDictionary<string, string, int>();
        private static StringBuilder outputBuilder = new StringBuilder();      
        
        static void Main(string[] args)
        {
            ProcessCommands();
            Console.Write(outputBuilder);
        }

        private static void ProcessCommands()
        {
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "End")
                {
                    break;
                }

                ProcessCommand(commandLine);
            }
        }

        private static void ProcessCommand(string commandLineString)
        {
            string[] commandLine = commandLineString.Split();
            string command = commandLine[0];
            switch (command)
            {
                case "ElementsCount":
                    outputBuilder.AppendLine(biDictionary.ElementsCount.ToString());
                    break;
                case "ReferencesCount":
                    outputBuilder.AppendLine(biDictionary.ReferencesCount.ToString());
                    break;
                case "ContainsFirstKey":
                    outputBuilder.AppendLine(biDictionary.ContainsFirstKey(commandLine[1]).ToString());
                    break;
                case "ContainsSecondKey":
                    outputBuilder.AppendLine(biDictionary.ContainsSecondKey(commandLine[1]).ToString());
                    break;
                case "ContainsKeys":
                    outputBuilder.AppendLine(biDictionary.ContainsKeys(commandLine[1], commandLine[2]).ToString());
                    break;
                case "ContainsValue":
                    outputBuilder.AppendLine(biDictionary.ContainsValue(int.Parse(commandLine[1])).ToString());
                    break;
                case "Add":
                    biDictionary.Add(commandLine[1], commandLine[2], int.Parse(commandLine[3]));
                    break;                
                case "RemoveValue":
                    outputBuilder.AppendLine(biDictionary.RemoveValue(commandLine[1], commandLine[2], int.Parse(commandLine[3])).ToString());
                    break;
                case "SearchByFirstKey":
                    outputBuilder.Append(biDictionary.SearchByFirstKey(commandLine[1], out List<int> values) + ": ");
                    outputBuilder.AppendLine($"[{string.Join(", ", values)}]");
                    break;
                case "SearchBySecondKey":
                    outputBuilder.Append(biDictionary.SearchBySecondKey(commandLine[1], out values) + ": ");
                    outputBuilder.AppendLine($"[{string.Join(", ", values)}]");
                    break;
                case "SearchByBothKeys":
                    outputBuilder.Append(biDictionary.SearchByBothKeys(commandLine[1], commandLine[2], out values) + ": ");
                    outputBuilder.AppendLine($"[{string.Join(", ", values)}]");
                    break;
                case "Foreach":
                    foreach (Tuple<string, string, List<int>> item in biDictionary)
                    {
                        outputBuilder.AppendLine($"{item.Item1} and {item.Item2}: [{string.Join(", ", item.Item3)}]");
                    }
                    
                    break;
                default:
                    outputBuilder.AppendLine($"Invalid command: {command}!");
                    break;
            }            
        }
    }
}