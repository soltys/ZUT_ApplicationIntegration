using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using NUnit.Framework;

namespace ApplicationIntegration.BookLibrary.Tests
{
    [TestFixture]
    public class XPathTests
    {
        [Test]
        public void SelectAllBooksAndCountThem()
        {
            using (StreamReader reader = new StreamReader("Data/books.xml"))
            {
                XmlDocument document = new XmlDocument();

                document.Load(reader);
                var bookNodes = document.SelectNodes("/books/book");
                Assert.IsNotNull(bookNodes);
                Assert.AreEqual(3, bookNodes.Count);
            }
        }

        [Test]
        public void SelectByIsbn()
        {
            using (StreamReader reader = new StreamReader("Data/books.xml"))
            {
                XmlDocument document = new XmlDocument();

                document.Load(reader);
                var bookNode = document.SelectSingleNode("//books/book[isbn='978-83-246-2785-1']");
                Assert.IsNotNull(bookNode);
                Assert.AreEqual("Java. Ćwiczenia praktyczne. Wydanie III, PHP", bookNode.SelectSingleNode("title").InnerText);
            }
        }

        [Test]
        public void SelectByAuthor()
        {
            using (StreamReader reader = new StreamReader("Data/books.xml"))
            {
                XmlDocument document = new XmlDocument();
                document.Load(reader);
                var bookNode = document.SelectNodes("//books/book/authors[author='Marcin Lis']");
                Assert.IsNotNull(bookNode);
                Assert.AreEqual(1, bookNode.Count);
            }
        }

        [Test]
        public void SelectByTitleAndYear()
        {
            using (StreamReader reader = new StreamReader("Data/books.xml"))
            {
                XmlDocument document = new XmlDocument();
                document.Load(reader);
                var xpath = @"/books/book[contains(title, 'PHP') and year>2009]";
                var bookNode = document.SelectNodes(xpath);
                Assert.IsNotNull(bookNode);
                Assert.AreEqual(1, bookNode.Count);
            }
        }

        [Test]
        public void SelectNodesWithMultipleAuthors()
        {
            using (StreamReader reader = new StreamReader("Data/books.xml"))
            {
                XmlDocument document = new XmlDocument();
                document.Load(reader);
                var xPathAuthors = @"authors/author";
                var xpath = string.Format(@"//books/book[count({0}) >2]/title", xPathAuthors);
                var bookNode = document.SelectNodes(xpath);
                Assert.IsNotNull(bookNode);
                Assert.AreEqual(1, bookNode.Count);
            }
        }

        [Test]
        public void SelectByIsbnFirstPart()
        {
            using (StreamReader reader = new StreamReader("Data/books.xml"))
            {
                XmlDocument document = new XmlDocument();
                document.Load(reader);

                var xpath = string.Format(@"//books/book[substring(isbn,0,7)='978-83']/isbn");
                var bookNode = document.SelectNodes(xpath);
                Assert.IsNotNull(bookNode);
                Assert.AreEqual(2, bookNode.Count);
            }
        }

        [Test]
        public void SelectByTitleLength()
        {
            using (StreamReader reader = new StreamReader("Data/books.xml"))
            {
                XmlDocument document = new XmlDocument();
                document.Load(reader);

                var xpath = string.Format(@"//books/book[string-length(title)>110]/isbn");
                var bookNode = document.SelectNodes(xpath);
                Assert.IsNotNull(bookNode);
                Assert.AreEqual(0, bookNode.Count);
            }
        }
    }
    
}
