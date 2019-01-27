using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Model
{
    public class BookStore
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
