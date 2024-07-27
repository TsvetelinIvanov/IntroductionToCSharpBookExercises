using System;
using System.Collections.Generic;
using System.Text;

namespace _04RealFileSystem
{
    public class Device : IComparable<Device>
    {
        private string name;
        private Directory root;

        public Device(string name, Directory root)
        {
            this.name = name;
            this.root = root;
        }

        public Device() : this(String.Empty, new Directory())
        {

        }

        public Device(string name, string rootName, DateTime rootLastChanged, IEnumerable<File> files, params Directory[] children) : this(name, new Directory(rootName, rootLastChanged, files, children))
        {

        }

        public Device(string name, string rootName, DateTime rootLastChanged, params Directory[] children) : this(name, rootName, rootLastChanged, new HashSet<File>(), children)
        {

        }        

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Directory Root
        {
            get { return this.root; }
            set { this.root = value; }
        }

        public int CompareTo(Device otherDevice)
        {
            return this.Name.CompareTo(otherDevice.Name);
        }

        public override string ToString()
        {
            return "Device: " + this.name + Environment.NewLine + DepthFirstSearchTraversal(this.Root, String.Empty);
        }

        public static string DepthFirstSearchTraversal(Directory directory, string path)
        {
            StringBuilder fileSystemBuilder = new StringBuilder();
            StringBuilder pathBuilder = new StringBuilder(path);
            pathBuilder.Append(directory.Name + '\\');
            fileSystemBuilder.AppendLine(pathBuilder.ToString());

            foreach (File file in directory.Files)
            {
                fileSystemBuilder.AppendLine(pathBuilder + file.ToString());
            }

            foreach (Directory subdirectory in directory.Directories)
            {
                fileSystemBuilder.Append(DepthFirstSearchTraversal(subdirectory, pathBuilder.ToString()));
            }

            return fileSystemBuilder.ToString();
        }        
    }
}
