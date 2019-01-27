using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Model
{
    public class Store
    {
        public int StoreID { get; set; }

        [StringLength(50)]
        public string NameStore { get; set; }

        public ICollection<BookStore> BookStores { get; set; } = new List<BookStore>();
    }
}
