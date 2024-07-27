using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _20_21Library
{
    public class Library
    {
        private string name;
        private List<Book> books;

        public Library(string name)
        {
            this.name = name;
            this.books = new List<Book>();
        }

        public string Name
        {
            get { return this.name; }            
        }

        internal List<Book> Books
        {
            get { return this.books; }            
        }        

        public string AddBook(Book book)
        {
            this.books.Add(book);
            
            return $"Book with title {book.Title}, from author {book.Author} is added to library.";
        }

        public string ShowAllBooks()
        {
            if (this.books.Count > 0)
            {
                StringBuilder allBooksBuilder = new StringBuilder("The books in the library are:" + Environment.NewLine);
                foreach (Book book in this.books)
                {
                    allBooksBuilder.AppendLine(book.ToString());
                }

                return allBooksBuilder.ToString();
            }
            else
            {
                return "There are no books in the library!";
            }
        }

        public string SearchBooksByAuthor(string author)
        {
            Book[] booksByAuthor = this.books.Where(b => b.Author == author).ToArray();
            if (booksByAuthor.Length > 0)
            {
                StringBuilder booksByAuthorBuilder = new StringBuilder($"The books in the library from author {author} are:" + Environment.NewLine);
                foreach (Book book in booksByAuthor)
                {
                    booksByAuthorBuilder.AppendLine(book.ToString());
                }
                
                return booksByAuthorBuilder.ToString();
            }
            else
            {
                return $"Not found books from author {author}!";
            }
        }

        public string SearchBooksByTitle(string title)
        {
            Book[] booksByTitle = this.books.Where(b => b.Title == title).ToArray();
            if (booksByTitle.Length > 0)
            {
                StringBuilder booksByTitleBuilder = new StringBuilder($"The books in the library with title {title} are:" + Environment.NewLine);
                foreach (Book book in booksByTitle)
                {
                    booksByTitleBuilder.AppendLine(book.ToString());
                }

                return booksByTitleBuilder.ToString();
            }
            else
            {
                return $"Not found books with title {title}!";
            }
        }

        public string SearchBookByISBN(string isbn)
        {
            Book book = this.books.FirstOrDefault(b => b.ISBN == isbn);
            if (book != null)
            {                
                return book.ToString();
            }
            else
            {
                return $"Not found book with ISBN {isbn}!";
            }
        }       

        public string DeleteBookByISBN(string isbn)
        {
            Book book = this.books.FirstOrDefault(b => b.ISBN == isbn);
            if (book != null)
            {
                this.books.Remove(book);
                return "Deleted book:" + Environment.NewLine + book.ToString();
            }
            else
            {
                return $"Not found book with ISBN {isbn}!";
            }
        }

        public string DeleteAllBooksByAuthor(string author)
        {          
            int deletedBooksCount = books.RemoveAll(b => b.Author == author);

            return $"There was deleted {deletedBooksCount} books from author {author}!";
        }
    }
}
