using System;

namespace _11FileParseException
{
    public class FileParseException : Exception
    {
        private string fileName;
        private string message;
        private int row;

        public FileParseException(string message)
        {
            this.message = message;
        }

        public FileParseException(string message, Exception innerException) : base(null, innerException)
        {
            this.message = message;
        }

        public FileParseException(string fileName, int row, Exception innerException)
            : base(null, innerException)
        {
            this.FileName = fileName;
            this.Row = row;
        }

        public FileParseException(string fileName, int row)
        {
            this.FileName = fileName;
            this.Row = row;
            this.message = string.Format("Invalid input format. Input: {0}. Row: {1}.", this.FileName, this.Row);
        }

        
        public string FileName
        {
            get { return this.fileName; }
            private set { this.fileName = value; }
        }
        
        public int Row
        {
            get { return this.row; }
            private set { this.row = value; }
        }
        
        public override string Message
        {
            get { return this.message; }
        }
    }
}