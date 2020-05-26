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
        static void Main(string[] args)
        {
            LibraryIndexController libs = new LibraryIndexController();
            Console.WriteLine("Library Index Query\n" +
                "\t 1.  Average Price of Books \n" +
                "\t 2.  Get Titles with specific price");

            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    libs.AveragePriceOfBooks();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Please insert the price");
                    var price = Console.ReadLine();
                    libs.GetTitleWithPrice(price);
                    break;
                default:
                    break;
            }
        }
    }
}
