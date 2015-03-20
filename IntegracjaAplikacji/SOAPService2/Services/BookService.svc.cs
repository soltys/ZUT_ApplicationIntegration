using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ApplicationIntegration.BookLibrary;
using AutoMapper;

namespace SOAPService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BookService.svc or BookService.svc.cs at the Solution Explorer and start debugging.
    public class BookService : IBookService
    {
        public IEnumerable<BookDto> GetAllBooks()
        {
            BookXmlReader bookXmlReader = new BookXmlReader();
            var result = bookXmlReader.GetAllBooks();

            return result.Select(Mapper.Map<BookDto>);
        }

        public PublisherDto GetPublisher(string id)
        {
            return new PublisherDto
            {
                Id = id,
                Name = "Soltys",
                Url = "http://blog.soltysiak.co.pl"
            };
        }
    }
}