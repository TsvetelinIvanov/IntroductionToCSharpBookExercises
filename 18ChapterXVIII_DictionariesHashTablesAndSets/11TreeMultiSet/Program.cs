using System;
using System.Text;

namespace _11TreeMultiSet
{
    class Program
    {
        private static StringBuilder outputBuilder = new StringBuilder();
        private static TreeMultiSet<int> treeMultiSet = new TreeMultiSet<int>();

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

        private static void ProcessCommand(string commandText)
        {
            string[] command = commandText.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
            switch (command[0])
            {
                case "Count":
                    {
                        outputBuilder.AppendLine(treeMultiSet.Count.ToString());
                        break;
                    }
                case "Add":
                    {
                        treeMultiSet.Add(int.Parse(command[1]));
                        break;
                    }
                case "Find":
                    {
                        outputBuilder.AppendLine(treeMultiSet.Find(int.Parse(command[1])).ToString());
                        break;
                    }
                case "FindMin":
                    {
                        outputBuilder.AppendLine(treeMultiSet.FindMin().ToString());
                        break;
                    }
                case "FindMax":
                    {
                        outputBuilder.AppendLine(treeMultiSet.FindMax().ToString());
                        break;
                    }
                case "Delete":
                    {
                        treeMultiSet.Delete(int.Parse(command[1]));
                        break;
                    }                
                case "DeleteAll":
                    {
                        treeMultiSet.DeleteAll(int.Parse(command[1]));
                        break;
                    }
                case "DeleteFirst":
                    {
                        treeMultiSet.DeleteFirst();
                        break;
                    }
                case "DeleteLast":
                    {
                        treeMultiSet.DeleteLast();
                        break;
                    }                
                case "Foreach":
                    {
                        foreach (int item in treeMultiSet)
                        {
                            outputBuilder.Append(item + ", ");
                        }

                        outputBuilder.Remove(outputBuilder.Length - 2, 2);
                        outputBuilder.AppendLine();
                        break;
                    }
            }
        }        
    }
}