
using LibraryBooksIndex.Service;

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

        public void GetTitleWithPrice(string price)
        {
            _libService = new LibraryIndexService();
            _libService.GetTitleWithPrice(price);
        }

        public void SearchForUserByName(string name)
        {
            _libService = new LibraryIndexService();
            _libService.SearchForUserByName(name);
        }
    }
}
