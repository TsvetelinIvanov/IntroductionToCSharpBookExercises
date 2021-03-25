using System;
using System.Collections.Generic;
using System.IO;

namespace _12HardDiskTree
{
    class Program
    {
		//input example:
		//C:\WINDOWS\
		//C:\WINDOWS\
		//expected output: it depends of file system and take time
		private static Folder rootFolder;	

		static void Main(string[] args)
		{
			string inputDirectory = Console.ReadLine();
			string subDirectory = Console.ReadLine();
			BuildTree(inputDirectory);
			ulong subDirectoryFilesSize = CalculateTotalFilesSizeInDirectory(subDirectory);
			Console.WriteLine(subDirectoryFilesSize);
		}

		private static void BuildTree(string directoryPath)
		{
			DirectoryInfo currentDirectory = new DirectoryInfo(directoryPath);
			rootFolder = new Folder(currentDirectory.FullName, null, null);
			BuildTree(currentDirectory, rootFolder);
		}

		private static void BuildTree(DirectoryInfo directory, Folder currentFolderInTree)
		{
			try
			{
				FileInfo[] childFiles = directory.GetFiles();
				currentFolderInTree.Files = new File[childFiles.Length];
				for (int i = 0; i < childFiles.Length; i++)
				{
					long currentFileSize = childFiles[i].Length;
					string currentFileName = childFiles[i].FullName;
					currentFolderInTree.Files[i] = new File(currentFileName, currentFileSize);
				}

				DirectoryInfo[] childDirectories = directory.GetDirectories();
				currentFolderInTree.Folders = new Folder[childDirectories.Length];
				for (int i = 0; i < childDirectories.Length; i++)
				{
					string currentDirectoryName = childDirectories[i].FullName;
					currentFolderInTree.Folders[i] = new Folder(currentDirectoryName, null, null);
				}

				for (int i = 0; i < childDirectories.Length; i++)
				{
					BuildTree(childDirectories[i], currentFolderInTree.Folders[i]);
				}
			}
			catch (UnauthorizedAccessException uae)
			{
                Console.WriteLine(uae.Message);
			}
		}

		public static ulong CalculateTotalFilesSizeInDirectory(string directoryPath)
		{
			string cleanedPath = directoryPath;
			if (directoryPath != rootFolder.Name)
			{
				cleanedPath = directoryPath[0..^1];
			}
			Folder currentFolder = FindFolderInTree(cleanedPath);
			ulong totalFilesSize = 0;
			Queue<Folder> currentDirectoryChilds = new Queue<Folder>();
			currentDirectoryChilds.Enqueue(currentFolder);
			while (currentDirectoryChilds.Count > 0)
			{
				Folder tempFolder = currentDirectoryChilds.Dequeue();
				if (tempFolder.Name.ToString().IndexOf("System Volume Information") >= 0)
				{
					continue;
				}

				if (tempFolder.Files != null)
				{
					foreach (File file in tempFolder.Files)
					{
						totalFilesSize += (ulong)file.Size;
					}
				}

				Folder[] tempSubDirectories = tempFolder.Folders;
				if (tempSubDirectories != null)
				{
					foreach (Folder subDirectory in tempSubDirectories)
					{
						currentDirectoryChilds.Enqueue(subDirectory);
					}
				}

				tempSubDirectories = null;
			}

			return totalFilesSize;
		}

		private static Folder FindFolderInTree(string directoryPath)
		{
			Queue<Folder> directories = new Queue<Folder>();
			directories.Enqueue(rootFolder);
			Folder currentFolder = rootFolder;
			while (directories.Count > 0)
			{
				currentFolder = directories.Dequeue();
				if (currentFolder.Name == directoryPath)
				{
					break;
				}

				if (currentFolder.Name.ToString().IndexOf("System Volume Information") >= 0)
				{
					continue;
				}

				Folder[] subDirectories = currentFolder.Folders;
				if (subDirectories != null)
				{
					foreach (Folder subDirectoriy in subDirectories)
					{
						directories.Enqueue(subDirectoriy);
					}
				}
            }

            return currentFolder;
		}
	}
}