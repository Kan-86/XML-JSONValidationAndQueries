
using LibraryBooksIndex.Service;
using System;

namespace LibraryBooksIndex.UI
{
    public class LibraryIndexController
    {
        LibraryIndexService _libService;
        public void AveragePriceOfBooks(string name)
        {
            _libService = new LibraryIndexService();
            _libService.AveragePriceOfBooks(name);
        }

        public void GetTitleWithPrice(double price)
        {
            _libService = new LibraryIndexService();
            _libService.GetTitleWithPrice(price);
        }

        public void SearchForUserByName(string name)
        {
            _libService = new LibraryIndexService();
            _libService.SearchForUserByName(name);
        }

        internal void ValidateJson()
        {
            _libService = new LibraryIndexService();
            _libService.ValidateJSONSchema();
        }
    }
}
