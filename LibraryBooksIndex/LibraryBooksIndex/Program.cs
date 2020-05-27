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
        private static LibraryIndexUnvalidatedController unvalLibs;
        static void Main(string[] args)
        {
            Console.WriteLine("Press 'v' for validated queries, anything else for unvalidated.");
            var val = Console.ReadLine();


            Console.WriteLine("Library Index Query\n" +
            "\t 1.  Average Price of Books \n" +
            "\t 2.  Get Titles with specific price \n" +
            "\t 3.  Search for user by name");

            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    CalculatedAverage(val);
                    break;
                case "2":
                    GetTitleWithPrice(val);
                    break;
                case "3":
                    SearchForUserName(val);
                    break;
                default:
                    break;
            }
        }

        private static void SearchForUserName(string val)
        {
            libs = new LibraryIndexController();
            unvalLibs = new LibraryIndexUnvalidatedController();
            Console.Clear();
            Console.WriteLine("Please input name you want to search for:");
            var name = Console.ReadLine();
            Console.Clear();
            if (val == "v")
            {
                libs.SearchForUserByName(name);
            }
            else
            {
                unvalLibs.SearchForUserByName(name);
            }
        }

        private static void GetTitleWithPrice(string val)
        {
            libs = new LibraryIndexController();
            unvalLibs = new LibraryIndexUnvalidatedController();
            Console.Clear();
            Console.WriteLine("Please insert the price (Between 0 and 2599:");
            var price = Console.ReadLine();
            Console.Clear();
            if (val == "v")
            {
                libs.GetTitleWithPrice(price);
            }
            else
            {
                unvalLibs.GetTitleWithPrice(price);
            }
        }

        private static void CalculatedAverage(string val)
        {
            libs = new LibraryIndexController();
            unvalLibs = new LibraryIndexUnvalidatedController();
            Console.Clear();
            Console.WriteLine("Please insert the name to count Average price");
            var avrg = Console.ReadLine();
            Console.Clear();
            if (val == "v")
            {
                libs.AveragePriceOfBooks(avrg);
            }
            else
            {
                unvalLibs.AveragePriceOfBooks(avrg);
            }
        }
    }
}
