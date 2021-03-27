using System;
using System.Text;

namespace _04DictHashSet
{
    class Program
    {
        private static StringBuilder outputBuilder = new StringBuilder();

        public static void Main(string[] args)
        {
            DictHashSet<int> dictHashSet = new DictHashSet<int>();

            ExecuteCommands(dictHashSet);

            Console.WriteLine(outputBuilder.ToString().TrimEnd());
        }

        private static void ExecuteCommands(DictHashSet<int> dictHashSet)
        {
            string commandsCountInput = Console.ReadLine();
            int commandsCount = int.Parse(commandsCountInput);
            for (int i = 0; i < commandsCount; i++)
            {
                string commandLine = Console.ReadLine();
                ExecuteCommands(commandLine, dictHashSet);
            }
        }

        private static void ExecuteCommands(string commandLineString, DictHashSet<int> dictHashSet)
        {
            string[] commandLine = commandLineString.Split();
            string command = commandLine[0];
            switch (command)
            {
                case "count":
                    ExecuteCountCommand(dictHashSet);
                    break;
                case "contains":
                    ExecuteContainsCommand(commandLine, dictHashSet);
                    break;
                case "add":
                    ExecuteAddCommand(commandLine, dictHashSet);
                    break;
                case "remove":
                    ExecuteRemoveCommand(commandLine, dictHashSet);
                    break;
                case "clear":
                    ExecuteClearCommand(dictHashSet);
                    break;
                case "union":
                    ExecuteUnionCommand(commandLine, dictHashSet);
                    break;
                case "intersect":
                    ExecuteIntersectCommand(commandLine, dictHashSet);
                    break;
                case "elements":
                    ExecuteElementsCommand(dictHashSet);
                    break;
            }
        }

        private static void ExecuteCountCommand(DictHashSet<int> dictHashSet)
        {
            int count = dictHashSet.Count;
            AppendLine(count.ToString());
        }

        private static void ExecuteContainsCommand(string[] arguments, DictHashSet<int> dictHashSet)
        {
            int element = int.Parse(arguments[1]);
            bool contains = dictHashSet.Contains(element);
            AppendLine(contains.ToString());
        }

        private static void ExecuteAddCommand(string[] arguments, DictHashSet<int> dictHashSet)
        {
            int element = int.Parse(arguments[1]);
            bool isAdded = dictHashSet.Add(element);
            AppendLine(isAdded.ToString());
        }

        private static void ExecuteRemoveCommand(string[] arguments, DictHashSet<int> dictHashSet)
        {
            int element = int.Parse(arguments[1]);
            bool isRemoved = dictHashSet.Remove(element);
            AppendLine(isRemoved.ToString());
        }

        private static void ExecuteClearCommand(DictHashSet<int> dictHashSet)
        {
            dictHashSet.Clear();
        }

        private static void ExecuteUnionCommand(string[] arguments, DictHashSet<int> dictHashSet)
        {
            DictHashSet<int> unionSet = new DictHashSet<int>();
            for (int i = 1; i < arguments.Length; i++)
            {
                int otherSetElement = int.Parse(arguments[i]);
                unionSet.Add(otherSetElement);
            }

            dictHashSet.Union(unionSet);
        }

        private static void ExecuteIntersectCommand(string[] arguments, DictHashSet<int> dictHashSet)
        {
            DictHashSet<int> intersectionSet = new DictHashSet<int>();
            for (int i = 1; i < arguments.Length; i++)
            {
                int otherSetElement = int.Parse(arguments[i]);
                intersectionSet.Add(otherSetElement);
            }

            dictHashSet.Intersect(intersectionSet);
        }

        private static void ExecuteElementsCommand(DictHashSet<int> dictHashSet)
        {            
            StringBuilder elementsBuilder = new StringBuilder();
            foreach (int item in dictHashSet)
            {
                elementsBuilder.Append(item + " ");
            }

            AppendLine(elementsBuilder.ToString());
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