using System.Text;

namespace _20_21Library
{
    public class Book
    {
        private string title;
        private string author;
        private string publisher;
        private int publishingYear;
        private string isbn;

        public Book(string title, string author, string publisher, int publishingYear, string isbn)
        {
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            this.publishingYear = publishingYear;
            this.isbn = isbn;
        }

        public string Title
        {
            get { return this.title; }
        }

        public string Author
        {
            get { return this.author; }
        }

        public string Publisher
        {
            get { return this.publisher; }
        }

        public int PublishingYear
        {
            get { return this.publishingYear; }
        }

        public string ISBN
        {
            get { return this.isbn; }
        }        

        public override string ToString()
        {
            StringBuilder bookBuilder = new StringBuilder();

            bookBuilder.AppendLine("Title: " + this.Title);
            bookBuilder.AppendLine("Author: " + this.Author);
            bookBuilder.AppendLine("Publisher: " + this.Publisher);
            bookBuilder.AppendLine("Year of publishing: " + this.publishingYear);
            bookBuilder.Append("ISBN: " + this.ISBN);

            return bookBuilder.ToString();
        }
    }
}