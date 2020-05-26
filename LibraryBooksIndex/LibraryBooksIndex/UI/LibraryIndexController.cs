using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace LibraryBooksIndex.UI
{
    public class LibraryIndexController
    {
        private XPathNavigator nav;
        private XPathDocument docNav;
        private XPathNodeIterator NodeIter;

        private string xmlPath = ConfigurationManager.AppSettings["Path"];
        private string strExpression;

        public void GetAllDocument()
        {
            // Load the document and set the root element.  
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            XmlNode root = doc.DocumentElement;

            // Add the namespace.  
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("bk", "urn:newbooks-schema");

            // Select all nodes where the book price is greater than 10.00.  
            XmlNodeList nodeList = root.SelectNodes(
                 "descendant::bk:BooksRented[bk:Price>1500]", nsmgr);
            foreach (XmlNode book in nodeList)
            {
                Console.WriteLine(book.OuterXml);
            }

            // Display the updated document.  
            doc.Save(Console.Out);
            Console.ReadLine();
        }
    }
}
