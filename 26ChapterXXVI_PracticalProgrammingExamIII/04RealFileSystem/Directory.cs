using System;
using System.Collections.Generic;
using System.Text;

namespace _04RealFileSystem
{
    public class Directory : IComparable<Directory>
    {
        private string name;
        private DateTime lastChangedOn;
        private Directory parrent;
        private SortedSet<File> files;
        private SortedSet<Directory> directories;

        public Directory(string name, DateTime lastChangedOn)
        {
            this.Name = name;
            this.LastChangedOn = lastChangedOn;
            this.Files = new SortedSet<File>();
            this.Directories = new SortedSet<Directory>();
        }

        public Directory() : this(string.Empty, DateTime.Now)
        { 

        }

        public Directory(string name, DateTime lastChangedOn, IEnumerable<File> files, params Directory[] directories) : this(name, lastChangedOn)
        {
            foreach (File file in files)
            {
                this.AddFile(file);
            }

            foreach (Directory directory in directories)
            {
                this.AddDirectory(directory);
            }
        }

        public Directory(string name, DateTime lastChanged, params Directory[] directories) : this(name, lastChanged, new List<File>(), directories)
        { 

        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public DateTime LastChangedOn
        {
            get { return this.lastChangedOn; }
            set { this.lastChangedOn = value; }
        }

        public Directory Parrent
        {
            get { return this.parrent; }
            set { this.parrent = value; }
        }

        public SortedSet<File> Files
        {
            get { return this.files; }
            set { this.files = value; }
        }

        public SortedSet<Directory> Directories
        {
            get { return this.directories; }
            set { this.directories = value; }
        }        

        public void AddFile(File file)
        {
            if (file.ParentDirectory != null)
            {
                throw new ArgumentException($"The file allready have parrent directory! File: {file.Name}; Directory: {file.ParentDirectory.Name}");
            }

            files.Add(file);
            file.ParentDirectory = this;
        }

        public void RemoveFile(File file)
        {
            if (files.Remove(file))
            {
                file.ParentDirectory = null;
            }
        }

        public void AddDirectory(Directory directory)
        {
            if (directory.Parrent != null)
            {
                throw new ArgumentException($"The directory allready have parrent directory! Directory: {directory.Name}; Parent Directory: {directory.Name}");
            }

            directories.Add(directory);
            directory.Parrent = this;
        }

        public void RemoveDirectory(Directory directory)
        {
            if (directories.Remove(directory))
            {
                directory.Parrent = null;
            }
        }

        public string GetFilesAndDirectories()
        {
            StringBuilder fileSystemBuilder = new StringBuilder();
            foreach (File file in files)
            {
                fileSystemBuilder.AppendLine(file.ToString());
            }

            foreach (Directory directory in directories)
            {
                fileSystemBuilder.AppendLine(directory.ToString());
            }

            return fileSystemBuilder.ToString();
        }

        public int CompareTo(Directory otherDirectory)
        {
            return this.Name.CompareTo(otherDirectory.Name);
        }

        public override string ToString()
        {
            return this.Name;
        }        
    }
}