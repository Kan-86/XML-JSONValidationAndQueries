using LibraryBooksIndex.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooksIndex.UI
{
    public class UnvalidatedController
    {
        UnvalidatedXpathQueries _libService;
        public void AveragePriceOfBooks(string name)
        {
            _libService = new UnvalidatedXpathQueries();
            _libService.AveragePriceOfBooks(name);
        }

        public void GetTitleWithPrice(string price)
        {
            _libService = new UnvalidatedXpathQueries();
            _libService.GetTitleWithPrice(price);
        }

        public void SearchForUserByName(string name)
        {
            _libService = new UnvalidatedXpathQueries();
            _libService.SearchForUserByName(name);
        }
    }
}
