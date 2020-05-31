using LibraryBooksIndex.Repos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;
using System.Xml.XPath;

namespace LibraryBooksIndex.Service
{
    public class LibraryIndexService
    {
        private XPathNavigator nav;
        private XPathDocument docNav;
        private XPathNodeIterator NodeIter;
        XmlNamespaceManager ns;
        private string xmlPath = ConfigurationManager.AppSettings["ValidatedXML"];
        private string xsdPath = ConfigurationManager.AppSettings["ValidateSchema"];
        private string bookxml = ConfigurationManager.AppSettings["BooksXML"];
        private string strExpression;

        LibraryIndexRepo _libRepo;
        ValidateXMLService validate;

        List<object> lisob;

        public void AveragePriceOfBooks(string name)
        {
            _libRepo = new LibraryIndexRepo();
            OpenXML();

            // Find the average cost of a book.
            // This expression uses standard XPath syntax.
            strExpression = $"sum(/Library/User/BooksRented[../Name = '{name}']/Price) " +
                $"div count(/Library/User/BooksRented[../Name = '{name}']/Price)";


            double total = (double)nav.Evaluate(strExpression);

            // Use the Evaluate method to return the evaluated expression.
            Console.WriteLine($"The average price of the books for user {name} is {string.Format("{0:0.00}", total)}" );

            // Pause
            Console.ReadLine();
        }

        public void GetTitleWithPrice(double price)
        {
            _libRepo = new LibraryIndexRepo();
            OpenXML();

            // Find the title of the books that are greater then inserted price
            strExpression = $"/Library/User[//Price>{price}]";

            // Select the node and place the results in an iterator.
            NodeIter = nav.Select(strExpression);

            if (NodeIter.Count != 0)
            {
                Console.WriteLine("Books that cost more than: " + price);
                //Iterate through the results showing the element value.
                while (NodeIter.MoveNext())
                {
                    Console.WriteLine(NodeIter.Current.OuterXml);
                };
            }
            else
            {
                Console.WriteLine("Error, Not Found: Please search for values between 0 - 2599.");
            }
            // Pause
            Console.ReadLine();
        }

        public void SearchForUserByName(string name)
        {
            OpenXML();
            lisob = new List<object>();
            strExpression = $"/Library/User[contains(string(), '{name}')]";

            NodeIter = nav.Select(strExpression);

            if (NodeIter.Count != 0)
            {
                //Iterate through the results showing the element value.
                while (NodeIter.MoveNext())
                {
                    Console.WriteLine("User: {0}", NodeIter.Current.OuterXml);
                };
            }
            else
            {
                Console.WriteLine("Error, Not Found: Please try again!");
            }
            // Pause
            Console.ReadLine();
        }

        public void ValidateXML()
        {
            validate = new ValidateXMLService();
            validate.ValidateXMLFile(xsdPath, bookxml);
        }

        private void OpenXML()
        {
            // Open the XML.
            docNav = new XPathDocument(xmlPath);

            // Create a navigator to query with XPath.
            nav = docNav.CreateNavigator();
            if (nav.NameTable != null)
            {
                ns = new XmlNamespaceManager(nav.NameTable);
                ns.AddNamespace("abbr", "http://tempuri.org/LibraryDTD");
            }
        }
    }
}
