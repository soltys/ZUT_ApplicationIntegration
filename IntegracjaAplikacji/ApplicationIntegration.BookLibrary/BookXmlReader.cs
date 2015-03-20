using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ApplicationIntegration.BookLibrary
{
    public class BookXmlReader
    {
        public IEnumerable<Book> GetAllBooks()
        {
            XmlSerializer ser = new XmlSerializer(typeof(Books));
            Books books;
            using (XmlReader reader = XmlReader.Create(EmbeddedData.AsStream("books.xml")))
            {
                books = (Books)ser.Deserialize(reader);
            }

            return books.Book;
        }

    }
}