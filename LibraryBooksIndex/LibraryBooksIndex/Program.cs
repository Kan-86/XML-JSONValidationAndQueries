using LibraryBooksIndex.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooksIndex
{
    class Program
    {
        private static LibraryIndexController libs;
        static void Main(string[] args)
        {
            Console.WriteLine("Library Index Query\n" +
                "\t 1.  Average Price of Books \n" +
                "\t 2.  Get Titles with specific price \n" +
                "\t 3.  Search for user by name");

            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    CalculatedAverage();
                    break;
                case "2":
                    GetTitleWithPrice();
                    break;
                case "3":
                    SearchForUserName();
                    break;
                default:
                    break;
            }
        }

        private static void SearchForUserName()
        {
            libs = new LibraryIndexController();
            Console.Clear();
            Console.WriteLine("Please input name you want to search for:");
            var name = Console.ReadLine();
            Console.Clear();
            libs.SearchForUserByName(name);
        }

        private static void GetTitleWithPrice()
        {
            libs = new LibraryIndexController();
            Console.Clear();
            Console.WriteLine("Please insert the price (Between 0 and 2599:");
            var price = Console.ReadLine();
            Console.Clear();
            libs.GetTitleWithPrice(price);
        }

        private static void CalculatedAverage()
        {
            libs = new LibraryIndexController();
            Console.Clear();
            Console.WriteLine("Please insert the name to count Average price");
            var avrg = Console.ReadLine();
            Console.Clear();
            libs.AveragePriceOfBooks(avrg);
        }
    }
}
