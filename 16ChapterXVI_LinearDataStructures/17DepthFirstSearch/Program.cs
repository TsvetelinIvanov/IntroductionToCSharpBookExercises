using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _17DepthFirstSearch
{
    class Program
    {
		private static StringBuilder directoriesBuilder = new StringBuilder();

		static void Main(string[] args)
		{
			string path = Console.ReadLine();

			DirectoryInfo directory = new DirectoryInfo(path);
			DepthFirstSearch(directory);
			Console.WriteLine(directoriesBuilder.ToString().TrimEnd());
		}

		private static void DepthFirstSearch(DirectoryInfo directory)
		{
			Stack<DirectoryInfo> directoriesStack = new Stack<DirectoryInfo>();
			directoriesStack.Push(directory);
			
			while (directoriesStack.Count > 0)
			{
				DirectoryInfo parentDirectory = directoriesStack.Pop();
				try
				{
					DirectoryInfo[] childDirectories = parentDirectory.GetDirectories();

					directoriesBuilder.AppendLine(parentDirectory.ToString());

					foreach (DirectoryInfo currentDirectory in childDirectories)
					{
						DepthFirstSearch(currentDirectory);
					}
				}
				catch (UnauthorizedAccessException uae)
				{
					directoriesBuilder.AppendLine(uae.GetType() + ": " + uae.ToString());
				}
			}			
		}
	}
}