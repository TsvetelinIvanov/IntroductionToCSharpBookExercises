using System;
using System.Collections.Generic;
using System.Text;

namespace _05DictionaryWithTwoKeys
{
    class Program
    {
        static StringBuilder outputBuilder = new StringBuilder();

        public static void Main(string[] args)
        {
            TwoKeysDictionary<int, int, int> twoKeysDictionary = new TwoKeysDictionary<int, int, int>();

            ExecuteCommands(twoKeysDictionary);

            Console.WriteLine(outputBuilder.ToString().TrimEnd());
        }

        private static void ExecuteCommands(TwoKeysDictionary<int, int, int> twoKeysDictionary)
        {
            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                string commandLine = Console.ReadLine();
                ExecuteCommands(commandLine, twoKeysDictionary);
            }
        }

        private static void ExecuteCommands(string commandLine, TwoKeysDictionary<int, int, int> twoKeysDictionary)
        {
            string[] tokens = commandLine.Split();
            string command = tokens[0];
            switch (command)
            {
                case "count":
                    ExecuteCountCommand(twoKeysDictionary);
                    break;
                case "contains":
                    ExecuteContainsCommand(tokens, twoKeysDictionary);
                    break;
                case "add":
                    ExecuteAddCommand(tokens, twoKeysDictionary);
                    break;
                case "remove":
                    ExecuteRemoveCommand(tokens, twoKeysDictionary);
                    break;
                case "clear":
                    ExecuteClearCommand(twoKeysDictionary);
                    break;
                case "value":
                    ExecuteValueCommand(tokens, twoKeysDictionary);
                    break;
                case "values":
                    ExecuteValuesCommand(twoKeysDictionary);
                    break;
                case "elements":
                    ExecuteElementsCommand(twoKeysDictionary);
                    break;
                default:
                    break;
            }
        }        

        private static void ExecuteCountCommand(TwoKeysDictionary<int, int, int> twoKeysDictionary)
        {
            int count = twoKeysDictionary.Count;
            AppendLine(count.ToString());
        }

        private static void ExecuteContainsCommand(string[] tokens, TwoKeysDictionary<int, int, int> twoKeysDictionary)
        {
            int key1 = int.Parse(tokens[1]);
            int key2 = int.Parse(tokens[2]);
            bool contains = twoKeysDictionary.Contains(key1, key2);
            AppendLine(contains.ToString());
        }

        private static void ExecuteAddCommand(string[] tokens, TwoKeysDictionary<int, int, int> twoKeysDictionary)
        {
            int key1 = int.Parse(tokens[1]);
            int key2 = int.Parse(tokens[2]);
            int value = int.Parse(tokens[3]);

            bool isCommandSuccessful = twoKeysDictionary.Add(key1, key2, value);
            AppendLine(isCommandSuccessful.ToString());
        }

        private static void ExecuteRemoveCommand(string[] tokens, TwoKeysDictionary<int, int, int> twoKeysDictionary)
        {
            int key1 = int.Parse(tokens[1]);
            int key2 = int.Parse(tokens[2]);
            bool isRemoved = twoKeysDictionary.Remove(key1, key2);
            AppendLine(isRemoved.ToString());
        }

        private static void ExecuteClearCommand(TwoKeysDictionary<int, int, int> twoKeysDictionary)
        {
            twoKeysDictionary.Clear();
        }

        private static void ExecuteValueCommand(string[] tokens, TwoKeysDictionary<int, int, int> twoKeysDictionary)
        {
            int key1 = int.Parse(tokens[1]);
            int key2 = int.Parse(tokens[2]);
            try
            {
                int value = twoKeysDictionary[key1, key2];
                AppendLine(value.ToString());
            }
            catch (KeyNotFoundException knfe)
            {
                AppendLine(knfe.Message);
            }
        }

        private static void ExecuteValuesCommand(TwoKeysDictionary<int, int, int> twoKeysDictionary)
        {
            AppendLine(string.Join(", ", twoKeysDictionary.Values));
        }

        private static void ExecuteElementsCommand(TwoKeysDictionary<int, int, int> twoKeysDictionary)
        {
            foreach (Tuple<int, int, int> twoKeyValuePair in twoKeysDictionary)
            {
                AppendLine($"First Key: {twoKeyValuePair.Item1}, Second Key: {twoKeyValuePair.Item2}, Value: {twoKeyValuePair.Item3}");
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