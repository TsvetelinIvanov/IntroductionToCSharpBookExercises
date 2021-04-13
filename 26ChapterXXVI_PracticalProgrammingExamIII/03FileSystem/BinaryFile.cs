using System;

namespace _03FileSystem
{
    public class BinaryFile : File
    {
        private byte[] content;

        public BinaryFile(string name, DateTime createdOn, DateTime lastChangedOn, byte[] content) : base(name, createdOn, lastChangedOn, FileType.Binary)
        {
            this.Content = content;
        }

        public byte[] Content
        {
            get { return this.content; }
            set { this.content = value; }
        }
    }
}