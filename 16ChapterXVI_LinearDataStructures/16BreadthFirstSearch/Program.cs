using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _16BreadthFirstSearch
{
    class Program
    {
		static void Main(string[] args)
		{
			string path = Console.ReadLine();

			DirectoryInfo directory = new DirectoryInfo(path);

			Console.WriteLine(BreadthFirstSearch(directory));
		}

		private static string BreadthFirstSearch(DirectoryInfo directory)
		{			
			Queue<DirectoryInfo> directoriesQueue = new Queue<DirectoryInfo>();
			directoriesQueue.Enqueue(directory);
			StringBuilder directoriesBuilder = new StringBuilder();
			while (directoriesQueue.Count > 0)
			{
				DirectoryInfo parentDirectory = directoriesQueue.Dequeue();
				try
				{
					DirectoryInfo[] childDirectories = parentDirectory.GetDirectories();

					directoriesBuilder.AppendLine(parentDirectory.ToString());

					foreach (DirectoryInfo currentDirectory in childDirectories)
					{
						directoriesQueue.Enqueue(currentDirectory);
					}
				}
				catch (UnauthorizedAccessException uae)
				{
					directoriesBuilder.AppendLine(uae.GetType() + ": " + uae.ToString());
				}
			}

			return directoriesBuilder.ToString().Trim();
		}
	}
}