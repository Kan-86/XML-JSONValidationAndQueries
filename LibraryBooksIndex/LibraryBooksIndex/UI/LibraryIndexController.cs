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

        public void AveragePriceOfBooks()
        {
            OpenXML();

            // Find the average cost of a book.
            // This expression uses standard XPath syntax.
            strExpression = "sum(/Library/User/BooksRented/Price) div count(/Library/User/BooksRented/Price)";

            // Use the Evaluate method to return the evaluated expression.
            Console.WriteLine("The average cost of the books are {0}", nav.Evaluate(strExpression));

            // Pause
            Console.ReadLine();
        }

        public void GetTitleWithPrice(string price)
        {
            OpenXML();
            // Find the title of the books that are greater then 1500Kr
            strExpression = $"/Library/User/BooksRented/Title[../Price>{price}]";

            // Select the node and place the results in an iterator.
            NodeIter = nav.Select(strExpression);

            //Iterate through the results showing the element value.
            while (NodeIter.MoveNext())
            {
                Console.WriteLine("Book Title: {0}", NodeIter.Current.Value);
            };

            // Pause
            Console.ReadLine();
        }

        private void OpenXML()
        {
            // Open the XML.
            docNav = new XPathDocument(xmlPath);

            // Create a navigator to query with XPath.
            nav = docNav.CreateNavigator();

            XmlNamespaceManager ns = null;
            if (nav.NameTable != null)
            {
                ns = new XmlNamespaceManager(nav.NameTable);
                ns.AddNamespace("abbr", "urn:newbooks-schema");
            }
        }
    }
}
