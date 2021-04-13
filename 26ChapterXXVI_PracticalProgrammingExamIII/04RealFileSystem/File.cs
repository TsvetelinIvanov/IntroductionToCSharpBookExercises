using System;

namespace _04RealFileSystem
{
    public abstract class File : IComparable<File>
    {
        private string name;
        private DateTime createdOn;
        private DateTime lastChangedOn;
        private FileType type;        
        private Directory parentDirectory;        

        public File(string name, DateTime createdOn, DateTime lastChangedOn, FileType type)
        {
            this.Name = name;
            this.CreatedOn = createdOn;
            this.LastChangedOn = lastChangedOn;
            this.Type = type;            
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public DateTime CreatedOn
        {
            get { return this.createdOn; }
            set { this.createdOn = value; }
        }

        public DateTime LastChangedOn
        {
            get { return this.lastChangedOn; }
            set { this.lastChangedOn = value; }
        }

        public FileType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public Directory ParentDirectory
        {
            get { return this.parentDirectory; }
            set { this.parentDirectory = value; }
        }

        public int CompareTo(File otherFile)
        {
            return this.Name.CompareTo(otherFile.Name);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}