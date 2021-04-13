using System;
using System.IO;

namespace _04RealFileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootDirectoryPath = Console.ReadLine();

            DirectoryInfo rootDirectoryInfo = new DirectoryInfo(rootDirectoryPath);

            Directory rootDirectory = new Directory(rootDirectoryInfo.Name, rootDirectoryInfo.LastWriteTime);
            Device device = new Device("My Device", rootDirectory);

            ComputerStorage computerStorage = new ComputerStorage();
            computerStorage.AddDevice(device);

            FileSystemTraversal(rootDirectoryInfo, rootDirectory);

            Console.WriteLine(computerStorage);
        }

        static void FileSystemTraversal(DirectoryInfo currentDirectoryInfo, Directory currentDirectory)
        {
            foreach (FileInfo fileInfo in currentDirectoryInfo.GetFiles())
            {
                currentDirectory.AddFile(new BinaryFile(fileInfo.Name, fileInfo.CreationTime, fileInfo.LastWriteTime, null));
            }

            foreach (DirectoryInfo directoryInfo in currentDirectoryInfo.GetDirectories())
            {
                Directory directory = new Directory(directoryInfo.Name, directoryInfo.LastWriteTime);
                currentDirectory.AddDirectory(directory);
                FileSystemTraversal(directoryInfo, directory);
            }
        }
    }
}