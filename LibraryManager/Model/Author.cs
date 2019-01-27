using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace LibraryManager.Model
{
    public class Author
    {
        public int AuthorID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(75)]
        public string Surname { get; set; }
        public ICollection <Book> Books { get; set; } = new List<Book>();
        public ICollection<AuthorConference> AuthorConferences { get; set; } = new List<AuthorConference>();

    }
}
