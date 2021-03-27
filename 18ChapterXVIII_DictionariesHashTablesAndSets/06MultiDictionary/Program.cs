using System;
using System.Collections.Generic;
using System.Text;

namespace _06MultiDictionary
{
    class Program
    {
        private static StringBuilder outputBuilder = new StringBuilder();

        public static void Main(string[] args)
        {
            MultiDictionary<int, int> multiDictionary = new MultiDictionary<int, int>();

            ExecuteCommands(multiDictionary);

            Console.WriteLine(outputBuilder.ToString().TrimEnd());
        }

        private static void ExecuteCommands(MultiDictionary<int, int> multiDictionary)
        {
            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                string commandLine = Console.ReadLine();
                ExecuteCommands(commandLine, multiDictionary);
            }
        }

        private static void ExecuteCommands(string commandLineString, MultiDictionary<int, int> multiDictionary)
        {
            string[] commandLine = commandLineString.Split();
            string command = commandLine[0];
            switch (command)
            {
                case "count":
                    ExecuteCountCommand(multiDictionary);
                    break;
                case "containsKey":
                    ExecuteContainsKeyCommand(commandLine, multiDictionary);
                    break;
                case "containsValue":
                    ExecuteContainsValueCommand(commandLine, multiDictionary);
                    break;
                case "value":
                    ExecuteValueCommand(commandLine, multiDictionary);
                    break;
                case "keys":
                    ExecuteKeysCommand(multiDictionary);
                    break;
                case "values":
                    ExecuteValuesCommand(multiDictionary);
                    break;
                case "add":
                    ExecuteAddCommand(commandLine, multiDictionary);
                    break;
                case "remove":
                    ExecuteRemoveCommand(commandLine, multiDictionary);
                    break;
                case "removeValue":
                    ExecuteRemoveValueCommand(commandLine, multiDictionary);
                    break;
                case "clear":
                    ExecuteClearCommand(multiDictionary);
                    break;
                case "getValues":
                    ExecuteGetValuesCommand(commandLine, multiDictionary);
                    break;
                case "elements":
                    ExecuteElementsCommand(multiDictionary);
                    break;
                default:
                    break;
            }
        }

        private static void ExecuteValueCommand(string[] tokens, MultiDictionary<int, int> multiDictionary)
        {
            int key = int.Parse(tokens[1]);
            AppendLine(string.Join(", ", multiDictionary[key]));
        }

        private static void ExecuteKeysCommand(MultiDictionary<int, int> multiDictionary)
        {
            AppendLine(string.Join(", ", multiDictionary.Keys));
        }

        private static void ExecuteValuesCommand(MultiDictionary<int, int> multiDictionary)
        {
            AppendLine(string.Join(", ", multiDictionary.Values));
        }

        private static void ExecuteCountCommand(MultiDictionary<int, int> multiDictionary)
        {
            AppendLine(multiDictionary.Count.ToString());
        }

        private static void ExecuteContainsKeyCommand(string[] tokens, MultiDictionary<int, int> multiDictionary)
        {
            int key = int.Parse(tokens[1]);
            bool containsKey = multiDictionary.ContainsKey(key);
            AppendLine(containsKey.ToString());
        }

        private static void ExecuteContainsValueCommand(string[] tokens, MultiDictionary<int, int> multiDictionary)
        {
            int value = int.Parse(tokens[1]);
            bool containsValue = multiDictionary.ContainsValue(value);
            AppendLine(containsValue.ToString());
        }

        private static void ExecuteAddCommand(string[] tokens, MultiDictionary<int, int> multiDictionary)
        {
            int key = int.Parse(tokens[1]);
            int value = int.Parse(tokens[2]);

            multiDictionary.Add(key, value);
        }

        private static void ExecuteRemoveCommand(string[] tokens, MultiDictionary<int, int> multiDictionary)
        {
            int key = int.Parse(tokens[1]);
            bool isRemoved = multiDictionary.Remove(key);
            AppendLine(isRemoved.ToString());
        }

        private static void ExecuteRemoveValueCommand(string[] tokens, MultiDictionary<int, int> multiDictionary)
        {
            int key = int.Parse(tokens[1]);
            int value = int.Parse(tokens[2]);
            bool isRemoved = multiDictionary.RemoveValue(key, value);
            AppendLine(isRemoved.ToString());
        }

        private static void ExecuteClearCommand(MultiDictionary<int, int> multiDictionary)
        {
            multiDictionary.Clear();
        }

        private static void ExecuteGetValuesCommand(string[] tokens, MultiDictionary<int, int> multiDictionary)
        {
            int key = int.Parse(tokens[1]);
            AppendLine(string.Join(", ", multiDictionary.GetValues(key)));
        }

        private static void ExecuteElementsCommand(MultiDictionary<int, int> multiDictionary)
        {
            foreach (KeyValuePair<int, List<int>> keyValuePair in multiDictionary)
            {
                AppendLine($"{keyValuePair.Key}: {string.Join(", ", keyValuePair.Value)}");
            }
        }

        private static void AppendLine(string line)
        {
            if (line.Equals(String.Empty))
            {
                return;
            }

            outputBuilder.AppendLine(line);
        }
    }
}