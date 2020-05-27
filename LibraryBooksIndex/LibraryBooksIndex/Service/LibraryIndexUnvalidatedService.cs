using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryBooksIndex.Service
{
    public class LibraryIndexUnvalidatedService
    {
        private string xmlPath = ConfigurationManager.AppSettings["UnvalidatedXML"];
        private XElement purchaseOrder;
        public void AveragePriceOfBooks(string name)
        {
            purchaseOrder = XElement.Load(xmlPath);

            IEnumerable<XElement> getUser = from item in purchaseOrder.Descendants("User")
                                            where (string)item.Element("Name") == name
                                            orderby (string)item.Element("Name")
                                            select item;

            
            foreach (var item in getUser)
            {
                var amount = item.Descendants("BooksRented").Count();
                double val = 0;
                foreach (var ssss in item.Descendants("BooksRented"))
                {

                    val += (double)ssss.Element("Price");
                }
                Console.WriteLine($"Average price for {name} books " + val/amount);
                Console.ReadLine();
            }


        }

        public void GetTitleWithPrice(string price)
        {

        }

        public void SearchForUserByName(string name)
        {

        }
    }
}
