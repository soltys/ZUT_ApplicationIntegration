using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationIntegration.BookLibrary
{
    public class BookManager
    {
        private List<Book> _books;

        public BookManager(List<Book> books )
        {
            _books = books;
        }

        public IEnumerable<Book> SearchByTitle(string searchedTitle)
        {
            return _books.Where(book => book.Title.Contains(searchedTitle));
        }

        public IEnumerable<Book> SearchByAuthor(string author)
        {
            return _books.Where(book => book.Title.Contains(author));
        }
        public Book SearchByIsbn(string isbn)
        {
            return _books.FirstOrDefault(book => book.ISBN == isbn);
        }
    }
}
