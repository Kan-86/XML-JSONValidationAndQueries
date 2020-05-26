using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooksIndex.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Books> BooksRented { get; set; }
    }
}
