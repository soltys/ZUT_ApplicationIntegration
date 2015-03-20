using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;

namespace ApplicationIntegration.BookLibrary.Tests
{
    [TestFixture]
    class BookXmlReaderTests
    {
        [Test]
        public void GetAllBooksTest()
        {
            BookXmlReader bookXmlReader = new BookXmlReader();
            var result = bookXmlReader.GetAllBooks();
            Assert.AreEqual(3, result.Count());
        }
    }
}
