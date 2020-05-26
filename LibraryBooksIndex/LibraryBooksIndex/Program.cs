using LibraryBooksIndex.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooksIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryIndexController libs = new LibraryIndexController();
            libs.GetAllDocument();
        }
    }
}
