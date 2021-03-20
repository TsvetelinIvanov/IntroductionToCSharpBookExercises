using System.Text;

namespace _20_21Library
{
    public class LibraryTest
    {
        private Library library = new Library("My Library");
        private Book book1 = new Book("Foundation", "Isaak Asimov", "Bantam Spectra Books", 1991, "0553293354");
        private Book book2 = new Book("Animal Farm", "George Orwell", "Rupa Publications", 2016, "9788129116123");
        private Book book3 = new Book("It", "Stephen King", "Scribner", 2016, "1501142976");
        private Book book4 = new Book("Misery", "Stephen King", "Pocket Books", 2017, "1501156748");

        public string TestLibrary()
        {
            StringBuilder libraryBuilder = new StringBuilder();
            libraryBuilder.AppendLine(this.library.AddBook(this.book1));
            libraryBuilder.AppendLine(this.library.AddBook(this.book2));
            libraryBuilder.AppendLine(this.library.AddBook(this.book3));
            libraryBuilder.AppendLine(this.library.AddBook(this.book4));
            libraryBuilder.AppendLine(this.library.ShowAllBooks());
            libraryBuilder.AppendLine(this.library.SearchBooksByAuthor("Stephen King"));
            libraryBuilder.AppendLine(this.library.DeleteAllBooksByAuthor("Stephen King"));
            libraryBuilder.AppendLine(this.library.ShowAllBooks());

            return libraryBuilder.ToString();
        }
    }
}