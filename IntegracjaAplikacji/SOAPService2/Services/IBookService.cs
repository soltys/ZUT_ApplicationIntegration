using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SOAPService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBookService" in both code and config file together.
    [ServiceContract]
    public interface IBookService
    {

        [OperationContract]
        IEnumerable<BookDto> GetAllBooks();

        [OperationContract]
        PublisherDto GetPublisher(string id);
    }


    
    
    
}
