using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Model
{
    public class AuthorConference
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int ConferenceId { get; set; }
        public Conference Conference { get; set; }
    }
}
