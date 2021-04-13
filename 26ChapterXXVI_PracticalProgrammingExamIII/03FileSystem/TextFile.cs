using System;

namespace _03FileSystem
{
    public class TextFile : File
    {
        private string content;

        public TextFile(string name, DateTime createdOn, DateTime lastChangedOn, string content) : base(name, createdOn, lastChangedOn, FileType.Text)
        {
            this.Content = content;
        }         

        public string Content
        {
            get { return this.content; }
            set { this.content = value; }
        }
    }
}