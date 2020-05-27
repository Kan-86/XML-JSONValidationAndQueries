using LibraryBooksIndex.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooksIndex.UI
{
    public class LibraryIndexUnvalidatedController
    {
        LibraryIndexUnvalidatedService _libService;
        public void AveragePriceOfBooks(string name)
        {
            _libService = new LibraryIndexUnvalidatedService();
            _libService.AveragePriceOfBooks(name);
        }

        public void GetTitleWithPrice(string price)
        {
            _libService = new LibraryIndexUnvalidatedService();
            _libService.GetTitleWithPrice(price);
        }

        public void SearchForUserByName(string name)
        {
            _libService = new LibraryIndexUnvalidatedService();
            _libService.SearchForUserByName(name);
        }
    }
}
