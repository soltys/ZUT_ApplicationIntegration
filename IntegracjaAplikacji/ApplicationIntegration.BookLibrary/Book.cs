using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationIntegration.BookLibrary
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }
        public int Pages { get; set; }

        public Book()
        {
            
        }

        public Book(string id, string title, string author, string isbn, int year, string publisher, int pages)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = isbn;
            Year = year;
            Publisher = publisher;
            Pages = pages;
        }

    }
}
